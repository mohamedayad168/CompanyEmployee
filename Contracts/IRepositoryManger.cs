namespace Contracts
{
    public interface IRepositoryManger
    {
        ICompanyRepository Company { get; }
        IEmployeeRepository Employee { get; }

        void Save();
    }
}
