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


namespace WindowsFormsApplication1
{
    public partial class AdminLogIn : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-CM6M00F\SQLEXPRESS; Initial Catalog=Sumon; Integrated Security= true;");
        
        public AdminLogIn()
        {
            InitializeComponent();
        }

        //log in button
        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            string query = "select admin_id,password from login where admin_id='" + textBox1.Text + "'and password='" + textBox2.Text + "'";
            SqlCommand cmd = new SqlCommand(query,conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                MessageBox.Show("Login Successfull");
                conn.Close();
                EntryDeleteView obj = new EntryDeleteView();               //admin(Entry new bus, Delete bus schedule, view customer details, seat manage page)

                obj.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("invalid username or password");
                conn.Close();
                ClearData();
            }
        }

        //previous button(Customer booking page)
        private void button5_Click(object sender, EventArgs e)
        {
            CustomerBooking obj = new CustomerBooking();                      

            obj.Show();
            this.Hide();
        }

        private void ClearData()
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }
    }
}
