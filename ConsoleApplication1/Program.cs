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
            string invaldAmount; //totalPrice < 0
            string toSmallAmount; //totalPrice > recivedMoney
            uint moneyBack; //recivedMoney - totalPrice
            uint value= { 500, 100, 50, 20, 10, 5, 1 };
            uint change = (SplitIntoDenominations(moneyBack, value)); //delar upp pengarna tillbaka i växelpengar
            string receipt;  //Det som kommer skrivas ut i kvittot 

            totalPrice = ReadPositiveDouble(totalPrice); //Summan får ett värde från metoden readPositivDouble(som checkar att användaren har matat in ett korrekt värde

            roundingOffAmount = Math.Round(totalPrice, 0, MidpointRounding.AwayFromZero); //Avrundar summan. Till närmaste heltal.

            recivedMoney = ReadUint(recivedMoney, (uint)roundingOffAmount); //Hämtar 

        }

            //do while sats för att kunna avsluta programmet med esc

            private static double ReadPositiveDouble(double totalPrice) //Säkerställa att användaren har matat in ett korrekt värde
            { 
                double value = 0;
                string input;
                while (true)
                {
                
                }
            
            }





            private static uint ReadUint(string kvitto, Double totalPrice)
            {
            Console.Write("Skriv det belopp som du ska betala:");
            totalPrice = double.Parse(System.Console.ReadLine());

            Console.Clear();

            Console.Write("Skriv det belopp som du ger till kassörskan:");
            totalPrice = double.Parse(System.Console.ReadLine());

            Console.Clear();

            }
            

        }

        private static uint SplitIntoDenominations(uint moneyBack, uint value) //http://pastebin.com/GMGWGYNf
        {
            change[0] = moneyBack / 500;
            moneyBack %= 500; 
            change[1] = moneyBack / 100;
            moneyBack %= 100;
            change[2] = moneyBack / 50;
            moneyBack %= 50;
            change[3] = moneyBack / 20;
            moneyBack %= 20;
            change[4] = moneyBack / 10;
            moneyBack %= 10;
            change[5] = moneyBack / 5;
            moneyBack %= 5;
            change[6] = moneyBack; //?

            return change; 
        }
    
}
