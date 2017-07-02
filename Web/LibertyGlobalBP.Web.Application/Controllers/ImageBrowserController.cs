namespace LibertyGlobalBP.Web.Application.Controllers
{
    using System.IO;
    using Kendo.Mvc.UI;

    public class ImageBrowserController : EditorImageBrowserController
    {
        private const string ContentFolderRoot = "~/Images/";
        private const string PrettyName = "Images/";
        private static readonly string[] FoldersToCopy = new[] { "~/Images/Shared/" };

        /// <summary>
        /// Gets the base paths from which content will be served.
        /// </summary>
        public override string ContentPath
        {
            get
            {
                return this.CreateUserFolder();
            }
        }

        private string CreateUserFolder()
        {
            var virtualPath = Path.Combine(ContentFolderRoot, "Shared");

            var path = this.Server.MapPath(virtualPath);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                foreach (var sourceFolder in FoldersToCopy)
                {
                    this.CopyFolder(this.Server.MapPath(sourceFolder), path);
                }
            }

            return virtualPath;
        }

        private void CopyFolder(string source, string destination)
        {
            if (!Directory.Exists(destination))
            {
                Directory.CreateDirectory(destination);
            }

            foreach (var file in Directory.EnumerateFiles(source))
            {
                var dest = Path.Combine(destination, Path.GetFileName(file));
                System.IO.File.Copy(file, dest);
            }

            foreach (var folder in Directory.EnumerateDirectories(source))
            {
                var dest = Path.Combine(destination, Path.GetFileName(folder));
                this.CopyFolder(folder, dest);
            }
        }
    }
}