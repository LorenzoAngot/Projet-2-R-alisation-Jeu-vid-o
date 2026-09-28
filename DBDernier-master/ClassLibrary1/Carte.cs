using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Carte
    {
        private readonly Pixel[,] _map; // La map est représentée par un tableau en 2 dimensions contenant des instances (objets) de la classe Pixel
                               // on peut supposer que cette structure de donnée s'apparente à une file puisque j'analyserai toujours le premier pixel qui est arrivé en premier (0,0)
                               // sauf dans le cas où on choisit un certain pixel
        private readonly int _n; // nombre de lignes
        private readonly int _m; // nombre de colonnes
        private readonly bool mode_avance; // défini si on utilise la méthode normale ou avancé pour générer le labyrinthe
        public Carte((int, int) taille, bool init_voisins)
        {
            this._map = new Pixel[taille.Item1, taille.Item2];
            this._n = taille.Item1;
            this._m = taille.Item2;
            this.mode_avance = init_voisins;
            for (int i = 0; i < taille.Item1; i++) // matrice avec n lignes 
            {
                for (int j = 0; j < taille.Item2; j++) // et m colonnes
                {
                    this._map[i, j] = new Pixel((i, j), init_voisins); // on position les pixels avec les mêmes coordonnées que sa position dans la map 
                }
            }
        }

        // getters
        public int N { get { return _n; } }
        public int M { get { return _m; } }
        public Pixel[,] Map { get { return _map; } }


        // Méthode publique tous_les_voisins 
        // Ajoute tous les voisins possible dans sa liste des voisins pour un pixel 
        // Permet de recopier cette liste de voisins dans la liste des voisins liés le mode "avancé" est utilisé
        // Permet donc l'initialisation du labyrinthe avec toutes les portes possibles
        public void tous_les_voisins(Pixel p)
        {
            for (int i = 0; i < this._n; i++) // Pour chaque pixel de la ligne i
            {
                for (int j = 0; j < this._m; j++) // Pour chaque pixel de la colonne j
                {
                    p.ajouter_voisin(this._map[i, j]); // ajout du voisin pour le Pixel p
                    this._map[i, j].ajouter_voisin(p); // ajout de Pixel p pour le voisin
                }
            }
            if (this.mode_avance is true)
            {
                p.recopie_voisins_et_liens(); // la liste des voisins liés est la même que la liste des voisins
            }
        }

        // Méthode init_voisins
        // Chaque pixel de la map est envoyé dans la méthode précédente pour ajouter tous ses voisins
        public void init_voisins()
        {
            for (int i = 0; i < this._n; i++) // Pour chaque pixel de la ligne i
            {
                for (int j = 0; j < this._m; j++) // Pour chaque pixel de la colonne j
                {
                    this.tous_les_voisins(this._map[i, j]); // appel de la méthode "tous_les_voisins" pour un pixel (x,y)
                }
            }
        }

        // Méthode publique inverse
        // Inverse les valeurs booléennes affectées dans v_gauche, v_bas, v_droit, v_haut de chaque pixel
        // Ainsi si un lien était true il se retrouve false et inversement
        public void inverse()
        {
            (bool, bool, bool, bool) etat;
            for (int i = 0; i < this._n; i++) // Pour chaque pixel de la ligne i
            {
                for (int j = 0; j < this._m; j++) // Pour chaque pixel de la colonne j
                {
                    etat = this._map[i, j].etat_lien(); // On récupère l'état des liens d'un pixel 
                    this._map[i, j].set_lien(!etat.Item1, !etat.Item2, !etat.Item3, !etat.Item4); // on inverse les valeurs booléennes 
                }
            }
        }

        // Méthode publique parcours_profondeur
        // Effectue un parcours en profondeur du labyrinthe initialisé avec toutes les portes possibles ou bien tous les murs
        public void parcours_profondeur()
        {
            Random random = new Random();
            Pile pile = new Pile(200); // Création d'une pile 
            int a = random.Next(this._n); // Choix aléatoire d'une ligne i sur la map 
            int b = random.Next(this._m); // Choix aléatoire d'une colonne j sur la map
            Pixel sommet_actuel = this._map[a, b]; // Pixel de départ aléatoire
            pile.empiler(sommet_actuel); // On met dans la pile le sommet de départ
            List<Pixel> voisins;
            while (pile.est_vide() is false) // tant que la pile n'est pas vide
            {
                sommet_actuel = pile.depiler(); // je récupère la valeur au sommet de la pile (elle n'est "plus dans la pile")
                if (sommet_actuel.visite() is false) // si le sommet actuel n'est pas visité alors
                {
                    sommet_actuel.set_visite(true); // je le visite
                    voisins = sommet_actuel.renvoie_voisins(); // on récupère sa liste de voisins
                    var truc = voisins.OrderBy(item => random.Next()); // trie aléatoire des voisins
                                                                       //Console.Write(sommet_actuel.get_pos()); afficher le parcours des sommets 

                    foreach (Pixel pixel in truc) // Pour chaque voisin
                    {
                        if (voisins is not null) // S'il n'est pas nul car liste plus grande que nécessaire
                        {
                            if (pixel.visite() is false && !pile.contient(pixel)) // si le voisin n'est pas visité et n'est pas déjà dans la pile
                            { // car plusieurs pixels peuvent avoir comme voisin ce pixel
                                if (this.mode_avance is false) // si le mode "normal" est choisit
                                {
                                    pixel.ajouter_lien(sommet_actuel); // on ajoute les liens entre les sommets
                                    sommet_actuel.ajouter_lien(pixel);
                                    pile.empiler(pixel); // on empile le voisin
                                }
                                else // si le mode "avancé" est choisit, donc il n'y a que des portes au début
                                {
                                    pixel.supprimer_liens(sommet_actuel); // je supprime les liens entre les pixels
                                    sommet_actuel.supprimer_liens(pixel);
                                    pile.empiler(pixel); // on empile le voisin
                                }
                            }
                        }
                    }
                }
            }
            if (this.mode_avance is true) // si c'est le mode "avancé"
            {
                this.inverse(); // j'inverse les valeurs booléennes des liens des pixels car
                                // en suivant ma méthode on se retrouve avec un "chemin de murs"
                                // ainsi si j'inverse les valeurs on obtient des murs à la place des portes et inversement
                                // on retrouve donc un chemin 
            }
        }

        public void parcours_profondeur_eulerien()
        {
            // essaye de rendre eulérien le graphe 

            Random random = new Random();
            Pile pile = new Pile(200);
            int a = random.Next(this._n);
            int b = random.Next(this._m);
            Pixel sommet_actuel = this._map[a, b];
            pile.empiler(sommet_actuel);
            List<Pixel> voisins_lies;
            while (pile.est_vide() is false)
            {
                List<Pixel> temp = new List<Pixel>();
                List<Pixel> temp2 = new List<Pixel>();
                sommet_actuel = pile.depiler();
                if (sommet_actuel.visite())
                {
                    sommet_actuel.set_visite(false);
                    voisins_lies = sommet_actuel.renvoie_voisins();
                    var truc = voisins_lies.OrderBy(item => random.Next());


                    foreach (Pixel pixel in truc)
                    {
                        if ((sommet_actuel.renvoie_lien().Count + temp.Count == 1) && !sommet_actuel.est_lie(pixel))
                        {
                            temp.Add(pixel);
                        }
                        else if ((sommet_actuel.renvoie_lien().Count + temp2.Count == 3) && sommet_actuel.est_lie(pixel) && pixel.renvoie_lien().Count == 3)
                        {
                            temp2.Add(pixel);
                        }

                        pile.empiler(pixel);
                    }

                    foreach (Pixel pixel in temp)
                    {
                        sommet_actuel.ajouter_lien(pixel);
                        pixel.ajouter_lien(sommet_actuel);
                    }
                    foreach (Pixel pixel in temp2)
                    {
                        sommet_actuel.supprimer_liens(pixel);
                        pixel.supprimer_liens(sommet_actuel);
                    }
                }
            }
        }
    }
}
