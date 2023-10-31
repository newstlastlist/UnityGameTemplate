using UnityEngine;
using Zenject;

namespace Infrastructure.States
{
    public class GameLoopState : IState
    {
        #region Injections
        #endregion
        
        private GameStateMachine _stateMachine;

        [Inject]
        public GameLoopState(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Exit()
        {
        }

        public void Enter()
        {
        }
    }
}