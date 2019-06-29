using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
        }

        //next button(Customer booking page)
        private void button5_Click(object sender, EventArgs e)
        {
            CustomerBooking obj = new CustomerBooking();               
            
            obj.Show();
            this.Hide();
        }
    }
}
