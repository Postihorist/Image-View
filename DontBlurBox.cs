using System.Drawing;
using System.Windows.Forms;

namespace Image_View
{
    public partial class DontBlurBox : PictureBox 
    {
        public DontBlurBox()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            Location = Point.Empty;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.None;
            base.OnPaint(e);
        }
        public void Unzoom()
        {
            if (Image == null) return;
            Size = Parent.Size;
            Location = Point.Empty;
        }
    }
    public class FastPanel : Panel
    {
        public FastPanel()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
        }
    }
}
