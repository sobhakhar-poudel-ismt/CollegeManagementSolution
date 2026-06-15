using CollegeManagement.Exceptions;
using CollegeManagement.Models.Domains.Academics;
using CollegeManagement.Models.ViewModels;
using CollegeManagement.Services;
using CollegeManagement.Tests.MocksRepo;
using Xunit;
namespace CollegeManagement.Tests
{
    public class DepartmentServiceTests
    {
        [Fact]
        public async Task GetAllAsync_WhenDepartmentsExist_ShouldMapToViewModels()
        {
            var repo = new MockDepartmentRepository();
            repo.SeedDepartments(
                new Department { Id = 1, Name = "IT", Description = "Information Technology" },
                new Department { Id = 2, Name = "HR", Description = "Human Resources" }
            );
            var service = new DepartmentService(repo);

            var result = await service.GetAllAsync();

            Assert.Equal(2, result.Count);
            Assert.Equal(1, result[0].DepartmentId);
            Assert.Equal("IT", result[0].Name);
            Assert.Equal("Information Technology", result[0].Description);
            Assert.Equal(2, result[1].DepartmentId);
            Assert.Equal("HR", result[1].Name);
            Assert.Equal("Human Resources", result[1].Description);
        }

        [Fact]
        public async Task AddAsync_WhenDepartmentNameDoesNotExist_ShouldAddDepartment()
        {
            var repo = new MockDepartmentRepository();
            var service = new DepartmentService(repo);
            var model = new DepartmentViewModel
            {
                DepartmentId = 0,
                Name = "Science",
                Description = "Science department"
            };

            await service.AddAsync(model);

            Assert.Equal(1, repo.AddCallCount);
            Assert.NotNull(repo.LastAddedDepartment);
            Assert.Equal("Science", repo.LastAddedDepartment!.Name);
            Assert.Equal("Science department", repo.LastAddedDepartment.Description);
        }

        [Fact]
        public async Task AddAsync_WhenDepartmentNameAlreadyExists_ShouldThrowDuplicateDepartmentException()
        {
            var repo = new MockDepartmentRepository();
            repo.SeedDepartments(new Department { Id = 1, Name = "Science", Description = "Existing" });
            var service = new DepartmentService(repo);
            var model = new DepartmentViewModel
            {
                DepartmentId = 0,
                Name = "Science",
                Description = "Duplicate department"
            };

            var ex = await Assert.ThrowsAsync<DuplicateDepartmentException>(() => service.AddAsync(model));

            Assert.Equal(0, repo.AddCallCount);
        }

        [Fact]
        public async Task DeleteAsync_ShouldRemoveDepartment()
        {
            var repo = new MockDepartmentRepository();
            repo.SeedDepartments(new Department { Id = 5, Name = "Commerce", Description = "Commerce dept" });
            var service = new DepartmentService(repo);
            var model = new DepartmentViewModel
            {
                DepartmentId = 5,
                Name = "Commerce",
                Description = "Commerce dept"
            };

            await service.DeleteAsync(model);

            Assert.Equal(1, repo.DeleteCallCount);
            Assert.Null(await repo.GetByIdAsync(5));
        }
    }
}
