﻿using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using Hl7.Fhir.Serialization;
using RazorPagesTerm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RazorPagesTerm.ApiHandlers
{
    public class FhirClientHandler
    {
        private static HttpClient _httpClient = new HttpClient();
        private readonly static Uri _fhirApiEndPoint = new Uri("https://fhirbackendservices.azurewebsites.net/fhir/Library/");
        private static FhirJsonSerializer _fhirJsonSerializer = new FhirJsonSerializer();

        public static async System.Threading.Tasks.Task PutLibraryAsync(Library library, string id)
        {

            var fullUrl = $"{_fhirApiEndPoint}{id}";
                     
            var body = _fhirJsonSerializer.SerializeToString(library);
            var content = new StringContent(body, Encoding.UTF8, "application/json");

            var newRequest = new HttpRequestMessage(HttpMethod.Put, fullUrl)
            {
                Content = content
            };

            var response = await _httpClient.SendAsync(newRequest);

      
        }

            public static async System.Threading.Tasks.Task DeleteLibraryAsync(string id)
        {
            if (id == null)
            {
                //return some exception
            }

            var newRequest = new HttpRequestMessage(HttpMethod.Delete, id);

            var response = await _httpClient.SendAsync(newRequest);


        }

        public static async Task<Bundle> GetBundleAsync()
        {

            var response = await _httpClient.GetAsync(_fhirApiEndPoint);

            var content = await response.Content.ReadAsStringAsync();

            var fhirJsonParser = new FhirJsonParser();

            var bundle = fhirJsonParser.Parse<Bundle>(content);

            return bundle; 

           throw new NotImplementedException();
        }

        public static async Task<Library> GetLibraryAsync(string id)
        {
            var fhirApiEndPointWithUri = $"{_fhirApiEndPoint}{id}";

            var response = await _httpClient.GetAsync(fhirApiEndPointWithUri);

            var contentBody = await response.Content.ReadAsStringAsync();

            var fhirJsonParser = new FhirJsonParser();

            var library = fhirJsonParser.Parse<Library>(contentBody);

            return library;
        }

        public static async Task<IList<Library>> GetLibraryFromTagAsync(string name)
        {
               string _tagEndPoint = "fhir.link/proj/term";


        //Bygg korrekt url med name
        var fullUrlFromTag = $"{_fhirApiEndPoint}?_tag={_tagEndPoint}|{name}";

            //Gör ett anrop och få tillbaka resultat
            var response = await _httpClient.GetAsync(fullUrlFromTag);

            var contentBody = await response.Content.ReadAsStringAsync();

            var fhirJsonParser = new FhirJsonParser();
            //Casta resultat till library

            var bundle = fhirJsonParser.Parse<Bundle>(contentBody);

            var libraries = GetAllLibraries.GetAllLibrariesFromBundle(bundle);

            return libraries;
        }

        public static async System.Threading.Tasks.Task PostLibraryAsync(Library library)
        {

            if (library == null)
            {
                //return some exception
            }

            var body = _fhirJsonSerializer.SerializeToString(library);
            var content = new StringContent(body, Encoding.UTF8, "application/json");

            var newRequest = new HttpRequestMessage(HttpMethod.Post, _fhirApiEndPoint)
            {
                Content = content
            };

            var response = await _httpClient.SendAsync(newRequest);

        }
    }
}
