namespace Entities.Exceptions
{
    public class EmployeeNotFoundException : NotFoundException
    {
        public EmployeeNotFoundException(Guid employeeId) : base($"the employee with id {employeeId} Not Found")
        {
        }
    }
}
