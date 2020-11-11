using System.Collections.Generic;
using _01.Framework.Application;
using NT.CM.Application.Contracts;
using NT.CM.Domain;
using NT.CM.Domain.CourseAgg;

namespace NT.CM.Application
{
    public class CourseApplication : ICourseApplication
    {
        private readonly ICourseRepository _courserepository;
        private readonly IUnitOfWorkNT _IUnitOfWorkNT;

        public CourseApplication(ICourseRepository courserepository, IUnitOfWorkNT IUnitOfWorkNT)
        {
            _courserepository = courserepository;
            _IUnitOfWorkNT = IUnitOfWorkNT;
        }

        public OperationResult Create(CourseViewModel command)
        {
            _IUnitOfWorkNT.BeginTran();
            var operationresult = new OperationResult();
            var NewItem = new Course(command.CName, command.Description, command.Audience, command.DailyPlan, command.Cost, command.CourseCatalog, command.CourseLevel, command.Duration, command.CategoryID, command.IsPrivate);
            _courserepository.Create(NewItem);
            _IUnitOfWorkNT.CommitTran();
            return operationresult.Successful();
        }

        public OperationResult Edit(CourseViewModel command)
        {
            _IUnitOfWorkNT.BeginTran();
            var operationresult = new OperationResult();
            var SelectedItem = _courserepository.GetBy(command.ID);
            SelectedItem.Edit(command.CName, command.Description, command.Audience, command.DailyPlan, command.Cost, command.CourseCatalog, command.CourseLevel, command.Duration, command.CategoryID, command.IsPrivate);
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

            var SelectedItem = _courserepository.GetBy(id);
            var result = new CourseViewModel
            {
                ID = SelectedItem.ID,
                CName = SelectedItem.CName,
                Description = SelectedItem.Description,
                Audience = SelectedItem.Audience,
                DailyPlan = SelectedItem.DailyPlan,
                Cost = SelectedItem.Cost,
                CourseCatalog = SelectedItem.CourseCatalog,
                CourseLevel = SelectedItem.CourseLevel,
                Duration = SelectedItem.Duration,
                CategoryID = SelectedItem.CategoryID
            };

            return result;
        }

        public List<CourseViewModel> Search(CourseViewModel searchmodel)
        {
            return _courserepository.Search(searchmodel);
        }
        //public List<CourseViewModel> List()
        //{
        //    var courses = _courserepository.GetAll();
        //    var result = new List<CourseViewModel>();
        //    foreach (var course in courses)
        //    {
        //        result.Add(new CourseViewModel
        //        {
        //            ID = course.ID,
        //            CName = course.CName,
        //            Description = course.Description,
        //            Audience = course.Audience,
        //            DailyPlan = course.DailyPlan,
        //            Cost = course.Cost,
        //            CourseCatalog = course.CourseCatalog,
        //            CourseLevelTitle = course.BaseInfoCourseLevel?.Title,
        //            Duration = course.Duration,
        //            CategoryIDTitle = course.BaseInfoCategory?.Title
        //        });
        //    }
        //    return result;
        //}

    }
}
