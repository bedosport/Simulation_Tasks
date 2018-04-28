using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NewspaperSellerModels;
namespace NewspaperSellerSimulation
{
    public partial class PredefinedNewsDayDistributionForm : Form
    {
        DayTypeDistribution d;
        int cnt = 0;
        double cumPro = 0;
        public List<DayTypeDistribution> DaysDistributions {get;set;}
        public PredefinedNewsDayDistributionForm()
        {
            InitializeComponent();
            d = new DayTypeDistribution();
            DaysDistributions = new List<DayTypeDistribution>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            d = new DayTypeDistribution();
            for (int i = 0; i < Enum.GetNames(typeof(Enums.DayType)).Length; i++)
                if (comboBox1.SelectedItem.ToString() == ((Enums.DayType)i).ToString())
                    d.DayType = (Enums.DayType)i;

                d.Probability = double.Parse(Probability.Text.ToString());
            if (cnt == 0)
            {
                d.MinRange = 1;
                d.CummProbability = d.Probability;
            }
            else
            {
                d.CummProbability = DaysDistributions[cnt - 1].CummProbability + d.Probability;
                d.MinRange = DaysDistributions[cnt - 1].MaxRange + 1;
            }
            d.MaxRange = (int)(d.CummProbability * 100);
            cnt++;

            comboBox1.Text = "";
            comboBox1.Items.Remove(comboBox1.SelectedItem);
            Probability.Text = "";
            DaysDistributions.Add(d);
            cumPro += d.Probability;
            if (cumPro >= 1)
                this.Close();
        }

        private void PredefinedNewsDayDistributionForm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < Enum.GetNames(typeof(Enums.DayType)).Length; i++)
                comboBox1.Items.Add(((Enums.DayType)i).ToString());
        }
    }
}
