namespace Interface1
{
    partial class Fin
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
            picRetour = new PictureBox();
            picBravo = new PictureBox();
            picDonnees = new PictureBox();
            picCredits = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)picRetour).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picBravo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picDonnees).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picCredits).BeginInit();
            SuspendLayout();
            // 
            // picRetour
            // 
            picRetour.BackColor = Color.Transparent;
            picRetour.Cursor = Cursors.Hand;
            picRetour.Image = Properties.Resources.retour;
            picRetour.Location = new Point(137, 345);
            picRetour.Name = "picRetour";
            picRetour.Size = new Size(171, 65);
            picRetour.SizeMode = PictureBoxSizeMode.StretchImage;
            picRetour.TabIndex = 0;
            picRetour.TabStop = false;
            picRetour.Click += pictureBox1_Click;
            // 
            // picBravo
            // 
            picBravo.BackColor = Color.Transparent;
            picBravo.Image = Properties.Resources.fin_message;
            picBravo.Location = new Point(45, 58);
            picBravo.Name = "picBravo";
            picBravo.Size = new Size(600, 50);
            picBravo.SizeMode = PictureBoxSizeMode.StretchImage;
            picBravo.TabIndex = 2;
            picBravo.TabStop = false;
            // 
            // picDonnees
            // 
            picDonnees.BackColor = Color.Transparent;
            picDonnees.Image = Properties.Resources.donnees;
            picDonnees.Location = new Point(45, 160);
            picDonnees.Name = "picDonnees";
            picDonnees.Size = new Size(600, 50);
            picDonnees.SizeMode = PictureBoxSizeMode.StretchImage;
            picDonnees.TabIndex = 3;
            picDonnees.TabStop = false;
            // 
            // picCredits
            // 
            picCredits.BackColor = Color.Transparent;
            picCredits.Cursor = Cursors.Hand;
            picCredits.Image = Properties.Resources.credits;
            picCredits.Location = new Point(422, 345);
            picCredits.Name = "picCredits";
            picCredits.Size = new Size(185, 65);
            picCredits.SizeMode = PictureBoxSizeMode.StretchImage;
            picCredits.TabIndex = 4;
            picCredits.TabStop = false;
            picCredits.Click += pictureBox4_Click;
            // 
            // Fin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fond_fin;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(687, 450);
            Controls.Add(picCredits);
            Controls.Add(picDonnees);
            Controls.Add(picBravo);
            Controls.Add(picRetour);
            Name = "Fin";
            Text = "Fin";
            FormClosing += Fin_FormClosing;
            ((System.ComponentModel.ISupportInitialize)picRetour).EndInit();
            ((System.ComponentModel.ISupportInitialize)picBravo).EndInit();
            ((System.ComponentModel.ISupportInitialize)picDonnees).EndInit();
            ((System.ComponentModel.ISupportInitialize)picCredits).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox picRetour;
        private PictureBox picBravo;
        private PictureBox picDonnees;
        private PictureBox picCredits;
    }
}