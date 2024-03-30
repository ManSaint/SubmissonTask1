// Define a class named User
public class User
{
    // Declare properties for the User class
    public string Username { get; set; }

    public string Password { get; set; }
    public string Email { get; set; }

    // Constructor for the User class that initializes the username, password, and email properties
    public User(string username, string password, string email)
    {
        Username = username;
        Password = password;
        Email = email;
    }
}