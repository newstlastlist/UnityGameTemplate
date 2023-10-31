using System;
using Zenject;

namespace Infrastructure.States.StatesFactory
{
    public class StateFactory : IStateFactory
    {
        private readonly DiContainer _container;

        [Inject]
        public StateFactory(DiContainer container)
        {
            _container = container;
        }

        public IState Create<T>() where T : IState
        {
            return _container.Instantiate<T>();
        }

        public IPayloadedState<string> CreatePayloadedState<T>() where T : IPayloadedState<string>
        {
            return _container.Instantiate<T>();
        }
    }
}