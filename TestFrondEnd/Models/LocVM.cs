using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestFrondEnd.Models
{
    public class LocVM
    {
        public string LocationId { get; set; }
        public string LocationName { get; set; }
    }

    public class Datum
    {
        public string locationId { get; set; }
        public string locationName { get; set; }
        public List<object> trBpkbs { get; set; }
    }

    public class Root
    {
        public string code { get; set; }
        public string status { get; set; }
        public string message { get; set; }
        public List<Datum> data { get; set; }
    }
}
