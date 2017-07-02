namespace LibertyGlobalBP.Data.Services.Contracts
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Web.ViewModels.ProjectFiles;

    public interface IProjectFilesService
    {
        void CreateFolder(FolderVM vm);

        void DeleteFile(int id);

        void DeleteFolder(int id);

        void DownloadFile(int id);

        bool FileExists(int folderId, string name, int? fileId = -1);

        bool FolderExists(int folderId, string name);

        bool FolderExists(string name);

        IQueryable<FileVM> GetAllFiles(int id);

        IQueryable<FolderVM> GetAllFolders(string userId);

        FileVM GetFile(int id);

        FileVM GetFile(string name);

        FolderVM GetFolder(string name);

        FolderVM GetFolder(int id);

        void UpdateFolder(FolderVM vm);

        void UploadFiles(IEnumerable<HttpPostedFileBase> files, int folderId);
    }
}