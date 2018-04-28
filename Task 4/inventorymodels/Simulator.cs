using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InventoryModels;
namespace InventoryModels
{
    public class Simulator
    {
        SimulationSystem mysys;
        public Simulator(SimulationSystem sys)
        {
            mysys = sys;
        }
        public void Run()
        {
            Random DemandRandom = new Random();
            Random LeadDaysRandom = new Random();
            int cycle = 1;
            int day_in_cycle = 1;
            int total_shortage = 0;
            int pre_end = mysys.StartInventoryQuantity;
            int[] orders = new int[mysys.NumberOfDays + 100];
            decimal total_ending = 0;
            decimal final_total_shortage = 0;
            orders[mysys.StartLeadDays + 1] = mysys.StartOrderQuantity;
            for(int day=1;day<=mysys.NumberOfDays;day++)
            {
                SimulationCase one = new SimulationCase();
                one.Day = day;
                one.Cycle = cycle;
                one.DayWithinCycle = day_in_cycle;
                one.BeginningInventory = pre_end + orders[day];
                one.RandomDemand = DemandRandom.Next(1, 100);
                one.Demand=get_val(one.RandomDemand,mysys.DemandDistribution);
                if(one.Demand > one.BeginningInventory)
                {
                    one.EndingInventory = 0;
                    one.ShortageQuantity = one.Demand - one.BeginningInventory +total_shortage;
                    total_shortage = one.ShortageQuantity;
                }
                else
                {
                    one.EndingInventory = one.BeginningInventory - one.Demand;
                    one.ShortageQuantity = total_shortage;
                }
               if(day % mysys.ReviewPeriod ==0)
                {
                    if(one.EndingInventory < mysys.OrderUpTo)
                    {
                        one.RandomLeadDays = LeadDaysRandom.Next(1, 100);
                        one.LeadDays = get_val(one.RandomLeadDays, mysys.LeadDaysDistribution);
                        one.OrderQuantity = mysys.OrderUpTo - one.EndingInventory + total_shortage;
                        orders[day + one.LeadDays + 1] = one.OrderQuantity;
                    }
                    else
                    {
                        one.RandomLeadDays = 0;
                        one.LeadDays = 0;
                        one.OrderQuantity = 0;
                    }
                    cycle++;
                    day_in_cycle = 1;
                }
               else
                {
                    one.RandomLeadDays = 0;
                    one.LeadDays = 0;
                    one.OrderQuantity = 0;
                    day_in_cycle++;
                }
               if(orders[day]!=0)
                {
                    if(one.EndingInventory >=total_shortage)
                    {
                        one.EndingInventory -= total_shortage;
                        total_shortage = 0;
                        one.ShortageQuantity = 0;
                    }
                    else
                    {
                        total_shortage -= one.EndingInventory;
                        one.ShortageQuantity = total_shortage;
                        one.EndingInventory = 0;
                    }                    
                }
                mysys.SimulationCases.Add(one);
                total_ending += one.EndingInventory;
                final_total_shortage += one.ShortageQuantity;
                pre_end = one.EndingInventory;
            }
            decimal n = mysys.SimulationCases.Count();
            mysys.PerformanceMeasures.EndingInventoryAverage = total_ending / n;
            mysys.PerformanceMeasures.ShortageQuantityAverage = final_total_shortage / n;
        }
        int get_val(int index,List<Distribution> table)
        {
            foreach(var item in table)
            {
                if(item.MinRange<=index && index<=item.MaxRange)
                {
                    return item.Value;
                }
            }
            return 0;
        }
    }
}
