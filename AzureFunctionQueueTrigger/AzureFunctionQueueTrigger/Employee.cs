﻿using Azure;

namespace AzureBlobService
{
    public class Employee
    {
        public string RowKey { get; set; }          // EmployeeId
        public string PartitionKey { get; set; }    // Designation
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public decimal Experience { get; set; }
        public float Salary { get; set; }
    }
}
