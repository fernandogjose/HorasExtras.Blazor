using HorasExtra.Domain.Interfaces.Repositories;
using HorasExtra.Domain.Models;
using HorasExtra.Repository.Helpers;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace HorasExtra.Repository.Repositories
{
    public class HorasRepository : IHorasRepository
    {
        private readonly MongoHelper _mongoHelper;
        private readonly IMongoCollection<BsonDocument> _collection;

        public HorasRepository(MongoHelper mongoHelper)
        {
            _mongoHelper = mongoHelper;
            _collection = _mongoHelper.MongoDatabase.GetCollection<BsonDocument>("Horas");
        }

        private List<Horas> Map(List<BsonDocument> bsonDocuments)
        {
            List<Horas> response = new List<Horas>();
            foreach (var bsonDocument in bsonDocuments)
            {
                Horas horas = Map(bsonDocument);
                response.Add(horas);
            }
            return response;
        }

        private Horas Map(BsonDocument bsonDocument)
        {
            if (bsonDocument == null)
            {
                return new Horas();
            }

            Horas response = new Horas();
            response.Id = bsonDocument.GetValue("_id").ToString();
            response.Desenvolvedor = bsonDocument.GetValue("Desenvolvedor").ToString();
            response.Data = Convert.ToDateTime(bsonDocument.GetValue("Data").ToString());
            response.HoraInicio = bsonDocument.GetValue("HoraInicio").ToString();
            response.HoraFim = bsonDocument.GetValue("HoraFim").ToString();
            
            bsonDocument.TryGetValue("Justificativa", out BsonValue bsonValueJustificativa);
            if(bsonValueJustificativa != null)
            {
                response.Justificativa = bsonValueJustificativa.ToString();
            }

            return response;
        }

        public Horas Obter(string id)
        {
            FilterDefinitionBuilder<BsonDocument> builder = Builders<BsonDocument>.Filter;
            FilterDefinition<BsonDocument> filter = builder.Eq("_id", ObjectId.Parse(id));
            BsonDocument bsonDocument = _collection.Find(filter).FirstOrDefault();

            Horas response = Map(bsonDocument);
            return response;
        }

        public List<Horas> Listar(Horas request)
        {
            FilterDefinitionBuilder<BsonDocument> builder = Builders<BsonDocument>.Filter;
            FilterDefinition<BsonDocument> filter = builder.Eq("Desenvolvedor", request.Desenvolvedor);
            List<BsonDocument> bsonDocuments = _collection.Find(filter).ToList();

            List<Horas> response = Map(bsonDocuments);
            return response;
        }

        public void Adicionar(Horas request)
        {
            var bsonDocumentRequest = new BsonDocument(
                new Dictionary<string, string> {
                    { "Desenvolvedor", request.Desenvolvedor.ToString() },
                    { "Data", request.Data.ToShortDateString() },
                    { "HoraInicio", request.HoraInicio.ToString() },
                    { "HoraFim", request.HoraFim },
                    { "Justificativa", request.Justificativa }
                }
            );

            _collection.InsertOne(bsonDocumentRequest);
        }

        public void Editar(Horas request)
        {
            FilterDefinitionBuilder<BsonDocument> builder = Builders<BsonDocument>.Filter;
            FilterDefinition<BsonDocument> filter = builder.Eq("_id", ObjectId.Parse(request.Id));
            UpdateDefinition<BsonDocument> bsonDocumentRequest = Builders<BsonDocument>.Update
                .Set("Desenvolvedor", request.Desenvolvedor.ToString())
                .Set("Data", request.Data.ToShortDateString())
                .Set("HoraInicio", request.HoraInicio.ToString())
                .Set("HoraFim", request.HoraFim.ToString())
                .Set("Justificativa", request.Justificativa.ToString());

            _collection.UpdateOne(filter, bsonDocumentRequest);
        }
    }
}