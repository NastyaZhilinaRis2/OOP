using System.Text.Json;
using MyCollectionLibrary;

namespace ООП16
{
    public class JsonGoodsService : IFileServiceAsync<string, Goods>
    {
        public string Path { get; set; }

        public async Task SetDataAsync(MyCollection<string, Goods> data)
        {
            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions
            {
                WriteIndented = true,
                IncludeFields = true
            });

            await File.WriteAllTextAsync(Path, json);
        }

        public async Task<MyCollection<string, Goods>> GetDataAsync()
        {
            if (!File.Exists(Path))
            {
                throw new Exception("Файл не найден");
            }

            var result = new MyCollection<string, Goods>("Десериализованная JSON коллекция");

            try
            {
                string json = await File.ReadAllTextAsync(Path);

                result = JsonSerializer.Deserialize<MyCollection<string, Goods>>(json)
                       ?? new MyCollection<string, Goods>("Новая коллекция");
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