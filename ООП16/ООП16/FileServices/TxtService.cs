using MyCollectionLibrary;

namespace ООП16
{
    public class TxtService : IFileTxtServiceAsync
    {
        public string Path { get; set; }

        public async Task SetDataAsync(List<string> data)
        {
            await using (FileStream stream = new FileStream(Path, FileMode.Append))
            await using (StreamWriter file = new StreamWriter(stream))
            {
                foreach (var item in data)
                {
                    await file.WriteLineAsync(item.ToString());
                }
            }
        }

        public async Task<List<string>> GetDataAsync()
        {
            if (!File.Exists(Path))
            {
                throw new Exception("Файл данных не найден");
            }

            try
            {
                return (await File.ReadAllLinesAsync(Path)).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
                return new List<string>();
            }
        }
    }
}
