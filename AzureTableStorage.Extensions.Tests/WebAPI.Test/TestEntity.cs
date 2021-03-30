using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Test
{
    public class TestEntity: TableEntity
    {
        public TestEntity()
        {

        }

        public TestEntity(string lastName,string emailId)
        {
            RowKey = emailId;
            PartitionKey = lastName;
        }

        public int Id { get; set; }

        public int MobileNumber { get; set; }
    }
}
