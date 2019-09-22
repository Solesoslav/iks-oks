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
            for (int j = 2; j >= 0; j--)
            {
                for (int i = 0; i < 3; i++)
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
                    if (i != 2)
                        Console.Write('|');
                }
                if (j != 0)
                    Console.WriteLine(Environment.NewLine + "---+---+---");
            }

        }
        /* //Ovo je prva varijanta funkcije koja je manje efikasna posto u svakom prelazu preoverava za oba igraca, sto nema potrebe jer samo onaj igrac koji je povukao poslednji potez moze pobediti
                public int ProveraPobede(int[,] xo)  
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
                }*/

        public int ProveraPobede(int[,] xo, int igrac)
        {
            igrac++;
            int rezd1 = 0;
            int rezd2 = 0;
            for (int i = 0; i < 3; i++)
            {
                int rezx = 0;
                for (int j = 0; j < 3; j++)
                {
                    if (xo[j, i] == igrac)
                        rezx++;
                    if (i == j)
                        if (xo[j, i] == igrac)
                            rezd1++;
                    if ((i + j) == 2)
                        if (xo[j, i] == igrac)
                            rezd2++;
                }
                if (rezx == 3)
                    return igrac;
            }
            if ((rezd1 == 3) || (rezd2 == 3))
                return igrac;

            for (int i = 0; i < 3; i++)
            {
                int rezy = 0;
                for (int j = 0; j < 3; j++)
                {
                    if (xo[i, j] == igrac)
                        rezy++;
                }
                if (rezy == 3)
                    return igrac;
            }
            return 0;
        }

        /* Trenutno je ubacen samo random CPU ponasanje koje ce biti u igri kao najniza tezina, u planu je ubacivanje vece tezine
         * gde ce postojati pravi protivnik koji ce raditi na osnovu poslednje povucenog poteza protivnika i algoritma za pravilno igranje iks oks igre
         * Tada ce se CPU funkciji pored table prosledjivati i jedan int koji ce odrediti "tezinu",
         * jedini posao CPU funkcije bice da pozove "random CPU" funkciju ili "real CPU" funkciju koji ce da budu odvojene funkcije
         * Za kraj je u planu ubaciti selektor tezine od 1 do 5, gde ce sama CPU funkcija izbaciti Random broj od 1 do 4
         * i ako odabrana tezina bude bila veca od tog random broja CPU funkcija ce pozvati "real CPU" funkciju, u suprotnom "random CPU" funkciju.
         * Tako da ce tezina 3 imati 50%/50% sansu da odradi pravi potez u odnosu na random potez(mada random potez moze se slucajno poklopiti sa pravim
         * necemo to uzimati u razmatranje procenta.
         * Kada se bude ubacio selektor tezine "real CPU" funkcija ce morati da bude ponovo napisana i prosirena kako bi mogla da radi na osnovu analize polja, 
         * a ne samo poslednjeg poteza protivnika, jer zbog random elementa polje se nece uklopiti u prethodni algoritam
        */
        static void CPU(int[,] xo) //treba prokljuviti kako da samo vratim 2 broja jednom metodom uspomoc C#7 tuple feature-a
        {  //mada je to verovatno neefikasno jer u svakom slucaju se mora proslediti tabla za sve cpu situacije sem za random
            Random rnd = new Random();
            int uspeh = 0;
            do
            {                
                int x = rnd.Next(0, 3);
                int y = rnd.Next(0, 3);
                if (xo[x, y] == 0)
                {
                    xo[x, y] = 2;
                    Console.WriteLine(Environment.NewLine + "Racnar je odigrao x:" + ++x + " y:" + ++y);
                    uspeh = 1;
                }
            } while (uspeh==0);
        }

        static void Singleplayer(int red)
        {
            int[,] tabla = new int[3, 3];
            int pobednik = 0, x=0, y=0;
            Program n = new Program();            
            for (int i = 0-red; i < 9-red; i++)
            {               
                if (i % 2 == 0)
                {                    
                    IspisTable(tabla);                    
                    Console.WriteLine(Environment.NewLine + "Na potezu je igrac");
                    Console.WriteLine("Unesite x koordinatu");
                    Int32.TryParse(Console.ReadLine(), out x);
                    Console.WriteLine("Unesite y koordinatu");
                    Int32.TryParse(Console.ReadLine(), out y);
                    if (x > 0 && x < 4 && y > 0 && y < 4)
                        if (tabla[--x, --y] == 0)
                            tabla[x, y] = 1;
                        else
                            i--;
                    else
                        i--;
                    Console.Clear();
                }
                else
                {
                    CPU(tabla);
                }
                if (i > 3)
                {
                    pobednik = n.ProveraPobede(tabla, i % 2);
                    switch(pobednik)
                    {
                        case 1:
                            {
                                Console.Clear();
                                IspisTable(tabla);
                                Console.WriteLine(Environment.NewLine + "Pobedili ste");
                                return;
                            }
                        case 2:
                            {
                                Console.Clear();
                                IspisTable(tabla);
                                Console.WriteLine(Environment.NewLine + "Racunar vas je pobedio");
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

        static void Multiplayer()
        {
            int[,] tabla = new int[3, 3];
            int pobednik = 0;
            Program n = new Program();

            for (int i = 0; i < 9; i++)
            {
                int x, y;
                if (i % 2 == 0)
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
                    pobednik = n.ProveraPobede(tabla, i % 2);
                    if (pobednik != 0)
                    {
                        Console.Clear();
                        IspisTable(tabla);
                        Console.WriteLine(Environment.NewLine + "Pobednik je igrac " + pobednik);
                        return;
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

                switch (unos) //PITANJE? da li je efikasnije konvertovati unos u int pre switcha?
                {
                    case "1":
                        {
                            //Console.WriteLine("Jos nismo dodali ovu mogucnost");
                            Console.WriteLine("Ako zelite da igrate prvi unesite 1, ako zelite da igrate drugi unesite 2");
                            unos = Console.ReadLine();
                            switch(unos)
                            {
                                case "1":
                                    {
                                        Singleplayer(0);
                                        break;
                                    }
                                case "2":
                                    {
                                        Singleplayer(1);
                                        break;
                                    }
                                default:
                                    {
                                        Console.WriteLine("Unos nije validan, molimo vas pokusajte ponovo");
                                        break;
                                    }
                            }
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

            } while (unos != "X");

            //Console.ReadKey();


        }
    }
}
