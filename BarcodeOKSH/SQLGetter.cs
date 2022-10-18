using System;
using System.Collections.Generic;
using System.Configuration;
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
            try
            {

                connection.Open();
                Console.WriteLine("COnnection = true");
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
                Console.WriteLine(ex.Message);
                return false;
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
                Console.WriteLine(ex.Message);
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
                Console.WriteLine("COnnection = true");
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {

                   // list.Add(dataReader["firstname"] + "," + dataReader["lastname"] + "," + dataReader["userid"]);
                    list.Add(new Person(dataReader["firstname"].ToString(), dataReader["lastname"].ToString(), dataReader["userid"].ToString()));
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

            database = "users";
            //Create a list to store the result
            List<Person> list = new List<Person>();
            ID = "'" + ID + "'";
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

                    // list.Add(dataReader["firstname"] + "," + dataReader["lastname"] + "," + dataReader["userid"]);
                    list.Add(new Person(dataReader["firstname"].ToString(), dataReader["lastname"].ToString(), dataReader["userid"].ToString()));
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


        public void insertPerson(string fn, string ln, string userid) {
            database = "users";
            //Open connection
            if (OpenConnection() == true)
            {
                string query = "INSERT INTO users (firstname, lastname, userid)"
                    +"VALUES (" + fn + "," + ln + "," + userid + ");";
                MySqlCommand comm = connection.CreateCommand();
                comm.CommandText = "INSERT INTO users(firstname,lastname,userid) VALUES (@firstname, @lastname,@userid)";
                comm.Parameters.AddWithValue("@firstname", fn);
                comm.Parameters.AddWithValue("@lastname", ln);
                comm.Parameters.AddWithValue("@userid", userid);
                comm.ExecuteNonQuery();
                CloseConnection();
            }
        }

        public void lendObjectToPerson(string personid, string objectid,string datestring)
        {
            database = "objects";
            if (OpenConnection() == true)
            {

                MySqlCommand comm = connection.CreateCommand();
                comm.CommandText = "UPDATE objects SET borrower=@personid,status=1,borroweduntil=@returndate WHERE barcode=@objectid;";
                comm.Parameters.AddWithValue("@personid", personid);
                comm.Parameters.AddWithValue("@objectid", objectid);
                comm.Parameters.AddWithValue("@returndate", datestring);
                Console.WriteLine("Lending object query" + comm.CommandText);
                comm.ExecuteNonQuery();
                CloseConnection();

            } 
        }


        public List<string> selectObject(string query)
        {
            database = "objects";
            //Create a list to store the result
            List<string> list = new List<string>();

            //Open connection
            if (OpenConnection() == true)
            {
                Console.WriteLine("COnnection = true");
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {

                    list.Add(dataReader["name"] + "," + dataReader["barcode"] + "," + dataReader["borrower"] + "," + dataReader["borroweduntil"] + "," + dataReader["status"]);
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



        public List<LendingObject> selectAllObjects()
        {
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
                    try
                    {
                        DateTime dt = dataReader.GetDateTime("borroweduntil");


                        //list.Add(dataReader["name"] + "," + dataReader["barcode"] + "," + dataReader["borrower"] + "," + dataReader["borroweduntil"] + "," + dataReader["status"]);
                        list.Add(new LendingObject(dataReader["name"].ToString(), dataReader["barcode"].ToString(), dataReader["status"].ToString(), dt));
                    }
                    catch (Exception ex)
                    {
                        list.Add(new LendingObject(dataReader["name"].ToString(), dataReader["barcode"].ToString(), dataReader["status"].ToString()));
                    }
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

            }

        public List<LendingObject> selectObjectByReturnDate(string cutoffdate)
        {
            database = "objects";
            //Create a list to store the result
            List<LendingObject> list = new List<LendingObject>();

            //Open connection
            if (OpenConnection() == true)
            {
                cutoffdate = "'"+cutoffdate+"'";

                string query = "SELECT * FROM objects WHERE borroweduntil<=" + cutoffdate+ ";";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    DateTime dt = dataReader.GetDateTime("borroweduntil");
                    
                    LendingObject lo = new LendingObject(dataReader["name"].ToString(), dataReader["barcode"].ToString(), dataReader["status"].ToString(), dt);
                    lo.borrower = dataReader["borrower"].ToString();
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
        }

        public List<LendingObject> selectObjectByBarcode(string barcode)
        {
            database = "objects";
            //Create a list to store the result
            List<LendingObject> list = new List<LendingObject>();

            //Open connection
            if (OpenConnection() == true)
            {
                Console.WriteLine("COnnection = true");
                string query = "SELECT * FROM objects WHERE barcode=" + barcode + ";";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {

                    //list.Add(dataReader["name"] + "," + dataReader["barcode"] + "," + dataReader["borrower"] + "," + dataReader["borroweduntil"] + "," + dataReader["status"]);
                    list.Add(new LendingObject(dataReader["name"].ToString(), dataReader["barcode"].ToString(), dataReader["status"].ToString()));
             
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

        public void returnObject(string objectid, string status)
        {
            database = "objects";
            if (OpenConnection() == true)
            {

                MySqlCommand comm = connection.CreateCommand();
                comm.CommandText = "UPDATE objects SET borrower=NULL,status=@status,borroweduntil=NULL WHERE barcode=@objectid;";
                comm.Parameters.AddWithValue("@status", status);
                comm.Parameters.AddWithValue("@objectid", objectid);
                comm.ExecuteNonQuery();
                CloseConnection();

            }
        }
        public void insertObject(string name, string barcode)
        {
            database = "objects";
            //Open connection
            if (OpenConnection() == true)
            {

                MySqlCommand comm = connection.CreateCommand();
                comm.CommandText = "INSERT INTO objects(name,barcode) VALUES(@name,@barcode)";
                comm.Parameters.AddWithValue("@name", name);
                comm.Parameters.AddWithValue("@barcode", barcode);
                comm.ExecuteNonQuery();
                CloseConnection();
            }
        }



        //Count statement
        public int Count(string query)
        {
            int Count = -1;

            //Open Connection
            if (OpenConnection() == true)
            {
                //Create Mysql Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //ExecuteScalar will return one value
                Count = int.Parse(cmd.ExecuteScalar() + "");

                //close Connection
                CloseConnection();

                return Count;
            }
            else
            {
                return Count;
            }
        }
    }
}