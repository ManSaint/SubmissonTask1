[TestClass]
public class UnitTest1
{
    // Test method to check if the username is in the correct format
    [TestMethod]
    public void CheckIfUsernameIsInCorrectFormat()
    {
        // Arrange
        // Create an instance of the RegistrationServiceManager class
        var testDummy = new RegistrationServiceManager();
        // Set the username to be tested
        string testUsername = "SaintManu";

        // Act
        // Call the CheckUsernameFormat method of the testDummy instance and store the result
        bool isCorrectFormat = testDummy.CheckUsernameFormat(testUsername);

        // Assert
        // Check if the result is true, indicating that the username is in the correct format
        Assert.IsTrue(isCorrectFormat);
    }

    // Test method to check if the username is unique
    [TestMethod]
    public void CheckIfUsernameIsUnique()
    {
        // Arrange
        // Create an instance of the RegistrationServiceManager class
        var testDummy = new RegistrationServiceManager();
        // Add a user with a username that is not unique
        testDummy.UserList.Add(new User("jane_doe", "123!@#987", "saintmanu@email.com"));
        // Set the username to be tested
        string testName = "!jane_doe";

        // Act
        // Call the CheckUsernameUnique method of the testDummy instance and store the result
        bool isUnique = testDummy.CheckUsernameUnique(testName);

        // Assert
        // Check if the result is true, indicating that the username is unique
        Assert.IsTrue(isUnique);
    }

    // Test method to check if the password is in the correct format
    [TestMethod]
    public void CheckIfPasswordIsInCorrectFormat()
    {
        // Arrange
        // Create an instance of the RegistrationServiceManager class
        var testDummy = new RegistrationServiceManager();
        // Set the password to be tested
        string testPassword = "!abcd1234";

        // Act
        // Call the CheckPasswordFormat method of the testDummy instance and store the result
        bool isCorrectFormat = testDummy.CheckPasswordFormat(testPassword);

        // Assert
        // Check if the result is true, indicating that the password is in the correct format
        Assert.IsTrue(isCorrectFormat);
    }

    // Test method to check if the email is in the correct format
    [TestMethod]
    public void CheckIfEmailIsInCorrectFormat()
    {
        // Arrange
        // Create an instance of the RegistrationServiceManager class
        var testDummy = new RegistrationServiceManager();
        // Set the email to be tested
        string email = "test@email.com";

        // Act
        // Call the CheckEmailFormat method of the testDummy instance and store the result
        bool isCorrectFormat = testDummy.CheckEmailFormat(email);

        // Assert
        // Check if the result is true, indicating that the email is in the correct format
        Assert.IsTrue(isCorrectFormat);
    }

    // Test method to check if a user can be added successfully
    [TestMethod]
    public void CheckIfAbleToAddUser()
    {
        // Arrange
        // Create an instance of the RegistrationServiceManager class
        var testDummy = new RegistrationServiceManager();
        // Set the username, password, and email for the new user
        string username = "SaintManu";
        string password = "!abcd1234";
        string email = "test@email.com";
        // Create a new User object with the provided details
        var newUser = new User(username, password, email);

        // Act
        // Call the AddUser method of the testDummy instance and store the returned message
        string message = testDummy.AddUser(newUser);

        // Assert
        // Check if the returned message matches the expected message
        Assert.AreEqual($"{newUser.Username} added successfully", message);
        // Check if the UserList of testDummy contains the new user
        Assert.IsTrue(testDummy.UserList.Contains(newUser));
    }
}