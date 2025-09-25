using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernSchoolManagement.Dam.Models
{
    public class AcademicYearModel
    {
        public int Id { get; set; }
        public string AcademicName { get; set; }
        public DateTime startdate { get; set; }
        public DateTime enddate { get; set; }
        public bool Is_Active { get; set; }

    }
}
