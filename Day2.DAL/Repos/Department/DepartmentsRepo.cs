
using Microsoft.EntityFrameworkCore;

namespace Day2.DAL;

public class DepartmentsRepo : IDepartmentsRepo
{
    private CompanyContext _context;

    public DepartmentsRepo(CompanyContext context)
    {
        _context = context;
    }

    public void Add(Department entity)
    {
        _context.Add(entity);
    }

    public void Delete(Department entity)
    {
        _context.Remove(entity);
    }

    public IEnumerable<Department> GetAll()
    {
        return _context.Set<Department>();
    }

    public IEnumerable<Department> GetAllAsReadOnly()
    {
        return _context.Set<Department>().AsNoTracking();

    }

    public Department? GetById(int id)
    {
        return _context.Set<Department>().Find(id);
    }

    public Department? GetWithTicketsAndDevelopersById(int id)
    {
        return _context.Set<Department>().Include(d=>d.Tickets).ThenInclude(t=>t.Developers).FirstOrDefault(d=>d.Id==id);
    }

    public void SaveChanges(Department entity)
    {
        _context.SaveChanges();
    }

    public void Update(Department entity)
    {
       
    }
}

