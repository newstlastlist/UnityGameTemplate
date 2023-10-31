using System;
using System.Collections;
using Infrastructure.Factory;
using Infrastructure.UI.GameLoop;
using Infrastructure.UI.LoadingScreen;
using Settings;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Infrastructure.SceneManagement
{
    public class SceneLoader
    {
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly DeveloperSettings _developerSettings;
        private readonly IGameLoopUIUsecase _gameLoopUIUsecase;
        private LoadingScreen _loadingScreen;

        [Inject]
        public SceneLoader(ICoroutineRunner coroutineRunner, LoadingScreen loadingScreen
            , DeveloperSettings developerSettings, IGameLoopUIUsecase gameLoopUIUsecase)
        {
            _coroutineRunner = coroutineRunner;
            _loadingScreen = loadingScreen;
            _developerSettings = developerSettings;
            _gameLoopUIUsecase = gameLoopUIUsecase;
        }

        public void Load(string name, Action onLoaded = null)
        {
            _coroutineRunner.StartCoroutine(LoadScene(name, onLoaded));
        }

        public IEnumerator LoadScene(string nextScene, Action onLoaded = null)
        {
            
            _gameLoopUIUsecase.SetLoadingState(true);
            
            _loadingScreen.Show();
            if (SceneManager.GetActiveScene().name == nextScene)
            {
                onLoaded?.Invoke();
                yield break;
            }
            
            void OnSceneLoaded(Scene scene, LoadSceneMode mode)
            {
                Debug.Log("Scene loaded: " + scene.name);
                SceneManager.sceneLoaded -= OnSceneLoaded;
                _loadingScreen.Hide();
                onLoaded?.Invoke();
            }
            
            SceneManager.sceneLoaded += OnSceneLoaded;

            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(nextScene);
            waitNextScene.allowSceneActivation = false;
            float startTime = Time.time;

            while (waitNextScene.progress < 0.9f)
            {
                _loadingScreen.UpdateProgress(waitNextScene.progress);
                yield return null;
            }

            float loadingTime = Time.time - startTime;
            
#if UNITY_EDITOR
            bool useFakeLoading = _developerSettings.FakeTimeLoadScene;
#else
            bool useFakeLoading = true;
#endif

            if (useFakeLoading && loadingTime < 3f)
            {
                yield return _coroutineRunner.StartCoroutine(FakeLoadingAnimation(3f - loadingTime));
            }
            else if (useFakeLoading)
            {
                float remainingTime = 3f - loadingTime;
                if (remainingTime > 0)
                {
                    yield return new WaitForSeconds(remainingTime);
                }
            }

            _loadingScreen.UpdateProgress(1f);
            waitNextScene.allowSceneActivation = true;
            
            _gameLoopUIUsecase.SetLoadingState(false);
        }

        private IEnumerator FakeLoadingAnimation(float duration)
        {
            float startTime = Time.time;
            float startProgress = _loadingScreen.CurrentProgress;

            while (Time.time - startTime < duration)
            {
                float elapsed = Time.time - startTime;
                float progress = Mathf.Lerp(startProgress, 1f, elapsed / duration);
                _loadingScreen.UpdateProgress(progress);
                yield return null;
            }
        }
    }
}