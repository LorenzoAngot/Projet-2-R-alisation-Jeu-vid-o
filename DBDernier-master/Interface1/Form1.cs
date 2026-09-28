using AxWMPLib;
using ClassLibrary1;
using System.Media;
using WMPLib;

namespace Interface1
{
    public partial class Accueil : Form
    {
        private SoundPlayer player;
        public Accueil()
        {
            InitializeComponent();
            player = new SoundPlayer(Properties.Resources.Menu_principal);
            BD.Connexion();
        }

        // pour pouvoir arrêter la musique depuis Form2
        public void Stop()
        {
            player.Stop();
        }

        public void Play()
        {
            player.PlayLooping();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Parametre form2 = new Parametre(this);
            form2.Show();
            this.Hide();
        }

        private void Accueil_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                Play();
            }
        }

        private void Accueil_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.ApplicationExitCall)
            {
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                string message = "Etes-vous sûr de vouloir retourner au bureau?";
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
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            BD.Delete();
            Classement temp = new Classement();
            temp.Show();
            this.Hide();
        }
    }
}
