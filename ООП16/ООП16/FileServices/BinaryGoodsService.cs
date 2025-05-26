using System.Text;
using MyCollectionLibrary;

namespace ООП16
{
    public class BinaryGoodsService : IFileServiceAsync<string, Goods>
    {
        public string Path { get; set; }

        public async Task SetDataAsync(MyCollection<string, Goods> data)
        {
            await using (FileStream stream = new FileStream(Path, FileMode.Create))
            await using (BinaryWriter writer = new BinaryWriter(stream))
            {
                foreach (var item in data)
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(item.ToString());
                    writer.Write(bytes.Length);
                    writer.Write(bytes);
                }
            }
        }

        public async Task<MyCollection<string, Goods>> GetDataAsync()
        {
            if (!File.Exists(Path))
            {
                throw new Exception("Файл данных не найден");
            }

            var result = new MyCollection<string, Goods>("Десериализованная бинарная коллекция");
            var stringData = new List<string>();

            try
            {
                await using (FileStream stream = new FileStream(Path, FileMode.Open))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    while (stream.Position < stream.Length)
                    {
                        int length = reader.ReadInt32();
                        byte[] bytes = reader.ReadBytes(length);
                        stringData.Add(Encoding.UTF8.GetString(bytes));
                    }
                }
                return CollectionGoodsManager.ConvertGoodsData(stringData);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
                return result;
            }
        }
    }
}
