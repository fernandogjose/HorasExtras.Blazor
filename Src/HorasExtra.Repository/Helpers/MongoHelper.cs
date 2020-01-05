using MongoDB.Driver;

namespace HorasExtra.Repository.Helpers
{
    public class MongoHelper
    {
        public IMongoDatabase MongoDatabase;

        public MongoHelper()
        {
            CreateMongoDatabase();
        }

        private void CreateMongoDatabase()
        {
            MongoClient client = new MongoClient("mongodb+srv://userDbHorasExtra:g716iso2@cluster0-i6gzm.azure.mongodb.net/test?retryWrites=true&w=majority");
            MongoDatabase = client.GetDatabase("HorasExtra");
        }
    }
}
