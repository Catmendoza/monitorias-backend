using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Monitorias.Models
{
    public class Monitoria
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        [JsonProperty("Name")]
        public string name { get; set; }

        public string faculty { get; set; }

        public string day { get; set; }
        public string init { get; set; }
        public string end { get; set; }

        public string livingRoom { get; set; }
        public int availableQuotas { get; set; }
        public int initialQuotas { get; set; }
        public string description { get; set; }

        public string[] students { get; set; }
     }
}