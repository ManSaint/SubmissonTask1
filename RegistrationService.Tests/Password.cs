// This class contains test methods related to password validation
[TestClass]
public class TestPassword
{
    // Test method to check if the password is in the correct format
    [TestMethod]
    [DataRow("!12345678")]
    [DataRow("!#¤abc999")]
    [DataRow("=abcdefgh")]
    public void CheckIfPasswordIsInCorrectFormat_ShouldReturnTrue(string password)
    {
        // Arrange
        var testDummy = new RegistrationServiceManager();
        var newUser = new User("SaintManu", password, "test@email.com");

        // Act
        string message = testDummy.AddUser(newUser);

        // Assert
        Assert.AreEqual($"{newUser.Username} added successfully", message);
        Assert.IsTrue(testDummy.UserList.Contains(newUser)); // Checking if the UserList of the RegistrationServiceManager contains the new user
    }

    // Test method to check if the password does not contain a special character
    [TestMethod]
    [DataRow("12345678")]
    [DataRow("abc999")]
    [DataRow("abcdefgh")]
    public void CheckIfPasswordDoesNotContainSpecialCharacter_ShouldReturnFalse(string password)
    {
        // Arrange
        var testDummy = new RegistrationServiceManager();
        var newUser = new User("SaintManu", password, "test@email.com");

        // Act and Assert
        Assert.ThrowsException<ArgumentException>(() => testDummy.AddUser(newUser), $"Password should be at least 8 characters long and contain at least one number and one special character");
    }

    // This test method checks if the method CheckIfPasswordIsTooShort_ShouldReturnFalse in the RegistrationServiceManager class correctly handles passwords that are too short
    [TestMethod]
    [DataRow("!Manu")]
    [DataRow("?John")]
    [DataRow("=Jane")]
    public void CheckIfPasswordIsTooShort_ShouldReturnFalse(string password)
    {
        // Arrange
        var testDummy = new RegistrationServiceManager(); // Creating an instance of the RegistrationServiceManager class for testing purposes
        var newUser = new User("SaintManu", password, "test@email.com"); // Creating a new user with the specified username, password, and email

        // Act and Assert
        Assert.ThrowsException<ArgumentException>(() => testDummy.AddUser(newUser), $"Password should be at least 8 characters long and contain at least one number and one special character"); // Verifying that an ArgumentException is thrown when trying to add a user with a password that is too short
    }
}