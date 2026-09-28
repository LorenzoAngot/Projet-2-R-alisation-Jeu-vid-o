using ClassLibrary1;
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
    public partial class Defaite : Form
    {
        private SoundPlayer player;
        private bool fermer;
        public Defaite(string pseudo, int score, int pos = 0)
        {
            InitializeComponent();
            player = new SoundPlayer(Properties.Resources.Musique_Message_de_Défaite);
            player.PlayLooping();
            fermer = true;
            BD.Insertion(pseudo, score, pos);
        }

        private void Fermer()
        {
            // pouvoir fermer la Form sans générer de messagebox --> quand on veut afficher une autre fenêtre par le code
            fermer = false;
            this.Close();
        }

        private void Defaite_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.ApplicationExitCall && fermer)
            {
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                string message = "Etes-vous sûr de vouloir retourner au bureau ?";
                string caption = "Retour au bureau";
                DialogResult result;
                result = MessageBox.Show(this, message, caption, buttons);

                if (result == DialogResult.Yes)
                {
                    BD.Deconnexion();
                    Application.Exit();
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            // afficher menu principal et fermer cette Form
            Application.OpenForms[0].Show();
            Fermer();
            player.Stop();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            // retour au bureau
            BD.Deconnexion();
            player.Stop();
            Application.Exit();
        }
    }
}
