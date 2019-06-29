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
    public partial class EntryDeleteView : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-CM6M00F\SQLEXPRESS;Initial Catalog=Sumon;Integrated Security= true;");
        public EntryDeleteView()
        {
            InitializeComponent();
            LoadData();
        }

        //previous(Log In page)
        private void button5_Click(object sender, EventArgs e)
        {
            AdminLogIn obj = new AdminLogIn();

            obj.Show();
            this.Hide();
        }

        //Entry new bus
        public void button1_Click(object sender, EventArgs e)
        {
            Database C = new Database();
            Business B = new Business();
            string bus_id1 = textBox8.Text;
            string bus_name = textBox5.Text;
            string from_where = textBox1.Text;
            string to_where = textBox2.Text;
            string date_of_journey = textBox9.Text;
            string dep_time = textBox3.Text;
            string arr_time = textBox4.Text;
            string avai_seat1 = textBox6.Text;
            string fare1 = textBox7.Text;
            B.entrybus(bus_id1, bus_name, from_where, to_where, date_of_journey, dep_time, arr_time, avai_seat1, fare1);
            LoadData();
            ClearData();
        }

        //Customer details
        private void button4_Click(object sender, EventArgs e)
        {
            CustomerDetails obj = new CustomerDetails();

            obj.Show();
            this.Hide();
        }

        //Delete bus schedule
        public void button2_Click(object sender, EventArgs e)
        {
            string bus_id1 = textBox8.Text;
            Business B = new Business();
            B.deletebus(bus_id1);
            LoadData();
            ClearData();
        }

        //Update bus schedule
        public void button3_Click(object sender, EventArgs e)
        {
            Business B = new Business();
            string bus_id1 = textBox8.Text;
            string bus_name = textBox5.Text;
            string from_where = textBox1.Text;
            string to_where = textBox2.Text;
            string date_of_journey = textBox9.Text;
            string dep_time = textBox3.Text;
            string arr_time = textBox4.Text;
            string avai_seat1 = textBox6.Text;
            string fare1 = textBox7.Text;
            B.updatebus(bus_id1, bus_name, from_where, to_where, date_of_journey, dep_time, arr_time, avai_seat1, fare1);
            LoadData();
            ClearData();
        }

        public bool LoadData()
        {
            string cmd = "select * from new_bus_info";
            SqlDataAdapter adp = new SqlDataAdapter(cmd, conn);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            return true;
        } 

        public void ClearData()
        {
            textBox8.Text = "";
            textBox5.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox9.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }

        public void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            textBox9.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
        } 
    }
}
