using System;
using System.Drawing;
using System.Windows.Forms;

namespace Image_View
{
    public partial class DontBlurBox : PictureBox
    {
        public int color = 0;
        private bool isDown = false;
        public Point p1;
        public Point p2;
        private Rectangle result;
        private double num;
        public DontBlurBox()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.ResizeRedraw | ControlStyles.StandardClick | ControlStyles.StandardDoubleClick, false);
            MouseDown += PictureBox_MouseDown;
            MouseUp += PictureBox_MouseUp;
            MouseMove += PictureBox_MouseMove;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            if (Image != null)
            {
                Size size = Image.Size;
                num = Math.Min((double)Width / (double)size.Width, (double)Height / (double)size.Height);
                result.Width = (int)((double)size.Width * num);
                result.Height = (int)((double)size.Height * num);
                result.X = ((Width - result.Width) / 2);
                result.Y = ((Height - result.Height) / 2);
                e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
                e.Graphics.DrawImage(Image, result);
                if (isDown)
                {
                    Pen pen = new Pen(Color.FromArgb(color, color, color), 2)
                    {
                        DashStyle = System.Drawing.Drawing2D.DashStyle.Dash
                    };
                    Rectangle rectangle = new Rectangle(Math.Min(p1.X, p2.X), Math.Min(p1.Y, p2.Y), Math.Abs(p1.X - p2.X), Math.Abs(p1.Y - p2.Y));

                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(55, color, color, color)), rectangle);
                    e.Graphics.DrawRectangle(pen, rectangle);
                }
            }
        }
        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (Image == null) return;
            p1 = Point.Empty;
            p2 = Point.Empty;
            if (e.Button == MouseButtons.Left && Image.Width > 6 && Image.Height > 6)
            {
                int right = result.X + result.Width;
                int down = result.Y + result.Height;
                if (e.X < result.X)
                    p1.X = result.X;
                else if (e.X > right)
                    p1.X = right;
                else
                    p1.X = e.X;
                if (e.Y < result.Y)
                    p1.Y = result.Y;
                else if (e.Y > down)
                    p1.Y = down;
                else
                    p1.Y = e.Y;
                isDown = true;
                Cursor.Current = Cursors.Hand;
            }
        }
        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (Image == null) return;
            if (isDown)
            {
                int right = result.X + result.Width;
                int down = result.Y + result.Height;
                if (e.X < result.X)
                    p2.X = result.X;
                else if (e.X > right)
                    p2.X = right;
                else
                    p2.X = e.X;
                if (e.Y < result.Y)
                    p2.Y = result.Y;
                else if (e.Y > down)
                    p2.Y = down;
                else
                    p2.Y = e.Y;
                Invalidate();
            }
        }
        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (Image == null) return;
            if (e.Button == MouseButtons.Left)
            {
                Cursor.Current = Cursors.Default;
                isDown = false;
                if (!p2.IsEmpty)
                {
                    int w = Math.Abs(p1.X - p2.X);
                    int h = Math.Abs(p1.Y - p2.Y);
                    if (w > 20 && h > 20 && (w != result.Width || h != result.Height))
                        Image = Crop((Bitmap)Image);
                    else
                        Invalidate();
                }
                else
                    Invalidate();
            }
        }
        private Bitmap Crop(Bitmap b)
        {
            double X1 = p1.X;
            double Y1 = p1.Y;
            double X2 = p2.X;
            double Y2 = p2.Y;
            if (Width > result.Width)
            {
                double blank = (Width - result.Width) / 2;
                X1 -= blank;
                X2 -= blank;
            }
            if (Height > result.Height)
            {
                double blank = (Height - result.Height) / 2;
                Y1 -= blank;
                Y2 -= blank;
            }
            X1 /= num;
            Y1 /= num;
            X2 /= num;
            Y2 /= num;
            Rectangle rectangle = new Rectangle((int)Math.Min(X1, X2), (int)Math.Min(Y1, Y2), (int)Math.Abs(X1 - X2) + 1, (int)Math.Abs(Y1 - Y2) + 1);
            Bitmap bmpCrop = b.Clone(rectangle, b.PixelFormat);
            return bmpCrop;
        }
    }
}
