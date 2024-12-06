using Microsoft.Win32;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Image_View
{
    public partial class Form1 : Form
    {
        private bool light = true;
        private float scale = 1.0f;
        private Image image;

        public Form1(string filePath = null)
        {
            InitializeComponent();
            toolStrip1.Renderer = new FixedRenderer();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.DoubleBuffered = true;

            if (!string.IsNullOrEmpty(filePath))
            {
                Image temp = Image.FromFile(filePath);
                int w = temp.Width;
                int h = temp.Height;
                toolStripLabel1.Text = $"{w} x {h}";
                if (w > 1920)
                {
                    image = new Bitmap(temp, w / (w / 1920), h / (w / 1920));
                }
                else
                {
                    image = temp;
                }
                toolStripButton4.Enabled = true;
                toolStripButton7.Enabled = true;
                pictureBox1.Image = image;
                pictureBox1.Size = new Size((int)(panel1.Width * scale), (int)(panel1.Height * scale));
            }
        }

        public class FixedRenderer : ToolStripSystemRenderer
        {
            public FixedRenderer() { }
            protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e) { }
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
                {
                    updateImage(openFileDialog.FileName);
                }
            }
        }
        private void updateImage(string path)
        {
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
                image.Dispose();
            }
            toolStripButton4.Enabled = true;
            toolStripButton7.Enabled = true;
            Image temp = Image.FromFile(path);
            Graphics g = Graphics.FromImage(temp);
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.PixelOffsetMode = PixelOffsetMode.Half;
            int w = temp.Width;
            int h = temp.Height;
            toolStripLabel1.Text = $"{w} x {h}";
            if (w > 1920)
            {
                image = new Bitmap(temp, w / (w / 1920), h / (w / 1920));
            }
            else
            {
                image = temp;
            }
            
            pictureBox1.Image = image;
            Form1.ActiveForm.WindowState = FormWindowState.Maximized;
            pictureBox1.Size = new Size((int)(panel1.Width * scale), (int)(panel1.Height * scale));
            pictureBox1.Location = new Point((panel1.Width - pictureBox1.Width) / 2, (panel1.Height - pictureBox1.Height) / 2);
        }
        private void resizeImage()
        {
            pictureBox1.Size = new Size((int)(panel1.Width * scale), (int)(panel1.Height * scale));
            toolStripLabel2.Text = Convert.ToInt16(scale * 100).ToString() + "%";
            pictureBox1.Location = new Point((panel1.Width - pictureBox1.Width) /2, (panel1.Height - pictureBox1.Height) / 2);
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

            private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (light)
            {
                Form1.ActiveForm.BackColor = Color.FromArgb(255, 25, 25, 25);
                toolStrip1.ForeColor = SystemColors.Window;
                contextMenuStrip1.BackColor = Color.FromArgb(255, 46, 46, 46);
                contextMenuStrip1.ForeColor = SystemColors.Window;
                toolStripButton2.Text = "⛯ Theme";
                light = false;
            }
            else
            {
                Form1.ActiveForm.BackColor = SystemColors.Window;
                toolStrip1.ForeColor = SystemColors.ControlText;
                contextMenuStrip1.BackColor = SystemColors.Control;
                contextMenuStrip1.ForeColor = SystemColors.ControlText;
                toolStripButton2.Text = "⛭ Theme";
                light = true;
            }
        }
        
        private void Form1_Shown(object sender, EventArgs e)
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize"))
            {
                if (key != null)
                {
                    Object o = key.GetValue("AppsUseLightTheme");
                    if (int.Parse(o.ToString()) == 0)
                    {
                        Form1.ActiveForm.BackColor = Color.FromArgb(255, 25, 25, 25);
                        toolStrip1.ForeColor = SystemColors.Window;
                        contextMenuStrip1.BackColor = Color.FromArgb(255, 46, 46, 46);
                        contextMenuStrip1.ForeColor = SystemColors.Window;
                        toolStripButton2.Text = "⛯ Theme";
                        light = false;
                    }
                }
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            panel1.AutoScroll = false;
            toolStrip1.Visible = false;
            if (pictureBox1.Image != null)
            {
                pictureBox1.Size = new Size((int)(panel1.Width * scale), (int)(panel1.Height * scale));
            }
            showBarToolStripMenuItem.Enabled = true;
        }

        private void showBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.AutoScroll = true;
            toolStrip1.Visible = true;
            if (pictureBox1.Image != null)
            {
                pictureBox1.Size = new Size((int)(panel1.Width * scale), (int)(panel1.Height * scale));
            }
            showBarToolStripMenuItem.Enabled = false;
        }

        private void panel1_Enter(object sender, EventArgs e)
        {
            panel1.Focus();
        }
       
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (scale > 0.1f)
            {
                scale -= 0.1f;
                resizeImage();
            }
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (scale < 7.9f)
            {
                scale += 0.1f;
                resizeImage();
            }
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
            if (pictureBox1.Image != null)
            {
                pictureBox1.Size = new Size((int)(panel1.Width * scale), (int)(panel1.Height * scale));
            }
        }
    }
}
