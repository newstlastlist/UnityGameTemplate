using Infrastructure.Factory;
using Infrastructure.SceneManagement;
using Infrastructure.Services.PersistentProgress;
using Zenject;

namespace Infrastructure.States
{
    public class LoadLevelState : IPayloadedState<string>, IState
    {
        private GameStateMachine _stateMachine;
        private SceneLoader _sceneLoader;
        private IGameFactory _gameFactory;
        private IPersistentProgressService _progressService;
        private readonly VariableJoystick _joystick;

        [Inject]
        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, IGameFactory gameFactory,
            IPersistentProgressService progressService, VariableJoystick joystick)
        {
            _stateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _gameFactory = gameFactory;
            _progressService = progressService;
            _joystick = joystick;
        }

        public void Enter(string sceneName)
        {
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Enter()
        {
        }

        public void Exit()
        {
        }

        private void OnLoaded()
        {
            //here we should init game world (create some hero/enemys etc via GameFactory)
            
            InformProgressReaders();
            
            _joystick.Show();
            
            _stateMachine.Enter<GameLoopState>();
        }

        //restore all saved progress for all entities
        //(dont forgot that all entities that may be saved should be in GameFactory.ProgressReaders)
        private void InformProgressReaders()
        {
            foreach (ISavedProgressReader progressReader in _gameFactory.ProgressReaders)
                progressReader.LoadProgress(_progressService.Progress);
        }
    }
}