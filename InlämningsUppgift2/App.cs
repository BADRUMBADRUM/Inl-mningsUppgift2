using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlämningsUppgift2
{
    public class App
    {
        public void run()
        {
            Console.WriteLine("\r\n██╗  ██╗ █████╗ ███████╗███████╗ █████╗ \r\n██║ ██╔╝██╔══██╗██╔════╝██╔════╝██╔══██╗\r\n█████╔╝ ███████║███████╗███████╗███████║\r\n██╔═██╗ ██╔══██║╚════██║╚════██║██╔══██║\r\n██║  ██╗██║  ██║███████║███████║██║  ██║\r\n╚═╝  ╚═╝╚═╝  ╚═╝╚══════╝╚══════╝╚═╝  ╚═╝\r\n\r\n");
            var register = new Register();
            var CurrentReceipt = new Receipt();
            CurrentReceipt.ReceiptString.Add("KVITTO " + DateTime.Now + "\n");
            bool trueorfalse = true;
            var text = File.ReadLines(@".\..\..\..\TXTFiler\Produkter.txt");
            List<Products> products = new List<Products>();
            foreach (var i in text)
            {
                var temp = i.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                products.Add(new Products(Convert.ToInt32(temp[0]), temp[1], float.Parse(temp[2])));
            }
            if(register.ShopOrExit() == false)
            {
                trueorfalse = false;
            }
            else
            {
                trueorfalse = true;
            }
            while (trueorfalse == true)
            {
                var CheckCommand = register.inShop().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int tempID = 0;
                int tempAmount = 0;
                if (CheckCommand[0] == "PAY")
                {
                    Console.Write(CurrentReceipt.ToString());

                    CurrentReceipt.PayAndFinishReceipt();

                    if (register.ShopOrExit() == false)
                    {
                        trueorfalse = false;
                    }
                    else
                    {
                        trueorfalse = true;
                    }
                }
                else if (int.TryParse(CheckCommand[0], out tempID) && int.TryParse(CheckCommand[1], out tempAmount))
                {
                    tempID = Convert.ToInt32(CheckCommand[0]);
                    tempAmount = Convert.ToInt32(CheckCommand[1]);
                    CurrentReceipt.AddToReciept(products[tempID], tempAmount);
                    Console.Write(CurrentReceipt.ToString());
                }

            }
            
        }
    }
}
