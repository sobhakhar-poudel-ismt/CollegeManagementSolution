using CollegeManagement.Data.Repositories;
using CollegeManagement.Models.Domains.Academics;

namespace CollegeManagement.Tests.MocksRepo
{
    public class MockDepartmentRepository : IDepartmentRepository
    {
        //Simlar to AppDBCOntext ko DBSet
        private readonly List<Department> _departments = new();

        public int AddCallCount { get; private set; }
        public int DeleteCallCount { get; private set; }
        public Department? LastAddedDepartment { get; private set; }
        public Department? LastDeletedDepartment { get; private set; }

        public List<Department> SeedDepartments(params Department[] departments)
        {
            _departments.Clear();
            _departments.AddRange(departments);
            return _departments;
        }

        public Task<List<Department>> GetAllAsync()
        {
            return Task.FromResult(_departments.ToList());
        }

        public Task<Department?> GetByIdAsync(int id)
        {
            var department = _departments.FirstOrDefault(x => x.Id == id);
            return Task.FromResult(department);
        }

        public Task<bool> ExistsByNameAsync(string name)
        {
            var exists = _departments.Any(x => x.Name.ToLower()==name.ToLower());
            return Task.FromResult(exists);
        }

        public Task AddAsync(Department department)
        {
            AddCallCount++;
            LastAddedDepartment = department;
            _departments.Add(department);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Department department)
        {
            var index = _departments.FindIndex(x => x.Id == department.Id);
            if (index >= 0)
            {
                _departments[index] = department;
            }

            return Task.CompletedTask;
        }

        public Task DeleteAsync(Department department)
        {
            DeleteCallCount++;
            LastDeletedDepartment = department;
            _departments.RemoveAll(x => x.Id == department.Id);
            return Task.CompletedTask;
        }
    }
}
