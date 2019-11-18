namespace ProductApi.Model
{
    public class FuncionalDatabaseSettings : IFuncionalDatabaseSettings
    {
        public string ProductCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IFuncionalDatabaseSettings
    {
        string ProductCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}