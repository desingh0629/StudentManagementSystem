using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Model
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [Range(5, 15, ErrorMessage = "Age must be between 5 and 15")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Grade is required")]
        public string Grade { get; set; }

        public string Address { get; set; }
        [EmailAddress(ErrorMessage = "Invalid email address")]

        public string Email { get; set; }
        [Phone(ErrorMessage = "Invalid phone number")]

        public string PhoneNumber { get; set; }

        public DateTime RegistrationDate { get; set; }
        public bool IsActive { get; set; }


    }

}
