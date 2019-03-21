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

        //public static async Task<Term> OnGetAsync(string searchString)
        //{
            
        //    var library = await FhirClientHandler.GetLibraryFromTagAsync("");

        //var term = GetLibrary.LibraryToTermConverter(library);

        //    return term;


        //}

    public async Task OnGetAsync()
        {
            if (!String.IsNullOrEmpty(SearchString))
            {
                var libraryList = await FhirClientHandler.GetLibraryFromTagAsync(SearchString);
                Term = GetAllLibraries.GetAllTermsFromTagSearchAsync(libraryList);            
            }
            Term = await GetAllLibraries.GetAllLibrariesAsTermsAsync();

            //var terms = from t in Term
            //            select t;

            //if (!string.IsNullOrEmpty(SearchString))
            //{
            //    terms = terms.Where(s => s.Name.Equals(SearchString));
            //}

            
        }

    }
}
