using System.Diagnostics;
using DbLibrary.Data;
using Microsoft.EntityFrameworkCore;

namespace DbLibrary.Repositories;

public class GroupRepository
{
    AppDbContext _dbContext;

    public GroupRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Group>> GetAllGroupsWithPersonsAsync()
    {
        List<Group> groups = [];

        try
        {
            groups = await _dbContext.Groups.Include(g => g.Persons).ToListAsync();
        }
        catch (Exception)
        {
            // do nothing
        }

        foreach (var group in groups)
        {
            if (group.Persons != null)
            {
                foreach (var person in group.Persons)
                {
                    Debug.WriteLine($"{person.Id} {person.FirstName} {person.LastName}");
                }
            }
        }
        
        return groups;
    }
}