using Infrastructure.States;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class GameBootstrapper : MonoBehaviour
    {
        private Game _game;

        [Inject]
        public void Construct(Game game)
        {
            _game = game;
        }

        private void Start()
        {
            print(_game == null);
            _game.StateMachine.Enter<BootstrapState>();
            
            DontDestroyOnLoad(this);
        }
    }
}