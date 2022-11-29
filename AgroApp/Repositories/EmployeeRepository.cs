using AgroApp.Data;
using AgroApp.Models;
using Microsoft.AspNetCore.Identity;

namespace AgroApp.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<UserModel> _userManager;

        public EmployeeRepository(ApplicationDbContext context, UserManager<UserModel> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public EmployeeModel GetEmployeeById(int employeeId)
        {
           return _context.Employees.FirstOrDefault(x => x.EmployeeId == employeeId);
        }

        public IEnumerable<EmployeeModel> GetEmployees()
        {
            return _context.Employees;
        }

        public  IEnumerable<UserModel> GetEmployeesByFarmId(int farmId)
        {
            List<UserModel> employees = new();
            foreach(UserModel employee in _userManager.Users)
            {
                if(employee.FarmId == farmId)
                {
                    
                    employees.Add(employee);
                }
            }

            return employees;

            
        }

        public void AddEmployee(EmployeeModel employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public void DeleteEmployee(int employeeId)
        {
            var result = _context.Employees.FirstOrDefault(x=> x.EmployeeId == employeeId);
            
            if (result != null)
            {
                _context.Remove(result);
            }
            _context.SaveChanges();
        }

        public void UpdateEmployee(int employeeId, EmployeeModel employee)
        {
            var result = _context.Employees.FirstOrDefault(x => x.EmployeeId == employeeId);

            if(result != null)
            {
                result.EmployeeName = employee.EmployeeName;
                result.EmployeeSurname = employee.EmployeeSurname;
                result.EmployeeAge = employee.EmployeeAge;
                result.EmployeePosition = employee.EmployeePosition;
                result.EmployeeStatus = employee.EmployeeStatus;
            }
            _context.SaveChanges();
        }
    }
}
