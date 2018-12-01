using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public class JsonMapSummaryN
    {
        public bool Sucess { get; set; }
        public string Message { get; set; }
        public MapSummaryN[] Result { get; set; }
    }
}
