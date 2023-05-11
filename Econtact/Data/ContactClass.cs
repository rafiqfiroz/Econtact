using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Econtact.Data
{
    public class ContactClass
    {
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        static string myconnstring = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString; 
        //Selecting Data from Database
        public DataTable Select()
        {
            //Make Connectionstring
            SqlConnection conn = new SqlConnection(myconnstring);
            DataTable dt = new DataTable();
            try
            {
                //wrinting sql query
                string sql = "Select * From tbl_Contact";
                SqlCommand cmd= new SqlCommand(sql,conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close(); 
            }
            return dt;
        }
        //Inserting Data into Database
        public bool Insert(ContactClass contact)
        {
            //creating a default return type and settings its value to false

            bool isSuccess=false;
            SqlConnection conn = new SqlConnection(myconnstring);
            try
            {
                string sql = "Insert into tbl_Contact(FirstName,LastName,ContactNo,Address,Gender)Values(@FirstName,@LastName,@ContactNo,@Address,@Gender)";
                SqlCommand cmd=new SqlCommand(sql,conn);
                cmd.Parameters.AddWithValue("@FirstName",contact.FirstName);
                cmd.Parameters.AddWithValue("@LastName", contact.LastName);
                cmd.Parameters.AddWithValue("@ContactNo", contact.ContactNo);
                cmd.Parameters.AddWithValue("@Address", contact.Address);
                cmd.Parameters.AddWithValue("@Gender", contact.Gender);
                //connection open
                conn.Open();
                int rows=cmd.ExecuteNonQuery();
                if (rows>0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess= false;
                }

            }
            catch (Exception)
            {

                throw;
            }   
            return isSuccess;
        }
        public bool Update(ContactClass contact)
        {
            bool isSuccess=false;
            SqlConnection conn = new SqlConnection(myconnstring);
            try
            {
                string sql = "Update tbl_Contact Set FirstName=@FirstName,LastName=@LastName,ContactNo=@ContactNo,Address=@Address,Gender=@Gender";
                SqlCommand cmd=new SqlCommand(sql,conn);
                cmd.Parameters.AddWithValue("@FirstName", contact.FirstName);
                cmd.Parameters.AddWithValue("@LastName", contact.LastName);
                cmd.Parameters.AddWithValue("@ContactNo", contact.ContactNo);
                cmd.Parameters.AddWithValue("@Address", contact.Address);
                cmd.Parameters.AddWithValue("@Gender", contact.Gender);
                conn.Open();
                int rows=cmd.ExecuteNonQuery();
                if (rows>0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess=false;
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally 
            { 
                conn.Close(); 
            }
            return isSuccess;
        }
        public bool Delete(ContactClass contact) 
        {
            bool isSuccess=false;
            SqlConnection conn = new SqlConnection(myconnstring);
            try
            {
                string sql = "Delete from tbl_Contact where ContactId=@ContactId";
                SqlCommand cmd= new SqlCommand(sql,conn);
                cmd.Parameters.AddWithValue("ContactId",contact.ContactId);
                conn.Open();
                int rows=cmd.ExecuteNonQuery();
                if (rows>0) 
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess=false;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally 
            { 
                conn.Close();
            }
            return isSuccess;
        }
       
    }
}
