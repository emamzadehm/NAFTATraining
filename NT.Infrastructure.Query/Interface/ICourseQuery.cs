using NT.Infrastructure.Query.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace NT.Infrastructure.Query.Interface
{
    public interface ICourseQuery
    {
        List<CourseQueryView> CourseList();
    }
}
