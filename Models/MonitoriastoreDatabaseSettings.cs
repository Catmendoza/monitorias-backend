namespace Monitorias.Models
{
    public class MonitoriastoreDatabaseSettings : IMonitoriastoreDatabaseSettings
    {
        public string MonitoriasCollectionName { get; set; }
        public string UsuariosCollectionName { get; set; }
        public string ComentariosCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IMonitoriastoreDatabaseSettings
    {
        string MonitoriasCollectionName { get; set; }
        string UsuariosCollectionName { get; set; }
        string ComentariosCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}