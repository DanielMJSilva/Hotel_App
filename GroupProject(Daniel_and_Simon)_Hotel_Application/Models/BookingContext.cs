using Hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace GroupProject_Daniel_and_Simon__Hotel_Application.Models
{
    public class BookingContext : DbContext
    {
        public BookingContext(DbContextOptions<BookingContext> options) : base(options) { }

        public DbSet<Booking> hoteldb { get; set; }
    }
}
