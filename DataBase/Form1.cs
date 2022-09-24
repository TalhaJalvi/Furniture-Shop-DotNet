using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace DataBase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void homeToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            int n=0;
            while (n<=100)
            {
                Thread.Sleep(25);
                progressBar1.Value = n;
                n++;
            }
            this.Hide();
             AAJFurnitures form = new AAJFurnitures();
             form.Show(); // or form.ShowDialog(this);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

            this.Hide();
            Form1 form = new Form1();
            form.Show(); // or form.ShowDialog(this);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Feedback form = new Feedback();
            form.Show(); // or form.ShowDialog(this);
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            About_us form = new About_us();
            form.Show(); // or form.ShowDialog(this);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Contact_us form = new Contact_us();
            form.Show(); // or form.ShowDialog(this);
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            //To close our Application
            this.Close();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(1);
        }

        private void label1_Click(object sender, EventArgs e)
        {
         
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
