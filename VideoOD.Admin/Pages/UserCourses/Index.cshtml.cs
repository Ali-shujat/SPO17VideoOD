using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VideoOD.Data.Data.Entities;
using VideoOD.Data.Services;

namespace VideoOD.Admin.Pages.UserCourses
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        [TempData] public string StatusMessage { get; set; }

        private IDbReadService _dbReadService;

        public IEnumerable<UserCourse> Items = new List<UserCourse>();


        public IndexModel(IDbReadService dbReadService)
        {
            _dbReadService = dbReadService;

        }
        public void OnGet()
        {
            Items = _dbReadService.GetWithIncludes<UserCourse>();
        }

    }
}