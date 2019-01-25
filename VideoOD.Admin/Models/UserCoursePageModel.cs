using VideoOD.Data.Data.Entities;

namespace VideoOD.Admin.Models
{
    public class UserCoursePageModel
    {
        public string Email { get; set; }
        public string CourseTitle { get; set; }
        public UserCourse UserCourse { get; set; } = new UserCourse();
        public UserCourse UpdatedUserCourse { get; set; } =
        new UserCourse();
    }
}
