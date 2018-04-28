using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BearingMachineTesting;
using BearingMachineModels;

namespace BearingMachineSimulation
{
    public partial class Form1 : Form
    {
       public static BearingMachineModels.SimulationSystem mysystem = new BearingMachineModels.SimulationSystem(); 
         
        public Form1()
        {
            InitializeComponent();
        }
       
        private void Simulate_Click(object sender, EventArgs e)
        {
            simulator.calculate_life_time(dataGridView1);
            simulator.calculate_delay_time(dataGridView2);
            Form2 f2 = new Form2(mysystem);
            f2.Show();
            Form3 f3 = new Form3(mysystem);
            f3.Show();
            string s = "";
            if (comboBox1.Text=="TestCase1")
            s=TestingManager.Test(mysystem, Constants.FileNames.TestCase1);
           else if (comboBox1.Text == "TestCase2")
              s=  TestingManager.Test(mysystem, Constants.FileNames.TestCase2);
           else
                s=TestingManager.Test(mysystem, Constants.FileNames.TestCase3);

            MessageBox.Show(s);
            mysystem=new BearingMachineModels.SimulationSystem(); 
        }

        private void Load_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            simulator.load(mysystem);
            simulator.read_from_file(down_time_cost, Repair_person_cost, Bearing_cost, Num_of_hours, Num_of_bearings, Repair_Time_for_one_Bearing, Repair_Time_for_all_bearings, dataGridView2, dataGridView1,comboBox1.Text);
        }

     }
}
