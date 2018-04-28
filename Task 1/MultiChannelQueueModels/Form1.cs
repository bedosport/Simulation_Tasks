using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;

namespace MultiChannelQueueModels
{

    public partial class Form1 : Form
    {
        Form2 Server_Distribution_form = new Form2();
        Form3 Customer_Distribution_form = new Form3();
        Form4 Random_service_form = new Form4();
        Form5 Random_Customer_form = new Form5();
        Chartscs chart = new Chartscs();
        Simulator Run;
        List<SimualtionCase> Cases;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Random");
            comboBox1.Items.Add("Highest Priority");
            comboBox1.Items.Add("Least Utilization");

            comboBox1.SelectedItem = "Highest Priority";
            comboBox1.Text = "Highest Priority";
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private bool Check_if_ok()
        {
            if (Server_Distribution_form.server_list == null || Customer_Distribution_form.TimeDistribution == null 
                || Server_Distribution_form.server_list.Count == 0 || Customer_Distribution_form.TimeDistribution.Count == 0 
                || textBox2.Text=="" || textBox1.Text==""
                )
            {
                MessageBox.Show("Please Enter Complete Data!!!!");
                return false;
            }
            if( Random_Customer_form.random_list == null || Random_service_form.random_list == null || Random_Customer_form.random_list.Count == 0 || Random_service_form.random_list.Count == 0)
            {
                if (Random_Customer_form.random_list == null)
                    Random_Customer_form.random_list = new List<int>();
                if (Random_service_form.random_list == null)
                    Random_service_form.random_list = new List<int>();
                Random r = new Random();
                if (Random_Customer_form.random_list.Count==0)
                {
                    for (int i=0;i<int.Parse(textBox1.Text) -1;i++)
                    {
                        int rInt = r.Next(0, 100);
                        Random_Customer_form.random_list.Add(rInt);
                    }
                }
                if(Random_service_form.random_list.Count==0)
                {
                    for (int i = 0; i < int.Parse(textBox1.Text); i++)
                    {
                        int rInt = r.Next(1, 100);
                        Random_service_form.random_list.Add(rInt);
                    }
                }

            }
            return true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("Enter A Positive Number For Servers");
                return;
            }
            Server_Distribution_form.number_of_servers = int.Parse(textBox2.Text);
            Server_Distribution_form.Show();
        }
        private string calculate_max_len()
        {
            int max_len = 0;
            int max_so_far = 0;
            for(int i=0;i<Cases.Count;i++)
            {
                if(Cases[i].WaitingTime!=0)
                {
                    int start = Cases[i].ArrivalTime;
                    int endd = Cases[i].ArrivalTime + Cases[i].WaitingTime;
                    max_len = 1;
                    for(int j=i+1;j<Cases.Count;j++)
                    {
                        if(Cases[j].ArrivalTime >=start && Cases[j].ArrivalTime+Cases[j].WaitingTime <endd)
                        {
                            max_len++;
                        }
                    }
                    max_so_far = Math.Max(max_so_far, max_len);
                }
            }
            return max_so_far.ToString();
        }
        private void Display(List<string> prob,List<Server> server_list)
        {
            dataGridView2.Columns.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("Customer ID", "Customer ID");
            dataGridView1.Columns.Add("Random Digits for arrivals", "Random Digits for arrivals");
            dataGridView1.Columns.Add("Time Between Arrivals", "Time Between Arrivals");
            dataGridView1.Columns.Add("Clock Time Of Arrivals", "Clock Time Of Arrivals");
            dataGridView1.Columns.Add("Random Digits for Service", "Random Digits for Service");
            dataGridView1.Columns.Add("Service Duration", "Service Duration");
            dataGridView1.Columns.Add("Server Index", "Server Index");
            dataGridView1.Columns.Add("Time Service Begins", "Time Service Begins");
            dataGridView1.Columns.Add("Time Service Ends", "Time Service Ends");
            dataGridView1.Columns.Add("Time In Queue", "Time In Queue");
            for (int i = 0; i < Cases.Count; i++)
            {
                dataGridView1.Rows.Add(
                 Cases[i].CustomerNumber,
                 Cases[i].RandomInterarrivalTime,
                 Cases[i].InterarrivalTime,
                 Cases[i].ArrivalTime,
                 Cases[i].RandomServiceTime,
                 Cases[i].ServiceTime,
                 Cases[i].AssignedServer.ServerId,
                 Cases[i].TimeServiceBegins,
                 Cases[i].TimeServiceEnds,
                 Cases[i].WaitingTime
                    );
            }

            textBox3.Text = prob[0];
            textBox4.Text = prob[1];
            dataGridView2.Columns.Add("Name", "Name");
            dataGridView2.Columns.Add("Prob.Idle", "Prob.Idle");
            dataGridView2.Columns.Add("Average Serv.T", "Average Serv.T");
            dataGridView2.Columns.Add("Utili.", "Utili.");
            List<string> Data;
            for(int i=0;i<server_list.Count;i++)
            {
                Data=Run.calculate_server_data(Cases, i + 1, server_list);
                dataGridView2.Rows.Add(server_list[i].Name, Data[0],Data[1],Data[2]);
            }
            textBox5.Text = calculate_max_len();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            Cases= new List<SimualtionCase>();
            if (!Check_if_ok()) return;
            Run = new Simulator(Server_Distribution_form, Customer_Distribution_form,Random_service_form,Random_Customer_form);
            // generate calls attributes
            int number_of_customers = int.Parse(textBox1.Text);
            Run.generate_calls(Cases, number_of_customers);
            // assign a server for each call
            Run.assign_server(Cases, Server_Distribution_form.server_list,comboBox1.SelectedItem.ToString());
            List<string> prob = Run.calculate_customer_data(Cases);
            Display(prob, Server_Distribution_form.server_list);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Customer_Distribution_form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                MessageBox.Show("Enter A Positive Number For Customers");
                return;
            }
            Random_service_form.numberOfCustomers = int.Parse(textBox1.Text);
            Random_service_form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter A Positive Number For Customers");
                return;
            }
            Random_Customer_form.numberOfCustomers = int.Parse(textBox1.Text);
            Random_Customer_form.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            List<Server> servers = Server_Distribution_form.server_list;
            List<bool> ls = new List<bool>();
            chart.Yaxis = new List<List<bool>>();
            chart.max_time = new List<int>();
            for (int i=0;i<servers.Count;i++)
            {
                ls = new List<bool>();
               for(int j=1;j<=servers[i].ending_time;j++)
                {
                    bool ok = false;
                   for(int k=0;k<Cases.Count;k++)
                    {
                        if(Cases[k].AssignedServer.ServerId==servers[i].ServerId && Cases[k].TimeServiceBegins <= j && Cases[k].TimeServiceEnds >= j)
                        {
                            ok = true;
                            break;
                        }
                    }
                    ls.Add(ok);
                }
                chart.Yaxis.Add(ls);
                chart.max_time.Add(servers[i].ending_time);
            }
            chart.total = servers.Count;
            chart.Show();
        }
    }
}
  