using MyCollectionLibrary;

namespace ООП16
{
    public class FileManager
    {
        public string Path { get; set; }

        TxtService txtService = new TxtService();
        BinaryGoodsService binService = new BinaryGoodsService();
        JsonGoodsService jsonService = new JsonGoodsService();
        XmlGoodsService xmlService = new XmlGoodsService();
        static string Filter { get; set; } =
            "Бинарные файлы (*.dat)|*.dat|" +
            "XML файлы (*.xml)|*.xml|" +
            "JSON файлы (*.json)|*.json";
        static public string GetFolderPath()
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Выберите папку";
                folderDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                folderDialog.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    return folderDialog.SelectedPath;
                }
            }
            return null;
        }
        static public string GetFileNameToOpen()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Выберите файл";
                openFileDialog.Filter = Filter;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return openFileDialog.FileName;
                }
            }
            return null;
        }
        static public string GetFileNameForSaving()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = Filter;
                saveFileDialog.Title = "Сохранить файл";
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return saveFileDialog.FileName;
                }
            }
            return null;
        }
        public async Task<MyCollection<string, Goods>> GetFileAsync()
        {
            MyCollection<string, Goods> data = new MyCollection<string, Goods>("Десериализованная коллекция");
            string nameFile = GetFileNameToOpen();

            if (nameFile == null)
                throw new OperationCanceledException("Сохранение отменено пользователем");

            string filePath = System.IO.Path.Combine(Path, nameFile);

            string extension = System.IO.Path.GetExtension(nameFile);
            switch (extension)
            {
                case ".dat":
                    {
                        binService.Path = filePath;
                        data = await binService.GetDataAsync();
                        break;
                    }
                case ".json":
                    {
                        jsonService.Path = filePath;
                        data = await jsonService.GetDataAsync();
                        break;
                    }
                case ".xml":
                    {
                        xmlService.Path = filePath;
                        data = await xmlService.GetDataAsync();
                        break;
                    }
            }
            return data;
        }
        public async Task SaveFileAsync(MyCollection<string, Goods> data)
        {
            string filePath = GetFileNameForSaving();

            if (filePath == null)
                throw new OperationCanceledException("Сохранение отменено пользователем");

            string extension = System.IO.Path.GetExtension(filePath);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            switch (extension)
            {
                case ".dat":
                    {
                        binService.Path = filePath;
                        await binService.SetDataAsync(data);
                        break;
                    }
                case ".json":
                    {
                        jsonService.Path = filePath;
                        await jsonService.SetDataAsync(data);
                        break;
                    }
                case ".xml":
                    {
                        xmlService.Path = filePath;
                        await xmlService.SetDataAsync(data);
                        break;
                    }
            }
        }
        public async Task SaveFileTxtAsync(string nameFile, List<string> data)
        {
            string filePath = System.IO.Path.Combine(Path, nameFile);
            txtService.Path = filePath;
            await txtService.SetDataAsync(data);
        }
        public async Task<List<string>> GetFileTxtAsync(string nameFile)
        {
            string filePath = System.IO.Path.Combine(Path, nameFile);
            txtService.Path = filePath;
            return await txtService.GetDataAsync();
        }
    }
}
