using System.ComponentModel.DataAnnotations;

namespace EmployeeWebPortal.Model
{
    public class EmployeeModel
    {
        [Key]
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
    }
}
