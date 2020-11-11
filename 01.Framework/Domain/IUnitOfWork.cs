namespace _01.Framework.Domain
{
    public interface IUnitOfWork
    {
        void BeginTran();
        void CommitTran();
        void RollBack();
    }
}
