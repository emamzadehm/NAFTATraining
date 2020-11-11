using _01.Framework.Infrastructure.EFCore;
using NT.CM.Application.Contracts;
using NT.CM.Domain;
using NT.CM.Domain.CandidateAgg;
using System;
using System.Collections.Generic;

namespace NT.CM.Infrastructure.EFCore.Repositories
{
    public class CandidateRepository : BaseRepository<long, Candidate>,ICandidateRepository
    {

        private readonly NTContext _ntcontext;
        public CandidateRepository(NTContext context) : base(context)
        {
            _ntcontext = context;
        }

        public List<CandidateViewModel> Search(CandidateViewModel command)
        {
            throw new NotImplementedException();
        }


        //public void Create(Candidate command)
        //{

        //    _ntcontext.Tbl_Candidate.Add(command);
        //    Save();
        //}

        //public void Save()
        //{
        //    _ntcontext.SaveChanges();
        //}
    }
}
