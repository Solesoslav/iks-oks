using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void IspisTable(int[,] xo)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    switch (xo[i, j])
                    {
                        case 1:
                            {
                                Console.Write(" x ");
                                break;
                            }
                        case 2:
                            {
                                Console.Write(" y ");
                                break;
                            }
                        default:
                            {
                                Console.Write("[ ]");
                                break;
                            }

                    }
                    if (j != 2)
                        Console.Write('|');
                }
                if (i!=2)
                    Console.WriteLine(Environment.NewLine + "---+---+---" /*+ Environment.NewLine*/); //mozda treba jos jedan Enviroment.NewLine na pocetku
            }

        }

        public int ProveraPobede(int[,] xo)  //moram da proverim sintaksu za ovo!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        {
            int rezd1 = 0;
            int rezd2 = 0;
                for (int i = 0; i < 3; i++)
                {
                    int rezx = 0;
                    for (int j = 0; j < 3; j++)
                    {
                        if (i==j)
                            switch (xo[i, j])
                            {
                                case 0:
                                    {
                                        rezd1 += 5;
                                        break;
                                    }
                                case 1:
                                    {
                                        rezd1 += 1;
                                        break;
                                    }
                                case 2:
                                    {
                                        rezd1 += 2;
                                        break;
                                    }
                            }
                        if ((i + j)==2)
                            switch (xo[i, j])
                            {
                                case 0:
                                    {
                                        rezd2 += 5;
                                        break;
                                    }
                                case 1:
                                    {
                                        rezd2 += 1;
                                        break;
                                    }
                                case 2:
                                    {
                                        rezd2 += 2;
                                        break;
                                    }
                            }

                        switch (xo[i, j])
                        {
                            case 0:
                                {
                                    rezx += 5;
                                    break;
                                }
                            case 1:
                                {
                                    rezx += 1;
                                    break;
                                }
                            case 2:
                                {
                                    rezx += 2;
                                    break;
                                }
                        }
                    }
                    switch (rezx)
                    {
                        case 3:
                            {
                                return 1;                                
                            }
                        case 6:
                            {
                                return 2;                                
                            }
                    }
                }
            switch (rezd1)
            {
                case 3:
                    {
                        return 1;
                    }
                case 6:
                    {
                        return 2;
                    }
            }
            switch (rezd2)
            {
                case 3:
                    {
                        return 1;
                    }
                case 6:
                    {
                        return 2;
                    }
            }






            for (int i = 0; i < 3; i++)
            {
                int rezy = 0;
                for (int j = 0; j < 3; j++)
                {
                    switch (xo[j, i])
                    {
                        case 0:
                            {
                                rezy += 5;
                                break;
                            }
                        case 1:
                            {
                                rezy += 1;
                                break;
                            }
                        case 2:
                            {
                                rezy += 2;
                                break;
                            }
                    }
                }
                switch (rezy)
                {
                    case 3:
                        {
                            return 1;
                        }
                    case 6:
                        {
                            return 2;
                        }
                }
            }
            return 0;
        }
        /* alternativna funkcija koju treba napisati koja ce se odvojeno pozivati na potezu prvog i na potezu drugog igraca
                static int ProveraPobedeAlt()
                {
                   
        if (i % 2 == 0)  //u ovom slucaju se samo proverava za prvog igraca
        {
        }
        else //u ovom slucaju se samo proverva za drugog igraca
        {

        }
        
    }*/

        static void Singleplayer()
        {

        }

        static void Multiplayer()
        {
            int[,] tabla = new int[3, 3];
            int pobednik = 0;
            Program n = new Program();

            for (int i=0;i<9;i++)
            {
                int x, y;
                if (i%2==0)
                {
                    Console.Clear();
                    IspisTable(tabla);
                    Console.WriteLine(Environment.NewLine + "Na potezu je igrac 1");
                    Console.WriteLine("Igrac 1 unesite x koordinatu");
                    Int32.TryParse(Console.ReadLine(), out x);
                    Console.WriteLine("Igrac 1 unesite y koordinatu");
                    Int32.TryParse(Console.ReadLine(), out y);
                    if (x > 0 && x < 4 && y > 0 && y < 4)
                        if (tabla[--x, --y] == 0)
                            tabla[x, y] = 1;
                        else
                            i--;
                    else
                        i--;
                    
                }
                else
                {
                    Console.Clear();                    
                    IspisTable(tabla);
                    Console.WriteLine(Environment.NewLine + "Na potezu je igrac 2");
                    Console.WriteLine("Igrac 2 unesite x koordinatu");
                    Int32.TryParse(Console.ReadLine(), out x);
                    Console.WriteLine("Igrac 2 unesite y koordinatu");
                    Int32.TryParse(Console.ReadLine(), out y);
                    if (x > 0 && x < 4 && y > 0 && y < 4)
                        if (tabla[--x, --y] == 0)
                            tabla[x, y] = 2;
                        else
                            i--;
                    else
                        i--;

                }                
                if (i > 3)
                {                    
                    pobednik = n.ProveraPobede(tabla);
                    switch (pobednik)
                    {
                        case 1:
                            {
                                Console.Clear();
                                IspisTable(tabla);
                                Console.WriteLine(Environment.NewLine + "Pobednik je igrac 1");
                                return;
                            }
                        case 2:
                            {
                                Console.Clear();
                                IspisTable(tabla);
                                Console.WriteLine(Environment.NewLine + "Pobednik je igrac 2");
                                return;
                            }
                    }
                }
            }
            Console.Clear();
            IspisTable(tabla);
            Console.WriteLine(Environment.NewLine + "Nereseno je");
            return;
            }

        static void Main(string[] args)
        {
            string unos;
            
            do
            {
                Console.WriteLine("Unesite broj igraca 1 ili 2, ukoliko zelite prestati sa igrom unesite X");
                unos = Console.ReadLine();

                switch (unos)
                {
                    case "1":
                        {
                            Console.WriteLine("Jos nismo dodali ovu mogucnost");
                            //Singleplayer();
                            break;
                        }
                    case "2":
                        {
                            Multiplayer();
                            break;
                        }
                    case "X":
                        {
                            Console.WriteLine("Izlazak iz igre");
                            break;
                        }
                    case "x":
                        {
                            unos = "X";
                            Console.WriteLine("Izlazak iz igre");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Unos nije validan, molimo vas pokusajte ponovo");
                            break;
                        }
                }
                
            } while (unos!="X");

            //Console.ReadKey();

 
        }
    }
}
