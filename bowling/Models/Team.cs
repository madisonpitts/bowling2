using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bowling.Models
{
    public class Team
    {
        [Required]
        [Key]
        public int TeamID { get; set; }

        public string TeamName { get; set; }

        public int CaptainID { get; set; }
    }
}
