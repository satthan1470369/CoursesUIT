using CoursesUIT.Models;

namespace CoursesUIT.Services
{
    public interface ICoursesServices
    {
        //Khóa học
        Task<List<Courses>> GetAllCourses();
        Task<Courses> GetIdCourses(Guid id, bool includeCourses = false);
        Task<Courses> AddCourses(Courses courses);
        Task<Courses> UpdateCourses(Courses  courses);
        Task<(bool,string)> DeleteCourses(Courses  courses);
        //Học Sinh
        Task<List<Student>> getAllStudent();
        Task<Student> GetIdStudent(Guid id, bool includeCourses = false);
        Task<Student> AddStudent(Student student);
        Task<Student> UpdateStudent(Student student);
        Task<(bool, string)> DeleteStudent(Student student);

        Task<List<Models.CoursesUIT>> GetAllSCourses();
        Task<Models.CoursesUIT> GetIdSCourses(Guid id);
        Task<Models.CoursesUIT> AddSCourses(Models.CoursesUIT sc);
        Task<Models.CoursesUIT> UpdateSCourses(Models.CoursesUIT sc);
        Task<(bool, string)> DeleteSCourses(Models.CoursesUIT sc);
    }
}
