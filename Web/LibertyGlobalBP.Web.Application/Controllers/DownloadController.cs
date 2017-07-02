namespace LibertyGlobalBP.Web.Application.Controllers
{
    using System;
    using System.Configuration;
    using System.IO;
    using System.Web.Mvc;
    using LibertyGlobalBP.Data.Services.Contracts;

    [Authorize]
    public class DownloadController : BaseController
    {
        private readonly IProjectFilesService projectFilesService;
        private const string ImportFileDateFormat = "dd-MM-yyyy_HH-mm";
        private const string ExcelFileExtension = ".xlsx";
        private const string ExcelContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        private readonly string uploadDirectory = ConfigurationManager.AppSettings["DataFilesUploadPath"];
        private readonly string directory = ConfigurationManager.AppSettings["ProjectFilesFolder"];

        public DownloadController(IProjectFilesService projectFilesService)
        {
            this.projectFilesService = projectFilesService;
        }
        public FileResult Reports(string id)
        {
            var file = this.Server.MapPath(ConfigurationManager.AppSettings["ExcelExportsPath"] + id);
            var name = "export-" + DateTime.Now.ToString(ImportFileDateFormat) + ExcelFileExtension;
            
            return this.File(file, ExcelContentType, name);
        }

        public FileResult ValidatedImport(string fileName)
        {
            var file = this.Server.MapPath(ConfigurationManager.AppSettings["DataFilesUploadPath"] + fileName);
            var name = "ValidatedImport-" + DateTime.Now.ToString(ImportFileDateFormat) + ExcelFileExtension;

            return this.File(file, ExcelContentType, name);
        }

        public FileResult ProjectFile(int id)
        {
            var file = this.projectFilesService.GetFile(id);
            var fileName = file.Name;
            var folderName = this.projectFilesService.GetFolder(file.FolderID)?.Name;
            var physicalPath = Path.Combine(this.Server.MapPath(this.directory), folderName, fileName);
            this.Response.BufferOutput = false;

            return this.File(physicalPath, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
    }
}