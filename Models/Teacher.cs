using DotNetOpenAuth.OpenId.Extensions.SimpleRegistration;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace YazGel.Models
{
    public class Teacher
    {
        public int teacherId { get; set; }
        public string teacherName { get; set; }
        public string teacherSurname { get; set; }
        public string teacherNo { get; set; }
        public string teacherPass { get; set; }
        public Gender teacherGender { get; set; }
        public int teacherType { get; set; }
        public virtual ICollection<Committee> tId{ get; set; }

        public int role { get; set; }
        public Role Role { get; set; }

    }
}
