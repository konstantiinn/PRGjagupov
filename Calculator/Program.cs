using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2023-2024.
 * Extended by students.
 */

namespace Calculator
{
    internal class Program
    {
        
        
        static void Main(string[] args)
        {

            bool ukoncit = false;
            while (!ukoncit)
            {
                Console.WriteLine("Vítejte v kalkulačce!");
                Console.WriteLine("Vyberte operaci:");
                Console.WriteLine("1 - Sčítání");
                Console.WriteLine("2 - Odčítání");
                Console.WriteLine("3 - Násobení");
                Console.WriteLine("4 - Dělení");
                Console.WriteLine("5 - Mocnina");
                Console.WriteLine("6 - Odmocnina");
                Console.WriteLine("7 - Převod mezi soustavami");
                Console.WriteLine("8 - Konec");
                Console.WriteLine('\n');

                int volba = Convert.ToInt32(Console.ReadLine());

                switch (volba)
                {
                    case 1:
                        Secti();
                        break;
                    case 2:
                        Odecti();
                        break;
                    case 3:
                        Vynasob();
                        break;
                    case 4:
                        Vydel();
                        break;
                    case 5:
                        Mocnina();
                        break;
                    case 6:
                        Odmocnina();
                        break;
                    case 7:
                        PrevodMeziSoustavami();
                        break;
                    case 8:
                        ukoncit = true;
                        break;
                    default:
                        Console.WriteLine("Neplatná volba. Zadejte číslo od 1 do 8.");
                        break;
                }
            }
        }

        static void Secti()
        {
            Console.Write("Zadejte první číslo: ");
            double cisloA = Convert.ToDouble(Console.ReadLine());
            Console.Write("Zadejte druhé číslo: ");
            double cisloB = Convert.ToDouble(Console.ReadLine());
            double vysledek = cisloA + cisloB;
            Console.WriteLine("Výsledek: " + vysledek);
        }

        static void Odecti()
        {
            Console.Write("Zadejte první číslo: ");
            double cisloA = Convert.ToDouble(Console.ReadLine());
            Console.Write("Zadejte druhé číslo: ");
            double cisloB = Convert.ToDouble(Console.ReadLine());
            double vysledek = cisloA - cisloB;
            Console.WriteLine("Výsledek: " + vysledek);
        }

        static void Vynasob()
        {
            Console.Write("Zadejte první číslo: ");
            double cisloA = Convert.ToDouble(Console.ReadLine());
            Console.Write("Zadejte druhé číslo: ");
            double cisloB = Convert.ToDouble(Console.ReadLine());
            double vysledek = cisloA * cisloB;
            Console.WriteLine("Výsledek: " + vysledek);
        }

        static void Vydel()
        {
            Console.Write("Zadejte první číslo: ");
            double cisloA = Convert.ToDouble(Console.ReadLine());
            Console.Write("Zadejte druhé číslo: ");
            double cisloB = Convert.ToDouble(Console.ReadLine());

            if (cisloB == 0)
            {
                Console.WriteLine("Nelze dělit nulou.");
            }
            else
            {
                double vysledek = cisloA / cisloB;
                Console.WriteLine("Výsledek: " + vysledek);
            }
        }

        static void Mocnina()
        {
            Console.Write("Zadejte základ: ");
            double zaklad = Convert.ToDouble(Console.ReadLine());
            Console.Write("Zadejte exponent: ");
            double exponent = Convert.ToDouble(Console.ReadLine());
            double vysledek = Math.Pow(zaklad, exponent);
            Console.WriteLine("Výsledek: " + vysledek);
        }

        static void Odmocnina()
        {
            Console.Write("Zadejte číslo: ");
            double cislo = Convert.ToDouble(Console.ReadLine());
            if (cislo >= 0)
            {
                double vysledek = Math.Sqrt(cislo);
                Console.WriteLine("Výsledek: " + vysledek);
            }
            else
            {
                Console.WriteLine("Odmocnina záporného čísla není definována v reálných číslech.");
            }
        }

        static void PrevodMeziSoustavami() // tady ten kousek jsem se hodne radil s OpenAI, ale snad uz tomu rozumim i ja sam :) (nevim jestli mi to uznas za spravne, ale hodil jsem to sem protoze to je mozne rozsireni ty kalkulacky)
        {
            Console.Write("Zadejte číslo: ");
            string cislo = Console.ReadLine();
            Console.Write("Zadejte výchozí soustavu (2 pro binární, 8 pro oktální, 16 pro hexadecimální): ");
            int zakladniSoustava = Convert.ToInt32(Console.ReadLine());
            Console.Write("Zadejte cílovou soustavu (2 pro binární, 8 pro oktální, 16 pro hexadecimální): ");
            int cilovaSoustava = Convert.ToInt32(Console.ReadLine());

            try
            {
                int desitkovaHodnota = Convert.ToInt32(cislo, zakladniSoustava);
                string vysledek = Convert.ToString(desitkovaHodnota, cilovaSoustava);
                Console.WriteLine("Výsledek: " + vysledek);
            }
            catch (FormatException)
            {
                Console.WriteLine("Neplatný vstup.");
            }
        }
    }




    
}

            /*
             * Pokud se budes chtit na neco zeptat a zrovna budu pomahat jinde, zkus se zeptat ChatGPT ;) - https://chat.openai.com/
             * 
             * ZADANI
             * Vytvor program ktery bude fungovat jako kalkulacka. Kroky programu budou nasledujici:
             * 1) Nacte vstup pro prvni cislo od uzivatele (vyuzijte metodu Console.ReadLine() - https://learn.microsoft.com/en-us/dotnet/api/system.console.readline?view=netframework-4.8.
             * 2) Zkonvertuje vstup od uzivatele ze stringu do integeru - https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/types/how-to-convert-a-string-to-a-number.
             * 3) Nacte vstup pro druhe cislo od uzivatele a zkonvertuje ho do integeru. (zopakovani kroku 1 a 2 pro druhe cislo)
             * 4) Nacte vstup pro ciselnou operaci. Rozmysli si, jak operace nazves. Muze to byt "soucet", "rozdil" atd. nebo napr "+", "-", nebo jakkoliv jinak.
             * 5) Nadefinuj integerovou promennou result a prirad ji prozatimne hodnotu 0.
             * 6) Vytvor podminky (if statement), podle kterych urcis, co se bude s cisly dit podle zadane operace
             *    a proved danou operaci - https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/selection-statements.
             * 7) Vypis promennou result do konzole
             * 
             * Mozna rozsireni programu pro rychliky / na doma (na poradi nezalezi):
             * 1) Vypis do konzole pred nactenim kazdeho uzivatelova vstupu co po nem chces
             * 2) a) Kontroluj, ze uzivatel do vstupu zadal, co mel (cisla, popr. ciselnou operaci). Pokud zadal neco jineho, napis mu, co ma priste zadat a program ukoncete.
             * 2) b) To same, co a) ale misto ukonceni programu opakovane cti vstup, dokud uzivatel nezada to, co ma
             *       - https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/iteration-statements#the-while-statement
             * 3) Umozni uzivateli zadavat i desetinna cisla, tedy prekopej kalkulacku tak, aby umela pracovat s floaty
             */

            //Tento komentar smaz a misto nej zacni psat svuj prdacky kod.

             //Toto nech jako posledni radek, aby se program neukoncil ihned, ale cekal na stisk klavesy od uzivatele.
      

