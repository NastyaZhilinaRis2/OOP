using MyCollectionLibrary;
namespace ООП16
{
    public partial class MainForm : Form
    {
        MyCollection<string, Goods> collection;
        Journal<string, Goods> journal;

        string typeObj;

        FileManager fileManager;

        string nameFileJournal;
        string nameFileReport;

        public bool IsSaved { get; set; } = true;

        public MainForm()
        {
            InitializeComponent();
        }

        #region Загрузка
        private void MainForm_Shown(object sender, EventArgs e)
        {
            journal = new Journal<string, Goods>();
            LoadCollection();

            collection.CollectionCountChanged += new CollectionHandler<string, Goods>(journal.CollectionCountChangedAsync);
            collection.CollectionReferenceChanged += new CollectionHandler<string, Goods>(journal.CollectionReferenceChangedAsync);
        }
        private void LoadCollection()
        {
            collection = new MyCollection<string, Goods>("Список товаров");

            typeObj = "";

            fileManager = new FileManager();

            LoadPath();

            collection.Clear();
            FormManager.DisplayDataCollection(textBox_outputWindow, collection);
        }
        private void LoadPath()
        {
            MessageBox.Show("Выберите путь для сохранения журнала и отчета!");
            string folderPath = FileManager.GetFolderPath();
            if (folderPath == null)
            {
                folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                MessageBox.Show($"Папка не выбрана. Файлы будут сохранены в: {folderPath}");
            }

            fileManager.Path = folderPath;
            journal.FileManager = fileManager;

            nameFileJournal = "journal.txt";
            nameFileReport = "report.txt";
        }
        #endregion
        #region Файл
        private async void OpenCollection_Click(object sender, EventArgs e)
        {
            if (!IsSaved)
            {
                DialogResult dialogResult = MessageBox.Show("Текущая коллекция не сохранена. Сохранить перед открытием новой?", "Подтверждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.OK)
                {
                    SaveCollection_Click(null, EventArgs.Empty);
                }
            }
            try
            {
                collection.Clear();
                collection = await fileManager.GetFileAsync();
                FormManager.DisplayDataCollection(textBox_outputWindow, collection);
            }
            catch (Exception) { }
        }
        private async void SaveCollection_Click(object sender, EventArgs e)
        {
            if (CollectionEmpty())
            {
                MessageBox.Show("Коллекция пустая!");
                return;
            }

            try
            {
                await fileManager.SaveFileAsync(collection);
                IsSaved = true;
            }
            catch (Exception) { }
        }
        #endregion
        #region Коллекция
        private void NewCollection_Click(object sender, EventArgs e)
        {
            if (!IsSaved)
            {
                DialogResult dialogResult = MessageBox.Show("Текущая коллекция не сохранена. Сохранить перед созданием новой?", "Подтверждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.OK)
                {
                    SaveCollection_Click(null, EventArgs.Empty);
                }
            }
            LoadCollection();
        }
        private void CurrentCollection_Click(object sender, EventArgs e)
        {
            FormManager.DisplayDataCollection(textBox_outputWindow, collection);
        }
        private void AddRandInCollection_Click(object sender, EventArgs e)
        {
            string input = FormManager.StringFromDialogBox("Ввод числа", "Количество элементов в коллекции:", "0");

            if (input == "")
                return;

            if (!InputValidator.InputInt(input, 0, int.MaxValue))
                return;

            int count = int.Parse(input);
            AddRandomRange(count);
            FormManager.DisplayDataCollection(textBox_outputWindow, collection);

            MessageBox.Show($"Добавлено!");
        }
        private void AddRandomRange(int count)
        {
            for (int i = 0; i < count; i++)
            {
                AddRandom();
            }
        }
        private void AddRandom()
        {
            Random random = new Random();
            try
            {
                int randType = random.Next(0, 4);
                switch (randType)
                {
                    case 0:
                        {
                            Goods goods = new Goods();
                            goods.RandomInit();
                            collection.Add(goods.Name, goods);
                            break;
                        }
                    case 1:
                        {
                            Toy toy = new Toy();
                            toy.RandomInit();
                            collection.Add(toy.Name, toy);
                            break;
                        }

                    case 2:
                        {
                            Product product = new Product();
                            product.RandomInit();
                            collection.Add(product.Name, product);
                            break;
                        }
                    case 3:
                        {
                            MilkProduct milkProduct = new MilkProduct();
                            milkProduct.RandomInit();
                            collection.Add(milkProduct.Name, milkProduct);
                            break;
                        }
                }
                IsSaved = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }
        }
        private Goods AddGoodsFromTLP(TableLayoutPanel tableLayoutPanel)
        {
            if (FormManager.ChekFieldsEmpty(tableLayoutPanelGoods))
            {
                throw new ArgumentException("Заполните все пустые поля!");
            }
            return new Goods(textBoxName.Text, int.Parse(textBoxPrice.Text), int.Parse(textBoxCount.Text));
        }
        private Toy AddToyFromTLP(TableLayoutPanel tableLayoutPanel)
        {
            if (FormManager.ChekFieldsEmpty(tableLayoutPanelToy))
            {
                throw new ArgumentException("Заполните все пустые поля!");
            }
            Goods goods = AddGoodsFromTLP(tableLayoutPanel);
            return new Toy(goods.Name, goods.Price, goods.AmountGoods, textBoxProducer.Text, int.Parse(textBoxAge.Text));
        }
        private Product AddProductFromTLP(TableLayoutPanel tableLayoutPanel)
        {
            if (FormManager.ChekFieldsEmpty(tableLayoutPanelProduct))
            {
                throw new ArgumentException("Заполните все пустые поля!");
            }
            Goods goods = AddGoodsFromTLP(tableLayoutPanel);
            return new Product(goods.Name, goods.Price, goods.AmountGoods, textBoxComposition.Text, int.Parse(textBoxDate.Text));
        }
        private MilkProduct AddMilkProductFromTLP(TableLayoutPanel tableLayoutPanel)
        {
            if (FormManager.ChekFieldsEmpty(tableLayoutPanelMilkProduct))
            {
                throw new ArgumentException("Заполните все пустые поля!");
            }
            bool LactoseFree = false;
            if (comboBoxLactoseFree.Text == "Да")
                LactoseFree = true;
            else if (comboBoxLactoseFree.Text == "Нет")
                LactoseFree = false;
            else throw new ArgumentException("Неверно введено поле [Без лактозы]");

            bool BMJ = false;
            if (comboBoxLactoseFree.Text == "Да")
                BMJ = true;
            else if (comboBoxLactoseFree.Text == "Нет")
                BMJ = false;
            else throw new ArgumentException("Неверно введено поле [БМЖ]");

            Product product = AddProductFromTLP(tableLayoutPanel);
            return new MilkProduct(product.Name, product.Price, product.AmountGoods, product.Composition, product.ExpirationDate, LactoseFree, BMJ);
        }
        private void DeleteFromCollection_Click(object sender, EventArgs e)
        {
            string input = FormManager.StringFromDialogBox("Ввод строки", "Ключ строки для удаления:");

            if (input == "")
                return;
            if (collection.Remove(input))
            {
                try
                {
                    FormManager.CleanFields(tableLayoutPanelObjectFields);
                    FormManager.DisplayDataCollection(textBox_outputWindow, collection);
                    IsSaved = false;
                    MessageBox.Show($"Удалено!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка: {ex.Message}");
                }

            }
            else MessageBox.Show($"По такому ключу ничего не найдено!");
        }
        private async void SearchInCollection_Click(object sender, EventArgs e)
        {
            string input = FormManager.StringFromDialogBox("Ввод строки", "Ключ элемента для поиска:");

            if (input == "")
                return;

            List<string> list = new List<string>();

            if (collection.TryGetValue(input, out Goods? goods))
            {
                list.Add($"Операция: [Поиск значения по ключу], Объект: ключ [{input}], значение [{goods}]");

                await fileManager.SaveFileTxtAsync(nameFileReport, list);

                MessageBox.Show($"Элемент найден!");
            }
            else
            {
                list.Add($"Операция: [Поиск значения по ключу], Объект не найден");

                await fileManager.SaveFileTxtAsync(nameFileReport, list);

                MessageBox.Show($"Элемент не найден!");
            }
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (comboBoxTypeObj.Text == null)
                return;

            Goods? goods = null;
            switch (typeObj)
            {
                case "Goods":
                    {
                        try
                        {
                            goods = AddGoodsFromTLP(tableLayoutPanelGoods);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Произошла ошибка: {ex.Message}");
                        }
                        break;
                    }
                case "Toys":
                    {
                        try
                        {
                            goods = AddToyFromTLP(tableLayoutPanelToy);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Произошла ошибка: {ex.Message}");
                        }
                        break;
                    }
                case "Products":
                    {
                        try
                        {
                            goods = AddProductFromTLP(tableLayoutPanelProduct);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Произошла ошибка: {ex.Message}");
                        }
                        break;
                    }
                case "MilkProducts":
                    {
                        try
                        {
                            goods = AddMilkProductFromTLP(tableLayoutPanelMilkProduct);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Произошла ошибка: {ex.Message}");
                        }
                        break;
                    }
            }
            FormManager.CleanFields(tableLayoutPanelObjectFields);

            if (goods != null)
            {
                try
                {
                    collection.Add(goods.Name, goods);
                    FormManager.DisplayDataCollection(textBox_outputWindow, collection);
                    IsSaved = false;
                    MessageBox.Show("Добавлено!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка: {ex.Message}");
                }
            }
        }
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (FormManager.ChekFieldsEmpty(comboBoxTypeObj))
                return;

            string input = FormManager.StringFromDialogBox("Ввод строки", "Ключ элемента для обновления:");

            if (input == "")
                return;

            if (collection.ContainsKey(input))
            {
                try
                {
                    collection[textBoxName.Text] = AddGoodsFromTLP(tableLayoutPanelGoods);
                    FormManager.CleanFields(tableLayoutPanelObjectFields);
                    FormManager.DisplayDataCollection(textBox_outputWindow, collection);
                    IsSaved = false;
                    MessageBox.Show($"Обновлено!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка: {ex.Message}");
                }
            }
            else
                MessageBox.Show($"По такому ключу ничего не найдено!");
        }
        private bool CollectionEmpty()
        {
            if (collection.Count == 0)
                return true;
            return false;
        }
        #endregion
        #region Запросы
        private async void MinPrice_Click(object sender, EventArgs e)
        {
            if (CollectionEmpty())
            {
                MessageBox.Show("Коллекция пустая!");
                return;
            }
            var minPrice = (from product in collection.Values
                            select product.Price).Min();

            var minPriceProducts = from product in collection.Values
                                   where product.Price == minPrice
                                   select product;

            List<string> list = new List<string>();
            foreach (var product in minPriceProducts)
            {
                list.Add($"Операция: [Минимальная цена среди товаров], Объект: [{product}], значение [{minPrice} руб.]");
            }
            list.Add("\r\n");
            await fileManager.SaveFileTxtAsync(nameFileReport, list);

            MessageBox.Show($"Применено! Смотреть в отчете.");
        }
        private async void AveragePrice_Click(object sender, EventArgs e)
        {
            if (CollectionEmpty())
            {
                MessageBox.Show("Коллекция пустая!");
                return;
            }
            var averagePrice = (from product in collection.Values
                                select product.Price).Average();

            List<string> list = new List<string>();
            list.Add($"Операция: [Средняя цена среди товаров], значение [{averagePrice} руб.]");
            list.Add("\r\n");

            await fileManager.SaveFileTxtAsync(nameFileReport, list);

            MessageBox.Show($"Применено! Смотреть в отчете.");
        }
        private async void MaxPrice_Click(object sender, EventArgs e)
        {
            if (CollectionEmpty())
            {
                MessageBox.Show("Коллекция пустая!");
                return;
            }
            var maxPrice = (from product in collection.Values
                            select product.Price).Max();

            var maxPricesProducts = from product in collection.Values
                                    where product.Price == maxPrice
                                    select product;

            List<string> list = new List<string>();
            foreach (var product in maxPricesProducts)
            {
                list.Add($"Операция: [Максимальная цена среди товаров], Объект: [{product}], значение [{maxPrice} руб.]");
            }
            list.Add("\r\n");
            await fileManager.SaveFileTxtAsync(nameFileReport, list);

            MessageBox.Show($"Применено! Смотреть в отчете.");
        }
        #endregion
        #region Журнал и отчет
        private async void OpenJournal_Click(object sender, EventArgs e)
        {
            try
            {
                await FormManager.DisplayDataFromFileTxtAsync(textBox_outputWindow, fileManager, nameFileJournal);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
        private async void OpenReport_Click(object sender, EventArgs e)
        {
            try
            {
                await FormManager.DisplayDataFromFileTxtAsync(textBox_outputWindow, fileManager, nameFileReport);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
        #endregion
        #region Операции (сортировка и фильтрация)
        private async Task SortedAsync(string field)
        {
            var sortedList = CollectionGoodsManager.SortedByField(collection, field);

            List<string> list = new List<string>();

            list.Add($"Операция: [Сортировка по полю], Поле: [{field}]:");
            foreach (var product in sortedList)
            {
                list.Add($"Объект: [{product}]");
            }
            list.Add("\r\n");
            await fileManager.SaveFileTxtAsync(nameFileReport, list);
        }
        private async Task FilteringAsync(string filter, string field)
        {
            var filterList = CollectionGoodsManager.FilteringByField(collection, filter, field);

            List<string> list = new List<string>();
            list.Add($"Операция: [Фильтрация по полю], Поле: [{field}]:, Фильтр: [{filter}]");
            foreach (var product in filterList)
            {
                list.Add($"Объект: [{product}]");
            }
            list.Add("\r\n");
            await fileManager.SaveFileTxtAsync(nameFileReport, list);
        }
        private async void buttonApply_Click(object sender, EventArgs e)
        {
            bool isSorted = !FormManager.ChekFieldsEmpty(tableLayoutPanelSorted);
            bool isFilter = !FormManager.ChekFieldsEmpty(tableLayoutPanelFilter);

            if (!isSorted && !isFilter)
            {
                MessageBox.Show("Заполните пустые поля!");
                return;
            }

            if (isSorted)
            {
                string field = comboBoxSort.Text;
                await SortedAsync(field);
                FormManager.CleanFields(tableLayoutPanelSorted);
            }

            if (isFilter)
            {
                string field = comboBoxFiltrField.Text;
                string strFiltr = textBoxFiltr.Text;
                await FilteringAsync(strFiltr, field);
                FormManager.CleanFields(tableLayoutPanelFilter);
            }

            MessageBox.Show($"Применено! Смотреть в отчете.");
        }
        #endregion
        #region Работа с объектами формы
        private void comboBoxTypeObj_TextChanged(object sender, EventArgs e)
        {
            typeObj = comboBoxTypeObj.Text;
            switch (typeObj)
            {
                case "Goods":
                    {
                        tableLayoutPanelGoods.Visible = true;
                        tableLayoutPanelToy.Visible = false;
                        tableLayoutPanelProduct.Visible = false;
                        tableLayoutPanelMilkProduct.Visible = false;

                        break;
                    }
                case "Toys":
                    {
                        tableLayoutPanelGoods.Visible = true;
                        tableLayoutPanelToy.Visible = true;
                        tableLayoutPanelProduct.Visible = false;
                        tableLayoutPanelMilkProduct.Visible = false;
                        break;
                    }
                case "Products":
                    {
                        tableLayoutPanelGoods.Visible = true;
                        tableLayoutPanelToy.Visible = false;
                        tableLayoutPanelProduct.Visible = true;
                        tableLayoutPanelMilkProduct.Visible = false;
                        break;
                    }
                case "MilkProducts":
                    {
                        tableLayoutPanelGoods.Visible = true;
                        tableLayoutPanelToy.Visible = false;
                        tableLayoutPanelProduct.Visible = true;
                        tableLayoutPanelMilkProduct.Visible = true;
                        break;
                    }
                default:
                    {
                        tableLayoutPanelGoods.Visible = false;
                        tableLayoutPanelToy.Visible = false;
                        tableLayoutPanelProduct.Visible = false;
                        tableLayoutPanelMilkProduct.Visible = false;
                        break;
                    }
            }
        }
        private void textBoxPrice_Leave(object sender, EventArgs e)
        {
            InputValidatorInForm.CorrectInputToControl(textBoxPrice);
        }
        private void textBoxCount_Leave(object sender, EventArgs e)
        {
            InputValidatorInForm.CorrectInputToControl(textBoxCount);
        }
        private void textBoxAge_Leave(object sender, EventArgs e)
        {
            int[] validNumbers = { 0, 3, 6, 12, 18 };
            InputValidatorInForm.CorrectInputToControl(textBoxAge, validNumbers);
        }
        private void textBoxDate_Leave(object sender, EventArgs e)
        {
            InputValidatorInForm.CorrectInputToControl(textBoxDate);
        }
        #endregion
    }
}
