public class RegistrationServiceManager
{
    // List to store users
    public List<User> UserList = new List<User>();

    // Check if the username format is valid
    public bool CheckUsernameFormat(string username)
    {
        // Username should contain only alphanumeric characters, be between 5 and 20 characters long
        if (Regex.IsMatch(username, "^[a-zA-Z0-9]+$") && username.Length >= 5 && username.Length <= 20)
        {
            return true;
        }
        else
        {
            // Throw an exception if the username format is invalid
            throw new ArgumentException("Username must be between 5 and 20 characters long");
        }
    }

    // Check if the username is unique
    public bool CheckUsernameUnique(string username)
    {
        // Check if the username already exists in the UserList
        if (UserList.Any(user => user.Username.ToLower() == username.ToLower()))
        {
            // Throw an exception if the username already exists
            throw new ArgumentException("Username already exists");
        }

        return true;
    }

    // Check if the password format is valid
    public bool CheckPasswordFormat(string password)
    {
        // Password should be at least 8 characters long and contain at least one special character
        string specialCharacters = "!@#$%^&*()-_=+[]{};:'\",.<>/?\\|";
        if (password.Length >= 8 && (password.Any(sc => specialCharacters.Contains(sc))))
        {
            return true;
        }
        else
        {
            // Throw an exception if the password format is invalid
            throw new ArgumentException("Password should be at least 8 characters long and contain at least one number and one special character");
        }
    }

    // Check if the email format is valid
    public bool CheckEmailFormat(string email)
    {
        // Email should be in a valid format
        string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
        if (Regex.IsMatch(email, pattern))
        {
            return true;
        }
        else
        {
            // Throw an exception if the email format is invalid
            throw new ArgumentException("Email format is invalid");
        }
    }

    // Add a new user to the UserList
    public string AddUser(User newUser)
    {
        // Check if the user information is valid and then add the user to the UserList
        if (CheckUsernameFormat(newUser.Username) &&
            CheckUsernameUnique(newUser.Username) &&
            CheckPasswordFormat(newUser.Password) &&
            CheckEmailFormat(newUser.Email))
        {
            // Add the new user to the UserList and return a success message
            UserList.Add(newUser);
            return $"{newUser.Username} added successfully";
        }
        else
        {
            // Throw an exception if the user information is invalid
            throw new ArgumentException("I messed up");
        }
    }
}