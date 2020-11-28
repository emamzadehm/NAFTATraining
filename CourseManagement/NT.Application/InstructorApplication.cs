using _01.Framework.Application;
using NT.CM.Application.Contracts.Interfaces;
using NT.CM.Application.Contracts.ViewModels.Instructors;
using NT.CM.Domain;
using NT.CM.Domain.InstructorAgg;
using NT.UM.Domain.UsersAgg;
using System.Collections.Generic;
using NT.UM.Domain;

namespace NT.CM.Application
{
    public class InstructorApplication : IInstructorApplication
    {
        private readonly IInstructorRepository _iinstructorRepository;
        private readonly IUsersRepository _iuserRepository;
        private readonly IUnitOfWorkNT _IUnitOfWorkNT;
        private readonly IFileUploader _ifileuploader;

        public InstructorApplication(IInstructorRepository iinstructorRepository, IUsersRepository iuserRepository,
            IUnitOfWorkNT iUnitOfWorkNT, IFileUploader ifileuploader)
        {
            _iinstructorRepository = iinstructorRepository;
            _iuserRepository = iuserRepository;
            _IUnitOfWorkNT = iUnitOfWorkNT;
            _ifileuploader = ifileuploader;
        }

        public OperationResult Create(InstructorsViewModel command)
        {
            _IUnitOfWorkNT.BeginTran();
            var operationresult = new OperationResult();
            long uId = CreateUser(command);
            var NewItem = new Instructor(command.EducationLevel, command.Resume, uId);
            _iinstructorRepository.Create(NewItem);
            _IUnitOfWorkNT.CommitTran();
            return operationresult.Successful();
        }

        private long CreateUser(InstructorsViewModel command)
        {
            var path = $"AdminPanel//Pages//UsersManagement//Uploads//";
            var foldername = command.LastName + " " + command.FirstName;
            var filenameIMG = _ifileuploader.Upload(command.IMG, path + foldername.Slugify() + $"//IMG");
            var filenameIDCardIMG = _ifileuploader.Upload(command.IDCardIMG, path + foldername.Slugify() + $"//IDCardIMG");
            var NewItem = new Users(command.FirstName, command.LastName, command.Sex, command.Email, filenameIMG, command.Tel, command.Password, filenameIDCardIMG);
            _iuserRepository.Create(NewItem);
            _iuserRepository.Save();
            return NewItem.ID;
        }

        public OperationResult Edit(InstructorsViewModel command)
        {
            _IUnitOfWorkNT.BeginTran();
            var operationresult = new OperationResult();
            var SelectedItem = _iinstructorRepository.GetBy(command.ID);
            EditUser(SelectedItem.UserId,command);
            SelectedItem.Edit(command.EducationLevel, command.Resume);
            _IUnitOfWorkNT.CommitTran();
            return operationresult.Successful();
        }

        private void EditUser(long userId, InstructorsViewModel command)
        {
            var SelectedUser = _iuserRepository.GetBy(userId);
            var path = $"AdminPanel//Pages//UsersManagement//Uploads//";
            var foldername = command.LastName + " " + command.FirstName;
            var filenameIMG = _ifileuploader.Upload(command.IMG, path + foldername.Slugify() + $"//IMG");
            var filenameIDCardIMG = _ifileuploader.Upload(command.IDCardIMG, path + foldername.Slugify() + $"//IDCardIMG");
            SelectedUser.Edit(command.FirstName, command.LastName, command.Sex, command.Tel, filenameIMG, command.Password, filenameIDCardIMG);
            _iuserRepository.Save();
        }

        public OperationResult Remove(long id)
        {
            _IUnitOfWorkNT.BeginTran();
            var operationresult = new OperationResult();
            var SelectedItem = _iinstructorRepository.GetBy(id);
            var SelectedUser = _iuserRepository.GetBy(SelectedItem.UserId);
            SelectedUser.Remove();
            SelectedItem.Remove();
            _IUnitOfWorkNT.CommitTran();
            return operationresult.Successful();
        }

        public InstructorsViewModel GetBy(long id)
        {
            return _iinstructorRepository.GetDetails(id);
        }

        public List<InstructorsViewModel> Search(InstructorsViewModel searchmodel = null)
        {
            return _iinstructorRepository.Search(searchmodel);
        }
    }
}
