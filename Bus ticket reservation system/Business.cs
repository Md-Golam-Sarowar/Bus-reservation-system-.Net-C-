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
    class Business
    {
        public void entrybus(string bus_id1, string bus_name, string from_where, string to_where, string date_of_journey, string dep_time, string arr_time, string avai_seat1, string fare1)
        {
            Database C = new Database();
            if (bus_id1 != "" && bus_name != "" && from_where != "" && to_where != "" && date_of_journey != "" && dep_time != "" && arr_time != "" && avai_seat1 != "" && fare1 != "")
            {
                int bus_id = C.Conv(bus_id1);
                int avai_seat = C.Conv(avai_seat1);
                int fare = C.Conv(fare1);
                C.entrybusdata(bus_id, bus_name, from_where, to_where, date_of_journey, dep_time, arr_time, avai_seat, fare);
                C.Nullcheck(bus_id1, bus_name, from_where, to_where, date_of_journey, dep_time, arr_time, avai_seat1, fare1);
            }
            else
            {
                MessageBox.Show("Error: Please Provide Details!");
            }
        }
        public void updatebus(string bus_id1, string bus_name, string from_where, string to_where, string date_of_journey, string dep_time, string arr_time, string avai_seat1, string fare1)
        {
            Database C = new Database();
            if (bus_id1 != "" && bus_name != "" && from_where != "" && to_where != "" && date_of_journey != "" && dep_time != "" && arr_time != "" && avai_seat1 != "" && fare1 != "")
            {
                int bus_id = C.Conv(bus_id1);
                int avai_seat = C.Conv(avai_seat1);
                int fare = C.Conv(fare1);
                C.updatebusdata(bus_id, bus_name, from_where, to_where, date_of_journey, dep_time, arr_time, avai_seat, fare);
                C.Nullcheck(bus_id1, bus_name, from_where, to_where, date_of_journey, dep_time, arr_time, avai_seat1, fare1);

            }
            else
            {
                MessageBox.Show("Error: Please Select Record To Update");
            }
        }
        public void deletebus(string bus_id1) 
        {
            Database C = new Database();
            if (bus_id1 != "")
            {
                int bus_id = C.Conv(bus_id1);
                C.deletebusdata(bus_id);
                C.Nullcheck1(bus_id1);

            }
            else
            {
                MessageBox.Show("Error: Provide bus id to Delete");
            }
        }
    }
}
