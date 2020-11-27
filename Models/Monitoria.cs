using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Monitorias.Models
{
    public class Monitoria
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        [BsonElement("Name")]
        [JsonProperty("Name")]
        public string name { get; set; }
        [Required(ErrorMessage = "La facultad es requerida")]
        [StringLength(80)]

        public string faculty { get; set; }
        [Required(ErrorMessage = "El día es requerido")]

        public string day { get; set; }
        [Required(ErrorMessage = "La hora de inicio es requerida")]
        public string init { get; set; }
        [Required(ErrorMessage = "La hora de finalización requerida")]
        public string end { get; set; }
        [Required(ErrorMessage = "El numero de salón o link de la sala son requeridos")]

        public string livingRoom { get; set; }
        [Required(ErrorMessage = "La disponibilidad de cupos es requerida")]
        public int availableQuotas { get; set; }
        public int initialQuotas { get; set; }
        public string description { get; set; }

        public string[] students { get; set; }
        public string monitor { get; set; }
    }
}