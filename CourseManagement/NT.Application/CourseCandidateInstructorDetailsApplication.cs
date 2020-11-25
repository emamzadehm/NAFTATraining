using _01.Framework.Application;
using NT.CM.Application.Contracts.Interfaces;
using NT.CM.Application.Contracts.ViewModels.CourseCandidateInstructorDetails;
using NT.CM.Domain;
using NT.CM.Domain.CourseCandidateInstructorDetailsAgg;
using System.Collections.Generic;

namespace NT.CM.Application
{
    public class CourseCandidateInstructorDetailsApplication : ICourseCandidateInstructorDetailsApplication
    {
        private readonly ICourseCandidateInstructorDetailsRepository _icourseCandidateInstructorDetailsRepository;
        private readonly IUnitOfWorkNT _IUnitOfWorkNT;
        private readonly IFileUploader _ifileuploader;

        public CourseCandidateInstructorDetailsApplication(ICourseCandidateInstructorDetailsRepository icourseCandidateInstructorDetailsRepository,
            IUnitOfWorkNT iUnitOfWorkNT, IFileUploader ifileuploader)
        {
            _icourseCandidateInstructorDetailsRepository = icourseCandidateInstructorDetailsRepository;
            _IUnitOfWorkNT = iUnitOfWorkNT;
            _ifileuploader = ifileuploader;
        }

        public OperationResult Create(CourseCandidateInstructorDetailsViewModel command)
        {
            _IUnitOfWorkNT.BeginTran();
            var operationresult = new OperationResult();
            var path = $"AdminPanel//CourseManagement//Uploads//DocumentIMG//";
            var filename = _ifileuploader.Upload(command.DocumentIMG, path);
            var NewItem = new CourseCandidateInstructorDetails(command.TypeID,command.Value,filename,command.CCI_ID);
            _icourseCandidateInstructorDetailsRepository.Create(NewItem);
            _IUnitOfWorkNT.CommitTran();
            return operationresult.Successful();
        }

        public OperationResult Edit(CourseCandidateInstructorDetailsViewModel command)
        {
            _IUnitOfWorkNT.BeginTran();
            var operationresult = new OperationResult();
            var SelectedItem = _icourseCandidateInstructorDetailsRepository.GetBy(command.ID);
            var path = $"AdminPanel//CourseManagement//Uploads//DocumentIMG//";
            var filename = _ifileuploader.Upload(command.DocumentIMG, path);
            SelectedItem.Edit(command.TypeID, command.Value, filename, command.CCI_ID);
            _IUnitOfWorkNT.CommitTran();
            return operationresult.Successful();
        }

        public OperationResult Remove(long id)
        {
            _IUnitOfWorkNT.BeginTran();
            var operationresult = new OperationResult();
            var SelectedItem = _icourseCandidateInstructorDetailsRepository.GetBy(id);
            SelectedItem.Remove();
            _IUnitOfWorkNT.CommitTran();
            return operationresult.Successful();
        }

        public CourseCandidateInstructorDetailsViewModel GetBy(long id)
        {
            var SelectedItem = _icourseCandidateInstructorDetailsRepository.GetBy(id);
            var result = new CourseCandidateInstructorDetailsViewModel
            {
                ID = SelectedItem.ID,
                CCI_ID=SelectedItem.CCI_ID,
                FileAddress=SelectedItem.DocumentIMG,
                TypeID=SelectedItem.TypeID,
                Value=SelectedItem.Value,
                BaseInfoName=SelectedItem.BaseInfo.Title
            };
            return result;
        }

        public List<CourseCandidateInstructorDetailsViewModel> Search(CourseCandidateInstructorDetailsViewModel searchmodel = null)
        {
            return _icourseCandidateInstructorDetailsRepository.Search(searchmodel);
        }
    }
}
