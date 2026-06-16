using Bunit;
using Microsoft.Extensions.DependencyInjection;
using CollegeManagement.Models.ViewModels;
using CollegeManagement.Services;
using CollegeManagement.Components.ManageDepartment;

namespace CollegeManagement.Tests.Components;

public class DepartmentTableTests : BunitContext
{
    [Fact]
    public void DepartmentTable_WhenDepartmentsExist_ShouldRenderRows()
    {
        // Arrange
        Services.AddSingleton<IDepartmentService>(
            new FakeDepartmentService()
        );
        // Act
        var cut = Render<DepartmentTable>();
        // Assert
        cut.WaitForAssertion(() =>
        {
            Assert.Contains("IT", cut.Markup);
            Assert.Contains("Information Technology", cut.Markup);
            Assert.Contains("HR", cut.Markup);
            Assert.Contains("Human Resource", cut.Markup);

            var rows = cut.FindAll("tbody tr");
            Assert.Equal(2, rows.Count);
        });
    }

 }

public class FakeDepartmentService : IDepartmentService
{
    public Task<List<DepartmentViewModel>> GetAllAsync()
    {
        return Task.FromResult(new List<DepartmentViewModel>
        {
            new()
            {
                DepartmentId = 1,
                Name = "IT",
                Description = "Information Technology"
            },
            new()
            {
                DepartmentId = 2,
                Name = "HR",
                Description = "Human Resource"
            }
        });
    }

    public Task CreateAsync(DepartmentViewModel model)
        => Task.CompletedTask;

    public Task UpdateAsync(DepartmentViewModel model)
        => Task.CompletedTask;

    public Task DeleteAsync(int id)
        => Task.CompletedTask;

    public Task<DepartmentViewModel> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(DepartmentViewModel model)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(DepartmentViewModel model)
    {
        throw new NotImplementedException();
    }
}
