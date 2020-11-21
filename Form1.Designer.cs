namespace fhl
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
        /// 
        
        
        private void InitializeComponent()
        {
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.видToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.прокруткаВКонсолиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.горизонтальнаяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.очиститьКонсольToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.форматToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.словариToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.точкиВходаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.переменныеФорматаСтрокиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nGINXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.кодыHTTPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.форматЛогаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.шаблонСтрокиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.конецСтрокиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unixToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.анализToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.начатьАнализToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вебСерверToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nginxToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.валидацияФорматаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.тестовыйВыводСтрокToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.целиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ошибки5xxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sqlInjectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xSSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pathTraversalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.режимОтладкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вОзможностиСистемыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CoreLog = new System.Windows.Forms.RichTextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog_mainForm = new System.Windows.Forms.OpenFileDialog();
            this.backgroundWorker_loaddata = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 539);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(752, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar1.Visible = false;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabel2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(50, 17);
            this.toolStripStatusLabel2.Text = "Отмена";
            this.toolStripStatusLabel2.Visible = false;
            this.toolStripStatusLabel2.Click += new System.EventHandler(this.toolStripStatusLabel2_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Khaki;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.видToolStripMenuItem,
            this.форматToolStripMenuItem,
            this.анализToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(752, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // видToolStripMenuItem
            // 
            this.видToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.прокруткаВКонсолиToolStripMenuItem,
            this.очиститьКонсольToolStripMenuItem});
            this.видToolStripMenuItem.Name = "видToolStripMenuItem";
            this.видToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.видToolStripMenuItem.Text = "Вид";
            // 
            // прокруткаВКонсолиToolStripMenuItem
            // 
            this.прокруткаВКонсолиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.горизонтальнаяToolStripMenuItem});
            this.прокруткаВКонсолиToolStripMenuItem.Name = "прокруткаВКонсолиToolStripMenuItem";
            this.прокруткаВКонсолиToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.прокруткаВКонсолиToolStripMenuItem.Text = "Прокрутка в консоли";
            // 
            // горизонтальнаяToolStripMenuItem
            // 
            this.горизонтальнаяToolStripMenuItem.CheckOnClick = true;
            this.горизонтальнаяToolStripMenuItem.Name = "горизонтальнаяToolStripMenuItem";
            this.горизонтальнаяToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.горизонтальнаяToolStripMenuItem.Text = "Горизонтальная";
            this.горизонтальнаяToolStripMenuItem.Click += new System.EventHandler(this.горизонтальнаяToolStripMenuItem_Click);
            // 
            // очиститьКонсольToolStripMenuItem
            // 
            this.очиститьКонсольToolStripMenuItem.Name = "очиститьКонсольToolStripMenuItem";
            this.очиститьКонсольToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.очиститьКонсольToolStripMenuItem.Text = "Очистить консоль";
            this.очиститьКонсольToolStripMenuItem.Click += new System.EventHandler(this.очиститьКонсольToolStripMenuItem_Click);
            // 
            // форматToolStripMenuItem
            // 
            this.форматToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.словариToolStripMenuItem,
            this.настройкиToolStripMenuItem,
            this.форматЛогаToolStripMenuItem});
            this.форматToolStripMenuItem.Name = "форматToolStripMenuItem";
            this.форматToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.форматToolStripMenuItem.Text = "Формат";
            // 
            // словариToolStripMenuItem
            // 
            this.словариToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.точкиВходаToolStripMenuItem,
            this.переменныеФорматаСтрокиToolStripMenuItem,
            this.кодыHTTPToolStripMenuItem});
            this.словариToolStripMenuItem.Name = "словариToolStripMenuItem";
            this.словариToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.словариToolStripMenuItem.Text = "Словари";
            // 
            // точкиВходаToolStripMenuItem
            // 
            this.точкиВходаToolStripMenuItem.Name = "точкиВходаToolStripMenuItem";
            this.точкиВходаToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.точкиВходаToolStripMenuItem.Text = "Точки входа";
            // 
            // переменныеФорматаСтрокиToolStripMenuItem
            // 
            this.переменныеФорматаСтрокиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nGINXToolStripMenuItem});
            this.переменныеФорматаСтрокиToolStripMenuItem.Name = "переменныеФорматаСтрокиToolStripMenuItem";
            this.переменныеФорматаСтрокиToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.переменныеФорматаСтрокиToolStripMenuItem.Text = "Переменные формата строки";
            // 
            // nGINXToolStripMenuItem
            // 
            this.nGINXToolStripMenuItem.Name = "nGINXToolStripMenuItem";
            this.nGINXToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.nGINXToolStripMenuItem.Text = "NGINX";
            // 
            // кодыHTTPToolStripMenuItem
            // 
            this.кодыHTTPToolStripMenuItem.Name = "кодыHTTPToolStripMenuItem";
            this.кодыHTTPToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.кодыHTTPToolStripMenuItem.Text = "Коды HTTP";
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            // 
            // форматЛогаToolStripMenuItem
            // 
            this.форматЛогаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.шаблонСтрокиToolStripMenuItem,
            this.конецСтрокиToolStripMenuItem});
            this.форматЛогаToolStripMenuItem.Name = "форматЛогаToolStripMenuItem";
            this.форматЛогаToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.форматЛогаToolStripMenuItem.Text = "Формат лога";
            // 
            // шаблонСтрокиToolStripMenuItem
            // 
            this.шаблонСтрокиToolStripMenuItem.Name = "шаблонСтрокиToolStripMenuItem";
            this.шаблонСтрокиToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.шаблонСтрокиToolStripMenuItem.Text = "Шаблон строки";
            this.шаблонСтрокиToolStripMenuItem.Click += new System.EventHandler(this.шаблонСтрокиToolStripMenuItem_Click);
            // 
            // конецСтрокиToolStripMenuItem
            // 
            this.конецСтрокиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.windowsToolStripMenuItem,
            this.unixToolStripMenuItem});
            this.конецСтрокиToolStripMenuItem.Name = "конецСтрокиToolStripMenuItem";
            this.конецСтрокиToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.конецСтрокиToolStripMenuItem.Text = "Конец строки";
            // 
            // windowsToolStripMenuItem
            // 
            this.windowsToolStripMenuItem.Checked = true;
            this.windowsToolStripMenuItem.CheckOnClick = true;
            this.windowsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.windowsToolStripMenuItem.Name = "windowsToolStripMenuItem";
            this.windowsToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.windowsToolStripMenuItem.Text = "Windows";
            this.windowsToolStripMenuItem.Click += new System.EventHandler(this.windowsToolStripMenuItem_Click);
            // 
            // unixToolStripMenuItem
            // 
            this.unixToolStripMenuItem.Name = "unixToolStripMenuItem";
            this.unixToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.unixToolStripMenuItem.Text = "Unix";
            this.unixToolStripMenuItem.Click += new System.EventHandler(this.unixToolStripMenuItem_Click);
            // 
            // анализToolStripMenuItem
            // 
            this.анализToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.начатьАнализToolStripMenuItem,
            this.вебСерверToolStripMenuItem,
            this.валидацияФорматаToolStripMenuItem,
            this.тестовыйВыводСтрокToolStripMenuItem,
            this.целиToolStripMenuItem});
            this.анализToolStripMenuItem.Name = "анализToolStripMenuItem";
            this.анализToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.анализToolStripMenuItem.Text = "Анализ";
            // 
            // начатьАнализToolStripMenuItem
            // 
            this.начатьАнализToolStripMenuItem.Name = "начатьАнализToolStripMenuItem";
            this.начатьАнализToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.начатьАнализToolStripMenuItem.Text = "Начать анализ";
            this.начатьАнализToolStripMenuItem.Click += new System.EventHandler(this.начатьАнализToolStripMenuItem_Click);
            // 
            // вебСерверToolStripMenuItem
            // 
            this.вебСерверToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nginxToolStripMenuItem1});
            this.вебСерверToolStripMenuItem.Name = "вебСерверToolStripMenuItem";
            this.вебСерверToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.вебСерверToolStripMenuItem.Text = "Веб сервер";
            // 
            // nginxToolStripMenuItem1
            // 
            this.nginxToolStripMenuItem1.Checked = true;
            this.nginxToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.nginxToolStripMenuItem1.Name = "nginxToolStripMenuItem1";
            this.nginxToolStripMenuItem1.Size = new System.Drawing.Size(106, 22);
            this.nginxToolStripMenuItem1.Text = "Nginx";
            // 
            // валидацияФорматаToolStripMenuItem
            // 
            this.валидацияФорматаToolStripMenuItem.Name = "валидацияФорматаToolStripMenuItem";
            this.валидацияФорматаToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.валидацияФорматаToolStripMenuItem.Text = "Валидация формата";
            this.валидацияФорматаToolStripMenuItem.Click += new System.EventHandler(this.валидацияФорматаToolStripMenuItem_Click);
            // 
            // тестовыйВыводСтрокToolStripMenuItem
            // 
            this.тестовыйВыводСтрокToolStripMenuItem.Name = "тестовыйВыводСтрокToolStripMenuItem";
            this.тестовыйВыводСтрокToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.тестовыйВыводСтрокToolStripMenuItem.Text = "Тестовый вывод строк";
            this.тестовыйВыводСтрокToolStripMenuItem.Click += new System.EventHandler(this.тестовыйВыводСтрокToolStripMenuItem_Click);
            // 
            // целиToolStripMenuItem
            // 
            this.целиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ошибки5xxToolStripMenuItem,
            this.sqlInjectionToolStripMenuItem,
            this.xSSToolStripMenuItem,
            this.pathTraversalToolStripMenuItem});
            this.целиToolStripMenuItem.Name = "целиToolStripMenuItem";
            this.целиToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.целиToolStripMenuItem.Text = "Цели";
            // 
            // ошибки5xxToolStripMenuItem
            // 
            this.ошибки5xxToolStripMenuItem.Name = "ошибки5xxToolStripMenuItem";
            this.ошибки5xxToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.ошибки5xxToolStripMenuItem.Text = "Ошибки 5xx";
            // 
            // sqlInjectionToolStripMenuItem
            // 
            this.sqlInjectionToolStripMenuItem.Name = "sqlInjectionToolStripMenuItem";
            this.sqlInjectionToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.sqlInjectionToolStripMenuItem.Text = "Sql-Injection";
            // 
            // xSSToolStripMenuItem
            // 
            this.xSSToolStripMenuItem.Name = "xSSToolStripMenuItem";
            this.xSSToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.xSSToolStripMenuItem.Text = "XSS";
            // 
            // pathTraversalToolStripMenuItem
            // 
            this.pathTraversalToolStripMenuItem.Name = "pathTraversalToolStripMenuItem";
            this.pathTraversalToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.pathTraversalToolStripMenuItem.Text = "Path Traversal";
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.режимОтладкиToolStripMenuItem,
            this.вОзможностиСистемыToolStripMenuItem});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // режимОтладкиToolStripMenuItem
            // 
            this.режимОтладкиToolStripMenuItem.Name = "режимОтладкиToolStripMenuItem";
            this.режимОтладкиToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.режимОтладкиToolStripMenuItem.Text = "Режим отладки";
            // 
            // вОзможностиСистемыToolStripMenuItem
            // 
            this.вОзможностиСистемыToolStripMenuItem.Name = "вОзможностиСистемыToolStripMenuItem";
            this.вОзможностиСистемыToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.вОзможностиСистемыToolStripMenuItem.Text = "Возможности системы";
            this.вОзможностиСистемыToolStripMenuItem.Click += new System.EventHandler(this.вОзможностиСистемыToolStripMenuItem_Click);
            // 
            // CoreLog
            // 
            this.CoreLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CoreLog.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CoreLog.Location = new System.Drawing.Point(0, 24);
            this.CoreLog.Name = "CoreLog";
            this.CoreLog.ReadOnly = true;
            this.CoreLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.CoreLog.Size = new System.Drawing.Size(752, 515);
            this.CoreLog.TabIndex = 2;
            this.CoreLog.Text = "";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // backgroundWorker_loaddata
            // 
            this.backgroundWorker_loaddata.WorkerReportsProgress = true;
            this.backgroundWorker_loaddata.WorkerSupportsCancellation = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 561);
            this.Controls.Add(this.CoreLog);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(768, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fox Hunter Log";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem форматToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem словариToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem точкиВходаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem переменныеФорматаСтрокиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem анализToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem начатьАнализToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem кодыHTTPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        public System.Windows.Forms.RichTextBox CoreLog;
        private System.Windows.Forms.ToolStripMenuItem nGINXToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вебСерверToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nginxToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem форматЛогаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem режимОтладкиToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem валидацияФорматаToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog_mainForm;
        private System.ComponentModel.BackgroundWorker backgroundWorker_loaddata;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripMenuItem шаблонСтрокиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem конецСтрокиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unixToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripMenuItem тестовыйВыводСтрокToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem видToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem прокруткаВКонсолиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem горизонтальнаяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem очиститьКонсольToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem целиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ошибки5xxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sqlInjectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xSSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pathTraversalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вОзможностиСистемыToolStripMenuItem;
    }
}

