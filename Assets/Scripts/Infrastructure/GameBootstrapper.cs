using Infrastructure.Factory;
using Infrastructure.States;
using Infrastructure.States.StatesFactory;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class GameBootstrapper : MonoBehaviour
    {
        private Game _game;
        private IGameFactory _gameFactory;
        private IStateFactory _stateFactory;

        [Inject]
        public void Construct(Game game, IStateFactory stateFactory)
        {
            _stateFactory = stateFactory;
            _game = game;
        }
        private void Start()
        {
            InitStateMachine();
            
            _game.StateMachine.Enter<BootstrapState>();
            
            DontDestroyOnLoad(this);
        }

        private void InitStateMachine()
        {
            AddState<BootstrapState>();
            AddState<GameLoopState>();
            AddState<LoadProgressState>();
            AddState<LoadLevelState>();

            void AddState<T>() where T : IState
            {
                var state = _stateFactory.Create<T>();
                
                _game.StateMachine.AddState(typeof(T), state);
            }
        }
        
    }
}