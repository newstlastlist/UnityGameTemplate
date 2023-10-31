namespace Infrastructure.States
{

    public interface IPayloadedState<TPayload> : IState
    {
        void Enter(TPayload payload);
    }

    public interface IState
    {
        void Enter();
        void Exit();
    }
}