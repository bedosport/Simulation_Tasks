using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using InventoryModels;
namespace InventorySimulation
{
    public partial class SimulationTableForm : Form
    {
        SimulationSystem mysys;
        public SimulationTableForm(SimulationSystem sys)
        {
            mysys = sys;
            InitializeComponent();
        }
        private void SimulationTableForm_Load(object sender, EventArgs e)
        {
            foreach(var item in mysys.SimulationCases)
            {
                dataGridView1.Rows.Add(item.Day, item.Cycle, item.DayWithinCycle, item.BeginningInventory, item.RandomDemand, item.Demand, item.EndingInventory, item.ShortageQuantity, item.OrderQuantity, item.RandomLeadDays, item.LeadDays);
            }
            AverageEnding.Text = mysys.PerformanceMeasures.EndingInventoryAverage.ToString();
            AverageShortage.Text = mysys.PerformanceMeasures.ShortageQuantityAverage.ToString();
        }
    }
}
