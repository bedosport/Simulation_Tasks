using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiChannelQueueModels
{
    public class Simulator 
    {
        public Form2 Server_Distribution_form ;
        public Form3 Customer_Distribution_form ;
        public Form4 Random_server_form ;
        public Form5 Random_Customer_form ;
        public Random r ;
        public Simulator(Form2 Server_Distribution_form,
        Form3 Customer_Distribution_form,
        Form4 Random_server_form,
        Form5 Random_Customer_form)
        {
            this.Server_Distribution_form = Server_Distribution_form;
            this.Customer_Distribution_form = Customer_Distribution_form;
            this.Random_server_form = Random_server_form;
            this.Random_Customer_form = Random_Customer_form;
            r = new Random();
            // initialize the server data

            for(int i=0;i< this.Server_Distribution_form.server_list.Count;i++)
            {
                this.Server_Distribution_form.server_list[i].ending_time = 0;
            }
        }
        public void generate_calls(List<SimualtionCase> List_of_cases, int Customers )
        {
            SimualtionCase one_case = new SimualtionCase();
            List<int> Random_digits_for_arrival = Random_Customer_form.random_list;
            List<int> Random_digits_for_service = Random_server_form.random_list;
            List<TimeDistribution> time_dist_customer = Customer_Distribution_form.TimeDistribution;

            // calculate interarrival time for each call
            for (int i = 0; i < Customers; i++)
            {
                one_case = new SimualtionCase();
                if (i == 0)
                {
                    one_case.CustomerNumber = 1;
                    one_case.RandomInterarrivalTime = 0;
                    one_case.InterarrivalTime = 0;
                    one_case.ArrivalTime = 0;
                }
                else
                {
                    one_case.CustomerNumber = i + 1;
                    one_case.RandomInterarrivalTime = Random_digits_for_arrival[i - 1];
                    for (int j = 0; j < time_dist_customer.Count; j++)
                    {
                        if (time_dist_customer[j].MinRange <= one_case.RandomInterarrivalTime && one_case.RandomInterarrivalTime <= time_dist_customer[j].MaxRange)
                        {
                            one_case.InterarrivalTime = time_dist_customer[j].Time;
                            break;
                        }
                    }
                    one_case.ArrivalTime = one_case.InterarrivalTime + List_of_cases[i - 1].ArrivalTime;
                }
                one_case.RandomServiceTime = Random_digits_for_service[i];
                List_of_cases.Add(one_case);
            }
        }

        public void assign_server(List<SimualtionCase> List_of_cases, List<Server> Server_list, string periority)
        {
            List<int> tmp = new List<int>();
            if (periority == "Highest Priority")
            {
                Server_list.Sort((emp1, emp2) => emp2.ServiceEfficiency.CompareTo(emp1.ServiceEfficiency));
                for (int i = 0; i < List_of_cases.Count; i++)
                {
                    bool found = false;
                    for (int j = 0; j < Server_list.Count; j++)
                    {
                        if (Server_list[j].ending_time <= List_of_cases[i].ArrivalTime)
                        {
                            found = true;
                            for (int k = 0; k < Server_list[j].ServiceTimeDistribution.Count; k++)
                            {
                                if (Server_list[j].ServiceTimeDistribution[k].MinRange <= List_of_cases[i].RandomServiceTime &&
                                    List_of_cases[i].RandomServiceTime <= Server_list[j].ServiceTimeDistribution[k].MaxRange
                                    )
                                {
                                    List_of_cases[i].ServiceTime = Server_list[j].ServiceTimeDistribution[k].Time;
                                    break;
                                }
                            }
                            List_of_cases[i].WaitingTime = 0;
                            List_of_cases[i].TimeServiceBegins = List_of_cases[i].ArrivalTime;
                            List_of_cases[i].TimeServiceEnds = List_of_cases[i].TimeServiceBegins + List_of_cases[i].ServiceTime;
                            List_of_cases[i].AssignedServer = Server_list[j];
                            Server_list[j].ending_time += List_of_cases[i].TimeServiceEnds;
                            break;
                        }
                    }
                    if (!found)
                    {
                        int minn = 1000000000, cur_indx = 0;
                        for (int j = 0; j < Server_list.Count; j++)
                        {
                            if (Server_list[j].ending_time - List_of_cases[i].ArrivalTime < minn)
                            {
                                minn = Server_list[j].ending_time - List_of_cases[i].ArrivalTime;
                                cur_indx = j;
                            }
                        }
                        for (int k = 0; k < Server_list[cur_indx].ServiceTimeDistribution.Count; k++)
                        {
                            if (Server_list[cur_indx].ServiceTimeDistribution[k].MinRange <= List_of_cases[i].RandomServiceTime &&
                                List_of_cases[i].RandomServiceTime <= Server_list[cur_indx].ServiceTimeDistribution[k].MaxRange
                                )
                            {
                                List_of_cases[i].ServiceTime = Server_list[cur_indx].ServiceTimeDistribution[k].Time;
                                break;
                            }
                        }
                        List_of_cases[i].WaitingTime = minn;
                        List_of_cases[i].TimeServiceBegins = List_of_cases[i].ArrivalTime + List_of_cases[i].WaitingTime;
                        List_of_cases[i].TimeServiceEnds = List_of_cases[i].TimeServiceBegins + List_of_cases[i].ServiceTime;
                        List_of_cases[i].AssignedServer = Server_list[cur_indx];
                        Server_list[cur_indx].ending_time += List_of_cases[i].ServiceTime;
                    }
                }
            }
            else if (periority == "Random")
            {
                for (int i = 0; i < List_of_cases.Count; i++)
                {
                    bool found = false;
                    for (int j = 0; j < Server_list.Count; j++)
                    {
                        if (Server_list[j].ending_time <= List_of_cases[i].ArrivalTime)
                        {
                            found = true;
                            tmp.Add(i);
                        }
                    }
                    if(found)
                    {
                        
                        int cur_indx = 0;
                        cur_indx = r.Next(0, tmp.Count - 1);
                        for (int k = 0; k < Server_list[cur_indx].ServiceTimeDistribution.Count; k++)
                        {
                            if (Server_list[cur_indx].ServiceTimeDistribution[k].MinRange <= List_of_cases[i].RandomServiceTime &&
                                List_of_cases[i].RandomServiceTime <= Server_list[cur_indx].ServiceTimeDistribution[k].MaxRange
                                )
                            {
                                List_of_cases[i].ServiceTime = Server_list[cur_indx].ServiceTimeDistribution[k].Time;
                                break;
                            }
                        }
                        List_of_cases[i].WaitingTime = 0;
                        List_of_cases[i].TimeServiceBegins = List_of_cases[i].ArrivalTime + List_of_cases[i].WaitingTime;
                        List_of_cases[i].TimeServiceEnds = List_of_cases[i].TimeServiceBegins + List_of_cases[i].ServiceTime;
                        List_of_cases[i].AssignedServer = Server_list[cur_indx];
                        Server_list[cur_indx].ending_time += List_of_cases[i].ServiceTime;
                    }
                    else
                    {
                        int minn = 1000000000, cur_indx = 0;
                        for (int j = 0; j < Server_list.Count; j++)
                        {
                            if (Server_list[j].ending_time - List_of_cases[i].ArrivalTime < minn)
                            {
                                minn = Server_list[j].ending_time - List_of_cases[i].ArrivalTime;
                                cur_indx = j;
                            }
                        }
                        for (int k = 0; k < Server_list[cur_indx].ServiceTimeDistribution.Count; k++)
                        {
                            if (Server_list[cur_indx].ServiceTimeDistribution[k].MinRange <= List_of_cases[i].RandomServiceTime &&
                                List_of_cases[i].RandomServiceTime <= Server_list[cur_indx].ServiceTimeDistribution[k].MaxRange
                                )
                            {
                                List_of_cases[i].ServiceTime = Server_list[cur_indx].ServiceTimeDistribution[k].Time;
                                break;
                            }
                        }
                        List_of_cases[i].WaitingTime = minn;
                        List_of_cases[i].TimeServiceBegins = List_of_cases[i].ArrivalTime + List_of_cases[i].WaitingTime;
                        List_of_cases[i].TimeServiceEnds = List_of_cases[i].TimeServiceBegins + List_of_cases[i].ServiceTime;
                        List_of_cases[i].AssignedServer = Server_list[cur_indx];
                        Server_list[cur_indx].ending_time += List_of_cases[i].ServiceTime;
                    }
                }
            }
            else
            {
                for (int i = 0; i < List_of_cases.Count; i++)
                {
                    int minn1 = 10000000;
                    int cur_indx1 = 0;
                    bool found = false;
                    for (int j = 0; j < Server_list.Count; j++)
                    {
                        if (Server_list[j].ending_time <= List_of_cases[i].ArrivalTime)
                        {
                            found = true;
                            if (Server_list[j].total_work_time < minn1)
                            {
                                minn1 = Server_list[j].total_work_time;
                                cur_indx1 = j;

                            }
                        }
                    }
                    if (found)
                    {
                        for (int k = 0; k < Server_list[cur_indx1].ServiceTimeDistribution.Count; k++)
                        {
                            if (Server_list[cur_indx1].ServiceTimeDistribution[k].MinRange <= List_of_cases[i].RandomServiceTime &&
                                List_of_cases[i].RandomServiceTime <= Server_list[cur_indx1].ServiceTimeDistribution[k].MaxRange
                                )
                            {
                                List_of_cases[i].ServiceTime = Server_list[cur_indx1].ServiceTimeDistribution[k].Time;
                                break;
                            }
                        }
                        List_of_cases[i].WaitingTime = 0;
                        List_of_cases[i].TimeServiceBegins = List_of_cases[i].ArrivalTime + List_of_cases[i].WaitingTime;
                        List_of_cases[i].TimeServiceEnds = List_of_cases[i].TimeServiceBegins + List_of_cases[i].ServiceTime;
                        List_of_cases[i].AssignedServer = Server_list[cur_indx1];
                        Server_list[cur_indx1].ending_time += List_of_cases[i].ServiceTime;
                        Server_list[cur_indx1].total_work_time += List_of_cases[i].ServiceTime;
                    }
                    else
                    {
                        int minn = 1000000000, cur_indx = 0;
                        for (int j = 0; j < Server_list.Count; j++)
                        {
                            if (Server_list[j].ending_time - List_of_cases[i].ArrivalTime < minn)
                            {
                                minn = Server_list[j].ending_time - List_of_cases[i].ArrivalTime;
                                cur_indx = j;
                            }
                        }
                        for (int k = 0; k < Server_list[cur_indx].ServiceTimeDistribution.Count; k++)
                        {
                            if (Server_list[cur_indx].ServiceTimeDistribution[k].MinRange <= List_of_cases[i].RandomServiceTime &&
                                List_of_cases[i].RandomServiceTime <= Server_list[cur_indx].ServiceTimeDistribution[k].MaxRange
                                )
                            {
                                List_of_cases[i].ServiceTime = Server_list[cur_indx].ServiceTimeDistribution[k].Time;
                                break;
                            }
                        }
                        List_of_cases[i].WaitingTime = minn;
                        List_of_cases[i].TimeServiceBegins = List_of_cases[i].ArrivalTime + List_of_cases[i].WaitingTime;
                        List_of_cases[i].TimeServiceEnds = List_of_cases[i].TimeServiceBegins + List_of_cases[i].ServiceTime;
                        List_of_cases[i].AssignedServer = Server_list[cur_indx];
                        Server_list[cur_indx].ending_time += List_of_cases[i].ServiceTime;
                    }
                }
            }
        }
        public List<string> calculate_customer_data(List<SimualtionCase> List_of_cases)
        {
            List<string> tmp = new List<string>();
            double total_waited_time = 0,waited_customers=0;
            for(int i=0;i<List_of_cases.Count;i++)
            {
                if(List_of_cases[i].WaitingTime!=0)
                {
                    waited_customers++;
                    total_waited_time += List_of_cases[i].WaitingTime;
                }
            }
            double tmp1 = 0;
            if (double.Parse(List_of_cases.Count.ToString()) != 0)
                tmp1 = (total_waited_time / double.Parse(List_of_cases.Count.ToString()));

            double tmp2 = 0;
            if(double.Parse(List_of_cases.Count.ToString())!=0)
            tmp2=(waited_customers / double.Parse(List_of_cases.Count.ToString()));
            tmp.Add(tmp1.ToString());
            tmp.Add(tmp2.ToString());
            return tmp;
        }

        public List<string> calculate_server_data(List<SimualtionCase> List_of_cases , int Serv_id,List<Server> list_of_servers)
        {
            List<string> tmp = new List<string>();
            double total_idle_time = 0,total_number_of_customers = 0, total_service_time = 0;
            int total_run_time = 0;
            for (int i=0;i<list_of_servers.Count;i++)
            {
                if (list_of_servers[i].ServerId == Serv_id)
                    total_idle_time = list_of_servers[i].ending_time;
                total_run_time = Math.Max(total_run_time, list_of_servers[i].ending_time);
            }
            for(int i=0;i<List_of_cases.Count;i++)
            {
                if(List_of_cases[i].AssignedServer.ServerId == Serv_id)
                {
                    total_service_time += List_of_cases[i].ServiceTime;
                    total_number_of_customers++;
                }
            }
            total_idle_time -= total_service_time;
            double tmp1 = total_idle_time / double.Parse(total_run_time.ToString());
            double tmp2 = total_service_time / total_number_of_customers;
            tmp.Add(tmp1.ToString());
            tmp.Add(tmp2.ToString());
            tmp.Add(total_service_time.ToString());
            return tmp;
        }
    }
}
