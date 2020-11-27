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
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(50)]
        [BsonElement("Name")]
        [JsonProperty("Name")]

        public string name { get; set; }
        [Required(ErrorMessage = "El programa es requerido")]
        public string career { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string mail { get; set; }
        [Required(ErrorMessage = "La cedula es requerido")]
        public string code { get; set; }
        [Required(ErrorMessage = "La contraseña es requerido")]
        [StringLength(8, ErrorMessage = "La contraseña tiene que tener maximo 8 caracteres.")]
        public string password { get; set; }

        public int roll { get; set; }

    }
}