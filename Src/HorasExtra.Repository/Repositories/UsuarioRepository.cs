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

        private List<Usuario> Map(List<BsonDocument> bsonDocuments)
        {
            List<Usuario> response = new List<Usuario>();
            foreach (var bsonDocument in bsonDocuments)
            {
                Usuario usuario = Map(bsonDocument);
                response.Add(usuario);
            }
            return response;
        }

        private Usuario Map(BsonDocument bsonDocument)
        {
            if (bsonDocument == null)
            {
                return new Usuario();
            }

            Usuario response = new Usuario();
            response.Nome = bsonDocument.GetValue("Nome").ToString();
            return response;
        }

        public void Adicionar(Usuario request)
        {
            var bsonDocumentRequest = new BsonDocument(
                new Dictionary<string, string> {
                    { "Nome", request.Nome.ToString() },
                    { "Email", request.Email },
                    { "Senha", request.Senha.ToString() },
                    { "Perfil", request.Perfil.ToString() },
                }
            );

            _collection.InsertOne(bsonDocumentRequest);
        }

        public List<Usuario> Listar()
        {
            FilterDefinitionBuilder<BsonDocument> builder = Builders<BsonDocument>.Filter;
            FilterDefinition<BsonDocument> filter = builder.Empty;
            List<BsonDocument> bsonDocuments = _collection.Find(filter).ToList();

            List<Usuario> response = Map(bsonDocuments);
            return response;
        }
    }
}