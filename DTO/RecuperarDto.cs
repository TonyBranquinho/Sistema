namespace Sistema.DTO
{
    public class RecuperarDto
    {
        public string Email { get; set; }
        
        public RecuperarDto() 
        {
        }

        public RecuperarDto(string email)
        {
            Email = email;
        }
    }
}
