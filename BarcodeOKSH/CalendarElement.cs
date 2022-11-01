using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarcodeOKSH
{
    public partial class CalendarElement : UserControl
    {
        List<ReturnReserveEvent> returnReserveEvents;
        int c, r = 0;
        string month = "";
        string year = "";
        int monthOffset = 0;
        List<EventDisplayElement> eeds = new List<EventDisplayElement>();

        string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
        public CalendarElement()
        {
            InitializeComponent();
            this.makeCalendar(DateTime.Now);
            registerEvents(Helpers.sortEventsByDate(new SQLGetter().generateEventsUntilDate(DateTime.Now.AddDays(30))));
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            monthOffset += 1;
            this.ElementPanel.Controls.Clear();
            this.makeCalendar(DateTime.Now.AddMonths(monthOffset));
            if (monthOffset == 0)
            {
                registerEvents(Helpers.sortEventsByDate(new SQLGetter().generateEventsUntilDate(DateTime.Now.AddDays(30))));
            }
            else
            {
                registerEvents(Helpers.sortEventsByDate(new SQLGetter().generateEventsUntilDate(DateTime.Now.AddDays(monthOffset * 30))));
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            monthOffset -= 1;
            this.ElementPanel.Controls.Clear();
            this.makeCalendar(DateTime.Now.AddMonths(monthOffset));
            if (monthOffset == 0)
            {
                registerEvents(Helpers.sortEventsByDate(new SQLGetter().generateEventsUntilDate(DateTime.Now.AddDays(30))));
            }
            else
            {
                registerEvents(Helpers.sortEventsByDate(new SQLGetter().generateEventsUntilDate(DateTime.Now.AddDays(monthOffset * 30))));
            }
        }

        public void makeCalendar(DateTime dt)
        {
            this.month = dt.Month.ToString();
            this.year = dt.Year.ToString();
            int daysinmonth = DateTime.DaysInMonth(dt.Year, dt.Month);
            this.c = 1;
            this.r = 0;
            CalendarInfoLabel.Text = this.month + " / " + this.year;
            foreach (string s in this.days)
            {
                var btn = new Label();
                btn.Text = s;
                btn.Dock = DockStyle.Fill;
                this.ElementPanel.Controls.Add(btn, r, 0);
                r++;
            }

            DateTime firstOfMonth = new DateTime(dt.Year, dt.Month, 1);
            string dayName = firstOfMonth.DayOfWeek.ToString();
            int offset = Array.IndexOf(days, dayName);
            this.c = offset;
            this.r = 1;
            for (int i = 0; i < daysinmonth; i++)
            {
                        if (this.c < 8)
                        {
                           this.c++;
                       }
                       else
                        {
                           this.c = 0;
                           this.r++;
                        }
                var btn = new EventDisplayElement(firstOfMonth.AddDays(i));
                eeds.Add(btn);
                btn.Dock = DockStyle.Fill;
                this.ElementPanel.Controls.Add(btn, c,r);
            }

        }

        public EventDisplayElement findEEDbyDate(DateTime toFind)
        {
            EventDisplayElement e = null;
            foreach(EventDisplayElement eed in this.eeds)
            {
                if (eed.assignedDate.Date == toFind.Date)
                {
                    e = eed;
                }
            }
            return e;
        }


        public void registerEvents(List<ReturnReserveEvent> returnReserveEvents)
        {
            
            foreach (ReturnReserveEvent returnReserveEvent in returnReserveEvents)
            {
                EventDisplayElement found = findEEDbyDate(returnReserveEvent.eventdate);
                if (found != null)
                {
                    found.addEvent(returnReserveEvent);
                    Console.WriteLine("ADDED ELEMENT ON" + found.assignedDate.ToShortDateString());
                }
                else
                {
                    Console.WriteLine("Not found eed for " + returnReserveEvent.eventdate.ToString());
                }
                
            }
            

        }
    }
}
