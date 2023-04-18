
using System.Numerics;

namespace Day2.DAL;

public interface IDepartmentsRepo
{
    List<Department> GetAll();
    IEnumerable<Department> GetAllAsReadOnly();
    Department? GetById(int id);
    void Add(Department entity);
    void Update(Department entity);
    void Delete(Department entity);
    void SaveChanges(Department entity);


    Department? GetWithTicketsAndDevelopersById(int id);
}
