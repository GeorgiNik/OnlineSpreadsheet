namespace OnlineSpreadsheet.Data.Services.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using OnlineSpreadsheet.Data.Common;
    using OnlineSpreadsheet.Data.Models;
    using OnlineSpreadsheet.Data.Services.Contracts;
    using OnlineSpreadsheet.Web.ViewModels.ProjectFiles;
    using OnlineSpreadsheet.Web.ViewModels.Users;

    public class ProjectProjectFilesesService : IProjectFilesService
    {
        private readonly IDeletableRepository<File> projectFiles;

        private readonly IDeletableRepository<Folder> projectFolders;

        private readonly Repository<ApplicationUser> users;

        public ProjectProjectFilesesService(IDeletableRepository<File> files, IDeletableRepository<Folder> folders, Repository<ApplicationUser> users)
        {
            this.projectFiles = files;
            this.projectFolders = folders;
            this.users = users;
        }

        public void CreateFolder(FolderVM vm)
        {
            var folder = Mapper.Map<Folder>(vm);

            this.projectFolders.Add(folder);
            this.projectFolders.SaveChanges();
        }

        public void DeleteFile(int id)
        {
            this.projectFiles.ActualDelete(id);
            this.projectFiles.SaveChanges();
        }

        public void DeleteFolder(int id)
        {
            this.projectFolders.ActualDelete(id);
            this.projectFiles.ActualDelete(x => x.FolderID == id);
            this.projectFolders.SaveChanges();
        }

        public void DownloadFile(int id)
        {
            throw new NotImplementedException();
        }

        public bool FileExists(int folderId, string name, int? fileId = -1)
        {
            if (fileId == -1)
            {
                return false;
            }

            var result = this.projectFiles.Any(x => x.Name == name && x.FolderID == folderId && x.ID == fileId.Value);

            return result;
        }

        public bool FolderExists(int folderId, string name)
        {
            var result = this.projectFolders.Any(x => x.Name == name && x.ID != folderId);

            return result;
        }

        public bool FolderExists(string name)
        {
            var result = this.projectFolders.Any(x => x.Name == name);

            return result;
        }

        public IQueryable<FileVM> GetAllFiles(int id)
        {
            return this.projectFiles.GetAll().Where(x => x.FolderID == id).ProjectTo<FileVM>();
        }

        public IQueryable<FolderVM> GetAllFolders(string userId)
        {
            return this.projectFolders.GetAll().ProjectTo<FolderVM>();
        }

        public FileVM GetFile(int id)
        {
            return Mapper.Map<FileVM>(this.projectFiles.Get(id));
        }

        public FileVM GetFile(string name)
        {
            return Mapper.Map<FileVM>(this.projectFiles.FirstOrDefault(x => x.Name == name));
        }

        public FolderVM GetFolder(string name)
        {
            return Mapper.Map<FolderVM>(this.projectFolders.FirstOrDefault(x => x.Name == name));
        }

        public FolderVM GetFolder(int id)
        {
            return Mapper.Map<FolderVM>(this.projectFolders.Get(id));
        }

        public void UpdateFolder(FolderVM vm)
        {
            var model = this.projectFolders.Get(vm.ID);
            var createdOn = model.CreatedOn;
            var folder = Mapper.Map(vm, model);
            folder.CreatedOn = createdOn;

            this.projectFolders.Update(folder);
            this.projectFolders.SaveChanges();
        }

        public void UploadFiles(IEnumerable<HttpPostedFileBase> files, int folderId)
        {
            foreach (var uploadeFile in files)
            {
                var newFile = new File()
                {
                    Name = uploadeFile.FileName,
                    Size = uploadeFile.ContentLength.ToString(),
                    FolderID = folderId,
                    CanBeDownloaded = true
                };

                if (!this.projectFiles.Any(x => x.Name == newFile.Name && x.FolderID == folderId))
                {
                    this.projectFiles.Add(newFile);
                }
                else
                {
                    var file = this.projectFiles.FirstOrDefault(x => x.Name == newFile.Name && x.FolderID == folderId);
                    file.ModifiedOn = DateTime.UtcNow;
                }
            }

            this.projectFiles.SaveChanges();
        }
    }
}