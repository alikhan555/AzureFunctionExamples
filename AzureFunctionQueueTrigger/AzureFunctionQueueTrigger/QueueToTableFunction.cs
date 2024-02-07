using AzureBlobService;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace AzureFunctionQueueTrigger
{
    public class QueueToTableFunction
    {
        private readonly ILogger _logger;

        public QueueToTableFunction(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<QueueToTableFunction>();
        }

        [Function("QueueToTableFunc")]
        [TableOutput("Employees", Connection = "storageAccountConnectionString")]
        public Employee Run([QueueTrigger("dotnet-queue", Connection = "storageAccountConnectionString")] Employee myQueueEmployee)
        {
            _logger.LogInformation($"C# Queue trigger function processed: {myQueueEmployee.RowKey}");

            return myQueueEmployee;
        }
    }
}
