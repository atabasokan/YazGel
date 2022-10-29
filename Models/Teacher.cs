using DotNetOpenAuth.OpenId.Extensions.SimpleRegistration;

namespace YazGel.Models
{
    public class Teacher
    {
        public int teacherId { get; set; }
        public string teacherName { get; set; }
        public string teacherSurname { get; set; }
        public string teacherNo { get; set; }
        public string teacherPass { get; set; }
        public Gender teacherGender { get; set; }
        public int teacherType { get; set; }
    }
}
