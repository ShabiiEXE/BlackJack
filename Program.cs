/*//////////////////////////////////////////////////////////////
//  ___   _      __    __    _       _    __    __    _       //
//  | |_) | |    / /\  / /`  | |_/   | |  / /\  / /`  | |_/   //
//  |_|_) |_|__ /_/--\ \_\_, |_| \ \_|_| /_/--\ \_\_, |_| \   //
//                                                            //
//////////////////////////////////////////////////////////////*/


Console.Title = "-----------------------------------------------------------------------------------------------------------------------------------------------"; //Titol de la consola de comandaments
Random numgen = new Random(); //Generador de numeros aleatoris


//Introduccio i normes previes
Console.WriteLine("          __________.__                 __        ____.              __    ");
Console.WriteLine("          \\______   \\  | _____    ____ |  | __   |    |____    ____ |  | __");
Console.WriteLine("           |    |  _/  | \\__  \\ _/ ___\\|  |/ /   |    \\__  \\ _/ ___\\|  |/ /");
Console.WriteLine("           |    |   \\  |__/ __ \\\\  \\___|    </\\__|    |/ __ \\\\  \\___|    < ");
Console.WriteLine("           |______  /____(____  /\\___  >__|_ \\________(____  /\\___  >__|_ \\");
Console.WriteLine("                  \\/          \\/     \\/     \\/             \\/     \\/     \\/");
Console.WriteLine("-----------------------------------------------------------------------------------------");
Console.WriteLine("");
Console.WriteLine("");

Console.WriteLine("BENVINGUT AL SIMULADOR");
Console.WriteLine("");
Console.WriteLine("Aquestes son les normes:");
Console.WriteLine("");
Console.WriteLine("El joc consisteix en que cada jugador s'ha d'apropar el màxim possible a una puntuació de 21 amb les cartes");
Console.WriteLine("que va robant. Després de rebre la segona carta pot escollir si vol robar una altre, intentant no passar-se. ");
Console.WriteLine("Si el jugador es passa, la seva puntuació sera 0, però si aconsegueix un 21, tindrà un BLACKJACK!");
Console.WriteLine("Un cop els 2 jugadors haguin robat les seves cartes es decidirà el guanyador.");
Console.WriteLine("");
Console.WriteLine("Bona sort!");
Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("Prem qualsevol tecla per a continuar...");
Console.ReadKey(); 



int replay = 0; //Crea un INT que ens permetra que el jugador pugui tornar a jugar el joc o no

