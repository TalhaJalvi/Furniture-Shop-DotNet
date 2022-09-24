using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;//Liberary for thread sleep
using System.Drawing.Printing;//for printing 
using Oracle.ManagedDataAccess.Client;//Libereries  for database connectivity
                                      //We are using ODP.NET Managed Driver  for  our  connection
using System.IO;//Liberary for input and output
namespace DataBase
{


    public partial class AAJFurniture3 : Form
    {//getting linked list from previous form
        static string gender, orders;
        string location = "";//for storing adress of user given image
        LinkedList l = new LinkedList();
        public void passList(LinkedList l)
        {
            this.l = l;
        }
        //Recieving done
 
        public AAJFurniture3()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AAJFurniture3_Load(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Feedback form = new Feedback();
            form.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Contact_us form = new Contact_us();
            form.Show();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            About_us form = new About_us();
            form.Show();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null || textBox2.Text == null || textBox3.Text == null || textBox4.Text == null || textBox5.Text == null || richTextBox1.Text == null || (radioButton1.Checked == false&& radioButton2.Checked==false) || comboBox1.Text == null || comboBox2.Text == null)
            {
                MessageBox.Show("Please Enter your personal details");
            }
            else
            {
                Shopping_successful form = new Shopping_successful();
                form.Show();
                Product p = l.start;
                while (p != null)
                {
                    orders = orders + "," + p.Prname;
                    p = p.next;
                }
                bool isChecked = radioButton1.Checked;//for comparing which radio button is selected
                if (radioButton1.Checked == true)
                {//if male button or radiobutton1 is selected then this if will run otherwise else will execute
                    gender = radioButton1.Text;
                }
                else if (radioButton2.Checked == true)
                {
                    gender = radioButton2.Text;
                }
                else
                {
                    gender = "NULL";
                }
                OracleConnection conn = new OracleConnection("DATA SOURCE=DESKTOP-1PMN2TN:1521/XE;USER ID=SYSTEM;password=123");//Connection password and connection string
                try
                {
                    //BLOB data type used to store image in Oracle ,it stores image in binary
                    FileStream fs = new FileStream(location, FileMode.Open, FileAccess.Read);
                    byte[] b = new byte[fs.Length - 1];
                    fs.Read(b, 0, b.Length);
                    fs.Close();
                    conn.Open();//Openeing connection so that data can be inserted or deleted
                    string InsertCustomerInfo = "Insert into JALVI.Customer_Info(C_NAME,F_Name,Gender,CNIC_NO,COUNTRY,ADRESS,EMAIL,T_BILL,image)values(:Name,:FName,:Gender,:CNIC,:Country,:Adress,:Email,:Bill,:pic)";
                    //Above is oracle query for inserting data
                    OracleCommand cmd = new OracleCommand(InsertCustomerInfo);//This is for executing new oracle commands;Inserting data into customerInfo
                    cmd.CommandType = CommandType.Text;//Giving commandtype
                    cmd.Connection = conn;
                    cmd.Parameters.Add(new OracleParameter(":Name", textBox1.Text));
                    cmd.Parameters.Add(new OracleParameter(":FName", textBox2.Text));
                    cmd.Parameters.Add(new OracleParameter(":Gender", gender));
                    cmd.Parameters.Add(new OracleParameter(":CNIC", textBox3.Text));
                    cmd.Parameters.Add(new OracleParameter(":Country", comboBox2.Text));
                    cmd.Parameters.Add(new OracleParameter(":Adress", richTextBox1.Text));
                    cmd.Parameters.Add(new OracleParameter(":Email", textBox5.Text));
                    cmd.Parameters.Add(new OracleParameter(":Bill", AAJFurnitures.a.ToString()));
                    //Now uploading image to oracle 11g
                    cmd.Parameters.Add(new OracleParameter(":pic", b));
                    cmd.ExecuteNonQuery();
                    string InsrtCOI = "Insert into JALVI.CustomerOI(name,orders)values(:name,:orders)";
                    OracleCommand cmd1 = new OracleCommand(InsrtCOI);
                    cmd1.CommandType = CommandType.Text;
                    cmd1.Connection = conn;
                    cmd1.Parameters.Add(new OracleParameter(":name", textBox1.Text));
                    cmd1.Parameters.Add(new OracleParameter(":orders", orders));
                    cmd1.ExecuteNonQuery();
                    conn.Close();//closing connection

                }
                catch (Exception ex)
                {
                    MessageBox.Show("EROOR! During connection" + ex);
                    MessageBox.Show("ex  " + ex);
                }
                form.Close();

                MessageBox.Show("Thankyou for shopping from here!! Take print of bill give one copy to bank and show one copy to our person");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Variable is above
            //picture uploading code in c#
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();//creating object of dialogbox(which is for selecting images)
                //ofd.Filter = "All picture files (*.*)";//applying filter so that user can select only images(you can ignore it)
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)//checking whether dialog has loaded successfully or not
                {
                    location = ofd.FileName;//Taking user selected file name into location variable.from filename dialog
      
                    uimage.ImageLocation = location;//setting imagebox i.e uimage (image location) to user given location
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error during selection", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);//Creating error 
                //dialog box or message box
            }

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }
        //Printing button coding
        private void button3_Click(object sender, EventArgs e)
        {
            printDialog1.Document = printDocument1;
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();//print command ,printing document 1
            }


        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {//what to write on the bill
            //left is for left corner and right is for uppr height controlling
            e.Graphics.DrawString("Customer Information",new Font("Arial",24,FontStyle.Bold),Brushes.Black,90,140);//Printing customer info
            e.Graphics.DrawString("-------------------------------------------------------------------------",new Font("Arial",24,FontStyle.Regular),Brushes.DarkRed,90,160);//Printing these line as it is
            e.Graphics.DrawString(textBox1.Text, new Font("Arial",12,FontStyle.Bold),Brushes.Black,90,190);//Printing name
            e.Graphics.DrawString(textBox3.Text, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 90, 220);//Printing CNIC no
            //Now for printing gender
            if (radioButton1.Checked==true)
            {//if male button or radiobutton1 is selected then this if will run otherwise else will execute
                 e.Graphics.DrawString(radioButton1.Text, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 90, 250);
            }
            else if(radioButton2.Checked==true)
            {
                e.Graphics.DrawString(radioButton2.Text, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 90, 250);
            }
            else
            {
                e.Graphics.DrawString("No gender selected", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 90, 250);
            }
            
            e.Graphics.DrawString(richTextBox1.Text, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 90, 270);
            e.Graphics.DrawString("BILL INFO", new Font("Arial", 24, FontStyle.Bold), Brushes.DarkRed, 90, 300);
            e.Graphics.DrawString("---------------------------------------------------------------------", new Font("Arial", 24, FontStyle.Bold),Brushes.DarkRed, 90, 330);
            //Creating object of previous forms

            Product q = l.start;
            int i = 330;//For next row so we can use this variable to set position and for next variable
             try
             {
                 while (q != null)
                 {
                     i = i + 30;//Incrementing fof next row
                     int j = 90;
                     e.Graphics.DrawString(q.Prname, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, j, i);
                     e.Graphics.DrawString(q.prodPrice.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, j + 400, i);
                     q = q.next;//Incrementing our linked list
                 }
             }
             catch (Exception)
             {
                 MessageBox.Show("Error empty value");
             }
            e.Graphics.DrawString("Bank Acc No:  HBL 0002447976535789", new Font("Arial", 12, FontStyle.Regular), Brushes.Black,90,i=(i+30));
            //Now showing total price
             e.Graphics.DrawString("--------------------------------------------------------------------", new Font("Arial", 24, FontStyle.Bold), Brushes.DarkRed, 90, i=(i + 30));
             e.Graphics.DrawString("TOTAL", new Font("Arial", 24, FontStyle.Bold), Brushes.DarkRed, 90, i = (i + 30));
             e.Graphics.DrawString(AAJFurnitures.a.ToString(), new Font("Arial", 24, FontStyle.Italic), Brushes.Black, (90+400), i);
        }
        //Printer code ends here

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
