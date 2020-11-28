using System.Collections.Generic;
using _01.Framework.Application;
using NT.CM.Application.Contracts;
using NT.CM.Application.Contracts.ViewModels.Courses;
using NT.CM.Domain;
using NT.CM.Domain.CourseAgg;

namespace NT.CM.Application
{
    public class CourseApplication : ICourseApplication
    {
        private readonly ICourseRepository _courserepository;
        private readonly IBaseInfoRepository _ibaseInfoRepository;
        private readonly IUnitOfWorkNT _IUnitOfWorkNT;
        private readonly IFileUploader _ifileuploader;

        public CourseApplication(ICourseRepository courserepository, IBaseInfoRepository ibaseInfoRepository, 
            IUnitOfWorkNT iUnitOfWorkNT, IFileUploader ifileuploader)
        {
            _courserepository = courserepository;
            _ibaseInfoRepository = ibaseInfoRepository;
            _IUnitOfWorkNT = iUnitOfWorkNT;
            _ifileuploader = ifileuploader;
        }

        public OperationResult Create(CourseViewModel command)
        {
            _IUnitOfWorkNT.BeginTran();
            var operationresult = new OperationResult();
            var CourseCategory = _ibaseInfoRepository.GetBy(command.CategoryID);
            var CourseLevel = _ibaseInfoRepository.GetBy(command.CourseLevel);
            var path = $"AdminPanel\\Pages\\CourseManagement\\Uploads\\CourseCatalog\\{(CourseCategory.Title).Slugify()}\\{(command.CName).Slugify()}\\{(CourseLevel.Title).Slugify()}";
            var filename = _ifileuploader.Upload(command.CourseCatalog, path);
            var NewItem = new Course(command.CName, command.Description, command.Audience, command.DailyPlan, command.Cost, filename, command.CourseLevel, command.Duration, command.CategoryID);
            _courserepository.Create(NewItem);
            _IUnitOfWorkNT.CommitTran();
            return operationresult.Successful();
        }

        public OperationResult Edit(CourseViewModel command)
        {
            _IUnitOfWorkNT.BeginTran();
            var operationresult = new OperationResult();
            var SelectedItem = _courserepository.GetBy(command.ID);
            var CourseCategory = _ibaseInfoRepository.GetBy(command.CategoryID);
            var CourseLevel = _ibaseInfoRepository.GetBy(command.CourseLevel);
            var path = $"AdminPanel\\Pages\\CourseManagement\\Uploads\\CourseCatalog\\{(CourseCategory.Title).Slugify()}\\{(command.CName).Slugify()}\\{(CourseLevel.Title).Slugify()}";
            var filename = _ifileuploader.Upload(command.CourseCatalog, path);
            SelectedItem.Edit(command.CName, command.Description, command.Audience, command.DailyPlan, command.Cost, filename, command.CourseLevel, command.Duration, command.CategoryID);
            _IUnitOfWorkNT.CommitTran();
            return operationresult.Successful();
        }

       
        public OperationResult Remove(long id)
        {
            _IUnitOfWorkNT.BeginTran();
            var operationresult = new OperationResult();
            var SelectedItem = _courserepository.GetBy(id);
            SelectedItem.Remove();
            _IUnitOfWorkNT.CommitTran();
            return operationresult.Successful();
        }

        public CourseViewModel GetBy(long id)
        {
            return _courserepository.GetDetails(id);
        }

        public List<CourseViewModel> Search(CourseViewModel searchmodel = null)
        {
            return _courserepository.Search(searchmodel);
        }

    }
}
