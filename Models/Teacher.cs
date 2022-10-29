using DotNetOpenAuth.OpenId.Extensions.SimpleRegistration;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YazGel.Models
{
    public class Teacher
    {
        [Key]

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string No { get; set; }
        public string Pass { get; set; }
        public Gender Gender { get; set; }
        public bool Type { get; set; }
        public virtual ICollection<Committee> teacherId{ get; set; }

        public int role { get; set; }
        public Role Role { get; set; }

    }
}
