using Nest;

namespace ElasticSearchProject
{
    public class LogService
    {


        public async Task<ISearchResponse<object>> GetCustomLog()
        {
            var client = _GetClient("http://localhost:9200", "customlog_*");

            var searchResponse = await client.SearchAsync<object>(
                s =>
                s.Size(3)
                .Query(
                    q => q.Term("Kennen", 3)
                ).Sort(s => s.Descending("TM"))
            );

            return searchResponse;
        }

        ElasticClient _GetClient(string uri, String indexFormat)
        {
            var settings = new ConnectionSettings(new Uri(uri))
                                .DefaultIndex(indexFormat);

            return new ElasticClient(settings);
        }

        public static void AddLog<TLog>(TLog type) where TLog : BaseLog
        {
            var settings = new ConnectionSettings(new Uri("http://localhost:9200"))
                                .DefaultIndex($"{"customlog_"}{DateTime.Now.ToString("yyyy_MM_dd")}");

            var client = new ElasticClient(settings);

            var response = client.IndexDocument(type);
        }
    }
}