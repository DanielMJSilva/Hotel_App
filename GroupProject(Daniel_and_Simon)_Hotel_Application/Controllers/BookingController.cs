using GroupProject_Daniel_and_Simon__Hotel_Application.Models;
using GroupProject_Daniel_and_Simon__Hotel_Application.Services;
using Hotel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GroupProject_Daniel_and_Simon__Hotel_Application.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookingController : Controller
    {
        private readonly IBookingRepository _iBookingRepository;

        public BookingController(IBookingRepository iBookingRepository)
        {
            _iBookingRepository = iBookingRepository;

        }

        //Get All Bookings
        [HttpGet("Bookings")]
        public async Task<IActionResult> Users()
        {
            return Ok(await _iBookingRepository.GetBookings());
        }

        //Get Booking by Id
        [HttpGet("{id}")]
        public async Task<IActionResult> User(int id)
        {
            return Ok(await _iBookingRepository.GetBookingById(id));
        }

        //POST Create User
        [HttpPost("create")]
        public async Task<IActionResult> CreateUserAsync(Booking booking)
        {

            return Ok(await _iBookingRepository.CreateBooking(booking));

        }


        //Update Booking
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateBooking(int id, Booking booking)
        {
            bool bookingExists = await _iBookingRepository.BookingExists(id);
           
            if (bookingExists)
            {
               await _iBookingRepository.UpdateBooking(id, booking);
                return Ok(await _iBookingRepository.GetBookingById(id));
            }
            return NotFound();
        }

        //Delete Booking
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {

            bool bookingExists = await _iBookingRepository.BookingExists(id);

            if (bookingExists)
            {
                return Ok(await _iBookingRepository.DeleteBookingAsync(id));
            }
            return NotFound();
        }
    }
}
