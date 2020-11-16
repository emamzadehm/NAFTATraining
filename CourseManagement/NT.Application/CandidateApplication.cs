using _01.Framework.Application;
using NT.CM.Application.Contracts;
using NT.CM.Application.Contracts.ViewModels.Candidates;
using NT.CM.Domain;
using NT.CM.Domain.CandidateAgg;
using System.Collections.Generic;

namespace NT.CM.Application
{
    public class CandidateApplication : ICandidateApplication
    {
        private readonly ICandidateRepository _icandidaterepository;
        private readonly IUnitOfWorkNT _IUnitOfWorkNT;

        public CandidateApplication(ICandidateRepository icandidaterepository, IUnitOfWorkNT IUnitOfWorkNT)
        {
            _icandidaterepository = icandidaterepository;
            _IUnitOfWorkNT = IUnitOfWorkNT;
        }

        public OperationResult Create(CandidateViewModel command)
        {
            var operationresult = new OperationResult();
            _IUnitOfWorkNT.BeginTran();
            var Newitem = new Candidate(command.CompanyID, command.NID, command.DOB, command.NationalityID, command.CityOfBirth);
            _icandidaterepository.Create(Newitem);
            _IUnitOfWorkNT.CommitTran();
            return operationresult.Successful();
        }

        public OperationResult Edit(CandidateViewModel command)
        {
            var operationresult = new OperationResult();
            _IUnitOfWorkNT.BeginTran();
            var selecteditem = _icandidaterepository.GetBy(command.ID);
            selecteditem.Edit(command.CompanyID, command.NID, command.DOB, command.NationalityID, command.CityOfBirth);
            _IUnitOfWorkNT.CommitTran();
            return operationresult.Successful();
        }

        public CandidateViewModel GetBy(long id)
        {
            var SelectedItem = _icandidaterepository.GetBy(id);
            return new CandidateViewModel
            {
                ID = SelectedItem.ID,
                CompanyID=SelectedItem.CompanyID,
                CityOfBirth=SelectedItem.CityOfBirth,
                DOB=SelectedItem.DOB,
                NationalityID=SelectedItem.NationalityID,
                NID=SelectedItem.NID
            };
        }


        public OperationResult Remove(long id)
        {
            var operationresult = new OperationResult();
            _IUnitOfWorkNT.BeginTran();
            var selecteditem = _icandidaterepository.GetBy(id);
            selecteditem.Remove();
            _IUnitOfWorkNT.CommitTran();
            return operationresult.Successful();
        }

        public List<CandidateViewModel> Search(CandidateViewModel searchmodel)
        {
            return _icandidaterepository.Search(searchmodel);
        }
    }
}
