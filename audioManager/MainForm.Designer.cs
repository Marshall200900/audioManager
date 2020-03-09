namespace audioManager
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.table = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьФайлыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьПапкуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.импортироватьНаУстройствоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.запросToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вывестиСписокПесенToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вывестиСписокАльбомовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вывестиСписокИсполнителейToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.импортироватьВExcelФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.upperPanel = new System.Windows.Forms.Panel();
            this.zeroitMetroButton2 = new Zeroit.Framework.Metro.ZeroitMetroButton();
            this.zeroitMetroButton1 = new Zeroit.Framework.Metro.ZeroitMetroButton();
            this.btnSave = new Zeroit.Framework.Metro.ZeroitMetroButton();
            this.zeroitMetroButton4 = new Zeroit.Framework.Metro.ZeroitMetroButton();
            this.settingsButton = new Zeroit.Framework.Metro.ZeroitMetroButton();
            this.zeroitMetroButton6 = new Zeroit.Framework.Metro.ZeroitMetroButton();
            this.zeroitMetroButton3 = new Zeroit.Framework.Metro.ZeroitMetroButton();
            this.dragControl1 = new BaseApp_TabControl.DragControl();
            ((System.ComponentModel.ISupportInitialize)(this.table)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.upperPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // table
            // 
            this.table.AllowUserToAddRows = false;
            this.table.AllowUserToDeleteRows = false;
            this.table.AllowUserToResizeColumns = false;
            this.table.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(24)))), ((int)(((byte)(35)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.table.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.table.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(24)))), ((int)(((byte)(35)))));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.table.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.table.EnableHeadersVisualStyles = false;
            this.table.GridColor = System.Drawing.Color.White;
            this.table.Location = new System.Drawing.Point(12, 100);
            this.table.Name = "table";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.table.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(24)))), ((int)(((byte)(35)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.table.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.table.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.table.Size = new System.Drawing.Size(756, 351);
            this.table.TabIndex = 0;
            this.table.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.table_CellBeginEdit);
            this.table.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.table_CellContentClick);
            this.table.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.table_CellEndEdit);
            this.table.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.table_CellValidating);
            this.table.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.table_CellValueChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.запросToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 30);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(780, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.файлToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьФайлыToolStripMenuItem,
            this.добавитьПапкуToolStripMenuItem,
            this.импортироватьНаУстройствоToolStripMenuItem});
            this.файлToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // добавитьФайлыToolStripMenuItem
            // 
            this.добавитьФайлыToolStripMenuItem.Name = "добавитьФайлыToolStripMenuItem";
            this.добавитьФайлыToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.добавитьФайлыToolStripMenuItem.Text = "Добавить файлы";
            this.добавитьФайлыToolStripMenuItem.Click += new System.EventHandler(this.добавитьФайлыToolStripMenuItem_Click);
            // 
            // добавитьПапкуToolStripMenuItem
            // 
            this.добавитьПапкуToolStripMenuItem.Name = "добавитьПапкуToolStripMenuItem";
            this.добавитьПапкуToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.добавитьПапкуToolStripMenuItem.Text = "Добавить папку";
            this.добавитьПапкуToolStripMenuItem.Click += new System.EventHandler(this.добавитьПапкуToolStripMenuItem_Click);
            // 
            // импортироватьНаУстройствоToolStripMenuItem
            // 
            this.импортироватьНаУстройствоToolStripMenuItem.Name = "импортироватьНаУстройствоToolStripMenuItem";
            this.импортироватьНаУстройствоToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.импортироватьНаУстройствоToolStripMenuItem.Text = "Импортировать на устройство";
            // 
            // запросToolStripMenuItem
            // 
            this.запросToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.вывестиСписокПесенToolStripMenuItem,
            this.вывестиСписокАльбомовToolStripMenuItem,
            this.вывестиСписокИсполнителейToolStripMenuItem,
            this.импортироватьВExcelФайлToolStripMenuItem});
            this.запросToolStripMenuItem.Name = "запросToolStripMenuItem";
            this.запросToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.запросToolStripMenuItem.Text = "Запрос";
            // 
            // вывестиСписокПесенToolStripMenuItem
            // 
            this.вывестиСписокПесенToolStripMenuItem.Name = "вывестиСписокПесенToolStripMenuItem";
            this.вывестиСписокПесенToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.вывестиСписокПесенToolStripMenuItem.Text = "Вывести список песен";
            this.вывестиСписокПесенToolStripMenuItem.Click += new System.EventHandler(this.вывестиСписокПесенToolStripMenuItem_Click);
            // 
            // вывестиСписокАльбомовToolStripMenuItem
            // 
            this.вывестиСписокАльбомовToolStripMenuItem.Name = "вывестиСписокАльбомовToolStripMenuItem";
            this.вывестиСписокАльбомовToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.вывестиСписокАльбомовToolStripMenuItem.Text = "Вывести список альбомов";
            this.вывестиСписокАльбомовToolStripMenuItem.Click += new System.EventHandler(this.вывестиСписокАльбомовToolStripMenuItem_Click);
            // 
            // вывестиСписокИсполнителейToolStripMenuItem
            // 
            this.вывестиСписокИсполнителейToolStripMenuItem.Name = "вывестиСписокИсполнителейToolStripMenuItem";
            this.вывестиСписокИсполнителейToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.вывестиСписокИсполнителейToolStripMenuItem.Text = "Вывести список исполнителей";
            this.вывестиСписокИсполнителейToolStripMenuItem.Click += new System.EventHandler(this.вывестиСписокИсполнителейToolStripMenuItem_Click);
            // 
            // импортироватьВExcelФайлToolStripMenuItem
            // 
            this.импортироватьВExcelФайлToolStripMenuItem.Name = "импортироватьВExcelФайлToolStripMenuItem";
            this.импортироватьВExcelФайлToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.импортироватьВExcelФайлToolStripMenuItem.Text = "Импортировать в Excel файл";
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оПрограммеToolStripMenuItem});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            // 
            // searchBox
            // 
            this.searchBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.searchBox.Location = new System.Drawing.Point(587, 74);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(100, 20);
            this.searchBox.TabIndex = 3;
            // 
            // upperPanel
            // 
            this.upperPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(28)))), ((int)(((byte)(47)))));
            this.upperPanel.Controls.Add(this.zeroitMetroButton2);
            this.upperPanel.Controls.Add(this.zeroitMetroButton1);
            this.upperPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.upperPanel.Location = new System.Drawing.Point(0, 0);
            this.upperPanel.Name = "upperPanel";
            this.upperPanel.Size = new System.Drawing.Size(780, 30);
            this.upperPanel.TabIndex = 8;
            // 
            // zeroitMetroButton2
            // 
            this.zeroitMetroButton2.BackColor = System.Drawing.Color.Turquoise;
            this.zeroitMetroButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.zeroitMetroButton2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(28)))), ((int)(((byte)(47)))));
            this.zeroitMetroButton2.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(163)))), ((int)(((byte)(20)))));
            this.zeroitMetroButton2.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.zeroitMetroButton2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.zeroitMetroButton2.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(163)))), ((int)(((byte)(20)))));
            this.zeroitMetroButton2.Location = new System.Drawing.Point(730, 5);
            this.zeroitMetroButton2.Name = "zeroitMetroButton2";
            this.zeroitMetroButton2.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(20)))));
            this.zeroitMetroButton2.RoundingArc = 20;
            this.zeroitMetroButton2.Size = new System.Drawing.Size(20, 20);
            this.zeroitMetroButton2.TabIndex = 10;
            this.zeroitMetroButton2.Click += new System.EventHandler(this.zeroitMetroButton2_Click);
            // 
            // zeroitMetroButton1
            // 
            this.zeroitMetroButton1.BackColor = System.Drawing.Color.Turquoise;
            this.zeroitMetroButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.zeroitMetroButton1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(28)))), ((int)(((byte)(47)))));
            this.zeroitMetroButton1.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.zeroitMetroButton1.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.zeroitMetroButton1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.zeroitMetroButton1.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.zeroitMetroButton1.Location = new System.Drawing.Point(755, 5);
            this.zeroitMetroButton1.Name = "zeroitMetroButton1";
            this.zeroitMetroButton1.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.zeroitMetroButton1.RoundingArc = 20;
            this.zeroitMetroButton1.Size = new System.Drawing.Size(20, 20);
            this.zeroitMetroButton1.TabIndex = 9;
            this.zeroitMetroButton1.Click += new System.EventHandler(this.zeroitMetroButton1_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSave.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(98)))), ((int)(((byte)(98)))));
            this.btnSave.DefaultColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSave.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSave.HoverColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSave.Icon = ((System.Drawing.Image)(resources.GetObject("btnSave.Icon")));
            this.btnSave.Location = new System.Drawing.Point(0, 60);
            this.btnSave.Name = "btnSave";
            this.btnSave.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(92)))), ((int)(((byte)(136)))));
            this.btnSave.RoundingArc = 23;
            this.btnSave.Size = new System.Drawing.Size(33, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Click += new System.EventHandler(this.button2_Click);
            // 
            // zeroitMetroButton4
            // 
            this.zeroitMetroButton4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.zeroitMetroButton4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.zeroitMetroButton4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(98)))), ((int)(((byte)(98)))));
            this.zeroitMetroButton4.DefaultColor = System.Drawing.SystemColors.ActiveCaption;
            this.zeroitMetroButton4.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.zeroitMetroButton4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.zeroitMetroButton4.HoverColor = System.Drawing.SystemColors.ActiveCaption;
            this.zeroitMetroButton4.Location = new System.Drawing.Point(693, 74);
            this.zeroitMetroButton4.Name = "zeroitMetroButton4";
            this.zeroitMetroButton4.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(92)))), ((int)(((byte)(136)))));
            this.zeroitMetroButton4.RoundingArc = 20;
            this.zeroitMetroButton4.Size = new System.Drawing.Size(75, 20);
            this.zeroitMetroButton4.TabIndex = 11;
            this.zeroitMetroButton4.Text = "Найти";
            this.zeroitMetroButton4.Click += new System.EventHandler(this.button1_Click);
            // 
            // settingsButton
            // 
            this.settingsButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.settingsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.settingsButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(98)))), ((int)(((byte)(98)))));
            this.settingsButton.DefaultColor = System.Drawing.SystemColors.ActiveCaption;
            this.settingsButton.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.settingsButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.settingsButton.HoverColor = System.Drawing.SystemColors.ActiveCaption;
            this.settingsButton.Location = new System.Drawing.Point(39, 60);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(92)))), ((int)(((byte)(136)))));
            this.settingsButton.RoundingArc = 23;
            this.settingsButton.Size = new System.Drawing.Size(127, 23);
            this.settingsButton.TabIndex = 12;
            this.settingsButton.Text = "Настройки вывода";
            this.settingsButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // zeroitMetroButton6
            // 
            this.zeroitMetroButton6.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.zeroitMetroButton6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.zeroitMetroButton6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(98)))), ((int)(((byte)(98)))));
            this.zeroitMetroButton6.DefaultColor = System.Drawing.SystemColors.ActiveCaption;
            this.zeroitMetroButton6.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.zeroitMetroButton6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.zeroitMetroButton6.HoverColor = System.Drawing.SystemColors.ActiveCaption;
            this.zeroitMetroButton6.Location = new System.Drawing.Point(172, 60);
            this.zeroitMetroButton6.Name = "zeroitMetroButton6";
            this.zeroitMetroButton6.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(92)))), ((int)(((byte)(136)))));
            this.zeroitMetroButton6.RoundingArc = 23;
            this.zeroitMetroButton6.Size = new System.Drawing.Size(127, 23);
            this.zeroitMetroButton6.TabIndex = 13;
            this.zeroitMetroButton6.Text = "Обновить";
            this.zeroitMetroButton6.Click += new System.EventHandler(this.zeroitMetroButton6_Click);
            // 
            // zeroitMetroButton3
            // 
            this.zeroitMetroButton3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.zeroitMetroButton3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.zeroitMetroButton3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(98)))), ((int)(((byte)(98)))));
            this.zeroitMetroButton3.DefaultColor = System.Drawing.SystemColors.ActiveCaption;
            this.zeroitMetroButton3.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.zeroitMetroButton3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.zeroitMetroButton3.HoverColor = System.Drawing.SystemColors.ActiveCaption;
            this.zeroitMetroButton3.Location = new System.Drawing.Point(305, 60);
            this.zeroitMetroButton3.Name = "zeroitMetroButton3";
            this.zeroitMetroButton3.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(92)))), ((int)(((byte)(136)))));
            this.zeroitMetroButton3.RoundingArc = 23;
            this.zeroitMetroButton3.Size = new System.Drawing.Size(127, 23);
            this.zeroitMetroButton3.TabIndex = 14;
            this.zeroitMetroButton3.Text = "Удалить поле";
            this.zeroitMetroButton3.Click += new System.EventHandler(this.zeroitMetroButton3_Click);
            // 
            // dragControl1
            // 
            this.dragControl1.SelectControl = this.upperPanel;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(24)))), ((int)(((byte)(35)))));
            this.ClientSize = new System.Drawing.Size(780, 475);
            this.Controls.Add(this.zeroitMetroButton3);
            this.Controls.Add(this.zeroitMetroButton6);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.zeroitMetroButton4);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.table);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.upperPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Сохранить";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.table)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.upperPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView table;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьФайлыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьПапкуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem импортироватьНаУстройствоToolStripMenuItem;
        private System.Windows.Forms.TextBox searchBox;
        private BaseApp_TabControl.DragControl dragControl1;
        private Zeroit.Framework.Metro.ZeroitMetroButton btnSave;
        private Zeroit.Framework.Metro.ZeroitMetroButton zeroitMetroButton4;
        private Zeroit.Framework.Metro.ZeroitMetroButton settingsButton;
        private System.Windows.Forms.ToolStripMenuItem запросToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem импортироватьВExcelФайлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.Panel upperPanel;
        private Zeroit.Framework.Metro.ZeroitMetroButton zeroitMetroButton2;
        private Zeroit.Framework.Metro.ZeroitMetroButton zeroitMetroButton1;
        private System.Windows.Forms.ToolStripMenuItem вывестиСписокПесенToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вывестиСписокАльбомовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вывестиСписокИсполнителейToolStripMenuItem;
        private Zeroit.Framework.Metro.ZeroitMetroButton zeroitMetroButton6;
        private Zeroit.Framework.Metro.ZeroitMetroButton zeroitMetroButton3;
    }
}

