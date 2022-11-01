using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeOKSH
{
    internal class Helpers
    {

        public static string makeDateTimeSQLString(DateTime date)
        {
            string toReturn = date.Year.ToString() + "-" + date.Month.ToString() + "-" + date.Day.ToString();
            return toReturn;
        }


        public static bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }


        public static string makeStringFromDate(DateTime input)
        {
            if (input.Date == new DateTime(0001, 1, 1).Date)
            {
                return "Nicht ausgeliehen";
            }
            else
            {
                string toreturn = input.Day.ToString() + "-" + input.Month.ToString() + "-" + input.Year.ToString();
                Console.WriteLine(toreturn);
                return toreturn;
            }
        }

        public static string translateNumberStringToStatus(string input)
        {
            if (input == "0")
            {
                return "Verfügbar";
            }
            else if (input == "1")
            {
                return "Ausgeliehen";
            }
            else if (input == "2")
            {
                return "In Reparatur";
            }
            else
            {
                return "Nicht bekannt/Fehler";
            }
        }


        public static DateTime makeDateFromString(string input)
        {
            Console.WriteLine(input);
            try
            {
                int year = int.Parse(input.Split('/')[0]);
                int month = int.Parse(input.Split('/')[1]);
                int day = int.Parse(input.Split('/')[2]);

                DateTime toreturn = new DateTime();
                toreturn.AddYears(year - 1);
                toreturn.AddMonths(month - 1);
                toreturn.AddDays(day - 1);

                return toreturn;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Date from string error " + ex.Message);
                return new DateTime(1, 1, 1);
            }
        }

        public static List<Reservation> checkIfItemIsFree(List<DateTime> daysToCheck, List<Reservation> checkAgainst)
        {
            List <Reservation> list = new List<Reservation>();
            foreach (DateTime date in daysToCheck)
            {
                foreach (Reservation subitem in checkAgainst)
                {

                   // Console.WriteLine("CHecking" date.ToString() + " against " , subitem.)
                    DateTime datePast = subitem.startdate;
                    DateTime dateFuture = subitem.enddate;
                    Console.WriteLine("CHecking"+ date.ToString() + " against ", subitem.startdate.ToString() + "--" + subitem.enddate.ToString());
                    if (datePast <= date && date <= dateFuture)
                    {
                        list.Add(subitem);
                    }
                 
                }
                
            }
            return list;
        }


        public static List<DateTime> datesBetweenDates(DateTime start, DateTime end)
        {
            List<DateTime> toReturn = new List<DateTime>();
            DateTime iterator = start;
            
            for (int i = 0; i<100;i++)
            {
                if (start.AddDays(i).Date <= end.Date)
                {
                    toReturn.Add(start.AddDays(i));
                    Console.WriteLine(toReturn.ToString() + toReturn.Count.ToString());
                }
                else
                {
                    break; 
                }
            }

            return toReturn; 


        }


        public static List<ReturnReserveEvent> sortEventsByDate(List<ReturnReserveEvent> inp)
        {
            List<ReturnReserveEvent> ret = new List<ReturnReserveEvent>();
            List<(DateTime date, ReturnReserveEvent ev)> SortList = new List<(DateTime date, ReturnReserveEvent ev)>();
            foreach (ReturnReserveEvent e in inp)
            {

                SortList.Add((e.eventdate, e));

            }
            SortList.Sort((u1, u2) => u1.date.CompareTo(u2.date));


            foreach (var v in SortList)
            {

                ret.Add(v.ev);
                Console.WriteLine("Sorted list " + v.ev.eventstring);
            }

            return ret;
        }

        public static string makeStringFromReservationItems(List<LendingObject> input)
        {
            string toreturn = "";
            foreach (LendingObject item in input)
            {
                toreturn += item.name;
                toreturn += "; ";
            }
            return toreturn; 
        }


    }
}
