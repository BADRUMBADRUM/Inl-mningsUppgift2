using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlämningsUppgift2
{
    public class Register
    {
        public bool ShopOrExit()
        {
            Console.WriteLine("1. Ny kund");
            Console.WriteLine("2. Avsluta");
            int value;
            string answear = Console.ReadLine();
            if(int.TryParse(answear, out value))
            {
                value = Convert.ToInt32(answear);

                if(value == 0)
                {
                    return false;
                }
                else if(value == 1)
                {
                    Console.WriteLine("KASSA");
                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }
        }
        public string inShop()
        {
            int ID = 0;
            int Amount = 0;

            Console.WriteLine("Kommandon:\n<Productid> <antal>\nPAY");
            Console.WriteLine("Kommando: ");
            var kommando = Console.ReadLine();
            var temp = kommando.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            if(kommando == "PAY")
            {
                return "PAY";
            }
            if(int.TryParse(temp[0], out ID) && temp.Length == 2)
            {
                ID = Convert.ToInt32(temp[0]);
                if(temp.Length == 2)
                {
                    if (int.TryParse(temp[1], out Amount))
                    {
                        Amount = Convert.ToInt32(temp[1]);
                    }
                    else
                    {
                        Console.WriteLine("Skriv in ett okej värde");
                        return "NULL";
                    }
                }
                if (ID > 4 || ID < 0)
                {
                    Console.WriteLine("Det finns ingen produkt med detta ID testa igen");
                    return "NULL";
                }

                return Convert.ToString(ID + " " + Amount);
            }
            else
            {
                Console.WriteLine("Felaktigt kommando försök igen");
                return "NULL";
            }
        }
    }
}
