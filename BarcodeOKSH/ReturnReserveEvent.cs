using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeOKSH
{
    public class ReturnReserveEvent
    {
        public string eventstring = "";
        public DateTime startDate = DateTime.Now;
        public DateTime endDate = DateTime.Now;
        public DateTime eventdate = DateTime.Now;
        public string type = "";
        public ReturnReserveEvent(Reservation res, DateTime date)
        {
            startDate = res.startdate;
            endDate =   res.enddate;
            this.eventdate = date;
            type = "RES";
            eventstring = "Reserviert durch " + res.borrower.getFullName() + ":" + res.makeItemNameString()+ res.startdate.ToString() + " bis "+  res.enddate.ToString();
        }
        

        
        public ReturnReserveEvent(LendingObject obj, DateTime date)
        {
            startDate = obj.borrowedOn;
            endDate = obj.borrowedUntil;
            this.eventdate = date;
            type = "OBJ";
            eventstring = obj.name + " an " + new SQLGetter().selectPersonByID(obj.borrower)[0].getFullName() + " bis " + obj.borrowedUntil.ToString();
        }



    }
}
