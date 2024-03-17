using API.Data;
using API.DTOs;
using API.Models;

namespace API.Business
{
    public class BusinessUserCreate : BusinessBase
    {
        private readonly AppDbContext appDbContext;
        private readonly User user;

        public BusinessUserCreate(User user, AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
            this.user = user;
        }

        public override void Procces()
        {
            if (IsValidString(user.FirstName) &&
                IsValidString(user.SecondName) &&
                IsValidString(user.LastName) &&
                IsValidString(user.SecondLastName) &&
                user.DateBirth != DateTime.MinValue &&
                user.Salary > 0)
            {
                user.DateCreation = DateTime.Now;
                user.DateUpdate = DateTime.Now;

                appDbContext.Users.Add(user);
                appDbContext.SaveChanges();

                SetResult(true);
            }
            else
            {
                SetValidation(MessageConst.InvalidUserProperties);
            }
        }

        public bool IsValidString(string? value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (value.Length < 51 && !value.Any(char.IsDigit))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
    }

}
