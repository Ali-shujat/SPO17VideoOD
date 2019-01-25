using VideoOD.Data.Data.Entities;

namespace VideoOD.Data.Data.Entities
{
    public class UserCourse
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
