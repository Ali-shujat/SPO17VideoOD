using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using VideoOD.Data.Services;
using VideoOD.Data.Data.Entities;


namespace VideoOD.Admin.Pages.Videos
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private IDbReadService _dbReadService;
        private IDbWriteService _dbWriteService;

        [BindProperty] public Video Input { get; set; } = new Video();
        [TempData] public string StatusMessage { get; set; }

        public CreateModel(IDbReadService dbReadService,IDbWriteService dbWriteService)
        {
            _dbReadService = dbReadService;
            _dbWriteService = dbWriteService;
        }

        public void OnGet()
        {
            ViewData["Modules"] = _dbReadService.GetSelectList<Module>("Id", "Title");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                Input.CourseId = _dbReadService.Get<Module>(Input.ModuleId).CourseId;
                var success = await _dbWriteService.Add(Input);

                if (success)
                {
                    StatusMessage = $"Created a new Video: {Input.Title}.";
                    return RedirectToPage("Index");
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}