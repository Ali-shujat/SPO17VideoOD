﻿using System.Collections.Generic;
using VideoOD.Data.Data.Entities;

namespace VideoOD.Data.Repositories
{
    public interface IReadRepository
    {
        IEnumerable<Course> GetCourses(string userId);
        Course GetCourse(string userId, int courseId);

        Video GetVideo(string userId, int videoId);
        IEnumerable<Video> GetVideos(string userId, int moduleId = default(int));
    }
}
