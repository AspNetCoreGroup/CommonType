namespace ModelLibrary.Model
{
    public class NetworkUserDto
    {
        public int NetworkUserID { get; set; }

        public int NetworkID { get; set; }

        public int UserID { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsEditor { get; set; }


        public NetworkDto? Network { get; set; }

        public UserDto? User { get; set; }
    }
}