namespace MongoDbCrudApp.Models
{
    public interface IStudentDbSettings
    {
        string StudentCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
