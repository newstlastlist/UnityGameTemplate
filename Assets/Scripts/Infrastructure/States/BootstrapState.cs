using Infrastructure.SceneManagement;
using Settings;
using UnityEngine;
using Zenject;

namespace Infrastructure.States
{
    public class BootstrapState : IState
    {
        
        private GameStateMachine _stateMachine;
        private SceneLoader _sceneLoader;
        private ApplicationSettings _applicationSettings;

        [Inject]
        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, ApplicationSettings applicationSettings)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _applicationSettings = applicationSettings;
        }

        public void Enter()
        {
            Application.targetFrameRate = _applicationSettings.TargetFrameRate;
            _sceneLoader.Load(ConstString.BootStrap, onLoaded: EnterLoadLevel);
        }

        public void Exit()
        {
        }

        private void EnterLoadLevel()
        {
            _stateMachine.Enter<LoadLevelState, string>(ConstString.Level1);
        }
    }
}