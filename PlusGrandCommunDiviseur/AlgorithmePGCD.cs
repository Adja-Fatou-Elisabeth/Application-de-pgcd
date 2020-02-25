using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace PlusGrandCommunDiviseur
{
    static class AlgorithmePGCD
    {
        // TODO Exercice 1, Tâche 1
        // Ajouter la méthode TrouverPGCDEuclide
        static int reste, sortir,x,res1, res2;
        static long duree;
        public static int TrouverPGCD(int a, int b,out long duree)
        {
            duree = 0;
            Stopwatch chrono = new Stopwatch();
            chrono.Start();
            if (a == 0)
            {
                return b;
            }
            else if (b == 0)
            {
                return a;
            }
            else
            {
                do
                {
                    if (a < b)
                    {
                        reste = b - a;
                        b = a;
                        a = reste;
                    }
                    else
                    {
                        reste = a - b;
                        a = b;
                        b = reste;
                    }
                    if (reste == 0)
                    {
                        if (b == 0) sortir = a;
                        else sortir = b;
                    }
                } while (reste != 0);
                chrono.Stop();
                duree = chrono.ElapsedTicks;
                return sortir;
            }
            
        }

        /*public static int TrouverPGCD3(int a, int b, int c) {
            x = TrouverPGCD(a, b);
            return TrouverPGCD(c,x);
        }
        public static int TrouverPGCD4(int a, int b, int c, int d)
        {
            res1 = TrouverPGCD3(a, b, c);
            return TrouverPGCD(res1, d,);
        }
        public static int TrouverPGCD5(int a, int b, int c, int d,int e)
        {
            res2 = TrouverPGCD4(a, b, c,d);
            return TrouverPGCD(res2, e);
        }*/


        public static int TrouverPGCDStein(int u,int v,out long duree)
        {
            duree = 0;
            Stopwatch chrono = new Stopwatch();
            chrono.Start();

            int k;

            // Etape 1.
            // pgcd(0, v) = v, car tout  divise zéro, 
            // et v est le plus grand nombre qui divise v. 
            // Idem, pgcd(u, 0) = u. pgcd(0, 0) n'est pas habituellement défini 
            // mais il est commode de poser pgcd(0, 0) = 0.
            if (u == 0 || v == 0)
                return u | v;

            // Etape 2.
            // Si u et v sont tous deux pairs, alors pgcd(u, v) = 2•pgcd(u/2, v/2), 
            // car 2 est un  diviseur commun. 
            for (k = 0; ((u | v) & 1) == 0; ++k)
            {
                u >>= 1;
                v >>= 1;
            }

            // Etape 3.
            // Si u est pair et v est impair, alors pgcd(u, v) = pgcd(u/2, v), 
            // car 2 n'est pas un  diviseur commun. 
            // Idem, si u est impair et v pair, 
            // alors pgcd(u, v) = pgcd(u, v/2). 
            while ((u & 1) == 0)
                u >>= 1;

            // Etape 4.
            // If u et v sont tous impairs, et u ≥ v, 
            // alors pgcd(u, v) = pgcd((u − v)/2, v). 
            // If tous sont impairs et u < v, alors pgcd(u, v) = pgcd((v − u)/2, u). 
            // Voila les combinaisons en une Etape de   
            //  l'algorithme Euclidien simple, 
            // qui utilise la soustraction à chaque Etape, et une application 
            // de l'Etape 3 ci-dessus. 
            // La division par 2 tombe sur un entier car la 
            // difference de deux nombres impairs  est paire.
            do
            {
                while ((v & 1) == 0)  // Boucle x
                    v >>= 1;

                //  u et v sont tous impairs, alors diff(u, v) est pair.
                //   Soit u = min(u, v) et v = diff(u, v)/2. 
                if (u < v)
                {
                    v -= u;
                }
                else
                {
                    int diff = u - v;
                    u = v;
                    v = diff;
                }
                v >>= 1;
                // Etape 5.
                // Répéter les Etapes 3–4 jusqu'à ce que u = v, ou (Etape supplémentaire) 
                // jusqu'à ce que u = 0.
                // Quelque soit le cas, le résultat est (2^k) * v, où k est 
                // le nombre de facteurs communs  de 2 trouvé à l'Etape 2. 
            } while (v != 0);

            u <<= k;
            chrono.Stop();
            duree = chrono.ElapsedTicks;
            return u;

                
        }


    }
}
