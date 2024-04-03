// Define a public class called User
public class User
{
    // Declare a public property for the username of the user
    public string Username { get; set; }

    // Declare a public property for the password of the user
    public string Password { get; set; }

    // Declare a public property for the email of the user
    public string Email { get; set; }

    // Constructor for the User class that initializes the username, password, and email
    public User(string username, string password, string email)
    {
        // Set the username property to the provided username
        Username = username;

        // Set the password property to the provided password
        Password = password;

        // Set the email property to the provided email
        Email = email;
    }
}