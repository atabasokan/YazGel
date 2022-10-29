using DotNetOpenAuth.OpenId.Extensions.SimpleRegistration;
using System.ComponentModel.DataAnnotations.Schema;

namespace YazGel.Models
{
    public class Supervisor
    {
        public int supervisorId { get; set; }
        public string supervisorName { get; set; }
        public string supervisorSurname { get; set; }
        public string supervisorNo { get; set; }
        public string supervisorPass { get; set; }
        public Gender supervisorGender { get; set; }

        public int role { get; set; }
        public Role Role { get; set; }
    }
}
