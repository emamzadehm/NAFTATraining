using _01.Framework.Infrastructure.EFCore;
using NT.UM.Domain;

namespace NT.UM.Infrastructure.EFCore.Repositories
{
    public class UnitOfWorkNTUM : UnitOfWork, IUnitOfWorkNTUM
    {
        private readonly NTUMContext _ntumcontext;
        public UnitOfWorkNTUM(NTUMContext ntumcontext) : base(ntumcontext)
        {
            _ntumcontext = ntumcontext;
        }
    }
}
