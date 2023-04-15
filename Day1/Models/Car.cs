using Microsoft.VisualBasic;
using WebApplication2.Validations;

namespace WebApplication2.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string name { get; set; }="";
        public string model { get; set; } = "";

        public string type { get; set; } = "";

        [DateMustBeInPastAttribute]
        public DateTime ProductionDate { get; set; } 
    }
}
