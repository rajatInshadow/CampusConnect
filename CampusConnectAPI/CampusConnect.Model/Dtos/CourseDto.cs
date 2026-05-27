using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampusConnect.Model.Dtos
{
    public class CourseDto
    {
        public int CourseID { get; set; }

        public string CourseName { get; set; }

        public string CourseCode { get; set; }

        public int DepartmentID { get; set; }
    }
}
