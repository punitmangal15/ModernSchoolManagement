using ModernSchoolManagement.Dam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernSchoolManagement.Dam.Repositories
{
    public interface IClassModel
    {
        Task<IEnumerable<ClassModel>> GetAllClassDetails();

        Task<ClassModel> GetClassDetail(long Id);
        Task<ClassModel> AddClass(ClassModel ClassModel);
        Task<ClassModel> UpdateClass(ClassModel ClassModel);
        Task<ClassModel> DeleteClass(long Id);
    }
}
