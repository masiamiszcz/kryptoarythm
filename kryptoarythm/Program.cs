
//Maciej Kubacka
//ISS 
//15436


using System.Text;

namespace kryptoarythm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Tablica przechowująca 7 unikalnych cyfr (A-G)
            int[] tab = new int[8];

            // Zbiór do przechowywania wygenerowanych kombinacji
            HashSet<string> kombinacje = new HashSet<string>();

            // Lista dostępnych cyfr
            List<int> availableints = new List<int>();
            availableints = Enumerable.Range(0,10).ToList();

            //Generator liczb losowych
            Random random = new Random();

            // Główna pętla programu
            bool prawda = true;
            while (prawda)
            {

                // Pętla generująca unikalną kombinację cyfr
                bool jest = true;
                while (jest)
                {
                    if(kombinacje.Count == 3628000) break;

                    //Kopiowanie Listy dostępnych cyfr, aby nie usunąć oryginalnej listy
                    List<int> ints = new List<int>(availableints);

                    StringBuilder tablica = new StringBuilder();

                    // Losowanie unikalnych cyfr i ich dodanie do tablicy `tab`
                    for (int i = 0; i < 8; i++)
                    {
                        int losindex = random.Next(ints.Count);
                        int los = ints[losindex];
                        ints.RemoveAt(losindex);
                        tab[i] = los;
                        tablica.Append(los);
                    }
                    //Sprawdzanie unikalności kombinacji
                    if (!kombinacje.Contains(tablica.ToString()))
                    {
                        kombinacje.Add(tablica.ToString()); jest = false;
                    }
                    else
                    {
                        continue;
                    }
                }

                if (kombinacje.Count == 3628000) 
                {
                    Console.WriteLine("osiągnięto 3628000 kombinacji, 100% możliwych kombinacji");
                    kombinacje.Clear();
                } 

                int A = tab[0], B = tab[1], C = tab[2], D = tab[3], E = tab[4], F = tab[5], G = tab[6], H = tab[7];

                int ABCDE = A * 10000 + B * 1000 + C * 100 + D * 10 + E;
              
                int ABCDE_A = ABCDE * A;

                //Sprawdzanie warunków zadania
                if (ABCDE_A.ToString().Length == 6)
                {
                    if (ABCDE_A.ToString()[2] == H.ToString()[0]) 
                    {
                        int ABCDE_G = ABCDE * G;
                        if (ABCDE_G.ToString().Length == 5)
                        {

                            if (ABCDE_G.ToString()[0] == B.ToString()[0] && ABCDE_G.ToString()[1] == B.ToString()[0])
                            {

                                int ABCDE_F = ABCDE * F;

                                if (ABCDE_F.ToString().Length == 6)
                                {

                                    if (ABCDE_F.ToString()[2] == H.ToString()[0])
                                    {

                                        int wynik = ABCDE_A + ABCDE_F * 100 + ABCDE_G * 10;

                                        if (wynik.ToString().Length == 8)
                                        {

                                            if (wynik.ToString()[1] == F.ToString()[0] && wynik.ToString()[5] == D.ToString()[0])
                                            {

                                                //Wypisanie wynik, komibinacji i przerwanie pętli
                                                Console.WriteLine($"A: {A}, B: {B}, C: {C}, D: {D}, E: {E}, F: {F}, G: {G} H: {H}");
                                                Console.WriteLine("wynik: " + wynik);
                                                prawda = false;
                                            }
                                            else
                                            {
                                                //Console.WriteLine("7");
                                                continue;
                                            }
                                        }
                                        else
                                        {
                                            //Console.WriteLine("6");
                                            continue;
                                        }
                                    }
                                    else
                                    {
                                        //Console.WriteLine("5");
                                        continue;
                                    }
                                }
                                else
                                {
                                    //Console.WriteLine("4");
                                    continue;
                                }
                            }
                            else
                            {

                                //Console.WriteLine("3");
                                continue;
                            }
                        }
                        else
                        {
                            //Console.WriteLine("2");
                            continue;
                        }
                    }
                    else
                    {
                        Console.WriteLine("1.2");
                        continue;
                    }
                }
                else
                {
                    //Console.WriteLine("1");
                    continue;
                }

            }
        }
    }
}
