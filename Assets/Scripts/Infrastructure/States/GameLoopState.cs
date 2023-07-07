using Zenject;

namespace Infrastructure.States
{
    public class GameLoopState : IState
    {
        private GameStateMachine _stateMachine;

        [Inject]
        public void Construct(GameStateMachine stateMachine)
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