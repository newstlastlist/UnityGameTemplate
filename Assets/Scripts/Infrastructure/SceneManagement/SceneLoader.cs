using System;
using System.Collections;
using Infrastructure.Factory;
using Infrastructure.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Infrastructure.SceneManagement
{
    public class SceneLoader
    {
        private readonly ICoroutineRunner _coroutineRunner;
        
        private LoadingScreen _loadingScreen;

        [Inject]
        public SceneLoader(ICoroutineRunner coroutineRunner, LoadingScreen loadingScreen)
        {
            _coroutineRunner = coroutineRunner;
            _loadingScreen = loadingScreen;
        }

        public void Load(string name, Action onLoaded = null)
        {
            _coroutineRunner.StartCoroutine(LoadScene(name, onLoaded));
        }

        public IEnumerator LoadScene(string nextScene, Action onLoaded = null)
        {
            _loadingScreen.Show();
            
            if (SceneManager.GetActiveScene().name == nextScene)
            {
                onLoaded?.Invoke();
                yield break;
            }

            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(nextScene);
            float startTime = Time.time;

            while (!waitNextScene.isDone)
            {
                _loadingScreen.UpdateProgress(waitNextScene.progress / 3);
                yield return null;
            }

            float loadingTime = Time.time - startTime;

            if (loadingTime < 3f)
            {
                _coroutineRunner.StartCoroutine(FakeLoadingAnimation(3f - loadingTime, onLoaded));
            }
            else
            {
                _loadingScreen.Hide();
                onLoaded?.Invoke();
            }
        }
        private IEnumerator FakeLoadingAnimation(float duration, Action onLoaded)
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

            _loadingScreen.UpdateProgress(1f);
            _loadingScreen.Hide();
            onLoaded?.Invoke();
        }
    }
}