using CollegeManagement.Helper.Mapper;
using CollegeManagement.Models.Domains.Academics;
using CollegeManagement.Models.ViewModels;

namespace CollegeManagement.Tests
{
    public class DepartmentMapperTests
    {
        [Fact]
        public void ToViewModel_WhenGivenDepartment_ShouldMapAllFields()
        {
            var department = new Department
            {
                Id = 7,
                Name = "Computer Science",
                Description = "Handles CS courses"
            };

            var result = DepartmentMapper.ToViewModel(department);

            Assert.Equal(7, result.DepartmentId);
            Assert.Equal("Computer Science", result.Name);
            Assert.Equal("Handles CS courses", result.Description);
        }

        [Fact]
        public void ToDomainModel_WhenGivenViewModel_ShouldMapAllFields()
        {
            var model = new DepartmentViewModel
            {
                DepartmentId = 4,
                Name = "Mathematics",
                Description = "Math department"
            };

            var result = DepartmentMapper.ToDomainModel(model);

            Assert.Equal(4, result.Id);
            Assert.Equal("Mathematics", result.Name);
            Assert.Equal("Math department", result.Description);
        }

        [Fact]
        public void UpdateDomainModel_WhenGivenExistingDepartment_ShouldUpdateMutableFields()
        {
            var department = new Department
            {
                Id = 10,
                Name = "Old Name",
                Description = "Old description"
            };

            var model = new DepartmentViewModel
            {
                DepartmentId = 10,
                Name = "New Name",
                Description = "New description"
            };

            DepartmentMapper.UpdateDomainModel(department, model);

            Assert.Equal(10, department.Id);
            Assert.Equal("New Name", department.Name);
            Assert.Equal("New description", department.Description);
        }
    }
}


//Unit Test cases for Authentication
//......

//Unit Test cases for Department/Event Flow

//AppDbContext [Hard to test]
//Repo [Hard to test]
//Service [To Test]
//Mapper [Tested]
//Razor Component [To test]

//Unit Test Cases for Courses/Venue Flow

//....