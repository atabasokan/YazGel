using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace YazGel.Models
{
    public class Role
    {
        [Key]

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Student> sId { get; set; }
        public virtual ICollection<Teacher> tId { get; set; }
        public virtual ICollection<Supervisor> svId { get; set; }
    }
}
