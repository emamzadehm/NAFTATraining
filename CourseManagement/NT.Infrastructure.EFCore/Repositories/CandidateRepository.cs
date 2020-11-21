using _01.Framework.Infrastructure.EFCore;
using NT.CM.Application.Contracts.ViewModels.Candidates;
using NT.CM.Domain;
using NT.CM.Domain.CandidateAgg;
using NT.UM.Infrastructure.EFCore;
using System.Collections.Generic;
using System.Linq;

namespace NT.CM.Infrastructure.EFCore.Repositories
{
    public class CandidateRepository : BaseRepository<long, Candidate>,ICandidateRepository
    {

        private readonly NTContext _ntcontext;
        private readonly NTUMContext _ntumcontext;
        public CandidateRepository(NTContext context, NTUMContext ntumcontext) : base(context)
        {
            _ntcontext = context;
            _ntumcontext = ntumcontext;
        }
        public CandidateViewModel GetDetails(long id)
        {
            var users = _ntumcontext.Tbl_Users.Where(x => x.Status == true).Select(x => new { x.ID, x.FirstName, x.LastName, x.Sex, x.Email, x.Tel, x.IMG, x.IDCardIMG, x.Password }).ToList();
            var candidates = _ntcontext.Tbl_Candidate
                                .Where(x => x.Status == true)
                                .Select(listitem => new CandidateViewModel
                                {
                                    ID = listitem.ID,
                                    CompanyID = listitem.CompanyID,
                                    DOB=listitem.DOB,
                                    NID=listitem.NID,
                                    NationalityID=listitem.NationalityID,
                                    CityOfBirth=listitem.CityOfBirth,
                                    UserID = listitem.UserId
                                }).ToList();

            foreach (var candidate in candidates)
            {
                var userCandidate = users.FirstOrDefault(x => x.ID == candidate.UserID);
                if (userCandidate != null)
                {
                    candidate.UserID = userCandidate.ID;
                    candidate.Fullname = userCandidate.Sex + " " + userCandidate.FirstName + " " + userCandidate.LastName;
                    candidate.Sex = userCandidate.Sex;
                    candidate.FirstName = userCandidate.FirstName;
                    candidate.LastName = userCandidate.LastName;
                    candidate.Email = userCandidate.Email;
                    candidate.Tel = userCandidate.Tel;
                    candidate.IMG = userCandidate.IMG;
                    candidate.IDCardIMG = userCandidate.IDCardIMG;
                    candidate.Password = userCandidate.Password;
                }
            };

            return candidates.FirstOrDefault(x => x.ID == id);
        }

        public List<CandidateViewModel> Search(CandidateViewModel command = null)
        {

            var users = _ntumcontext.Tbl_Users.Where(x => x.Status == true).Select(x => new { x.ID, x.FirstName, x.LastName, x.Sex, x.Email, x.Tel, x.IMG, x.IDCardIMG, x.Password }).ToList();
            var candidates = _ntcontext.Tbl_Candidate
                                .Where(x => x.Status == true)
                                .Select(listitem => new CandidateViewModel
                                {
                                    ID = listitem.ID,
                                    CompanyID = listitem.CompanyID,
                                    DOB = listitem.DOB,
                                    NID = listitem.NID,
                                    NationalityID = listitem.NationalityID,
                                    CityOfBirth = listitem.CityOfBirth,
                                    UserID = listitem.UserId
                                }).ToList();

            foreach (var candidate in candidates)
            {
                var userCandidate = users.FirstOrDefault(x => x.ID == candidate.UserID);
                if (userCandidate != null)
                {
                    candidate.UserID = userCandidate.ID;
                    candidate.Fullname = userCandidate.Sex + " " + userCandidate.FirstName + " " + userCandidate.LastName;
                    candidate.Sex = userCandidate.Sex;
                    candidate.FirstName = userCandidate.FirstName;
                    candidate.LastName = userCandidate.LastName;
                    candidate.Email = userCandidate.Email;
                    candidate.Tel = userCandidate.Tel;
                    candidate.IMG = userCandidate.IMG;
                    candidate.IDCardIMG = userCandidate.IDCardIMG;
                    candidate.Password = userCandidate.Password;
                }
            };
            if (command != null)
            {
                if (!string.IsNullOrWhiteSpace(command.NID))
                    candidates = candidates.Where(x => x.NID.Contains(command.NID)).ToList();
            }

            return candidates.OrderBy(x => x.ID).ToList();
        }
    }
}
