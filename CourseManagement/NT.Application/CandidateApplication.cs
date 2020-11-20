using _01.Framework.Application;
using NT.CM.Application.Contracts;
using NT.CM.Application.Contracts.ViewModels.Candidates;
using NT.CM.Domain;
using NT.CM.Domain.CandidateAgg;
using NT.UM.Domain;
using NT.UM.Domain.UsersAgg;
using System.Collections.Generic;

namespace NT.CM.Application
{
    public class CandidateApplication : ICandidateApplication
    {
        private readonly ICandidateRepository _icandidaterepository;
        private readonly IUsersRepository _iuserrepository;
        private readonly IUnitOfWorkNT _IUnitOfWorkNT;

        public CandidateApplication(ICandidateRepository icandidaterepository, IUsersRepository iuserrepository, IUnitOfWorkNT iUnitOfWorkNT)
        {
            _icandidaterepository = icandidaterepository;
            _iuserrepository = iuserrepository;
            _IUnitOfWorkNT = iUnitOfWorkNT;
        }

        public OperationResult Create(CandidateViewModel command)
        {
            var operationresult = new OperationResult();
            _IUnitOfWorkNT.BeginTran();
            long uid = NewUser(command);
            var Newitem = new Candidate(command.CompanyID, command.NID, command.DOB, command.NationalityID, command.CityOfBirth, uid);
            _icandidaterepository.Create(Newitem);
            _IUnitOfWorkNT.CommitTran();
            return operationresult.Successful();
        }

        public OperationResult Edit(CandidateViewModel command)
        {
            var operationresult = new OperationResult();
            _IUnitOfWorkNT.BeginTran();
            var selecteditem = _icandidaterepository.GetBy(command.ID);
            EditUser(command);
            selecteditem.Edit(command.CompanyID, command.NID, command.DOB, command.NationalityID, command.CityOfBirth);
            _IUnitOfWorkNT.CommitTran();
            return operationresult.Successful();
        }

        public CandidateViewModel GetDetails(long id)
        {
            return _icandidaterepository.GetDetails(id);
        }

        private long NewUser(CandidateViewModel command)
        {
            var NewItem = new Users(command.FirstName, command.LastName, command.Sex, command.Email, command.IMG, command.Tel, command.Password, command.IDCardIMG);
            _iuserrepository.Create(NewItem);
            _iuserrepository.Save();
            return NewItem.ID;

        }

        private void EditUser(CandidateViewModel command)
        {
            var SelectedItem = _iuserrepository.GetBy(command.UserID);
            SelectedItem.Edit(command.FirstName, command.LastName, command.Sex, command.Tel, command.IMG, command.Password, command.IDCardIMG);
            _iuserrepository.Save();
        }

        public OperationResult Remove(long id)
        {
            var operationresult = new OperationResult();
            _IUnitOfWorkNT.BeginTran();
            var SelectedItem = _icandidaterepository.GetBy(id);
            var SelectedUser = _iuserrepository.GetBy(SelectedItem.UserId);
            SelectedUser.Remove();
            SelectedItem.Remove();
            _IUnitOfWorkNT.CommitTran();
            return operationresult.Successful();
        }

        public List<CandidateViewModel> Search(CandidateViewModel searchmodel)
        {
            return _icandidaterepository.Search(searchmodel);
        }
    }
}
