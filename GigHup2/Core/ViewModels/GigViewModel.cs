using GigHup2.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GigHup2.ViewModels
{
    public class GigViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Venue { get; set; }

        [Required]
        [MyValidDate]
        public string Date { get; set; }

        [Required]
        [MyValidTime]
        public string Time { get; set; }

        [Required]
        public byte Genre { get; set; }
        public string Action
        {
            get
            {
                return (Id != 0) ? "Update" : "Create";
            }
        }

        public IEnumerable<Genre> Genres { get; set; }
        public DateTime GetDateTime()
        {
            return DateTime.Parse(string.Format("{0} {1}", Date, Time)); 
        }
        public string Heading { get; set; }
    }
}