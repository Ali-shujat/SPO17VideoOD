using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VideoOD.Admin.Models;
using VideoOD.Admin.Services;
using VideoOD.Data.Data.Entities;
using VideoOD.Data.Services;

namespace VideoOD.Admin.Pages.UserCourses
{
    public class EditModel : PageModel
    {
        private IDbWriteService _dbWriteService;
        private IDbReadService _dbReadService;
        private IUserService _userService;

        [BindProperty]
        public UserCoursePageModel Input { get; set; } = new UserCoursePageModel();

        [TempData]
        public string StatusMessage { get; set; } // Used to send a message back to the Index view

        public EditModel(IDbReadService dbReadService, IDbWriteService dbWriteService, IUserService userService)
        {
            _dbWriteService = dbWriteService;
            _dbReadService = dbReadService;
            _userService = userService;
        }

        public void OnGet(int courseId, string userId)
        {
            ViewData["Courses"] = _dbReadService.GetSelectList<Course>("Id", "Title");
            Input.UserCourse = _dbReadService.Get<UserCourse>(userId, courseId);
            Input.UpdatedUserCourse = Input.UserCourse;
            var course = _dbReadService.Get<Course>(courseId);
            var user = _userService.GetUser(userId);
            Input.CourseTitle = course.Title;
            Input.Email = user.Email;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var success = await _dbWriteService.Update(Input.UserCourse, Input.UpdatedUserCourse);

                if (success)
                {
                    var updatedCourse = _dbReadService.Get<Course>(Input.UpdatedUserCourse.CourseId);
                    StatusMessage = $"The [{Input.CourseTitle} | {Input.Email}] combination was changed to [{updatedCourse.Title} | {Input.Email}].";
                    return RedirectToPage("Index");
                }
            }

            // If we got this far, something failed, redisplay form
            ViewData["Courses"] = _dbReadService.GetSelectList<Course>("Id", "Title");
            return Page();
        }

    }
}