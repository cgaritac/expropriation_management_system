using GestionExpropaciones.Models;
using GestionExpropaciones.Interfaces.IRepositories;
using GestionExpropaciones.Interfaces.IServices;
using GestionExpropaciones.Common;

namespace GestionExpropaciones.Services;

public class FileService(IFileRepository fileRepository, IUserService userService) : IFileService
{
    private readonly IFileRepository _fileRepository = fileRepository;
    private readonly IUserService _userservice = userService;

    public async Task<FileModel?> GetFile_ByIdAsync(int idFile)
    {
        return await _fileRepository.GetFile_ByIdAsync(idFile);
    }

    public async Task<PageResponseModel<FileModel>> GetFileList_Pagination_SearchAsync(int pageNumber, string searchTerm)
    {
        var fileList = await _fileRepository.GetFileList_Pagination_SearchAsync(pageNumber, searchTerm);
        var Count = await _fileRepository.GetFile_TotalCountAsync(searchTerm);

        var pageResponse = new PageResponseModel<FileModel>(
            items: fileList,
            totalCount: Count,
            page: pageNumber,
            pageSize: Constants.PageSize
        );
                
        return pageResponse;
    }

    public async Task<bool> Create_FileAsync(FileModel file)
    {
        var user = _userservice.GetUserEmail();

        file.SetCreationInfo(user);

        return await _fileRepository.Create_FileAsync(file);
    }

    public async Task<bool> Edit_FileAsync(FileModel file)
    {
        return await _fileRepository.Edit_FileAsync(file);
    }

    public async Task<bool> Delete_FileAsync(int idFile)
    {
       return await _fileRepository.Delete_FileAsync(idFile);
    }
}
