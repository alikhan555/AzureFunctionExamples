using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace AzureCosmosDbTrigger
{
    public class Function1
    {
        private readonly ILogger _logger;

        public Function1(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Function1>();
        }

        [Function("DetectCosmosDbChange")]
        public void Run([CosmosDBTrigger(
            databaseName: "HR",
            collectionName: "Employees",
            ConnectionStringSetting = "cosmosDbConnectionString",
            LeaseCollectionName = "leases", CreateLeaseCollectionIfNotExists = true)] IReadOnlyList<EmployeeModel> employees)
        {
            if (employees != null && employees.Count > 0)
            {
                foreach (EmployeeModel employee in employees)
                {
                    _logger.LogInformation("Employee id: " + employee.id);
                    _logger.LogInformation("Employee EmployeeId: " + employee.EmployeeId);
                    _logger.LogInformation("Employee Name: " + employee.Name);
                    _logger.LogInformation("Employee Designation: " + employee.Designation);
                    _logger.LogInformation("Employee Age: " + employee.Age);
                    _logger.LogInformation("Employee Experience: " + employee.Experience);
                    _logger.LogInformation("Employee Salary: " + employee.Salary);
                    _logger.LogInformation("END");
                }
            }
        }
    }

    public class EmployeeModel
    {
        public string id { get; set; }
        public string EmployeeId { get; set; }
        public string Designation { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public decimal Experience { get; set; }
        public float Salary { get; set; }
    }
}
