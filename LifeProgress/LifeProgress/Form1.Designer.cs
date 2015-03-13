namespace LifeProgress
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tabWeek = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.prgStatus = new System.Windows.Forms.ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblTime = new System.Windows.Forms.Label();
            this.calMain = new System.Windows.Forms.MonthCalendar();
            this.btnToday = new System.Windows.Forms.Button();
            this.btnCurrent = new System.Windows.Forms.Button();
            this.prgWeek = new System.Windows.Forms.ProgressBar();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.grpWeek = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNumber = new System.Windows.Forms.Label();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tabStatistics = new System.Windows.Forms.TabPage();
            this.ctxCommon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmiComplete = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiFiertSep = new System.Windows.Forms.ToolStripSeparator();
            this.cmiAddTask = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiEditTask = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiRemoveTask = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmiNewField = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiRenameField = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiRemoveField = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.weekView = new TaskLibrary.WeekView();
            this.fmControl = new TaskLibrary.FieldCoefficients();
            this.mainStat = new TaskLibrary.StatisticChart();
            this.tcMain.SuspendLayout();
            this.tabWeek.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpWeek.SuspendLayout();
            this.tabSettings.SuspendLayout();
            this.tabStatistics.SuspendLayout();
            this.ctxCommon.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcMain
            // 
            this.tcMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tcMain.Controls.Add(this.tabWeek);
            this.tcMain.Controls.Add(this.tabSettings);
            this.tcMain.Controls.Add(this.tabStatistics);
            this.tcMain.Location = new System.Drawing.Point(3, 2);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(909, 590);
            this.tcMain.TabIndex = 0;
            // 
            // tabWeek
            // 
            this.tabWeek.BackColor = System.Drawing.SystemColors.Window;
            this.tabWeek.Controls.Add(this.groupBox4);
            this.tabWeek.Controls.Add(this.groupBox2);
            this.tabWeek.Controls.Add(this.btnToday);
            this.tabWeek.Controls.Add(this.btnCurrent);
            this.tabWeek.Controls.Add(this.prgWeek);
            this.tabWeek.Controls.Add(this.btnNext);
            this.tabWeek.Controls.Add(this.btnPrev);
            this.tabWeek.Controls.Add(this.grpWeek);
            this.tabWeek.Location = new System.Drawing.Point(4, 22);
            this.tabWeek.Name = "tabWeek";
            this.tabWeek.Padding = new System.Windows.Forms.Padding(3);
            this.tabWeek.Size = new System.Drawing.Size(901, 564);
            this.tabWeek.TabIndex = 0;
            this.tabWeek.Text = "Неделя";
            this.tabWeek.SizeChanged += new System.EventHandler(this.tabWeek_SizeChanged);
            this.tabWeek.Enter += new System.EventHandler(this.tabWeek_Enter);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.weekView);
            this.groupBox4.Controls.Add(this.prgStatus);
            this.groupBox4.Controls.Add(this.lblStatus);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Location = new System.Drawing.Point(6, 183);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(213, 93);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Прогресс";
            // 
            // prgStatus
            // 
            this.prgStatus.Location = new System.Drawing.Point(6, 40);
            this.prgStatus.Name = "prgStatus";
            this.prgStatus.Size = new System.Drawing.Size(201, 21);
            this.prgStatus.TabIndex = 4;
            this.prgStatus.Value = 36;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblStatus.ForeColor = System.Drawing.Color.Red;
            this.lblStatus.Location = new System.Drawing.Point(129, 8);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(78, 29);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "100%";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(0, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 19);
            this.label5.TabIndex = 1;
            this.label5.Text = "Рейтинг недели:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblTime);
            this.groupBox2.Controls.Add(this.calMain);
            this.groupBox2.Location = new System.Drawing.Point(6, 282);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(213, 205);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Календарь";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTime.Location = new System.Drawing.Point(82, 183);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(49, 17);
            this.lblTime.TabIndex = 4;
            this.lblTime.Text = "17:08";
            // 
            // calMain
            // 
            this.calMain.FirstDayOfWeek = System.Windows.Forms.Day.Monday;
            this.calMain.Location = new System.Drawing.Point(6, 25);
            this.calMain.MaxSelectionCount = 1;
            this.calMain.Name = "calMain";
            this.calMain.ShowWeekNumbers = true;
            this.calMain.TabIndex = 3;
            this.calMain.TitleBackColor = System.Drawing.Color.Teal;
            this.calMain.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.calMain_DateSelected);
            // 
            // btnToday
            // 
            this.btnToday.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnToday.Location = new System.Drawing.Point(6, 147);
            this.btnToday.Name = "btnToday";
            this.btnToday.Size = new System.Drawing.Size(213, 30);
            this.btnToday.TabIndex = 5;
            this.btnToday.Text = "Сегодня";
            this.btnToday.UseVisualStyleBackColor = true;
            this.btnToday.Click += new System.EventHandler(this.btnToday_Click);
            // 
            // btnCurrent
            // 
            this.btnCurrent.Location = new System.Drawing.Point(41, 117);
            this.btnCurrent.Name = "btnCurrent";
            this.btnCurrent.Size = new System.Drawing.Size(143, 24);
            this.btnCurrent.TabIndex = 5;
            this.btnCurrent.Text = "Текущая";
            this.btnCurrent.UseVisualStyleBackColor = true;
            this.btnCurrent.Click += new System.EventHandler(this.btnCurrent_Click);
            // 
            // prgWeek
            // 
            this.prgWeek.Location = new System.Drawing.Point(6, 101);
            this.prgWeek.Name = "prgWeek";
            this.prgWeek.Size = new System.Drawing.Size(213, 10);
            this.prgWeek.TabIndex = 4;
            this.prgWeek.Value = 36;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(190, 117);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(29, 24);
            this.btnNext.TabIndex = 5;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(6, 117);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(29, 24);
            this.btnPrev.TabIndex = 5;
            this.btnPrev.Text = "<";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // grpWeek
            // 
            this.grpWeek.Controls.Add(this.label2);
            this.grpWeek.Controls.Add(this.lblYear);
            this.grpWeek.Controls.Add(this.label1);
            this.grpWeek.Controls.Add(this.lblNumber);
            this.grpWeek.Location = new System.Drawing.Point(6, 6);
            this.grpWeek.Name = "grpWeek";
            this.grpWeek.Size = new System.Drawing.Size(213, 89);
            this.grpWeek.TabIndex = 2;
            this.grpWeek.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(6, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "Год: ";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblYear.Location = new System.Drawing.Point(127, 50);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(74, 31);
            this.lblYear.TabIndex = 1;
            this.lblYear.Text = "2008";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Неделя :";
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblNumber.ForeColor = System.Drawing.Color.Red;
            this.lblNumber.Location = new System.Drawing.Point(137, 12);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(64, 46);
            this.lblNumber.TabIndex = 1;
            this.lblNumber.Text = "43";
            // 
            // tabSettings
            // 
            this.tabSettings.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tabSettings.Controls.Add(this.fmControl);
            this.tabSettings.Controls.Add(this.btnCancel);
            this.tabSettings.Controls.Add(this.btnSave);
            this.tabSettings.Location = new System.Drawing.Point(4, 22);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettings.Size = new System.Drawing.Size(901, 564);
            this.tabSettings.TabIndex = 1;
            this.tabSettings.Text = "Настройки";
            this.tabSettings.Enter += new System.EventHandler(this.tabSettings_Enter);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCancel.Location = new System.Drawing.Point(687, 62);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(204, 50);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Отменить";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSave.ForeColor = System.Drawing.Color.Green;
            this.btnSave.Location = new System.Drawing.Point(687, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(204, 50);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tabStatistics
            // 
            this.tabStatistics.Controls.Add(this.mainStat);
            this.tabStatistics.Location = new System.Drawing.Point(4, 22);
            this.tabStatistics.Name = "tabStatistics";
            this.tabStatistics.Size = new System.Drawing.Size(901, 564);
            this.tabStatistics.TabIndex = 2;
            this.tabStatistics.Text = "Статистика";
            this.tabStatistics.UseVisualStyleBackColor = true;
            // 
            // ctxCommon
            // 
            this.ctxCommon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmiComplete,
            this.cmiFiertSep,
            this.cmiAddTask,
            this.cmiEditTask,
            this.cmiRemoveTask,
            this.cmiSep1,
            this.cmiNewField,
            this.cmiRenameField,
            this.cmiRemoveField});
            this.ctxCommon.Name = "ctxCommon";
            this.ctxCommon.Size = new System.Drawing.Size(209, 170);
            this.ctxCommon.Opening += new System.ComponentModel.CancelEventHandler(this.ctxCommon_Opening);
            // 
            // cmiComplete
            // 
            this.cmiComplete.Name = "cmiComplete";
            this.cmiComplete.Size = new System.Drawing.Size(208, 22);
            this.cmiComplete.Text = "Выполнить задание";
            this.cmiComplete.Click += new System.EventHandler(this.cmiComplete_Click);
            // 
            // cmiFiertSep
            // 
            this.cmiFiertSep.Name = "cmiFiertSep";
            this.cmiFiertSep.Size = new System.Drawing.Size(205, 6);
            // 
            // cmiAddTask
            // 
            this.cmiAddTask.Name = "cmiAddTask";
            this.cmiAddTask.Size = new System.Drawing.Size(208, 22);
            this.cmiAddTask.Text = "Добавить задание";
            this.cmiAddTask.Click += new System.EventHandler(this.cmiAddTask_Click);
            // 
            // cmiEditTask
            // 
            this.cmiEditTask.Name = "cmiEditTask";
            this.cmiEditTask.Size = new System.Drawing.Size(208, 22);
            this.cmiEditTask.Text = "Редактировать задание";
            this.cmiEditTask.Click += new System.EventHandler(this.cmiEditTask_Click);
            // 
            // cmiRemoveTask
            // 
            this.cmiRemoveTask.Name = "cmiRemoveTask";
            this.cmiRemoveTask.Size = new System.Drawing.Size(208, 22);
            this.cmiRemoveTask.Text = "Удалить задание";
            this.cmiRemoveTask.Click += new System.EventHandler(this.cmiRemoveTask_Click);
            // 
            // cmiSep1
            // 
            this.cmiSep1.Name = "cmiSep1";
            this.cmiSep1.Size = new System.Drawing.Size(205, 6);
            // 
            // cmiNewField
            // 
            this.cmiNewField.Name = "cmiNewField";
            this.cmiNewField.Size = new System.Drawing.Size(208, 22);
            this.cmiNewField.Text = "Новая область";
            this.cmiNewField.Click += new System.EventHandler(this.cmiNewField_Click);
            // 
            // cmiRenameField
            // 
            this.cmiRenameField.Name = "cmiRenameField";
            this.cmiRenameField.Size = new System.Drawing.Size(208, 22);
            this.cmiRenameField.Text = "Переименовать область";
            this.cmiRenameField.Click += new System.EventHandler(this.cmiRenameField_Click);
            // 
            // cmiRemoveField
            // 
            this.cmiRemoveField.Name = "cmiRemoveField";
            this.cmiRemoveField.Size = new System.Drawing.Size(208, 22);
            this.cmiRemoveField.Text = "Удалить область";
            this.cmiRemoveField.Click += new System.EventHandler(this.cmiRemoveField_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // weekView
            // 
            this.weekView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.weekView.Location = new System.Drawing.Point(4, 67);
            this.weekView.Name = "weekView";
            this.weekView.Size = new System.Drawing.Size(207, 17);
            this.weekView.TabIndex = 5;
            // 
            // fmControl
            // 
            this.fmControl.Location = new System.Drawing.Point(6, 6);
            this.fmControl.Name = "fmControl";
            this.fmControl.Size = new System.Drawing.Size(282, 68);
            this.fmControl.TabIndex = 2;
            // 
            // mainStat
            // 
            this.mainStat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mainStat.Location = new System.Drawing.Point(5, 3);
            this.mainStat.MinimumSize = new System.Drawing.Size(200, 170);
            this.mainStat.Name = "mainStat";
            this.mainStat.Size = new System.Drawing.Size(890, 556);
            this.mainStat.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AcceptButton = this.btnToday;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 595);
            this.ContextMenuStrip = this.ctxCommon;
            this.Controls.Add(this.tcMain);
            this.DoubleBuffered = true;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Жизненный тонус";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tcMain.ResumeLayout(false);
            this.tabWeek.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpWeek.ResumeLayout(false);
            this.grpWeek.PerformLayout();
            this.tabSettings.ResumeLayout(false);
            this.tabStatistics.ResumeLayout(false);
            this.ctxCommon.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tabWeek;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.MonthCalendar calMain;
        private System.Windows.Forms.Button btnCurrent;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.ProgressBar prgWeek;
        private System.Windows.Forms.GroupBox grpWeek;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ProgressBar prgStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Button btnToday;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ContextMenuStrip ctxCommon;
        private System.Windows.Forms.ToolStripMenuItem cmiAddTask;
        private System.Windows.Forms.ToolStripMenuItem cmiEditTask;
        private System.Windows.Forms.ToolStripMenuItem cmiRemoveTask;
        private System.Windows.Forms.ToolStripSeparator cmiSep1;
        private System.Windows.Forms.ToolStripMenuItem cmiNewField;
        private System.Windows.Forms.ToolStripMenuItem cmiRemoveField;
        private System.Windows.Forms.ToolStripMenuItem cmiRenameField;
        private System.Windows.Forms.ToolStripMenuItem cmiComplete;
        private System.Windows.Forms.ToolStripSeparator cmiFiertSep;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private TaskLibrary.WeekView weekView;
        private System.Windows.Forms.TabPage tabStatistics;
        private TaskLibrary.StatisticChart mainStat;
        private TaskLibrary.FieldCoefficients fmControl;
    }
}

