using GigHup2.Core.Models;
using System;

namespace GigHup2.Dtos
{
    public class GigDto
    {
        public int Id { get; set; }

        public bool IsCancled { get; set; }

        public UserDto Artist { get; set; }
     

        public DateTime DateTime { get; set; }

     
        public string Venue { get; set; }


        public GenreDto Genre { get; set; }
   
     
      
    }
}