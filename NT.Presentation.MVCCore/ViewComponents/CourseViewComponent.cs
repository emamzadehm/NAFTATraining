using Microsoft.AspNetCore.Mvc;
using NT.Infrastructure.Query.Interface;

namespace NT.Presentation.MVCCore.ViewComponents
{
    public class CourseViewComponent : ViewComponent
    {
        //public List<CourseQueryView> Courses { get; set; }
        private readonly ICourseQuery _coursequery;

        public CourseViewComponent(ICourseQuery coursequery)
        {
            _coursequery = coursequery;
        }

        public IViewComponentResult Invoke()
        {
            var Courses = _coursequery.CourseList();
            return View(Courses);
        }
    }
}