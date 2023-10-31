namespace Infrastructure.States.StatesFactory
{
    public interface IStateFactory
    {
        IState Create<T>() where T : IState;
        IPayloadedState<string> CreatePayloadedState<T>() where T : IPayloadedState<string>;
    }
}