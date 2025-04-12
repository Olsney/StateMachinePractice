namespace CodeBase.Infrastructure.StateMachine.Interfaces
{
    public interface IExitable : IState, IUpdatable
    {
        void Exit();
    }
}