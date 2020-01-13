using HorasExtra.Domain.Interfaces.Repositories;
using HorasExtra.Domain.Models;
using HorasExtra.Repository.Helpers;
using MongoDB.Bson;
using MongoDB.Driver;

namespace HorasExtra.Repository.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly MongoHelper _mongoHelper;
        private readonly IMongoCollection<BsonDocument> _collection;

        public LoginRepository(MongoHelper mongoHelper)
        {
            _mongoHelper = mongoHelper;
            _collection = _mongoHelper.MongoDatabase.GetCollection<BsonDocument>("Usuario");
        }

        private Login Map(BsonDocument bsonDocument)
        {
            if (bsonDocument == null)
            {
                return new Login();
            }

            Login response = new Login();
            response.Email = bsonDocument.GetValue("Email").ToString();
            response.Nome = bsonDocument.GetValue("Nome").ToString();
            response.Perfil = bsonDocument.GetValue("Perfil").ToString();
            return response;
        }

        public Login Obter(Login request)
        {
            FilterDefinitionBuilder<BsonDocument> builder = Builders<BsonDocument>.Filter;
            FilterDefinition<BsonDocument> filter = builder.Eq("Email", request.Email) & builder.Eq("Senha", request.Senha);
            BsonDocument bsonDocument = _collection.Find(filter).FirstOrDefault();
            Login response = Map(bsonDocument);
            return response;
        }
    }
}