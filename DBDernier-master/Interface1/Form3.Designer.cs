namespace Interface1
{
    partial class Jeu
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Jeu));
            lblNbScore = new Label();
            lblNbDb = new Label();
            lblTempsBoost = new Label();
            picVie1 = new PictureBox();
            picVie2 = new PictureBox();
            picVie3 = new PictureBox();
            tmrBoost = new System.Windows.Forms.Timer(components);
            picBoost = new PictureBox();
            grbJeu = new GroupBox();
            lblNbNiveau = new Label();
            picDB = new PictureBox();
            tmrEnnemis = new System.Windows.Forms.Timer(components);
            picFreezer = new PictureBox();
            pcbCell = new PictureBox();
            picVegeta = new PictureBox();
            picBuu = new PictureBox();
            picEtourdit = new PictureBox();
            tmrAttaque = new System.Windows.Forms.Timer(components);
            picPause = new PictureBox();
            picScore = new PictureBox();
            picNiveau = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)picVie1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picVie2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picVie3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picBoost).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picDB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picFreezer).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcbCell).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picVegeta).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picBuu).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picEtourdit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picPause).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picScore).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picNiveau).BeginInit();
            SuspendLayout();
            // 
            // lblNbScore
            // 
            lblNbScore.AutoSize = true;
            lblNbScore.BackColor = Color.Transparent;
            lblNbScore.Location = new Point(415, 43);
            lblNbScore.Name = "lblNbScore";
            lblNbScore.Size = new Size(17, 20);
            lblNbScore.TabIndex = 3;
            lblNbScore.Text = "0";
            // 
            // lblNbDb
            // 
            lblNbDb.AutoSize = true;
            lblNbDb.BackColor = Color.Transparent;
            lblNbDb.Location = new Point(549, 43);
            lblNbDb.Name = "lblNbDb";
            lblNbDb.Size = new Size(17, 20);
            lblNbDb.TabIndex = 4;
            lblNbDb.Text = "0";
            // 
            // lblTempsBoost
            // 
            lblTempsBoost.AutoSize = true;
            lblTempsBoost.BackColor = Color.Transparent;
            lblTempsBoost.Location = new Point(647, 43);
            lblTempsBoost.Name = "lblTempsBoost";
            lblTempsBoost.Size = new Size(17, 20);
            lblTempsBoost.TabIndex = 5;
            lblTempsBoost.Text = "0";
            // 
            // picVie1
            // 
            picVie1.BackColor = Color.Transparent;
            picVie1.Image = (Image)resources.GetObject("picVie1.Image");
            picVie1.Location = new Point(683, 28);
            picVie1.Margin = new Padding(3, 4, 3, 4);
            picVie1.Name = "picVie1";
            picVie1.Size = new Size(98, 59);
            picVie1.SizeMode = PictureBoxSizeMode.StretchImage;
            picVie1.TabIndex = 7;
            picVie1.TabStop = false;
            // 
            // picVie2
            // 
            picVie2.BackColor = Color.Transparent;
            picVie2.Image = (Image)resources.GetObject("picVie2.Image");
            picVie2.Location = new Point(795, 28);
            picVie2.Margin = new Padding(3, 4, 3, 4);
            picVie2.Name = "picVie2";
            picVie2.Size = new Size(89, 59);
            picVie2.SizeMode = PictureBoxSizeMode.StretchImage;
            picVie2.TabIndex = 8;
            picVie2.TabStop = false;
            // 
            // picVie3
            // 
            picVie3.BackColor = Color.Transparent;
            picVie3.Image = (Image)resources.GetObject("picVie3.Image");
            picVie3.Location = new Point(896, 28);
            picVie3.Margin = new Padding(3, 4, 3, 4);
            picVie3.Name = "picVie3";
            picVie3.Size = new Size(89, 59);
            picVie3.SizeMode = PictureBoxSizeMode.StretchImage;
            picVie3.TabIndex = 9;
            picVie3.TabStop = false;
            // 
            // tmrBoost
            // 
            tmrBoost.Interval = 1000;
            tmrBoost.Tick += timer1_Tick;
            // 
            // picBoost
            // 
            picBoost.BackColor = Color.Transparent;
            picBoost.Location = new Point(576, 20);
            picBoost.Margin = new Padding(3, 4, 3, 4);
            picBoost.Name = "picBoost";
            picBoost.Size = new Size(65, 63);
            picBoost.SizeMode = PictureBoxSizeMode.StretchImage;
            picBoost.TabIndex = 12;
            picBoost.TabStop = false;
            picBoost.Visible = false;
            // 
            // grbJeu
            // 
            grbJeu.BackColor = Color.Transparent;
            grbJeu.BackgroundImageLayout = ImageLayout.Stretch;
            grbJeu.Location = new Point(14, 101);
            grbJeu.Margin = new Padding(3, 4, 3, 4);
            grbJeu.Name = "grbJeu";
            grbJeu.Padding = new Padding(3, 4, 3, 4);
            grbJeu.Size = new Size(1011, 760);
            grbJeu.TabIndex = 13;
            grbJeu.TabStop = false;
            // 
            // lblNbNiveau
            // 
            lblNbNiveau.AutoSize = true;
            lblNbNiveau.BackColor = Color.Transparent;
            lblNbNiveau.Location = new Point(261, 43);
            lblNbNiveau.Name = "lblNbNiveau";
            lblNbNiveau.Size = new Size(17, 20);
            lblNbNiveau.TabIndex = 24;
            lblNbNiveau.Text = "0";
            // 
            // picDB
            // 
            picDB.BackColor = Color.Transparent;
            picDB.Image = Properties.Resources.db;
            picDB.Location = new Point(471, 16);
            picDB.Name = "picDB";
            picDB.Size = new Size(71, 71);
            picDB.SizeMode = PictureBoxSizeMode.StretchImage;
            picDB.TabIndex = 25;
            picDB.TabStop = false;
            // 
            // tmrEnnemis
            // 
            tmrEnnemis.Interval = 2000;
            tmrEnnemis.Tick += TmrEnnemis_Tick;
            // 
            // picFreezer
            // 
            picFreezer.BackColor = Color.Transparent;
            picFreezer.Image = Properties.Resources.freezer;
            picFreezer.Location = new Point(1032, 115);
            picFreezer.Margin = new Padding(3, 4, 3, 4);
            picFreezer.Name = "picFreezer";
            picFreezer.Size = new Size(114, 104);
            picFreezer.SizeMode = PictureBoxSizeMode.StretchImage;
            picFreezer.TabIndex = 26;
            picFreezer.TabStop = false;
            // 
            // pcbCell
            // 
            pcbCell.BackColor = Color.Transparent;
            pcbCell.Image = Properties.Resources.cell;
            pcbCell.Location = new Point(1032, 248);
            pcbCell.Margin = new Padding(3, 4, 3, 4);
            pcbCell.Name = "pcbCell";
            pcbCell.Size = new Size(114, 101);
            pcbCell.SizeMode = PictureBoxSizeMode.StretchImage;
            pcbCell.TabIndex = 27;
            pcbCell.TabStop = false;
            // 
            // picVegeta
            // 
            picVegeta.BackColor = Color.Transparent;
            picVegeta.Image = Properties.Resources.vegeta;
            picVegeta.Location = new Point(1032, 399);
            picVegeta.Margin = new Padding(3, 4, 3, 4);
            picVegeta.Name = "picVegeta";
            picVegeta.Size = new Size(114, 105);
            picVegeta.SizeMode = PictureBoxSizeMode.StretchImage;
            picVegeta.TabIndex = 28;
            picVegeta.TabStop = false;
            // 
            // picBuu
            // 
            picBuu.BackColor = Color.Transparent;
            picBuu.Image = Properties.Resources.buu;
            picBuu.Location = new Point(1032, 543);
            picBuu.Margin = new Padding(3, 4, 3, 4);
            picBuu.Name = "picBuu";
            picBuu.Size = new Size(114, 103);
            picBuu.SizeMode = PictureBoxSizeMode.StretchImage;
            picBuu.TabIndex = 29;
            picBuu.TabStop = false;
            // 
            // picEtourdit
            // 
            picEtourdit.BackColor = Color.Transparent;
            picEtourdit.Image = Properties.Resources.vertige_removebg_preview;
            picEtourdit.Location = new Point(1032, 136);
            picEtourdit.Margin = new Padding(3, 4, 3, 4);
            picEtourdit.Name = "picEtourdit";
            picEtourdit.Size = new Size(114, 51);
            picEtourdit.SizeMode = PictureBoxSizeMode.StretchImage;
            picEtourdit.TabIndex = 30;
            picEtourdit.TabStop = false;
            picEtourdit.Visible = false;
            // 
            // tmrAttaque
            // 
            tmrAttaque.Interval = 500;
            tmrAttaque.Tick += TmrAttaque_Tick;
            // 
            // picPause
            // 
            picPause.BackColor = Color.Transparent;
            picPause.Cursor = Cursors.Hand;
            picPause.Image = Properties.Resources.pause;
            picPause.Location = new Point(14, 20);
            picPause.Margin = new Padding(3, 4, 3, 4);
            picPause.Name = "picPause";
            picPause.Size = new Size(96, 59);
            picPause.SizeMode = PictureBoxSizeMode.StretchImage;
            picPause.TabIndex = 31;
            picPause.TabStop = false;
            picPause.Click += pictureBox1_Click;
            // 
            // picScore
            // 
            picScore.BackColor = Color.Transparent;
            picScore.Image = Properties.Resources.score;
            picScore.Location = new Point(303, 24);
            picScore.Margin = new Padding(3, 4, 3, 4);
            picScore.Name = "picScore";
            picScore.Size = new Size(89, 59);
            picScore.SizeMode = PictureBoxSizeMode.StretchImage;
            picScore.TabIndex = 32;
            picScore.TabStop = false;
            // 
            // picNiveau
            // 
            picNiveau.BackColor = Color.Transparent;
            picNiveau.Image = Properties.Resources.niveau;
            picNiveau.Location = new Point(133, 20);
            picNiveau.Margin = new Padding(3, 4, 3, 4);
            picNiveau.Name = "picNiveau";
            picNiveau.Size = new Size(121, 59);
            picNiveau.SizeMode = PictureBoxSizeMode.StretchImage;
            picNiveau.TabIndex = 33;
            picNiveau.TabStop = false;
            // 
            // Jeu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.namek;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1192, 915);
            Controls.Add(picNiveau);
            Controls.Add(picScore);
            Controls.Add(picPause);
            Controls.Add(picEtourdit);
            Controls.Add(picBuu);
            Controls.Add(picVegeta);
            Controls.Add(pcbCell);
            Controls.Add(picFreezer);
            Controls.Add(picDB);
            Controls.Add(lblNbNiveau);
            Controls.Add(grbJeu);
            Controls.Add(picBoost);
            Controls.Add(picVie3);
            Controls.Add(picVie2);
            Controls.Add(picVie1);
            Controls.Add(lblTempsBoost);
            Controls.Add(lblNbDb);
            Controls.Add(lblNbScore);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Jeu";
            Text = "Fukushu No Yume";
            FormClosing += Jeu_FormClosing;
            KeyDown += Form3_KeyDown;
            ((System.ComponentModel.ISupportInitialize)picVie1).EndInit();
            ((System.ComponentModel.ISupportInitialize)picVie2).EndInit();
            ((System.ComponentModel.ISupportInitialize)picVie3).EndInit();
            ((System.ComponentModel.ISupportInitialize)picBoost).EndInit();
            ((System.ComponentModel.ISupportInitialize)picDB).EndInit();
            ((System.ComponentModel.ISupportInitialize)picFreezer).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcbCell).EndInit();
            ((System.ComponentModel.ISupportInitialize)picVegeta).EndInit();
            ((System.ComponentModel.ISupportInitialize)picBuu).EndInit();
            ((System.ComponentModel.ISupportInitialize)picEtourdit).EndInit();
            ((System.ComponentModel.ISupportInitialize)picPause).EndInit();
            ((System.ComponentModel.ISupportInitialize)picScore).EndInit();
            ((System.ComponentModel.ISupportInitialize)picNiveau).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblNbScore;
        private Label lblNbDb;
        private Label lblTempsBoost;
        private PictureBox picVie1;
        private PictureBox picVie2;
        private PictureBox picVie3;
        private System.Windows.Forms.Timer tmrBoost;
        private PictureBox picBoost;
        private GroupBox grbJeu;
        private Label lblNbNiveau;
        private PictureBox picDB;
        private System.Windows.Forms.Timer tmrEnnemis;
        private PictureBox picFreezer;
        private PictureBox pcbCell;
        private PictureBox picVegeta;
        private PictureBox picBuu;
        private PictureBox picEtourdit;
        private System.Windows.Forms.Timer tmrAttaque;
        private PictureBox picPause;
        private PictureBox picScore;
        private PictureBox picNiveau;
    }
}