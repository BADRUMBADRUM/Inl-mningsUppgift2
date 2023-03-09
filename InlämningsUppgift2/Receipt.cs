using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlämningsUppgift2
{
    public class Receipt 
    {
        public List<string> ReceiptString = new List<string>();
        public float TotalPriceAmount { get; set; }

        public void AddToReciept(Products product, int amount)
        {
            var tempSum = product.Price * amount;
            ReceiptString.Add(product.Name + " " + amount + " * " + product.Price + " = " + tempSum);
            TotalPriceAmount += tempSum;
        }

        public void PayAndFinishReceipt()
        {
            ReceiptString.Add("\n" + "Total: " + TotalPriceAmount.ToString() + "\n");
            File.AppendAllLines(@".\..\..\..\TXTFiler\Kvitto.txt", ReceiptString);
            TotalPriceAmount = 0;
            ReceiptString.Clear();
            ReceiptString.Add("KVITTO " + DateTime.Now + "\n");
        }

        public override string ToString()
        {
            StringBuilder myStringbuilder = new StringBuilder();
            foreach(var line in ReceiptString)
                myStringbuilder.AppendLine(line.ToString());
            myStringbuilder.Append("\n");
            myStringbuilder.AppendLine("Total: " + TotalPriceAmount.ToString());
            myStringbuilder.Append("\n");
            return myStringbuilder.ToString();  
        }
    }
}
