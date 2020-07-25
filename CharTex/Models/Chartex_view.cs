using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharTex.Models
{
    public class Chartex_view
    {
        
        public long id { get; private set; }
        public int PersonId { get; private set; }
        public string Name { get; private set; }
        public string Family { get; private set; }
        public DateTime?  StartDate { get; private set; }
        public DateTime?  EndDate { get; private set; }
        public int Sum { get; private set; }
        public int Total { get; private set; }
    }
}