while (replay < 1) //Bucle que permet tornar a comencar el joc
{
    //INT que serveixen per a emmagatzemar les puntuacions finals de cada jugador
    int Mem1 = 0;
    int Mem2 = 0;

    //Loop que permet fer el Joc per als dos jugadors sense tenir que repetir codi
    for (int Jugador = 1; Jugador <= 2; Jugador++)

    {   //Indica el Jugador que juga en la ronda
        Console.Clear(); //Neteja la pantalla anterior, ja sigui la principal o la ronda anterior
        Console.Title = "BLACKJACK"; //Titol de la consola de comandaments
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Jugador " + Jugador);
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("------------------------------------");
        Console.WriteLine("");

        int Card1Value = numgen.Next(1, 14); //Genera un numero del 1 - 13 referent a una carta, per la primera carta
        int FinalValue = 0; //INT que permet guardar una dada per a poder guardar-ho en Mem1 o Mem2
        int numconv = 0; // INT que serveix com a memoria temporal per guardar el valor de les cartes entre tirades
        int count = 0; //Contador per a poder realitzar el joc sense repetir codi

        numconv = Card1Value; //La memoria val igual que el numero obtingut al primer generador

        //Repeticio del joc fins que el contador sobrepassi 1
        while (count <= 1)
        {
            int Card2Value = numgen.Next(1, 14); //Genera un numero del 1 - 13 referent a una carta, per les seguents tirades de cartes
            int data = 0;
            int Color = numgen.Next(0, 2); //Cada cop que es treu una carta crea un valor 0 o 1 per determinar si es negra o vermella

            if (Color == 1) Console.ForegroundColor = ConsoleColor.Red; //Si surt 1 en el valor color la carta es vermella si no es queda negra
            


            //S'estableix el valor de cada numero referent a les cartes
            if (numconv == 10) Console.WriteLine("Deu: 10 punts");
            if (numconv == 11)
            {
                Console.WriteLine("J: 10 punts");
                numconv = 10;
            }
            if (numconv == 1) //S'estableix a mes a mes si el jugador vol que A sigui 1 o 11 per cada vegada
            {
                Console.WriteLine("T'ha sortit un As, vol que valgui 1 punt o 11 punts?"); //Preguntem quin valor d'As es vol
            As_Switch: //Punt de referencia en al codi per a tornar a poder preguntar el valor en cas de no ser 1 o 11 
                data = Convert.ToInt32(Console.ReadLine());
                switch (data) //Resultat dels casos
                {
                    case 1: //si es diu 1, el valor de la carta sera 1
                        numconv = 1;
                        break;
                    case 11: //si es diu 11, el valor de la carta sera 11
                        numconv = 11;
                        break;
                    default: //si no es diu ni 1 ni 11, s'escriu una frase i el codi torna al punt de referencia anterior per a tornar a preguntar
                        Console.WriteLine("Escull només 1 o 11");
                        goto As_Switch;
                }
            }
            if (numconv == 2) Console.WriteLine("Dos: 2 punts");
            if (numconv == 3) Console.WriteLine("Tres: 3 punts");
            if (numconv == 4) Console.WriteLine("Quatre: 4 punts");
            if (numconv == 5) Console.WriteLine("Cinc: 5 punts");
            if (numconv == 6) Console.WriteLine("Sis: 6 punts");
            if (numconv == 7) Console.WriteLine("Set: 7 punts");
            if (numconv == 8) Console.WriteLine("Vuit: 8 punts");
            if (numconv == 9) Console.WriteLine("Nou: 9 punts");
            if (numconv == 12)
            {
                Console.WriteLine("Q: 10 punts");
                numconv = 10;
            }
            if (numconv == 13)
            {
                Console.WriteLine("K: 10 punts");
                numconv = 10;
            }



            Console.ForegroundColor = ConsoleColor.White;

            FinalValue += numconv; //Es passa el valor de la carta a la memoria FinalValue
            numconv = Card2Value; //Fem que la memoria temporal ara prengui el valor del seguent valor de carta generat

            //Si s'han llencat 2 cartes (ho sabem gracies al contador) i no s'ha passat o fet blackjack, es demana i el jugador en vol mes
            if (count == 1 && FinalValue < 21)
            {
                Console.WriteLine("------------------------------------");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Valor actual: " + FinalValue);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Vol una carta adicional? Si o no");
                JocAdicional_Switch: //Punt de referencia en al codi per a tornar a poder preguntar el valor en cas de no ser ni si ni no
                    string data1 = Console.ReadLine();
                    switch (data1) //Resultat dels casos
                    {
                        case "si": //Si es diu si, el bucle de joc es reinicia
                            count = 0;
                            break;
                        //Escriptura alternativa de si que donen el mateix resultat
                        case "Si":
                            goto case "si";
                        case "SI":
                            goto case "si";
                        case "sI":
                            goto case "si";

                        case "no": //Si es diu no, el bucle es trenca i el joc finalitza
                            break;
                        //Escriptura alternativa de no que donen el mateix resultat
                        case "No":
                            goto case "no";
                        case "NO":
                            goto case "no";
                        case "nO":
                            goto case "no";
                        default: //si no es diu ni si ni no, es torna a fer la pregunta i es torna al punt de referencia anterior.
                            Console.WriteLine("Vol una carta adicional? Si o no");
                            goto JocAdicional_Switch;
                }
                Console.WriteLine("");
            }
            count++; //S'augmenta el valor al bucle
        }

        //Es mostra el resultat del jugador que jugava en aquella ronda
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Jugador " + Jugador);
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("------------------------------------");
        Console.WriteLine("");

        if (FinalValue > 21) //Si el valor es passa de 21, el valor passa a 0 el minim
        {
            Console.WriteLine(FinalValue + ": T'has passat, més sort la propera vegada");
            FinalValue = 0;
        }
        if (FinalValue == 21) Console.WriteLine("BLACKJACK!"); //Si el valor es 21 es mostra com a BlackJack
        else Console.WriteLine("Valor final: " + FinalValue);

        if (Jugador == 1) Mem1 = FinalValue; //Referent al bucle de joc, si esta en el primer el valor temporal amb el resultat final es guarda a la memoria per al jugador 1
        else Mem2 = FinalValue; //Referent al bucle de joc, si esta en el segon el valor temporal amb el resultat final es guarda a la memoria per al jugador 2

        Console.ReadKey();

    }

    Console.Clear();

    //Escriu els resultats finals
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Resultats: ");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("------------------------------------");
    Console.WriteLine("");
    Console.WriteLine("Valor Jugador 1: " + Mem1);
    Console.WriteLine("Valor Jugador 2: " + Mem2);
    Console.WriteLine("");
    Console.WriteLine("------------------------------------");
    Console.ReadKey();
    Console.WriteLine("");
    Console.ForegroundColor = ConsoleColor.Yellow;
    //Compara les puntuacions per indicar si el J1 o el J2 son els guanyadors o empat
    if (Mem2 < Mem1)
    {
        Console.WriteLine("El guanyador és el Jugador 1 amb " + Mem1 + " punts.");
        Console.WriteLine("Enhorabona!");
    }
    else
    {
        if (Mem1 < Mem2)
        {
            Console.WriteLine("El guanyador és el Jugador 2 amb " + Mem2 + " punts.");
            Console.WriteLine("Enhorabona!");
        }
        else Console.WriteLine("EMPAT");
    }
    Console.ForegroundColor = ConsoleColor.White;

    Console.ReadKey();

    //Pregunta al jugador si vol tornar a jugar i reiniciar el joc
    Console.WriteLine("");
    Console.WriteLine("------------------------------------");
    Console.WriteLine("");
    Console.WriteLine("");
    Console.WriteLine("Vol tornar a jugar? Si o no");

JocFinal_Switch: //Punt de referencia en al codi per a tornar a poder preguntar el valor en cas de no ser ni si ni no
    string data2 = Console.ReadLine();
    switch (data2) //Resultat dels casos
    {
        case "si": //Si es diu si, el bucle de joc es reinicia
            replay = 0;
            break;
        //Escriptura alternativa de si que donen el mateix resultat
        case "Si":
            goto case "si";
        case "SI":
            goto case "si";
        case "sI":
            goto case "si";

        case "no": //Si es diu no, el bucle es trenca i el joc finalitza
            replay = 1;
            break;
        //Escriptura alternativa de no que donen el mateix resultat
        case "No":
            goto case "no";
        case "NO":
            goto case "no";
        case "nO":
            goto case "no";
        default: //Si no es diu ni si ni no, es torna a fer la pregunta i es torna al punt de referencia anterior.
            Console.Clear();
            Console.WriteLine("Vol tornar a jugar? Si o no");
            goto JocFinal_Switch;
    }
}