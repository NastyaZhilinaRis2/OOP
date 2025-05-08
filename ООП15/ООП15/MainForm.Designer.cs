namespace ООП15
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            label_number_team = new Label();
            button_start = new Button();
            DGV_game_data = new DataGridView();
            Column_name = new DataGridViewTextBoxColumn();
            Column_count_wins = new DataGridViewTextBoxColumn();
            Column_count_losses = new DataGridViewTextBoxColumn();
            Column_priority = new DataGridViewTextBoxColumn();
            button_finish = new Button();
            label_pool_fighters = new Label();
            textBox__pool_fighters = new TextBox();
            textBox__number_team = new TextBox();
            ((System.ComponentModel.ISupportInitialize)DGV_game_data).BeginInit();
            SuspendLayout();
            // 
            // label_number_team
            // 
            label_number_team.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label_number_team.AutoSize = true;
            label_number_team.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label_number_team.Location = new Point(33, 43);
            label_number_team.Name = "label_number_team";
            label_number_team.Size = new Size(154, 21);
            label_number_team.TabIndex = 0;
            label_number_team.Text = "Количество команд:";
            // 
            // button_start
            // 
            button_start.Anchor = AnchorStyles.Bottom;
            button_start.BackColor = Color.FromArgb(192, 255, 192);
            button_start.Font = new Font("Segoe UI", 12F);
            button_start.Location = new Point(338, 523);
            button_start.Name = "button_start";
            button_start.Size = new Size(109, 45);
            button_start.TabIndex = 3;
            button_start.Text = "Начать";
            button_start.UseVisualStyleBackColor = false;
            button_start.Click += button_start_Click;
            // 
            // DGV_game_data
            // 
            DGV_game_data.AllowUserToAddRows = false;
            DGV_game_data.AllowUserToDeleteRows = false;
            DGV_game_data.AllowUserToResizeColumns = false;
            DGV_game_data.AllowUserToResizeRows = false;
            DGV_game_data.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DGV_game_data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = Color.MistyRose;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            DGV_game_data.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            DGV_game_data.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_game_data.Columns.AddRange(new DataGridViewColumn[] { Column_name, Column_count_wins, Column_count_losses, Column_priority });
            DGV_game_data.Location = new Point(33, 98);
            DGV_game_data.Name = "DGV_game_data";
            DGV_game_data.ReadOnly = true;
            DGV_game_data.ScrollBars = ScrollBars.Vertical;
            DGV_game_data.Size = new Size(755, 401);
            DGV_game_data.TabIndex = 5;
            // 
            // Column_name
            // 
            Column_name.HeaderText = "Название команды";
            Column_name.Name = "Column_name";
            Column_name.ReadOnly = true;
            // 
            // Column_count_wins
            // 
            Column_count_wins.HeaderText = "Победы";
            Column_count_wins.Name = "Column_count_wins";
            Column_count_wins.ReadOnly = true;
            // 
            // Column_count_losses
            // 
            Column_count_losses.HeaderText = "Поражения";
            Column_count_losses.Name = "Column_count_losses";
            Column_count_losses.ReadOnly = true;
            // 
            // Column_priority
            // 
            Column_priority.HeaderText = "Приоритет";
            Column_priority.Name = "Column_priority";
            Column_priority.ReadOnly = true;
            // 
            // button_finish
            // 
            button_finish.Anchor = AnchorStyles.Bottom;
            button_finish.BackColor = Color.FromArgb(255, 192, 192);
            button_finish.Font = new Font("Segoe UI", 12F);
            button_finish.Location = new Point(667, 523);
            button_finish.Name = "button_finish";
            button_finish.Size = new Size(109, 45);
            button_finish.TabIndex = 4;
            button_finish.Text = "Стоп";
            button_finish.UseVisualStyleBackColor = false;
            button_finish.Click += button_finish_Click;
            // 
            // label_pool_fighters
            // 
            label_pool_fighters.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label_pool_fighters.AutoSize = true;
            label_pool_fighters.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label_pool_fighters.Location = new Point(384, 43);
            label_pool_fighters.Name = "label_pool_fighters";
            label_pool_fighters.Size = new Size(193, 21);
            label_pool_fighters.TabIndex = 5;
            label_pool_fighters.Text = "Количество бойцов (пул):";
            // 
            // textBox__pool_fighters
            // 
            textBox__pool_fighters.Font = new Font("Segoe UI", 12F);
            textBox__pool_fighters.Location = new Point(583, 40);
            textBox__pool_fighters.Name = "textBox__pool_fighters";
            textBox__pool_fighters.Size = new Size(100, 29);
            textBox__pool_fighters.TabIndex = 2;
            // 
            // textBox__number_team
            // 
            textBox__number_team.Font = new Font("Segoe UI", 12F);
            textBox__number_team.Location = new Point(207, 40);
            textBox__number_team.Name = "textBox__number_team";
            textBox__number_team.Size = new Size(100, 29);
            textBox__number_team.TabIndex = 1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 580);
            Controls.Add(textBox__number_team);
            Controls.Add(textBox__pool_fighters);
            Controls.Add(label_pool_fighters);
            Controls.Add(button_finish);
            Controls.Add(DGV_game_data);
            Controls.Add(button_start);
            Controls.Add(label_number_team);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Противостояние команд";
            ((System.ComponentModel.ISupportInitialize)DGV_game_data).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_number_team;
        private Button button_start;
        private DataGridView DGV_game_data;
        private Button button_finish;
        private Label label_pool_fighters;
        private TextBox textBox__pool_fighters;
        private TextBox textBox__number_team;
        private DataGridViewTextBoxColumn Column_name;
        private DataGridViewTextBoxColumn Column_count_wins;
        private DataGridViewTextBoxColumn Column_count_losses;
        private DataGridViewTextBoxColumn Column_priority;
    }
}
