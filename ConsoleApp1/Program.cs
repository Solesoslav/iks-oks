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

        static void PotezIgrac(int[,] xo, int red)
        {
            //Program n = new Program();
            Console.Clear();
            IspisTable(xo);
            int x, y;
            Console.WriteLine(Environment.NewLine + "Na potezu je igrac " + red);
            Console.WriteLine("Igrac " + red + " unesite x koordinatu");
            Int32.TryParse(Console.ReadLine(), out x);
            Console.WriteLine("Igrac " + red + " unesite y koordinatu");
            Int32.TryParse(Console.ReadLine(), out y);
            //n.ValidacijaPolja(xo, red, x, y); //nisam uspeo da namestim da ova funkcija menja x i y
            int i;
            do
            {
                i = 0;
                while (x > 3 || x < 1 || y > 3 || y < 1)
                {
                    Console.Clear();
                    IspisTable(xo);
                    Console.WriteLine(Environment.NewLine + "Unos nije validan, molimo vas pokusajte ponovo");
                    Console.WriteLine("Igrac " + red + " unesite x koordinatu");
                    Int32.TryParse(Console.ReadLine(), out x);
                    Console.WriteLine("Igrac " + red + " unesite y koordinatu");
                    Int32.TryParse(Console.ReadLine(), out y);
                    i++;
                }
                if (xo[x - 1, y - 1] != 0)
                {
                    Console.Clear();
                    IspisTable(xo);
                    Console.WriteLine(Environment.NewLine + "Polje je zauzeto, molimo vas pokusajte ponovo");
                    Console.WriteLine("Igrac " + red + " unesite x koordinatu");
                    Int32.TryParse(Console.ReadLine(), out x);
                    Console.WriteLine("Igrac " + red + " unesite y koordinatu");
                    Int32.TryParse(Console.ReadLine(), out y);
                    i++;
                }
            } while (i != 0);
            xo[x - 1, y - 1] = red;            
        }

        public void ValidacijaPolja(int[,] xo, int red, int x, int y)
        {
            int i;
            do
            {
                i = 0;
                while (x > 3 || x < 1 || y > 3 || y < 1)
                {
                    Console.Clear();
                    IspisTable(xo);
                    Console.WriteLine(Environment.NewLine + "Unos nije validan, molimo vas pokusajte ponovo");
                    Console.WriteLine("Igrac " + red + " unesite x koordinatu");
                    Int32.TryParse(Console.ReadLine(), out x);
                    Console.WriteLine("Igrac " + red + " unesite y koordinatu");
                    Int32.TryParse(Console.ReadLine(), out y);
                    i++;
                }
                if (xo[x - 1, y - 1] != 0)
                {
                    Console.Clear();
                    IspisTable(xo);
                    Console.WriteLine(Environment.NewLine + "Polje je zauzeto, molimo vas pokusajte ponovo");
                    Console.WriteLine("Igrac " + red + " unesite x koordinatu");
                    Int32.TryParse(Console.ReadLine(), out x);
                    Console.WriteLine("Igrac " + red + " unesite y koordinatu");
                    Int32.TryParse(Console.ReadLine(), out y);
                    i++;
                }                                                        
            } while (i != 0);
        }
        
        static int ProveraPobedeAlt(int[,] xo)  
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

        static int ProveraPobede(int[,] xo, int igrac)
        {            
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

        public void RealCPU(int[,] xo) //ovo jos ne radi
        {
            int[][,] t = new int [8][,];
            /*
            *pisemo 7 razlicite varijante svaka varijanta je koliko je polje udaljeno od koordinatnog pocetka, ide od dole levo na desno
            * kad popuni red krene sredina levo. x se dobija tako sto se uradi mod udaljenosti a y se dobija tako sto se uradi div udaljenosti
            *
            */
            for (int i=1;i<9;i++)
            {
                int j = i-1;
                t[j] = new int [3,3];
                if (xo[i % 3, i / 3] == 0)
                {
                    t[j] = xo;
                    //t[j][0, 0] = 2;
                    t[j][i % 3, i / 3] = 2;
                    int pobednik=ProveraPobedeAlt(t[j]);
                    switch(pobednik)
                    {
                        case 1:
                            {
                                Console.WriteLine("Debug poruka 1");
                                Console.WriteLine("j= " + j);
                                IspisTable(t[j]);                                
                                break;
                            }
                        case 2:
                            {
                                Console.WriteLine("Debug poruka 2");
                                Console.WriteLine("j= " + j);
                                IspisTable(t[j]);
                                Console.WriteLine("Debug poruka 2b");
                                IspisTable(xo);
                                Console.WriteLine("Debug poruka 2c");
                                IspisTable(t[4]); //uspomoc ovog vidim da tek t[4] se popuni, svi pre njega su prazni, nemaju cak ni x dole levo.
                                Console.ReadKey();
                                break;
                            }
                        default:
                            {
                                RealCPU(t[j]);
                                break;
                            }
                    }
                    //RealCPU(t[j]);
                }
                
            }
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

        public void RandomCPU(int[,] xo)
        {
            Random rnd = new Random();
            int uspeh = 0;
            do
            {
                int x = rnd.Next(0, 3);
                int y = rnd.Next(0, 3);
                if (xo[x, y] == 0)
                {
                    uspeh = 1;
                    xo[x, y] = 2;
                    Console.WriteLine(Environment.NewLine + "Racnar je odigrao x:" + ++x + " y:" + ++y);
                }
            } while (uspeh == 0);
        }

        public void PotezCPU(int[,] xo, int dif) //treba prokljuviti kako da samo vratim 2 broja jednom metodom uspomoc C#7 tuple feature-a
        {  //mada je to verovatno neefikasno jer u svakom slucaju se mora proslediti tabla za sve cpu situacije sem za random
            if (dif == 1)
                RandomCPU(xo);
            else
                RealCPU(xo);
            //Console.WriteLine(Environment.NewLine + "Racnar je odigrao x:" + ++x + " y:" + ++y);
        }

        public void Singleplayer(int diff, int red)
        {
            int[,] tabla = new int[3, 3];
            int pobednik = 0, x=0, y=0;
            int tez = diff;
            //Program n = new Program();            
            for (int i = 0+red; i < 9+red; i++)
            {               
                if (i % 2 == 0)
                {
                    PotezIgrac(tabla, 1);                    
                }
                else
                {
                    PotezCPU(tabla,tez);
                    //tabla[x, y] = 2; moram da vidim kako da sa CPU funkcijom promenim x i y(verovatno trebam da ih prosledim)
                    //Console.WriteLine(Environment.NewLine + "Racnar je odigrao x:" + ++x + " y:" + ++y);
                }
                if (i > 3)
                {
                    int z = i % 2 + 1;
                    pobednik = ProveraPobede(tabla, z);
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
            //Program n = new Program();

            for (int i = 0; i < 9; i++)
            {
                int z = i % 2 + 1;
                PotezIgrac(tabla, z);                
                if (i > 3)
                {
                    pobednik = ProveraPobede(tabla, z);
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
                switch (unos) //PITANJE? da li je efikasnije konvertovati unos u int pre switcha pa raditi switch sa int a pre toga dodati if ako je unos==k onda break?
                {
                    case "1":
                        {
                            //Console.WriteLine("Jos nismo dodali ovu mogucnost");
                            Console.WriteLine("Unesite tezinu na skali od 1 do 2");
                            int k;
                            Int32.TryParse(Console.ReadLine(), out k);     
                            while ((k != 1) && (k != 2))
                            {
                                Console.WriteLine("Unos nije validan, molimo vas pokusajte ponovo");
                                Int32.TryParse(Console.ReadLine(), out k);
                            }
                            Console.WriteLine("Ako zelite da igrate prvi unesite 1, ako zelite da igrate drugi unesite 2");
                            int p;
                            Int32.TryParse(Console.ReadLine(), out p);
                            while ((p != 1) && (p != 2))
                            {
                                Console.WriteLine("Unos nije validan, molimo vas pokusajte ponovo");
                                Int32.TryParse(Console.ReadLine(), out p);
                            }
                            Program n = new Program();
                            n.Singleplayer(k, p-1);
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
