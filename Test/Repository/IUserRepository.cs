using Test.Payload;
using Util.Paging;

namespace Test.Repository;

public interface IUserRepository
{
    User GetById(string id);
    Page<User> GetUserListPage(int size, int page);
}

public class UserRepository : IUserRepository
{
    private readonly List<User?> _lists = new()
    {
        new User
        {
            Id = "B",
            Name = "Anita",
            Family = "Bakhtiari"
        },
        new User
        {
            Id = "C",
            Name = "Ares",
            Family = "Ornil"
        },
        new User
        {
            Name = "Ares",
            Family = "Ornil"
        },
        new User
        {
            Name = "Ares",
            Family = "Ornil"
        },
        new User
        {
            Name = "Ares",
            Family = "Ornil"
        },
        new User
        {
            Name = "Ares",
            Family = "Ornil"
        },
        new User
        {
            Name = "Ares",
            Family = "Ornil"
        },
        new User
        {
            Name = "Ares",
            Family = "Ornil"
        },
        new User
        {
            Name = "Ares",
            Family = "Ornil"
        },
        new User
        {
            Id = "1",
            Name = "Ares",
            Family = "Ornil"
        },
        new User
        {
            Id = "1",
            Name = "Ares",
            Family = "Ornil"
        },
        new User
        {
            Id = "1",
            Name = "Ares",
            Family = "Ornil"
        }
    };

    public User GetById(string id)
    {
        return _lists.FirstOrDefault(a => a != null && a.Id == id)!;
    }

    public Page<User> GetUserListPage(int size, int page)
    {
        return _lists.AsQueryable().OrderByDescending(a => a.Family).ToPageList(page, size);
    }

    public User GetByIdName(string id, string name)
    {
        return _lists.FirstOrDefault(a => a != null && a.Id == id && a.Name == name)!;
    }
}