using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using VideoOD.Admin.Services;
using VideoOD.Admin.Models;
using VideoOD.Data.Data.Entities;
using VideoOD.Data.Services;


namespace VideoOD.Admin.Pages.Videos
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private IDbReadService _dbReadService;
        public IEnumerable<Video> Items = new List<Video>();
        [TempData] public string StatusMessage { get; set; }

        public IndexModel(IDbReadService dbReadService)
        {
            _dbReadService = dbReadService;
        }

        public void OnGet()
        {
            Items = _dbReadService.GetWithIncludes<Video>();
        }
    }

}