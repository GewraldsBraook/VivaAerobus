using MediatR;
using Microsoft.AspNetCore.Mvc;
using VivaAerobus.API.Attributes;
using VivaAerobus.API.Controllers.Base;
using VivaAerobus.Aplication.Booking.Models.Commands;
using VivaAerobus.Aplication.Booking.Models.Queries;
using VivaAerobus.Aplication.Booking.Models.Queries.Results;

namespace VivaAerobus.API.Controllers.v1
{
    [ApiController]
    [ApiKey]
    [Route("api/v1/[controller]")]
    public class BookingController(ILogger<BookingController> logger, IMediator mediator) : BaseController(logger, mediator)
    {

        /// <summary>
        /// Create booking 
        /// </summary>
        /// <returns></returns>
        [HttpPost("create")]
        [ProducesResponseType(typeof(BookingsResult), 200)]
        [ProducesResponseType(typeof(Nullable), 401)]
        [ProducesResponseType(typeof(Nullable), 500)]
        public async Task<IActionResult> Create([FromBody] CreateBookingCommand createBookingCommand)
        {
            if (createBookingCommand == null) return BadRequest();

            return await SendCommand<CreateBookingCommand, object>(createBookingCommand);

        }

        /// <summary>
        /// Get all bookings 
        /// </summary>
        /// <returns></returns>
        [HttpGet("bookings")]
        [ProducesResponseType(typeof(BookingsResult), 200)]
        [ProducesResponseType(typeof(Nullable), 401)]
        [ProducesResponseType(typeof(Nullable), 500)]
        public async Task<IActionResult> GetAll()
        {
            return await SendQuery<GetAllBookingsQuery, BookingsResult>(new GetAllBookingsQuery());
        }

        /// <summary>
        /// Get booking by record locator 
        /// </summary>
        /// <returns></returns>
        [HttpGet("booking")]
        [ProducesResponseType(typeof(BookingsResult), 200)]
        [ProducesResponseType(typeof(Nullable), 401)]
        [ProducesResponseType(typeof(Nullable), 500)]
        public async Task<IActionResult> GetByRecordLocator([FromBody] GetBookingQuery bookingQuery)
        {
            if (bookingQuery == null) return BadRequest();

            return await SendQuery<GetBookingQuery, BookingResult>(bookingQuery);
        }
    }
}
