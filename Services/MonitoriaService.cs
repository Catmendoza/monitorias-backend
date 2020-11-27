using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using Monitorias.Models;

namespace Monitorias.Services
{
    public class MonitoriaService
    {
        private readonly IMongoCollection<Monitoria> _Monitorias;

        public MonitoriaService(IMonitoriastoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _Monitorias = database.GetCollection<Monitoria>(settings.MonitoriasCollectionName);
        }

        public List<Monitoria> Get() =>
            _Monitorias.Find(Monitoria => true).ToList();
        public List<Monitoria> GetMonitor() =>
            _Monitorias.Find(Monitoria => Monitoria.monitor != "").ToList();
        public List<Monitoria> GetAvailables() =>
            _Monitorias.Find(Monitoria => Monitoria.monitor == "").ToList();
        public List<Monitoria> GetMonitoriasMonitor(string id) =>
            _Monitorias.Find(Monitoria => Monitoria.monitor == id).ToList();

        public Monitoria Get(string id) =>
            _Monitorias.Find<Monitoria>(Monitoria => Monitoria.Id == id).FirstOrDefault();

        public Monitoria Create(Monitoria Monitoria)
        {
            _Monitorias.InsertOne(Monitoria);
            return Monitoria;
        }

        public void Update(string id, Monitoria MonitoriaIn) =>
            _Monitorias.ReplaceOne(Monitoria => Monitoria.Id == id, MonitoriaIn);

        public void Remove(Monitoria MonitoriaIn) =>
            _Monitorias.DeleteOne(Monitoria => Monitoria.Id == MonitoriaIn.Id);

        public void Remove(string id) =>
            _Monitorias.DeleteOne(Monitoria => Monitoria.Id == id);
    }
}