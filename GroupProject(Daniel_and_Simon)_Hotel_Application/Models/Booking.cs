
using GroupProject_Daniel_and_Simon__Hotel_Application.Models;
using System;

namespace Hotel.Models
{
   
    public class Booking
    {
        public int Id { get; set; }
      
        public string Username { get; set; }
    
        public int RoomId { get; set; }
    
        public DateTime StartDate { get; set; }
     
        public DateTime EndDate { get; set; }
      
        public decimal Price { get; set; }

        public int NumPeople { get; set; }
    }
}
