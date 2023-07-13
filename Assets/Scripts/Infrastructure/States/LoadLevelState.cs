using Infrastructure.Factory;
using Infrastructure.SceneManagement;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.UI;
using Zenject;

namespace Infrastructure.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private GameStateMachine _stateMachine;
        private SceneLoader _sceneLoader;
        private LoadingScreen _loadingScreen;
        private IGameFactory _gameFactory;
        private IPersistentProgressService _progressService;

        [Inject]
        public void Construct(GameStateMachine gameStateMachine, SceneLoader sceneLoader, LoadingScreen loadingScreen, IGameFactory gameFactory,
            IPersistentProgressService progressService)
        {
            _stateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _loadingScreen = loadingScreen;
            _gameFactory = gameFactory;
            _progressService = progressService;
        }

        public void Enter(string sceneName)
        {
            // _loadingCurtain.Show();
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit()
        {
            // _loadingCurtain.Hide();
        }

        private void OnLoaded()
        {
            _stateMachine.Enter<GameLoopState>();
        }

        private void InformProgressReaders()
        {
            foreach (ISavedProgressReader progressReader in _gameFactory.ProgressReaders)
                progressReader.LoadProgress(_progressService.Progress);
        }
    }
}