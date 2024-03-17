namespace API.DTOs
{
    public class UserGetListDTO
    {
        public Int32 PageNumber { get; set; }

        public Int32 PageSize { get; set; }

        public String Name { get; set; } = String.Empty;
    }
}
