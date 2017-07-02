namespace OnlineSpreadsheet.Web.Application.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Web;
    using Ionic.Zip;
    using OnlineSpreadsheet.Data.Common;

    public class Files
    {
        private static readonly List<string> archiveExtension = new List<string>() { ".zip", ".7z" };

        public static string SaveFile(HttpPostedFileBase file, string path, string newName = "")
        {
            //Create directory if it does not exist
            Directory.CreateDirectory(path);

            string fileName = Path.GetFileName(file.FileName);

            if (!string.IsNullOrEmpty(newName))
            {
                fileName = $"{newName}{Path.GetExtension(file.FileName)}";
            }

            path = Path.Combine(path, fileName);

            //Delete if already file with the same name exists in the folder
            File.Delete(path);

            //Save file
            file.SaveAs(path);

            return fileName;
        }

        public static bool IsArchive(HttpPostedFileBase file)
        {
            var extension = Path.GetExtension(file.FileName);

            return extension != null && archiveExtension.Contains(extension.ToLower());
        }

        public static string ZipFolder(Dictionary<string, string> files, string path, string zipFileName)
        {
            // Get the FileInfo objects for every file in the directory.
            string zipFile = $"{path}/{zipFileName}.zip";
            using (var zip = new ZipFile())
            {
                foreach (var file in files)
                {
                    zip.AddFile(file.Key, file.Value);
                }
                zip.Save(zipFile);
            }

            return zipFile;
        }

        public static void DeleteDirectory(string path)
        {
            DeleteDirectory(path, false);
        }

        public static void DeleteDirectory(string path, bool recursive)
        {
            try
            {
                if (recursive)
                {
                    var subfolders = Directory.GetDirectories(path);
                    foreach (var s in subfolders)
                    {
                        DeleteDirectory(s, true);
                    }
                }

                var files = Directory.GetFiles(path);
                foreach (var f in files)
                {
                    // Delete the file
                    File.Delete(f);
                }

                // When we get here, all the files of the folder were
                // already deleted, so we just delete the empty folder
                Directory.Delete(path);
            }
            catch (Exception ex)
            {
                NLogger.Instance.Error(ex);
            }
        }
    }
}