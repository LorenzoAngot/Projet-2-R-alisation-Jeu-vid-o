
using MySql.Data.MySqlClient;
using System;
using System.Runtime.Intrinsics.Arm;
using static System.Formats.Asn1.AsnWriter;

namespace ClassLibrary1
{
    public static class BD
    {
        private static MySqlConnection conn;

        public static void Connexion()
        {
            string serveur = "10.1.238.173";
            string login = "c1";
            string mdp = "groupeC1";
            string bd = "basec1";

            string chaineConnexion = $"server={serveur};uid={login};pwd={mdp};database ={bd}";
            // Tentative d'accès à la BD
            try
            {
                conn = new MySqlConnection(chaineConnexion);
                conn.Open();
            }
            catch (MySqlException ex)
            {
                // Affiche le code d'erreur et le message explicatif
                Console.WriteLine($"Erreur MySQL ({ex.Number}) : {ex.Message}");
            }
        }

        public static bool Deconnexion()
        {
            // si accès à la BD est ok alors on peut fermer 
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
                conn.Dispose();
                return true;
            }
            return false;
        }

        public static void Delete()
        {
            try
            {
                string req = $"DELETE FROM Classement WHERE Score=908009070090400";
                MySqlCommand cmd = new MySqlCommand(req, conn);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch { }
        }

        public static void Insertion(string pseudo, int score, int pos)
        {
            // insertion du score du joueur dans la BD
            try
            {
                string req = $"INSERT INTO Classement (Cla_pseudo_joueur, Score, Position_clas) VALUES ('{pseudo}',{score}, {pos})";
                MySqlCommand cmd = new MySqlCommand(req, conn);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch { }
        }

        public static string[,] AfficherClassement()
        {
            // enregistrement des données des 10 premiers dans la table Classement
            string req = "SELECT * FROM Classement ORDER BY score DESC";
            string[,] result = new string[10,2];
            int i = 0, j = 0;
            MySqlCommand cmd = new MySqlCommand(req, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            try
            {
                while (rdr.Read())
                {
                    //result += rdr.GetInt32(0).ToString() + " ";
                    result[i, j] += rdr.GetString(1);
                    j++;
                    result[i, j] += rdr.GetInt32(2).ToString();
                    //result[i, j] += rdr.GetInt32(3).ToString();
                    if (i != 9)
                    {
                        i++;
                    }
                    j--;
                }
                rdr.Close();
                rdr.Dispose();   
            }
            catch {}
            return result;
        }
    }
}

