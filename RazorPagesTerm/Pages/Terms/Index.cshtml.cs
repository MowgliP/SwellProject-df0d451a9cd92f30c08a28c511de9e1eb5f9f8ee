using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesTerm.ApiHandlers;
using RazorPagesTerm.Models;

namespace RazorPagesTerm.Pages.Terms
{
    public class IndexModel : PageModel
    {
        public IList<Term> Term { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Authors { get; set; }
        [BindProperty(SupportsGet = true)]
        public string TermAuthor { get; set; }

        public async Task OnGetAsync()
        {
            Term = await GetAllLibraries.GetAllLibrariesAsTermsAsync();

        }
    }
}
