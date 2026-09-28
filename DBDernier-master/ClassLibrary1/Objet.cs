using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ClassLibrary1
{
    public class Objet
    {
        private Point _position;
        private int _valeur_score;
        private bool _dragon_ball;
        private byte _boost; // 1 = boost de vitesse // 2 étourdissement // 3 téléportation
        private (int, int) _pos_tab;

        public Objet(Point pos, int score, bool dragonBall, (int, int) pos_tab, byte boost = 0)
        {
            _position = pos;
            _valeur_score = score;
            _dragon_ball = dragonBall;
            _boost = boost;
            _pos_tab = pos_tab;
        }

        // getters

        public (int, int) pos_tab { get { return _pos_tab; } }

        public int valeur_score { get { return _valeur_score; } }

        public bool dragon_ball { get { return _dragon_ball; } }

        public byte boost { get { return _boost; } }

        public Point position { get { return _position; } }
    }
}
