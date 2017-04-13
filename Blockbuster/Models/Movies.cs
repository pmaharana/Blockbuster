using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blockbuster.Models
{
    public class Movies
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int? YearReleased { get; set; }
        public string Director { get; set; }
        public string Genre { get; set; }
        public bool? IsCheckedOut { get; set; }


    }
}