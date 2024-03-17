using API.Data;
using API.DTOs;
using API.Models;

namespace API.Business
{
    public class BusinessUserGet : BusinessBase
    {
        private readonly AppDbContext appDbContext;
        private Int32 id;

        public BusinessUserGet(Int32 id, AppDbContext appDbContext)
        {
            this.id = id;
            this.appDbContext = appDbContext;
        }

        public override void Procces()
        {
            User? user = appDbContext.Users.FirstOrDefault(u => u.Id == id);

            if (user != null)
            {
                SetResult(user);
            }
            else
            {
                SetValidation(MessageConst.NotFindedUser);
            }
        }
    }
}
