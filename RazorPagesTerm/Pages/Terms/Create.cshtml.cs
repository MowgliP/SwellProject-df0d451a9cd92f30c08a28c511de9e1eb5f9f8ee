using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesTerm.ApiHandlers;
using RazorPagesTerm.Models;

namespace RazorPagesTerm.Pages.Terms
{
    public class CreateModel : PageModel
    {
     
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Term Term { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var term = Term;
            await CreateLibrary.CreateLibraryAndPostAsync(term);


            return RedirectToPage("./Index");
        }
    }
}