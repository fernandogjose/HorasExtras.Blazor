using HorasExtra.Domain.Interfaces.Repositories;
using HorasExtra.Domain.Models;
using HorasExtra.Repository.Helpers;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace HorasExtra.Repository.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly MongoHelper _mongoHelper;
        private readonly IMongoCollection<BsonDocument> _collection;

        public UsuarioRepository(MongoHelper mongoHelper)
        {
            _mongoHelper = mongoHelper;
            _collection = _mongoHelper.MongoDatabase.GetCollection<BsonDocument>("Usuario");
        }

        public void Adicionar(Usuario request)
        {
            var bsonDocumentRequest = new BsonDocument(
                new Dictionary<string, string> {
                    { "Nome", request.Nome.ToString() },
                    { "Email", request.Email },
                    { "Senha", request.Senha.ToString() },
                }
            );

            _collection.InsertOne(bsonDocumentRequest);
        }
    }
}