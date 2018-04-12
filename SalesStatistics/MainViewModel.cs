using SalesStatistics.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesStatistics {
    class MainViewModel {
        readonly SalesStatisticsContext salesStatisticsContext;

        public string Ass { get; set; }

        public MainViewModel() {
            salesStatisticsContext = new SalesStatisticsContext();
        }
    }
}
