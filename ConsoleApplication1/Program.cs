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
            double totalPrice; //readline
            uint recivedMoney; //readline
            double roundingOffAmount; //totalPrice - roundingOff-totalPrice
            double roundingOffmarginal;
            uint moneyBack; //recivedMoney - totalPrice
            //string receipt;  //Det som kommer skrivas ut i kvittot 

            //uint change = SplitIntoDenominations(moneyBack, value); //delar upp pengarna tillbaka i växelpengar

            totalPrice = ReadPositiveDouble("Skriv det belopp som du ska betala:"); //Summan får ett värde från metoden readPositivDouble(som checkar att användaren har matat in ett korrekt värde

            roundingOffAmount = Math.Round(totalPrice, 0, MidpointRounding.AwayFromZero); //Avrundar summan. Till närmaste heltal.

            recivedMoney = ReadUint("Skriv det erhållna beloppet:", totalPrice); //Hämtar värdet från readuint-metoden

            //uint[] money = { 500, 100, 50, 20, 10, 5, 1 }; //deklarerar en variabel för de valörer som finns

            roundingOffmarginal = roundingOffAmount - totalPrice; //räknar ut hur mkt som rundas av(växlen)

            moneyBack = recivedMoney - (uint)roundingOffAmount;

            Console.WriteLine("Att betala: {0}", totalPrice);
            Console.WriteLine("Erhållna pengar: {0}", recivedMoney);
            Console.WriteLine("Öresavrundingen: {0}", roundingOffmarginal);

        }

        //do while sats för att kunna avsluta programmet med esc

        private static double ReadPositiveDouble(string prompt) //kallar på meddelandet och frågar efter ett värde tillvalue(=totalprice) kontrollerar att det är större än 0
        {
            double value = 0;
            string input;
            while (true)
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
                    Console.Write("Du har skrivit fel, du måste skriva siffror. Prova igen:");
                }
                catch (OverflowException)
                {
                    Console.Write("Du har skrivit fel, ditt tal kan inte vara mindre än 0kr. ");
                }
            }

            return value;
        }

        private static uint ReadUint(string prompt, double totalPrice)
        {
            uint recivedMoney = 0;
            string input; //tilfällig varibel för att utföra denna metoden.
            //string prompt = "Skriv det belopp som du betalar med:";

            while (true) //loop för att jag inte vet hur många gånger användaren ska göra fel
            {
                Console.Write(prompt); //skriver ut meddelande och användaren tilldelar input ett värde
                input = Console.ReadLine();

                try
                {
                    recivedMoney = uint.Parse(input); //provar att parsa input till en uint
                    if (recivedMoney < totalPrice) //pengarna användaren ska betala måste vara mindre än vad användaren ger, om ...
                    {
                        throw new OverflowException();//det är så kastas ett argument som berättar att detta inte fungerar
                    }
                    break; //om recivedMoney < totalPrice stämmer bryts satsen
                }
                catch (OverflowException)
                {
                    Console.Write("Du kan tyvärr inte betala {0} med {1}", totalPrice, recivedMoney);
                }
                catch (FormatException)
                {
                    Console.Write("Du har skrivit fel, du måste skriva siffror. Prova igen:");
                }
            }

            return recivedMoney;
        }

        //private static uint[] SplitIntoDenominations(uint moneyBack, uint value) //http://pastebin.com/GMGWGYNf
        //{
        //    uint[] change = new uint[7];
        //    change[0] = moneyBack / 500;
        //    moneyBack %= 500;
        //    change[1] = moneyBack / 100;
        //    moneyBack %= 100;
        //    change[2] = moneyBack / 50;
        //    moneyBack %= 50;
        //    change[3] = moneyBack / 20;
        //    moneyBack %= 20;
        //    change[4] = moneyBack / 10;
        //    moneyBack %= 10;
        //    change[5] = moneyBack / 5;
        //    moneyBack %= 5;
        //    change[6] = moneyBack; //resten från pengarna, dvs enkronor

        //    return change;
        //}

       
    }
}
