using API.Data;
using API.DTOs;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Business
{
    public class BusinessUserUpdate : BusinessBase
    {
        private readonly AppDbContext appDbContext;
        private readonly User user;

        public BusinessUserUpdate(User user, AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
            this.user = user;
        }

        public override void Procces()
        {
            User? tempUser = appDbContext.Users.AsNoTracking().FirstOrDefault((u => u.Id == user.Id));

            if (tempUser != null)
            {
                if (IsValidString(user.FirstName) &&
                    IsValidString(user.SecondName) &&
                    IsValidString(user.LastName) &&
                    IsValidString(user.SecondLastName) &&
                    user.DateBirth != DateTime.MinValue &&
                    user.Salary > 0)
                {
                    user.DateUpdate = DateTime.Now;
                    user.DateCreation = tempUser.DateCreation;

                    appDbContext.Users.Update(user);
                    appDbContext.SaveChanges();

                    SetResult(true);
                }
                else
                {
                    SetValidation(MessageConst.InvalidUserProperties);
                }
            }
            else
            {
                SetValidation(MessageConst.NotFindedUser);
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
