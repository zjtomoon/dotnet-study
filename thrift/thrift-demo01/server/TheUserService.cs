public class TheUserService:UserService.IAsync
{
    public Task<User> GetUserByID(int userID, CancellationToken cancellationToken = default)
    {
        User user = new User()
        {
            ID = 1, Name = "alex"
        };

        return Task.FromResult(user);

    }

    public Task<List<User>> GetAllUser(CancellationToken cancellationToken = default)
    {
        List<User> users = new List<User>(){
            new User() { ID = 1, Name = "alex" },
            new User() { ID = 2, Name = "alice" }
        };

        return Task.FromResult(users);
    }
}