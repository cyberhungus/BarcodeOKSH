using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BarcodeOKSH
{
    class SQLGetter
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public SQLGetter()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            server = "localhost";
            database = "oksh";
            uid = "root";
            password = "your_password";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + ";";

            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        private bool OpenConnection()
        {
            if (connection.State != ConnectionState.Open)
            {
                try
                {

                    connection.Open();
                    // Console.WriteLine("COnnection = true");
                    return true;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.ToString());
                    //When handling errors, you can your application's response based 
                    //on the error number.
                    //The two most common error numbers when connecting are as follows:
                    //0: Cannot connect to server.
                    //1045: Invalid user name and/or password.
                    switch (ex.Number)
                    {
                        case 0:
                            Console.WriteLine("Cannot connect to server.  Contact administrator");
                            break;

                        case 1045:
                            Console.WriteLine("Invalid username/password, please try again");
                            break;
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("SQLG - OpenConnection throws" , ex.Message);
                    return false;


                }
            }
            else
            {
                return true;
            }


        }


       


        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("SQLG CloseConnection throws: " + ex.Message);
                return false;
            }
        }

        //Select statement
        public List<Person> selectPerson(string query)
        {

            database = "users";
            //Create a list to store the result
            List<Person> list = new List<Person>();

            //Open connection
            if (OpenConnection() == true)
            {
                //Console.WriteLine("COnnection = true");
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {

                    Person p = makePersonFromData(dataReader);
                    list.Add(p);
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                Console.WriteLine("COnnection = false");
                return list;
            }
        }

        public List<Person> selectPersonByID(string ID)
        {

            
            List<Person> result;
            Task<List<Person>> getUrlTask = Task<List<Person>>.Factory.StartNew(() => {


                List<Person> list = new List<Person>();

            if (ID != "" && Helpers.IsDigitsOnly(ID))
            {
                database = "users";
                //Create a list to store the result
                
                //  ID = "'" + ID + "'";
                string query = "SELECT * FROM users WHERE userid=" + ID + ";";
                Console.WriteLine("Searching person by id" + ID + "----" + query);
                //Open connection
                if (OpenConnection() == true)
                {
                    Console.WriteLine("COnnection = true");
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        Person p = makePersonFromData(dataReader);
                        list.Add(p);
                    }

                    //close Data Reader
                    dataReader.Close();

                    //close Connection
                    CloseConnection();

                    //return list to be displayed
                    return list;
                }
                else
                {
                    Console.WriteLine("COnnection = false");
                    return list;
                }
            }
            else
            {
                return list;
            }

            });
            result = getUrlTask.Result;
            return result;
        }

        public List<Person> selectPersonByFirstName(string firstname)
        {
            List<Person> result;
            Task<List<Person>> getUrlTask = Task<List<Person>>.Factory.StartNew(() => {

                List<Person> list = new List<Person>();
            if (firstname != "")
            {
                database = "users";
                //Create a list to store the result

                //  ID = "'" + ID + "'";
                string query = "SELECT * FROM users WHERE firstname LIKE '%" + firstname + "%';";

                //Open connection
                if (OpenConnection() == true)
                {
                    Console.WriteLine("COnnection = true");
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        Person p = makePersonFromData(dataReader);
                        list.Add(p);
                    }

                    //close Data Reader
                    dataReader.Close();

                    //close Connection
                    CloseConnection();

                    //return list to be displayed
                    return list;
                }
                else
                {
                    Console.WriteLine("COnnection = false");
                    return list;
                }
            }
            else
            {
                return list;
            }
        });
            result = getUrlTask.Result;
            return result;
        }

        public List<Person> selectPersonByLastName(string lastname)
        {
            List<Person> result;
            Task<List<Person>> getUrlTask = Task<List<Person>>.Factory.StartNew(() => {

                List<Person> list = new List<Person>();
            if (lastname != "")
            {
                database = "users";
                //Create a list to store the result

                //  ID = "'" + ID + "'";
                string query = "SELECT * FROM users WHERE lastname LIKE '%" + lastname + "%';";

                //Open connection
                if (OpenConnection() == true)
                {
                    Console.WriteLine("COnnection = true");
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                      Person p = makePersonFromData(dataReader);
                        list.Add(p);
                    }

                    //close Data Reader
                    dataReader.Close();

                    //close Connection
                    CloseConnection();

                    //return list to be displayed
                    return list;
                }
                else
                {
                    Console.WriteLine("COnnection = false");
                    return list;
                }
            }
            else
            {
                return list;
            }
        });
            result = getUrlTask.Result;
            return result;
        }




        public void insertPerson(string fn, string ln, string userid,string contactdetail, string govidnum, string address, string dob) {
            database = "users";
            //Open connection
            if (OpenConnection() == true)
            {

                MySqlCommand comm = connection.CreateCommand();
                comm.CommandText = "INSERT INTO users(firstname,lastname,userid,contactdetail,govidnum,address,dob) VALUES (@firstname, @lastname,@userid,@contact,@govid,@address,@dob)";
                comm.Parameters.AddWithValue("@firstname", fn);
                comm.Parameters.AddWithValue("@lastname", ln);
                comm.Parameters.AddWithValue("@userid", userid);
                comm.Parameters.AddWithValue("@contact", contactdetail);
                comm.Parameters.AddWithValue("@govid", govidnum);
                comm.Parameters.AddWithValue("@address", address);
                comm.Parameters.AddWithValue("@dob", dob);
                comm.ExecuteNonQuery();
                CloseConnection();
            }
        }


        public void insertReservation(Reservation res)
        {
            database = "reservations";
            //Open connection
            if (OpenConnection() == true)
            {

                MySqlCommand comm = connection.CreateCommand();
                comm.CommandText = "INSERT INTO reservations(objectids, personid, staffmember, startdate, enddate) VALUES (@objectids, @personid,@staffmember,@startdate,@enddate)";
                comm.Parameters.AddWithValue("@objectids", res.makeItemsString());
                comm.Parameters.AddWithValue("@personid", res.borrower.PersonalID);
                comm.Parameters.AddWithValue("@staffmember",res.staffmember);
                comm.Parameters.AddWithValue("@startdate", Helpers.makeDateTimeSQLString(res.startdate.Date) );
                comm.Parameters.AddWithValue("@enddate",  Helpers.makeDateTimeSQLString(res.enddate.Date) );
                Console.WriteLine(comm.CommandText.ToString());
                comm.ExecuteNonQuery();
                CloseConnection();
            }
        }

        public void lendObjectToPerson(string personid, string objectid,string datestring,string staffmember)
        {
            database = "objects";

            if (OpenConnection() == true )
            {

                MySqlCommand comm = connection.CreateCommand();
                comm.CommandText = "UPDATE objects SET borrower=@personid,borrstatus=1,borrowedon = @nowdate , borroweduntil=@returndate,staffmember=@staffmember WHERE barcode=@objectid;";
                comm.Parameters.AddWithValue("@personid", personid);
                comm.Parameters.AddWithValue("@objectid", objectid);
                comm.Parameters.AddWithValue("@returndate", datestring);
                comm.Parameters.AddWithValue("@nowdate", Helpers.makeDateTimeSQLString(DateTime.Now));
                comm.Parameters.AddWithValue("@staffmember", staffmember);
                Console.WriteLine("Lending object query" + comm.CommandText);
                comm.ExecuteNonQuery();
                CloseConnection();


            } 


        }


        public List<LendingObject> selectAllObjects()
        {
            List<LendingObject> result;
            Task<List<LendingObject>> getUrlTask = Task<List<LendingObject>>.Factory.StartNew(() => {

                database = "objects";
            //Create a list to store the result
            List<LendingObject> list = new List<LendingObject>();

            //Open connection
            if (OpenConnection() == true)
            {

                string query = "SELECT * FROM objects ;";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    LendingObject lo = makeObjectFromData(dataReader);
                    list.Add(lo);
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                CloseConnection();
                return list;
            }
            else
            {
                return list;
            }

                  
            });
            result = getUrlTask.Result;
            return result;
        }

    public List<LendingObject> selectObjectByReturnDate(string cutoffdate)
        {
            List<LendingObject> result;
            Task<List<LendingObject>> getUrlTask = Task<List<LendingObject>>.Factory.StartNew(() => {

                database = "objects";
            //Create a list to store the result
            List<LendingObject> list = new List<LendingObject>();

            //Open connection
            if (OpenConnection() == true)
            {
                cutoffdate = "'"+cutoffdate+"'";

                string query = "SELECT * FROM objects WHERE borroweduntil<=" + cutoffdate+ " AND borroweduntil > '" + Helpers.makeDateTimeSQLString(DateTime.Now) + "' AND borrstatus = '1';";
                    Console.WriteLine("selectobjectbyreturndate query" + query);
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    LendingObject lo = makeObjectFromData(dataReader);
                    list.Add(lo);
                }
                //close Data Reader
                dataReader.Close();

                //close Connection
                CloseConnection();
      

                //return list to be displayed
                return list;
            }
            else
            {
                Console.WriteLine("Connection = false");
                return list;
                }
            });
            result = getUrlTask.Result;
            return result;
        }


        public List<LendingObject> selectLateObjects()
        {
            List<LendingObject> result;
            Task<List<LendingObject>> getUrlTask = Task<List<LendingObject>>.Factory.StartNew(() => {

                database = "objects";
                //Create a list to store the result
                List<LendingObject> list = new List<LendingObject>();

                //Open connection
                if (OpenConnection() == true)
                {


                    string query = "SELECT * FROM objects WHERE borroweduntil < '" + Helpers.makeDateTimeSQLString(DateTime.Now) + "';";
                    Console.WriteLine(query);
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        LendingObject lo = makeObjectFromData(dataReader);
                        list.Add(lo);
                    }
                    //close Data Reader
                    dataReader.Close();

                    //close Connection
                    CloseConnection();


                    //return list to be displayed
                    return list;
                }
                else
                {
                    Console.WriteLine("Connection = false");
                    return list;
                }
            });
            result = getUrlTask.Result;
            return result;
        }

        public List<int> getAllUserIDs()
        {

            database = "users";
            List<int> list = new List<int>();

            //Open connection
            if (OpenConnection() == true)
            {
                Console.WriteLine("COnnection = true");
                string query = "SELECT userid FROM users";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader(); //TO-DO Fehlermeldung wenn nicht nach Zahl gesucht wird

                while (dataReader.Read())
                {
                    try
                    {
                        list.Add(Int32.Parse(dataReader["userid"].ToString()));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("SQLG getAllUserIDS throws " + ex.Message);
                    }

                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                Console.WriteLine("Connection = false");
                return list;
            }
        }

        public List<LendingObject> selectObjectByBorrowerID(string borrowerid)
        {
            List<LendingObject> result;
            Task<List<LendingObject>> getUrlTask = Task<List<LendingObject>>.Factory.StartNew(() => {


                database = "objects";
            Console.WriteLine("Search Object by id" + borrowerid);
            List<LendingObject> list = new List<LendingObject>();

            //Open connection
            if (OpenConnection() == true)
            {
               // Console.WriteLine("COnnection = true");
                string query = "SELECT * FROM objects WHERE borrower=" + borrowerid + ";";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader(); //TO-DO Fehlermeldung wenn nicht nach Zahl gesucht wird

                while (dataReader.Read())
                {
                    LendingObject lo = makeObjectFromData(dataReader);
                    list.Add(lo);
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                Console.WriteLine("Connection = false");
                return list;
            }
        });
            result = getUrlTask.Result;
            return result;
        }

        public List<LendingObject> selectObjectByBarcode(string barcode)
        {
            List<LendingObject> result;
            Task<List<LendingObject>> getUrlTask = Task<List<LendingObject>>.Factory.StartNew(() => {


                database = "objects";
            Console.WriteLine("scanned barcode" + barcode);
            List<LendingObject> list = new List<LendingObject>();

            //Open connection
            if (OpenConnection() == true && barcode != "" && Helpers.IsDigitsOnly(barcode))
            {
               
                string query = "SELECT * FROM objects WHERE barcode=" + barcode + ";";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader(); //TO-DO Fehlermeldung wenn nicht nach Zahl gesucht wird
                    Console.WriteLine(query);
                    while (dataReader.Read())
                {
                    LendingObject lo = makeObjectFromData(dataReader);
                    list.Add(lo);
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                CloseConnection();

                //return list to be displayed
                return list;
            }
            else if (barcode == "")
            {
                Console.WriteLine("EMPTY SEACH STRING ");
                return list; 
            }
            else
            {
                Console.WriteLine("Connection = false");
                return list;
                }
            });
            result = getUrlTask.Result;
            return result;
        }

        public List<LendingObject> selectObjectByStatus(string status)
        {
            List<LendingObject> result = new List<LendingObject>();
            if (status != "")
            {
                Task<List<LendingObject>> getUrlTask = Task<List<LendingObject>>.Factory.StartNew(() =>
                {

                    database = "objects";

                    List<LendingObject> list = new List<LendingObject>();

                    //Open connection
                    if (OpenConnection() == true)
                    {
                        Console.WriteLine("COnnection = true");
                        string query = "SELECT * FROM objects WHERE status=" + status + ";";
                        MySqlCommand cmd = new MySqlCommand(query, connection);
                        MySqlDataReader dataReader = cmd.ExecuteReader(); // TODO Fehlermeldung bei Statussuche

                        while (dataReader.Read())
                        {
                            LendingObject lo = makeObjectFromData(dataReader);
                            list.Add(lo);
                        }

                        //close Data Reader
                        dataReader.Close();

                        //close Connection
                        CloseConnection();

                        //return list to be displayed
                        return list;
                    }
                    else
                    {
                        Console.WriteLine("Connection = false");
                        return list;
                    }
                });
                result = getUrlTask.Result;
                return result;
            }
            else
            {
                return result;
            }
        }
        public List<LendingObject> searchObjectByTags(string searchterm)
        {
            List<LendingObject> result;
            Task<List<LendingObject>> getUrlTask = Task<List<LendingObject>>.Factory.StartNew(() => {

                database = "objects";

            List<LendingObject> list = new List<LendingObject>();

            //Open connection
            if (OpenConnection() == true)
            {

                string query = "SELECT * FROM objects WHERE tags LIKE '%" + searchterm + "%';";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                Console.WriteLine("search by name query ", query);
                while (dataReader.Read())
                {
                    LendingObject lo = makeObjectFromData(dataReader);
                    list.Add(lo);
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                Console.WriteLine("Connection = false");
                return list;
                }
            });
            result = getUrlTask.Result;
            return result;
        }

        public List<LendingObject> searchObjectByName(string searchterm)
            {
                List<LendingObject> result;
                Task<List<LendingObject>> getUrlTask = Task<List<LendingObject>>.Factory.StartNew(() => {

                    database = "objects";

            List<LendingObject> list = new List<LendingObject>();

            //Open connection
            if (OpenConnection() == true)
            {

                string query = "SELECT * FROM objects WHERE objectname LIKE '%" + searchterm + "%';";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                Console.WriteLine("search by name query ", query);
                while (dataReader.Read())
                {
                    LendingObject lo = makeObjectFromData(dataReader);
                    list.Add(lo);
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                Console.WriteLine("Connection = false");
                return list;
                    }
                });
            result = getUrlTask.Result;
            return result;
        }

        public List<LendingObject> selectObjectByBarcodeOnDate(string barcode,string datestring)
        {
            List<LendingObject> result;
            Task<List<LendingObject>> getUrlTask = Task<List<LendingObject>>.Factory.StartNew(() => {


                database = "objects";
            Console.WriteLine("scanned barcode" + barcode);
            List<LendingObject> list = new List<LendingObject>();
            
            //Open connection
            if (OpenConnection() == true)
            {
                Console.WriteLine("COnnection = true");
                string query = "SELECT * FROM objects WHERE barcode=" + barcode + " AND(borrstatus = \"0\" OR borroweduntil < '" + datestring + "'); "; ;
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader(); //TO-DO Fehlermeldung wenn nicht nach Zahl gesucht wird

                while (dataReader.Read())
                {
                    LendingObject lo = makeObjectFromData(dataReader);
                    list.Add(lo);
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                Console.WriteLine("Connection = false");
                return list;
            }
        });
            result = getUrlTask.Result;
            return result;
        }

        public List<LendingObject> selectObjectByStatusOnDate(string status, string datestring)
        {
            List<LendingObject> result;
            Task<List<LendingObject>> getUrlTask = Task<List<LendingObject>>.Factory.StartNew(() => {


                database = "objects";

            List<LendingObject> list = new List<LendingObject>();

            //Open connection
            if (OpenConnection() == true)
            {
                Console.WriteLine("COnnection = true");
                string query = "SELECT * FROM objects WHERE status=" + status + " AND(borrstatus = \"0\" OR borroweduntil < '"+datestring+"'); ";;
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader(); // TODO Fehlermeldung bei Statussuche

                while (dataReader.Read())
                {
                    LendingObject lo = makeObjectFromData(dataReader);
                    list.Add(lo);
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                Console.WriteLine("Connection = false");
                return list;
        }
    });
            result = getUrlTask.Result;
            return result;
        }
        public List<LendingObject> searchObjectByTagsOnDate(string searchterm, string datestring)
        {
            List<LendingObject> result;
            Task<List<LendingObject>> getUrlTask = Task<List<LendingObject>>.Factory.StartNew(() => {

                database = "objects";

            List<LendingObject> list = new List<LendingObject>();

            //Open connection
            if (OpenConnection() == true)
            {

                string query = "SELECT * FROM objects WHERE tags LIKE '%" + searchterm + "%' AND(borrstatus = \"0\" OR borroweduntil < '" + datestring + "' ); "; 
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                Console.WriteLine("search by name query ", query);
                while (dataReader.Read())
                {
                LendingObject lo =  makeObjectFromData(dataReader) ;
                    list.Add(lo);
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                Console.WriteLine("Connection = false");
                return list;
                }
            });
            result = getUrlTask.Result;
            return result;
        }


        public List<LendingObject> searchObjectByNameOnDate(string searchterm, string datestring)
            {
                List<LendingObject> result;
                Task<List<LendingObject>> getUrlTask = Task<List<LendingObject>>.Factory.StartNew(() => {

                    database = "objects";

            List<LendingObject> list = new List<LendingObject>();

            //Open connection
            if (OpenConnection() == true)
            {

                string query = "SELECT * FROM objects WHERE objectname LIKE '%" +searchterm + "%' AND(borrstatus = \"0\" OR borroweduntil < '" + datestring + "' ) ";
                //Console.WriteLine("sobnod" + query);
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                Console.WriteLine("search by name query ", query);
                while (dataReader.Read())
                {
 makeObjectFromData(dataReader);
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                Console.WriteLine("Connection = false");
                return list;
                    }
                });
            result = getUrlTask.Result;
            return result;
        }


        public void returnObject(string objectid, string status, string staffmember)
        {
            database = "objects";
            if (OpenConnection() == true)
            {

                MySqlCommand comm = connection.CreateCommand();
                comm.CommandText = "UPDATE objects SET borrower=NULL,borrstatus=@status,borroweduntil=NULL,staffmember=@staff WHERE barcode=@objectid;";
                comm.Parameters.AddWithValue("@status", status);
                comm.Parameters.AddWithValue("@objectid", objectid);
                comm.Parameters.AddWithValue("@staff", staffmember);
                comm.ExecuteNonQuery();
                CloseConnection();

            }
        }
        public Boolean insertObject(string name, string barcode,string tags)
        {
            List<LendingObject> result = selectObjectByBarcode(barcode);


            database = "objects";

            if (result.Count == 0)
            {
                if (OpenConnection() == true)
                {

                    MySqlCommand comm = connection.CreateCommand();
                    comm.CommandText = "INSERT INTO objects(objectname,barcode,borrstatus,tags) VALUES(@name,@barcode,0,@tags)";
                    comm.Parameters.AddWithValue("@name", name);
                    comm.Parameters.AddWithValue("@barcode", barcode);
                    comm.Parameters.AddWithValue("@tags", tags);
                    comm.ExecuteNonQuery();
                    CloseConnection();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else return false;
        }

        public Person makePersonFromData(MySqlDataReader reader)
        {
            Person toReturn = new Person();
            toReturn.FirstName = reader["firstname"].ToString();
            toReturn.LastName = reader["lastname"].ToString();
            toReturn.PersonalID = reader["userid"].ToString();
            toReturn.contactdetails = reader["contactdetail"].ToString();
            toReturn.govidnum = reader["govidnum"].ToString();
            toReturn.Address = reader["address"].ToString();

            string datestring = reader.GetMySqlDateTime("dob").ToString();
           
            toReturn.DateOfBirth = Helpers.makeDateFromString(datestring);


            return toReturn;
        }


        public Reservation makeReservationFromData(MySqlDataReader reader)
        {
            Reservation toReturn = new Reservation();
            try
            {
                toReturn.borrower = new SQLGetter().selectPersonByID(reader["personid"].ToString())[0];
            }
            catch (Exception ex)
            {
                toReturn.borrower = new Person("NICHT", "BEKANNT", "0");
                Console.WriteLine("Not found person" + reader["personid"].ToString());
            }
           toReturn.enddate = reader.GetDateTime("enddate");
            //toReturn.enddate = Helpers.makeDateFromString(enddatestring.Split(' ')[0]);
            
            toReturn.startdate = reader.GetDateTime("startdate");


            toReturn.staffmember = reader["staffmember"].ToString();


            foreach (string itemstring in reader["objectids"].ToString().Split(':'))
            {
                try
                {
                    if (itemstring != "")
                    {
                        LendingObject objToAdd = new SQLGetter().selectObjectByBarcode(itemstring)[0];
                        if (objToAdd != null)
                        {
                            toReturn.addItem(objToAdd);
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine("SQLG MakeReserfromdata throws " + ex.Message); }


                
            }
            return toReturn;
        }

        public LendingObject makeObjectFromData(MySqlDataReader reader)
        {
            LendingObject lo = new LendingObject();
            DateTime dt;
            try
            {
                 dt = reader.GetDateTime("borroweduntil");
            }
            catch (Exception ex)
            {
                dt = new DateTime(1,1,1);
            }

            try
            {
                lo.borrower = reader["borrower"].ToString();
            }
            catch (Exception ex)
            {
                lo.borrower=null;
            }

            lo.name = reader["objectname"].ToString();
            lo.status = reader["borrstatus"].ToString();
            
            lo.code = reader["barcode"].ToString();
            lo.borrowedUntil = dt;


            lo.staffmember = reader["staffmember"].ToString();
            return lo;


        }
        public List<Reservation> selectAllReservations()
        {
            List<Reservation> result;
            Task<List<Reservation>> getUrlTask = Task<List<Reservation>>.Factory.StartNew(() => {

                database = "reservations";
            //Create a list to store the result
            List<Reservation> list = new List<Reservation>();

            //Open connection
            if (OpenConnection() == true)
            {

                string query = "SELECT * FROM reservations ;";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    list.Add(makeReservationFromData(dataReader));
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                CloseConnection();

                return list;
            }
            else
            {
                return list;
                }
            });
            result = getUrlTask.Result;
            return result;

        }


        public List<Reservation> selectReservationsActiveOnDate(DateTime date)
        {
            List<Reservation> result;
            Task<List<Reservation>> getUrlTask = Task<List<Reservation>>.Factory.StartNew(() => {

                database = "reservations";
            //Create a list to store the result
            List<Reservation> list = new List<Reservation>();

            //Open connection
            if (OpenConnection() == true)
            {

                string query = String.Format("SELECT * FROM reservations WHERE startdate < '{0}' ;",Helpers.makeDateTimeSQLString(date));
                    Console.WriteLine(query);
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    list.Add(makeReservationFromData(dataReader));
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                CloseConnection();

                return list;
            }
            else
            {
                return list;
            }
        });
            result = getUrlTask.Result;
            return result;

        }

        public List<Reservation> selectReservationsByItem(string objectid)
        {
            database = "reservations";
            //Create a list to store the result
            List<Reservation> list = new List<Reservation>();

            //Open connection
            if (OpenConnection() == true)
            {

                string query = "SELECT * FROM reservations WHERE objectids LIKE '%"+objectid+"%';";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    list.Add(makeReservationFromData(dataReader));
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                CloseConnection();

                Console.WriteLine("Number of Reservations with " + objectid + " was " + list.Count);
                return list;
            }
            else
            {
                return list;
            }

        }


        public List<ReturnReserveEvent> generateEventsUntilDate(DateTime date)
        {
            List<LendingObject> objects = selectObjectByReturnDate(Helpers.makeDateTimeSQLString(date));
            List<Reservation> reservations = selectReservationsActiveOnDate(date);
            List<ReturnReserveEvent> events = new List<ReturnReserveEvent>();
            foreach (LendingObject lendingObject in objects)
            {
                foreach (DateTime dt in Helpers.datesBetweenDates(DateTime.Now.Date, lendingObject.borrowedUntil))
                {
                    events.Add(new ReturnReserveEvent(lendingObject, dt));
                }

            }
            foreach (Reservation reservation in reservations)
            {
                foreach (DateTime dt in Helpers.datesBetweenDates(reservation.startdate, reservation.enddate))
                {
                    events.Add(new ReturnReserveEvent(reservation, dt));
                }
               // events.Add(new ReturnReserveEvent(reservation));
            }
            return events;


        }


    }
}