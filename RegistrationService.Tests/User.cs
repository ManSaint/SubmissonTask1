[TestClass]
public class TestUser
{
    [TestMethod]
    public void CheckIfAbleToAddUser_ShouldReturnTrue()
    {
        // Arrange
        var testDummy = new RegistrationServiceManager();
        var newUser = new User("SaintManu", "!abcd1234", "test@email.com");

        // Act
        string message = testDummy.AddUser(newUser);

        // Assert
        Assert.AreEqual($"{newUser.Username} added successfully", message);
        Assert.IsTrue(testDummy.UserList.Contains(newUser));
    }
}