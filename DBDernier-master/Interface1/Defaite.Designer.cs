namespace Interface1
{
    partial class Defaite
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            picDefaite = new PictureBox();
            picMenu = new PictureBox();
            picBureau = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)picDefaite).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picMenu).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picBureau).BeginInit();
            SuspendLayout();
            // 
            // picDefaite
            // 
            picDefaite.BackColor = Color.Transparent;
            picDefaite.Image = Properties.Resources.defaite;
            picDefaite.Location = new Point(33, 41);
            picDefaite.Name = "picDefaite";
            picDefaite.Size = new Size(253, 72);
            picDefaite.SizeMode = PictureBoxSizeMode.StretchImage;
            picDefaite.TabIndex = 3;
            picDefaite.TabStop = false;
            // 
            // picMenu
            // 
            picMenu.BackColor = Color.Transparent;
            picMenu.Cursor = Cursors.Hand;
            picMenu.Image = Properties.Resources.menu;
            picMenu.Location = new Point(3, 160);
            picMenu.Name = "picMenu";
            picMenu.Size = new Size(130, 50);
            picMenu.SizeMode = PictureBoxSizeMode.StretchImage;
            picMenu.TabIndex = 4;
            picMenu.TabStop = false;
            picMenu.Click += pictureBox2_Click;
            // 
            // picBureau
            // 
            picBureau.BackColor = Color.Transparent;
            picBureau.Cursor = Cursors.Hand;
            picBureau.Image = Properties.Resources.bureau;
            picBureau.Location = new Point(174, 160);
            picBureau.Name = "picBureau";
            picBureau.Size = new Size(145, 50);
            picBureau.SizeMode = PictureBoxSizeMode.StretchImage;
            picBureau.TabIndex = 5;
            picBureau.TabStop = false;
            picBureau.Click += pictureBox3_Click;
            // 
            // Defaite
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fond_défaite;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(331, 222);
            Controls.Add(picBureau);
            Controls.Add(picMenu);
            Controls.Add(picDefaite);
            Name = "Defaite";
            Text = "Defaite";
            FormClosing += Defaite_FormClosing;
            ((System.ComponentModel.ISupportInitialize)picDefaite).EndInit();
            ((System.ComponentModel.ISupportInitialize)picMenu).EndInit();
            ((System.ComponentModel.ISupportInitialize)picBureau).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private PictureBox picDefaite;
        private PictureBox picMenu;
        private PictureBox picBureau;
    }
}