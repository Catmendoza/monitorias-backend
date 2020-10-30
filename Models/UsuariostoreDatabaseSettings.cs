namespace Usuarios.Models
{
    public class UsuariostoreDatabaseSettings : IUsuariostoreDatabaseSettings
    {
        public string UsuariosCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IUsuariostoreDatabaseSettings
    {
        string UsuariosCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}