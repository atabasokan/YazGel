using System.Collections;
using System.Collections.Generic;

namespace YazGel.Models
{
    public class DocumentProgress
    {
        public int Id { get; set; }
        public string ProgressName { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
