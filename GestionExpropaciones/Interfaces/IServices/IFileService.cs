using GestionExpropaciones.Models;

namespace GestionExpropaciones.Interfaces.IServices;

public interface IFileService
{    
    Task<FileModel?> GetFile_ByIdAsync(int idFile);
    Task<PageResponseModel<FileModel>> GetFileList_Pagination_SearchAsync(int pageNumber, string searchTerm);
    Task<bool> Create_FileAsync(FileModel file);
    Task<bool> Edit_FileAsync(FileModel file);
    Task<bool> Delete_FileAsync(int idFile);
}
