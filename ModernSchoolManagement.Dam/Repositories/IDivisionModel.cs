using ModernSchoolManagement.Dam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernSchoolManagement.Dam.Repositories
{
    public interface IDivisionModel
    {
        Task<IEnumerable<DivisionModel>> GetAllDivisionDetails();

        Task<DivisionModel> GetDivisionDetail(long Id);
        Task<DivisionModel> AddDivision(DivisionModel DivisionModel);
        Task<DivisionModel> UpdateDivision(DivisionModel DivisionModel);
        Task<DivisionModel> DeleteDivision(long Id);
    }
}
