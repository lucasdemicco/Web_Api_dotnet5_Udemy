using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using UdemyApi.Application.VO.UploadDir;

namespace UdemyApi.CrossCutting.Repository
{
    internal interface IFileDetailRepository
    {
        public byte[] GetFileDetail(string fileName);
        public Task<FileDetailVO> SaveFileToDisk(IFormFile file);
        public Task<List<FileDetailVO>> SaveFileToDisk(IList<IFormFile> file);
    }
}
