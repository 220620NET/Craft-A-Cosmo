    [Fact]
    public async Task UpdateFailsWithInvalidUserID()
    {
        var mockedRepo = new Mock<IUserRepo>();
        User userToAdd = new()
        {
            UserId = 1,
            Username = "test",
            Password = "test",
            Email = "test@test.com",
            Role = "User"
        };
        User userToTest = new()
        {
            UserId = 2,
            Username = "test2",
            Password = "test",
            Email = "test@test.com",
            Role = "User"
        };
        mockedRepo.Setup(r => r.GetUserByUserId(userToAdd.UserId)).ReturnsAsync(userToAdd);
        AuthService auth = new(mockedRepo.Object);

        await Assert.ThrowsAsync<UserNotAvailableException>(() => auth.UpdateUser(userToTest));
    }
    /*
     *      Update Succeeds
     */
    // [Fact]
    // public async Task UpdateSucceedsWithVaildInformation()
    // {
    //     var mockedRepo = new Mock<IUserRepo>();

    //     User userToAdd = new()
    //     {
    //         UserId = 1,
    //         Username = "test",
    //         Password = "test",
    //         Email = "test@test.com",
    //         Role = "User"
    //     };

    //     User userToTest = new()
    //     {
    //         UserId = 1,
    //         Username = "test2",
    //         Password = "test2",
    //         Email = "test@test.com",
    //         Role = "User"
    //     };

    //     mockedRepo.Setup(r => r.GetUserByUserId(userToAdd.UserId)).ReturnsAsync(userToAdd);

    //     AuthService auth = new(mockedRepo.Object);

    //     User updatedUser = await auth.UpdateUser(userToTest);

    //     mockedRepo.Verify(r => r.GetUserByUserId(userToTest.UserId), Times.Once());

    //     Assert.NotNull(updatedUser);
    //     Assert.Equal(updatedUser.Username, userToTest.Username);
    //     Assert.Equal(updatedUser.Password, userToTest.Password);
    //     Assert.Equal(userToTest,updatedUser);
    // }
