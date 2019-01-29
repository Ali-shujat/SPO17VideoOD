using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VideoOD.Data.Data.Entities;
using VideoOD.Data.Services;

namespace VideoOD.Admin.Pages.Modules
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private IDbReadService _dbReadService;

        public IEnumerable<Module> Items = new List<Module>();

        [TempData] public string StatusMessage { get; set; }

        public IndexModel(IDbReadService dbReadService)
        {
            _dbReadService = dbReadService;
        }

        public void OnGet()
        {
            Items = _dbReadService.GetWithIncludes<Module>();
        }
    }
}