using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blockbuster.Models
{
    public class RentalLog
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int MovieId { get; set; }
        public DateTime? DateCheckedOut { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public Customers Customer { get; set; }
        public Movies Movie { get; set; }
    }
}