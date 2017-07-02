namespace OnlineSpreadsheet.Web.Application.Services
{
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;

    public class ImageService
    {
        public static void SaveThumbnail(string path, string newPath, int width, int height)
        {
            using (System.Drawing.Image photo = new Bitmap(path))
            {
                double aspectRatio = (double)photo.Width / photo.Height;
                double boxRatio = width / height;
                double scaleFactor = 0;

                if (photo.Width < width && photo.Height < height)
                {
                    // keep the image the same size since it is already smaller than our max width/height
                    scaleFactor = 1.0;
                }
                else
                {
                    if (boxRatio > aspectRatio)
                        scaleFactor = (double)height / photo.Height;
                    else
                        scaleFactor = (double)width / photo.Width;
                }

                int newWidth = (int)(photo.Width * scaleFactor);
                int newHeight = (int)(photo.Height * scaleFactor);

                using (Bitmap bmp = new Bitmap(newWidth, newHeight))
                {
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        g.SmoothingMode = SmoothingMode.HighQuality;
                        g.CompositingQuality = CompositingQuality.HighQuality;
                        g.PixelOffsetMode = PixelOffsetMode.HighQuality;

                        g.DrawImage(photo, 0, 0, newWidth, newHeight);


                        ImageCodecInfo[] info = ImageCodecInfo.GetImageEncoders();
                        EncoderParameters encoderParameters;
                        using (encoderParameters = new System.Drawing.Imaging.EncoderParameters(1))
                        {
                            // use jpeg info[1] and set quality to 90
                            encoderParameters.Param[0] = new System.Drawing.Imaging.EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 90L);
                            bmp.Save(newPath, info[1], encoderParameters);
                        }

                    }
                }
            }
        }
    }
}