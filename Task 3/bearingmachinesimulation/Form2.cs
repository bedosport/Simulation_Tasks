using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BearingMachineModels;
namespace BearingMachineSimulation
{
    public partial class Form2 : Form
    {
        
        BearingMachineModels.SimulationSystem mysystem = new BearingMachineModels.SimulationSystem();
        public Form2(BearingMachineModels.SimulationSystem mysys)
        {
            
            mysystem = mysys;
            InitializeComponent();
        }
         
            private void Form2_Load(object sender, EventArgs e)
            {
                simulator.calculate_current_solution(dataGridView3);
                textBox5.Text = mysystem.CurrentPerformanceMeasures.BearingCost.ToString();
                textBox3.Text = mysystem.CurrentPerformanceMeasures.DelayCost.ToString();
                textBox6.Text = mysystem.CurrentPerformanceMeasures.DowntimeCost.ToString();
                textBox4.Text =  mysystem.CurrentPerformanceMeasures.RepairPersonCost.ToString();
                textBox2.Text = mysystem.CurrentPerformanceMeasures.TotalCost.ToString();
            }
         
            private void button1_Click(object sender, EventArgs e)
            {
                
            }
    }
}
