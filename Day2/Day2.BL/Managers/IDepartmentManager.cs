
using Day2.DAL;

namespace Day2.BL;
public interface IDepartmentManager
{
    DepartmentDetailReadDbo? GetDetail(int id);
    List<Department> Getall();
}
