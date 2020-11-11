using _01.Framework.Infrastructure.EFCore;
using NT.CM.Domain;

namespace NT.CM.Infrastructure.EFCore.Repositories
{
    public class UnitOfWorkNT : UnitOfWork, IUnitOfWorkNT
    {
        private readonly NTContext _ntcontext;
        public UnitOfWorkNT(NTContext ntcontext) : base(ntcontext)
        {
            _ntcontext = ntcontext;
        }
    }
}
