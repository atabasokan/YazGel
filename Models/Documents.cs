using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace YazGel.Models
{
    public class Documents
    {
        [Key]
        public int Id { get; set; }

        public int InternshipId{ get; set; }
        public Internship Internship{ get; set; }
        public int StudentId { get; set; }
        public Student Student{ get; set; }
        public string RecourseConfirm { get; set; }
        public string InternshipBook { get; set; }
        public string InternshipScore { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
