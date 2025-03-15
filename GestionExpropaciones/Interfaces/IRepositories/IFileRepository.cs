using GestionExpropaciones.Models;

namespace GestionExpropaciones.Interfaces.IRepositories;

public interface IFileRepository
{    
    Task<FileModel?> GetFile_ByIdAsync(int idFile);
    Task<List<FileModel>> GetFileList_Pagination_SearchAsync(int pageNumber, string searchTerm);
    Task<int> GetFile_TotalCountAsync(string searchTerm);
    Task<bool> Create_FileAsync(FileModel file);
    Task<bool> Edit_FileAsync(FileModel file);
    Task<bool> Delete_FileAsync(int idFile);
}
