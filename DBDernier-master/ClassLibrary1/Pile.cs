using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Pile
    {
        private int indice;
        private int taille;
        private Pixel[] pile; // pile contenant des instances de la classe Pixel
        public Pile(int taille)
        {
            this.pile = new Pixel[taille]; // création de la pile
            this.indice = 0;
            this.taille = taille;
        }

        // Méthode publique empiler
        // Paramètre : Pixel a
        // Ajoute un Pixel dans la pile
        public void empiler(Pixel a)
        {
            if (this.est_pleine()) // si la pile est pleine alors
            {
                Console.WriteLine("Pile pleine");
                // puisque sinon nous serons dans exception Index out ouf range qui fera planter le programme
            }
            else
            {
                this.pile[this.indice] = a;  // on incrémente dans la pile à la position de l'indice le pixel p
                this.indice++; // indice + 1 sinon on n'avance jamais
            }
        }

        // Méthode publique dépiler
        // "Enlève" le dernier élément de la pile
        public Pixel depiler()
        {
            if (!this.est_vide()) // si l'indice n'est pas à 0
            {
                this.indice--; // on descend avant de renvoyer la valeur car l'indice à un coup d'avance sur la précédente position
                               // si la dernière valeur empiler est à l'indice 0, l'indice de la pile est à 1
                return this.pile[this.indice]; // on renvoie le Pixel
            }
            else
            {
                Console.WriteLine("Pile vide"); // on affiche un message d'erreur
                Pixel temp = new Pixel((-2, -2), false); // on retourne un pixel impossible à avoir en voisin
                return temp; // l'idéal est ici de faire un try/catch/throw pour éviter de renvoyer une valeur aberrante 
            }
        }

        // Méthode publique est_vide
        // Renvoie si la pile est vide (true) ou non (false)
        public bool est_vide()
        {
            if (this.indice == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Méthode publique est_pleine
        // Renvoie si la pile est pleine (true) ou non (false)
        public bool est_pleine()
        {
            if (this.indice == this.taille - 1) // Si l'indice = la taille - 1 de la pile car ça commence à 0 alors on renvoie true
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Méthode publique contient
        // Renvoie si la pile contient un pixel (true) ou non (false)
        public bool contient(Pixel p)
        {
            if (this.pile.Contains(p)) // On regarde si le pixel est dans pile (dans sa totalité)
            {
                for (int i = 0; i < this.indice; i++) // on parcours la pile jusqu'à son indice car le pixel peut être enregistré plus haut
                                                      // car on ne supprime par une valeur dans une pile
                {
                    if (this.pile[i] == p) // on regarde si le pixel p est dans la pile jusqu'à l'indice
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
