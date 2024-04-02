using System.ComponentModel.DataAnnotations;

namespace CoursesUIT.Models
{
    public class Student
    {
        [Key]
        public Guid? StudentId { get; set; }
        public string? Name { get; set; }
        public List<CoursesUIT>? CoursesUIT { get; set; }
    }
}
