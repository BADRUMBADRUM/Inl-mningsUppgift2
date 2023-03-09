using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlämningsUppgift2
{
    public class Products
    {
        public int ID {get;set;}
        public float Price { get; set; }
        public string Name { get; set; }



        public Products(int ID, string name, float price)
        {
            this.Price = price;
            this.Name = name;
            this.ID = ID;
        }
        public override string ToString()
        {
            return ID + " " + Name + " " + Price;
        }

    }
}
