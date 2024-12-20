using Microsoft.Win32;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Image_View
{
    public partial class form : Form
    {
        private Image temp;
        [System.Runtime.InteropServices.DllImport("dwmapi.dll", PreserveSig = true)]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, int[] val, int size);
        public form(string filePath = null)
        {
            InitializeComponent();

            using (RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize"))
            {
                if (key != null)
                {
                    Object o = key.GetValue("AppsUseLightTheme");
                    if (int.Parse(o.ToString()) == 0)
                    {
                        DwmSetWindowAttribute(this.Handle, 20, new[] { 1 }, 4);
                        pictureBox.color = 0;
                    }
                }
            }
            toolStrip.Renderer = new FixedRenderer();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            if (!string.IsNullOrEmpty(filePath))
                UpdateImage(filePath);
        }
        private void UpdateImage(string path)
        {
            pictureBox.Image?.Dispose();
            temp?.Dispose();
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                temp = new Bitmap(Image.FromStream(fs));
                this.Text = $"{Path.GetFileName(path)}   {temp.Width} x {temp.Height}";
                pictureBox.Image = temp;

            }
        }
        private void Form_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
            }
        }
        private void Form_DragDrop(object sender, DragEventArgs e)
        {
            UpdateImage(((string[])e.Data.GetData(DataFormats.FileDrop))[0]);
        }
        private void Form_Shown(object sender, EventArgs e)
        {
            if (pictureBox.color == 0)
            {
                this.BackColor = Color.FromArgb(255, 25, 25, 25);
                toolStrip.ForeColor = SystemColors.Window;
                themeButton.Text = "⛯ Theme";
            }
        }
        private void OpenButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\";
                openFileDialog.Filter = "All image files (*.png;*.jpg;*.ico;*.jpeg;*.bmp;*.tiff;*.jpe;*.jfif;*.exif;*.gif)|*.png;*.jpg;*.ico;*.jpeg;*.bmp;*.tiff;*.jpe;*.jfif;*.exif|PNG (*.png)|*.png|JPG (*.jpg)|*.jpg|TIFF (*.tiff)|*.tiff|ICO (*.ico)|*.ico";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    UpdateImage(openFileDialog.FileName);
                    this.Text = $"{Path.GetFileName(openFileDialog.FileName)}   {temp.Width} x {temp.Height}";
                }
            }
        }
        private void MirrorButton_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image != null)
            {
                pictureBox.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                pictureBox.Invalidate();
            }
        }
        private void RotateButton_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image != null)
            {
                pictureBox.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                pictureBox.Invalidate();
            }
        }
        private void PictureBox_MouseEnter(object sender, EventArgs e)
        {
            pictureBox.Focus();
        }
        private void ThemeButton_Click(object sender, EventArgs e)
        {
            if (pictureBox.color == 250)
            {
                this.BackColor = Color.FromArgb(255, 25, 25, 25);
                toolStrip.ForeColor = SystemColors.Window;
                themeButton.Text = "⛯ Theme";
                pictureBox.color = 0;
            }
            else
            {
                this.BackColor = SystemColors.Window;
                toolStrip.ForeColor = SystemColors.ControlText;
                themeButton.Text = "⛭ Theme";
                pictureBox.color = 250;
            }
        }
        private void HideButton_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image != null)
            {
                toolStrip.Visible = false;
                pictureBox.Refresh();
            }
        }
        private void Form_Resize(object sender, EventArgs e)
        {
            if (pictureBox.Image == null) return;
            pictureBox.Refresh();
        }
        private void RestoreButton_Click(object sender, EventArgs e)
        {
            pictureBox.Image = temp;
        }
        void Form_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 17 && e.KeyChar <= 90)
                pictureBox.Image = temp;
        }
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (pictureBox.Image == null) return;
            if (e.Button == MouseButtons.Right)
            {
                toolStrip.Visible = true;
                pictureBox.Invalidate();
            }
        }
    }
}
