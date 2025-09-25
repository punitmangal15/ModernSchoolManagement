using ModernSchoolManagement.Dam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernSchoolManagement.Dam.Repositories
{
    public interface IAcademicYearModel
    {
        Task<IEnumerable<AcademicYearModel>> GetAllAcademicYearDetails();

        Task<AcademicYearModel> GetAcademicYearDetail(long Id);
        Task<AcademicYearModel> AddAcademicYear(AcademicYearModel AcademicYearModel);
        Task<AcademicYearModel> UpdateAcademicYear(AcademicYearModel AcademicYearModel);
        Task<AcademicYearModel> DeleteAcademicYear(long Id);
    }
}
