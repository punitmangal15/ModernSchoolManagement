using ModernSchoolManagement.Dam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernSchoolManagement.Dam.Repositories
{
    public interface ISchoolModel
    {
        Task<IEnumerable<SchoolModel>> GetAllSchoolDetails();

        Task<SchoolModel> GetSchoolDetail(long Id);
        Task<SchoolModel> AddSchool(SchoolModel schoolModel);
        Task<SchoolModel> UpdateSchool(SchoolModel schoolModel);
        Task<SchoolModel> DeleteSchool(long Id);
    }
}
