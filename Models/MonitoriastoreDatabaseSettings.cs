namespace Monitorias.Models
{
    public class MonitoriastoreDatabaseSettings : IMonitoriastoreDatabaseSettings
    {
        public string MonitoriasCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IMonitoriastoreDatabaseSettings
    {
        string MonitoriasCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}