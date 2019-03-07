using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using RazorPagesTerm.Models;

namespace RazorPagesTerm.ApiHandlers
{
    public class DeleteLibrary
    {
        public Term Term { get; set; }
        public static async System.Threading.Tasks.Task DeleteTermAsync(string id)
        {
            var endpointUrl = "https://fhirbackendservices.azurewebsites.net/fhir/Library/";
            var fullUrl = $"{endpointUrl}{id}"; 
            await FhirClientHandler.DeleteLibraryAsync(fullUrl);
        }


    }
}
