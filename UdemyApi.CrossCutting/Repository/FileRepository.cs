using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UdemyApi.Application.VO.UploadDir;

namespace UdemyApi.CrossCutting.Repository
{
    public class FileRepository : IFileDetailRepository
    {

        private readonly string _basePath;
        private readonly IHttpContextAccessor _acessor;

        public FileRepository(string basePath, IHttpContextAccessor acessor)
        {
            _basePath = Directory.GetCurrentDirectory() + "\\UploadDir\\";
            _acessor = acessor;
        }

        public byte[] GetFileDetail(string fileName)
        {
            throw new NotImplementedException();
        }

        public Task<FileDetailVO> SaveFileToDisk(IFormFile file)
        {
            throw new NotImplementedException();
        }

        public Task<List<FileDetailVO>> SaveFileToDisk(IList<IFormFile> file)
        {
            throw new NotImplementedException();
        }
    }
}
