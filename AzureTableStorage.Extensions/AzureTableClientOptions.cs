using Microsoft.Azure.Cosmos.Table;

namespace AzureTableStorage.Extensions
{
    /// <summary>
    /// Represents Configuration settings associated with AzureTableClient
    /// </summary>
    public class AzureTableClientOptions: TableClientConfiguration
    {
        public AzureTableClientOptions()
        {

        }

        public AzureTableClientOptions(string azureTableConnectionString)
        {
            AzureTableConnectionString = azureTableConnectionString;   
        }

        /// <summary>
        /// Azure Table Connection String, available in Azure Portal
        /// </summary>
        public string AzureTableConnectionString { get; set; }
    }
}
