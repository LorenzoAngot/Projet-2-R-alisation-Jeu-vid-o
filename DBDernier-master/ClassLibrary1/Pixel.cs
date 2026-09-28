using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Pixel
    {
        private (int, int) position;
        private int _indice_voisins;
        private bool est_visite = false;
        private bool v_gauche; // voisin gauche
        private bool v_bas; // bas
        private bool v_droit; // droit
        private bool v_haut; // haut
        private List<Pixel> _liste_voisins_linked;
        private List<Pixel> _liste_voisins;
        private bool _occupe = false;

        public Pixel((int, int) pos, bool init_voisins)
        {
            this.position = pos;
            _liste_voisins = new List<Pixel>();
            _liste_voisins_linked = new List<Pixel>();
            this._indice_voisins = 0;
            this.v_bas = init_voisins;
            this.v_gauche = init_voisins;
            this.v_droit = init_voisins;
            this.v_haut = init_voisins;
        }

        // getters
        public bool occupe { get { return _occupe; } set { _occupe = value; } }

        // Méthode publique set_visite
        // Modifie la valeur de l'attribut est_visite à true
        public void set_visite(bool a)
        {
            this.est_visite = a;
        }

        // Méthode publique visite
        // Renvoie la valeur de l'attribut est_visite
        public bool visite()
        {
            return this.est_visite;
        }

        // Méthode publique get_pos
        // Renvoie la valeur de l'attribut position sous forme d'un tuple (int, int)
        public (int, int) get_pos()
        {
            return this.position;
        }

        // Méthode publique ajouter_voisin
        // Paramètre : Pixel p
        // Ajoute un autre pixel à la liste des voisins du pixel si cet autre pixel n'est pas déjà voisin du pixel
        public void ajouter_voisin(Pixel p)
        {
            if (this.est_voisin(p) is false) // vérification si le Pixel p n'est pas voisin avec le pixel qui invoque la méthode
            {
                if ((this.position.Item1 == p.position.Item1) && this.position.Item2 - 1 == p.position.Item2) // même ligne et p à gauche
                {
                    _liste_voisins.Add(p); // Ajoute le pixel à la position "indice_voisins"
                    this._indice_voisins++; // incrémente indice_voisins à +1
                }
                if ((this.position.Item1 == p.position.Item1) && this.position.Item2 + 1 == p.position.Item2) // même ligne et p à droite
                {
                    _liste_voisins.Add(p);
                    this._indice_voisins++;
                }
                if ((this.position.Item1 - 1 == p.position.Item1) && this.position.Item2 == p.position.Item2) // même colonne et p en bas
                {
                    _liste_voisins.Add(p);
                    this._indice_voisins++;
                }
                if ((this.position.Item1 + 1 == p.position.Item1) && this.position.Item2 == p.position.Item2) // même colonne et p en haut
                {
                    _liste_voisins.Add(p);
                    this._indice_voisins++;
                }
            }
        }

        // Méthode publique ajouter_lien
        // Paramètre : Pixel p 
        // Ajoute le pixel dans la liste des voisins liés si celui-ci est voisin
        // Enregistre la position du pixel ajouté en fonction du pixel de base --> à gauche, en bas, à droite ou en haut
        public void ajouter_lien(Pixel p)
        {
            if (this.est_voisin(p) is true) // vérification si le Pixel p est voisin avec le pixel qui invoque la méthode
            {
                _liste_voisins_linked.Add(p); // même système que pour les voisins
                if ((this.position.Item1 == p.position.Item1) && this.position.Item2 - 1 == p.position.Item2) // même ligne et p à gauche
                {
                    this.v_gauche = true;
                }
                if ((this.position.Item1 == p.position.Item1) && this.position.Item2 + 1 == p.position.Item2) // même ligne et p à droite
                {
                    this.v_droit = true;
                }
                if ((this.position.Item1 - 1 == p.position.Item1) && this.position.Item2 == p.position.Item2) // même colonne et p en haut
                {
                    this.v_haut = true;
                }
                if ((this.position.Item1 + 1 == p.position.Item1) && this.position.Item2 == p.position.Item2) // même colonne et p en bas
                {
                    this.v_bas = true;
                }
            }
        }

        // Méthode publique est_voisin
        // Paramètre : Pixel p
        // Renvoie si le pixel p est voisin avec le pixel qui invoque la méthode (true ou false)
        public bool est_voisin(Pixel p)
        {
            if (_liste_voisins.Contains(p)) // vérification si le pixel p est dans la liste des voisins 
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Méthode publique est_lie
        // Paramètre : Pixel p 
        // Renvoie si le pixel p est lié avec le pixel qui invoque la méthode (true ou false)
        public bool est_lie(Pixel p)
        {
            if (_liste_voisins_linked.Contains(p)) // vérification si le pixel p est dans la liste des voisins liés 
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Méthode publique renvoie_voisins
        // Renvoie la liste des voisins du pixel qui invoque la méthode
        public List<Pixel> renvoie_voisins()
        {
            return _liste_voisins;
        }

        // Méthode publique renvoie_lien
        // Renvoie la liste des voisins liés avec le pixel qui invoque la méthode
        public List<Pixel> renvoie_lien()
        {
            return _liste_voisins_linked;
        }

        // Méthode publique etat_lien
        // Renvoie sous la forme d'un tuple (bool, bool, bool, bool) l'état de chaque côté du pixel
        // Le côté est soit lié (true) soit non lié (false)
        public (bool, bool, bool, bool) etat_lien()
        {
            return (this.v_gauche, this.v_bas, this.v_droit, this.v_haut);
        }

        // Méthode publique set_lien
        // Paramètre : bool a
        //             bool b
        //             bool c
        //             bool d
        // Modifie la valeur des liens du pixel qui invoque la méthode grâce aux paramètres 
        public void set_lien(bool a, bool b, bool c, bool d)
        {
            this.v_gauche = a; this.v_bas = b; this.v_droit = c; this.v_haut = d;
        }

        // Méthode publique recopie_voisins_et_liens
        // Recopie la liste des voisins dans la liste des voisins liés
        // La liste des voisins liés est donc la même que celle des voisins
        public void recopie_voisins_et_liens()
        {
            _liste_voisins_linked = _liste_voisins;
        }

        // Méthode publique supprimer_liens
        // Paramètre : Pixel p
        // Permet de supprimer le lien entre le pixel p et le pixel qui invoque la méthode  si il existe un lien entre les 2
        public void supprimer_liens(Pixel p)
        {
            if (this.est_lie(p) is true) // vérification s'il existe un lien entre les 2
            {
                _liste_voisins_linked.Remove(p);
                if ((this.position.Item1 == p.position.Item1) && this.position.Item2 - 1 == p.position.Item2) // même ligne et p à gauche
                {
                    this.v_gauche = false; // on supprime le lien 
                }
                if ((this.position.Item1 == p.position.Item1) && this.position.Item2 + 1 == p.position.Item2) // même ligne et p à droite
                {
                    this.v_droit = false;
                }
                if ((this.position.Item1 - 1 == p.position.Item1) && this.position.Item2 == p.position.Item2) // même colonne et p en haut
                {
                    this.v_haut = false;
                }
                if ((this.position.Item1 + 1 == p.position.Item1) && this.position.Item2 == p.position.Item2) // même colonne et p en bas
                {
                    this.v_bas = false;
                }
            }
        }
    }
}
