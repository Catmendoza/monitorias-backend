using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Monitorias.Models
{
    public class Usuario
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [Required]
        [BsonElement("Name")]
        [JsonProperty("Name")]

        public string name { get; set; }
        [Required]
        public string career { get; set; }
        [Required]
        public string mail { get; set; }
        [Required]
        public string code { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public int roll {get; set;}
        
    }
}