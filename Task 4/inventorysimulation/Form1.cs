using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InventoryTesting;
using InventoryModels;

namespace InventorySimulation
{
    public partial class Form1 : Form
    {
        SimulationSystem mysys;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            mysys = new SimulationSystem();
            read_from_file();
        }

        private void Simulate_Click(object sender, EventArgs e)
        {
            if(mysys==null)
            {
                MessageBox.Show("Error No Input !!!");
            }
            else
            {
                Simulator Simulator_Case = new Simulator(mysys);
                Simulator_Case.Run();
                SimulationTableForm simulationTable = new SimulationTableForm(mysys);
                simulationTable.Show();
                string test_res = "";
                string s = comboBox1.Text;
                if (s== "TestCase1")
                {
                    test_res= TestingManager.Test(mysys, Constants.FileNames.TestCase1);
                }
                else if(s== "TestCase2")
                {
                    test_res = TestingManager.Test(mysys, Constants.FileNames.TestCase2);
                }
                else if(s== "TestCase3")
                {
                    test_res = TestingManager.Test(mysys, Constants.FileNames.TestCase3);
                }
                else if(s== "TestCase4")
                {
                    test_res = TestingManager.Test(mysys, Constants.FileNames.TestCase4);
                }
                MessageBox.Show(test_res);
                mysys = new SimulationSystem();
            }
        }
        private void read_from_file()
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            string s = comboBox1.Text;
            string[] lines = null;
            if (s == "TestCase1")
            {
                lines = System.IO.File.ReadAllLines(@"C:\Users\Zaza\Desktop\simulation\inventorysimulation\InventorySimulation\TestCases\TestCase1.txt");
            }
            else if (s == "TestCase2")
            {
                lines = System.IO.File.ReadAllLines(@"C:\Users\Zaza\Desktop\simulation\inventorysimulation\InventorySimulation\TestCases\TestCase2.txt");
            }
            else if (s == "TestCase3")
            {
                lines = System.IO.File.ReadAllLines(@"C:\Users\Zaza\Desktop\simulation\inventorysimulation\InventorySimulation\TestCases\TestCase3.txt");

            }
            else if (s == "TestCase4")
            {
                lines = System.IO.File.ReadAllLines(@"C:\Users\Zaza\Desktop\simulation\inventorysimulation\InventorySimulation\TestCases\TestCase4.txt");
            }
            else
            {
                MessageBox.Show("Error While Reading The Input File");
                return;
            }
            for (int i = 0; i < lines.Count(); i++)
            {
                if (lines[i] == "OrderUpTo")
                {
                    mysys.OrderUpTo = int.Parse(lines[i + 1]);
                    OrderUpTo.Text = lines[i + 1];
                    i++;
                }
                else if (lines[i] == "ReviewPeriod")
                {
                    mysys.ReviewPeriod = int.Parse(lines[i + 1]);
                    ReviewPeriod.Text = lines[i + 1];
                    i++;
                }
                else if (lines[i] == "StartInventoryQuantity")
                {
                    mysys.StartInventoryQuantity = int.Parse(lines[i + 1]);
                    StartInventoryQuantity.Text = lines[i + 1];
                    i++;
                }
                else if (lines[i] == "StartLeadDays")
                {
                    mysys.StartLeadDays = int.Parse(lines[i + 1]);
                    StartLeadDays.Text = lines[i + 1];
                    i++;
                }
                else if (lines[i] == "StartOrderQuantity")
                {
                    mysys.StartOrderQuantity = int.Parse(lines[i + 1]);
                    StartOrderQuantity.Text = lines[i + 1];
                    i++;
                }
                else if (lines[i] == "NumberOfDays")
                {
                    mysys.NumberOfDays = int.Parse(lines[i + 1]);
                    NumberOfDays.Text = lines[i + 1];
                    i++;
                }
                else if (lines[i] == "DemandDistribution")
                {
                    Distribution one = new Distribution();
                    bool first_time = true;
                    decimal pre = 0;
                    while (i + 1 < lines.Count() && lines[i + 1] != "")
                    {
                        one = new Distribution();
                        i++;
                        char[] d = { ',', ' ' };
                        string[] splitted = lines[i].Split(d);
                        one.Value = int.Parse(splitted[0]);
                        one.Probability = decimal.Parse(splitted[2]);
                        if (first_time)
                        {
                            one.CummProbability = one.Probability;
                            one.MinRange = 1;
                            one.MaxRange = Convert.ToInt32(one.CummProbability * 100);
                        }
                        else
                        {
                            one.CummProbability = one.Probability + pre;
                            one.MinRange = Convert.ToInt32(pre * 100) + 1;
                            one.MaxRange = Convert.ToInt32(one.CummProbability * 100);
                        }
                        pre = one.CummProbability;
                        first_time = false;
                        mysys.DemandDistribution.Add(one);
                        dataGridView1.Rows.Add(one.Value, one.Probability, one.CummProbability, one.MinRange, one.MaxRange);
                    }
                }
                else if (lines[i] == "LeadDaysDistribution")
                {
                    Distribution one = new Distribution();
                    bool first_time = true;
                    decimal pre = 0;
                    while (i + 1 < lines.Count() && lines[i + 1] != "")
                    {
                        one = new Distribution();
                        i++;
                        char[] d = { ',', ' ' };
                        string[] splitted = lines[i].Split(d);
                        one.Value = int.Parse(splitted[0]);
                        one.Probability = decimal.Parse(splitted[2]);
                        if (first_time)
                        {
                            one.CummProbability = one.Probability;
                            one.MinRange = 1;
                            one.MaxRange = Convert.ToInt32(one.CummProbability * 100);
                        }
                        else
                        {
                            one.CummProbability = one.Probability + pre;
                            one.MinRange = Convert.ToInt32(pre * 100) + 1;
                            one.MaxRange = Convert.ToInt32(one.CummProbability * 100);
                        }
                        pre = one.CummProbability;
                        first_time = false;
                        mysys.LeadDaysDistribution.Add(one);
                        dataGridView2.Rows.Add(one.Value, one.Probability, one.CummProbability, one.MinRange, one.MaxRange);
                    }
                }
            }
        }
    }
}
