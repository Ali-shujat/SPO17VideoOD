﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VideoOD.Data.Data.Entities;
using VideoOD.Data.Services;

namespace VideoOD.Admin.Pages.Instructors
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private IDbWriteService _dbWriteService;
        private IDbReadService _dbReadService;

        [BindProperty]
        public Instructor Input { get; set; } = new Instructor();

        [TempData]
        public string StatusMessage { get; set; } // Used to send a message back to the Index view

        public DeleteModel(IDbReadService dbReadService, IDbWriteService dbWriteService)
        {
            _dbWriteService = dbWriteService;
            _dbReadService = dbReadService;
        }

        public void OnGet(int id)
        {
            Input = _dbReadService.Get<Instructor>(id);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var success = await _dbWriteService.Delete(Input);

                if (success)
                {
                    StatusMessage = $"Deleted Instructor: {Input.Name}.";
                    return RedirectToPage("Index");
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}