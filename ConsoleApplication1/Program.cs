using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1;

namespace vaxelpangar
{
    class Program
    {
        static void Main(string[] args)
        {
            //Deklarera variabler, peangarna man ska betala, man ska ge och avrundningen mellan dessa.
            double totalPrice; 
            uint recivedMoney; 
            double roundingOffAmount; //math.round
            double roundingOffmarginal; //math.round - totalprice
            uint moneyBack; //recivedMoney - totalPrice
            
            do
            {
                Console.Clear();
                totalPrice = ReadPositiveDouble("Skriv det belopp som du ska betala:"); //Summanav totalprice får ett värde från metoden readPositivDouble(som också checkar att användaren har matat in ett korrekt värde)

                roundingOffAmount = Math.Round(totalPrice, 0, MidpointRounding.AwayFromZero); //Avrundar summan till närmaste heltal.

                recivedMoney = ReadUint("Skriv det erhållna beloppet:", totalPrice); //Hämtar värdet från readuint-metoden (som också checkar att användaren har matat in ett korrekt värde)

                uint[] money = { 500, 100, 50, 20, 10, 5, 1 }; //deklarerar en array variabel för de valörer som finns
                string[] bills = { "500", "100", "50", "20", "10", "5", "1" }; //deklarerar en array variabel för de pengar som finns
                roundingOffmarginal = roundingOffAmount - totalPrice; //räknar ut hur mkt som rundas av(växlen)

                moneyBack = recivedMoney - (uint)roundingOffAmount;

                uint[] change = SplitIntoDenominations(moneyBack, money); //delar upp pengarna tillbaka i växelpengar

                Console.Clear();
                Console.WriteLine("KVITTO\n***************************");  //skrivs mitt kvitto ut
                Console.WriteLine("Att betala: {0:c}", totalPrice);
                Console.WriteLine("Erhållna pengar: {0:c0}", recivedMoney);
                Console.WriteLine("Öresavrundingen: {0:c}", roundingOffmarginal);
                Console.WriteLine("Att betala efter öresavrundningen: {0:c}", roundingOffAmount);
                Console.WriteLine("Pengar att få tillbaka: {0:c0}", moneyBack);
                Console.WriteLine("Växel tillbaka: ");
                
                for (int i = 0; i < change.GetLength(0); i++)
                {
                    if (change[i] != 0)
                    {
                        Console.WriteLine("{0} st av {1}-lapp(ar)", change[i], bills[i] );
                    }
                }
                Console.WriteLine("****************************");
                

            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);//do while sats för att kunna avsluta programmet med esc eller fortsätta med valfri tangent
        }

        private static double ReadPositiveDouble(string prompt) //kallar på meddelandet och frågar efter ett värde till value(=totalprice) kontrollerar att det är större än 0
        {
            double value = 0;
            string input;
            while (true)        //loop för att jag inte vet hur många gånger användaren kommer göra fel
            {
                Console.Write(prompt); //här skrivs ut "skriv summan"
                input = Console.ReadLine(); //användaren  skriver in vad den ska betala =input
                try
                {
                    value = double.Parse(input);
                    if (Math.Round(value, MidpointRounding.AwayFromZero) >= 0) //Avrundningen är större eller lika med noll
                    {
                        break; //om detta ovan stämmer kommer break hoppa över catch-satserna
                    }
                }
                catch (FormatException)
                {
                    Console.BackgroundColor = ConsoleColor.Red; //catch satser ifall kraven i If-satsen inte stämmer.
                    Console.WriteLine("FEL! '{0}', du måste skriva siffror. Prova igen!", input);
                    Console.ResetColor();
                }
                catch (OverflowException)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("FÖRSTORT! Ditt tal, '{0}' är förstort.", input);
                    Console.ResetColor();
                }
                if (int.Parse(input) < 0)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("FÖRLITET! Ditt tal, '{0}' kan inte tolkas som en giltig summa pengar.", input);
                    Console.ResetColor();
                }
            }

            return value; 
        }

        private static uint ReadUint(string prompt, double totalPrice)
        {
            uint recivedMoney = 0;
            string input; //tilfällig varibel för att utföra denna metoden.

            while (true) 
            {
                Console.Write(prompt); //skriver ut meddelande och användaren tilldelar input ett värde
                input = Console.ReadLine();

                try
                {
                    recivedMoney = uint.Parse(input); //provar parsa input till en uint
                    if (recivedMoney < totalPrice) //pengarna användaren ska betala måste vara mindre än vad användaren ger, om ...
                    {
                        throw new OverflowException();//...det är så kastas ett argument som berättar att detta inte fungerar
                    }
                    break; //om recivedMoney < totalPrice stämmer bryts satsen
                }
                catch (OverflowException)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Du kan tyvärr inte betala {0:c} med {1:c}, använda mer pengar!", totalPrice, recivedMoney);
                    Console.ResetColor();
                }
                catch (FormatException)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Du har skrivit fel, du måste skriva heltal.  Glöm inte att använda punkt(.) istället för komma(,). Prova igen!");
                    Console.ResetColor();
                }
            }

            return recivedMoney;
        }

        private static uint[] SplitIntoDenominations(uint moneyBack, uint[] money) //http://pastebin.com/GMGWGYNf
        {
            uint[] change = new uint[7];
            for (int i = 0; i < money.GetLength(0); i++) //en loop som går igenom modelussatsem
            {
                if (moneyBack / money[i] >= 1) // testar hur många lappar som går in i moneyBack, och checkar ifall det är mer än noll
                {
                    change[i] = moneyBack / money[i];  // change får ett nytt värde
                    moneyBack %= money[i];     // Moneyback fåt ett nytt värde och körs om i loopen
                }
            }
            return change;
        }

       
    }
}
