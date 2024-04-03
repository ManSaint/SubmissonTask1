// This class contains unit tests for the Email validation functionality
[TestClass]
public class TestEmail
{
    // This test method checks if the given email is in the correct format and should return true
    [TestMethod]
    [DataRow("user@example.com")]
    [DataRow("john.doe@example.com")]
    [DataRow("jane.smith@example.com")]
    public void CheckIfEmailIsInCorrectFormat_ShouldReturnTrue(string email)
    {
        // Arrange
        var testDummy = new RegistrationServiceManager(); // Creating a test instance of RegistrationServiceManager
        var newUser = new User("SaintManu", "!abcd1234", email); // Creating a new User object with provided email

        // Act
        string message = testDummy.AddUser(newUser); // Adding the new user

        // Assert
        Assert.AreEqual($"{newUser.Username} added successfully", message); // Checking if user added successfully message is returned
        Assert.IsTrue(testDummy.UserList.Contains(newUser)); // Checking if the new user is added to the user list
    }

    // This test method checks if the given email is not in the correct format and should return false
    [TestMethod]
    [DataRow("userexample.com")]
    [DataRow("john.doeexample.com")]
    [DataRow("jane.smith@com")]
    public void CheckIfEmailIsInCorrectFormat_ShouldReturnFalse(string email)
    {
        // Arrange
        var testDummy = new RegistrationServiceManager(); // Creating a test instance of RegistrationServiceManager
        var newUser = new User("SaintManu", "!abcd1234", email); // Creating a new User object with invalid email

        // Act and assert
        Assert.ThrowsException<ArgumentException>(() => testDummy.AddUser(newUser), $"Email format is invalid"); // Checking if adding user with invalid email throws an exception
    }
}