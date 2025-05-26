using MyCollectionLibrary;

namespace ООП16
{
    public interface IFileServiceAsync<TKey, TValue>
    {
        public string Path { get; set; }

        Task<MyCollection<TKey, TValue>> GetDataAsync();

        Task SetDataAsync(MyCollection<TKey, TValue> data);

    }
    public interface IFileTxtServiceAsync
    {
        public string Path { get; set; }

        Task<List<string>> GetDataAsync();

        Task SetDataAsync(List<string> data);

    }
}
