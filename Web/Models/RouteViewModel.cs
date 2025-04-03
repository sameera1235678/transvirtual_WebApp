using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DijkstraLib.Models;

namespace Web.Models
{
    public class RouteViewModel
    {
        [Required(ErrorMessage = "Please select a starting node")]
        [Display(Name = "From Node")]
        public string fromNode { get; set; }

        [Required(ErrorMessage = "Please select a destination node")]
        [Display(Name = "To Node")]
        public string toNode { get; set; }

        public List<string> availableNodes { get; set; }

        public ShotestPathData result { get; set; }
    }
}