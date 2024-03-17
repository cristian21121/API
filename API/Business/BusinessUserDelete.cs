using API.Data;
using API.DTOs;
using API.Models;

namespace API.Business
{
    public class BusinessUserDelete : BusinessBase
    {
        private readonly AppDbContext appDbContext;
        private Int32 id;

        public BusinessUserDelete(Int32 id, AppDbContext appDbContext)
        {
            this.id = id;
            this.appDbContext = appDbContext;
        }

        public override void Procces()
        {
            User? user = appDbContext.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                appDbContext.Users.Remove(user);
                appDbContext.SaveChanges();

                SetResult(true);
            }
            else
            {
                SetValidation(MessageConst.NotFindedUser);
            }
        }
    }
}
