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
    public partial class Form3 : Form
    {
        BearingMachineModels.SimulationSystem mysystem = new BearingMachineModels.SimulationSystem();
        public Form3(BearingMachineModels.SimulationSystem mysys)
        {
            
            mysystem = mysys;
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            simulator.calculate_proposed_solution(dataGridView4);
          textBox5.Text = mysystem.ProposedPerformanceMeasures.BearingCost.ToString();
          textBox3.Text = mysystem.ProposedPerformanceMeasures.DelayCost.ToString();
          textBox6.Text = mysystem.ProposedPerformanceMeasures.DowntimeCost.ToString();
          textBox4.Text = mysystem.ProposedPerformanceMeasures.RepairPersonCost.ToString();
          textBox2.Text = mysystem.ProposedPerformanceMeasures.TotalCost.ToString();
        }
    }
}
