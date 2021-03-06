﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VideoOD.Admin.Services;
using VideoOD.Data.Data.Entities;
using VideoOD.Data.Services;

namespace VideoOD.Admin.Pages.UserCourses
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private IDbReadService _dbReadService;
        private IDbWriteService _dbWriteService;
        private IUserService _userService;

        [TempData] public string StatusMessage { get; set; }

        [BindProperty]
        public UserCourse Input { get; set; } = new UserCourse();

        public CreateModel(IDbReadService dbReadService, IDbWriteService dbWriteService, IUserService userService)
        {
            _dbReadService = dbReadService;
            _dbWriteService = dbWriteService;
            _userService = userService;

        }

        public void OnGet()
        {
            ViewData["Courses"] = _dbReadService.GetSelectList<Course>("Id", "Title");
            ViewData["Users"] = _dbReadService.GetSelectList<User>("Id", "Email");

        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var success = await _dbWriteService.Add(Input);

                if (success)
                {
                    var user = _userService.GetUser(Input.UserId);
                    var course = _dbReadService.Get<Course>(Input.CourseId);
                    StatusMessage = $"User-Course combination [{course.Title} |{ user.Email}] was created.";
                    return RedirectToPage("Index");
                }
            }

            // If we got this far, something failed, redisplay form
            ViewData["Users"] = _dbReadService.GetSelectList<User>("Id", "Email");
            ViewData["Courses"] = _dbReadService.GetSelectList<Course>("Id", "Title");
            return Page();
        }
    }
}