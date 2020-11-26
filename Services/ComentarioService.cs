using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using Monitorias.Models;

namespace Comentarios.Services
{
    public class ComentarioService
    {
        private readonly IMongoCollection<Comentario> _Comentario;

        public ComentarioService(IMonitoriastoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _Comentarios = database.GetCollection<Comentario>(settings.ComentariosCollectionName);
        }

        public List<Comentario> Get() =>
            _Comentarios.Find(Comentario => true).ToList();
        public List<Comentario> GetUsers() =>
            _Comentarios.Find(Comentario => Comentario.Id != 1).ToList();

        public Comentario GetOne(string description) =>
        _Comentarios.Find<Comentario>(Comentario => Comentario.description == description).FirstOrDefault();

        

        public Comentario Create(Comentario Comentario)
        {
            _Comentarios.InsertOne(Comentario);
            return Comentario;
        }

        public void Update(string id, Comentario ComentarioIn) =>
            _Comentarios.ReplaceOne(Comentario => Comentario.Id == id, ComentarioIn);

        public void Remove(Comentario ComentarioIn) =>
            _Comentarios.DeleteOne(Comentario => Comentario.Id == ComentarioIn.Id);

        public void Remove(string id) =>
            _Comentarios.DeleteOne(Comentario => Comentario.Id == id);
    }
}