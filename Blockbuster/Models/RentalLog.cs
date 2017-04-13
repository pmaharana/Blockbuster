using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blockbuster.Models
{
    public class RentalLog
    {
        public int Id { get; set; }
        public string Customer { get; set; }
        public string Movie { get; set; }
        public DateTime? DateCheckedOut { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}