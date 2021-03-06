﻿namespace OnlineSpreadsheet.Web.ViewModels.ProjectFiles
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using OnlineSpreadsheet.Localization.Resources;
    using OnlineSpreadsheet.Web.ViewModels.Infrastructure;
    using File = OnlineSpreadsheet.Data.Models.File;

    public class FileVM : IMapFrom<File>
    {
        [Display(Name = "DateCreated", ResourceType = typeof(Resources))]
        public DateTime CreatedOn { get; set; }

        [Display(Name = "LastUpdated", ResourceType = typeof(Resources))]
        public DateTime? ModifiedOn { get; set; }

        public int FolderID { get; set; }

        public int ID { get; set; }

        public string Name { get; set; }

        public string Path { get; set; }

        public string Size { get; set; }

        public string Type { get; set; }
    }
}