using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BearingMachineTesting;
using BearingMachineModels;
using System.Windows.Forms;
namespace BearingMachineSimulation
{
    public static class simulator
    {
        static BearingMachineModels.SimulationSystem mysystem;
        public static void load(BearingMachineModels.SimulationSystem mysy)
        {
            mysystem = mysy;
        }
        public static void calculate_life_time(DataGridView dataGridView1)
        {

            decimal cum_temp = 0;
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {

                TimeDistribution temp = new TimeDistribution();
                int j = 0;


                temp.Time = Convert.ToInt32(dataGridView1[j, i].Value);
                temp.Probability = Convert.ToDecimal(dataGridView1[j + 1, i].Value);
                cum_temp += temp.Probability;
                if (i == 0)
                {
                    temp.CummProbability = temp.Probability;
                    temp.MinRange = 1;
                }
                else
                {
                    temp.CummProbability = cum_temp;
                    temp.MinRange = mysystem.BearingLifeDistribution[i - 1].MaxRange + 1;
                }
                temp.MaxRange = (int)(temp.CummProbability * 100);
                dataGridView1.Rows[i].Cells[2].Value = cum_temp;
                dataGridView1.Rows[i].Cells[3].Value = temp.MinRange;
                dataGridView1.Rows[i].Cells[4].Value = temp.MaxRange;
                mysystem.BearingLifeDistribution.Add(temp);


            }
        }
        public static void calculate_delay_time(DataGridView dataGridView2)
        {
            decimal cum2_temp = 0;
            for (int i = 0; i < dataGridView2.RowCount - 1; i++)
            {

                TimeDistribution temp = new TimeDistribution();
                int j = 0;


                temp.Time = Convert.ToInt32(dataGridView2[j, i].Value);
                temp.Probability = Convert.ToDecimal(dataGridView2[j + 1, i].Value);
                cum2_temp += temp.Probability;
                if (i == 0)
                {
                    temp.CummProbability = temp.Probability;
                    temp.MinRange = 1;
                }
                else
                {
                    temp.CummProbability = cum2_temp;
                    temp.MinRange = mysystem.DelayTimeDistribution[i - 1].MaxRange + 1;
                }
                temp.MaxRange = (int)(temp.CummProbability * 100);
                dataGridView2.Rows[i].Cells[2].Value = cum2_temp;
                dataGridView2.Rows[i].Cells[3].Value = temp.MinRange;
                dataGridView2.Rows[i].Cells[4].Value = temp.MaxRange;
                mysystem.DelayTimeDistribution.Add(temp);
            }
        }
        public static void read_from_file(TextBox down_time_cost, TextBox Repair_person_cost, TextBox Bearing_cost, TextBox Num_of_hours, TextBox Num_of_bearings, TextBox Repair_Time_for_one_Bearing, TextBox Repair_Time_for_all_bearings, DataGridView dataGridView2, DataGridView dataGridView1,string test_case_number)
        {
            string[] lines;
            if (test_case_number == "TestCase1")
                lines = System.IO.File.ReadAllLines(@"C:\Users\Zaza\Desktop\simulation\SimulationTasks-master\Task 3\bearingmachinesimulation\TestCases\TestCase1.txt");
            else if (test_case_number == "TestCase2")
                lines = System.IO.File.ReadAllLines(@"C:\Users\Zaza\Desktop\simulation\SimulationTasks-master\Task 3\bearingmachinesimulation\TestCases\TestCase2.txt");
            else
                lines = System.IO.File.ReadAllLines(@"C:\Users\Zaza\Desktop\simulation\SimulationTasks-master\Task 3\bearingmachinesimulation\TestCases\TestCase3.txt");

            for (int i = 0; i < lines.Count(); i++)
            {
                if (lines[i] == "DowntimeCost")
                {
                    mysystem.DowntimeCost = int.Parse(lines[i + 1]);
                    down_time_cost.Text = lines[i + 1];
                    i++;
                }
                else if (lines[i] == "RepairPersonCost")
                {
                    mysystem.RepairPersonCost = int.Parse(lines[i + 1]);
                    Repair_person_cost.Text = lines[i + 1];
                    i++;
                }
                else if (lines[i] == "BearingCost")
                {
                    mysystem.BearingCost = int.Parse(lines[i + 1]);
                    Bearing_cost.Text = lines[i + 1];
                    i++;
                }
                else if (lines[i] == "NumberOfHours")
                {
                    mysystem.NumberOfHours = int.Parse(lines[i + 1]);
                    Num_of_hours.Text = lines[i + 1];
                    i++;
                }
                else if (lines[i] == "NumberOfBearings")
                {
                    mysystem.NumberOfBearings = int.Parse(lines[i + 1]);
                    Num_of_bearings.Text = lines[i + 1];
                    i++;
                }
                else if (lines[i] == "RepairTimeForOneBearing")
                {
                    mysystem.RepairTimeForOneBearing = int.Parse(lines[i + 1]);
                    Repair_Time_for_one_Bearing.Text = lines[i + 1];
                    i++;
                }
                else if (lines[i] == "RepairTimeForAllBearings")
                {
                    mysystem.RepairTimeForAllBearings = int.Parse(lines[i + 1]);
                    Repair_Time_for_all_bearings.Text = lines[i + 1];
                    i++;
                }
                else if (lines[i] == "DelayTimeDistribution")
                {
                    while (lines[i + 1] != "")
                    {
                        char[] del = { ',', ' ' };
                        string[] all = lines[i + 1].Split(del);
                        dataGridView2.Rows.Add(all[0], all[2]);
                        i++;
                    }
                }
                else if (lines[i] == "BearingLifeDistribution")
                {
                    while (i + 1 < lines.Count())
                    {
                        char[] del = { ',', ' ' };
                        string[] all = lines[i + 1].Split(del);
                        dataGridView1.Rows.Add(all[0], all[2]);
                        i++;
                    }
                }
            }
        }
        public static void calculate_current_solution(DataGridView dataGridView3)
        {
            dataGridView3.Columns.Add("Count", "Count");
            dataGridView3.Columns.Add("Index", "Index");
            dataGridView3.Columns.Add("Random Life", "Random Life");
            dataGridView3.Columns.Add("Life", "Life");
            dataGridView3.Columns.Add("Accumelated Life", "Accumelated Life");
            dataGridView3.Columns.Add("Random Delay", "Random Delay");
            dataGridView3.Columns.Add("Delay", "Delay");

            int Bearings_number = mysystem.NumberOfBearings;
            int index_number = 1;
            Random rand = new Random();
            Random rand2 = new Random();
            int counter = 0;
            while (Bearings_number > 0)
            {

                bool bearing_start = true;
                int round_cond = 0;

                while (round_cond < mysystem.NumberOfHours)
                {
                    CurrentSimulationCase temp = new CurrentSimulationCase();
                    temp.Bearing = new Bearing();
                    temp.Bearing.Index = index_number;
                    temp.Bearing.RandomHours = rand.Next(1, 100);
                    for (int i = 0; i < mysystem.BearingLifeDistribution.Count; i++)
                    {
                        if (temp.Bearing.RandomHours >= mysystem.BearingLifeDistribution[i].MinRange && temp.Bearing.RandomHours <= mysystem.BearingLifeDistribution[i].MaxRange)
                            temp.Bearing.Hours = mysystem.BearingLifeDistribution[i].Time;
                    }

                    if (bearing_start)
                    {
                        temp.AccumulatedHours = temp.Bearing.Hours;
                        bearing_start = false;
                    }
                    else
                        temp.AccumulatedHours = temp.Bearing.Hours + mysystem.CurrentSimulationCases[counter - 1].AccumulatedHours;

                    temp.RandomDelay = rand2.Next(1, 100);

                    for (int i = 0; i < mysystem.DelayTimeDistribution.Count; i++)
                    {
                        if (temp.RandomDelay >= mysystem.DelayTimeDistribution[i].MinRange && temp.RandomDelay <= mysystem.DelayTimeDistribution[i].MaxRange)
                            temp.Delay = mysystem.DelayTimeDistribution[i].Time;

                    }

                    round_cond = temp.AccumulatedHours;
                    mysystem.CurrentSimulationCases.Add(temp);
                    counter++;
                }

                index_number++;
                bearing_start = true;
                Bearings_number--;
            }


            int z, total_delay = 0;
            for (z = 0; z < mysystem.CurrentSimulationCases.Count; z++)
            {
                dataGridView3.Rows.Add(z + 1, mysystem.CurrentSimulationCases[z].Bearing.Index, mysystem.CurrentSimulationCases[z].Bearing.RandomHours, mysystem.CurrentSimulationCases[z].Bearing.Hours, mysystem.CurrentSimulationCases[z].AccumulatedHours, mysystem.CurrentSimulationCases[z].RandomDelay, mysystem.CurrentSimulationCases[z].Delay);
                total_delay += mysystem.CurrentSimulationCases[z].Delay;

            }
            decimal total = decimal.Parse(z.ToString());
            mysystem.CurrentPerformanceMeasures.BearingCost = total * mysystem.BearingCost;
            mysystem.CurrentPerformanceMeasures.DelayCost = total_delay * mysystem.DowntimeCost;
            mysystem.CurrentPerformanceMeasures.DowntimeCost = total * mysystem.RepairTimeForOneBearing * mysystem.DowntimeCost;
            mysystem.CurrentPerformanceMeasures.RepairPersonCost = total * mysystem.RepairTimeForOneBearing * mysystem.RepairPersonCost / 60;
            mysystem.CurrentPerformanceMeasures.TotalCost = mysystem.CurrentPerformanceMeasures.BearingCost + mysystem.CurrentPerformanceMeasures.DelayCost + mysystem.CurrentPerformanceMeasures.DowntimeCost + mysystem.CurrentPerformanceMeasures.RepairPersonCost;


        }
        public static void calculate_proposed_solution(DataGridView dataGridView4)
        {
            dataGridView4.Columns.Add("Count", "Count");
            for (int i = 0; i < mysystem.NumberOfBearings; i++)
            {
                dataGridView4.Columns.Add("Bearing"+(i+1).ToString(), "Bearing"+(i+1).ToString());
            }
            dataGridView4.Columns.Add("First Failure", "First Failure");
            dataGridView4.Columns.Add("Accumelated Life", "Accumelated Life");
            dataGridView4.Columns.Add("Random Delay", "Random Delay");
            dataGridView4.Columns.Add("Delay", "Delay");
            List<List<Bearing>> total_bears=new List<List<Bearing>>();
            List<Bearing> tmp=new List<Bearing>();
            int pre=1;
            int max_len = 0;
            for(int i=0;i<mysystem.CurrentSimulationCases.Count;i++)
            {
                if(mysystem.CurrentSimulationCases[i].Bearing.Index!=pre)
                {
                    total_bears.Add(tmp);
                    max_len = Math.Max(max_len, tmp.Count());
                    pre = mysystem.CurrentSimulationCases[i].Bearing.Index;
                    tmp = new List<Bearing>();
                }
                tmp.Add(mysystem.CurrentSimulationCases[i].Bearing);
            }
            total_bears.Add(tmp);
            max_len = Math.Max(max_len, tmp.Count());
            int total_time = 0;
            Random r = new Random();
            mysystem.ProposedSimulationCases = new List<ProposedSimulationCase>();
            for (int j = 0; total_time<mysystem.NumberOfHours; j++)
            {
                ProposedSimulationCase psc=new ProposedSimulationCase();
                List<string> s = new List<string>();
                s.Add(j.ToString());
                int minn = int.MaxValue;
                for (int i = 0; i < mysystem.NumberOfBearings; i++)
                {
                    if (j < total_bears[i].Count())
                    {
                        psc.Bearings.Add(total_bears[i][j]);
                        if (total_bears[i][j].Hours < minn)
                            minn = total_bears[i][j].Hours;
                    }
                    else
                    {
                        Bearing Bearing_tmp = new Bearing();
                        Bearing_tmp.Index = i+1;
                        Bearing_tmp.RandomHours = r.Next(1, 100);
                        for (int k= 0; k < mysystem.BearingLifeDistribution.Count; k++)
                        {
                            if (Bearing_tmp.RandomHours >= mysystem.BearingLifeDistribution[k].MinRange && Bearing_tmp.RandomHours <= mysystem.BearingLifeDistribution[k].MaxRange)
                                Bearing_tmp.Hours = mysystem.BearingLifeDistribution[k].Time;
                        }
                        if (Bearing_tmp.Hours < minn)
                            minn = Bearing_tmp.Hours;
                        psc.Bearings.Add(Bearing_tmp);
                    }
                     
                }
                psc.FirstFailure = minn;
                total_time += psc.FirstFailure;
                if (mysystem.ProposedSimulationCases.Count() == 0)
                {
                    psc.AccumulatedHours = psc.FirstFailure;
                }
                else
                {
                    psc.AccumulatedHours = psc.FirstFailure + mysystem.ProposedSimulationCases[mysystem.ProposedSimulationCases.Count() - 1].AccumulatedHours;
                }
                int random_tmp  = r.Next(1, 100);
                int delay_tmp = 0;
                for (int l = 0; l < mysystem.DelayTimeDistribution.Count; l++)
                {
                    if (random_tmp >= mysystem.DelayTimeDistribution[l].MinRange && random_tmp <= mysystem.DelayTimeDistribution[l].MaxRange)
                        delay_tmp = mysystem.DelayTimeDistribution[l].Time;

                }
                psc.RandomDelay = random_tmp;
                psc.Delay = delay_tmp;
                mysystem.ProposedSimulationCases.Add(psc);
            }

            int total_delay=0; 
            for(int i=0;i<mysystem.ProposedSimulationCases.Count();i++)
            { 
                List<string> s = new List<string>();
                s.Add((i+1).ToString());
                for(int j=0;j<mysystem.ProposedSimulationCases[i].Bearings.Count();j++)
                {
                    s.Add(mysystem.ProposedSimulationCases[i].Bearings[j].Hours.ToString());
                }
                s.Add(mysystem.ProposedSimulationCases[i].FirstFailure.ToString());
                s.Add(mysystem.ProposedSimulationCases[i].AccumulatedHours.ToString());
                s.Add(mysystem.ProposedSimulationCases[i].RandomDelay.ToString());
                s.Add(mysystem.ProposedSimulationCases[i].Delay.ToString());
                dataGridView4.Rows.Add(s.ToArray());
                total_delay+=mysystem.ProposedSimulationCases[i].Delay;
            }

          mysystem.ProposedPerformanceMeasures.BearingCost = mysystem.ProposedSimulationCases.Count() * mysystem.NumberOfBearings*mysystem.BearingCost;
          mysystem.ProposedPerformanceMeasures.DelayCost = total_delay * mysystem.DowntimeCost;
          mysystem.ProposedPerformanceMeasures.DowntimeCost = mysystem.ProposedSimulationCases.Count() * mysystem.RepairTimeForAllBearings * mysystem.DowntimeCost;
          mysystem.ProposedPerformanceMeasures.RepairPersonCost = mysystem.ProposedSimulationCases.Count() * mysystem.RepairTimeForAllBearings * mysystem.RepairPersonCost / 60;
          mysystem.ProposedPerformanceMeasures.TotalCost = mysystem.ProposedPerformanceMeasures.BearingCost + mysystem.ProposedPerformanceMeasures.DelayCost + mysystem.ProposedPerformanceMeasures.DowntimeCost + mysystem.ProposedPerformanceMeasures.RepairPersonCost;

        }
    }
}
