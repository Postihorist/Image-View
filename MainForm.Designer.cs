namespace Image_View
{
    partial class form
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form));
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.openButton = new System.Windows.Forms.ToolStripButton();
            this.themeButton = new System.Windows.Forms.ToolStripButton();
            this.hideButton = new System.Windows.Forms.ToolStripButton();
            this.rotateButton = new System.Windows.Forms.ToolStripButton();
            this.mirrorButton = new System.Windows.Forms.ToolStripButton();
            this.restoreButton = new System.Windows.Forms.ToolStripButton();
            this.sizeLabel = new System.Windows.Forms.ToolStripLabel();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox = new Image_View.DontBlurBox();
            this.toolStrip.SuspendLayout();
            this.contextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // openFile
            // 
            this.openFile.AutoUpgradeEnabled = false;
            // 
            // toolStrip
            // 
            this.toolStrip.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.toolStrip.AutoSize = false;
            this.toolStrip.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip.GripMargin = new System.Windows.Forms.Padding(0);
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openButton,
            this.themeButton,
            this.hideButton,
            this.rotateButton,
            this.mirrorButton,
            this.restoreButton,
            this.sizeLabel});
            this.toolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip.Location = new System.Drawing.Point(0, 335);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStrip.ShowItemToolTips = false;
            this.toolStrip.Size = new System.Drawing.Size(473, 26);
            this.toolStrip.TabIndex = 2;
            // 
            // openButton
            // 
            this.openButton.AutoSize = false;
            this.openButton.AutoToolTip = false;
            this.openButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.openButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.openButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.openButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openButton.Margin = new System.Windows.Forms.Padding(6, 2, 2, 3);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(61, 21);
            this.openButton.Text = "Open File";
            this.openButton.Click += new System.EventHandler(this.OpenButton_Click);
            // 
            // themeButton
            // 
            this.themeButton.AutoSize = false;
            this.themeButton.AutoToolTip = false;
            this.themeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.themeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.themeButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.themeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.themeButton.Margin = new System.Windows.Forms.Padding(6, 2, 2, 3);
            this.themeButton.Name = "themeButton";
            this.themeButton.Size = new System.Drawing.Size(62, 21);
            this.themeButton.Text = "⛭ Theme";
            this.themeButton.Click += new System.EventHandler(this.ThemeButton_Click);
            // 
            // hideButton
            // 
            this.hideButton.AutoSize = false;
            this.hideButton.AutoToolTip = false;
            this.hideButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.hideButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.hideButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.hideButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.hideButton.Margin = new System.Windows.Forms.Padding(6, 2, 2, 3);
            this.hideButton.Name = "hideButton";
            this.hideButton.Size = new System.Drawing.Size(56, 21);
            this.hideButton.Text = "Hide Bar";
            this.hideButton.Click += new System.EventHandler(this.HideButton_Click);
            // 
            // rotateButton
            // 
            this.rotateButton.AutoSize = false;
            this.rotateButton.AutoToolTip = false;
            this.rotateButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.rotateButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.rotateButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.rotateButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rotateButton.Margin = new System.Windows.Forms.Padding(6, 2, 2, 3);
            this.rotateButton.Name = "rotateButton";
            this.rotateButton.Size = new System.Drawing.Size(58, 21);
            this.rotateButton.Text = "↻ Rotate";
            this.rotateButton.Click += new System.EventHandler(this.RotateButton_Click);
            // 
            // mirrorButton
            // 
            this.mirrorButton.AutoSize = false;
            this.mirrorButton.AutoToolTip = false;
            this.mirrorButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mirrorButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mirrorButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mirrorButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mirrorButton.Margin = new System.Windows.Forms.Padding(6, 2, 2, 3);
            this.mirrorButton.Name = "mirrorButton";
            this.mirrorButton.Size = new System.Drawing.Size(58, 21);
            this.mirrorButton.Text = "⇄ Mirror";
            this.mirrorButton.Click += new System.EventHandler(this.MirrorButton_Click);
            // 
            // restoreButton
            // 
            this.restoreButton.AutoSize = false;
            this.restoreButton.AutoToolTip = false;
            this.restoreButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.restoreButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.restoreButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.restoreButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.restoreButton.Margin = new System.Windows.Forms.Padding(6, 2, 2, 3);
            this.restoreButton.Name = "restoreButton";
            this.restoreButton.Size = new System.Drawing.Size(50, 21);
            this.restoreButton.Text = "Restore";
            this.restoreButton.Click += new System.EventHandler(this.RestoreButton_Click);
            // 
            // sizeLabel
            // 
            this.sizeLabel.AutoSize = false;
            this.sizeLabel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.sizeLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.sizeLabel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.sizeLabel.Margin = new System.Windows.Forms.Padding(6, 2, 2, 3);
            this.sizeLabel.Name = "sizeLabel";
            this.sizeLabel.Size = new System.Drawing.Size(68, 21);
            this.sizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // contextMenu
            // 
            this.contextMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showItem});
            this.contextMenu.Name = "contextMenuStrip1";
            this.contextMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenu.ShowImageMargin = false;
            this.contextMenu.Size = new System.Drawing.Size(92, 26);
            // 
            // showItem
            // 
            this.showItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.showItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.showItem.Enabled = false;
            this.showItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showItem.Name = "showItem";
            this.showItem.ShowShortcutKeys = false;
            this.showItem.Size = new System.Drawing.Size(91, 22);
            this.showItem.Text = "Show Bar";
            this.showItem.Click += new System.EventHandler(this.ShowItem_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox.CausesValidation = false;
            this.pictureBox.ContextMenuStrip = this.contextMenu;
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.ErrorImage = null;
            this.pictureBox.InitialImage = null;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(473, 335);
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseEnter += new System.EventHandler(this.PictureBox_MouseEnter);
            // 
            // form
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(473, 361);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.toolStrip);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "form";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Monocle";
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form_DragEnter);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form_KeyPress);
            this.Resize += new System.EventHandler(this.Form_Resize);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.contextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton openButton;
        private System.Windows.Forms.ToolStripButton themeButton;
        private System.Windows.Forms.ToolStripButton hideButton;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem showItem;
        private System.Windows.Forms.ToolStripLabel sizeLabel;
        private System.Windows.Forms.ToolStripButton rotateButton;
        private DontBlurBox pictureBox;
        private System.Windows.Forms.ToolStripButton mirrorButton;
        private System.Windows.Forms.ToolStripButton restoreButton;
    }
}

