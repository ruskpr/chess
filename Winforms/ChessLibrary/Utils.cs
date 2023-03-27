using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary
{
    public class Utils
    {
        public static Bitmap RoundImage(Image img)
        {
            var roundedImage = new Bitmap(img.Width, img.Height, img.PixelFormat);

            using (var g = Graphics.FromImage(roundedImage))
            using (var gp = new GraphicsPath())
            {
                g.Clear(Color.Transparent);

                g.SmoothingMode = SmoothingMode.AntiAlias;
                
                Brush brush = new TextureBrush(img);
                gp.AddEllipse(0, 0, img.Width, img.Height);
                g.FillPath(brush, gp);
            }

            return roundedImage;
        }
    }
}
