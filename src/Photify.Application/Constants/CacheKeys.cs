namespace Photify.Application.Constants
{
    public static class CacheKeys
    {
        public static string GetFileObjectsBySourceId(int sourceId) => $"file_objects_by_source_{sourceId}";
        public static string GetAllDataSources => $"all_data_sources";
    }
}
