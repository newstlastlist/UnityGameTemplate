using System;
using System.Collections.Generic;
using Zenject;

namespace Infrastructure.States
{
    public class GameStateMachine
    {
        private Dictionary<Type, IExitableState> _states;
        private IExitableState _activeState;

        private LoadLevelState _loadLevelState;
        private BootstrapState _bootstrapState;
        private GameLoopState _gameLoopState;
        private LoadProgressState _loadProgressState;
        
        [Inject]
        public GameStateMachine(LoadLevelState loadLevelState, BootstrapState bootstrapState, GameLoopState gameLoopState, LoadProgressState loadProgressState)
        {
            _loadLevelState = loadLevelState;
            _bootstrapState = bootstrapState;
            _gameLoopState = gameLoopState;
            _loadProgressState = loadProgressState;
            
            _states = new Dictionary<Type, IExitableState>
            {
                [typeof(BootstrapState)] = _bootstrapState,
                [typeof(LoadLevelState)] = _loadLevelState,
                [typeof(GameLoopState)] = _gameLoopState,
                [typeof(LoadProgressState)] = _loadProgressState,
            };
        }

        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
        {
            TState state = ChangeState<TState>();
            state.Enter(payload);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _activeState?.Exit();

            TState state = GetState<TState>();
            _activeState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState =>
            _states[typeof(TState)] as TState;
    }
}