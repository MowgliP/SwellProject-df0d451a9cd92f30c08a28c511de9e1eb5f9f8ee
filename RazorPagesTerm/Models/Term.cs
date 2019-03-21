using System;
using System.ComponentModel.DataAnnotations;
using Hl7.Fhir.Model;

namespace RazorPagesTerm.Models
{
    public class Term
    {
        public string Id { get; set; }

        [Required]
        public string Title { get; set; }
        public PublicationStatus Status { get => PublicationStatus.Active; }
        public CodeableConcept Type { get => new CodeableConcept("http://terminology.hl7.org/CodeSystem/library-type", "logic-library"); }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Version { get; set; }
        [Required]
        public string Purpose { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get => DateTime.Today; }
        public string Synonym { get; set; }
    }
}