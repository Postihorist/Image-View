using Microsoft.Win32;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Image_View
{
    public partial class Form1 : Form
    {
        private bool light = true;
        private double scale = 1;
        private Point p1 = new Point();
        private Point p2 = new Point();
        public Form1(string filePath = null)
        {
            InitializeComponent();
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize"))
            {
                if (key != null)
                {
                    Object o = key.GetValue("AppsUseLightTheme");
                    if (int.Parse(o.ToString()) == 0)
                        light = false;
                }
            }
            toolStrip1.Renderer = new FixedRenderer();
            pictureBox1.MouseWheel += PictureBox_MouseWheel;
            pictureBox1.MouseDown += PictureBox_MouseDown;
            pictureBox1.MouseUp += PictureBox_MouseUp;
            pictureBox1.MouseMove += PictureBox_MouseMove;
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            if (!string.IsNullOrEmpty(filePath))
            {
                updateImage(filePath);
            } 
        }
        private void updateImage(string path)
        {
            pictureBox1.Image?.Dispose();
            toolStripButton4.Enabled = true;
            toolStripButton7.Enabled = true;
            toolStripLabel2.Text = "100%";
            scale = 1;
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                Image temp = Image.FromStream(fs);
                int w = temp.Width;
                int h = temp.Height;
                toolStripLabel1.Text = $"{w} x {h}";
                if (Math.Max(h, w) > 1920)
                {
                    temp = new Bitmap(temp, w / (w / 1920), h / (w / 1920));
                }
                pictureBox1.Image = temp;
            }
            pictureBox1.Unzoom();
        }
        private void sizeImage()
        { 
            pictureBox1.Size = new Size((int)(panel1.Width * scale), (int)(panel1.Height * scale));
            toolStripLabel2.Text = Convert.ToInt16(scale * 100).ToString() + "%";
        }
        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Image == null) return;
            if (e.Button == MouseButtons.Left)
            {
                int x = p2.X + (MousePosition.X - p1.X);
                int y = p2.Y + (MousePosition.Y - p1.Y);
                //if (x < 0 && x > panel1.Width - pictureBox1.Width) pictureBox1.Left = x;
                //if (y < 0 && y > panel1.Height - pictureBox1.Height) pictureBox1.Top = y;
                pictureBox1.Location = new Point(x, y);
            }
        }
        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Image == null) return;
            if (e.Button == MouseButtons.Left)
            {
                Cursor.Current = Cursors.Default;
            }
        }
        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Image == null) return;
            if (e.Button == MouseButtons.Left)
            {
                Cursor.Current = Cursors.Hand;
                p1 = MousePosition;
                p2 = pictureBox1.Location;
            }
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null) return;
            pictureBox1.Unzoom();
        }
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
            }
        }
        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            updateImage(((string[])e.Data.GetData(DataFormats.FileDrop))[0]);
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            if (!light)
            {
                ActiveForm.BackColor = Color.FromArgb(255, 25, 25, 25);
                toolStrip1.ForeColor = SystemColors.Window;
                contextMenuStrip1.BackColor = Color.FromArgb(255, 46, 46, 46);
                contextMenuStrip1.ForeColor = SystemColors.Window;
                toolStripButton2.Text = "⛯ Theme";
            }
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\";
                openFileDialog.Filter = "All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                    updateImage(openFileDialog.FileName);
            }
        }
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                toolStrip1.Visible = false;
                sizeImage();
                showBarToolStripMenuItem.Enabled = true;
            }
        }
        private void showBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip1.Visible = true;
            sizeImage();
            showBarToolStripMenuItem.Enabled = false;
        }
       
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (light)
            {
                ActiveForm.BackColor = Color.FromArgb(255, 25, 25, 25);
                toolStrip1.ForeColor = SystemColors.Window;
                contextMenuStrip1.BackColor = Color.FromArgb(255, 46, 46, 46);
                contextMenuStrip1.ForeColor = SystemColors.Window;
                toolStripButton2.Text = "⛯ Theme";
                light = false;
            }
            else
            {
                ActiveForm.BackColor = SystemColors.Window;
                toolStrip1.ForeColor = SystemColors.ControlText;
                contextMenuStrip1.BackColor = SystemColors.Control;
                contextMenuStrip1.ForeColor = SystemColors.ControlText;
                toolStripButton2.Text = "⛭ Theme";
                light = true;
            }
        }
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Focus();
        }
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                pictureBox1.Invalidate();
            }
        }
        private void PictureBox_MouseWheel(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Image == null) return;
            int x = e.Location.X;
            int y = e.Location.Y;
            int ow = pictureBox1.Width;
            int oh = pictureBox1.Height;
            int VX, VY;
            if (e.Delta > 0)
            {
                if (scale < 6.9)
                {
                    scale += 0.2;
                }
            }
            else if (scale > 1)
                scale -= 0.2;
            sizeImage();
            //ActiveForm.Text = $"{scale} {pictureBox1.Size} {pictureBox1.Image.Size}";
            VX = pictureBox1.Location.X + (int)((double)x * (ow - pictureBox1.Width) / ow);
            VY = pictureBox1.Location.Y + (int)((double)y * (oh - pictureBox1.Height) / oh);
            pictureBox1.Location = new Point(VX, VY);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (scale > 1)
            {
                scale -= 0.1;
                sizeImage();
            }
        }
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (scale < 6.9)
            {
                scale += 0.1;
                sizeImage();
            }
        }
    }
}
