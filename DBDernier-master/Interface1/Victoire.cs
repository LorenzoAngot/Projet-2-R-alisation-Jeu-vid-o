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
using static System.Formats.Asn1.AsnWriter;

namespace Interface1
{
    public partial class Victoire : Form
    {
        private string _pseudo;
        private byte _touches;
        private byte _niveau_partie;
        private int _score;
        private byte _difficulte;
        private bool fermer = true;
        public Victoire(string pseudo, byte touches, byte difficulte, byte niveau_partie, int score)
        {
            InitializeComponent();
            _pseudo = pseudo;
            _touches = touches;
            _niveau_partie = niveau_partie;
            _score = score;
            _difficulte = difficulte;
        }

        private void Victoire_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 
            if (e.CloseReason != CloseReason.UserClosing && fermer)
            {
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                string message = "Etes-vous sûr de vouloir quitter? Vous allez perdre votre progression";
                string caption = "Retour au bureau";
                DialogResult result;
                result = MessageBox.Show(this, message, caption, buttons);

                if (result == DialogResult.Yes)
                {
                    // deconnxion BD avant de quitter le jeu
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

        private void Fermer()
        {
            // pouvoir fermer la Form sans générer de messagebox --> quand on veut afficher une autre fenêtre par le code
            fermer = false;
            Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // gagner 5 niveaux car 20 c'est long
            if (_niveau_partie == 3) // ça commence à 1
            {
                Fin fin = new(_pseudo, _score, 0);
                fin.Show();
            }
            else
            {
                Jeu jeu = new(_pseudo, _touches, _difficulte, _niveau_partie, _score);
                jeu.Show();
            }
            Fermer();
        }
    }
}
