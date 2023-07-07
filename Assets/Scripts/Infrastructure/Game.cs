using Infrastructure.States;
using Zenject;

namespace Infrastructure
{
    public class Game
    {
        [Inject]
        public GameStateMachine StateMachine;
        
    }
}