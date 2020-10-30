using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Usuarios.Models
{
    public class Usuario
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        [JsonProperty("Name")]
        public string name { get; set; }

        public string career { get; set; }

        public string mail { get; set; }

        public string code { get; set; }
    }
}