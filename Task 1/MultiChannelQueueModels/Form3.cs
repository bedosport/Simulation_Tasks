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
    public partial class Form3 : Form
    {
        public int cnt_TimeDistribution { get; set; }
        public List<TimeDistribution> TimeDistribution { get; set; }
        public Form3()
        {
            TimeDistribution = new List<TimeDistribution>();
            cnt_TimeDistribution = 0;
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cnt_TimeDistribution++;
            TimeDistribution t = new TimeDistribution();
            t.Time = int.Parse(textBox1.Text.ToString());
            t.Probability = double.Parse(textBox2.Text.ToString());
            if (cnt_TimeDistribution == 1) // first time
            {
                t.CummProbability = t.Probability;
                t.MinRange = 1;
            }
            else
            {
                t.CummProbability = TimeDistribution.ElementAt(cnt_TimeDistribution - 2).CummProbability + t.Probability;               
                t.MinRange = TimeDistribution.ElementAt(cnt_TimeDistribution - 2).MaxRange + 1;
            }
            t.MaxRange = t.CummProbability * 100;

            TimeDistribution.Add(t);
            if (t.CummProbability == 1.0)
                this.Close();

            textBox1.Text = "";
            textBox2.Text = "";

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
