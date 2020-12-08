using _01.Framework.Application;
using NT.UM.Application.Contracts.Interfaces;
using NT.UM.Application.Contracts.ViewModels;
using NT.UM.Domain;
using NT.UM.Domain.UsersAgg;
using System.Collections.Generic;

namespace NT.UM.Application
{
    public class UserApplication : IUserApplication
    {
        private readonly IUsersRepository _userRepository;
        private readonly IUnitOfWorkNTUM _iUnitOfWork;
        private readonly IFileUploader _ifileuploader;
        private readonly IPasswordHasher _ipasswordhasher;

        public UserApplication(IUsersRepository userRepository, IUnitOfWorkNTUM iUnitOfWork,
            IFileUploader ifileuploader, IPasswordHasher ipasswordhasher)
        {
            _userRepository = userRepository;
            _iUnitOfWork = iUnitOfWork;
            _ifileuploader = ifileuploader;
            _ipasswordhasher = ipasswordhasher;
        }

        public OperationResult Create(UsersViewModel command)
        {
            _iUnitOfWork.BeginTran();
            var operationresult = new OperationResult();
            var path = $"UsersManagement//";
            var foldername = command.LastName + " " + command.FirstName;
            var filenameIMG = _ifileuploader.Upload(command.IMG, path + foldername.Slugify() + $"//IMG");
            var filenameIDCardIMG = _ifileuploader.Upload(command.IDCardIMG, path + foldername.Slugify() + $"//IDCardIMG");
            var NewItem = new Users(command.FirstName, command.LastName, command.Sex, command.Email, filenameIMG, command.Tel, command.Password, filenameIDCardIMG);
            _userRepository.Create(NewItem);
            _iUnitOfWork.CommitTran();
            return operationresult.Successful();
        }
        public OperationResult Edit(UsersViewModel command)
        {
            _iUnitOfWork.BeginTran(); 
            var operationresult = new OperationResult();
            var SelectedItem = _userRepository.GetBy(command.ID);
            var path = $"UsersManagement//";
            var foldername = command.LastName + " " + command.FirstName;
            var filenameIMG = _ifileuploader.Upload(command.IMG, path + foldername.Slugify() + $"//IMG");
            var filenameIDCardIMG = _ifileuploader.Upload(command.IDCardIMG, path + foldername.Slugify() + $"//IDCardIMG");
            SelectedItem.Edit(command.FirstName, command.LastName, command.Sex,command.Tel, filenameIMG, filenameIDCardIMG);
            _iUnitOfWork.CommitTran();
            return operationresult.Successful();
        }

        public OperationResult Remove(long id)
        {
            _iUnitOfWork.BeginTran();
            var operationresult = new OperationResult();
            var SelectedItem = _userRepository.GetBy(id);
            SelectedItem.Remove();
            _iUnitOfWork.CommitTran();
            return operationresult.Successful();
        }

        public UsersViewModel GetDetails(long id)
        {
            return _userRepository.GetDetails(id);
        }

        public List<UsersViewModel> Search(UsersViewModel searchmodel = null)
        {
            return _userRepository.Search(searchmodel);
        }

        public OperationResult ChangePassword(long uid, string password)
        {
            _iUnitOfWork.BeginTran();
            var operationresult = new OperationResult();
            var SelectedItem = _userRepository.GetBy(uid);
            var Password = _ipasswordhasher.Hash(password);
            SelectedItem.ChangePassword(Password);
            _iUnitOfWork.CommitTran();
            return operationresult.Successful();
        }
    }
}
