namespace OnlineSpreadsheet.Web.ViewModels.ProjectFiles
{
    using AutoMapper;
    using Infrastructure;
    using OnlineSpreadsheet.Data.Models;
    using Localization.Resources;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class FolderVM : IMapFrom<Folder>
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "FolderName", ResourceType = typeof(Resources))]
        public string Name { get; set; }

        public int? ParentFolderID { get; set; }

        [Display(Name = "DateCreated", ResourceType = typeof(Resources))]
        public DateTime CreatedOn { get; set; }

        [Display(Name = "LastUpdated", ResourceType = typeof(Resources))]
        public DateTime? ModifiedOn { get; set; }
    }
}