using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ClassLibrary1
{
    public class Ennemi
    {
        private Point _position;
        private (int, int) _pos_tab;
        private (int, int) _pos_tab_init;
        private Point _pos_init;
        private string _nom;
        private Point _pos_attaque;
        private byte _attaque_en_cours;
        private bool _attaque;
        private bool _chemin;
        private List<(Pixel, Pixel)> _chemin1;

        public Ennemi(string nom, Point location, (int, int) pos_tab, bool chemin = false)
        {
            _position = location;
            _pos_init = _position;
            _pos_tab = pos_tab;
            _pos_tab_init = _pos_tab;
            _nom = nom;
            _pos_attaque = _position;
            _attaque = false;
            _pos_attaque = new Point(-10, -10);
            _chemin = chemin;
            _chemin1 = new List<(Pixel, Pixel)>();
        }

        // getters

        public bool attaque { get { return _attaque; } set { _attaque = value; } }
        public byte attaque_en_cours { get { return _attaque_en_cours; } set { _attaque_en_cours = value; } }
        public Point pos_attaque { get { return _pos_attaque; } set { _pos_attaque = value; } }
        public string nom { get { return _nom; } }
        public Point pos_init { get { return _pos_init; } }
        public (int, int) pos_tab { get { return _pos_tab; } }
        public Point position { get { return _position; } set { _position = value; _pos_tab = _pos_tab_init; } }

        public void Deplacement(Pixel[,] temp)
        {

            if (!_chemin)
            {
                (bool, bool, bool, bool) etat_liens = temp[_pos_tab.Item1, _pos_tab.Item2].etat_lien();
                Random random = new Random();
                int x = random.Next(1, 5);

                if (x == 1 && etat_liens.Item1 && _pos_tab.Item2 != 0) // gauche
                {
                    _position.X -= 60;
                    _pos_tab.Item2--;
                }
                else if (x == 2 && etat_liens.Item2 && _pos_tab.Item1 != 8) // bas
                {
                    _position.Y += 50;
                    _pos_tab.Item1++;
                }
                else if (x == 3 && etat_liens.Item3 && _pos_tab.Item2 != 13) // droite
                {
                    _position.X += 60;
                    _pos_tab.Item2++;
                }
                else if (x == 4 && etat_liens.Item4 && _pos_tab.Item1 != 0) // haut
                {
                    _position.Y -= 50;
                    _pos_tab.Item1--;
                }

                if (!_attaque)
                {
                    _pos_attaque = _position;
                }
            }
            else
            {
                hierholzer(temp);
                Random random = new Random();
                Pixel suivant = _chemin1[random.Next(0, _chemin1.Count)].Item2;
                // choix aléatoire des pixels voisins de degré 2
                if (suivant.get_pos().Item2 > _pos_tab.Item2 && _pos_tab.Item2 != 13) // droite
                {
                    _position.X += 60;
                    _pos_tab.Item2++;
                }
                else if (suivant.get_pos().Item2 < _pos_tab.Item2 && _pos_tab.Item2 != 0) // gauche
                {
                    _position.X -= 60;
                    _pos_tab.Item2--;
                }
                else if (suivant.get_pos().Item1 > _pos_tab.Item1 && _pos_tab.Item1 != 9) // bas
                {
                    _position.Y += 50;
                    _pos_tab.Item1++;
                }
                else if (suivant.get_pos().Item1 < _pos_tab.Item1 && _pos_tab.Item1 != 0) // haut
                {
                    _position.Y -= 50;
                    _pos_tab.Item1--;
                }

                // si je n'attaque pas alors la pos de la prochaine attaque est la même que celle de l'ennemi
                if (!_attaque)
                {
                    _pos_attaque = _position;
                }
            }
        }

        public void BougerAttaque()
        {
            // attaque en cours == sens de l'attaque --> haut,bas,droite,gauche
            if (_attaque_en_cours == 1)
            {
                _pos_attaque = new Point(_pos_attaque.X, _pos_attaque.Y - 50); // haut
            }
            else if (_attaque_en_cours == 2)
            {
                _pos_attaque = new Point(_pos_attaque.X, _pos_attaque.Y + 50); // bas
            }
            else if (_attaque_en_cours == 3)
            {
                _pos_attaque = new Point(_pos_attaque.X - 60, _pos_attaque.Y); // gauche
            }
            else if (_attaque_en_cours == 4)
            {
                _pos_attaque = new Point(_pos_attaque.X + 60, _pos_attaque.Y); // droite
            }
        }

        public void hierholzer(Pixel[,] temp)
        {
            // pixel de départ, pixel d'arrivée
            _chemin1 = new List<(Pixel, Pixel)>();
            Pixel sommet_actuel = temp[pos_tab.Item1, pos_tab.Item2];
            foreach (Pixel pixel in sommet_actuel.renvoie_lien())
            {
                // pour chaque pixel voisin de degré 2 on ajoute dans la liste 
                // pour faire un semblant de chemin eulérien 
                // dans ce graphe/labyrinthe pas eulérien
                if (pixel.renvoie_lien().Count % 2 == 0)
                {
                    _chemin1.Add((sommet_actuel, pixel));
                    sommet_actuel = pixel;
                }
            }
            // si il n'y a pas de voisin pair alors on ajoute des sommets impairs 
            if (_chemin1.Count == 0)
            {
                foreach (Pixel pixel in sommet_actuel.renvoie_lien())
                {
                    _chemin1.Add((sommet_actuel, pixel));
                }
            }
        }
    }
}

