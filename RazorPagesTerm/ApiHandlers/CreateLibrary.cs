using Hl7.Fhir.Model;
using RazorPagesTerm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesTerm.ApiHandlers
{
    public static class CreateLibrary
    {
        public static async System.Threading.Tasks.Task CreateLibraryAndPostAsync(Term term)
        {
            var library = GetLibraryFromTerm(term);
            await FhirClientHandler.PostLibraryAsync(library);   
        }

        private static Library GetLibraryFromTerm(Term term)
        {
            if(string.IsNullOrEmpty(term.Status.ToString()) || string.IsNullOrEmpty(term.Type.ToString()))
            {
                throw new IndexOutOfRangeException();
            }

            var library = new Library()
            {
                Title = term.Title,
                Type = term.Type,
                Status = term.Status,
                Name = term.Name,
                Version = term.Version,
                Description = new Markdown(term.Description),
                Purpose = new Markdown(term.Purpose)
                //Version = "1.0.0",
                //Description = new Markdown("APA"),
                //Url = $"https://localhost:44389/Terms/{term.Name}",

                //Extension = new List<Extension>()
                //{
                //    new Extension("fhir.link/proj/term/synonym",new FhirString(""))
                //}

            };
            return library;
        }
    }
}
