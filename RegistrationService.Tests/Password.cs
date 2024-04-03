[TestClass]
public class TestPassword
{
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
        Assert.IsTrue(testDummy.UserList.Contains(newUser));
    }

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

    [TestMethod]
    [DataRow("!Manu")]
    [DataRow("?John")]
    [DataRow("=Jane")]
    public void CheckIfPasswordIsTooShort_ShouldReturnFalse(string password)
    {
        // Arrange
        var testDummy = new RegistrationServiceManager();
        var newUser = new User("SaintManu", password, "test@email.com");

        // Act and Assert
        Assert.ThrowsException<ArgumentException>(() => testDummy.AddUser(newUser), $"Password should be at least 8 characters long and contain at least one number and one special character");
    }
}