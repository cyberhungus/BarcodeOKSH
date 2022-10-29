using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeOKSH
{
    public class Reservation
    {
        public List<LendingObject> objects = new List<LendingObject>();
       public  Person borrower { get; set; }
        public string staffmember { get; set; }

        public string id { get; set; }
        public DateTime startdate { get; set; }
        public DateTime enddate { get; set; }




        public Reservation() { }


        public void addItem(LendingObject newitem)
        {
            objects.Add(newitem);
        }

        public string makeItemsString()
        {
            string toreturn = "";
            foreach (LendingObject item in objects)
            {
                toreturn += item.code;
                toreturn += ":";
            }
            return toreturn;
        }


        public override string ToString()
        {
            return "Reservation from " + startdate.Date.ToString() + " until " + enddate.Date.ToString() + " by " + borrower.getFullName() + " Items:" + Helpers.makeStringFromReservationItems(objects);
        }

    }
}
