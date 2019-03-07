using System;
using System.ComponentModel.DataAnnotations;
using Hl7.Fhir.Model;

namespace RazorPagesTerm.Models
{
    public class Term
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public PublicationStatus Status { get => PublicationStatus.Active; }
        public CodeableConcept Type { get => new CodeableConcept("http://terminology.hl7.org/CodeSystem/library-type", "logic-library"); } 
        public string Name { get; set; }
    }
}