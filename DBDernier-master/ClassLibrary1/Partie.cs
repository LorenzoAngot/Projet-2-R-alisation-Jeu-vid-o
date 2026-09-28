using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClassLibrary1
{
    public class Partie
    {
        private byte _niveau_partie;
        private Joueur _Goku;
        private int _score;
        private byte _nb_db = 0;
        private byte _touches;
        private byte _nb_ennemis_mort = 0;
        private List<Objet> _objets;
        private List<Ennemi> _ennemis;
        private List<Objet> _objet_a_supprimer;
        private List<Ennemi> _ennemi_a_supprimer;
        private string _pseudo;
        private byte _difficulte;
        private Carte _carte;
        private byte _une_seule_fois_transformé = 0;
        private Ennemi _ennemi_etourdi;
        private bool _etourdi = false; // ennemi étourdi
        private byte _timer_etourdi = 5;
        private byte _timer_boost = 5;
        private bool _attaque_en_cours = false;
        private Ennemi _celui_qui_attaque;
        // rajouter les temps des timer

        public Partie(Carte carte, string pseudo, byte touches = 0, byte difficulte = 0, byte niveau_partie = 1, int score = 0)
        {
            _touches = touches;
            _niveau_partie = niveau_partie;
            _score = score;
            _objets = new List<Objet>();
            _ennemis = new List<Ennemi>();
            _ennemi_a_supprimer = new List<Ennemi>();
            _objet_a_supprimer = new List<Objet>();
            _pseudo = pseudo;
            _difficulte = difficulte;
            _carte = carte;
            // ennemi par "défaut"
            Point pos = new Point(0, 0);
            _ennemi_etourdi = new Ennemi("defaut", pos, (-1, -1));
            _celui_qui_attaque = _ennemi_etourdi;
            // joueur par défaut
            _Goku = new Joueur("defaut", pos, (-10,-10));
        }

        // getters

        public byte timer_boost { get { return _timer_boost; } set { _timer_boost = value; } }
        public bool attaque_en_cours { get { return _attaque_en_cours; } set { _attaque_en_cours = value; } }
        public Ennemi ennemi_etourdi { get { return _ennemi_etourdi; } }
        public byte timer_etourdi { get { return _timer_etourdi; } set { _timer_etourdi = value; } }
        public bool etourdi { get { return _etourdi; } set { _etourdi = value; } }
        public byte nb_db { get { return _nb_db; } }
        public byte niveau_partie { get { return _niveau_partie; } }
        public byte transforme { get { return _une_seule_fois_transformé; } set { _une_seule_fois_transformé = value; } }
        public List<Ennemi> ennemis_a_supprimer { get { return _ennemi_a_supprimer; } }
        public List<Objet> objets_a_surrpimer { get { return _objet_a_supprimer; } }
        public Joueur Goku { get { return _Goku; } set { _Goku = value; } }
        public List<Ennemi> ennemis { get { return _ennemis; } }
        public List<Objet> objets { get { return _objets; } }
        public string pseudo { get { return _pseudo; } }
        public int score { get { return _score; } }
        public byte touches { get { return _touches; } }
        public byte difficulte { get { return _difficulte; } }


        public void Moins1TimerEtourdi()
        {
            _timer_etourdi -= 1;
            if (_timer_etourdi == 0)
            {
                _ennemis.Add(_ennemi_etourdi);
                Point pos = new Point(0, 0);
                // ennemi par "défaut" pour pouvoir faire les tests 
                _ennemi_etourdi = new Ennemi("defaut", pos, (-1, -1));
                // remettre img
            }
        }
        public byte VerifPosJoueurEnnemi()
        {
            byte result = 4;
            foreach (Ennemi ennemi in _ennemis)
            {
                // si même pos et pas d'étourdissement dispo
                if (_Goku.position == ennemi.position && !_Goku.nyobo)
                {
                    // si Goku n'est pas invincible
                    if (!_Goku.invincible)
                    {
                        result = 0; // result = 0 --> prendre un dégat
                        if (_Goku.PerdreVie())
                        {
                            // 1= mourir
                            result = 1;
                        }
                        break; // re init pos entités
                    }
                    // sinon je tue un ennemi
                    else
                    {
                        _ennemi_a_supprimer.Add(ennemi);
                        _nb_ennemis_mort++;
                        _score += 2000;
                        if (_nb_ennemis_mort == 4)
                        {
                            _niveau_partie++;
                            result = 2; break;
                            // on sort de la boucle car c'est fini on a gagné
                        }
                    }
                }
                else if (_Goku.position == ennemi.position && _Goku.nyobo) // si même pos et étourdissement disponible
                {
                    _ennemi_etourdi = ennemi;
                    _etourdi = true;
                }
            }
            // si ennemi étourdit tué --> ennemi étourdi n'est plus dans la liste des ennemis pour bloquer son mouvement
            if (_ennemi_etourdi.position == _Goku.position && _Goku.invincible)
            {
                _ennemi_a_supprimer.Add(_ennemi_etourdi);
                _nb_ennemis_mort++;
            }

            // suppression système de l'ennemi tué ou étourdi
            // on supprimer après car on ne peut pas pendant la boucle
            // c'est ici que sert l'ennemi par défaut car sinon l'ennemi étourdit n'est jamais reset 
            if (_ennemis.Contains(_ennemi_etourdi))
            {
                _ennemis.Remove(_ennemi_etourdi);
            }
            foreach (Ennemi ennemi1 in _ennemi_a_supprimer)
            {
                ennemis.Remove(ennemi1);
            }

            // si j'ai prit un dégat les positions sont réinitialisées
            if (result == 0)
            {
                foreach (Ennemi ennemi in _ennemis)
                {
                    ennemi.position = ennemi.pos_init;
                }
                _Goku.position = _Goku.pos_init;
            }
            return result;
        }

        public byte VerifPosJoueurObjet()
        {
            // nouvel instance pour supprimer les anciens objets qui étaient dans la liste
            _objet_a_supprimer = new List<Objet>();
            byte result = 0;
            foreach (Objet objet in _objets)
            {
                // on ne récupère par un objet quand un étourdissement est disponible
                if (_Goku.position == objet.position && !_Goku.nyobo)                                                                 
                {
                    _objet_a_supprimer.Add(objet); // peut pas supprimer en pleine boucle 
                    // si l'objet n'est pas une DB
                    if (!objet.dragon_ball)
                    {
                        _score += objet.valeur_score;
                        // si invincible on ne récupère pas de boost seulement le score
                        if (!_Goku.invincible)
                        {
                            result = objet.boost;
                        }
                    }
                    else
                    {
                        _nb_db += 1;
                        _score += objet.valeur_score;
                    }
                }
            }
            foreach (Objet objet in _objet_a_supprimer)
            {
                _objets.Remove(objet);
            }
            return result;
        }

        public bool VerifNbDb()
        {
            if (_nb_db == 7 && _une_seule_fois_transformé == 0)
            {
                _Goku.invincible = true;
                _une_seule_fois_transformé = 1;
                return true;
            }
            return false;
        }

        public void AttaqueEnnemis(Ennemi a)
        {
            if (!_attaque_en_cours)
            {
                if (nb_db > 3)
                {
                    // ennemi et joueur sur la même colonne
                    if (a.position.X == _Goku.position.X)
                    {
                        // joueur en haut ennemi
                        if (a.position.Y > _Goku.position.Y)
                        {
                            a.attaque_en_cours = 1;
                            a.attaque = true;
                            _attaque_en_cours = true;
                        }
                        // joueur en bas ennemi
                        else
                        {
                            a.attaque_en_cours = 2;
                            a.attaque = true;
                            _attaque_en_cours = true;
                        }
                    }
                    // sur la même ligne
                    else if (a.position.Y == _Goku.position.Y)
                    {
                        // joueur gauche de ennemi
                        if (a.position.X > _Goku.position.X)
                        {
                            a.attaque_en_cours = 3;
                            a.attaque = true;
                            _attaque_en_cours = true;
                        }
                        // joueur à droite de ennemi
                        else
                        {
                            a.attaque_en_cours = 4;
                            a.attaque = true;
                            _attaque_en_cours = true;
                        }
                    }
                    else
                    {
                        a.attaque_en_cours = 0;
                    }
                }
            }
        }

        public Ennemi UnSeulEnnemiAttque()
        {
            foreach (Ennemi a in _ennemis)
            {
                if (a.attaque_en_cours != 0)
                {
                    _celui_qui_attaque = a;
                    return a;
                }
            }
            // renvoie un ennemi qui ne peut pas attaquer
            Point point = new Point();
            Ennemi temp = new Ennemi("truc", point, (-100, -100));
            return temp;
        }

        public (bool, bool) VerifJoueurKikoha()
        {
            if (_celui_qui_attaque.pos_attaque == _Goku.position && !_Goku.invincible)
            {
                foreach (Ennemi ennemi in _ennemis)
                {
                    ennemi.position = ennemi.pos_init;
                }
                _Goku.position = _Goku.pos_init;
                // Item1 = prendre un dégat ou non, Item2 = mourir ou non
                return (true, _Goku.PerdreVie());
            }
            return (false, false);
        }

        public void DeplacementEnnemis()
        {
            foreach (Ennemi ennemi in _ennemis)
            {
                ennemi.Deplacement(_carte.Map);
            }
        }
    }
}

