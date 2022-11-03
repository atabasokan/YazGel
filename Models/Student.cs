using DotNetOpenAuth.OpenId.Extensions.SimpleRegistration;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YazGel.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Surname { get; set; }
        public string No { get; set; }
        public string Pass { get; set; }
        public Gender Gender { get; set; }
        public int role { get; set; }
        public Role Role { get; set; }
        public int? ProgressId { get; set; }
        public DocumentProgress DocumentProgress { get; set; }
        public int? TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public virtual ICollection<Documents> Documents{ get; set; }

        public virtual ICollection<Internship> Internships { get; set; }

    }
}
