using ModernSchoolManagement.Dam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernSchoolManagement.Dam.Repositories
{
    public interface ISubjectModel
    {
        Task<IEnumerable<SubjectModel>> GetAllSubjectDetails();

        Task<SubjectModel> GetSubjectDetail(long Id);
        Task<SubjectModel> AddSubject(SubjectModel SubjectModel);
        Task<SubjectModel> UpdateSubject(SubjectModel SubjectModel);
        Task<SubjectModel> DeleteSubject(long Id);
    }
}
