using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace FileManagerMicroservice.BLL.Contracts
{
    public interface IStorageBusiness
    {
        Task<string> WriteFile(IFormFile file);
    }
}
