using ETicaretAPI.Application.Abstractions.Services.Storage;
using ETicaretAPI.Infrastructure.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Infrastructure.Services.Storage
{
    class StorageFileRenameService : IStorageFileRenameService
    {
        delegate bool HasFile(string pathOrContainerName, string fileName);
        public async Task<string> FileRenameAsync(string pathOrContainerName, string fileName, IStorageFileRenameService.HasFile hasFileMethod)
        {
            string extension = Path.GetExtension(fileName);
            string oldName = Path.GetFileNameWithoutExtension(fileName);
            string newFileName = $"{NameOperation.CharacterRegulatory(oldName)}{extension}";
            for (int i = 1; hasFileMethod(pathOrContainerName, newFileName); i++)
            {

                newFileName = $"{oldName}-{i}{extension}";
            }
            return newFileName;

        }

    }
}
