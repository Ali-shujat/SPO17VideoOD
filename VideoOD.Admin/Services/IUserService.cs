using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoOD.Admin.Models;

namespace VideoOD.Admin.Services
{
    public interface IUserService
    {
        IEnumerable<UserPageModel> GetUsers();

        UserPageModel GetUser(string userId);

        Task<IdentityResult> AddUserAsync(RegisterUserPageModel user);

        Task<bool> UpdateUserAsync(UserPageModel user);

        Task<bool> DeleteUser(string userId);
    }
}
