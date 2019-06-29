using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace WindowsFormsApplication1
{      
    public partial class CustomerBooking : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-CM6M00F\SQLEXPRESS;Initial Catalog=Sumon;Integrated Security= true;");
        int bus_id1;
        string bus_name;
        string from_where;
        string to_where;
        string dep_time;
        string arr_time;
        string date_of_journey;
        int amount;

        public CustomerBooking()
        {
            InitializeComponent();
            LoadData();
        }

        //search buses button
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                conn.Open();
                string queryy = "select * from new_bus_info where from_where='" + textBox1.Text + "'and to_where='" + textBox2.Text + "'and date_of_journey='" + textBox3.Text + "'";
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
                    MessageBox.Show("There have no such schedule");
                    conn.Close();

                    ClearData();
                }
            }
            else
            {
                MessageBox.Show("Please provide the information!");
            }
        }

        //admin log in page
        private void button2_Click(object sender, EventArgs e)
        {
            AdminLogIn obj = new AdminLogIn();               

            obj.Show();
            this.Hide();
        }

        private void LoadData()
        {
            string cmd = "select * from new_bus_info";
            SqlDataAdapter adp = new SqlDataAdapter(cmd, conn);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        //seat booking button
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox6.Text != "" && textBox5.Text != "" && textBox7.Text != "" && bus_id1 > 0 && bus_name != "" && from_where != "" && to_where != "" && dep_time != "" && arr_time != "" && date_of_journey != "")
            {
                //total fare for selected seat amount
                int total_amount;
                total_amount = amount * Convert.ToInt32(textBox7.Text);

                //random ticket number
                Random RandomNumber = new Random();
                int no = RandomNumber.Next(10000000, 99999999); 

                conn.Open();
                string query = "INSERT INTO passenger_info (ticket_no, name, contact_no, email, seat_amount, bus_id, bus_name, from_where, to_where, dep_time, arr_time, date_of_journey, fare, total_fare)VALUES (@ticket_no, @name, @contact_no, @email, @seat_amount, @bus_id, @bus_name, @from_where, @to_where, @dep_time, @arr_time, @date_of_journey, @fare, @total_fare) ";
                SqlCommand bcmd = new SqlCommand(query, conn);
                bcmd.Parameters.AddWithValue("@ticket_no", no);
                bcmd.Parameters.AddWithValue("@name", textBox6.Text);
                bcmd.Parameters.AddWithValue("@contact_no", textBox5.Text);
                bcmd.Parameters.AddWithValue("@email", textBox4.Text);
                bcmd.Parameters.AddWithValue("@seat_amount", textBox7.Text);
                bcmd.Parameters.AddWithValue("@bus_id", bus_id1);
                bcmd.Parameters.AddWithValue("@bus_name", bus_name);
                bcmd.Parameters.AddWithValue("@from_where", from_where);
                bcmd.Parameters.AddWithValue("@to_where", to_where);
                bcmd.Parameters.AddWithValue("@dep_time", dep_time);
                bcmd.Parameters.AddWithValue("@arr_time", arr_time);
                bcmd.Parameters.AddWithValue("@date_of_journey", date_of_journey);
                bcmd.Parameters.AddWithValue("@fare", amount);
                bcmd.Parameters.AddWithValue("@total_fare", total_amount);
                bcmd.ExecuteNonQuery();

                string queryy = "update new_bus_info set avai_seat = avai_seat - '" + textBox7.Text + "'  where bus_id ='" + bus_id1 + "'";
                SqlDataAdapter sda = new SqlDataAdapter(queryy, conn);
                sda.SelectCommand.ExecuteNonQuery();

                //pdf format
                Document document = new Document();
                PdfWriter.GetInstance(document, new FileStream("C:/Users/USER/Desktop/" + textBox6.Text + ".pdf", FileMode.Create));
                document.Open();
                Paragraph p = new Paragraph("Ticket Number= " + no + "" + Environment.NewLine + " Name= " + textBox6.Text + "" + Environment.NewLine + " Contact Number= " + textBox5.Text + "" + Environment.NewLine + "Seat Amount= " + textBox7.Text + "" + Environment.NewLine + " Bus Id= " + bus_id1 + "" + Environment.NewLine + "Bus Name= " + bus_name + "" + Environment.NewLine + "From= " + from_where + "" + Environment.NewLine + "To= " + to_where + "" + Environment.NewLine + "Departure time= " + dep_time + "" + Environment.NewLine + "Arrival time= " + arr_time + "" + Environment.NewLine + "Total fare= " + total_amount + "");
                document.Add(p);
                document.Close(); 

                conn.Close();

                MessageBox.Show("Successfully booked and generated your ticket in your home screen(desktop).");

                LoadData();
                ClearData();
            }
            else 
            {
                MessageBox.Show("Please provide or select the information correctly");
            }
        }

        private void ClearData()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            bus_id1 = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            bus_name = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            from_where = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            to_where = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            dep_time = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            arr_time = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            amount = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString());
            date_of_journey = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
        }

        //previous button(Home page)
        private void button4_Click(object sender, EventArgs e)
        {
            Welcome obj = new Welcome();

            obj.Show();
            this.Hide();
        }
    }
}