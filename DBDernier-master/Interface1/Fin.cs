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
    public partial class Fin : Form
    {
        private bool fermer = true;
        public Fin(string pseudo, int score, int pos = 0)
        {
            InitializeComponent();
            BD.Insertion(pseudo, score, pos);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.OpenForms[0].Show();
            Fermer();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            // information concernant l'équipe qui a créé le jeu
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            string message = "IUT AMIENS Sud - BUT 1 - 2023-2024\n Groupe C-01\n ANGOT LORENZO\r\nDRUART LUCAS\r\nHENNAOUI --SINOQUET SAMY\r\nIDRISSI MOHAMED\r\nIGOUFE VALENTIN\r\nKABA OUMAR";
            string caption = "Crédits";
            DialogResult result;
            result = MessageBox.Show(this, message, caption, buttons);

        }

        private void Fermer()
        {
            // pouvoir fermer la Form sans générer de messagebox --> quand on veut afficher une autre fenêtre par le code
            fermer = false;
            this.Close();
        }

        private void Fin_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}
