using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using OpenSURFcs;
using System.IO;

namespace OpenSURFDemo
{
    public partial class DemoSURF : Form
    {
        Bitmap img1 = null, img2 = null;

        public DemoSURF()
        {
            InitializeComponent();
        }

        private void btnOpenPic1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            if (File.Exists(openFileDialog.FileName))
                img1 = new Bitmap(openFileDialog.FileName);
        }

        //------------------------------------------------------------------------------------------------------------

        private void btnOpenPic2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            if (File.Exists(openFileDialog.FileName))
                img2 = new Bitmap(openFileDialog.FileName);

            if (img1 == null || img2 == null)
                return;

            List<IPoint> ipts1 = new List<IPoint>();//图片1的特征点
            List<IPoint> ipts2 = new List<IPoint>();//图片2的特征点

            //----------------------------------------------------------------------------------------------//
            // Create Integral Image
            IntegralImage iimg = IntegralImage.FromImage(img1);

            // Extract the interest points
            ipts1 = FastHessian.getIpoints(0.0001f, //此值越小，特征点越多
                                                                    5, 2, iimg);

            // Describe the interest points
            SurfDescriptor.DecribeInterestPoints(ipts1, false, //是否表示方向
                                                                                            false, //false为64，true为128
                                                                                            iimg);
            //----------------------------------------------------------------------------------------------//
            // Create Integral Image
            iimg = IntegralImage.FromImage(img2);

            // Extract the interest points
            ipts2 = FastHessian.getIpoints(0.0001f, 5, 2, iimg);

            // Describe the interest points
            SurfDescriptor.DecribeInterestPoints(ipts2, false, false, iimg);

            List<IPoint>[] matches = Utils.getMatches(ipts1, ipts2);
            PaintSURF(img1,img2, matches);
        }
        // DemoApp


        private void PaintSURF(Bitmap img1, Bitmap img2, List<IPoint>[] matches)
        {
            Bitmap bmp = new Bitmap(img1.Width + img2.Width, Math.Max(img1.Height, img2.Height));

            Graphics g = Graphics.FromImage(bmp);
            g.DrawImage(img1, 0, 0,img1.Width,img1.Height);
            g.DrawImage(img2, img1.Width, 0,img2.Width,img2.Height);

            Pen redPen = new Pen(Color.Red);
            Pen bluePen = new Pen(Color.Blue);
            Pen whitePen = new Pen(Color.Black);
            Pen myPen;

            int x = 0;
            //画出特征点和方向
            for (int i = 0; i < matches.Length;i++ )
            {
                foreach (IPoint ip in matches[i])
                {
                    int S = 2 * Convert.ToInt32(2.5f * ip.scale);
                    int R = Convert.ToInt32(S / 2f);

                    Point pt = new Point(Convert.ToInt32(ip.x), Convert.ToInt32(ip.y));
                    Point ptR = new Point(Convert.ToInt32(R * Math.Cos(ip.orientation)),
                                 Convert.ToInt32(R * Math.Sin(ip.orientation)));

                    myPen = (ip.laplacian > 0 ? bluePen : redPen);

                    g.DrawEllipse(myPen, x+pt.X - R, pt.Y - R, S, S);
                    g.DrawLine(new Pen(Color.FromArgb(0, 255, 0)), new Point(x + pt.X, pt.Y), new Point(x + pt.X + ptR.X, pt.Y + ptR.Y));
                }
                x += img1.Width;
            }
            //连接匹配的特征点
            for (int i = 0; i < matches[0].Count; i++)
            {
                Point pt1 = new Point(Convert.ToInt32(matches[0][i].x), Convert.ToInt32(matches[0][i].y));
                Point pt2 = new Point(img1.Width + Convert.ToInt32(matches[1][i].x), Convert.ToInt32(matches[1][i].y));
                g.DrawLine(whitePen, pt1, pt2);
            }
            g.Dispose();

            this.pictureBox1.Image = bmp;
        }
    }
} // OpenSURFDemo
