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
        private readonly IFileUploader _ifileuploader;

        public CandidateApplication(ICandidateRepository icandidaterepository, IUsersRepository iuserrepository,
            IUnitOfWorkNT iUnitOfWorkNT, IFileUploader ifileuploader)
        {
            _icandidaterepository = icandidaterepository;
            _iuserrepository = iuserrepository;
            _IUnitOfWorkNT = iUnitOfWorkNT;
            _ifileuploader = ifileuploader;
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
            var path = $"AdminPanel//UsersManagement//Uploads//";
            var foldername = command.LastName + " " + command.FirstName + " " + command.CompanyName;
            var filenameIMG = _ifileuploader.Upload(command.IMG, path + foldername.Slugify() + $"//IMG");
            var filenameIDCardIMG = _ifileuploader.Upload(command.IDCardIMG, path + foldername.Slugify() + $"//IDCardIMG");
            var NewItem = new Users(command.FirstName, command.LastName, command.Sex, command.Email, filenameIMG, command.Tel, command.Password, filenameIDCardIMG);
            _iuserrepository.Create(NewItem);
            _iuserrepository.Save();
            return NewItem.ID;

        }

        private void EditUser(CandidateViewModel command)
        {
            var SelectedItem = _iuserrepository.GetBy(command.UserID);
            var path = $"AdminPanel//UsersManagement//Uploads//";
            var foldername = command.LastName + " " + command.FirstName + " " + command.CompanyName;
            var filenameIMG = _ifileuploader.Upload(command.IMG, path + foldername.Slugify() + $"//IMG");
            var filenameIDCardIMG = _ifileuploader.Upload(command.IDCardIMG, path + foldername.Slugify() + $"//IDCardIMG");
            SelectedItem.Edit(command.FirstName, command.LastName, command.Sex, command.Tel, filenameIMG, command.Password, filenameIDCardIMG);
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

        public List<CandidateViewModel> Search(CandidateViewModel searchmodel = null)
        {
            return _icandidaterepository.Search(searchmodel);
        }
    }
}
