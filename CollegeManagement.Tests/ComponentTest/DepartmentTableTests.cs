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

        var departments = new List<DepartmentViewModel>
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
};
        var cut = Render<DepartmentTable>(parameters => parameters
            .Add(p => p.Departmentss, departments)
        );
        //var cut = Render<DepartmentTable>();

        Console.WriteLine( cut );
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


    public Task DeleteAsync(DepartmentViewModel model)
    {
        throw new NotImplementedException();
    }

 

    public Task<DepartmentViewModel> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(DepartmentViewModel model)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(DepartmentViewModel model)
    {
        throw new NotImplementedException();
    }
}

/*dotnet add package bunit
dotnet add package Microsoft.NET.Test.Sdk
dotnet add package xunit
dotnet add package xunit.runner.visualstudio*/