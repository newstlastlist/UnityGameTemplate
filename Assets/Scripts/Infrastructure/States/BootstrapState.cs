using Infrastructure.SceneManagement;
using Zenject;

namespace Infrastructure.States
{
    public class BootstrapState : IState
    {
        private const string BootStrap = "BootstrapScene";
        private GameStateMachine _stateMachine;
        private SceneLoader _sceneLoader;

        [Inject]
        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            _sceneLoader.Load(BootStrap, onLoaded: EnterLoadLevel);
        }

        public void Exit()
        {
        }

        private void EnterLoadLevel()
        {
            _stateMachine.Enter<LoadLevelState, string>("Level1");
        }
    }
}