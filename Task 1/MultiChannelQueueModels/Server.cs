using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiChannelQueueModels
{
    public class Server
    {
        public Server()
        {
            ServiceTimeDistribution = new List<TimeDistribution>();
        }
        public int ServerId { get; set; }

        public string Name { get; set; }

        public double ServiceEfficiency { get; set; }

        public List<TimeDistribution> ServiceTimeDistribution { get; set; }

        public int ending_time = 0;

        public int total_work_time = 0;
    }
}
