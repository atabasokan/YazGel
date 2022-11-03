using System.Collections;
using System.Collections.Generic;

namespace YazGel.Models
{
    public class Documents
    {
        public int Id { get; set; }

        public int InternshipId{ get; set; }
        public Internship Internship { get; set; }
        public string RecourseConfirm { get; set; }
        public string InternshipBook { get; set; }
        public string InternshipScore { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
