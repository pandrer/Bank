using CoreMicroservice.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace CoreMicroservice.Repository
{
    public class RadicatorRepository : IRadicatorRepository
    {

        private readonly IMongoCollection<RegisterFile> _colRegisterFile;
        public RadicatorRepository(IMongoDatabase db)
        {
            _colRegisterFile = db.GetCollection<RegisterFile>(RegisterFile.DocumentName);
        }

        public List<RegisterFile> GetRegisterFiles() =>
            _colRegisterFile.Find(FilterDefinition<RegisterFile>.Empty).ToList();

        public RegisterFile GetRegisterFile(Guid registerFileId) =>
            _colRegisterFile.Find(c => c.Id == registerFileId).FirstOrDefault();

        public void InsertRegisterFile(RegisterFile registerFile) =>
            _colRegisterFile.InsertOne(registerFile);

        public void UpdateRegisterFile(RegisterFile registerFile) =>
            _colRegisterFile.UpdateOne(c => c.Id == registerFile.Id, Builders<RegisterFile>.Update
                .Set(c => c.Id, registerFile.Id)
                .Set(c => c.Status, registerFile.Status)
                .Set(c => c.RegisterDate, registerFile.RegisterDate)
                .Set(c => c.State, registerFile.State)
                .Set(c => c.City, registerFile.City)
                .Set(c => c.Description, registerFile.Description)
                .Set(c => c.Sender, registerFile.Sender)
                .Set(c => c.Receiver, registerFile.Receiver)
                .Set(c => c.Courier, registerFile.Courier)
                );

        public void DeleteRegisterFile(Guid registerFileId) =>
            _colRegisterFile.DeleteOne(c => c.Id == registerFileId);
    }
}
