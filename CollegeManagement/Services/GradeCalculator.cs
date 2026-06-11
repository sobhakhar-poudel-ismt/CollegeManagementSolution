namespace CollegeManagement.Services
{
    public class GradeCalculator
    {
        public string GetGrade(int marks)
        {
            if (marks < 0 || marks > 100)
                throw new ArgumentException("Marks must be between 0 and 100.");

            if (marks >= 80) return "Distinction";
            if (marks >= 60) return "First Division";
            if (marks >= 40) return "Pass";

            return "Fail";
        }
    }
}
