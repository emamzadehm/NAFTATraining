using System.Collections.Generic;
using _01.Framework.Domain;
using NT.CM.Domain.CourseAgg;
using NT.CM.Domain.CompanyAgg;
using NT.CM.Domain.CourseCandidateInstructorDetailsAgg;
using NT.CM.Domain.GalleryAgg;
using NT.CM.Domain.CandidateAgg;
using NT.CM.Domain.CourseInstructorAgg;

namespace Domain.BaseInfoAgg
{
    //public class BaseInfo : DomainBase<int, bool>
    public class BaseInfo : DomainBase
    {
        public string Title { get; private set; }
        public long? TypeID { get; private set; }
        public long? ParentID { get; private set; }
        public BaseInfo Type { get; private set; }
        public ICollection<BaseInfo> TypeChilds { get; private set; }
        public BaseInfo Parent { get; private set; }
        public ICollection<BaseInfo> ParentChilds { get; private set; }
        
        //Relation to Course
        public ICollection<Course> CourseLevels { get; private set; }
        public ICollection<Course> CourseCategoriers { get; private set; }
        
        //Relation to Company
        public ICollection<Company> Companies { get; private set; }

        //Relation to CourseCandidateInstructorDetails
        public ICollection<CourseCandidateInstructorDetails> CourseCandidateInstructorDetails { get; private set; }

        //Relation to Gallery
        public ICollection<Gallery> Galleries { get; private set; }

        //Relation to Candidate
        public ICollection<Candidate> Candidates { get; private set; }

        //Relation to CourseInstructor
        public ICollection<CourseInstructor> CourseInstructors { get; private set; }
        
        
        
        protected BaseInfo()
        {

        }
        public BaseInfo(string title, long? typeid, long? parentid)
        {
            Title = title;
            TypeID = typeid;
            ParentID = parentid;
            ParentChilds = new List<BaseInfo>();
            TypeChilds = new List<BaseInfo>();
            CourseLevels = new List<Course>();
            CourseCategoriers = new List<Course>();
            Companies = new List<Company>();
            CourseCandidateInstructorDetails = new List<CourseCandidateInstructorDetails>();
            Galleries = new List<Gallery>();
            Candidates = new List<Candidate>();
            CourseInstructors = new List<CourseInstructor>();

        }
        public void Edit(string title, long? typeid, long? parentid)
        {
            Title = title;
            TypeID = typeid;
            ParentID = parentid;
        }
    }
}
