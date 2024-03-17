using API.Models;

namespace API.DTOs
{
    public class UserUpdateDTO
    {
        public Int32 Id { get; set; }

        public String FirstName { get; set; } = String.Empty;

        public String? SecondName { get; set; }

        public String LastName { get; set; } = String.Empty;

        public String? SecondLastName { get; set; }

        public DateTime DateBirth { get; set; }

        public Decimal Salary { get; set; }

        public static explicit operator User(UserUpdateDTO userUpdateDTO)
        {
            User user = new User
            {
                DateBirth = userUpdateDTO.DateBirth,
                FirstName = userUpdateDTO.FirstName,
                Id = userUpdateDTO.Id,
                LastName = userUpdateDTO.LastName,
                Salary = userUpdateDTO.Salary,
                SecondLastName = userUpdateDTO.SecondLastName,
                SecondName = userUpdateDTO.SecondName
            };

            return user;
        }
    }
}
