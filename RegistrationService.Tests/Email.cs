[TestClass]
public class TestEmail
{
    [TestMethod]
    [DataRow("user@example.com")]
    [DataRow("john.doe@example.com")]
    [DataRow("jane.smith@example.com")]
    public void CheckIfEmailIsInCorrectFormat_ShouldReturnTrue(string email)
    {
        // Arrange
        var testDummy = new RegistrationServiceManager();
        var newUser = new User("SaintManu", "!abcd1234", email);

        // Act
        string message = testDummy.AddUser(newUser);

        // Assert
        Assert.AreEqual($"{newUser.Username} added successfully", message);
        Assert.IsTrue(testDummy.UserList.Contains(newUser));
    }

    [TestMethod]
    [DataRow("userexample.com")]
    [DataRow("john.doeexample.com")]
    [DataRow("jane.smith@com")]
    public void CheckIfEmailIsInCorrectFormat_ShouldReturnFalse(string email)
    {
        // Arrange
        var testDummy = new RegistrationServiceManager();
        var newUser = new User("SaintManu", "!abcd1234", email);

        // Act and assert
        Assert.ThrowsException<ArgumentException>(() => testDummy.AddUser(newUser), $"Email format is invalid");
    }
}