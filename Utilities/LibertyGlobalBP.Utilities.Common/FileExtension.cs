namespace LibertyGlobalBP.Utilities.Common
{
    public class FileExtension
    {
        public static FileType GetFileType(string extension)
        {
            extension = extension.ToLower();
            switch (extension)
            {
                case ".png":
                case ".jpeg":
                case ".jpg":
                case ".gif":
                case ".bmp":
                case ".tiff":
                    return FileType.Image;
                case ".mp3":
                case ".mp4":
                case ".wav":
                    return FileType.Audio;
                case ".avi":
                case ".wmv":
                case ".flv":
                    return FileType.Video;
                case ".doc":
                case ".docx":
                    return FileType.Word;
                case ".xlsx":
                    return FileType.Excel;
                case ".ppt":
                case ".pptx":
                    return FileType.Ppt;
                case ".pdf":
                    return FileType.Pdf;
                default:
                    return FileType.Other;
            }
        }
    }
}