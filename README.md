# AzureTableStorage.Extensions
Easily Pluggable Extension for Azure Table Storage

#To Use This package
1. Configure Your Azure Table Storage Service in Startup.cs as below,

            services.AddTableStorageServices(options =>
            {
                options.AzureTableConnectionString = Configuration.GetConnectionString("AzureTableStorage");
            });
            
 2. Then Inject the IAzureTableClient in constructor of the classes where it is required as below,
 
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IAzureTableClient _azureTableClient;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IAzureTableClient azureTableClient)
        {
            _logger = logger;
            _azureTableClient = azureTableClient;
        }
        
3. Now create a Cloud Table and start using it in your classes.
    
        var cloudtable = _azureTableClient.CreateIfNotExists("TestEntities"); //TestEntities is the table name
        
4. There are few extension method to help in InsertOrMerge, Retrieve and Delete of Entities in cloud table.
            
            //for insert or merge, Async version is also available
            cloudtable.InsertOrMergeEntity<TestEntity>(testEntity);// Create a Entity type by implementing TableEntity of Microsoft.Azure.Cosmos.Table
            
            //Retrive an entity from Cloud Table
            var cloudTableEntity = cloudtable.RetrieveEntityUsingPointQuery<TestEntity>("partitionkey", "rowkey");

            //Delete an wntity from cloud table
            cloudtable.DeleteEntity(testEntity);// Create a Entity type by implementing TableEntity of Microsoft.Azure.Cosmos.Table
