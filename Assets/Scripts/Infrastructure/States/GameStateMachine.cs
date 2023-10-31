using System;
using System.Collections.Generic;

namespace Infrastructure.States
{
    public class GameStateMachine
    {
        private Dictionary<Type, IState> _states = new Dictionary<Type, IState>();
        private IState _activeState;
        
        // [Inject]
        // public GameStateMachine(IStateFactory stateFactory)
        // {
        //     _states = new Dictionary<Type, IExitableState>
        //     {
        //         [typeof(BootstrapState)] = stateFactory.Create<BootstrapState>(),
        //         [typeof(LoadLevelState)] = stateFactory.CreatePayloadedState<LoadLevelState>(),
        //         [typeof(GameLoopState)] = stateFactory.Create<GameLoopState>(),
        //         [typeof(LoadProgressState)] = stateFactory.Create<LoadProgressState>()
        //     };
        // }
        // public GameStateMachine(Dictionary<Type, IExitableState> states)
        // {
        //     _states = states;
        // }
        public void AddState(Type stateType,IState state)
        {
            _states.Add(stateType, state);
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

        private TState ChangeState<TState>() where TState : class, IState
        {
            _activeState?.Exit();

            TState state = GetState<TState>();
            _activeState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, IState =>
            _states[typeof(TState)] as TState;
    }
}