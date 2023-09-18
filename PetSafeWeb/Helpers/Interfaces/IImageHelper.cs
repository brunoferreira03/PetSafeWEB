using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace PetSafeWeb.Helpers.Interfaces
{
    public interface IImageHelper
    {
        Task<string> UploadImageAsync(IFormFile imageFile, string folder);
    }
}
