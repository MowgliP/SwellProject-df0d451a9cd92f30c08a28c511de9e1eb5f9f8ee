﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesTerm.ApiHandlers;
using RazorPagesTerm.Models;

namespace RazorPagesTerm.Pages.Terms
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Term Term { get; set; }

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
            if (id == null)
            {
                return NotFound();
            }

            if (id != null)
            {
              await DeleteLibrary.DeleteTermAsync(id);
            }

            return RedirectToPage("./Index");
        }
    }
}
