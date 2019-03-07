using Hl7.Fhir.Model;
using RazorPagesTerm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesTerm.ApiHandlers
{
    public class GetLibrary
    {
        public static async Task<Term> GetTermAsync(string id)
        {
            var library = await FhirClientHandler.GetLibraryAsync(id);

            var term = LibraryToTermConverter(library);

            return term;
        }

        public static Term LibraryToTermConverter(Library library)
        {
            var term = new Term()
            {
                Id = library.Id,
                Name = library.Name,
                Title = library.Title
            };
            return term;
        }
    }
}
