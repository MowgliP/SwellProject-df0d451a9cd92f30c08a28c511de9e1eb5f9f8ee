using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using RazorPagesTerm.Models;

namespace RazorPagesTerm.ApiHandlers
{
    public class GetAllLibraries
    {
        public static async Task<IList<Term>> GetAllLibrariesAsTermsAsync()
        {
            var bundle = await FhirClientHandler.GetBundleAsync();

            var listOfLibrary = GetAllLibrariesFromBundle(bundle);

            var listOfTerms = GetAllTermsFromLibraryList(listOfLibrary);

            return listOfTerms;
        }

        private static List<Term> GetAllTermsFromLibraryList(List<Library> listOfLibrary)
        {
            var listOfTerms = new List<Term>();
            foreach (var library in listOfLibrary)
            {
                var term = new Term()
                {
                    Id = library.Id,
                    Name = library.Name,
                    Title = library.Title
                };
                listOfTerms.Add(term);
            };
            return listOfTerms;
        }

        private static List<Library> GetAllLibrariesFromBundle(Bundle bundle)
        {
            var listOfLibraries = new List<Library>();

            foreach (var entry in bundle.Entry)
            {
                if (entry.Resource.ResourceType == ResourceType.Library)
                {
                    listOfLibraries.Add((Library)entry.Resource);
                }
            }

            return listOfLibraries;
        }
    }
}
