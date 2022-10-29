using System.Collections;
using System.Collections.Generic;

namespace YazGel.Models
{
    public class Role
    {
        public int roleId { get; set; }
        public string roleName { get; set; }
        public virtual ICollection<Student> sId { get; set; }
        public virtual ICollection<Teacher> tId { get; set; }
        public virtual ICollection<Committee> cId { get; set; }
        public virtual ICollection<Supervisor> svId { get; set; }
    }
}
