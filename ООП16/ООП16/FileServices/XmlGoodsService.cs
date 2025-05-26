using System.Xml.Serialization;
using MyCollectionLibrary;

namespace ООП16
{
    public class XmlGoodsService : IFileServiceAsync<string, Goods>
    {
        public string Path { get; set; }
        public async Task SetDataAsync(MyCollection<string, Goods> data)
        {
            var nodes = data.Select(kv => new NodeHash<string, Goods> (kv.Key, kv.Value )).ToList();

            var serializer = new XmlSerializer(typeof(List<NodeHash<string, Goods>>));

            await using var file = File.Create(Path);

            serializer.Serialize(file, nodes);
        }

        public async Task<MyCollection<string, Goods>> GetDataAsync()
        {
            if (!File.Exists(Path))
            {
                throw new Exception("Файл не найден");
            }

            var result = new MyCollection<string, Goods>("Десериализованная XML коллекция");
            var serializer = new XmlSerializer(typeof(List<NodeHash<string, Goods>>));

            try
            {
                await using var fileStream = new FileStream(Path, FileMode.Open);

                var nodes = serializer.Deserialize(fileStream) as List<NodeHash<string, Goods>> ?? new List<NodeHash<string, Goods>>();

                foreach (var node in nodes)
                {
                    result.Add(node.Key, node.Value);
                }
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
                return result;
            }
        }
    }
}
