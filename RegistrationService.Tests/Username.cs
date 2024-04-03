[TestClass]
public class TestUsername
{
    [TestMethod]
    [DataRow("SaintManu")]
    [DataRow("JohnDoe99")]
    [DataRow("JaneDoe99")]
    public void CheckIfUsernameIsInCorrectFormat_ShouldReturnTrue(string username)
    {
        // Arrange
        var testDummy = new RegistrationServiceManager();
        var newUser = new User(username, "!abcd1234", "test@email.com");

        // Act
        string message = testDummy.AddUser(newUser);

        // Assert
        Assert.AreEqual($"{newUser.Username} added successfully", message);
        Assert.IsTrue(testDummy.UserList.Contains(newUser));
    }

    [TestMethod]
    [DataRow("!SaintManu")]
    [DataRow("?JohnDoe99")]
    [DataRow("+JaneDoe99")]
    public void CheckIfUsernameContainsSpecialCharacter_ShouldReturnFalse(string username)
    {
        // Arrange
        var testDummy = new RegistrationServiceManager();
        var newUser = new User(username, "!abcd1234", "test@email.com");

        // Act and Assert
        Assert.ThrowsException<ArgumentException>(() => testDummy.AddUser(newUser), $"Username must be between 5 and 20 alphanumeric characters long");
    }

    [TestMethod]
    [DataRow("Manu")]
    [DataRow("Doe9")]
    [DataRow("Eh9")]
    public void CheckIfUsernameIsTooShort_ShouldReturnFalse(string username)
    {
        // Arrange
        var testDummy = new RegistrationServiceManager();
        var newUser = new User(username, "!abcd1234", "test@email.com");

        // Act and Assert
        Assert.ThrowsException<ArgumentException>(() => testDummy.AddUser(newUser), $"Username must be between 5 and 20 alphanumeric characters long");
    }

    [TestMethod]
    [DataRow("SaintManuSaintManuSaintManu")]
    [DataRow("JohnDoeJohnDoeJohnDoe99")]
    [DataRow("JaneDoeJaneDoeJaneDoe99")]
    public void CheckIfUsernameIsTooLong_ShouldReturnFalse(string username)
    {
        // Arrange
        var testDummy = new RegistrationServiceManager();
        var newUser = new User(username, "!abcd1234", "test@email.com");

        // Act and Assert
        Assert.ThrowsException<ArgumentException>(() => testDummy.AddUser(newUser), $"Username must be between 5 and 20 alphanumeric characters long");
    }

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