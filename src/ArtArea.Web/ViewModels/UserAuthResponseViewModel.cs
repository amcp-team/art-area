namespace ArtArea.Web.ViewModels
{
    // if username is valid & user was seccessfully registered than username holds username passed & token is valid
    // else Successfull holds false & Username = Token = ""
    public class UserAuthResponseViewModel
    {
        public string Username { get; set; }
        public string Token { get; set; }
        public bool Successfull { get; set; }
    }
}