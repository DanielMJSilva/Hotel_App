using GroupProject_Daniel_and_Simon__Hotel_Application.Models;
using Hotel.Models;

namespace GroupProject_Daniel_and_Simon__Hotel_Application.Services
{
    public interface IBookingRepository
    {
        Task<bool> BookingExists(int bookingId);
        Task<IEnumerable<Booking>> GetBookings();
        Task<Booking> GetBookingById(int bookingId);
        Task<Booking> CreateBooking(Booking booking);
        Task<Booking> UpdateBooking(int bookingId, Booking booking);
        Task<Booking> DeleteBookingAsync(int bookingId);
    }
}
