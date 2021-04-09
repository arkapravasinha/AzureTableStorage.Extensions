using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Table;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AzureTableStorage.Extensions
{
    /// <summary>
    /// Use to create CloudTable
    /// </summary>
    sealed class AzureTableClient : IDisposable, IAzureTableClient
    {
        private CloudTableClient _cloudTableClient;

        public AzureTableClient(AzureTableClientOptions azureTableClientOptions)
        {
            _cloudTableClient = CreateStorageAccountFromConnectionString(azureTableClientOptions.AzureTableConnectionString)
                                    .CreateCloudTableClient(azureTableClientOptions);
        }

        public CloudTable CreateIfNotExists(string tableName,
                                                TableRequestOptions tableRequestOptions,
                                                OperationContext operationContext = null,
                                                string serializedIndexingPolicy = null,
                                                int? throughPut = null,
                                                int? defaultTimeToLive = null)
        {
            if (string.IsNullOrEmpty(tableName))
                throw new ArgumentNullException(nameof(tableName), "tableName can not be null  or empty");

            CloudTable cloudTable = _cloudTableClient.GetTableReference(tableName);
            cloudTable.CreateIfNotExists(tableRequestOptions, operationContext, serializedIndexingPolicy, throughPut, defaultTimeToLive);
            return cloudTable;
        }

        public CloudTable CreateIfNotExists(string tableName)
        {
            if (string.IsNullOrEmpty(tableName))
                throw new ArgumentNullException(nameof(tableName), "tableName can not be null  or empty");

            CloudTable cloudTable = _cloudTableClient.GetTableReference(tableName);
            cloudTable.CreateIfNotExists();
            return cloudTable;
        }

        public CloudTable CreateIfNotExists(string tableName,
                                               IndexingMode indexingMode,
                                               int? throughput = null,
                                               int? defaultTimeToLive = null)
        {
            if (string.IsNullOrEmpty(tableName))
                throw new ArgumentNullException(nameof(tableName), "tableName can not be null  or empty");

            CloudTable cloudTable = _cloudTableClient.GetTableReference(tableName);
            cloudTable.CreateIfNotExists(indexingMode, throughput, defaultTimeToLive);
            return cloudTable;
        }

        public Task<CloudTable> CreateIfNotExistsAsync(string tableName,
                                                CancellationToken cancellationToken,
                                                TableRequestOptions tableRequestOptions = null,
                                                OperationContext operationContext = null,
                                                string serializedIndexingPolicy = null,
                                                int? throughPut = null,
                                                int? defaultTimeToLive = null)
        {
            if (string.IsNullOrEmpty(tableName))
                throw new ArgumentNullException(nameof(tableName), "tableName can not be null  or empty");

            return CreateTableAsync(tableName, tableRequestOptions, operationContext, serializedIndexingPolicy, throughPut, defaultTimeToLive, cancellationToken);
        }

        public Task<CloudTable> CreateIfNotExistsAsync(string tableName,
                                               IndexingMode indexingMode,
                                               CancellationToken cancellationToken,
                                               int? throughput = null,
                                               int? defaultTimeToLive = null)
        {
            if (string.IsNullOrEmpty(tableName))
                throw new ArgumentNullException(nameof(tableName), "tableName can not be null  or empty");

            return CreateTableAync(tableName, indexingMode, throughput, defaultTimeToLive, cancellationToken);
        }        

        public Task<CloudTable> CreateIfNotExistsAsync(string tableName)
        {
            if (string.IsNullOrEmpty(tableName))
                throw new ArgumentNullException(nameof(tableName), "tableName can not be null  or empty");
            return CreateTableAsync(tableName);
        }

        public void Dispose()
        {
            try
            {
                Dispose(true);
            }
            catch (Exception)
            {
                //Do nothing
            }
        }

        private async Task<CloudTable> CreateTableAsync(string tableName)
        {
            CloudTable cloudTable = _cloudTableClient.GetTableReference(tableName);
            await cloudTable.CreateIfNotExistsAsync();
            return cloudTable;
        }
        private async Task<CloudTable> CreateTableAsync(string tableName, TableRequestOptions tableRequestOptions, OperationContext operationContext, string serializedIndexingPolicy, int? throughPut, int? defaultTimeToLive, CancellationToken cancellationToken)
        {
            CloudTable cloudTable = _cloudTableClient.GetTableReference(tableName);
            await cloudTable.CreateIfNotExistsAsync(tableRequestOptions, operationContext, serializedIndexingPolicy, throughPut, defaultTimeToLive, cancellationToken);
            return cloudTable;
        }
        private async Task<CloudTable> CreateTableAync(string tableName, IndexingMode indexingMode, int? throughput, int? defaultTimeToLive, CancellationToken cancellationToken)
        {
            CloudTable cloudTable = _cloudTableClient.GetTableReference(tableName);
            await cloudTable.CreateIfNotExistsAsync(indexingMode, throughput, defaultTimeToLive, cancellationToken);
            return cloudTable;
        }
        private void Dispose(bool isDispose)
        {
            if (isDispose)
            {
                _cloudTableClient = null;
            }
        }

        private static CloudStorageAccount CreateStorageAccountFromConnectionString(string azureTableConnectionString)
        {
            if (string.IsNullOrEmpty(azureTableConnectionString))
                throw new ArgumentNullException(nameof(azureTableConnectionString), "azureTableConnectionString can not be blank");

            CloudStorageAccount cloudStorageAccount;
            
            cloudStorageAccount = CloudStorageAccount.Parse(azureTableConnectionString);

            return cloudStorageAccount;

        }
    }
}
