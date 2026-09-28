using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interface1
{
    public partial class Parametre : Form
    {
        private byte touches = 0;
        private byte difficulte = 0;
        private Accueil Accueil;
        private bool fermer = true;
        public Parametre(Accueil accueil)
        {
            InitializeComponent();
            this.Hide();
            rdoFacile.Checked = true;
            rdoFleches.Checked = true;
            Accueil = accueil;

        }

        private void rdo_CheckedChanged(object sender, EventArgs e)
        {
            // même procédure pour toutes les RDO
            RadioButton temp = (RadioButton)sender;
            if (temp.Checked == true)
            {
                temp.BackColor = Color.Red;
                if (temp.Name == rdoZQSD.Name)
                {
                    touches = 1;
                }
                else if (temp.Name == rdoFleches.Name)
                {
                    touches = 0;
                }
                else if (temp.Name == rdoFacile.Name)
                {
                    difficulte = 0;
                }
                else if (temp.Name == rdoMoyen.Name)
                {
                    difficulte = 1;
                }
                else
                {
                    difficulte = 2;
                }
            }
            else
            {
                // si décochée couleur blanche
                temp.BackColor = Color.White;
            }
        }

        private void trkVolume_Scroll(object sender, EventArgs e)
        {
            lblNbVolume.Text = Convert.ToString(trkVolume.Value);
        }

        private void Parametre_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.ApplicationExitCall && fermer)
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
            else
            {
                fermer = true;
            }
        }

        private void Fermer()
        {
            // pouvoir fermer la Form sans générer de messagebox --> quand on veut afficher une autre fenêtre par le code
            fermer = false;
            this.Close();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Accueil.Stop();
            Jeu temp = new Jeu(txbPseudo.Text, touches, difficulte, 1, 0);
            temp.Show();
            Fermer();
        }
    }
}
