using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Table;
using System.Threading;
using System.Threading.Tasks;

namespace AzureTableStorage.Extensions
{
    public interface IAzureTableClient
    {
        /// <summary>
        /// Create a Cloud Table if does not exist, otherwise returns the one already presented
        /// </summary>
        /// <param name="tableName" >Use to Create Table</param>
        /// <returns>CloudTable</returns>
        CloudTable CreateIfNotExists(string tableName);

        /// <summary>
        /// Create a Cloud Table if does not exist, otherwise returns the one already presented
        /// </summary>
        /// <param name="tableName">Use to Create Table, required, string</param>
        /// <param name="tableRequestOptions">Table Request options, optional</param>
        /// <param name="operationContext">Operation Context, optional</param>
        /// <param name="serializedIndexingPolicy">Serialized Indexing policy, optional, string</param>
        /// <param name="throughPut">Indicates Throughput, optional, int</param>
        /// <param name="defaultTimeToLive">Default Time To live, optional, int</param>
        /// <returns>CloudTable</returns>
        CloudTable CreateIfNotExists(string tableName, TableRequestOptions tableRequestOptions = null, OperationContext operationContext = null, string serializedIndexingPolicy = null, int? throughPut = null, int? defaultTimeToLive = null);

        /// <summary>
        /// Create a Cloud Table if does not exist, otherwise returns the one already presented
        /// </summary>
        /// <param name="tableName">Use to Create Table, required, string</param>
        /// <param name="indexingMode">Indexing Mode, required, enum</param>
        /// <param name="throughput">Indicates Throughput, optional, int</param>
        /// <param name="defaultTimeToLive">Default Time To live, optional, int</param>
        /// <returns>CloudTable</returns>
        CloudTable CreateIfNotExists(string tableName, IndexingMode indexingMode, int? throughput = null, int? defaultTimeToLive = null);

        /// <summary>
        /// Asynchornously Create a Cloud Table if does not exist, otherwise returns the one already presented
        /// </summary>
        /// <param name="tableName">Use to Create Table</param>
        /// <returns>CloudTable</returns>
        Task<CloudTable> CreateIfNotExistsAsync(string tableName);

        /// <summary>
        /// Asynchornously Create a Cloud Table if does not exist, otherwise returns the one already presented
        /// </summary>
        /// <param name="tableName">Use to Create Table</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <param name="tableRequestOptions">Table Request options, optional</param>
        /// <param name="operationContext">Operation Context, optional</param>
        /// <param name="serializedIndexingPolicy">Serialized Indexing policy, optional, string</param>
        /// <param name="throughPut">Indicates Throughput, optional, int</param>
        /// <param name="defaultTimeToLive">Default Time To live, optional, int</param>
        /// <returns>CloudTable</returns>
        Task<CloudTable> CreateIfNotExistsAsync(string tableName, CancellationToken cancellationToken, TableRequestOptions tableRequestOptions = null, OperationContext operationContext = null, string serializedIndexingPolicy = null, int? throughPut = null, int? defaultTimeToLive = null);

        /// <summary>
        /// Asynchornously Create a Cloud Table if does not exist, otherwise returns the one already presented
        /// </summary>
        /// <param name="tableName">Use to Create Table</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <param name="indexingMode">Indexing Mode, required, enum</param>
        /// <param name="throughput">Indicates Throughput, optional, int</param>
        /// <param name="defaultTimeToLive">Default Time To live, optional, int</param>
        /// <returns>CloudTable</returns>
        Task<CloudTable> CreateIfNotExistsAsync(string tableName, CancellationToken cancellationToken, IndexingMode indexingMode, int? throughput = null, int? defaultTimeToLive = null);
    }
}