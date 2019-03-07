using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesTerm.ApiHandlers;
using RazorPagesTerm.Models;

namespace RazorPagesTerm.Pages.Terms
{
    public class EditModel : PageModel
    {

        [BindProperty]
        public Term Term { get; set; }
        public Library library { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Term = await GetLibrary.GetTermAsync(id);

            if (Term == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }   

            if (!string.IsNullOrEmpty(id))
            { 
            await EditLibrary.EditTermAsync(Term,id);
            }
            return RedirectToPage("./Index");
        }
    }
}
