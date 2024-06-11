using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Abstractions.Services.Storage
{
    public interface IStorageFileRenameService
    {
         delegate bool HasFile(string pathOrContainerName, string fileName);
        Task<string> FileRenameAsync(string pathOrContainerName, string fileName, HasFile hasFileMethod);
    }
}
