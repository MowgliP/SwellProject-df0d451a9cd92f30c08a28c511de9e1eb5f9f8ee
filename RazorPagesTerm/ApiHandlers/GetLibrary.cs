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
            var description = "";
            var purpose = "";
            var synonym = "";

            if( library.Description != null)
            {
                if(library.Description.Value.Any())
                {
                    description = library.Description.Value;
                }
            }
            if(library.Purpose!= null)
            {
                if (library.Purpose.Value.Any())
                {
                    purpose = library.Purpose.Value;
                }
            }
            if (library.Extension != null)
            {
                foreach(var extension in library.Extension)
                {
                    if (extension.Url == "fhir.link/proj/term/synonym")
                    {
                        synonym = extension.Value.ToString(); 
                    }
                }
            }

            var term = new Term()
            {
                Id = library.Id,
                Name = library.Name,
                Title = library.Title,
                Version = library.Version,
                Description = description,
                Purpose = purpose,
                Synonym = synonym
            };
            return term;
        }
    }
}
