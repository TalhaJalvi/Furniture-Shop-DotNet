using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
namespace DataBase
{
    public partial class Feedback : Form
    {
        public Feedback()
        {
            InitializeComponent();
        }

        private void Feedback_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {   //Taking string variable and storing data in it from text field and sending it to database
            OracleConnection conn = new OracleConnection("DATA SOURCE=DESKTOP-1PMN2TN:1521/XE;USER ID=SYSTEM;password=123");
            try
            {
                string Feed = "Insert into JALVI.Feedback(feedback)values(:feed)";
                OracleCommand cmd = new OracleCommand(Feed);//This is for executing new oracle commands;Inserting data into customerInfo
                cmd.CommandType = CommandType.Text;//Giving commandtype
                cmd.Connection = conn;
                conn.Open();//Openeing connection so that data can be inserted or deleted
                cmd.Parameters.Add(new OracleParameter(":feed", richTextBox1.Text));
                cmd.ExecuteNonQuery();
                conn.Close();

            }
            catch(Exception)
            {
                MessageBox.Show("Error ");
            }
            //Just for checking that text has been stored or not
            MessageBox.Show("Feedback submitted");
            this.Hide();
            Form1 form = new Form1();
            form.Show(); // or form.ShowDialog(this);
        }
    }
}
