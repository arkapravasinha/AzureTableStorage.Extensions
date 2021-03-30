using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureTableStorage.Extensions
{
    /// <summary>
    /// Azure Table Helper Extension Methods
    /// </summary>
    public static class AzureTableOperationHelper
    {
        /// <summary>
        /// Asynchronously Insert or Update an entity in Azure Table Storage
        /// </summary>
        /// <typeparam name="T">Parameter of Type TableEntity or ITableEntity</typeparam>
        /// <param name="table">CloudTable</param>
        /// <param name="entity">Type of TableEntity or ITableEntity</param>
        /// <returns>Parameter of Type TableEntity or ITableEntity</returns>
        /// <exception cref="ArgumentNullException">If Entity is null</exception>
        /// <exception cref="StorageException"></exception>
        /// <exception cref="Exception"></exception>
        public static async Task<T> InsertOrMergeEntityAsync<T>(this CloudTable table, T entity) where T: TableEntity,ITableEntity
        {
            if (entity == null)
                throw new ArgumentNullException("entity", "entity can not be null");
            if (table == null)
                throw new ArgumentNullException("table", "table can not be null");
            try
            {
                // Create the InsertOrReplace table operation
                TableOperation insertOrMergeOperation = TableOperation.InsertOrMerge(entity);

                // Execute the operation.
                TableResult result = await table.ExecuteAsync(insertOrMergeOperation);
                var insertedEnity = (T)result.Result;

                return insertedEnity;
            }
            catch (StorageException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Insert or Update an entity in Azure Table Storage
        /// </summary>
        /// <typeparam name="T">Parameter of Type TableEntity or ITableEntity</typeparam>
        /// <param name="table">CloudTable</param>
        /// <param name="entity">Type of TableEntity or ITableEntity</param>
        /// <returns>Type of TableEntity or ITableEntity</returns>
        /// <exception cref="ArgumentNullException">If Entity is null</exception>
        /// <exception cref="StorageException"></exception>
        /// <exception cref="Exception"></exception>
        public static T InsertOrMergeEntity<T>(this CloudTable table, T entity) where T : TableEntity, ITableEntity
        {
            if (entity == null)
                throw new ArgumentNullException("entity", "entity can not be null");
            if (table == null)
                throw new ArgumentNullException("table", "table can not be null");
            try
            {
                // Create the InsertOrReplace table operation
                TableOperation insertOrMergeOperation = TableOperation.InsertOrMerge(entity);

                // Execute the operation.
                TableResult result = table.Execute(insertOrMergeOperation);
                var insertedEnity = (T)result.Result;

                return insertedEnity;
            }
            catch (StorageException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Asynchornously retrieve entity using partition key and row key
        /// </summary>
        /// <typeparam name="T">Parameter of Type TableEntity or ITableEntity</typeparam>
        /// <param name="table">CloudTable</param>
        /// <param name="partitionKey">Partition Key, required, string</param>
        /// <param name="rowKey">Row Key, required, string</param>
        /// <returns>Type of TableEntity or ITableEntity</returns>
        public static async Task<T> RetrieveEntityUsingPointQueryAsync<T>(this CloudTable table, string partitionKey, string rowKey) where T : TableEntity, ITableEntity
        {
            if (table == null)
                throw new ArgumentNullException("table", "table can not be null");
            if (string.IsNullOrEmpty(partitionKey))
                throw new ArgumentNullException("partitionKey", "partitionKey can not be null");
            if (string.IsNullOrEmpty(partitionKey))
                throw new ArgumentNullException("partitionKey", "partitionKey can not be null");
            try
            {
                TableOperation retrieveOperation = TableOperation.Retrieve<T>(partitionKey, rowKey);
                TableResult result = await table.ExecuteAsync(retrieveOperation);
                var queryResults = result.Result as T;
                return queryResults;
            }
            catch (StorageException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Retrieve entity using partition key and row key
        /// </summary>
        /// <typeparam name="T">Parameter of Type TableEntity or ITableEntity</typeparam>
        /// <param name="table">CloudTable</param>
        /// <param name="partitionKey">Partition Key, required, string</param>
        /// <param name="rowKey">Row Key, required, string</param>
        /// <returns>Type of TableEntity or ITableEntity</returns>
        public static T RetrieveEntityUsingPointQuery<T>(this CloudTable table, string partitionKey, string rowKey) where T : TableEntity, ITableEntity
        {
            if (table == null)
                throw new ArgumentNullException("table", "table can not be null");
            if(string.IsNullOrEmpty(partitionKey))
                throw new ArgumentNullException("partitionKey", "partitionKey can not be null");
            if (string.IsNullOrEmpty(partitionKey))
                throw new ArgumentNullException("partitionKey", "partitionKey can not be null");
            try
            {
                TableOperation retrieveOperation = TableOperation.Retrieve<T>(partitionKey, rowKey);
                TableResult result = table.Execute(retrieveOperation);
                var queryResults = result.Result as T;
                return queryResults;
            }
            catch (StorageException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Asynchornously Deletes an entity
        /// </summary>
        /// <typeparam name="T">Parameter of Type TableEntity or ITableEntity</typeparam>
        /// <param name="table">CloudTable</param>
        /// <param name="deleteEntity">Type of TableEntity or ITableEntity</param>
        /// <returns>Task</returns>
        public static async Task DeleteEntityAsync<T>(this CloudTable table, T deleteEntity) where T : TableEntity, ITableEntity
        {
            if (table == null)
                throw new ArgumentNullException("table", "table can not be null");

            if (deleteEntity == null)
                throw new ArgumentNullException("deleteEntity");

            try
            {
                TableOperation deleteOperation = TableOperation.Delete(deleteEntity);
                TableResult result = await table.ExecuteAsync(deleteOperation);
            }
            catch (StorageException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Asynchornously Deletes an entity
        /// </summary>
        /// <typeparam name="T">Parameter of Type TableEntity or ITableEntity</typeparam>
        /// <param name="table">CloudTable</param>
        /// <param name="deleteEntity">Type of TableEntity or ITableEntity</param>
        public static void DeleteEntity<T>(this CloudTable table, T deleteEntity) where T : TableEntity, ITableEntity
        {
            if (table == null)
                throw new ArgumentNullException("table", "table can not be null");

            if (deleteEntity == null)
                throw new ArgumentNullException("deleteEntity");
            try
            {
                TableOperation deleteOperation = TableOperation.Delete(deleteEntity);
                TableResult result = table.Execute(deleteOperation);
            }
            catch (StorageException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
