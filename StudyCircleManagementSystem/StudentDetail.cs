using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCircleManagementSystem.Entities
{
    public class StudentDetail
    {
        public int studentId { get; set; }

        public string studentName { get; set; }

        public string courseName { get; set; }

        public long studentPhoneNumber { get; set; }
       
        public int testMarks { get; set; }  

    }
}
