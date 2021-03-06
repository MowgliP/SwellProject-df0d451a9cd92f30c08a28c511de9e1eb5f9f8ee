﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using RazorPagesTerm.Models;

namespace RazorPagesTerm.ApiHandlers
{
    public class EditLibrary
    {
        Library library   { get; set; }

        public static async System.Threading.Tasks.Task EditTermAsync(Term term, string id)
        {
            var library = GetLibraryFromTerm(term, id);
            await FhirClientHandler.PutLibraryAsync(library, id);
        }

        public static Library GetLibraryFromTerm(Term term, string id = null)
        {
            var resourceId = "";
            if (string.IsNullOrEmpty(term.Status.ToString()) || string.IsNullOrEmpty(term.Type.ToString()))
            {
                throw new IndexOutOfRangeException();
            }

            if(id != null)
            {
                resourceId = id;
            }

            var library = new Library()
            {
                Id = resourceId,
                Title = term.Title,
                Type = term.Type,
                Status = term.Status,
                Name = term.Name,
                Version = term.Version,
                Description = new Markdown(term.Description),
                Purpose = new Markdown(term.Purpose),
                Meta = new Meta()
                {
                    Tag = new List<Coding>()
                    {
                        new Coding("fhir.link/proj/term",$"{term.Name}")
                    }
                },
                Date = Date.UtcToday().ToString(),
                Url = $"https://localhost:44389/Terms/{term.Name}",
                Extension = new List<Extension>()
                {
                    new Extension("fhir.link/proj/term/synonym",new FhirString(term.Synonym))
                }


            };
            return library;
        }
    }
}
