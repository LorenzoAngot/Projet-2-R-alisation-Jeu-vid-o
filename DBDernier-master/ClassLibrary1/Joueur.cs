using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ClassLibrary1
{
    public class Joueur
    {
        private Point _position;
        private Point _pos_init;
        private byte _nb_vie = 3;
        private string _pseudo;
        private bool _invincible = false;
        private byte _vitesse = 2;
        private (int, int) _pos_tab;
        private (int, int) _pos_tab_init;
        private bool _nyobo = false; // true si étourdissement disponible

        public Joueur(string p, Point pos, (int, int) pos_tab)
        {
            _pseudo = p;
            _position = pos;
            _pos_init = _position;
            _pos_tab = pos_tab;
            _pos_tab_init = _pos_tab;
        }

        // get and set

        public bool nyobo { get { return _nyobo; } set { _nyobo = value; } }
        public byte vie { get { return _nb_vie; } }
        public Point pos_init { get { return _pos_init; } }
        public (int, int) pos_tab { get { return _pos_tab; } }
        public bool invincible { get { return _invincible; } set { _invincible = value; } }

        public Point position { get { return _position; } set { _position = value; _pos_tab = _pos_tab_init; } }

        public byte vitesse { get { return _vitesse; } set { _vitesse = value; } }

        public bool PerdreVie()
        {
            _nb_vie--;
            if (_nb_vie == 0)
            {
                return true;
            }
            return false;
        }

        public void Bouger(byte a, Pixel[,] temp)
        {
            Pixel[,] map = temp;
            (bool, bool, bool, bool) etat_liens = map[_pos_tab.Item1, _pos_tab.Item2].etat_lien();

            if (etat_liens.Item1 && _pos_tab.Item2 != 0 && a == 1) // gauche
            {
                _position.X -= 60;
                _pos_tab.Item2--;
            }
            else if (etat_liens.Item2 && _pos_tab.Item1 != 9 && a == 2) // bas
            {
                _position.Y += 50;
                _pos_tab.Item1++;
            }
            else if (etat_liens.Item3 && _pos_tab.Item2 != 13 && a == 3) // droite
            {
                _position.X += 60;
                _pos_tab.Item2++;
            }
            else if (etat_liens.Item4 && _pos_tab.Item1 != 0 && a == 4) // haut
            {
                _position.Y -= 50;
                _pos_tab.Item1--;
            }
        }
    }
}

