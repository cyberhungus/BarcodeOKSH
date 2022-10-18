using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace BarcodeOKSH
{


    internal class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalID { get; set; }
        public DateTime DateOfBirth { get; set; } 

        public string Company { get; set; }

        public string PhonePrivate { get; set; }

        public string PhoneWork { get; set; }

        public string ZipCode { get; set; }

        public string Address { get; set; }



        public Person(string FirstName, string LastName, string PersonalID, DateTime DOB)
        {

            this.FirstName= FirstName;
            this.LastName = LastName;
            this.PersonalID = PersonalID;
            this.DateOfBirth = DOB; 

        }

        public Person(string FirstName, string LastName, string PersonalID)
        {

            this.FirstName = FirstName;
            this.LastName = LastName;
            this.PersonalID = PersonalID;
            
        }


            public string getJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        



    }
}
