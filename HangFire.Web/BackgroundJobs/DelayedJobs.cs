using System.Drawing;

namespace HangFire.Web.BackgroundJobs
{
    public class DelayedJobs
    {
        public static string AddWatermarkJob(string fileName, string watermarkText)
        {
            return Hangfire.BackgroundJob.Schedule(() => ApplyWatermark(fileName, watermarkText), TimeSpan.FromSeconds(20));
        }
        public static void ApplyWatermark(string fileName, string watermarkText)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pictures", fileName);

            using (var bitmap = Bitmap.FromFile(path))
            {
                using (Bitmap tempBitmap = new Bitmap(bitmap.Width, bitmap.Height))
                {
                    using (Graphics graphics = Graphics.FromImage(tempBitmap))
                    {
                        graphics.DrawImage(bitmap, 0, 0);

                        var font = new Font(FontFamily.GenericSansSerif, 25, FontStyle.Bold);

                        var color = Color.FromArgb(255, 0, 0);

                        var brush = new SolidBrush(color);

                        // x, y
                        var point = new Point(20, bitmap.Height - 50);

                        graphics.DrawString(watermarkText, font, brush, point);

                        tempBitmap.Save(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pictures/watermarks", fileName));
                    }
                }
            }
        }
    }
}
