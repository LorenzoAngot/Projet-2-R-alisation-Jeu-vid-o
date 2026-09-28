namespace Interface1
{
    partial class Parametre
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
            grpDifficulte = new GroupBox();
            picDifficulte = new PictureBox();
            rdoDifficile = new RadioButton();
            rdoMoyen = new RadioButton();
            rdoFacile = new RadioButton();
            grpTouches = new GroupBox();
            picTouches = new PictureBox();
            rdoZQSD = new RadioButton();
            rdoFleches = new RadioButton();
            grpVolume = new GroupBox();
            picVolume = new PictureBox();
            lblNbVolume = new Label();
            trkVolume = new TrackBar();
            grpPseudo = new GroupBox();
            picPseudo = new PictureBox();
            txbPseudo = new TextBox();
            picParam = new PictureBox();
            picDB = new PictureBox();
            picRetour = new PictureBox();
            picJouer = new PictureBox();
            grpDifficulte.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picDifficulte).BeginInit();
            grpTouches.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picTouches).BeginInit();
            grpVolume.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picVolume).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trkVolume).BeginInit();
            grpPseudo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picPseudo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picParam).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picDB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picRetour).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picJouer).BeginInit();
            SuspendLayout();
            // 
            // grpDifficulte
            // 
            grpDifficulte.BackColor = Color.Transparent;
            grpDifficulte.Controls.Add(picDifficulte);
            grpDifficulte.Controls.Add(rdoDifficile);
            grpDifficulte.Controls.Add(rdoMoyen);
            grpDifficulte.Controls.Add(rdoFacile);
            grpDifficulte.FlatStyle = FlatStyle.Flat;
            grpDifficulte.Location = new Point(64, 301);
            grpDifficulte.Margin = new Padding(3, 4, 3, 4);
            grpDifficulte.Name = "grpDifficulte";
            grpDifficulte.Padding = new Padding(3, 4, 3, 4);
            grpDifficulte.Size = new Size(592, 112);
            grpDifficulte.TabIndex = 2;
            grpDifficulte.TabStop = false;
            // 
            // picDifficulte
            // 
            picDifficulte.BackColor = Color.Transparent;
            picDifficulte.Image = Properties.Resources.difficulte;
            picDifficulte.Location = new Point(6, 27);
            picDifficulte.Name = "picDifficulte";
            picDifficulte.Size = new Size(283, 77);
            picDifficulte.SizeMode = PictureBoxSizeMode.StretchImage;
            picDifficulte.TabIndex = 11;
            picDifficulte.TabStop = false;
            // 
            // rdoDifficile
            // 
            rdoDifficile.Appearance = Appearance.Button;
            rdoDifficile.AutoSize = true;
            rdoDifficile.Location = new Point(493, 51);
            rdoDifficile.Margin = new Padding(3, 4, 3, 4);
            rdoDifficile.Name = "rdoDifficile";
            rdoDifficile.Size = new Size(71, 30);
            rdoDifficile.TabIndex = 5;
            rdoDifficile.Text = "Difficile";
            rdoDifficile.UseVisualStyleBackColor = true;
            rdoDifficile.CheckedChanged += rdo_CheckedChanged;
            // 
            // rdoMoyen
            // 
            rdoMoyen.Appearance = Appearance.Button;
            rdoMoyen.AutoSize = true;
            rdoMoyen.Location = new Point(399, 51);
            rdoMoyen.Margin = new Padding(3, 4, 3, 4);
            rdoMoyen.Name = "rdoMoyen";
            rdoMoyen.Size = new Size(64, 30);
            rdoMoyen.TabIndex = 4;
            rdoMoyen.Text = "Moyen";
            rdoMoyen.UseVisualStyleBackColor = true;
            rdoMoyen.CheckedChanged += rdo_CheckedChanged;
            // 
            // rdoFacile
            // 
            rdoFacile.Appearance = Appearance.Button;
            rdoFacile.AutoSize = true;
            rdoFacile.Location = new Point(311, 51);
            rdoFacile.Margin = new Padding(3, 4, 3, 4);
            rdoFacile.Name = "rdoFacile";
            rdoFacile.Size = new Size(56, 30);
            rdoFacile.TabIndex = 3;
            rdoFacile.Text = "Facile";
            rdoFacile.UseVisualStyleBackColor = true;
            rdoFacile.CheckedChanged += rdo_CheckedChanged;
            // 
            // grpTouches
            // 
            grpTouches.BackColor = Color.Transparent;
            grpTouches.Controls.Add(picTouches);
            grpTouches.Controls.Add(rdoZQSD);
            grpTouches.Controls.Add(rdoFleches);
            grpTouches.Location = new Point(64, 436);
            grpTouches.Margin = new Padding(3, 4, 3, 4);
            grpTouches.Name = "grpTouches";
            grpTouches.Padding = new Padding(3, 4, 3, 4);
            grpTouches.Size = new Size(592, 103);
            grpTouches.TabIndex = 5;
            grpTouches.TabStop = false;
            // 
            // picTouches
            // 
            picTouches.BackColor = Color.Transparent;
            picTouches.Image = Properties.Resources.touches;
            picTouches.Location = new Point(6, 21);
            picTouches.Name = "picTouches";
            picTouches.Size = new Size(283, 69);
            picTouches.SizeMode = PictureBoxSizeMode.StretchImage;
            picTouches.TabIndex = 11;
            picTouches.TabStop = false;
            // 
            // rdoZQSD
            // 
            rdoZQSD.Appearance = Appearance.Button;
            rdoZQSD.AutoSize = true;
            rdoZQSD.Location = new Point(470, 43);
            rdoZQSD.Margin = new Padding(3, 4, 3, 4);
            rdoZQSD.Name = "rdoZQSD";
            rdoZQSD.Size = new Size(58, 30);
            rdoZQSD.TabIndex = 7;
            rdoZQSD.Text = "ZQSD";
            rdoZQSD.UseVisualStyleBackColor = true;
            rdoZQSD.CheckedChanged += rdo_CheckedChanged;
            // 
            // rdoFleches
            // 
            rdoFleches.Appearance = Appearance.Button;
            rdoFleches.AutoSize = true;
            rdoFleches.Location = new Point(334, 43);
            rdoFleches.Margin = new Padding(3, 4, 3, 4);
            rdoFleches.Name = "rdoFleches";
            rdoFleches.Size = new Size(67, 30);
            rdoFleches.TabIndex = 6;
            rdoFleches.Text = "Flèches";
            rdoFleches.UseVisualStyleBackColor = true;
            rdoFleches.CheckedChanged += rdo_CheckedChanged;
            // 
            // grpVolume
            // 
            grpVolume.BackColor = Color.Transparent;
            grpVolume.Controls.Add(picVolume);
            grpVolume.Controls.Add(lblNbVolume);
            grpVolume.Controls.Add(trkVolume);
            grpVolume.Location = new Point(64, 557);
            grpVolume.Margin = new Padding(3, 4, 3, 4);
            grpVolume.Name = "grpVolume";
            grpVolume.Padding = new Padding(3, 4, 3, 4);
            grpVolume.Size = new Size(592, 108);
            grpVolume.TabIndex = 6;
            grpVolume.TabStop = false;
            // 
            // picVolume
            // 
            picVolume.BackColor = Color.Transparent;
            picVolume.Image = Properties.Resources.volume;
            picVolume.Location = new Point(6, 21);
            picVolume.Name = "picVolume";
            picVolume.Size = new Size(283, 71);
            picVolume.SizeMode = PictureBoxSizeMode.StretchImage;
            picVolume.TabIndex = 11;
            picVolume.TabStop = false;
            // 
            // lblNbVolume
            // 
            lblNbVolume.AutoSize = true;
            lblNbVolume.Location = new Point(549, 45);
            lblNbVolume.Name = "lblNbVolume";
            lblNbVolume.Size = new Size(25, 20);
            lblNbVolume.TabIndex = 8;
            lblNbVolume.Text = "50";
            // 
            // trkVolume
            // 
            trkVolume.BackColor = Color.White;
            trkVolume.Cursor = Cursors.Hand;
            trkVolume.Location = new Point(325, 28);
            trkVolume.Margin = new Padding(3, 4, 3, 4);
            trkVolume.Maximum = 100;
            trkVolume.Name = "trkVolume";
            trkVolume.Size = new Size(217, 56);
            trkVolume.TabIndex = 8;
            trkVolume.TickFrequency = 10;
            trkVolume.Value = 50;
            trkVolume.Scroll += trkVolume_Scroll;
            // 
            // grpPseudo
            // 
            grpPseudo.BackColor = Color.Transparent;
            grpPseudo.BackgroundImageLayout = ImageLayout.None;
            grpPseudo.Controls.Add(picPseudo);
            grpPseudo.Controls.Add(txbPseudo);
            grpPseudo.FlatStyle = FlatStyle.Flat;
            grpPseudo.Location = new Point(64, 189);
            grpPseudo.Margin = new Padding(3, 4, 3, 4);
            grpPseudo.Name = "grpPseudo";
            grpPseudo.Padding = new Padding(3, 4, 3, 4);
            grpPseudo.Size = new Size(592, 104);
            grpPseudo.TabIndex = 8;
            grpPseudo.TabStop = false;
            // 
            // picPseudo
            // 
            picPseudo.BackColor = Color.Transparent;
            picPseudo.Image = Properties.Resources.pseudo;
            picPseudo.Location = new Point(6, 27);
            picPseudo.Name = "picPseudo";
            picPseudo.Size = new Size(290, 69);
            picPseudo.SizeMode = PictureBoxSizeMode.StretchImage;
            picPseudo.TabIndex = 10;
            picPseudo.TabStop = false;
            // 
            // txbPseudo
            // 
            txbPseudo.Location = new Point(334, 45);
            txbPseudo.Margin = new Padding(3, 4, 3, 4);
            txbPseudo.Name = "txbPseudo";
            txbPseudo.Size = new Size(230, 27);
            txbPseudo.TabIndex = 2;
            txbPseudo.Text = "Joueur1";
            // 
            // picParam
            // 
            picParam.BackColor = Color.Transparent;
            picParam.Image = Properties.Resources.titre_2;
            picParam.Location = new Point(103, 12);
            picParam.Name = "picParam";
            picParam.Size = new Size(591, 96);
            picParam.SizeMode = PictureBoxSizeMode.StretchImage;
            picParam.TabIndex = 9;
            picParam.TabStop = false;
            // 
            // picDB
            // 
            picDB.BackColor = Color.Transparent;
            picDB.Image = Properties.Resources.dragon_ball;
            picDB.Location = new Point(27, 27);
            picDB.Name = "picDB";
            picDB.Size = new Size(69, 68);
            picDB.SizeMode = PictureBoxSizeMode.StretchImage;
            picDB.TabIndex = 12;
            picDB.TabStop = false;
            // 
            // picRetour
            // 
            picRetour.BackColor = Color.Transparent;
            picRetour.Cursor = Cursors.Hand;
            picRetour.Image = Properties.Resources.retour;
            picRetour.Location = new Point(14, 697);
            picRetour.Margin = new Padding(3, 4, 3, 4);
            picRetour.Name = "picRetour";
            picRetour.Size = new Size(162, 67);
            picRetour.SizeMode = PictureBoxSizeMode.StretchImage;
            picRetour.TabIndex = 14;
            picRetour.TabStop = false;
            picRetour.Click += pictureBox7_Click;
            // 
            // picJouer
            // 
            picJouer.BackColor = Color.Transparent;
            picJouer.Cursor = Cursors.Hand;
            picJouer.Image = Properties.Resources.jouer;
            picJouer.Location = new Point(599, 697);
            picJouer.Margin = new Padding(3, 4, 3, 4);
            picJouer.Name = "picJouer";
            picJouer.Size = new Size(151, 67);
            picJouer.SizeMode = PictureBoxSizeMode.StretchImage;
            picJouer.TabIndex = 15;
            picJouer.TabStop = false;
            picJouer.Click += pictureBox8_Click;
            // 
            // Parametre
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.pla_kaio_shin;
            ClientSize = new Size(763, 780);
            Controls.Add(picJouer);
            Controls.Add(picRetour);
            Controls.Add(picDB);
            Controls.Add(picParam);
            Controls.Add(grpVolume);
            Controls.Add(grpTouches);
            Controls.Add(grpDifficulte);
            Controls.Add(grpPseudo);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Parametre";
            Text = "Fukushu No Yume";
            FormClosing += Parametre_FormClosing;
            grpDifficulte.ResumeLayout(false);
            grpDifficulte.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picDifficulte).EndInit();
            grpTouches.ResumeLayout(false);
            grpTouches.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picTouches).EndInit();
            grpVolume.ResumeLayout(false);
            grpVolume.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picVolume).EndInit();
            ((System.ComponentModel.ISupportInitialize)trkVolume).EndInit();
            grpPseudo.ResumeLayout(false);
            grpPseudo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picPseudo).EndInit();
            ((System.ComponentModel.ISupportInitialize)picParam).EndInit();
            ((System.ComponentModel.ISupportInitialize)picDB).EndInit();
            ((System.ComponentModel.ISupportInitialize)picRetour).EndInit();
            ((System.ComponentModel.ISupportInitialize)picJouer).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox grpDifficulte;
        private RadioButton rdoDifficile;
        private RadioButton rdoMoyen;
        private RadioButton rdoFacile;
        private GroupBox grpTouches;
        private RadioButton rdoZQSD;
        private RadioButton rdoFleches;
        private GroupBox grpVolume;
        private TrackBar trkVolume;
        private Label lblNbVolume;
        private GroupBox grpPseudo;
        private TextBox txbPseudo;
        private PictureBox picParam;
        private PictureBox picDifficulte;
        private PictureBox picTouches;
        private PictureBox picPseudo;
        private PictureBox picVolume;
        private PictureBox picDB;
        private PictureBox picRetour;
        private PictureBox picJouer;
    }
}