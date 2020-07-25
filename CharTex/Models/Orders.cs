using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharTex.Models
{
    public class Orders
    {
        public int id { get; set; }
        public int PersonId { get; set; }
        public DateTime TransactionDate { get; set; }
        public int Price { get; set; }
    }
}
