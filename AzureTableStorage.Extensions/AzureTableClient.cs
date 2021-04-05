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
    internal class AzureTableClient : IDisposable, IAzureTableClient
    {
        private AzureTableClientOptions _azureTableClientOptions;
        private CloudStorageAccount _cloudStorageAccount;
        private CloudTableClient _cloudTableClient;

        public AzureTableClient(AzureTableClientOptions azureTableClientOptions)
        {
            _azureTableClientOptions = azureTableClientOptions;
            _cloudStorageAccount = CreateStorageAccountFromConnectionString(azureTableClientOptions.AzureTableConnectionString);
            _cloudTableClient = _cloudStorageAccount.CreateCloudTableClient(azureTableClientOptions);
        }

        public CloudTable CreateIfNotExists(string tableName,
                                                TableRequestOptions tableRequestOptions = null,
                                                OperationContext operationContext = null,
                                                string serializedIndexingPolicy = null,
                                                int? throughPut = null,
                                                int? defaultTimeToLive = null)
        {
            if (string.IsNullOrEmpty(tableName))
                throw new ArgumentNullException("tableName", "tableName can not be null  or empty");
            CloudTable cloudTable;
            cloudTable = _cloudTableClient.GetTableReference(tableName);
            cloudTable.CreateIfNotExists(tableRequestOptions, operationContext, serializedIndexingPolicy, throughPut, defaultTimeToLive);
            return cloudTable;
        }

        public CloudTable CreateIfNotExists(string tableName)
        {
            if (string.IsNullOrEmpty(tableName))
                throw new ArgumentNullException("tableName", "tableName can not be null  or empty");
            CloudTable cloudTable;
            cloudTable = _cloudTableClient.GetTableReference(tableName);
            cloudTable.CreateIfNotExists();
            return cloudTable;
        }

        public CloudTable CreateIfNotExists(string tableName,
                                               IndexingMode indexingMode,
                                               int? throughput = null,
                                               int? defaultTimeToLive = null)
        {
            if (string.IsNullOrEmpty(tableName))
                throw new ArgumentNullException("tableName", "tableName can not be null  or empty");
            CloudTable cloudTable;
            cloudTable = _cloudTableClient.GetTableReference(tableName);
            cloudTable.CreateIfNotExists(indexingMode, throughput, defaultTimeToLive);
            return cloudTable;
        }

        public async Task<CloudTable> CreateIfNotExistsAsync(string tableName,
                                                CancellationToken cancellationToken,
                                                TableRequestOptions tableRequestOptions = null,
                                                OperationContext operationContext = null,
                                                string serializedIndexingPolicy = null,
                                                int? throughPut = null,
                                                int? defaultTimeToLive = null)
        {
            if (string.IsNullOrEmpty(tableName))
                throw new ArgumentNullException("tableName", "tableName can not be null  or empty");
            CloudTable cloudTable;
            cloudTable = _cloudTableClient.GetTableReference(tableName);
            await cloudTable.CreateIfNotExistsAsync(tableRequestOptions, operationContext, serializedIndexingPolicy, throughPut, defaultTimeToLive, cancellationToken);
            return cloudTable;
        }

        public async Task<CloudTable> CreateIfNotExistsAsync(string tableName,
                                               CancellationToken cancellationToken,
                                               IndexingMode indexingMode,
                                               int? throughput = null,
                                               int? defaultTimeToLive = null)
        {
            if (string.IsNullOrEmpty(tableName))
                throw new ArgumentNullException("tableName", "tableName can not be null  or empty");
            CloudTable cloudTable;
            cloudTable = _cloudTableClient.GetTableReference(tableName);
            await cloudTable.CreateIfNotExistsAsync(indexingMode, throughput, defaultTimeToLive, cancellationToken);
            return cloudTable;
        }

        public async Task<CloudTable> CreateIfNotExistsAsync(string tableName)
        {
            if (string.IsNullOrEmpty(tableName))
                throw new ArgumentNullException("tableName", "tableName can not be null  or empty");
            CloudTable cloudTable;
            cloudTable = _cloudTableClient.GetTableReference(tableName);
            await cloudTable.CreateIfNotExistsAsync();
            return cloudTable;
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

        private void Dispose(bool isDispose)
        {
            if (isDispose)
            {
                _cloudStorageAccount = null;
                _azureTableClientOptions = null;
                _cloudTableClient = null;
            }
        }

        private CloudStorageAccount CreateStorageAccountFromConnectionString(string azureTableConnectionString)
        {
            if (string.IsNullOrEmpty(azureTableConnectionString))
                throw new ArgumentNullException("azureTableConnectionString", "azureTableConnectionString can not be blank");

            CloudStorageAccount cloudStorageAccount;
            try
            {
                cloudStorageAccount = CloudStorageAccount.Parse(azureTableConnectionString);
            }
            catch (FormatException)
            {
                throw;
            }
            catch (ArgumentException)
            {
                throw;
            }

            return cloudStorageAccount;

        }
    }
}
