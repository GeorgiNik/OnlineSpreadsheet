namespace LibertyGlobalBP.Web.Application.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using LibertyGlobalBP.Data.Models;
    using LibertyGlobalBP.Data.Services.Contracts;
    using LibertyGlobalBP.Localization.Resources;
    using LibertyGlobalBP.Web.Application.Infrastructure;
    using LibertyGlobalBP.Web.Application.Services;
    using LibertyGlobalBP.Web.ViewModels.ProjectFiles;
    using Microsoft.AspNet.Identity;

    [AuthorizeUser(AccessRequest = AccessRequest.ProjectFilesEdit)]
    public class ProjectFilesController : BaseController
    {
        private readonly IProjectFilesService projectFilesService;
        private readonly string directory = ConfigurationManager.AppSettings["ProjectFilesFolder"];

        public ProjectFilesController(IProjectFilesService fs)
        {
            this.projectFilesService = fs;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Folders_Read([DataSourceRequest]DataSourceRequest request)
        {
            var userId = this.User.Identity.GetUserId();
            var result = this.projectFilesService.GetAllFolders(userId).ToDataSourceResult(request);

            return this.Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Folders_Destroy([DataSourceRequest]DataSourceRequest request, FolderVM folder)
        {
            var physicalPath = Path.Combine(this.Server.MapPath(this.directory), folder.Name);
            if (Directory.Exists(physicalPath))
            {
                Directory.Delete(physicalPath, true);
                this.projectFilesService.DeleteFolder(folder.ID);
            }

            return this.Json(new[] { folder }.ToDataSourceResult(request, this.ModelState), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Files_Read([DataSourceRequest]DataSourceRequest request, int fileId)
        {
            var result = this.projectFilesService.GetAllFiles(fileId).ToDataSourceResult(request);

            return this.Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CreateFolder()
        {
            var vm = new FolderVM();
            return this.PartialView("_CreateFolder", vm);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult CreateFolder(FolderVM vm)
        {
            if (this.projectFilesService.FolderExists(vm.Name))
            {
                this.ModelState.AddModelError(string.Empty, Resources.FolderNameExists);
            }
            if (this.ModelState.IsValid)
            {
                var physicalPath = Path.Combine(this.Server.MapPath(this.directory), vm.Name);

                if (!Directory.Exists(physicalPath))
                {
                    Directory.CreateDirectory(physicalPath);
                    this.projectFilesService.CreateFolder(vm);
                }

                return null;
            }

            var errors = this.ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
            return this.ValidationError(errors);
        }

        public ActionResult EditFolder(int id)
        {
            var vm = this.projectFilesService.GetFolder(id);
            return this.PartialView("_EditFolder", vm);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult EditFolder(FolderVM vm)
        {
            if (this.projectFilesService.FolderExists(vm.ID, vm.Name))
            {
                this.ModelState.AddModelError(String.Empty, Resources.FolderNameExists);
            }

            if (this.ModelState.IsValid)
            {
                var oldName = this.projectFilesService.GetFolder(vm.ID)?.Name;
                var physicalPathNewFolderName = Path.Combine(this.Server.MapPath(this.directory), vm.Name);
                var physicalPathOldFolderName = Path.Combine(this.Server.MapPath(this.directory), oldName);

                if (Directory.Exists(physicalPathOldFolderName))
                {
                    if (physicalPathNewFolderName != physicalPathOldFolderName)
                    {
                        Directory.Move(physicalPathOldFolderName, physicalPathNewFolderName);
                    }

                    this.projectFilesService.UpdateFolder(vm);
                }

                return null;
            }

            var errors = this.ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
            return this.ValidationError(errors);
        }

        public ActionResult UploadFiles()
        {
            var vm = new UploadFilesVM();
            return this.PartialView("_UploadFiles", vm);
        }

        public ActionResult Upload(IEnumerable<HttpPostedFileBase> files, int? folderId)
        {
            if (folderId == null)
            {
                this.Content(Resources.SelectFolder);
            }

            if (files != null)
            {
                if (this.ModelState.IsValid)
                {
                    foreach (var uploadedFile in files)
                    {
                        var fileName = Path.GetFileName(uploadedFile.FileName);
                        var folderName = this.projectFilesService.GetFolder(folderId.Value)?.Name;
                        var physicalPath = Path.Combine(this.Server.MapPath(this.directory), folderName, fileName);
                        var directoryPath = Path.Combine(this.Server.MapPath(this.directory), folderName);
                        if (Directory.Exists(directoryPath))
                        {
                            uploadedFile.SaveAs(physicalPath);
                        }
                    }

                    this.projectFilesService.UploadFiles(files, folderId.Value);

                    return this.Content("");
                }
            }

            return this.Content(Resources.DataFileUploadError);
        }

        public ActionResult DeleteFile(int id)
        {
            if (this.ModelState.IsValid)
            {
                var file = this.projectFilesService.GetFile(id);
                var fileName = file.Name;
                var folderName = this.projectFilesService.GetFolder(file.FolderID)?.Name;
                var physicalPath = Path.Combine(this.Server.MapPath(this.directory), folderName, fileName);

                if (System.IO.File.Exists(physicalPath))
                {
                    System.IO.File.Delete(physicalPath);
                    this.projectFilesService.DeleteFile(id);
                }
            }

            return null;
        }
    }
}