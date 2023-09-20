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

        static int Plus(int x, int y) {
            int res = x + y;    
            return res;
            
        }
        static int Minus(int x, int y)
        {

            return x - y;
        }
        static int Krat(int x, int y)
        {

            return x * y;
        }
        static double Deleno(double x, double y)
        {
            double res;
            res = x / y;
            return res;
        }
        
        
        static void Main(string[] args)
        {
            int res = 0;
            string a, b;
            string z;
            int o = 4;
            int q=0,w=0,e=0;
            
            string[] kontrola1 = {"0","1","2","4","5","6","7","8","9"};
            char[] kontrola2 = { '+', '-', '*', '/' };
            bool read = true;
            while (read)
            {
                Console.WriteLine("Zadejte prvni cislo: ");
                a = Console.ReadLine();
                bool isNumber = double.TryParse(a, out double result);
                while (!isNumber)
                {
                    Console.WriteLine("Prosim zadejte CISLO:");
                    a = Console.ReadLine();
                    isNumber = double.TryParse(a, out result);

                }
                Console.WriteLine("Zadejte druhe cislo: ");
                b = Console.ReadLine();
                bool isNumber1 = double.TryParse(a, out double result1);

                while (!isNumber1)
                {
                    Console.WriteLine("Prosim zadejte CISLO:");
                    b = Console.ReadLine();
                    isNumber1 = double.TryParse(a, out result1);

                }
                Console.WriteLine("Zadejte znak operace: ");
                z = Console.ReadLine();
                bool isZnak = char.TryParse(a, out char result2);

                while (!isZnak)
                {
                    Console.WriteLine("Prosim zadejte ZNAK:");
                    z = Console.ReadLine();
                    isZnak = char.TryParse(a, out result2);
                }

                switch (Convert.ToChar(z))
                {
                    case '+':
                        Console.WriteLine(Plus(Convert.ToInt32(a), Convert.ToInt32(b)));
                        
                        break;
                    case '-':
                        Console.WriteLine(Minus(Convert.ToInt32(a), Convert.ToInt32(b)));
                        break;
                    case '*':
                        Console.WriteLine(Krat(Convert.ToInt32(a), Convert.ToInt32(b)));
                        break;
                    case '/':
                        Console.WriteLine(Deleno(Convert.ToDouble(a), Convert.ToDouble(b)));
                        break;
                }



            }
            Console.ReadKey();
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
        }
    }

