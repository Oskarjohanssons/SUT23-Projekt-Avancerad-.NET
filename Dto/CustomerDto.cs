namespace SUT23_Projekt___Avancerad_.NET.Dto
{
    public class CustomerDto
    {
        public int CustomerId { get; set; }
        public string Email { get; set; }

        public string Phone { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }


        public ICollection<AppointmentDto> Appointments { get; set; }

    }
}
