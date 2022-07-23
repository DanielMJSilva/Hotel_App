using GroupProject_Daniel_and_Simon__Hotel_Application.Models;
using Hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace GroupProject_Daniel_and_Simon__Hotel_Application.Services
{
    public class BookingRepository : IBookingRepository
    {
        private readonly BookingContext _BookingContext;

        public async Task<bool> BookingExists(int id)
        {
            Booking booking = await _BookingContext.Bookings.FindAsync(id);

            if(booking != null)
            {
                return true;
            }
            return false;
        }

        public BookingRepository(BookingContext bookingContext)
        {
            _BookingContext = bookingContext;
        }

        public async Task<Booking> CreateBooking(Booking booking)
        {
            Booking newBooking = new()
            {
                Id = booking.Id,
                Username = booking.Username,
                StartDate = booking.StartDate,
                EndDate = booking.EndDate,
                RoomId = booking.RoomId,
                NumPeople = booking.NumPeople,
                Price = booking.Price

            };
            await _BookingContext.AddAsync(newBooking);
            await _BookingContext.SaveChangesAsync();

            return newBooking;
        }

        public async Task<Booking> DeleteBookingAsync(int bookingId)
        {
            Booking booking = await _BookingContext.Bookings.FindAsync(bookingId);
            _BookingContext.Remove(booking);
            await _BookingContext.SaveChangesAsync();
            return booking;
        }

        public async Task<Booking> GetBookingById(int id)
        {
            return await _BookingContext.Bookings.FindAsync(id);
        }

        public async Task<IEnumerable<Booking>> GetBookings()
        {
            return await _BookingContext.Bookings.ToListAsync();
        }

        public async Task<Booking> UpdateBooking(int id, Booking booking)
        {
            Booking updateBooking = await _BookingContext.Bookings.FindAsync(id);
            updateBooking.StartDate = booking.StartDate;
            updateBooking.EndDate = booking.EndDate;
            updateBooking.NumPeople = booking.NumPeople;
            updateBooking.Price = booking.Price;

            await _BookingContext.SaveChangesAsync();
            return updateBooking;
        }

        
    }
}
