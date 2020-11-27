using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using Monitorias.Models;

namespace Monitorias.Services
{
    public class ComentarioService
    {
        private readonly IMongoCollection<Comentario> _Comentario;

        public ComentarioService(IMonitoriastoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _Comentario = database.GetCollection<Comentario>(settings.ComentariosCollectionName);
        }

        public List<Comentario> Get() =>
            _Comentario.Find(Comentario => true).ToList();
        public List<Comentario> GetByMonitoria(string id) =>
            _Comentario.Find(Comentario => Comentario.idMonitoria == id).ToList();
        public Comentario Get(string id) =>
            _Comentario.Find<Comentario>(Comentario => Comentario.Id == id).FirstOrDefault();

        public Comentario GetOne(string description) =>
        _Comentario.Find<Comentario>(Comentario => Comentario.description == description).FirstOrDefault();

        public Comentario Create(Comentario Comentario)
        {
            _Comentario.InsertOne(Comentario);
            return Comentario;
        }

        public void Update(string id, Comentario ComentarioIn) =>
            _Comentario.ReplaceOne(Comentario => Comentario.Id == id, ComentarioIn);

        public void Remove(Comentario ComentarioIn) =>
            _Comentario.DeleteOne(Comentario => Comentario.Id == ComentarioIn.Id);

        public void Remove(string id) =>
            _Comentario.DeleteOne(Comentario => Comentario.Id == id);
    }
}