using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NUnit.Framework;

namespace WindowsFormsApplication1
{
    public class Database
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-CM6M00F\SQLEXPRESS;Initial Catalog=Sumon;Integrated Security= true;");
        public bool entrybusdata(int bus_id, string bus_name, string from_where, string to_where, string date_of_journey, string dep_time, string arr_time, int avai_seat, int fare) 
        {
            conn.Open();
            string query1 = "select * from new_bus_info where bus_id = '" + bus_id + "'";
            string query = "INSERT INTO new_bus_info (bus_id,bus_name,from_where,to_where,date_of_journey,dep_time,arr_time,avai_seat,fare)VALUES (@bus_id,@bus_name,@from_where,@to_where,@date_of_journey,@dep_time,@arr_time,@avai_seat,@fare) ";
            SqlCommand bcmd = new SqlCommand(query, conn);
            SqlCommand bcmd1 = new SqlCommand(query1, conn);
            SqlDataAdapter da = new SqlDataAdapter(bcmd1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Error: This bus id exists in database");
                conn.Close();
            }
            else
            {
                bcmd.Parameters.AddWithValue("@bus_id", bus_id);
                bcmd.Parameters.AddWithValue("@bus_name", bus_name);
                bcmd.Parameters.AddWithValue("@from_where", from_where);
                bcmd.Parameters.AddWithValue("@to_where", to_where);
                bcmd.Parameters.AddWithValue("@date_of_journey", date_of_journey);
                bcmd.Parameters.AddWithValue("@dep_time", dep_time);
                bcmd.Parameters.AddWithValue("@arr_time", arr_time);
                bcmd.Parameters.AddWithValue("@avai_seat", avai_seat);
                bcmd.Parameters.AddWithValue("@fare", fare);
                bcmd.ExecuteNonQuery();
                MessageBox.Show("Information Inserted Successfully");
                conn.Close();
            }
            return true;
        }
        public bool deletebusdata(int bus_id) 
        {
            conn.Open();
            string query1 = "select * from new_bus_info where bus_id = '" + bus_id + "'";
            string query = "delete from new_bus_info where bus_id='" + bus_id + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            SqlCommand bcmd1 = new SqlCommand(query1, conn);
            SqlDataAdapter da = new SqlDataAdapter(bcmd1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                sda.SelectCommand.ExecuteNonQuery();
                MessageBox.Show("Delete successfully");
                conn.Close();
            }
            else
            {
                MessageBox.Show("Error: This bus schedule does not exist in database");
                conn.Close(); 
            }
            return true;
        }
        public bool updatebusdata(int bus_id, string bus_name, string from_where, string to_where, string date_of_journey, string dep_time, string arr_time, int avai_seat, int fare) 
        {
            conn.Open();
            string query1 = "select * from new_bus_info where bus_id = '" + bus_id + "'";
            string query = "update new_bus_info set bus_id = '" + bus_id + "', bus_name = '" + bus_name + "', from_where = '" + from_where + "', to_where = '" + to_where + "', dep_time = '" + dep_time + "', arr_time = '" + arr_time + "', avai_seat = '" + avai_seat + "', fare = '" + fare + "', date_of_journey = '" + date_of_journey + "'  where bus_id = '" + bus_id + "'";
            SqlCommand bcmd = new SqlCommand(query, conn);
            SqlCommand bcmd1 = new SqlCommand(query1, conn);
            SqlDataAdapter da = new SqlDataAdapter(bcmd1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                bcmd.Parameters.AddWithValue("@bus_id", bus_id);
                bcmd.Parameters.AddWithValue("@bus_name", bus_name);
                bcmd.Parameters.AddWithValue("@from_where", from_where);
                bcmd.Parameters.AddWithValue("@to_where", to_where);
                bcmd.Parameters.AddWithValue("@date_of_journey", date_of_journey);
                bcmd.Parameters.AddWithValue("@dep_time", dep_time);
                bcmd.Parameters.AddWithValue("@arr_time", arr_time);
                bcmd.Parameters.AddWithValue("@avai_seat", avai_seat);
                bcmd.Parameters.AddWithValue("@fare", fare);
                bcmd.ExecuteNonQuery();
                MessageBox.Show("Updated successfully");
                conn.Close();
            }
            else
            {
                MessageBox.Show("Error: This bus id does not exist");
                conn.Close();
            }
            return true;
        }

        public int Conv(string s)
        {
            if (s != null)
                return Convert.ToInt32(s);
            else
                throw new ArgumentNullException("Can not be null");
        }

        public bool Nullcheck(string bus_id1, string bus_name, string from_where, string to_where, string date_of_journey, string dep_time, string arr_time, string avai_seat1, string fare1)
         {
             if (bus_id1 == null || bus_name == null || from_where == null || to_where == null || date_of_journey == null || dep_time == null || arr_time == null || avai_seat1 == null || fare1 == null)
                 throw new ArgumentNullException("Can not be null");
             else
                 return true;
         }

        public bool Nullcheck1(string bus_id1)
        {
            if (bus_id1 == null)
                throw new ArgumentNullException("Can not be null");
            else
                return true; 
        }
    }
}
