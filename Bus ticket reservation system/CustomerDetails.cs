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
    public partial class CustomerDetails : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-CM6M00F\SQLEXPRESS; Initial Catalog=Sumon; Integrated Security= true;");

        int ticketno;
        string name;
        int seat_amount;
        int bus_id;
        string bus_name;
        string from_where;
        string to_where;
        string dep_time;
        string arr_time;
        string date_of_journey;

        public CustomerDetails()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            string cmd = "select * from passenger_info";
            SqlDataAdapter adp = new SqlDataAdapter(cmd, conn);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        //previous button(EntryDeleteView page)
        private void button1_Click(object sender, EventArgs e)
        {
            EntryDeleteView obj = new EntryDeleteView();               //admin(Entry new bus, Delete bus schedule, view customer details, update details)

            obj.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                conn.Open();
                string queryy = "select * from passenger_info where ticket_no='" + textBox1.Text + "' and name='" + textBox2.Text + "'";
                SqlDataAdapter adp = new SqlDataAdapter(queryy, conn);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                    conn.Close();

                    ClearData();
                }
                else
                {
                    MessageBox.Show("This ticket is not exist.");
                    conn.Close();

                    ClearData();
                }
            }
            else
            {
                MessageBox.Show("Please provide the information!");
            }
        }

        private void ClearData()
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ticketno = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            name = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            seat_amount = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
            bus_id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
            bus_name = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            from_where = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            to_where = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            dep_time = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            arr_time = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
            date_of_journey = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (name != "")
            {
                conn.Open();

                string query = "delete from passenger_info where ticket_no='" + ticketno + "' and name='" + name + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                sda.SelectCommand.ExecuteNonQuery();

                string queryy = "update new_bus_info set avai_seat = avai_seat + '" + seat_amount + "'  where bus_id ='" + bus_id + "'";
                SqlDataAdapter pq = new SqlDataAdapter(queryy, conn);
                pq.SelectCommand.ExecuteNonQuery();

                MessageBox.Show("Delete successfully");

                conn.Close();

                LoadData();
            }
            else
            {
                MessageBox.Show("Please Select Record to Delete");
            } 
        }
    }
}
