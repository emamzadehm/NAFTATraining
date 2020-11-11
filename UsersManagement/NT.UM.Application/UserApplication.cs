using _01.Framework.Application;
using NT.UM.Application.Contracts;
using NT.UM.Application.Contracts.Interfaces;
using NT.UM.Domain;
using NT.UM.Domain.UsersAgg;
using System.Collections.Generic;

namespace NT.UM.Application
{
    public class UserApplication : IUserApplication
    {
        private readonly IUsersRepository _userRepository;
        private readonly IUnitOfWorkNTUM _iUnitOfWork;

        public UserApplication(IUsersRepository userRepository, IUnitOfWorkNTUM iUnitOfWork)
        {
            _userRepository = userRepository;
            _iUnitOfWork = iUnitOfWork;
        }

        //public void Create(CandidateViewModel command)
        //{
        //    _iUnitOfWork.BeginTran();
        //    var NewCandidate = new Users(command.FirstName, command.LastName, command.Sex, command.Email, command.IMG, command.Tel, command.Password, command.IDCardIMG, command.CompanyID,command.NID,command.DOB,command.NationalityID,command.CityOfBirth, 1);
        //    _userRepository.Create(NewCandidate);
        //    _iUnitOfWork.CommitTran();
        //}

        //public void Create(InstructorsViewModel command)
        //{
        //    _iUnitOfWork.BeginTran();
        //    var NewInstructor = new Users(command.FirstName, command.LastName, command.Sex, command.Email, command.IMG, command.Tel, command.Password, command.IDCardIMG,command.EducationLevel, command.Resume,1);
        //    _userRepository.Create(NewInstructor);
        //    _iUnitOfWork.CommitTran();
        //}

        public OperationResult Create(UsersViewModel command)
        {
            _iUnitOfWork.BeginTran();
            var operationresult = new OperationResult();
            var NewItem = new Users(command.FirstName, command.LastName, command.Sex, command.Email, command.IMG, command.Tel, command.Password, command.IDCardIMG);
            _userRepository.Create(NewItem);
            _iUnitOfWork.CommitTran();
            return operationresult.Successful();
        }
        public OperationResult Edit(UsersViewModel command)
        {
            _iUnitOfWork.BeginTran(); 
            var operationresult = new OperationResult();
            var SelectedItem = _userRepository.GetBy(command.ID);
            SelectedItem.Edit(command.FirstName, command.LastName, command.Sex,command.Tel, command.IMG, command.Password, command.IDCardIMG);

            _iUnitOfWork.CommitTran();
            return operationresult.Successful();
            //if (command.RoleID == 1)
            //    { 
            //        var SelectedInstructor = _instructorRepository.GetBy(command.ID);
            //        SelectedInstructor.Edit(command.FirstName, command.LastName, command.Sex, command.IMG, command.Tel, command.Password,command.IDCardIMG, command.EducationLevel, command.Resume);
            //    }
            //else
            //    {
            //        var SelectedCandidate = _candidateRepository.GetBy(command.ID);
            //        SelectedCandidate.Edit(command.FirstName, command.LastName, command.Sex, command.IMG, command.Tel, command.Password, command.IDCardIMG, command.CompanyID, command.NID, command.DOB, command.NationalityID, command.CityOfBirth);
            //    }
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
                IMG = SelectedUser.IMG,
                Tel = SelectedUser.Tel,
                Password = SelectedUser.Password,
                IDCardIMG = SelectedUser.IDCardIMG,
                //EducationLevel = SelectedUser.Instructors?.EducationLevel,
                //Resume = SelectedUser.Instructors?.Resume,
                //CompanyID = SelectedUser.Candidates?.CompanyID,
                //NID = SelectedUser.Candidates?.NID,
                //DOB = SelectedUser.Candidates?.DOB,
                //NationalityID = SelectedUser.Candidates?.NationalityID,
                //CityOfBirth = SelectedUser.Candidates?.CityOfBirth,
                //UsersRoless = new List<UsersRoles>().Where(x => x.UserID == SelectedUser.ID).ToList()
            };
        }

        public List<UsersViewModel> Search(UsersViewModel searchmodel)
        {
            return _userRepository.Search(searchmodel);
        }


        //////public List<UsersViewModel> List()
        //////{
        //////    var AllUsers = _userRepository.GetAll();
        //////    return AllUsers.Select(users => new UsersViewModel
        //////    {
        //////        ID= users.ID,
        //////        FirstName= users.FirstName,
        //////        LastName= users.LastName,
        //////        Fullname= users.FirstName + " " + users.LastName,
        //////        Sex = users.Sex,
        //////        Email=users.Email,
        //////        IMG= users.IMG,
        //////        Tel= users.Tel,
        //////        Password= users.Password,
        //////        IDCardIMG=users.IDCardIMG,
        //////        //EducationLevel= users.Instructors?.EducationLevel,
        //////        //Resume= users.Instructors?.Resume,
        //////        //CompanyID=users.Candidates?.CompanyID,
        //////        //NID = users.Candidates?.NID,
        //////        //DOB = users.Candidates?.DOB,
        //////        //NationalityID = users.Candidates?.NationalityID,
        //////        //CityOfBirth = users.Candidates?.CityOfBirth
        //////        //UsersRoless = new List<UsersRoles>().Where(x => x.UserID == users.ID).ToList()
        //////    }).ToList();
        //////}

    }
}
