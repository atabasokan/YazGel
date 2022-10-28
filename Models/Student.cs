using DotNetOpenAuth.OpenId.Extensions.SimpleRegistration;

namespace YazGel.Models
{
    public class Student
    {
        public int studentId { get; set; } 
        public string studentName { get; set; }
        public string studentSurname { get; set; }
        public string studentNo { get; set; }
        public string studentPass { get; set; }
        public Gender studentGender { get; set; }
        public int role { get; set; }
    }
}
