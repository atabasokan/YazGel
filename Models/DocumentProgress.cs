using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace YazGel.Models
{
    public class DocumentProgress
    {
        [Key]
        public int Id { get; set; }
        public string ProgressName { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
