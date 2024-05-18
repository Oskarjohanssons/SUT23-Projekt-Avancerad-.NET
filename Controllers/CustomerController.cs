using ClassLibary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SUT23_Projekt___Avancerad_.NET.Services;

namespace SUT23_Projekt___Avancerad_.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomer<Customer> _customer;
        public CustomerController(ICustomer<Customer> customer)
        {
            _customer = customer;
        }

        [HttpPut("Update Customer/{id:int}")]
        public async Task<ActionResult<Customer>> UpdateCustomer(int id, Customer customer)
        {
            try
            {
                if (id != customer.CustomerID)
                {
                    return BadRequest("No Customer with that ID exists...");
                }
                var customerToUpdate = await _customer.GetSingleCustomer(id);
                if (customerToUpdate == null)
                {
                    return NotFound($"Customer with ID {id} could not be found..");
                }

                customer.CustomerID = id;
                var updatedCustomer = await _customer.UpdateCustomer(customer);

                if (updatedCustomer != null)
                {
                    return updatedCustomer;
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Failed to update customer.");
                }

            }
            catch
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to Post data To Database.......");
            }




        }

        [HttpDelete("CancelAppointment/{customerID:int}/{id:int}")] //funkar
        public async Task<ActionResult<Appointment>> CancelAppointment(int id, int customerID)
        {
            try
            {
                var appointment = await _customer.GetUserWithAppointment(customerID);
                if (appointment == null)
                {
                    return NotFound();
                }

                var cancelAppointment = appointment.Appointments.FirstOrDefault(a => a.AppointmentID == id);
                if (cancelAppointment == null)
                {
                    return NotFound("This Appointment ID is not booked in your name.");
                }

                var result = await _customer.CancelAppointment(cancelAppointment);

                await _customer.LogAppointmentChange("Canceled Appointment", null, null, cancelAppointment);

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error removing data from the database.");
            }
        }

        [HttpPost("Book new appointment")]
        public async Task<ActionResult<Appointment>> BookNewAppointment(Appointment appointment)
        {


            try
            {
                if (appointment == null)
                {
                    return BadRequest();
                }

                var newAppointment = await _customer.AddAppointment(appointment);
                await _customer.LogAppointmentChange("Customer Booked Appointment", null, null, newAppointment);
                return CreatedAtAction(nameof(BookNewAppointment), new { id = newAppointment.AppointmentID }, newAppointment);


            }
            catch
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to Post Data To Database.......");
            }

        }

    }

}
