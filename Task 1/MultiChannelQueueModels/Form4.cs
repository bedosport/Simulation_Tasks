using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiChannelQueueModels
{
    public partial class Form4 : Form
    {
        public List<int> random_list { get; set; }
        public int numberOfCustomers { get; set; }
        int k = 1;
        
        public Form4()
        {
            InitializeComponent();
            random_list = new List<int>();
            numberOfCustomers = 0;
            label2.Text = "Customer " + k.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(int.Parse(textBox1.Text)>100 || int.Parse(textBox1.Text) < 0)
            {
                MessageBox.Show("Please Enter a Valid Data");
                return;
            }
            random_list.Add(int.Parse(textBox1.Text));
            k++;
            if (k > numberOfCustomers)
                this.Close();
            label2.Text ="Customer "+k.ToString();
            textBox1.Text = "";
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
