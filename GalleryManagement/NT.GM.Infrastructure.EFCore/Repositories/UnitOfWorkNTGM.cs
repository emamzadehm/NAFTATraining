using _01.Framework.Infrastructure.EFCore;
using NT.GM.Domain;

namespace NT.GM.Infrastructure.EFCore.Repositories
{
    public class UnitOfWorkNTGM : UnitOfWork, IUnitOfWorkNTGM
    {
        private readonly NTGMContext _ntcontext;
        public UnitOfWorkNTGM(NTGMContext ntgmcontext) : base(ntgmcontext)
        {
            _ntcontext = ntgmcontext;
        }
    }
}
