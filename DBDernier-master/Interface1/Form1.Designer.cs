namespace Interface1
{
    partial class Accueil
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            picTitre = new PictureBox();
            picJouer = new PictureBox();
            picDB1 = new PictureBox();
            picClassement = new PictureBox();
            picNomJeu = new PictureBox();
            picDB2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)picTitre).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picJouer).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picDB1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picClassement).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picNomJeu).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picDB2).BeginInit();
            SuspendLayout();
            // 
            // picTitre
            // 
            picTitre.BackColor = Color.Transparent;
            picTitre.Image = Properties.Resources.titre__pas_celui_du_jeu_;
            picTitre.Location = new Point(183, 9);
            picTitre.Margin = new Padding(3, 2, 3, 2);
            picTitre.Name = "picTitre";
            picTitre.Size = new Size(479, 94);
            picTitre.SizeMode = PictureBoxSizeMode.StretchImage;
            picTitre.TabIndex = 1;
            picTitre.TabStop = false;
            // 
            // picJouer
            // 
            picJouer.BackColor = Color.Transparent;
            picJouer.Cursor = Cursors.Hand;
            picJouer.Image = Properties.Resources.titre1;
            picJouer.Location = new Point(174, 223);
            picJouer.Margin = new Padding(3, 2, 3, 2);
            picJouer.Name = "picJouer";
            picJouer.Size = new Size(478, 52);
            picJouer.SizeMode = PictureBoxSizeMode.StretchImage;
            picJouer.TabIndex = 2;
            picJouer.TabStop = false;
            picJouer.Click += pictureBox2_Click;
            // 
            // picDB1
            // 
            picDB1.BackColor = Color.Transparent;
            picDB1.Image = Properties.Resources.dragon_ball;
            picDB1.Location = new Point(69, 223);
            picDB1.Margin = new Padding(3, 2, 3, 2);
            picDB1.Name = "picDB1";
            picDB1.Size = new Size(65, 46);
            picDB1.SizeMode = PictureBoxSizeMode.StretchImage;
            picDB1.TabIndex = 3;
            picDB1.TabStop = false;
            // 
            // picClassement
            // 
            picClassement.BackColor = Color.Transparent;
            picClassement.Cursor = Cursors.Hand;
            picClassement.Image = Properties.Resources.classement;
            picClassement.Location = new Point(174, 296);
            picClassement.Margin = new Padding(3, 2, 3, 2);
            picClassement.Name = "picClassement";
            picClassement.Size = new Size(478, 57);
            picClassement.SizeMode = PictureBoxSizeMode.StretchImage;
            picClassement.TabIndex = 4;
            picClassement.TabStop = false;
            picClassement.Click += pictureBox4_Click;
            // 
            // picNomJeu
            // 
            picNomJeu.BackColor = Color.Transparent;
            picNomJeu.Image = Properties.Resources.titre_jeu;
            picNomJeu.Location = new Point(160, 107);
            picNomJeu.Margin = new Padding(3, 2, 3, 2);
            picNomJeu.Name = "picNomJeu";
            picNomJeu.Size = new Size(523, 52);
            picNomJeu.SizeMode = PictureBoxSizeMode.StretchImage;
            picNomJeu.TabIndex = 5;
            picNomJeu.TabStop = false;
            // 
            // picDB2
            // 
            picDB2.BackColor = Color.Transparent;
            picDB2.Image = Properties.Resources.dragon_ball;
            picDB2.Location = new Point(69, 300);
            picDB2.Margin = new Padding(3, 2, 3, 2);
            picDB2.Name = "picDB2";
            picDB2.Size = new Size(65, 46);
            picDB2.SizeMode = PictureBoxSizeMode.StretchImage;
            picDB2.TabIndex = 6;
            picDB2.TabStop = false;
            // 
            // Accueil
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.pla_kaio_shin;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(picDB2);
            Controls.Add(picNomJeu);
            Controls.Add(picClassement);
            Controls.Add(picDB1);
            Controls.Add(picJouer);
            Controls.Add(picTitre);
            Name = "Accueil";
            Text = "Fukushu No Yume";
            FormClosing += Accueil_FormClosing;
            VisibleChanged += Accueil_VisibleChanged;
            ((System.ComponentModel.ISupportInitialize)picTitre).EndInit();
            ((System.ComponentModel.ISupportInitialize)picJouer).EndInit();
            ((System.ComponentModel.ISupportInitialize)picDB1).EndInit();
            ((System.ComponentModel.ISupportInitialize)picClassement).EndInit();
            ((System.ComponentModel.ISupportInitialize)picNomJeu).EndInit();
            ((System.ComponentModel.ISupportInitialize)picDB2).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private PictureBox picTitre;
        private PictureBox picJouer;
        private PictureBox picDB1;
        private PictureBox picClassement;
        private PictureBox picNomJeu;
        private PictureBox picDB2;
    }
}
