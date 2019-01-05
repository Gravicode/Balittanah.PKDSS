using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PKDSS.MonoApp.Helpers
{
    public class RawChart
    {

        public DataGelombang data { get; set; }
        string CurrentFileName;
        public Bitmap DrawChart(Size size, Pen PenColor, int AmplitudeScale=120)
        {
            if (data == null) return null;
            int nSamples = data.wavenumber.Count;
            //Stopwatch sw = new Stopwatch();
            //sw.Start();

            //Size size = new Size(800, 600);
            Color BackColor = Color.Black;

           
            var datas = new DrawPoint[nSamples];
            double MaxVal = -1;
            double MinVal = 99999;
            for (int i = 0; i < nSamples - 1; i++)//i = timeslice
            {
                datas[i] = new DrawPoint();
                datas[i].X = data.wavenumber[i];
                datas[i].Y = data.absorbance[i];

            }
            MaxVal = AmplitudeScale;
            MinVal = -AmplitudeScale;
            Bitmap bmp = new System.Drawing.Bitmap(size.Width, size.Height,
                                    PixelFormat.Format32bppArgb);
            Padding borders = new Padding(50, 5, 5, 30);
            Rectangle plotArea = new Rectangle(borders.Left, borders.Top,
                           size.Width - borders.Left - borders.Right,
                           size.Height - borders.Top - borders.Bottom);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.Silver);
                using (SolidBrush brush = new SolidBrush(BackColor))
                    g.FillRectangle(brush, plotArea);
                g.DrawRectangle(Pens.LightGoldenrodYellow, plotArea);
                var step = plotArea.Height / 10;
                var valStep = AmplitudeScale / 5;
                var startStep = valStep * 5;
                var MyFont = new Font(FontFamily.GenericMonospace, 8);
                var FontBrush = new SolidBrush(Color.Black);
                for (int i = 0; i <= 10; i++)
                {
                    var he = (plotArea.Top + (startStep >= 0 ? 2 : 4)) + i * step;
                    g.DrawLine(Pens.Black, plotArea.Left - 5, he,
                          plotArea.Left, he);
                    g.DrawString(ConvertNumber(startStep), MyFont, FontBrush, new PointF(plotArea.Left - 40, he - 5));
                    startStep -= valStep;
                }
                g.TranslateTransform(plotArea.Left, plotArea.Top);

                g.DrawLine(Pens.White, 0, plotArea.Height / 2, plotArea.Width, plotArea.Height / 2);

                double dataHeight = Math.Max(MaxVal, MinVal) * 2;
                double yScale = 1f * plotArea.Height / dataHeight;
                double xScale = 1f * plotArea.Width / nSamples;


                g.ScaleTransform((float)xScale, (float)yScale);

                g.TranslateTransform(0, (float)dataHeight / 2);

                //g.DrawLine(Pens.White, new Point(0, 0), new Point(datas.Length, 0));
                //reverse drawing      

                var pointsIM = datas.ToList().AsParallel().Select((currentitem, x) => new { x, y=currentitem })
                                 .Select(p => new PointF((float)p.y.X, (float)p.y.Y * -1)).ToList();
                g.DrawLines(PenColor, pointsIM.ToArray());

                g.ResetTransform();
                g.DrawString(nSamples.ToString("###,###,###,##0") + " data samples plotted.",
                    new Font("Consolas", 14f), Brushes.Black,
                    plotArea.Left, plotArea.Bottom + 2f);
            }
            return bmp;
            //sw.Stop();
            //Console.WriteLine(sw.ElapsedMilliseconds + "ms");
            // Save sin_0_2pi.png image file
            //bmp.Save(@"C:\Users\mifma\Pictures\sonar\chart\chart.png", System.Drawing.Imaging.ImageFormat.Png);
            //return bmp;
        }
        public string ConvertNumber(int num)
        {
            if (Math.Abs( num) >= 1000)
                return string.Concat(num / 1000, "k");
            else
                return num.ToString();
        }
        public bool LoadFile(string FileName)
        {
            if (CurrentFileName == FileName) return true;
            try
            {
                if (!File.Exists(FileName)) return false;
                data = JsonConvert.DeserializeObject<DataGelombang>(File.ReadAllText(FileName));
                CurrentFileName = FileName;
               
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<DrawPoint> GetDataGelombangInXY()
        {
            var dataPoints = new List<DrawPoint>();
            if (data!=null)
            {
                for(int i=0;i<data.wavenumber.Count;i++)
                {
                    dataPoints.Add(new DrawPoint() { X= data.wavenumber[i], Y = data.absorbance[i] });
                }
            }

            return dataPoints;
        }


    }

    
    public class DrawPoint
    {
        public double X { set; get; }
        public double Y { set; get; }
      
    }
}
