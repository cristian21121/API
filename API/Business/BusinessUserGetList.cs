using API.Data;
using API.DTOs;
using API.Models;

namespace API.Business
{
    public class BusinessUserGetList : BusinessBase
    {
        private readonly AppDbContext appDbContext;
        private UserGetListDTO userGetListDTO;

        public BusinessUserGetList(UserGetListDTO userGetListDTO, AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
            this.userGetListDTO = userGetListDTO;
        }

        public override void Procces()
        {
            Int32 recordsToSkip = (userGetListDTO.PageNumber - 1) * userGetListDTO.PageSize;

            List<User> users = appDbContext.Users
                .Where(u => u.FirstName == userGetListDTO.Name || u.LastName == userGetListDTO.Name)
                .OrderBy(u => u.Id)
                .Skip(recordsToSkip)
                .Take(userGetListDTO.PageSize)
                .ToList();

            SetResult(users);
        }
    }
}
