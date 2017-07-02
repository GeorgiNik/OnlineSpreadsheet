namespace LibertyGlobalBP.Web.ViewModels.ProjectFiles
{
    using System.ComponentModel.DataAnnotations;
    using LibertyGlobalBP.Localization.Resources;

    public class UploadFilesVM
    {
        [Required]
        [Display(Name = "SelectFolder", ResourceType = typeof(Resources))]
        public int FolderID { get; set; }
    }
}
