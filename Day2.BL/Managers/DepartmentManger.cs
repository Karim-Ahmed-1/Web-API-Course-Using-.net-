

using Day2.DAL;

namespace Day2.BL;

public class DepartmentManger : IDepartmentManager
{
    private IDepartmentsRepo _departmentRepo;

    public DepartmentManger(IDepartmentsRepo departmentsRepo)
    {
        _departmentRepo = departmentsRepo;
    }

    public DepartmentDetailReadDbo? GetDetail(int id)
    {
        Department? DepartmentFromDB= _departmentRepo.GetWithTicketsAndDevelopersById(id);
        if(DepartmentFromDB == null)
        {
            return null;
        }
        return new DepartmentDetailReadDbo
        {
            Id = DepartmentFromDB.Id,
            Name = DepartmentFromDB.Name,
            Tickets = DepartmentFromDB.Tickets.Select(Ticket => new TicketChildReadDto
            {
                Id = Ticket.Id,
                Description = Ticket.Description,
                DevelopersCount = Ticket.Developers.Count
            }).ToList()
        };


    }


    public List<Department> Getall()
    {
        return _departmentRepo.GetAll();
    }
}
