using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBase
{
    
    public partial class AAJFurnitures : Form
    {
        public static int a = 0;//This variable is to store total price of customer shopping
        LinkedList l=new LinkedList();
        public AAJFurnitures()
        {
            InitializeComponent();
        }

        private void AAJFurnitures_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            l.Add(9000, "Single black Coloured sofa");
            a = a + 9000;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            l.Add(25000, "Glassy wood table");
            a = a + 25000;
        }

        private void button13_Click(object sender, EventArgs e)
        {//If...else to make sure that customer does not leave without buying anything
            if (l.start == null)
            {
                LeavingWithoutShop lws = new LeavingWithoutShop();
                lws.Show();
            }
            else
            {
                this.Hide();
                AAJFurniture3 form2 = new AAJFurniture3();
                form2.passList(this.l);//Passing linked list to next AAJ3 form
                form2.Show(); // or form.ShowDialog(this);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Hide();
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

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            l.Add(80000, "single Bed");
            a = a + 80000;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            l.Add(30000, "Fancy sofa");
            a = a + 30000;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            l.Add(25000, "Home office table");
            a = a + 25000;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            l.Add(50000, "Full Dinner Furniture Collection");
            a = a + 50000;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            l.Add(20000, "Office drawer cabbin set");
            a = a + 20000;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            l.Add(12000, "Single glass oval shaped table");
            a = a + 12000;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            l.Add(60000, "Sky blue sofa set");
            a = a + 60000;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            l.Add(10000, "Endearing kitchen storage");
            a = a + 10000;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            l.Add(8000, "Single rounded table");
            a = a + 8000;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            l.Add(25000, "Serving cart");
            a = a + 25000;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            l.RESET();
        }
    }
}
//Creating our linked list

 public  class Product
{
    //Public because otherwise they will be private and we may not access them
    public string Prname;
    public int prodPrice;
    public Product next;
}
//Creating class that performs operation on our created linked list
//Using unsafe because pointers can only be used with this,otherwise not
 public class LinkedList
{
    public Product start;
    public void Add(int price, string desc)
    {

        if (start == null)
        {
            Product p = new Product();
            p.Prname = desc;
            p.prodPrice = price;
            p.next = null;
            start = p;
            //Only for checking that data is being stored or not
            string a = "Added to cart";
            MessageBox.Show(a);
            
        }
        else
        {
                Product q = new Product();
                q.next = start;
                q.prodPrice = price;
                q.Prname = desc;
                start = q;
                //Just for checking data is being stored or not
                string b = "Added to cart";
                MessageBox.Show(b);
            }
        }
     //Only for checking
     //For resetting all information, delete function
    public void RESET()
    {
        //Now resetting all values
        while (start != null)
        {
            start = start.next;
        }
    }
}
//LinkedList has ben designed which will contain our data in main memory
