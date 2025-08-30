using System.IO.Pipelines;

namespace TestNotationPolonaise
{
    class Program
    {
        /// <summary>
        /// Fonction du calcul de la formule polonaise
        /// </summary>
        /// <param name="formule">envoie de la formule</param>
        /// <returns>resultat de l'opération ( si erreur envoi de NaN )</returns>
        static float Polonaise(String formule)
        {
            try
            {
                string[] tab = formule.Split(' ');
                for (int i = tab.Length - 1; i >= 0; i--)
                {
                    if (tab[i] == "+" || tab[i] == "*" || tab[i] == "-" || tab[i] == "/")
                    {
                        switch (char.Parse(tab[i]))
                        {
                            case '+':
                                tab[i] = (float.Parse(tab[i + 1]) + float.Parse(tab[i + 2])).ToString();
                                break;
                            case '-':
                                tab[i] = (float.Parse(tab[i + 1]) - float.Parse(tab[i + 2])).ToString();
                                break;
                            case '*':
                                tab[i] = (float.Parse(tab[i + 1]) * float.Parse(tab[i + 2])).ToString();
                                break;
                            case '/':
                                if (tab[i + 1] == "0" || tab[i + 2] == "0")
                                {
                                    return float.NaN;
                                }
                                tab[i] = (float.Parse(tab[i + 1]) / float.Parse(tab[i + 2])).ToString();
                                break;
                            default:
                                break;
                        }
                        tab[i + 1] = " ";
                        tab[i + 2] = " ";
                        i = tab.Length;
                        for (int j = tab.Length - 2; j >= 0; j--)
                        {
                            if (tab[j] == " ")
                            {
                                string temp = tab[j];
                                tab[j] = tab[j + 1];
                                tab[j + 1] = temp;
                            }
                        }
                    }
                }
                return float.Parse(tab[0]);
            }
            catch (System.Exception)
            {
                return float.NaN;
                throw;
            }
        }
        /// <summary>
        /// saisie d'une réponse d'un caractère parmi 2
        /// </summary>
        /// <param name="message">message à afficher</param>
        /// <param name="carac1">premier caractère possible</param>
        /// <param name="carac2">second caractère possible</param>
        /// <returns>caractère saisi</returns>
        static char Saisie(string message, char carac1, char carac2)
        {
            char reponse;
            do
            {
                Console.WriteLine();
                Console.Write(message + " (" + carac1 + "/" + carac2 + ") ");
                reponse = Console.ReadKey().KeyChar;
            } while (reponse != carac1 && reponse != carac2);
            return reponse;
        }

        /// <summary>
        /// Saisie de formules en notation polonaise pour tester la fonction de calcul
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            char reponse;
            // boucle sur la saisie de formules
            do
            {
                Console.WriteLine();
                // Console.WriteLine("entrez une formule polonaise en séparant chaque partie par un espace = ");
                // String laFormule = Console.ReadLine();
                // affichage du résultat
                // Console.WriteLine("Résultat =  " + Polonaise(laFormule));
                Console.WriteLine("Résultat de \"0\" = " + Polonaise("0"));
                Console.WriteLine("Résultat de \"4\" = " + Polonaise("4"));
                Console.WriteLine("Résultat de \"+ 4 3\" = " + Polonaise("+ 4 3"));
                Console.WriteLine("Résultat de \"- 3 4\" = " + Polonaise("- 3 4"));
                Console.WriteLine("Résultat de \"- / 2 3 4\" = " + Polonaise("- / 2 3 4"));
                Console.WriteLine("Résultat de \"* + 4 3 5\" = " + Polonaise("* + 4 3 5"));
                Console.WriteLine("Résultat de \"/ 7 * + 4 3 - 10 8\" = " + Polonaise("/ 7 * + 4 3 - 10 8"));
                Console.WriteLine("Résultat de \"/ + * 4 - 2 6 + 5 3 10\" = " + Polonaise("/ + * 4 - 2 6 + 5 3 10"));
                Console.WriteLine("Résultat de \"* - 7 5 + 4 - 12 * 2 / 4 2\" = " + Polonaise("* - 7 5 + 4 - 12 * 2 / 4 2"));
                Console.WriteLine("Résultat de \"* - + - + / 2 4 12 2 5 3 3\" = " + Polonaise("* - + - + / 2 4 12 2 5 3 3"));
                Console.WriteLine();
                Console.WriteLine("Résultat de \"- 3\" = " + Polonaise("- 3"));
                Console.WriteLine("Résultat de \"+\" = " + Polonaise("+"));
                Console.WriteLine("Résultat de \"4 3\" = " + Polonaise("4 3"));
                Console.WriteLine("Résultat de \"4 + 3\" = " + Polonaise("4 + 3"));
                Console.WriteLine("Résultat de \"+ * 2 4\" = " + Polonaise("+ * 2 4"));
                Console.WriteLine("Résultat de \"/ 25 0\" = " + Polonaise("/ 25 0"));
                Console.WriteLine("Résultat de \"+ % 4 3 12\" = " + Polonaise("+ % 4 3 12"));
                Console.WriteLine("Résultat de \"+ 4  3\" = " + Polonaise("+ 4  3"));

                reponse = Saisie("Voulez-vous continuer ?", 'O', 'N');
            } while (reponse == 'O');
        }
    }
}
