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
   
    public partial class Form2 : Form
    {
        
        public int number_of_servers{ get; set; }
        public int cnt_ServiceTimeDistribution{ get; set; }

        public List<TimeDistribution> ServiceTimeDistribution_{ get; set; }
        public int cnt_server{ get; set; }
        public List<Server> server_list { get; set; }
        
        public Form2()
        {
            ServiceTimeDistribution_ = new List<TimeDistribution>();
            cnt_ServiceTimeDistribution = 0;
            InitializeComponent();
            cnt_server=1;
            server_list = new List<Server>();
        }
     
        private void button1_Click(object sender, EventArgs e)
        {
            if(double.Parse(textBox2.Text) >1.0)
            {
                MessageBox.Show("Enter A Valid Probability <= 1.0");
                return;
            }
            cnt_ServiceTimeDistribution++;
            TimeDistribution t = new TimeDistribution();
            t.Time = int.Parse(textBox1.Text.ToString());
            t.Probability = double.Parse(textBox2.Text.ToString());
            if (cnt_ServiceTimeDistribution == 1) // first time
            {
                t.CummProbability = t.Probability;
                t.MinRange = 1;
               // t.MaxRange = 1;
            }
            else
            {
                t.CummProbability = ServiceTimeDistribution_.ElementAt(cnt_ServiceTimeDistribution - 2).CummProbability + t.Probability;
                t.MinRange = ServiceTimeDistribution_.ElementAt(cnt_ServiceTimeDistribution-2).MaxRange+1;
            }

            t.MaxRange = t.CummProbability * 100;

             ServiceTimeDistribution_.Add(t);
            if(t.CummProbability>=1.0)
            {
                ///
                Server tmp = new Server();
                tmp.Name = textBox3.Text;
                tmp.ServiceEfficiency = double.Parse(textBox4.Text);
                tmp.ServerId = cnt_server;
                tmp.ServiceTimeDistribution = new List<TimeDistribution>(ServiceTimeDistribution_);

                server_list.Add(tmp);
                if (cnt_server == number_of_servers)
                    this.Close();
                cnt_server++;
                label6.Text = "Server " + cnt_server.ToString();
                
                ServiceTimeDistribution_.Clear();  // new server 
                cnt_ServiceTimeDistribution = 0;
                
                textBox3.Text = "";
                textBox4.Text = "";
            }

            textBox1.Text = "";
            textBox2.Text = "";

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }
    }
}
