using AgroApp.Models;

namespace AgroApp.Repositories
{
    public interface IEmployeeRepository
    {
        EmployeeModel GetEmployeeById(int employeeId);
        IEnumerable<EmployeeModel> GetEmployees();
        IEnumerable<UserModel> GetEmployeesByFarmId(int farmId);
        void AddEmployee(EmployeeModel employee);
        void UpdateEmployee(int employeeId, EmployeeModel employee);
        void DeleteEmployee(int employeeId);
    }
}
