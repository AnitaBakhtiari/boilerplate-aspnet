using AutoMapper.QueryableExtensions;
using Test.Context;
using Test.Payload;
using Util.Paging;
using DataSql.Data.Repository;
using Microsoft.EntityFrameworkCore;


namespace Test.Repository;

public interface IContactRepository : IBaseRepository<Contact>
{
    ContactResponse GetById(int id);
    Task<Page<ContactResponse>> GetAllAsync(int size, int page);
}

public class ContactRepository :BaseRepository<Contact>, IContactRepository
{
    private readonly MyContext _context;

    public ContactRepository(MyContext context)
    {
        _context = context;
    }

    public ContactResponse GetById(int id)
    {
        return _context.Contacts.Where(a => a.Id == id).ProjectTo<ContactResponse>(mapper.ConfigurationProvider).FirstOrDefault()!;
    }

    public async Task<Page<ContactResponse>> GetAllAsync(int size, int page)
    {
     
        return await _context.Contacts.ProjectTo<ContactResponse>(mapper.ConfigurationProvider)
            .ToPageListAsync(page, size);
    }
}