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
    public partial class Chartscs : Form
    {
        public Chartscs()
        {
            InitializeComponent();
        }
        public List<int> max_time ;
        public int counter = 1;
        public int total = 0;
        public List<List<bool>> Yaxis;
        private void Chartscs_Load(object sender, EventArgs e)
        {
            this.label1.Text = counter.ToString();
            for (int i = 0; i < max_time[counter - 1]; i++)
            {
                this.chart1.Series["Server"].Points.AddXY(i+1, Yaxis[counter - 1][i] == true);
            }
            counter++;
        }
        private void display()
        {
            if (counter-1 == total)
            {
                this.Close();
                return;
            }
                
            this.label1.Text = counter.ToString();
            for (int i = 0; i < max_time[counter - 1]; i++)
            {
                this.chart1.Series["Server"].Points.AddXY(i+1, Yaxis[counter - 1][i] == true);
            }
            counter++;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.chart1.Series["Server"].Points.Clear();
            display();
        }
    }
}
