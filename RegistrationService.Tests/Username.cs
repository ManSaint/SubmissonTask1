[TestClass] // This is the attribute signifying that the TestUsername class contains test methods
public class TestUsername
{
    [TestMethod] // This attribute indicates that the following method is a test method
    [DataRow("SaintManu")] // This attribute provides a data row for the test method with the specified username
    [DataRow("JohnDoe99")] // This attribute provides another data row for the test method with the specified username
    [DataRow("JaneDoe99")] // This attribute provides yet another data row for the test method with the specified username
    public void CheckIfUsernameIsInCorrectFormat_ShouldReturnTrue(string username)
    {
        // Arrange
        var testDummy = new RegistrationServiceManager(); // Creating an instance of RegistrationServiceManager for testing
        var newUser = new User(username, "!abcd1234", "test@email.com"); // Creating a new user with the specified username, password, and email

        // Act
        string message = testDummy.AddUser(newUser); // Calling the AddUser method of the RegistrationServiceManager with the new user

        // Assert
        Assert.AreEqual($"{newUser.Username} added successfully", message); // Checking if the message returned is as expected
        Assert.IsTrue(testDummy.UserList.Contains(newUser)); // Checking if the new user is added to the UserList of the RegistrationServiceManager
    }

    [TestMethod] // This attribute indicates that the following method is a test method
    [DataRow("!SaintManu")] // This attribute provides a data row for the test method with the specified username
    [DataRow("?JohnDoe99")] // This attribute provides another data row for the test method with the specified username
    [DataRow("+JaneDoe99")] // This attribute provides yet another data row for the test method with the specified username
    public void CheckIfUsernameContainsSpecialCharacter_ShouldReturnFalse(string username)
    {
        // Arrange
        var testDummy = new RegistrationServiceManager(); // Creating an instance of RegistrationServiceManager for testing
        var newUser = new User(username, "!abcd1234", "test@email.com"); // Creating a new user with the specified username, password, and email

        // Act and Assert
        Assert.ThrowsException<ArgumentException>(() => testDummy.AddUser(newUser), $"Username must be between 5 and 20 alphanumeric characters long"); // Checking if adding the new user with a special character in the username throws an ArgumentException with the specified message
    }

    // This test method checks if the username is too short and should return false
    [TestMethod]
    [DataRow("Manu")]
    [DataRow("Doe9")]
    [DataRow("Eh9")]
    public void CheckIfUsernameIsTooShort_ShouldReturnFalse(string username)
    {
        // Arrange
        var testDummy = new RegistrationServiceManager(); // Creating an instance of the RegistrationServiceManager
        var newUser = new User(username, "!abcd1234", "test@email.com"); // Creating a new User object with the provided username, password, and email

        // Act and Assert
        Assert.ThrowsException<ArgumentException>(() => testDummy.AddUser(newUser), $"Username must be between 5 and 20 alphanumeric characters long"); // Verifying that adding the user with the given username throws an ArgumentException with the specified message
    }

    // This test method checks if the username is too long and should return false
    [TestMethod]
    [DataRow("SaintManuSaintManuSaintManu")]
    [DataRow("JohnDoeJohnDoeJohnDoe99")]
    [DataRow("JaneDoeJaneDoeJaneDoe99")]
    public void CheckIfUsernameIsTooLong_ShouldReturnFalse(string username)
    {
        // Arrange
        var testDummy = new RegistrationServiceManager(); // Creating an instance of the RegistrationServiceManager
        var newUser = new User(username, "!abcd1234", "test@email.com"); // Creating a new User object with the provided username, password, and email

        // Act and Assert
        Assert.ThrowsException<ArgumentException>(() => testDummy.AddUser(newUser), $"Username must be between 5 and 20 alphanumeric characters long"); // Verifying that adding the user with the given username throws an ArgumentException with the specified message
    }

    // This test method checks if the username is unique and should return true
    [TestMethod]
    [DataRow("SaintManu")]
    [DataRow("JohnDoe99")]
    [DataRow("AliceSmith")]
    public void CheckIfUsernameIsUnique_ShouldReturnTrue(string username)
    {
        // Arrange
        var testDummy = new RegistrationServiceManager();
        testDummy.UserList.Add(new User("jane_doe", "123!@#987", "saintmanu@email.com"));

        // Act
        bool isUnique = testDummy.CheckUsernameUnique(username);

        // Assert
        Assert.IsTrue(isUnique);
    }

    // This test method checks if the username is taken and should return false
    [TestMethod]
    public void CheckIfUsernameIsTaken_ShouldReturnFalse()
    {
        // Arrange
        var testDummy = new RegistrationServiceManager();
        var newUser = new User("SaintManu", "!abcd1234", "test@email.com");
        testDummy.AddUser(newUser);

        // Act and Assert
        Assert.ThrowsException<ArgumentException>(() => testDummy.AddUser(newUser), $"{newUser.Username} already exists");
    }
}