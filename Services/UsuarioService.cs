using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using Monitorias.Models;

namespace Monitorias.Services
{
    public class UsuarioService
    {
        private readonly IMongoCollection<Usuario> _Usuarios;

        public UsuarioService(IMonitoriastoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _Usuarios = database.GetCollection<Usuario>(settings.UsuariosCollectionName);
        }

        public List<Usuario> Get() =>
            _Usuarios.Find(Usuario => true).ToList();

        public Usuario GetOne(string mail) =>
        _Usuarios.Find<Usuario>(Usuario => Usuario.mail == mail).FirstOrDefault();

        public Usuario Get(string id) =>
            _Usuarios.Find<Usuario>(Usuario => Usuario.Id == id).FirstOrDefault();

        public Usuario Create(Usuario Usuario)
        {
            _Usuarios.InsertOne(Usuario);
            return Usuario;
        }

        public void Update(string id, Usuario UsuarioIn) =>
            _Usuarios.ReplaceOne(Usuario => Usuario.Id == id, UsuarioIn);

        public void Remove(Usuario UsuarioIn) =>
            _Usuarios.DeleteOne(Usuario => Usuario.Id == UsuarioIn.Id);

        public void Remove(string id) =>
            _Usuarios.DeleteOne(Usuario => Usuario.Id == id);
    }
}