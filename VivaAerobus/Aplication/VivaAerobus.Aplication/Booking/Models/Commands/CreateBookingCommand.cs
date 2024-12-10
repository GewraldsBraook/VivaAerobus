using MediatR;
using VivaAerobus.Domain.CQRS.Models;

namespace VivaAerobus.Aplication.Booking.Models.Commands
{
    public class CreateBookingCommand : Command, IRequest<CommandResponse<object>>
    {
        public Domain.Booking.Models.Booking Booking { get; set; }
    }
}
