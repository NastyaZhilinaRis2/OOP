namespace ООП16
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip = new MenuStrip();
            файлToolStripMenuItem1 = new ToolStripMenuItem();
            OpenCollection = new ToolStripMenuItem();
            SaveCollection = new ToolStripMenuItem();
            коллекцияToolStripMenuItem = new ToolStripMenuItem();
            NewCollection = new ToolStripMenuItem();
            CurrentCollection = new ToolStripMenuItem();
            AddRandInCollection = new ToolStripMenuItem();
            DeleteFromCollection = new ToolStripMenuItem();
            SearchInCollection = new ToolStripMenuItem();
            запросыToolStripMenuItem = new ToolStripMenuItem();
            MinPrice = new ToolStripMenuItem();
            AveragePrice = new ToolStripMenuItem();
            MaxPrice = new ToolStripMenuItem();
            журналToolStripMenuItem = new ToolStripMenuItem();
            OpenJournal = new ToolStripMenuItem();
            отчетToolStripMenuItem = new ToolStripMenuItem();
            OpenReport = new ToolStripMenuItem();
            splitContainer = new SplitContainer();
            textBox_outputWindow = new TextBox();
            groupBoxParam = new GroupBox();
            tableLayoutPanelParam = new TableLayoutPanel();
            tableLayoutPanelButton = new TableLayoutPanel();
            buttonUpdate = new Button();
            buttonAdd = new Button();
            tableLayoutPanelSorted = new TableLayoutPanel();
            labelSort = new Label();
            labelOperations = new Label();
            comboBoxSort = new ComboBox();
            buttonApply = new Button();
            tableLayoutPanelTypeObj = new TableLayoutPanel();
            labelTypeObj = new Label();
            comboBoxTypeObj = new ComboBox();
            tableLayoutPanelObjectFields = new TableLayoutPanel();
            labelObjectFields = new Label();
            tableLayoutPanelGoods = new TableLayoutPanel();
            labelName = new Label();
            labelPrice = new Label();
            labelCount = new Label();
            textBoxName = new TextBox();
            textBoxPrice = new TextBox();
            textBoxCount = new TextBox();
            tableLayoutPanelToy = new TableLayoutPanel();
            labelProducer = new Label();
            labelAge = new Label();
            textBoxProducer = new TextBox();
            textBoxAge = new TextBox();
            tableLayoutPanelProduct = new TableLayoutPanel();
            labelComposition = new Label();
            labelDate = new Label();
            textBoxDate = new TextBox();
            textBoxComposition = new TextBox();
            tableLayoutPanelMilkProduct = new TableLayoutPanel();
            labelLactoseFree = new Label();
            comboBoxLactoseFree = new ComboBox();
            comboBoxBMJ = new ComboBox();
            labelBMJ = new Label();
            tableLayoutPanelFilter = new TableLayoutPanel();
            comboBoxFiltrField = new ComboBox();
            labelFiltr = new Label();
            labelFiltrField = new Label();
            textBoxFiltr = new TextBox();
            файлToolStripMenuItem = new ToolStripMenuItem();
            menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            groupBoxParam.SuspendLayout();
            tableLayoutPanelParam.SuspendLayout();
            tableLayoutPanelButton.SuspendLayout();
            tableLayoutPanelSorted.SuspendLayout();
            tableLayoutPanelTypeObj.SuspendLayout();
            tableLayoutPanelObjectFields.SuspendLayout();
            tableLayoutPanelGoods.SuspendLayout();
            tableLayoutPanelToy.SuspendLayout();
            tableLayoutPanelProduct.SuspendLayout();
            tableLayoutPanelMilkProduct.SuspendLayout();
            tableLayoutPanelFilter.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem1, коллекцияToolStripMenuItem, запросыToolStripMenuItem, журналToolStripMenuItem, отчетToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(1189, 24);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "Меню";
            // 
            // файлToolStripMenuItem1
            // 
            файлToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { OpenCollection, SaveCollection });
            файлToolStripMenuItem1.Name = "файлToolStripMenuItem1";
            файлToolStripMenuItem1.Size = new Size(48, 20);
            файлToolStripMenuItem1.Text = "Файл";
            // 
            // OpenCollection
            // 
            OpenCollection.Name = "OpenCollection";
            OpenCollection.Size = new Size(180, 22);
            OpenCollection.Text = "Открыть";
            OpenCollection.Click += OpenCollection_Click;
            // 
            // SaveCollection
            // 
            SaveCollection.Name = "SaveCollection";
            SaveCollection.Size = new Size(180, 22);
            SaveCollection.Text = "Сохранить";
            SaveCollection.Click += SaveCollection_Click;
            // 
            // коллекцияToolStripMenuItem
            // 
            коллекцияToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { NewCollection, CurrentCollection, AddRandInCollection, DeleteFromCollection, SearchInCollection });
            коллекцияToolStripMenuItem.Name = "коллекцияToolStripMenuItem";
            коллекцияToolStripMenuItem.Size = new Size(79, 20);
            коллекцияToolStripMenuItem.Text = "Коллекция";
            // 
            // NewCollection
            // 
            NewCollection.Name = "NewCollection";
            NewCollection.Size = new Size(201, 22);
            NewCollection.Text = "Новая";
            NewCollection.Click += NewCollection_Click;
            // 
            // CurrentCollection
            // 
            CurrentCollection.Name = "CurrentCollection";
            CurrentCollection.Size = new Size(201, 22);
            CurrentCollection.Text = "Просмотреть текущую";
            CurrentCollection.Click += CurrentCollection_Click;
            // 
            // AddRandInCollection
            // 
            AddRandInCollection.Name = "AddRandInCollection";
            AddRandInCollection.Size = new Size(201, 22);
            AddRandInCollection.Text = "Сгенерировать";
            AddRandInCollection.Click += AddRandInCollection_Click;
            // 
            // DeleteFromCollection
            // 
            DeleteFromCollection.Name = "DeleteFromCollection";
            DeleteFromCollection.Size = new Size(201, 22);
            DeleteFromCollection.Text = "Удалить";
            DeleteFromCollection.Click += DeleteFromCollection_Click;
            // 
            // SearchInCollection
            // 
            SearchInCollection.Name = "SearchInCollection";
            SearchInCollection.Size = new Size(201, 22);
            SearchInCollection.Text = "Найти";
            SearchInCollection.Click += SearchInCollection_Click;
            // 
            // запросыToolStripMenuItem
            // 
            запросыToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { MinPrice, AveragePrice, MaxPrice });
            запросыToolStripMenuItem.Name = "запросыToolStripMenuItem";
            запросыToolStripMenuItem.Size = new Size(68, 20);
            запросыToolStripMenuItem.Text = "Запросы";
            // 
            // MinPrice
            // 
            MinPrice.Name = "MinPrice";
            MinPrice.Size = new Size(186, 22);
            MinPrice.Text = "Минимальная цена";
            MinPrice.Click += MinPrice_Click;
            // 
            // AveragePrice
            // 
            AveragePrice.Name = "AveragePrice";
            AveragePrice.Size = new Size(186, 22);
            AveragePrice.Text = "Средняя цена";
            AveragePrice.Click += AveragePrice_Click;
            // 
            // MaxPrice
            // 
            MaxPrice.Name = "MaxPrice";
            MaxPrice.Size = new Size(186, 22);
            MaxPrice.Text = "Максимальная цена";
            MaxPrice.Click += MaxPrice_Click;
            // 
            // журналToolStripMenuItem
            // 
            журналToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { OpenJournal });
            журналToolStripMenuItem.Name = "журналToolStripMenuItem";
            журналToolStripMenuItem.Size = new Size(63, 20);
            журналToolStripMenuItem.Text = "Журнал";
            // 
            // OpenJournal
            // 
            OpenJournal.Name = "OpenJournal";
            OpenJournal.Size = new Size(131, 22);
            OpenJournal.Text = "Просмотр";
            OpenJournal.Click += OpenJournal_Click;
            // 
            // отчетToolStripMenuItem
            // 
            отчетToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { OpenReport });
            отчетToolStripMenuItem.Name = "отчетToolStripMenuItem";
            отчетToolStripMenuItem.Size = new Size(51, 20);
            отчетToolStripMenuItem.Text = "Отчет";
            // 
            // OpenReport
            // 
            OpenReport.Name = "OpenReport";
            OpenReport.Size = new Size(131, 22);
            OpenReport.Text = "Просмотр";
            OpenReport.Click += OpenReport_Click;
            // 
            // splitContainer
            // 
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.Location = new Point(0, 24);
            splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(textBox_outputWindow);
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(groupBoxParam);
            splitContainer.Size = new Size(1189, 604);
            splitContainer.SplitterDistance = 779;
            splitContainer.TabIndex = 1;
            // 
            // textBox_outputWindow
            // 
            textBox_outputWindow.Dock = DockStyle.Fill;
            textBox_outputWindow.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBox_outputWindow.Location = new Point(0, 0);
            textBox_outputWindow.Multiline = true;
            textBox_outputWindow.Name = "textBox_outputWindow";
            textBox_outputWindow.ReadOnly = true;
            textBox_outputWindow.ScrollBars = ScrollBars.Both;
            textBox_outputWindow.Size = new Size(779, 604);
            textBox_outputWindow.TabIndex = 0;
            // 
            // groupBoxParam
            // 
            groupBoxParam.Controls.Add(tableLayoutPanelParam);
            groupBoxParam.Dock = DockStyle.Fill;
            groupBoxParam.Location = new Point(0, 0);
            groupBoxParam.Name = "groupBoxParam";
            groupBoxParam.Size = new Size(406, 604);
            groupBoxParam.TabIndex = 0;
            groupBoxParam.TabStop = false;
            groupBoxParam.Text = "Параметры";
            // 
            // tableLayoutPanelParam
            // 
            tableLayoutPanelParam.ColumnCount = 1;
            tableLayoutPanelParam.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelParam.Controls.Add(tableLayoutPanelButton, 0, 5);
            tableLayoutPanelParam.Controls.Add(tableLayoutPanelSorted, 0, 2);
            tableLayoutPanelParam.Controls.Add(buttonApply, 0, 4);
            tableLayoutPanelParam.Controls.Add(tableLayoutPanelTypeObj, 0, 0);
            tableLayoutPanelParam.Controls.Add(tableLayoutPanelObjectFields, 0, 1);
            tableLayoutPanelParam.Controls.Add(tableLayoutPanelFilter, 0, 3);
            tableLayoutPanelParam.Dock = DockStyle.Fill;
            tableLayoutPanelParam.Location = new Point(3, 19);
            tableLayoutPanelParam.Name = "tableLayoutPanelParam";
            tableLayoutPanelParam.RowCount = 6;
            tableLayoutPanelParam.RowStyles.Add(new RowStyle(SizeType.Absolute, 56F));
            tableLayoutPanelParam.RowStyles.Add(new RowStyle(SizeType.Absolute, 321F));
            tableLayoutPanelParam.RowStyles.Add(new RowStyle(SizeType.Absolute, 55F));
            tableLayoutPanelParam.RowStyles.Add(new RowStyle(SizeType.Absolute, 63F));
            tableLayoutPanelParam.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanelParam.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tableLayoutPanelParam.Size = new Size(400, 582);
            tableLayoutPanelParam.TabIndex = 1;
            // 
            // tableLayoutPanelButton
            // 
            tableLayoutPanelButton.ColumnCount = 2;
            tableLayoutPanelButton.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanelButton.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanelButton.Controls.Add(buttonUpdate, 1, 0);
            tableLayoutPanelButton.Controls.Add(buttonAdd, 0, 0);
            tableLayoutPanelButton.Dock = DockStyle.Fill;
            tableLayoutPanelButton.Location = new Point(3, 536);
            tableLayoutPanelButton.Name = "tableLayoutPanelButton";
            tableLayoutPanelButton.RowCount = 1;
            tableLayoutPanelButton.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelButton.Size = new Size(394, 43);
            tableLayoutPanelButton.TabIndex = 6;
            // 
            // buttonUpdate
            // 
            buttonUpdate.Dock = DockStyle.Top;
            buttonUpdate.Location = new Point(200, 3);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(191, 37);
            buttonUpdate.TabIndex = 16;
            buttonUpdate.Text = "Обновить";
            buttonUpdate.UseVisualStyleBackColor = true;
            buttonUpdate.Click += buttonUpdate_Click;
            // 
            // buttonAdd
            // 
            buttonAdd.Dock = DockStyle.Top;
            buttonAdd.Location = new Point(3, 3);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(191, 37);
            buttonAdd.TabIndex = 15;
            buttonAdd.Text = "Добавить";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // tableLayoutPanelSorted
            // 
            tableLayoutPanelSorted.ColumnCount = 2;
            tableLayoutPanelSorted.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 123F));
            tableLayoutPanelSorted.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tableLayoutPanelSorted.Controls.Add(labelSort, 0, 1);
            tableLayoutPanelSorted.Controls.Add(labelOperations, 0, 0);
            tableLayoutPanelSorted.Controls.Add(comboBoxSort, 1, 1);
            tableLayoutPanelSorted.Dock = DockStyle.Fill;
            tableLayoutPanelSorted.Location = new Point(3, 380);
            tableLayoutPanelSorted.Name = "tableLayoutPanelSorted";
            tableLayoutPanelSorted.RowCount = 2;
            tableLayoutPanelSorted.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanelSorted.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanelSorted.Size = new Size(394, 49);
            tableLayoutPanelSorted.TabIndex = 0;
            // 
            // labelSort
            // 
            labelSort.AutoSize = true;
            labelSort.Dock = DockStyle.Fill;
            labelSort.Location = new Point(3, 20);
            labelSort.Name = "labelSort";
            labelSort.Size = new Size(117, 35);
            labelSort.TabIndex = 14;
            labelSort.Text = "Сортировка по полю:";
            // 
            // labelOperations
            // 
            labelOperations.AutoSize = true;
            labelOperations.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelOperations.Location = new Point(3, 0);
            labelOperations.Name = "labelOperations";
            labelOperations.Size = new Size(70, 15);
            labelOperations.TabIndex = 13;
            labelOperations.Text = "Операции:";
            // 
            // comboBoxSort
            // 
            comboBoxSort.Dock = DockStyle.Fill;
            comboBoxSort.FormattingEnabled = true;
            comboBoxSort.ItemHeight = 15;
            comboBoxSort.Items.AddRange(new object[] { "Название", "Цена", "Количество" });
            comboBoxSort.Location = new Point(126, 23);
            comboBoxSort.Name = "comboBoxSort";
            comboBoxSort.Size = new Size(265, 23);
            comboBoxSort.TabIndex = 11;
            // 
            // buttonApply
            // 
            buttonApply.Dock = DockStyle.Right;
            buttonApply.Location = new Point(169, 498);
            buttonApply.Name = "buttonApply";
            buttonApply.Size = new Size(228, 32);
            buttonApply.TabIndex = 14;
            buttonApply.Text = "Применить";
            buttonApply.UseVisualStyleBackColor = true;
            buttonApply.Click += buttonApply_Click;
            // 
            // tableLayoutPanelTypeObj
            // 
            tableLayoutPanelTypeObj.ColumnCount = 1;
            tableLayoutPanelTypeObj.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelTypeObj.Controls.Add(labelTypeObj, 0, 0);
            tableLayoutPanelTypeObj.Controls.Add(comboBoxTypeObj, 0, 1);
            tableLayoutPanelTypeObj.Dock = DockStyle.Fill;
            tableLayoutPanelTypeObj.Location = new Point(3, 3);
            tableLayoutPanelTypeObj.Name = "tableLayoutPanelTypeObj";
            tableLayoutPanelTypeObj.RowCount = 2;
            tableLayoutPanelTypeObj.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanelTypeObj.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanelTypeObj.Size = new Size(394, 50);
            tableLayoutPanelTypeObj.TabIndex = 4;
            // 
            // labelTypeObj
            // 
            labelTypeObj.AutoSize = true;
            labelTypeObj.Dock = DockStyle.Fill;
            labelTypeObj.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelTypeObj.Location = new Point(3, 0);
            labelTypeObj.Name = "labelTypeObj";
            labelTypeObj.Size = new Size(388, 20);
            labelTypeObj.TabIndex = 0;
            labelTypeObj.Text = "Тип объекта:";
            // 
            // comboBoxTypeObj
            // 
            comboBoxTypeObj.Dock = DockStyle.Fill;
            comboBoxTypeObj.FormattingEnabled = true;
            comboBoxTypeObj.Items.AddRange(new object[] { "Goods", "Toys", "Products", "MilkProducts" });
            comboBoxTypeObj.Location = new Point(3, 23);
            comboBoxTypeObj.Name = "comboBoxTypeObj";
            comboBoxTypeObj.Size = new Size(388, 23);
            comboBoxTypeObj.TabIndex = 1;
            comboBoxTypeObj.TextChanged += comboBoxTypeObj_TextChanged;
            // 
            // tableLayoutPanelObjectFields
            // 
            tableLayoutPanelObjectFields.ColumnCount = 1;
            tableLayoutPanelObjectFields.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelObjectFields.Controls.Add(labelObjectFields, 0, 0);
            tableLayoutPanelObjectFields.Controls.Add(tableLayoutPanelGoods, 0, 1);
            tableLayoutPanelObjectFields.Controls.Add(tableLayoutPanelToy, 0, 2);
            tableLayoutPanelObjectFields.Controls.Add(tableLayoutPanelProduct, 0, 3);
            tableLayoutPanelObjectFields.Controls.Add(tableLayoutPanelMilkProduct, 0, 4);
            tableLayoutPanelObjectFields.Dock = DockStyle.Fill;
            tableLayoutPanelObjectFields.Location = new Point(3, 59);
            tableLayoutPanelObjectFields.Name = "tableLayoutPanelObjectFields";
            tableLayoutPanelObjectFields.RowCount = 5;
            tableLayoutPanelObjectFields.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanelObjectFields.RowStyles.Add(new RowStyle(SizeType.Absolute, 96F));
            tableLayoutPanelObjectFields.RowStyles.Add(new RowStyle(SizeType.Absolute, 76F));
            tableLayoutPanelObjectFields.RowStyles.Add(new RowStyle(SizeType.Absolute, 66F));
            tableLayoutPanelObjectFields.RowStyles.Add(new RowStyle(SizeType.Absolute, 13F));
            tableLayoutPanelObjectFields.Size = new Size(394, 315);
            tableLayoutPanelObjectFields.TabIndex = 5;
            // 
            // labelObjectFields
            // 
            labelObjectFields.AutoSize = true;
            labelObjectFields.Dock = DockStyle.Fill;
            labelObjectFields.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelObjectFields.Location = new Point(3, 0);
            labelObjectFields.Name = "labelObjectFields";
            labelObjectFields.Size = new Size(388, 20);
            labelObjectFields.TabIndex = 2;
            labelObjectFields.Text = "Поля объекта:";
            // 
            // tableLayoutPanelGoods
            // 
            tableLayoutPanelGoods.ColumnCount = 2;
            tableLayoutPanelGoods.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.9031334F));
            tableLayoutPanelGoods.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 66.09686F));
            tableLayoutPanelGoods.Controls.Add(labelName, 0, 0);
            tableLayoutPanelGoods.Controls.Add(labelPrice, 0, 1);
            tableLayoutPanelGoods.Controls.Add(labelCount, 0, 2);
            tableLayoutPanelGoods.Controls.Add(textBoxName, 1, 0);
            tableLayoutPanelGoods.Controls.Add(textBoxPrice, 1, 1);
            tableLayoutPanelGoods.Controls.Add(textBoxCount, 1, 2);
            tableLayoutPanelGoods.Dock = DockStyle.Fill;
            tableLayoutPanelGoods.Location = new Point(3, 23);
            tableLayoutPanelGoods.Name = "tableLayoutPanelGoods";
            tableLayoutPanelGoods.RowCount = 3;
            tableLayoutPanelGoods.RowStyles.Add(new RowStyle(SizeType.Percent, 28.7234039F));
            tableLayoutPanelGoods.RowStyles.Add(new RowStyle(SizeType.Percent, 28.7234039F));
            tableLayoutPanelGoods.RowStyles.Add(new RowStyle(SizeType.Percent, 42.5531921F));
            tableLayoutPanelGoods.Size = new Size(388, 90);
            tableLayoutPanelGoods.TabIndex = 3;
            tableLayoutPanelGoods.Visible = false;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Dock = DockStyle.Fill;
            labelName.Location = new Point(3, 0);
            labelName.Name = "labelName";
            labelName.Size = new Size(125, 25);
            labelName.TabIndex = 4;
            labelName.Text = "Название (ключ):";
            // 
            // labelPrice
            // 
            labelPrice.AutoSize = true;
            labelPrice.Dock = DockStyle.Fill;
            labelPrice.Location = new Point(3, 25);
            labelPrice.Name = "labelPrice";
            labelPrice.Size = new Size(125, 25);
            labelPrice.TabIndex = 6;
            labelPrice.Text = "Цена (руб.):";
            // 
            // labelCount
            // 
            labelCount.AutoSize = true;
            labelCount.Dock = DockStyle.Fill;
            labelCount.Location = new Point(3, 50);
            labelCount.Name = "labelCount";
            labelCount.Size = new Size(125, 40);
            labelCount.TabIndex = 10;
            labelCount.Text = "Количество (шт.):";
            // 
            // textBoxName
            // 
            textBoxName.Dock = DockStyle.Fill;
            textBoxName.Location = new Point(134, 3);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(251, 23);
            textBoxName.TabIndex = 2;
            // 
            // textBoxPrice
            // 
            textBoxPrice.Dock = DockStyle.Fill;
            textBoxPrice.Location = new Point(134, 28);
            textBoxPrice.Name = "textBoxPrice";
            textBoxPrice.Size = new Size(251, 23);
            textBoxPrice.TabIndex = 3;
            textBoxPrice.Leave += textBoxPrice_Leave;
            // 
            // textBoxCount
            // 
            textBoxCount.Dock = DockStyle.Fill;
            textBoxCount.Location = new Point(134, 53);
            textBoxCount.Name = "textBoxCount";
            textBoxCount.Size = new Size(251, 23);
            textBoxCount.TabIndex = 4;
            textBoxCount.Leave += textBoxCount_Leave;
            // 
            // tableLayoutPanelToy
            // 
            tableLayoutPanelToy.ColumnCount = 2;
            tableLayoutPanelToy.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.9031334F));
            tableLayoutPanelToy.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 66.09686F));
            tableLayoutPanelToy.Controls.Add(labelProducer, 0, 0);
            tableLayoutPanelToy.Controls.Add(labelAge, 0, 1);
            tableLayoutPanelToy.Controls.Add(textBoxProducer, 1, 0);
            tableLayoutPanelToy.Controls.Add(textBoxAge, 1, 1);
            tableLayoutPanelToy.Dock = DockStyle.Fill;
            tableLayoutPanelToy.Location = new Point(3, 119);
            tableLayoutPanelToy.Name = "tableLayoutPanelToy";
            tableLayoutPanelToy.RowCount = 2;
            tableLayoutPanelToy.RowStyles.Add(new RowStyle(SizeType.Percent, 36.231884F));
            tableLayoutPanelToy.RowStyles.Add(new RowStyle(SizeType.Percent, 63.768116F));
            tableLayoutPanelToy.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanelToy.Size = new Size(388, 70);
            tableLayoutPanelToy.TabIndex = 4;
            tableLayoutPanelToy.Visible = false;
            // 
            // labelProducer
            // 
            labelProducer.AutoSize = true;
            labelProducer.Dock = DockStyle.Fill;
            labelProducer.Location = new Point(3, 0);
            labelProducer.Name = "labelProducer";
            labelProducer.Size = new Size(125, 25);
            labelProducer.TabIndex = 8;
            labelProducer.Text = "Изготовитель:";
            // 
            // labelAge
            // 
            labelAge.AutoSize = true;
            labelAge.Dock = DockStyle.Fill;
            labelAge.Location = new Point(3, 25);
            labelAge.Name = "labelAge";
            labelAge.Size = new Size(125, 45);
            labelAge.TabIndex = 11;
            labelAge.Text = "Возрастное \r\nограничение (..+):";
            // 
            // textBoxProducer
            // 
            textBoxProducer.Dock = DockStyle.Fill;
            textBoxProducer.Location = new Point(134, 3);
            textBoxProducer.Name = "textBoxProducer";
            textBoxProducer.Size = new Size(251, 23);
            textBoxProducer.TabIndex = 5;
            // 
            // textBoxAge
            // 
            textBoxAge.Dock = DockStyle.Fill;
            textBoxAge.Location = new Point(134, 28);
            textBoxAge.Name = "textBoxAge";
            textBoxAge.Size = new Size(251, 23);
            textBoxAge.TabIndex = 6;
            textBoxAge.Leave += textBoxAge_Leave;
            // 
            // tableLayoutPanelProduct
            // 
            tableLayoutPanelProduct.ColumnCount = 2;
            tableLayoutPanelProduct.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.9031334F));
            tableLayoutPanelProduct.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 66.09686F));
            tableLayoutPanelProduct.Controls.Add(labelComposition, 0, 0);
            tableLayoutPanelProduct.Controls.Add(labelDate, 0, 1);
            tableLayoutPanelProduct.Controls.Add(textBoxDate, 1, 1);
            tableLayoutPanelProduct.Controls.Add(textBoxComposition, 1, 0);
            tableLayoutPanelProduct.Dock = DockStyle.Fill;
            tableLayoutPanelProduct.Location = new Point(3, 195);
            tableLayoutPanelProduct.Name = "tableLayoutPanelProduct";
            tableLayoutPanelProduct.RowCount = 2;
            tableLayoutPanelProduct.RowStyles.Add(new RowStyle(SizeType.Percent, 43.103447F));
            tableLayoutPanelProduct.RowStyles.Add(new RowStyle(SizeType.Percent, 56.896553F));
            tableLayoutPanelProduct.Size = new Size(388, 60);
            tableLayoutPanelProduct.TabIndex = 5;
            tableLayoutPanelProduct.Visible = false;
            // 
            // labelComposition
            // 
            labelComposition.AutoSize = true;
            labelComposition.Dock = DockStyle.Fill;
            labelComposition.Location = new Point(3, 0);
            labelComposition.Name = "labelComposition";
            labelComposition.Size = new Size(125, 25);
            labelComposition.TabIndex = 22;
            labelComposition.Text = "Состав:";
            // 
            // labelDate
            // 
            labelDate.AutoSize = true;
            labelDate.Dock = DockStyle.Fill;
            labelDate.Location = new Point(3, 25);
            labelDate.Name = "labelDate";
            labelDate.Size = new Size(125, 35);
            labelDate.TabIndex = 24;
            labelDate.Text = "До конца срока \r\n(дня(ей)):";
            // 
            // textBoxDate
            // 
            textBoxDate.Dock = DockStyle.Fill;
            textBoxDate.Location = new Point(134, 28);
            textBoxDate.Name = "textBoxDate";
            textBoxDate.Size = new Size(251, 23);
            textBoxDate.TabIndex = 8;
            textBoxDate.Leave += textBoxDate_Leave;
            // 
            // textBoxComposition
            // 
            textBoxComposition.Dock = DockStyle.Fill;
            textBoxComposition.Location = new Point(134, 3);
            textBoxComposition.Name = "textBoxComposition";
            textBoxComposition.Size = new Size(251, 23);
            textBoxComposition.TabIndex = 7;
            // 
            // tableLayoutPanelMilkProduct
            // 
            tableLayoutPanelMilkProduct.ColumnCount = 4;
            tableLayoutPanelMilkProduct.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanelMilkProduct.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanelMilkProduct.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.8148146F));
            tableLayoutPanelMilkProduct.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35.6125374F));
            tableLayoutPanelMilkProduct.Controls.Add(labelLactoseFree, 0, 0);
            tableLayoutPanelMilkProduct.Controls.Add(comboBoxLactoseFree, 1, 0);
            tableLayoutPanelMilkProduct.Controls.Add(comboBoxBMJ, 3, 0);
            tableLayoutPanelMilkProduct.Controls.Add(labelBMJ, 2, 0);
            tableLayoutPanelMilkProduct.Dock = DockStyle.Fill;
            tableLayoutPanelMilkProduct.Location = new Point(3, 261);
            tableLayoutPanelMilkProduct.Name = "tableLayoutPanelMilkProduct";
            tableLayoutPanelMilkProduct.RowCount = 1;
            tableLayoutPanelMilkProduct.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelMilkProduct.Size = new Size(388, 51);
            tableLayoutPanelMilkProduct.TabIndex = 6;
            tableLayoutPanelMilkProduct.Visible = false;
            // 
            // labelLactoseFree
            // 
            labelLactoseFree.AutoSize = true;
            labelLactoseFree.Dock = DockStyle.Fill;
            labelLactoseFree.Location = new Point(3, 0);
            labelLactoseFree.Name = "labelLactoseFree";
            labelLactoseFree.Size = new Size(90, 51);
            labelLactoseFree.TabIndex = 26;
            labelLactoseFree.Text = "Без лактозы:";
            // 
            // comboBoxLactoseFree
            // 
            comboBoxLactoseFree.Dock = DockStyle.Left;
            comboBoxLactoseFree.FormattingEnabled = true;
            comboBoxLactoseFree.ItemHeight = 15;
            comboBoxLactoseFree.Items.AddRange(new object[] { "Да", "Нет" });
            comboBoxLactoseFree.Location = new Point(99, 3);
            comboBoxLactoseFree.Name = "comboBoxLactoseFree";
            comboBoxLactoseFree.Size = new Size(53, 23);
            comboBoxLactoseFree.TabIndex = 9;
            // 
            // comboBoxBMJ
            // 
            comboBoxBMJ.Dock = DockStyle.Left;
            comboBoxBMJ.FormattingEnabled = true;
            comboBoxBMJ.ItemHeight = 15;
            comboBoxBMJ.Items.AddRange(new object[] { "Да", "Нет" });
            comboBoxBMJ.Location = new Point(252, 3);
            comboBoxBMJ.Name = "comboBoxBMJ";
            comboBoxBMJ.Size = new Size(56, 23);
            comboBoxBMJ.TabIndex = 10;
            // 
            // labelBMJ
            // 
            labelBMJ.AutoSize = true;
            labelBMJ.Dock = DockStyle.Fill;
            labelBMJ.Location = new Point(195, 0);
            labelBMJ.Name = "labelBMJ";
            labelBMJ.Size = new Size(51, 51);
            labelBMJ.TabIndex = 28;
            labelBMJ.Text = "БМЖ:";
            // 
            // tableLayoutPanelFilter
            // 
            tableLayoutPanelFilter.ColumnCount = 2;
            tableLayoutPanelFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 234F));
            tableLayoutPanelFilter.Controls.Add(comboBoxFiltrField, 1, 0);
            tableLayoutPanelFilter.Controls.Add(labelFiltr, 0, 1);
            tableLayoutPanelFilter.Controls.Add(labelFiltrField, 0, 0);
            tableLayoutPanelFilter.Controls.Add(textBoxFiltr, 1, 1);
            tableLayoutPanelFilter.Dock = DockStyle.Fill;
            tableLayoutPanelFilter.Location = new Point(3, 435);
            tableLayoutPanelFilter.Name = "tableLayoutPanelFilter";
            tableLayoutPanelFilter.RowCount = 2;
            tableLayoutPanelFilter.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelFilter.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelFilter.Size = new Size(394, 57);
            tableLayoutPanelFilter.TabIndex = 15;
            // 
            // comboBoxFiltrField
            // 
            comboBoxFiltrField.Dock = DockStyle.Fill;
            comboBoxFiltrField.FormattingEnabled = true;
            comboBoxFiltrField.Items.AddRange(new object[] { "Название", "Цена", "Количество" });
            comboBoxFiltrField.Location = new Point(163, 3);
            comboBoxFiltrField.Name = "comboBoxFiltrField";
            comboBoxFiltrField.Size = new Size(228, 23);
            comboBoxFiltrField.TabIndex = 12;
            // 
            // labelFiltr
            // 
            labelFiltr.AutoSize = true;
            labelFiltr.Dock = DockStyle.Fill;
            labelFiltr.Location = new Point(3, 28);
            labelFiltr.Name = "labelFiltr";
            labelFiltr.Size = new Size(154, 29);
            labelFiltr.TabIndex = 17;
            labelFiltr.Text = "Фильтр";
            // 
            // labelFiltrField
            // 
            labelFiltrField.AutoSize = true;
            labelFiltrField.Dock = DockStyle.Fill;
            labelFiltrField.Location = new Point(3, 0);
            labelFiltrField.Name = "labelFiltrField";
            labelFiltrField.Size = new Size(154, 28);
            labelFiltrField.TabIndex = 15;
            labelFiltrField.Text = "Фильтр по полю:";
            // 
            // textBoxFiltr
            // 
            textBoxFiltr.Dock = DockStyle.Fill;
            textBoxFiltr.Location = new Point(163, 31);
            textBoxFiltr.Name = "textBoxFiltr";
            textBoxFiltr.Size = new Size(228, 23);
            textBoxFiltr.TabIndex = 13;
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new Size(32, 19);
            файлToolStripMenuItem.Text = "Файл";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1189, 628);
            Controls.Add(splitContainer);
            Controls.Add(menuStrip);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MainMenuStrip = menuStrip;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ООП16 (Работа с файлами)";
            Shown += MainForm_Shown;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel1.PerformLayout();
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            groupBoxParam.ResumeLayout(false);
            tableLayoutPanelParam.ResumeLayout(false);
            tableLayoutPanelButton.ResumeLayout(false);
            tableLayoutPanelSorted.ResumeLayout(false);
            tableLayoutPanelSorted.PerformLayout();
            tableLayoutPanelTypeObj.ResumeLayout(false);
            tableLayoutPanelTypeObj.PerformLayout();
            tableLayoutPanelObjectFields.ResumeLayout(false);
            tableLayoutPanelObjectFields.PerformLayout();
            tableLayoutPanelGoods.ResumeLayout(false);
            tableLayoutPanelGoods.PerformLayout();
            tableLayoutPanelToy.ResumeLayout(false);
            tableLayoutPanelToy.PerformLayout();
            tableLayoutPanelProduct.ResumeLayout(false);
            tableLayoutPanelProduct.PerformLayout();
            tableLayoutPanelMilkProduct.ResumeLayout(false);
            tableLayoutPanelMilkProduct.PerformLayout();
            tableLayoutPanelFilter.ResumeLayout(false);
            tableLayoutPanelFilter.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip;
        private ToolStripMenuItem MenuFile;
        private ToolStripMenuItem OpenFile;
        private ToolStripMenuItem SaveFile;
        private ToolStripMenuItem MenuCollection;
        private ToolStripMenuItem AddRandInCollection;
        private ToolStripMenuItem MenuRequests;
        private ToolStripMenuItem MenuJournal;
        private ToolStripMenuItem MenuReport;
        private ToolStripMenuItem AveragePrice;
        private ToolStripMenuItem MaxPrice;
        private ToolStripMenuItem OpenJournal;
        private ToolStripMenuItem OpenReport;
        private SplitContainer splitContainer;
        private ComboBox comboBoxTypeObj;
        private Label labelTypeObj;
        private Label labelCount;
        private TextBox textBoxProducer;
        private Label labelProducer;
        private TextBox textBoxCount;
        private Label labelPrice;
        private TextBox textBoxPrice;
        private Label labelName;
        private TextBox textBoxName;
        private Label labelObjectFields;
        private TextBox textBoxAge;
        private Label labelAge;
        private ComboBox comboBoxSort;
        private Label labelFiltrField;
        private Label labelSort;
        private Label labelOperations;
        private Button buttonUpdate;
        private Button buttonAdd;
        private Label labelBMJ;
        private ComboBox comboBoxLactoseFree;
        private Label labelLactoseFree;
        private GroupBox groupBoxParam;
        private Label labelComposition;
        private TextBox textBoxComposition;
        private Label labelDate;
        private TextBox textBoxDate;
        private TableLayoutPanel tableLayoutPanelTypeObj;
        private TableLayoutPanel tableLayoutPanelObjectFields;

        /*private TableLayoutPanel tableLayoutPanel3;*/
        /*private Panel panel1;*/

        private TableLayoutPanel tableLayoutPanelGoods;
        private TableLayoutPanel tableLayoutPanelToy;
        private TableLayoutPanel tableLayoutPanelProduct;
        private TableLayoutPanel tableLayoutPanelMilkProduct;
        private Button buttonApply;
        private TableLayoutPanel tableLayoutPanelButton;

        private TableLayoutPanel tableLayoutPanelParam;
        private TableLayoutPanel tableLayoutPanelSorted;
        private ComboBox comboBoxBMJ;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem DeleteFromCollection;
        private ComboBox comboBoxFiltrField;
        private Label labelFiltr;
        private TextBox textBoxFiltr;
        private ToolStripMenuItem коллекцияToolStripMenuItem;
        private ToolStripMenuItem запросыToolStripMenuItem;
        private ToolStripMenuItem MinPrice;
        private ToolStripMenuItem журналToolStripMenuItem;
        private ToolStripMenuItem отчетToolStripMenuItem;
        private ToolStripMenuItem SearchInCollection;
        private TextBox textBox_outputWindow;
        private TableLayoutPanel tableLayoutPanelFilter;
        private ToolStripMenuItem CurrentCollection;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem файлToolStripMenuItem1;
        private ToolStripMenuItem OpenCollection;
        private ToolStripMenuItem SaveCollection;
        private ToolStripMenuItem NewCollection;
    }
}
