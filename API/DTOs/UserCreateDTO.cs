using API.Models;

namespace API.DTOs
{
    public class UserCreateDTO
    {
        public String FirstName { get; set; } = String.Empty;

        public String? SecondName { get; set; }

        public String LastName { get; set; } = String.Empty;

        public String? SecondLastName { get; set; }

        public DateTime DateBirth { get; set; }

        public Decimal Salary { get; set; }

        public static explicit operator User(UserCreateDTO userCreateDTO)
        {
            User user = new User
            {
                DateBirth = userCreateDTO.DateBirth,
                FirstName = userCreateDTO.FirstName,
                LastName = userCreateDTO.LastName,
                Salary = userCreateDTO.Salary,
                SecondLastName = userCreateDTO.SecondLastName,
                SecondName = userCreateDTO.SecondName
            };

            return user;
        }
    }
}
