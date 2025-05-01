using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DTO;

namespace Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepositoryManger _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public EmployeeService(IRepositoryManger repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public EmployeeDto CreateEmployeeForCompany(Guid companyId, EmployeeForCreationDto employeeForCreation, bool trackChanges)
        {
            var company = _repository.Company.GetCompany(companyId, false);
            if (company == null)
            {
                throw new CompanyNotFoundException(companyId);
            }
            var employee = _mapper.Map<Employee>(employeeForCreation);
            _repository.Employee.CreateEmployeeForCompany(companyId, employee);
            _repository.Save();
            return _mapper.Map<EmployeeDto>(employee);
        }

        public void DeleteEmployeeForCompany(Guid companyId, Guid id, bool trackChanges)
        {
            var company = _repository.Company.GetCompany(companyId, false);
            if (company == null)
                throw new CompanyNotFoundException(companyId);
            var employee = _repository.Employee.GetEmployee(companyId, id, false);
            if (employee == null)
                throw new EmployeeNotFoundException(id);
            _repository.Employee.DeleteEmployee(employee);
            _repository.Save();

        }

        public EmployeeDto GetEmployee(Guid companyId, Guid id, bool trackChanges)
        {
            var company = _repository.Company.GetCompany(companyId, false);
            if (company is null)
            {
                throw new CompanyNotFoundException(companyId);
            }
            var employee = _repository.Employee.GetEmployee(companyId, id, trackChanges);
            if (employee is null)
                throw new EmployeeNotFoundException(id);
            return _mapper.Map<EmployeeDto>(employee);
        }

        public (EmployeeForUpdateDto employeeToPatch, Employee employeeEntity) GetEmployeeForPatch(Guid companyId, Guid id, bool compTrackChanges, bool empTrackChanges)
        {
            var company = _repository.Company.GetCompany(companyId, compTrackChanges);
            if (company is null)
                throw new CompanyNotFoundException(companyId);
            var employeeEntity = _repository.Employee.GetEmployee(companyId, id, empTrackChanges);
            if (employeeEntity is null)
                throw new EmployeeNotFoundException(companyId);
            var employeeToPatch = _mapper.Map<EmployeeForUpdateDto>(employeeEntity);
            return (employeeToPatch, employeeEntity);
        }

        public IEnumerable<EmployeeDto> GetEmployees(Guid companyId, bool trackChanges)
        {
            var company = _repository.Company.GetCompany(companyId, trackChanges);
            if (company is null)
                throw new CompanyNotFoundException(companyId);
            var employees = _repository.Employee.GetEmployees(companyId, trackChanges);

            return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
        }

        public void SaveChangesForPatch(EmployeeForUpdateDto employeeToPatch, Employee employeeEntity)
        {
            _mapper.Map(employeeToPatch, employeeEntity);
            _repository.Save();
        }

        public void UpdateEmployeeForCompany(Guid companyId, Guid id, EmployeeForUpdateDto employeeForUpdate, bool compTrackChanges, bool empTrackChanges)
        {
            var company = _repository.Company.GetCompany(companyId, compTrackChanges);
            if (company is null)
                throw new CompanyNotFoundException(companyId);
            var employee = _repository.Employee.GetEmployee(companyId, id, empTrackChanges);
            if (employee is null)
                throw new EmployeeNotFoundException(id);
            _mapper.Map(employeeForUpdate, employee);
            _repository.Save();
        }
    }
}
