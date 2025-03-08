using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateBookingDto> _validator;

        public BookingController(IBookingService bookingService, IMapper mapper, IValidator<CreateBookingDto> validator)
        {
            _bookingService = bookingService;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _bookingService.TGetListAll();
            return Ok(_mapper.Map<List<ResultBookingDto>>(values));
        }

        [HttpPost]
        public IActionResult CreateBooking([FromBody] CreateBookingDto createBookingDto)
        {
            var validationResult = _validator.Validate(createBookingDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var value = _mapper.Map<Booking>(createBookingDto);
            _bookingService.TAdd(value);
            return Ok("Rezervasyon Yapıldı");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var value = _bookingService.TGetByID(id);
            if (value == null)
            {
                return NotFound("Rezervasyon bulunamadı!");
            }

            _bookingService.TDelete(value);
            return Ok("Rezervasyon Silindi");
        }

        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            var existingBooking = _bookingService.TGetByID(updateBookingDto.BookingID);
            if (existingBooking == null)
            {
                return NotFound("Güncellenecek rezervasyon bulunamadı!");
            }

            var value = _mapper.Map(updateBookingDto, existingBooking);
            _bookingService.TUpdate(value);
            return Ok("Rezervasyon Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var value = _bookingService.TGetByID(id);
            if (value == null)
            {
                return NotFound("Rezervasyon bulunamadı!");
            }

            return Ok(_mapper.Map<GetBookingDto>(value));
        }

        [HttpGet("BookingStatusApproved/{id}")]
        public IActionResult BookingStatusApproved(int id)
        {
            var value = _bookingService.TGetByID(id);
            if (value == null)
            {
                return NotFound("Rezervasyon bulunamadı!");
            }

            _bookingService.BookingStatusApproved(id);
            return Ok("Rezervasyon onaylandı!");
        }

        [HttpGet("BookingStatusCancelled/{id}")]
        public IActionResult BookingStatusCancelled(int id)
        {
            var value = _bookingService.TGetByID(id);
            if (value == null)
            {
                return NotFound("Rezervasyon bulunamadı!");
            }

            _bookingService.BookingStatusCancelled(id);
            return Ok("Rezervasyon iptal edildi!");
        }
    }
}
