namespace OnlineSpreadsheet.Web.ViewModels.ProjectFiles
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web;
    using OnlineSpreadsheet.Localization.Resources;

    public class FolderCreateVM
    {
        public FolderCreateVM()
        {
        }

        public FolderCreateVM(int folderID)
        {
            this.ParentFolderID = folderID;
        }

        public IEnumerable<HttpPostedFileBase> Files { get; set; }

        public int ID { get; set; }

        [Required(ErrorMessageResourceName = "FolderNameRequired",ErrorMessageResourceType = typeof(Resources))]
        public string Name { get; set; }

        public int ParentFolderID { get; set; }
    }
}