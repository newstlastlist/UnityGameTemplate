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
        private readonly IGameFactory _gameFactory;
        
        private LoadingScreen _loadingScreen;

        [Inject]
        public SceneLoader(ICoroutineRunner coroutineRunner, IGameFactory gameFactory)
        {
            _coroutineRunner = coroutineRunner;
            _gameFactory = gameFactory;
        }

        public void Load(string name, Action onLoaded = null)
        {
            if (_loadingScreen == null)
            {
                _loadingScreen = _gameFactory.CreateLoadingScreen();
            }
            
            _coroutineRunner.StartCoroutine(LoadScene(name, onLoaded));
        }

        public IEnumerator LoadScene(string nextScene, Action onLoaded = null)
        {
            if (SceneManager.GetActiveScene().name == nextScene)
            {
                onLoaded?.Invoke();
                yield break;
            }

            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(nextScene);

            while (!waitNextScene.isDone)
                yield return null;

            onLoaded?.Invoke();
        }
    }
}