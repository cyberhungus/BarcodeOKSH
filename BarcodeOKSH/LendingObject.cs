using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace BarcodeOKSH
{

   public class LendingObject
    {

        public string name { get; set; }
        public string code { get; set; }
        public DateTime borrowedOn { get; set; }
        public DateTime borrowedUntil { get; set; }
        public string status { get; set; }
        public string borrower { get; set; }

        public string tags { get; set; }


        public string staffmember { get; set; }

        const string FREE = "0";
        const string ONLEASE = "1";
        const string INREPAIR = "2"; 
        public LendingObject(string name, string code, string status, string tags)
        {
            this.name = name;
            this.code = code;
            this.status = status;
            this.tags = tags;
        }

        public LendingObject(string name, string code)
        {
            this.name = name;
            this.code = code;

        }

        public LendingObject(string name, string code, string status, string tags, DateTime borrowedUntil)
        {
            this.name = name;
            this.code = code;
            this.status = status;
            this.borrowedUntil = borrowedUntil;
            this.tags = tags;
        }


        public LendingObject()
        {

        }

   


        public override string ToString()
        {
            return this.name + "-" + this.status + "-" + this.code+"-"+this.borrowedUntil.ToString();
        }



    }
}
