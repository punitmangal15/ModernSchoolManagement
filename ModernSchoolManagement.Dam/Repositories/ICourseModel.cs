using ModernSchoolManagement.Dam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernSchoolManagement.Dam.Repositories
{
    public interface ICourseModel
    {
        Task<IEnumerable<CourseModel>> GetAllCourseDetails();

        Task<CourseModel> GetCourseDetail(long Id);
        Task<CourseModel> AddCourse(CourseModel CourseModel);
        Task<CourseModel> UpdateCourse(CourseModel CourseModel);
        Task<CourseModel> DeleteCourse(long Id);
    }
}
