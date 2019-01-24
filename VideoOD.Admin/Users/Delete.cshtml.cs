using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VideoOD.Admin.Models;
using VideoOD.Admin.Services;

namespace VideoOD.Admin.Users
{
    public class DeleteModel : PageModel
    {
        private IUserService _userService;

        [BindProperty]
        public UserPageModel Input { get; set; } = new UserPageModel();

        [TempData]
        public string StatusMessage { get; set; }

        public DeleteModel(IUserService userService)
        {
            _userService = userService;
        }

        public void OnGet(string userId)
        {
            Input = _userService.GetUser(userId);
            StatusMessage = string.Empty;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.DeleteUserAsync(Input.Id);

                if (result)
                {
                    StatusMessage = $"User {Input.Email} was deleted.";
                    return RedirectToPage("Index");
                }
            }

            return Page();
        }
    }
}