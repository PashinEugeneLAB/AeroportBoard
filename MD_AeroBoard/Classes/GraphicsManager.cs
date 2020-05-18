using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MD_AeroBoard.Classes
{
    public static class GraphicsManager
    {
        public static BitmapImage GetRealImage(this System.Drawing.Bitmap bmp)
        {
            MemoryStream ms = new MemoryStream();
            bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] bytes = ms.ToArray();
            ms = new MemoryStream(bytes);
            BitmapImage img = new BitmapImage();
            img.BeginInit();
            img.StreamSource = ms;
            img.EndInit();
            return img;
        }

        public static Bitmap GetDiagram(List<int> Data)
        {
            int AllSection = 24;
            int Step = 25;
            int Width = AllSection * Step;
            int wItem = 5;
            Bitmap img = new Bitmap(Width, Width);

            using (Graphics g = Graphics.FromImage(img))
            {
                g.FillRectangle(new SolidBrush(ColorTranslator.FromHtml("#FFF8D1")), 0, 0, Width, Width);
                g.DrawRectangle(new Pen(ColorTranslator.FromHtml("#1E415D"), 4), 0, 0, Width, Width);

                foreach (int item in Data)
                {
                    int SectionNumber = Data.IndexOf(item);

                    int X = SectionNumber * Step;

                    g.FillRectangle(new SolidBrush(Color.FromArgb(255, ColorTranslator.FromHtml("#00B715"))), X- wItem, Width, X+ wItem, item);
                    g.DrawRectangle(new Pen(ColorTranslator.FromHtml("white"), 2), X - wItem, Width, X + wItem, item);

                }
            }

            return img;

        }
    }
}
