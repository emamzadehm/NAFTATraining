using _01.Framework.Infrastructure.EFCore;
using NT.SM.Domain.Interfaces;

namespace NT.SM.Infrastructure.EFCore.Repository
{
    public class UnitOfWorkNTSM : UnitOfWork, IUnitOfWorkNTSM
    {
        private readonly NTSMContext _ntsmcontext;
        public UnitOfWorkNTSM(NTSMContext ntsmcontext) : base(ntsmcontext)
        {
            _ntsmcontext = ntsmcontext;
        }
    }
}
