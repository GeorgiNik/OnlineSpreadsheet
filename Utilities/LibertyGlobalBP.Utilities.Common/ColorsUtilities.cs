namespace LibertyGlobalBP.Utilities.Common
{
    using System.Drawing;

    public static class ColorsUtilities
    {
        public const string Black = "#000000";

        public const string Blue = "#3899B4";

        public const string Orange = "#ea5e35";

        public const string Green = "#48c27e";

        public const string Gray = "#CCCCCC";

        public const string Lead = "#67AD2F";

        public const string CoLead = "#67AD2F";

        public const string Trailing = "#7F7F7F";

        /// <summary>
        /// Creates color with corrected brightness.
        /// </summary>
        /// <param name="color">Color to correct.</param>
        /// <param name="correctionFactor">The brightness correction factor. Must be between -1 and 1. 
        /// Negative values produce darker colors.</param>
        /// <returns>
        /// Corrected <see cref="Color"/> structure.
        /// </returns>
        public static string ChangeColorBrightness(Color color, double correctionFactor)
        {
            double red = (double)color.R;
            double green = (double)color.G;
            double blue = (double)color.B;

            if (correctionFactor < 0)
            {
                correctionFactor = 1 + correctionFactor;
                red *= correctionFactor;
                green *= correctionFactor;
                blue *= correctionFactor;
            }
            else
            {
                red = ((255 - red) * correctionFactor) + red;
                green = ((255 - green) * correctionFactor) + green;
                blue = ((255 - blue) * correctionFactor) + blue;
            }

            return Color.FromArgb(color.A, (int) red, (int) green, (int) blue).ToHex();
        }

        public static string ChangeColorBrightness(Color color, float correctionFactor)
        {
            return ChangeColorBrightness(color, (double) correctionFactor);
        }

        public static string ToHex(this Color color)
        {
            return ColorTranslator.ToHtml(color);
        }
    }
}
