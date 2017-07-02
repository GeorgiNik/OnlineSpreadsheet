namespace OnlineSpreadsheet.Web.ViewModels.ProjectFiles
{
    using System.ComponentModel.DataAnnotations;
    using OnlineSpreadsheet.Localization.Resources;

    public class UploadFilesVM
    {
        [Required]
        [Display(Name = "SelectFolder", ResourceType = typeof(Resources))]
        public int FolderID { get; set; }
    }
}
