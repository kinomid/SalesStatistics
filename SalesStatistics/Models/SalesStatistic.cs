// TODO:3 Добавляем модель SalesStatistic
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesStatistics.Models {

    class SalesStatistic {
        public DateTime ShipDate { get; set; }
        public decimal Amount { get; set; }

        public string Type1_ClassifierId { get; set; }
        public Type1_Classifier Type1_Classiifer { get; set; }

        public string Type2_ClassifierId { get; set; }
        public Type2_Classifier Type2_Classiifer { get; set; }

        public string Type3_ClassifierId { get; set; }
        public Type3_Classifier Type3_Classiifer { get; set; }

        public string Type4_ClassifierId { get; set; }
        public Type4_Classifier Type4_Classiifer { get; set; }
    }
}
