[TestClass] // This attribute marks the TestUser class as a test class for unit testing purposes
public class TestUser // This class contains unit tests for the User class
{
    [TestMethod] // This attribute marks the CheckIfAbleToAddUser_ShouldReturnTrue method as a test method
    public void CheckIfAbleToAddUser_ShouldReturnTrue()
    {
        // Arrange
        var testDummy = new RegistrationServiceManager(); // Create an instance of RegistrationServiceManager for testing
        var newUser = new User("SaintManu", "!abcd1234", "test@email.com"); // Create a new User object for testing

        // Act
        string message = testDummy.AddUser(newUser); // Call the AddUser method of testDummy and store the return message

        // Assert
        Assert.AreEqual($"{newUser.Username} added successfully", message); // Check if the message returned is as expected
        Assert.IsTrue(testDummy.UserList.Contains(newUser)); // Check if the UserList of testDummy contains the newUser object
    }
}