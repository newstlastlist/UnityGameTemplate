using Infrastructure.States;
using Zenject;

namespace Infrastructure
{
    public class Game
    {
        public GameStateMachine StateMachine;
        
        [Inject]
        public Game(GameStateMachine gameStateMachine)
        {
            StateMachine = gameStateMachine;
        }
        
    }
}