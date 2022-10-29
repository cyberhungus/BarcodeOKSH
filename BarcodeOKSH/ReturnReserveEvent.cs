using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeOKSH
{
    internal class ReturnReserveEvent
    {
        public string eventstring = "";
       public List<DateTime> relevantDates = new List<DateTime>();
        public ReturnReserveEvent(Reservation res)
        {
            relevantDates.AddRange( Helpers.datesBetweenDates(res.startdate, res.enddate));
            eventstring = "Reserviert durch " + res.borrower.getFullName() + ":" + res.makeItemsString()+ res.startdate.ToString() + " bis "+  res.enddate.ToString();
        }
        

        
        public ReturnReserveEvent(LendingObject obj)
        {
            relevantDates.AddRange(Helpers.datesBetweenDates(DateTime.Now, obj.borrowedUntil));
            eventstring = obj.name +" ausgeliehen durch " + new SQLGetter().selectPersonByID(obj.borrower)[0] + " bis " + obj.borrowedUntil.ToString();
        }



    }
}
