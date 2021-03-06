﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanMaster
{
    class Program
    {
        static void Main(string[] args)
       {
            int i;
            int num;
            string log;
            string pass;
            string linijka;
            string linijka1;
            int count = 0;

            try
            {
                for (i = 0; i < 1; i++)
                {

                    do
                    {
                        Console.WriteLine("Logowanie - wciśnij 1");
                        Console.WriteLine("Rejestracja - wciśnij 2");
                        num = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();


                        switch (num)
                        {

                            case 1:

                                Console.WriteLine("Podaj swój Login");
                                log = Console.ReadLine();

                                using (StreamReader streamR = new StreamReader("login.txt"))
                                {
                                    
                                    while ((linijka = streamR.ReadLine()) != log)
                                    {
                                    }
                                   
                                }

                                Console.WriteLine("Podaj swoje hasło");
                                pass = Console.ReadLine();

                                using (StreamReader streamR = new StreamReader("password.txt"))
                                {
                                    
                                    while ((linijka1 = streamR.ReadLine()) != pass)
                                    {
                                    }
                                }

                                Console.Clear();

                                if (log == linijka && pass == linijka1)
                                {
                                    Console.WriteLine("Poprawnie zalogowano");
                                    count--;
                                    MainMenu();
                                }
                                else
                                {
                                    Console.WriteLine("Złe hasło lub login");
                                    count++;
                                }
                                break;

                            case 2:

                                Console.WriteLine("Podaj login");
                                using (StreamWriter streamW = new StreamWriter(("login.txt"), true))
                                {
                                    string text = Console.ReadLine();
                                    streamW.WriteLine(text); 
                                }
                                Console.WriteLine("Podaj hasło");
                                using (StreamWriter streamW = new StreamWriter(("password.txt"), true))
                                {
                                    string text = Console.ReadLine();

                                    streamW.WriteLine(text);
                                }
                                Console.Clear();
                                count++;
                                break;

                            default:
                                Console.WriteLine("Błędna wartość");
                                count++;
                                break;
                        }

                    } while (count > 0);
                }
            }
            catch (Exception s)
            {
                Console.WriteLine(s.Message);
                Console.ReadKey();
                Console.Clear();
                Main(null);
            }

        }
        public static void MainMenu()
        {

            try
            {

                for (int i = 0; i < 1; i++)
                {

                    Console.WriteLine("");
                    Console.WriteLine("Witaj w Plan Master!");
                    Console.WriteLine("Plany treningowe - wciśnij 1");
                    Console.WriteLine("Kalkulatory kalorii - wciśnij 2");
                    Console.WriteLine("Plany żywienia - wciśnij 3");
                    Console.WriteLine("");

                    int num = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();

                    switch (num)
                    {
                        case 1:
                            PlanMenu();
                            break;
                        case 2:
                            CalcMenu();
                            break;
                        case 3:
                            Console.WriteLine("test"); //in progress
                            break;
                        default:
                            Console.WriteLine("Błędna wartość");
                            break;
                    }
                }
            }
            catch (Exception s)
            {
                Console.WriteLine(s.Message);
                Console.ReadKey();
                Console.Clear();
                MainMenu();
            }
        }

        public static void PlanMenu()
        {

            Console.Write("Wybierz dwolony plan treningowy: ");
            Console.WriteLine();
            Console.WriteLine("Wybierz plan treningowy: ");
            Console.WriteLine("");
            Console.WriteLine("Plan na trzy dni - wciśnij 1");
            Console.WriteLine("Plan na cztery dni - wciśnij 2");
            Console.WriteLine("Plan na pięć dni - wciśnij 3");  
            Console.WriteLine("");

            int num = Convert.ToInt32(Console.ReadLine());

            switch (num)
            {
                case 1:
                    ThreeDaysPlan();

                    break;

                case 2:
                    FourDaysPlan();

                    break;

                case 3:
                    FiveDaysPlan();

                    break;

                default:
                    Console.WriteLine("Błędna wartość");
                    PlanMenu();
                    break;
            }
        }

        static void ThreeDaysPlan()
        {
            Console.WriteLine("Plan na trzy dni");


        }
        static void FourDaysPlan()
        {
            Console.WriteLine("Plan na cztery dni");


        }

        static void FiveDaysPlan()
        {
            Console.WriteLine("Plan na pięć dni");


        }
        public static void CalcMenu()
        {
            Console.WriteLine("Kalkulator podstawowej przemiany materii (BMR) - wciśnij 1");
            Console.WriteLine("Kalkulator całkowitej przemiany materii (CPM) - wciśnij 2");
            int num = Convert.ToInt32(Console.ReadLine());

            switch (num)
            {
                case 1:
                    BmrSexMenu();
                    break;

                case 2:
                    CpmSexMenu();
                    break;

                default:
                    Console.WriteLine("Błędna wartość");
                    CalcMenu();
                    break;
            }
        }

        public static void BmrSexMenu()
        {
            Console.WriteLine("Jestes mężczyzną - wciśnij 1");
            Console.WriteLine("Jestes kobietą - wciśnij 2");
            Console.WriteLine("Cofnij - wciśnij 3");


            int num = Convert.ToInt32(Console.ReadLine());

            switch (num)
            {
                case 1:
                    Console.WriteLine(MenCalculator() + " kcal");
                    break;
                case 2:
                    Console.WriteLine(WomenCalculator() + "kcal");
                    break;
                case 3:
                    CalcMenu();
                    break;
                default:
                    Console.WriteLine("Błędna wartość");
                    BmrSexMenu();
                    break;
            }
        }

        public static double MenCalculator()
        {
            Console.WriteLine("Podaj swój wiek");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Podaj Swoją wagę");
            double kg = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Podaj swoj wzrost (w cm)");
            double height = Convert.ToDouble(Console.ReadLine());

            double bmr = (9.99 * kg) + (6.25 * height) - (4.92 * age) + 5;

            return bmr;
        }

        public static double WomenCalculator()
        {
            Console.WriteLine("Podaj swój wiek");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Podaj Swoją wagę (w kg)");
            double kg = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Podaj swoj wzrost (w cm)");
            double height = Convert.ToDouble(Console.ReadLine());

            double bmr = (9.99 * kg) + (6.25 * height) - (4.92 * age) - 161;

            return bmr;
        }


        public static void CpmSexMenu()
        {
            Console.WriteLine("Jestes mężczyzną - wciśnij 1");
            Console.WriteLine("Jestes kobietą - wciśnij 2");
            Console.WriteLine("Cofnij - wciśnij 3");


            int num = Convert.ToInt32(Console.ReadLine());

            switch (num)
            {
                case 1:
                    ActivityMen();
                    break;
                case 2:
                    ActivityWomen();
                    break;
                case 3:
                    CalcMenu();
                    break;
                default:
                    Console.WriteLine("Błędna wartość");
                    CpmSexMenu();
                    break;
            }
        }

        public static void ActivityMen()
        {
            Console.Write("Wybierz swoją aktywność:");
            Console.WriteLine("Brak aktywności, praca siedząca - wciśnij 1");
            Console.WriteLine("Niska aktywność (praca siedząca i 1-2 treningi w tygodniu) - wciśnij 2");
            Console.WriteLine("Średnia aktywność (praca siedząca i treningi 3-4 razy w tygodniu) - wciśnij 3");
            Console.WriteLine("Wysoka aktywność (praca fizyczna i 3-4 treningi w tygodniu) - wciśnij 4");
            Console.WriteLine("Bardzo wysoka aktywność (zawodowi sportowcy, osoby codziennie trenujące");
            int num = Convert.ToInt32(Console.ReadLine());

            switch (num)
            {
                case 1:
                    Console.WriteLine(MenCalculator() * 1.2 + " kcal");
                    break;
                case 2:
                    Console.WriteLine(MenCalculator() * 1.4 + " kcal");
                    break;
                case 3:
                    Console.WriteLine(MenCalculator() * 1.6 + " kcal");
                    break;
                case 4:
                    Console.WriteLine(MenCalculator() * 1.8 + " kcal");
                    break;
                case 5:
                    Console.WriteLine(MenCalculator() * 2 + " kcal");
                    break;

                default:
                    Console.WriteLine("Błędna wartość, wciśnij dowolny klawisz by powtórzyć");
                    Console.ReadKey();
                    ActivityMen();
                    break;
            }
        }
        public static void ActivityWomen()
        {
            Console.Write("Wybierz swoją aktywność:");
            Console.WriteLine("Brak aktywności, praca siedząca - wciśnij 1");
            Console.WriteLine("Niska aktywność (praca siedząca i 1-2 treningi w tygodniu) - wciśnij 2");
            Console.WriteLine("Średnia aktywność (praca siedząca i treningi 3-4 razy w tygodniu) - wciśnij 3");
            Console.WriteLine("Wysoka aktywność (praca fizyczna i 3-4 treningi w tygodniu) - wciśnij 4");
            Console.WriteLine("Bardzo wysoka aktywność (zawodowi sportowcy, osoby codziennie trenujące");
            int num = Convert.ToInt32(Console.ReadLine());

            switch (num)
            {
                case 1:
                    Console.WriteLine(WomenCalculator() * 1.2 + " kcal");
                    break;
                case 2:
                    Console.WriteLine(WomenCalculator() * 1.4 + " kcal");
                    break;
                case 3:
                    Console.WriteLine(WomenCalculator() * 1.6 + " kcal");
                    break;
                case 4:
                    Console.WriteLine(WomenCalculator() * 1.8 + " kcal");
                    break;
                case 5:
                    Console.WriteLine(WomenCalculator() * 2 + " kcal");
                    break;

                default:
                    Console.WriteLine("Błędna wartość, wciśnij dowolny klawisz by powtórzyć");
                    Console.ReadKey();
                    ActivityWomen();
                    break;
            }

        }
        public static void Target()
        {

        }

    }
}
