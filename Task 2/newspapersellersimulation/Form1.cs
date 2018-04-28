using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NewspaperSellerTesting;
using NewspaperSellerModels;

namespace NewspaperSellerSimulation
{
    public partial class Form1 : Form
    {
        PredefinedNewsDayDistributionForm f2=new PredefinedNewsDayDistributionForm();
        public Form1()
        {
            InitializeComponent();            
        }
        NewspaperSellerModels.System mySystem = new NewspaperSellerModels.System();
        private void ProbabilityOf_PredefinedNewsDay_Click(object sender, EventArgs e)
        {
            f2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mySystem.DayTypeDistributions = f2.DaysDistributions;
            mySystem.NumOfNewspapers = int.Parse(NumberOfNewsPaper.Text);
            mySystem.NumOfRecords = int.Parse(NumRecords.Text);
            mySystem.ScrapPrice = double.Parse(NewsPaperScrapValue.Text);
            mySystem.SellingPrice = double.Parse(NewsPaperSellingPrice.Text);
            mySystem.PurchasePrice = double.Parse(NewsPaperPrice.Text);
            mySystem.UnitProfit = double.Parse("100");
            dataGridView1.Columns.Add("Demand", "Demand");
            for (int i = 0; i < f2.DaysDistributions.Count();i++ )
            {
                dataGridView1.Columns.Add(f2.DaysDistributions[i].DayType.ToString(), f2.DaysDistributions[i].DayType.ToString());
            }

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DemandDistribution d=new DemandDistribution();
            DayTypeDistribution dd=new DayTypeDistribution();
            int cnt=0;
            for(int i=0;i<dataGridView1.RowCount-1;i++)
            {
                d = new DemandDistribution();
                mySystem.DemandDistributions.Add(d);
                mySystem.DemandDistributions[i].Demand=int.Parse(dataGridView1[0,i].Value.ToString());
                for (int j = 1; j < mySystem.DayTypeDistributions.Count + 1; j++)
                {
                    dd = new DayTypeDistribution();
                    dd.DayType = (Enums.DayType)(j - 1);
                    if (i == 0)
                    {
                        
                        dd.Probability = double.Parse(dataGridView1[j, i].Value.ToString());
                        dd.CummProbability = double.Parse(dataGridView1[j, i].Value.ToString());
                        dd.MinRange = 1;
                        dd.MaxRange = (int)(dd.CummProbability * 100);
                       
                    }
                    else
                    {
                       
                        dd.Probability = double.Parse(dataGridView1[j, i].Value.ToString());


                        dd.CummProbability =
                            dd.Probability + mySystem.DemandDistributions[i - 1].DayTypeDistributions[Math.Abs(j-1)].CummProbability;
                        dd.MinRange =
                           (mySystem.DemandDistributions[i-1].DayTypeDistributions[j-1].MaxRange) + 1;
                        dd.MaxRange = (int)(dd.CummProbability * 100);
                    }
                    mySystem.DemandDistributions[i].DayTypeDistributions.Add(dd);
                    
                    cnt++;
                }

                

            }

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();

            SimulationCase temp = new SimulationCase();
            Random r=new Random();
            dataGridView2.Columns.Add("Day", "Day");
            dataGridView2.Columns.Add("RandomTypeNewsDay", "RandomTypeNewsDay");
            dataGridView2.Columns.Add("TypeOfNewsDay", "TypeOfNewsDay");
            dataGridView2.Columns.Add("RandomDemand", "RandomDemand");
            dataGridView2.Columns.Add("Demand", "Demand");
            dataGridView2.Columns.Add("DailyCost", "DailyCost");
            dataGridView2.Columns.Add("RevenueFromSale", "RevenueFromSale");
            dataGridView2.Columns.Add("LostProfit", "LostProfit");
            dataGridView2.Columns.Add("SaleAsScrap", "SaleAsScrap");
            dataGridView2.Columns.Add("DailyProfit", "DailyProfit");
            for(int i=0;i<mySystem.NumOfRecords;i++)
            {
                temp =new SimulationCase();
                temp.DayNo = i + 1;
                int k=0;
                temp.RandomNewsDayType = r.Next(1, 100);
                for(int j=0;j<mySystem.DayTypeDistributions.Count;j++)
                {
                    if((temp.RandomNewsDayType<=mySystem.DayTypeDistributions[j].MaxRange||mySystem.DayTypeDistributions[j].MaxRange==0)&&
                        temp.RandomNewsDayType>=mySystem.DayTypeDistributions[j].MinRange)
                    {
                        temp.NewsDayType = mySystem.DayTypeDistributions[j].DayType;
                        k=j;
                        break;
                    }
                }
                temp.RandomDemand = r.Next(1, 100);
                for(int j=0;j<mySystem.DemandDistributions.Count;j++)
                {
                    //MessageBox.Show(mySystem.DemandDistributions[j].DayTypeDistributions[k].MaxRange.ToString());
                    if ((mySystem.DemandDistributions[j].DayTypeDistributions[k].MaxRange >= temp.RandomDemand || mySystem.DemandDistributions[j].DayTypeDistributions[k].MaxRange == 0) &&
                        mySystem.DemandDistributions[j].DayTypeDistributions[k].MinRange<=temp.RandomDemand)
                    {
                        temp.Demand = mySystem.DemandDistributions[j].Demand;
                        break;
                    }
                }
                temp.SalesProfit = temp.Demand * (mySystem.PurchasePrice);
                if(temp.Demand>mySystem.NumOfNewspapers)
                {
                    temp.SalesProfit = mySystem.NumOfNewspapers * (mySystem.PurchasePrice/mySystem.UnitProfit);
                    temp.LostProfit = ((temp.Demand - mySystem.NumOfNewspapers) * ((mySystem.PurchasePrice - mySystem.SellingPrice) / mySystem.UnitProfit));
                    temp.ScrapProfit = 0;
                }
                else
                {
                    temp.SalesProfit = temp.Demand * (mySystem.PurchasePrice / mySystem.UnitProfit);
                    temp.LostProfit = 0;
                    temp.ScrapProfit = (mySystem.ScrapPrice / mySystem.UnitProfit) * (mySystem.NumOfNewspapers - temp.Demand);

                }
                temp.DailyCost = ((double)(mySystem.NumOfNewspapers) * mySystem.SellingPrice) / mySystem.UnitProfit;
                temp.DailyNetProfit = temp.SalesProfit - temp.DailyCost - temp.LostProfit + temp.ScrapProfit;
                
                mySystem.SimulationCases.Add(temp);
                dataGridView2.Rows.Add(temp.DayNo, temp.RandomNewsDayType, temp.NewsDayType, temp.RandomDemand, temp.Demand, temp.DailyCost, temp.SalesProfit, temp.LostProfit, temp.ScrapProfit, temp.DailyNetProfit);
                mySystem.PerformanceMeasures.TotalCost += temp.DailyCost;
                mySystem.PerformanceMeasures.TotalLostProfit += temp.LostProfit;
                mySystem.PerformanceMeasures.TotalSalesProfit += temp.SalesProfit;
                mySystem.PerformanceMeasures.TotalScrapProfit += temp.ScrapProfit;
                mySystem.PerformanceMeasures.TotalNetProfit += Math.Round(temp.DailyNetProfit,1);
                if (temp.LostProfit!=0)
                    mySystem.PerformanceMeasures.DaysWithMoreDemand++;
                else if (temp.ScrapProfit!=0)
                    mySystem.PerformanceMeasures.DaysWithUnsoldPapers++;
            }
            textBox1.Text = mySystem.PerformanceMeasures.DaysWithUnsoldPapers.ToString();
            textBox2.Text = mySystem.PerformanceMeasures.TotalScrapProfit.ToString();
            textBox3.Text = mySystem.PerformanceMeasures.TotalLostProfit.ToString();
            textBox4.Text = mySystem.PerformanceMeasures.TotalNetProfit.ToString();
            textBox5.Text = mySystem.PerformanceMeasures.DaysWithMoreDemand.ToString();
            textBox7.Text = mySystem.PerformanceMeasures.TotalCost.ToString();
            textBox8.Text = mySystem.PerformanceMeasures.TotalSalesProfit.ToString();
            
            string s = TestingManager.Test(mySystem, Constants.FileNames.TestCase1);
            MessageBox.Show(s);
        }
    }
}
