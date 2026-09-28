using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interface1
{
    public partial class Classement : Form
    {
        public Classement()
        {
            InitializeComponent();
            string[,] result = BD.AfficherClassement();
            int occurence = 0, taille, y = 0, x = 0;
            taille = result.Length;

            // création du classement des 10 premiers joueurs
            for (int i = 0; i < taille/2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Label temp = new Label();
                    temp.Name = $"lbl{occurence}";
                    occurence++;
                    temp.Text = result[i, j];
                    temp.BackColor = Color.Transparent;
                    if (i == 0 && j == 0)
                    {
                        temp.Location = new Point(ClientSize.Width / 4, ClientSize.Height / 5);
                        y = temp.Location.Y;
                        x = temp.Location.X;
                        temp.ForeColor = Color.Red;
                    }
                    else if (i == 0 && j == 1)
                    {
                        temp.ForeColor = Color.Red;
                    }
                    x += 150;
                    temp.Location = new Point(x, y);
                    Controls.Add(temp);
                }
                y += 30;
                x = ClientSize.Width / 4;
            }
        }

        private void Classement_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.ApplicationExitCall)
            {
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                string message = "Etes-vous sûr de vouloir retourner au menu principal?";
                string caption = "Retour au menu principal";
                DialogResult result;
                result = MessageBox.Show(this, message, caption, buttons);

                if (result == DialogResult.Yes)
                {
                    Application.OpenForms[0].Show();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
