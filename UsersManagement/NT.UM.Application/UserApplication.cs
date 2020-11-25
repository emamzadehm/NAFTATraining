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

        public UserApplication(IUsersRepository userRepository, IUnitOfWorkNTUM iUnitOfWork, IFileUploader ifileuploader)
        {
            _userRepository = userRepository;
            _iUnitOfWork = iUnitOfWork;
            _ifileuploader = ifileuploader;
        }

        public OperationResult Create(UsersViewModel command)
        {
            _iUnitOfWork.BeginTran();
            var operationresult = new OperationResult();
            var path = $"AdminPanel//UsersManagement//Uploads//";
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
            var path = $"AdminPanel//UsersManagement//Uploads//";
            var foldername = command.LastName + " " + command.FirstName;
            var filenameIMG = _ifileuploader.Upload(command.IMG, path + foldername.Slugify() + $"//IMG");
            var filenameIDCardIMG = _ifileuploader.Upload(command.IDCardIMG, path + foldername.Slugify() + $"//IDCardIMG");

            SelectedItem.Edit(command.FirstName, command.LastName, command.Sex,command.Tel, filenameIMG, command.Password, filenameIDCardIMG);

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

        public UsersViewModel GetBy(long id)
        {
            var SelectedUser = _userRepository.GetBy(id);
            return new UsersViewModel
            {
                ID = SelectedUser.ID,
                FirstName = SelectedUser.FirstName,
                LastName = SelectedUser.LastName,
                Sex = SelectedUser.Sex,
                Email = SelectedUser.Email,
                IMGFileAddress = SelectedUser.IMG,
                Tel = SelectedUser.Tel,
                Password = SelectedUser.Password,
                IDCardIMGFileAddress = SelectedUser.IDCardIMG           
            };
        }

        public List<UsersViewModel> Search(UsersViewModel searchmodel = null)
        {
            return _userRepository.Search(searchmodel);
        }

    }
}
