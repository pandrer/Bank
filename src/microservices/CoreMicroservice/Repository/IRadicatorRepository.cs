using CoreMicroservice.Model;
using System;
using System.Collections.Generic;

namespace CoreMicroservice.Repository
{
    public interface IRadicatorRepository
    {
        void DeleteRegisterFile(Guid registerFileId);
        RegisterFile GetRegisterFile(Guid registerFileId);
        List<RegisterFile> GetRegisterFiles();
        void InsertRegisterFile(RegisterFile registerFile);
        void UpdateRegisterFile(RegisterFile registerFile);
    }
}