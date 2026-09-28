using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary1;
using static System.Formats.Asn1.AsnWriter;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Interface1
{
    public partial class Jeu : Form
    {
        private readonly Partie partie;
        private readonly Carte carte;
        private bool fermer = true;
        private readonly PictureBox picJoueur;
        private readonly PictureBox picEnnemi1;
        private readonly PictureBox picEnnemi2;
        private readonly PictureBox picEnnemi3;
        private readonly PictureBox picEnnemi4;
        private readonly PictureBox picAttaque;
        private SoundPlayer SoundPlayer;
        public Jeu(string pseudo, byte touches, byte difficulte = 0, byte niveau_partie = 1, int score = 0)
        {
            InitializeComponent();
            this.Hide();
            picJoueur = new PictureBox();
            picEnnemi1 = new PictureBox();
            picEnnemi2 = new PictureBox();
            picEnnemi3 = new PictureBox();
            picEnnemi4 = new PictureBox();
            picAttaque = new PictureBox();
            SoundPlayer = new SoundPlayer(Properties.Resources.Musique_Jeu__Niveaux_2);
            SoundPlayer.Tag = "musique_niveau";
            SoundPlayer.PlayLooping();

            // taille carte
            if (difficulte == 0)
            {
                this.Width = 1050;
                this.Height = 690;
                carte = new Carte((10, 14), false); // taille en fonction de la difficulté
                grbJeu.Width = this.Width - 200;
                grbJeu.Height = this.Height - 170;
                picFreezer.Location = new Point(grbJeu.Location.X + grbJeu.Width + 20, 90);
                pcbCell.Location = new Point(picFreezer.Location.X, picFreezer.Location.Y + 140);
                picVegeta.Location = new Point(pcbCell.Location.X, pcbCell.Location.Y + 140);
                picBuu.Location = new Point(picVegeta.Location.X, picVegeta.Location.Y + 140);
            }
            else if (difficulte == 1)
            {
                this.Width = 1050;
                this.Height = 650;
                carte = new Carte((9, 14), false); // taille en fonction de la difficulté
                grbJeu.Width = this.Width - 200;
                grbJeu.Height = this.Height - 180;
                picFreezer.Location = new Point(grbJeu.Location.X + grbJeu.Width + 20, 90);
                pcbCell.Location = new Point(picFreezer.Location.X, picFreezer.Location.Y + 125);
                picVegeta.Location = new Point(pcbCell.Location.X, pcbCell.Location.Y + 125);
                picBuu.Location = new Point(picVegeta.Location.X, picVegeta.Location.Y + 125);
            }
            else
            {
                this.Width = 1050;
                this.Height = 600;
                carte = new Carte((8, 14), false); // taille en fonction de la difficulté
                grbJeu.Width = this.Width - 200;
                grbJeu.Height = this.Height - 180;
                picFreezer.Location = new Point(grbJeu.Location.X + grbJeu.Width + 20, 90);
                pcbCell.Location = new Point(picFreezer.Location.X, picFreezer.Location.Y + 110);
                picVegeta.Location = new Point(pcbCell.Location.X, pcbCell.Location.Y + 110);
                picBuu.Location = new Point(picVegeta.Location.X, picVegeta.Location.Y + 110);
            }

            partie = new Partie(carte, pseudo, touches, difficulte, niveau_partie, score);
            carte.init_voisins();
            carte.parcours_profondeur(); // réalise un parcours en profondeur sur la carte
            carte.parcours_profondeur_eulerien(); // est sensée rendre le grahe eulérien...

            AfficherMap();

            AffichageObjet();

            // choix arriere plan
            Fond();
            lblNbNiveau.Text = partie.niveau_partie.ToString();
            lblNbScore.Text = partie.score.ToString();
            picEtourdit.BringToFront();
        }
        private void Form3_KeyDown(object sender, KeyEventArgs e)
        {

            if ((string)SoundPlayer.Tag != "musique_niveau")
            {
                SoundPlayer = new SoundPlayer(Properties.Resources.Musique_Jeu__Niveaux_2);
                SoundPlayer.PlayLooping();
            }
            // ennemis bougent dès que le joueur bouge pour la première fois
            if (!tmrEnnemis.Enabled)
            {
                tmrEnnemis.Start();
            }

            // déplacement joueur en foonction de ZQSD ou flèches
            if (partie.touches == 0)
            {
                if (partie.Goku.vie != 0 && !partie.Goku.invincible && !partie.Goku.nyobo)
                {
                    picJoueur.Image = Properties.Resources.gpku_v;
                }
                if (e.KeyCode == Keys.Left)
                {
                    partie.Goku.Bouger(1, carte.Map);
                    if (partie.Goku.nyobo) { } // on ne change pas d'img
                    else if (!partie.Goku.invincible) { picJoueur.Image = Properties.Resources.goku_gauche; } // goku se tourne à gauche
                    else
                    {
                        picJoueur.Image = Properties.Resources.ssj_goku_gauche;
                    }
                }
                else if (e.KeyCode == Keys.Down)
                {
                    partie.Goku.Bouger(2, carte.Map);
                }
                else if (e.KeyCode == Keys.Right)
                {
                    partie.Goku.Bouger(3, carte.Map);
                    if (partie.Goku.nyobo) { }
                    else if (!partie.Goku.invincible && !partie.Goku.nyobo) { picJoueur.Image = Properties.Resources.gpku_v; }
                    else
                    {
                        picJoueur.Image = Properties.Resources.ssj_goku;
                    }
                }
                else if (e.KeyCode == Keys.Up)
                {
                    partie.Goku.Bouger(4, carte.Map);
                }
            }
            else if (partie.touches == 1)
            {
                if (partie.Goku.vie != 0 && !partie.Goku.invincible && !partie.Goku.nyobo)
                {
                    picJoueur.Image = Properties.Resources.gpku_droite;
                }
                if (e.KeyCode == Keys.Q)
                {
                    partie.Goku.Bouger(1, carte.Map);
                    if (partie.Goku.nyobo) { }
                    else if (!partie.Goku.invincible) { picJoueur.Image = Properties.Resources.goku_gauche; }
                    else
                    {
                        picJoueur.Image = Properties.Resources.ssj_goku_gauche;
                    }
                }
                else if (e.KeyCode == Keys.S)
                {
                    partie.Goku.Bouger(2, carte.Map);
                }
                else if (e.KeyCode == Keys.D)
                {
                    partie.Goku.Bouger(3, carte.Map);
                    if (partie.Goku.nyobo) { }
                    else if (!partie.Goku.invincible && !partie.Goku.nyobo) { picJoueur.Image = Properties.Resources.gpku_droite; }
                    else
                    {
                        picJoueur.Image = Properties.Resources.ssj_goku;
                    }
                }
                else if (e.KeyCode == Keys.Z)
                {
                    partie.Goku.Bouger(4, carte.Map);
                }
            }

            VerifPosJoueurEnnemi();
            VerifJoueurObjet();

            AttaqueEnnemis();
            AffichageEnnemiEtourdi();

            SuppressionEnnemisObjets();
            ActualisationVie();

            VerifDB();

            lblNbScore.Text = partie.score.ToString();
            lblNbDb.Text = partie.nb_db.ToString();

            // maj pos PictureBox joueur
            picJoueur.Location = partie.Goku.position;
        }

        private void VerifDB()
        {
            // verif nb db
            if (partie.VerifNbDb() && partie.transforme == 1)
            {
                if (tmrBoost.Enabled)
                {
                    // reset si boost en cours 
                    // le boost est remplacé 
                    // les ennemis retrouvent leur vitesse normale
                    tmrBoost.Stop();
                    tmrEnnemis.Interval = 2000;
                    lblTempsBoost.Text = "0"; 
                }
                partie.timer_boost = 30;
                picBoost.Image = Properties.Resources.aura_invincibilité;
                picJoueur.Image = Properties.Resources.ssj_goku;
                picBoost.Visible = true;
                tmrBoost.Start();
                partie.transforme = 2;
            }
        }

        private void VerifJoueurObjet()
        {
            switch (partie.VerifPosJoueurObjet())
            {
                case 1:
                    if (!partie.etourdi)
                    {
                        // ralentir les ennemis
                        partie.timer_boost = 5;
                        picBoost.Image = Properties.Resources.kinto_un;
                        picBoost.Visible = true;
                        tmrBoost.Start();
                        tmrEnnemis.Interval = 4000;
                    }
                    break;
                case 2:
                    // pouvoir étourdir un ennemi à la prochaine collision
                    if (!partie.etourdi)
                    {
                        partie.Goku.nyobo = true;
                        partie.timer_boost = 5;
                        picBoost.Image = Properties.Resources.nyobo;
                        picJoueur.Image = Properties.Resources.goku_baton;
                        picBoost.Visible = true;
                        tmrBoost.Start();
                    }
                    break;
                default: break;
            }
        }

        private void ActualisationVie()
        {
            //Actualisation visu des vies
            byte nb_vie = partie.Goku.vie;
            if (nb_vie == 2) { picVie1.Visible = false; }
            else if (nb_vie == 1) { picVie2.Visible = false; }
            else if (nb_vie == 0) { picVie3.Visible = false; }
        }

        private void SuppressionEnnemisObjets()
        {
            // suppression des ennemis tués ou objets récupérés
            //ennemis
            foreach (Ennemi ennemi in partie.ennemis_a_supprimer)
            {
                if (ennemi.nom == "Freezer") { grbJeu.Controls.Remove(picEnnemi1); picFreezer.Image = Properties.Resources.freezer_mort; }
                else if (ennemi.nom == "Buu") { grbJeu.Controls.Remove(picEnnemi2); picBuu.Image = Properties.Resources.buu_mort; }
                else if (ennemi.nom == "Vegeta") { grbJeu.Controls.Remove(picEnnemi3); picVegeta.Image = Properties.Resources.vegeta_mort; }
                else if (ennemi.nom == "Cell") { grbJeu.Controls.Remove(picEnnemi4); pcbCell.Image = Properties.Resources.vegeta_mort; }
            }
            //objets
            // pas opti ?
            foreach (Objet objet in partie.objets_a_surrpimer)
            {
                foreach (PictureBox picture in grbJeu.Controls)
                {
                    if (objet.position == picture.Location && picture.Tag == null)
                    {
                        grbJeu.Controls.Remove(picture);
                    }
                }
            }
        }

        private void AffichageEnnemiEtourdi()
        {
            // maj img ennemi --> si un ennemi est étourdi
            // afficher les ennemis en vie sur le coté 
            // timer pour afficher l'étourdissement avec les étoiles qui tournent
            // avec changement d'image rapide en fonction du tick
            if (partie.ennemi_etourdi.nom == "Freezer") { picEnnemi1.Image = Properties.Resources.freezer_imo; picFreezer.Image = Properties.Resources.freezer_imo; picEtourdit.Visible = true; picEtourdit.Location = picFreezer.Location; }
            else if (partie.ennemi_etourdi.nom == "Buu") { picEnnemi2.Image = Properties.Resources.buu_imo; picBuu.Image = Properties.Resources.buu_imo; picEtourdit.Visible = true; picEtourdit.Location = picBuu.Location; }
            else if (partie.ennemi_etourdi.nom == "Vegeta") { picEnnemi3.Image = Properties.Resources.vegeta_imo; picVegeta.Image = Properties.Resources.vegeta_imo; picEtourdit.Visible = true; picEtourdit.Location = picVegeta.Location; }
            else if (partie.ennemi_etourdi.nom == "Cell") { picEnnemi4.Image = Properties.Resources.cell_imo; pcbCell.Image = Properties.Resources.cell_imo; picEtourdit.Visible = true; picEtourdit.Location = pcbCell.Location; }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // si un étourdissement est en cours, aucun autre boost n'est récupéré uniquement les points associés
            if (partie.etourdi)
            {
                // Goku ne peut plus étourdir
                partie.Goku.nyobo = false;
                // timer de l'étourdissement
                partie.Moins1TimerEtourdi();
                lblTempsBoost.Text = partie.timer_etourdi.ToString();
                // si étourdissement terminé
                if (lblTempsBoost.Text == "0")
                {
                    // reset du timer
                    partie.timer_etourdi = 5;
                    // étoiles au dessus de la tête de l'ennemi n'est plus visible
                    picEtourdit.Visible = false;
                    // maj img ennemis
                    foreach (Ennemi ennemi in partie.ennemis)
                    {
                        if (ennemi.nom == "Freezer") { picEnnemi1.Image = Properties.Resources.freezer_r; picFreezer.Image = Properties.Resources.freezer; }
                        else if (ennemi.nom == "Buu") { picEnnemi2.Image = Properties.Resources.buu_r; picBuu.Image = Properties.Resources.buu; }
                        else if (ennemi.nom == "Vegeta") { picEnnemi3.Image = Properties.Resources.vegeta_r; picVegeta.Image = Properties.Resources.vegeta; }
                        else if (ennemi.nom == "Cell") { picEnnemi4.Image = Properties.Resources.cell_r; pcbCell.Image = Properties.Resources.cell; }
                    }
                    lblTempsBoost.ForeColor = Color.Black;
                    picJoueur.Image = Properties.Resources.gpku_v;
                    picBoost.Visible = false;
                    partie.etourdi = false;
                    tmrEnnemis.Interval = 2000;
                    tmrBoost.Stop();
                }
            }
            else
            {
                // boost sans étourdissement en cours
                /// faire ça avec un timer dans Partie
                lblTempsBoost.Text = Convert.ToString(partie.timer_boost);
                partie.timer_boost--;
                switch (lblTempsBoost.Text)
                {
                    case "1":
                        lblTempsBoost.ForeColor = Color.Red;
                        break;
                    case "2":
                        lblTempsBoost.ForeColor = Color.Orange;
                        break;
                    case "3":
                        lblTempsBoost.ForeColor = Color.Yellow;
                        break;
                    case "0":
                        // on reset tout
                        lblTempsBoost.ForeColor = Color.Black;
                        picJoueur.Image = Properties.Resources.gpku_v;
                        if (partie.transforme == 2 && !partie.Goku.invincible)
                        {
                            partie.Goku.invincible = false;
                            Defaite defaite = new(partie.pseudo, partie.score);
                            defaite.Show();
                            Fermer();
                        }
                        picBoost.Visible = false;
                        tmrEnnemis.Interval = 2000;
                        partie.Goku.nyobo = false;
                        partie.timer_boost = 5;
                        tmrBoost.Stop();
                        break;
                    default:
                        lblTempsBoost.ForeColor = Color.Black;
                        break;
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // on stop tout pendant la pause
            tmrBoost.Stop();
            tmrEnnemis.Stop();
            tmrAttaque.Stop();
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            string message = "Etes-vous sûr de vouloir retourner au menu principal? Vous allez perdre votre progression";
            string caption = "Retour au menu principal";
            DialogResult result;
            result = MessageBox.Show(this, message, caption, buttons);

            if (result == DialogResult.Yes)
            {
                System.Windows.Forms.Application.OpenForms[0].Show();
                Fermer();
            }
            else
            {
                // on redémarre si l'utilisateur ne veut pas quitter
                tmrBoost.Start();
                tmrEnnemis.Start();
                tmrAttaque.Start();
            }
        }


        private void Jeu_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (e.CloseReason != CloseReason.ApplicationExitCall && fermer)
            {
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                string message = "Etes-vous sûr de vouloir retourner au bureau? Vous allez perdre votre progression";
                string caption = "Retour au bureau";
                DialogResult result;
                result = MessageBox.Show(this, message, caption, buttons);

                if (result == DialogResult.Yes)
                {
                    // Déconnxeion avant de quitter
                    BD.Deconnexion();
                    System.Windows.Forms.Application.Exit();
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

        public void Fermer()
        {
            // pouvoir fermer la Form sans générer de messagebox --> quand on veut afficher une autre fenêtre par le code
            fermer = false;
            this.Close();
        }

        public void VerifPosJoueurEnnemi()
        {
            switch (partie.VerifPosJoueurEnnemi())
            {
                case 0:
                    // prendre un degat 
                    SoundPlayer soundPlayer = new(Properties.Resources.Effet_sonore_Perd_une_vie);
                    SoundPlayer.Tag = "truc";
                    soundPlayer.Play();
                    tmrEnnemis.Stop();
                    tmrAttaque.Stop();
                    // modif Image de la PictureBox de Goku
                    picJoueur.Image = Properties.Resources.goku_rouge;
                    // retour aux positions init 
                    picJoueur.Location = partie.Goku.position;
                    foreach (Ennemi ennemi in partie.ennemis)
                    {
                        if (ennemi.nom == "Freezer") { picEnnemi1.Location = ennemi.pos_init; }
                        else if (ennemi.nom == "Buu") { picEnnemi2.Location = ennemi.pos_init; }
                        else if (ennemi.nom == "Vegeta") { picEnnemi3.Location = ennemi.pos_init; }
                        else if (ennemi.nom == "Cell") { picEnnemi4.Location = ennemi.pos_init; }
                    }
                    break;
                case 1:
                    // mourir
                    Defaite defaite = new(partie.pseudo, partie.score);
                    defaite.Show();
                    Fermer();
                    break;
                case 2:
                    // gagner
                    Victoire victoire = new(partie.pseudo, partie.touches, partie.difficulte, partie.niveau_partie, partie.score);
                    victoire.Show();
                    Fermer();
                    break;
                default:
                    break;
            }
        }

        public void Fond()
        {
            // sélectionne aléatoirement le fond d'écran du niveau
            Random random = new();
            int x = random.Next(0, 4);
            x = 0;
            if (x == 0) { BackgroundImage = Properties.Resources.cell_game; grbJeu.BackgroundImage = Properties.Resources.cell_game_sombre; }
            else if (x == 1) { BackgroundImage = Properties.Resources.désert; grbJeu.BackgroundImage = Properties.Resources.désert_sombre; }
            else if (x == 2) { BackgroundImage = Properties.Resources.pla_kaio_shin; grbJeu.BackgroundImage = Properties.Resources.pla_kaio_shin_sombre; }
            else { BackgroundImage = Properties.Resources.namek; grbJeu.BackgroundImage = Properties.Resources.namek_sombre; }
        }

        public void AffichageObjet()
        {
            int x = 20, y = 25, occurence = 0, nb_db = 0, valeur, nb_ennemis = 0, max = 10, nb_nuage = 0, nb_baton = 0, max_baton = 4, max_nuage = 4;
            Random random = new();
            if (partie.difficulte == 1) { max = 9; max_baton = 3; max_nuage = 3; }
            else if (partie.difficulte == 2) { max = 8; max_baton = 2; max_nuage = 2; }

            // position aléatoire du joueur
            (int, int) pos1 = (random.Next(0, max), random.Next(0, 14));
            picJoueur.Size = new(30, 30);
            picJoueur.Image = Properties.Resources.gpku_v;
            // petit calcul pour mettre les PictureBox au bonne endroit 
            picJoueur.Location = new(x + 60 * pos1.Item2, y + 50 * pos1.Item1);
            picJoueur.Tag = "entité";
            picJoueur.SizeMode = PictureBoxSizeMode.StretchImage;
            partie.Goku = new(partie.pseudo, picJoueur.Location, (pos1));
            grbJeu.Controls.Add(picJoueur);
            carte.Map[pos1.Item1, pos1.Item2].occupe = true;

            // position aléatoire des db
            while (nb_db < 7)
            {
                (int, int) pos = (random.Next(0, max), random.Next(0, 14));

                // verif pos
                bool ok = true;
                foreach (Objet obj in partie.objets)
                {
                    if ((obj.pos_tab.Item1 == pos.Item1 || obj.pos_tab.Item2 == pos.Item2)
                        && obj.dragon_ball || carte.Map[pos.Item1, pos.Item2].occupe)
                    {
                        // pas de db sur les mêmes positions i ou j que les autres 
                        // sinon pas ok on recommence
                        ok = false; break;
                    }
                }

                if (ok)
                {
                    PictureBox temp = new();
                    temp.Name = $"pcb{occurence + 1}";
                    temp.Size = new Size(30, 30);
                    temp.Image = Properties.Resources.db;
                    temp.Location = new Point(x + 60 * pos.Item2, y + 50 * pos.Item1);
                    temp.SizeMode = PictureBoxSizeMode.StretchImage;
                    Objet objet = new(temp.Location, 2000, true, pos);
                    partie.objets.Add(objet);
                    grbJeu.Controls.Add(temp);
                    nb_db++;
                    carte.Map[pos.Item1, pos.Item2].occupe = true;
                }
            }

            // position aléatoire des ennemis
            while (nb_ennemis < 4)
            {
                (int, int) pos = (random.Next(0, max), random.Next(0, 14));
                bool ok = true;

                foreach (Ennemi ennemi in partie.ennemis)
                {
                    if ((ennemi.pos_tab.Item1 == pos.Item1 || ennemi.pos_tab.Item2 == pos.Item2)
                        || carte.Map[pos.Item1, pos.Item2].occupe)
                    {
                        // pas d'ennemi sur les mêmes positions i ou j que les autres
                        ok = false; break;
                    }
                }

                // quel ennemi en fonction de nb_ennemis
                if (ok)
                {
                    if (nb_ennemis == 0)
                    {
                        picEnnemi1.Size = new Size(30, 30);
                        picEnnemi1.Location = new Point(x + 60 * pos.Item2, y + 50 * pos.Item1);
                        picEnnemi1.SizeMode = PictureBoxSizeMode.StretchImage;
                        picEnnemi1.Tag = "entité";
                        picEnnemi1.Image = Properties.Resources.freezer_r;
                        Ennemi ennemi_temp = new("Freezer", picEnnemi1.Location, pos, true);
                        partie.ennemis.Add(ennemi_temp);
                        grbJeu.Controls.Add(picEnnemi1);
                    }
                    else if (nb_ennemis == 1)
                    {
                        picEnnemi2.Size = new Size(30, 30);
                        picEnnemi2.Location = new Point(x + 60 * pos.Item2, y + 50 * pos.Item1);
                        picEnnemi2.SizeMode = PictureBoxSizeMode.StretchImage;
                        picEnnemi2.Tag = "entité";
                        picEnnemi2.Image = Properties.Resources.buu_r;
                        Ennemi ennemi_temp = new("Buu", picEnnemi2.Location, pos);
                        partie.ennemis.Add(ennemi_temp);
                        grbJeu.Controls.Add(picEnnemi2);
                    }
                    else if (nb_ennemis == 2)
                    {
                        picEnnemi3.Size = new Size(30, 30);
                        picEnnemi3.Location = new Point(x + 60 * pos.Item2, y + 50 * pos.Item1);
                        picEnnemi3.SizeMode = PictureBoxSizeMode.StretchImage;
                        picEnnemi3.Tag = "entité";
                        picEnnemi3.Image = Properties.Resources.vegeta_r;
                        Ennemi ennemi_temp = new("Vegeta", picEnnemi3.Location, pos);
                        partie.ennemis.Add(ennemi_temp);
                        grbJeu.Controls.Add(picEnnemi3);
                    }
                    else if (nb_ennemis == 3)
                    {
                        picEnnemi4.Size = new Size(30, 30);
                        picEnnemi4.Location = new Point(x + 60 * pos.Item2, y + 50 * pos.Item1);
                        picEnnemi4.SizeMode = PictureBoxSizeMode.StretchImage;
                        picEnnemi4.Tag = "entité";
                        picEnnemi4.Image = Properties.Resources.cell_r;
                        picEnnemi4.BackColor = Color.Transparent;
                        Ennemi ennemi_temp = new("Cell", picEnnemi4.Location, pos);
                        partie.ennemis.Add(ennemi_temp);
                        grbJeu.Controls.Add(picEnnemi4);
                    }
                    nb_ennemis++;
                    carte.Map[pos.Item1, pos.Item2].occupe = true;
                }
            }

            while (nb_baton < max_baton)
            {
                (int, int) pos = (random.Next(0, max), random.Next(0, 14));
                // baton magique
                if (!carte.Map[pos.Item1, pos.Item2].occupe)
                {
                    PictureBox temp = new();
                    temp.Name = $"pcb{occurence + 1}";
                    temp.Size = new Size(30, 30);
                    temp.Image = Properties.Resources.nyobo;
                    temp.Location = new(x + 60 * pos.Item2, y + 50 * pos.Item1);
                    temp.SizeMode = PictureBoxSizeMode.StretchImage;
                    Objet objet = new(temp.Location, 1500, false, pos, 2);
                    partie.objets.Add(objet);
                    grbJeu.Controls.Add(temp);
                    carte.Map[pos.Item1, pos.Item2].occupe = true;
                    nb_baton++;
                }
            }

            while (nb_nuage < max_nuage)
            {
                (int, int) pos = (random.Next(0, max), random.Next(0, 14));
                // baton magique
                if (!carte.Map[pos.Item1, pos.Item2].occupe)
                {
                    PictureBox temp = new PictureBox();
                    temp.Name = $"pcb{occurence + 1}";
                    temp.Size = new Size(30, 30);
                    temp.Image = Properties.Resources.kinto_un;
                    temp.Location = new Point(x + 60 * pos.Item2, y + 50 * pos.Item1);
                    temp.SizeMode = PictureBoxSizeMode.StretchImage;
                    Objet objet = new(temp.Location, 2000, false, pos, 1);
                    partie.objets.Add(objet);
                    grbJeu.Controls.Add(temp);
                    carte.Map[pos.Item1, pos.Item2].occupe = true;
                    nb_nuage++;
                }
            }

            // autres objets
            for (int i = 0; i < max; i++)
            {
                for (int j = 0; j < 14; j++)
                {
                    valeur = random.Next(2, 6);
                    if (valeur == 2 && !carte.Map[i, j].occupe)// poisson
                    {
                        PictureBox temp = new();
                        temp.Name = $"pcb{occurence + 1}";
                        temp.Size = new Size(30, 30);
                        temp.Image = Properties.Resources.poisson;
                        temp.Location = new Point(x, y);
                        temp.SizeMode = PictureBoxSizeMode.StretchImage;
                        Objet objet = new Objet(temp.Location, 2000, false, (i, j), 0);
                        partie.objets.Add(objet);
                        grbJeu.Controls.Add(temp);
                        carte.Map[i, j].occupe = true;
                    }
                    else if (valeur == 3 && !carte.Map[i, j].occupe) // pain
                    {
                        PictureBox temp = new();
                        temp.Name = $"pcb{occurence + 1}";
                        temp.Size = new Size(30, 30);
                        temp.Image = Properties.Resources.pain;
                        temp.Location = new Point(x, y);
                        temp.SizeMode = PictureBoxSizeMode.StretchImage;
                        Objet objet = new Objet(temp.Location, 100, false, (i, j), 0);
                        partie.objets.Add(objet);
                        grbJeu.Controls.Add(temp);
                        carte.Map[i, j].occupe = true;
                    }
                    else if (valeur == 4 && !carte.Map[i, j].occupe) // riz
                    {
                        PictureBox temp = new();
                        temp.Name = $"pcb{occurence + 1}";
                        temp.Size = new Size(30, 30);
                        temp.Image = Properties.Resources.riz;
                        temp.Location = new Point(x, y);
                        temp.SizeMode = PictureBoxSizeMode.StretchImage;
                        Objet objet = new Objet(temp.Location, 2000, false, (i, j), 0);
                        partie.objets.Add(objet);
                        grbJeu.Controls.Add(temp);
                        carte.Map[i, j].occupe = true;
                    }
                    else if (valeur == 5 && !carte.Map[i, j].occupe)
                    {
                        // viande
                        PictureBox temp = new();
                        temp.Name = $"pcb{occurence + 1}";
                        temp.Size = new Size(30, 30);
                        temp.Image = Properties.Resources.viande;
                        temp.Location = new Point(x, y);
                        temp.SizeMode = PictureBoxSizeMode.StretchImage;
                        Objet objet = new(temp.Location, 1500, false, (i, j), 0);
                        partie.objets.Add(objet);
                        grbJeu.Controls.Add(temp);
                        carte.Map[i, j].occupe = true;
                    }

                    // maj des prochaines pos
                    x += 60;
                    if (x + 30 > grbJeu.ClientSize.Width)
                    {
                        // "retour à la ligne"
                        x = 20;
                        y += 50;
                    }
                }
            }
        }

        private void AttaqueEnnemis()
        {
            // on regarde si un ennmi peut faire une attaque
            foreach (Ennemi ennemi in partie.ennemis)
            {
                partie.AttaqueEnnemis(ennemi);
            }

            // si aucune attaque n'est en cours alors on peut en faire une
            if (!tmrAttaque.Enabled)
            {
                tmrAttaque.Start();
            }
        }

        private void TmrEnnemis_Tick(object sender, EventArgs e)
        {
            partie.DeplacementEnnemis();
            VerifPosJoueurEnnemi();
            AttaqueEnnemis();

            // maj pos PictureBox
            foreach (Ennemi ennemi in partie.ennemis)
            {
                if (ennemi.nom == "Freezer") { picEnnemi1.Location = ennemi.position; picEnnemi1.BringToFront(); }
                else if (ennemi.nom == "Buu") { picEnnemi2.Location = ennemi.position; picEnnemi2.BringToFront(); }
                else if (ennemi.nom == "Vegeta") { picEnnemi3.Location = ennemi.position; picEnnemi3.BringToFront(); }
                else if (ennemi.nom == "Cell") { picEnnemi4.Location = ennemi.position; picEnnemi4.BringToFront(); }
            }
        }

        private void TmrAttaque_Tick(object sender, EventArgs e)
        {
            // Si la PictureBox n'est pas instanciée 
            // Caractéristiques attaque
            picAttaque.Size = new Size(30, 30);
            picAttaque.Image = Properties.Resources.kikoha;
            picAttaque.SizeMode = PictureBoxSizeMode.StretchImage;

            // Ennemi qui lance l'attaque
            Ennemi temp = partie.UnSeulEnnemiAttque();
            temp.BougerAttaque();
            picAttaque.Location = temp.pos_attaque;

            if (!grbJeu.Controls.Contains(picAttaque))
            {
                grbJeu.Controls.Add(picAttaque);
            }
            else if (picAttaque.Location.X > grbJeu.ClientSize.Width || picAttaque.Location.X < 0
                || picAttaque.Location.Y > grbJeu.ClientSize.Height || picAttaque.Location.Y < 0)
            {
                grbJeu.Controls.Remove(picAttaque);
                partie.attaque_en_cours = false;
                temp.attaque = false;
                tmrAttaque.Stop();
            }

            picAttaque.BringToFront();
            (bool, bool) result = partie.VerifJoueurKikoha();
            // Item1 = prendre un dégat // Item2 = mourir
            if (result.Item1)
            {
                SoundPlayer soundPlayer = new(Properties.Resources.Effet_sonore_Perd_une_vie);
                soundPlayer.Play();
                SoundPlayer.Tag = "truc";
                grbJeu.Controls.Remove(picAttaque);
                partie.attaque_en_cours = false;
                temp.attaque = false;
                tmrAttaque.Stop();
                tmrEnnemis.Stop();
                // si j'ai prit un dégat on fait les modifications nécessaires
                picJoueur.Image = Properties.Resources.goku_rouge;
                picJoueur.Location = partie.Goku.position;
                foreach (Ennemi ennemi in partie.ennemis)
                {
                    if (ennemi.nom == "Freezer") { picEnnemi1.Location = ennemi.pos_init; }
                    else if (ennemi.nom == "Buu") { picEnnemi2.Location = ennemi.pos_init; }
                    else if (ennemi.nom == "Vegeta") { picEnnemi3.Location = ennemi.pos_init; }
                    else if (ennemi.nom == "Cell") { picEnnemi4.Location = ennemi.pos_init; }
                }
                ActualisationVie();
                if (result.Item2)
                {
                    // mourir
                    Defaite defaite = new(partie.pseudo, partie.score);
                    defaite.Show();
                    Fermer();
                }
            }
        }

        private void AfficherMap()
        {
            Pixel temp;
            (bool, bool, bool, bool) etat;
            int x = 0, y = 10, occurence = 0, espace = 0, scale = 20;

            for (int i = 0; i <= carte.M + 2; i++)
            {
                PictureBox tempo = new();
                tempo.Name = $"pcb{occurence + 1}";
                tempo.Size = new(50, 10);
                tempo.Location = new(x, y);
                tempo.Image = Properties.Resources.mur;
                grbJeu.Controls.Add(tempo);
                x += 50;
            }

            for (int i = 0; i < carte.N; i++) // Pour chaque pixel de la ligne i 
            {
                // premier mur d'une ligne déterminant le contour du laby
                PictureBox t = new();
                t.Name = $"pcb{occurence + 1}";
                t.Size = new Size(10, 50);
                t.Location = new Point(0, scale);
                t.Image = Properties.Resources.murvertical;
                grbJeu.Controls.Add(t);

                for (int j = 0; j < carte.M; j++) // Pour chaque pixel de la colonne j
                {
                    temp = carte.Map[i, j]; // récupération du pixel
                    etat = temp.etat_lien(); // récupération de l'état des côtés du pixel (mur ou lien)
                    if (etat.Item2 == false) // si pas de lien en bas 
                    {
                        PictureBox p = new();
                        p.Name = $"pcb{occurence + 1}";
                        p.Size = new Size(50, 10);
                        p.Location = new Point(grbJeu.Controls[grbJeu.Controls.Count - 1].Location.X + grbJeu.Controls[grbJeu.Controls.Count - 1].Width + espace, scale + 40);
                        p.Image = Properties.Resources.mur;
                        grbJeu.Controls.Add(p);
                        espace = 0;
                    }
                    else
                    {
                        if (espace != 0)
                        {
                            espace += 50;
                        }
                        else
                        {
                            espace = 50;
                        }
                    }

                    // droite
                    if (etat.Item3 == false || j == carte.M - 1) // si pas de lien à la droite du pixel ou que j = au nombre de colonne de la matrice - 1 car ça commence à 0
                    {
                        // mur de droite
                        PictureBox k = new();
                        k.Name = $"pcb{occurence + 1}";
                        k.Size = new Size(10, 50);
                        k.Location = new Point(grbJeu.Controls[grbJeu.Controls.Count - 1].Location.X + grbJeu.Controls[grbJeu.Controls.Count - 1].Width + espace, scale);
                        k.Image = Properties.Resources.murvertical;
                        grbJeu.Controls.Add(k);
                        espace = 0;
                    }
                    else
                    {
                        if (espace != 0)
                        {
                            espace += 10;
                        }
                        else
                        {
                            espace = 10;
                        }
                    }
                }
                scale += 50;
            }
        }
    }
}
