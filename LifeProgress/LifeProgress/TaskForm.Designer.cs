namespace LifeProgress
{
    partial class frmTask
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
            this.numWeek = new System.Windows.Forms.NumericUpDown();
            this.numYear = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblWeek = new System.Windows.Forms.Label();
            this.cmbField = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkRepeating = new System.Windows.Forms.CheckBox();
            this.chkNumberTask = new System.Windows.Forms.CheckBox();
            this.txbName = new System.Windows.Forms.TextBox();
            this.chkDay = new System.Windows.Forms.CheckBox();
            this.chkDebt = new System.Windows.Forms.CheckBox();
            this.numCount = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.lblSuperImportant = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.trkLevel = new System.Windows.Forms.TrackBar();
            this.lblNormal = new System.Windows.Forms.Label();
            this.lblNotImportant = new System.Windows.Forms.Label();
            this.lblLowImportance = new System.Windows.Forms.Label();
            this.lblImportant = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numWeek)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCount)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // numWeek
            // 
            this.numWeek.Location = new System.Drawing.Point(68, 19);
            this.numWeek.Maximum = new decimal(new int[] {
            52,
            0,
            0,
            0});
            this.numWeek.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numWeek.Name = "numWeek";
            this.numWeek.Size = new System.Drawing.Size(58, 20);
            this.numWeek.TabIndex = 0;
            this.numWeek.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numWeek.ValueChanged += new System.EventHandler(this.numWeek_ValueChanged);
            // 
            // numYear
            // 
            this.numYear.Location = new System.Drawing.Point(68, 45);
            this.numYear.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.numYear.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numYear.Name = "numYear";
            this.numYear.Size = new System.Drawing.Size(58, 20);
            this.numYear.TabIndex = 0;
            this.numYear.Value = new decimal(new int[] {
            2008,
            0,
            0,
            0});
            this.numYear.ValueChanged += new System.EventHandler(this.numWeek_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Неделя";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Год:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblWeek);
            this.groupBox1.Controls.Add(this.numWeek);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.numYear);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(144, 100);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Время";
            // 
            // lblWeek
            // 
            this.lblWeek.AutoSize = true;
            this.lblWeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblWeek.Location = new System.Drawing.Point(24, 68);
            this.lblWeek.Name = "lblWeek";
            this.lblWeek.Size = new System.Drawing.Size(84, 24);
            this.lblWeek.TabIndex = 2;
            this.lblWeek.Text = "Текущая";
            // 
            // cmbField
            // 
            this.cmbField.FormattingEnabled = true;
            this.cmbField.Location = new System.Drawing.Point(154, 21);
            this.cmbField.Name = "cmbField";
            this.cmbField.Size = new System.Drawing.Size(262, 21);
            this.cmbField.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Область задач:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkRepeating);
            this.groupBox2.Controls.Add(this.chkNumberTask);
            this.groupBox2.Controls.Add(this.txbName);
            this.groupBox2.Controls.Add(this.chkDay);
            this.groupBox2.Controls.Add(this.chkDebt);
            this.groupBox2.Controls.Add(this.numCount);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cmbField);
            this.groupBox2.Location = new System.Drawing.Point(12, 194);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(459, 144);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Параметры задачи";
            // 
            // chkRepeating
            // 
            this.chkRepeating.AutoSize = true;
            this.chkRepeating.Location = new System.Drawing.Point(19, 78);
            this.chkRepeating.Name = "chkRepeating";
            this.chkRepeating.Size = new System.Drawing.Size(107, 17);
            this.chkRepeating.TabIndex = 7;
            this.chkRepeating.Text = "Каждую неделю";
            this.chkRepeating.UseVisualStyleBackColor = true;
            // 
            // chkNumberTask
            // 
            this.chkNumberTask.AutoSize = true;
            this.chkNumberTask.Location = new System.Drawing.Point(19, 103);
            this.chkNumberTask.Name = "chkNumberTask";
            this.chkNumberTask.Size = new System.Drawing.Size(153, 17);
            this.chkNumberTask.TabIndex = 6;
            this.chkNumberTask.Text = "Несколько раз в неделю";
            this.chkNumberTask.UseVisualStyleBackColor = true;
            this.chkNumberTask.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // txbName
            // 
            this.txbName.Location = new System.Drawing.Point(154, 48);
            this.txbName.Name = "txbName";
            this.txbName.Size = new System.Drawing.Size(261, 20);
            this.txbName.TabIndex = 0;
            // 
            // chkDay
            // 
            this.chkDay.AutoSize = true;
            this.chkDay.Checked = true;
            this.chkDay.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDay.Enabled = false;
            this.chkDay.Location = new System.Drawing.Point(319, 103);
            this.chkDay.Name = "chkDay";
            this.chkDay.Size = new System.Drawing.Size(109, 17);
            this.chkDay.TabIndex = 3;
            this.chkDay.Text = "Один раз в день";
            this.chkDay.UseVisualStyleBackColor = true;
            // 
            // chkDebt
            // 
            this.chkDebt.AutoSize = true;
            this.chkDebt.Enabled = false;
            this.chkDebt.Location = new System.Drawing.Point(173, 78);
            this.chkDebt.Name = "chkDebt";
            this.chkDebt.Size = new System.Drawing.Size(122, 17);
            this.chkDebt.TabIndex = 4;
            this.chkDebt.Text = "Переносить в долг";
            this.chkDebt.UseVisualStyleBackColor = true;
            // 
            // numCount
            // 
            this.numCount.Enabled = false;
            this.numCount.Location = new System.Drawing.Point(191, 101);
            this.numCount.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCount.Name = "numCount";
            this.numCount.Size = new System.Drawing.Size(122, 20);
            this.numCount.TabIndex = 2;
            this.numCount.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Название:";
            // 
            // lblSuperImportant
            // 
            this.lblSuperImportant.AutoSize = true;
            this.lblSuperImportant.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSuperImportant.ForeColor = System.Drawing.Color.Navy;
            this.lblSuperImportant.Location = new System.Drawing.Point(143, 29);
            this.lblSuperImportant.Name = "lblSuperImportant";
            this.lblSuperImportant.Size = new System.Drawing.Size(92, 15);
            this.lblSuperImportant.TabIndex = 0;
            this.lblSuperImportant.Text = "Супер важно";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.trkLevel);
            this.groupBox4.Controls.Add(this.lblNormal);
            this.groupBox4.Controls.Add(this.lblNotImportant);
            this.groupBox4.Controls.Add(this.lblLowImportance);
            this.groupBox4.Controls.Add(this.lblImportant);
            this.groupBox4.Controls.Add(this.lblSuperImportant);
            this.groupBox4.Location = new System.Drawing.Point(166, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(305, 181);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Сложность задания";
            // 
            // trkLevel
            // 
            this.trkLevel.Location = new System.Drawing.Point(92, 21);
            this.trkLevel.Maximum = 100;
            this.trkLevel.Minimum = 1;
            this.trkLevel.Name = "trkLevel";
            this.trkLevel.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trkLevel.Size = new System.Drawing.Size(45, 128);
            this.trkLevel.TabIndex = 0;
            this.trkLevel.Value = 20;
            // 
            // lblNormal
            // 
            this.lblNormal.AutoSize = true;
            this.lblNormal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblNormal.ForeColor = System.Drawing.Color.Green;
            this.lblNormal.Location = new System.Drawing.Point(143, 79);
            this.lblNormal.Name = "lblNormal";
            this.lblNormal.Size = new System.Drawing.Size(83, 15);
            this.lblNormal.TabIndex = 0;
            this.lblNormal.Text = "Нормально";
            // 
            // lblNotImportant
            // 
            this.lblNotImportant.AutoSize = true;
            this.lblNotImportant.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblNotImportant.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblNotImportant.Location = new System.Drawing.Point(143, 129);
            this.lblNotImportant.Name = "lblNotImportant";
            this.lblNotImportant.Size = new System.Drawing.Size(154, 15);
            this.lblNotImportant.TabIndex = 0;
            this.lblNotImportant.Text = "В последнюю очередь";
            // 
            // lblLowImportance
            // 
            this.lblLowImportance.AutoSize = true;
            this.lblLowImportance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLowImportance.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblLowImportance.Location = new System.Drawing.Point(143, 104);
            this.lblLowImportance.Name = "lblLowImportance";
            this.lblLowImportance.Size = new System.Drawing.Size(131, 15);
            this.lblLowImportance.TabIndex = 0;
            this.lblLowImportance.Text = "Низкий приоритет";
            // 
            // lblImportant
            // 
            this.lblImportant.AutoSize = true;
            this.lblImportant.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblImportant.ForeColor = System.Drawing.Color.Blue;
            this.lblImportant.Location = new System.Drawing.Point(143, 53);
            this.lblImportant.Name = "lblImportant";
            this.lblImportant.Size = new System.Drawing.Size(50, 15);
            this.lblImportant.TabIndex = 0;
            this.lblImportant.Text = "Важно";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(12, 118);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(144, 33);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Добавить";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(12, 157);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(144, 33);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmTask
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 349);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmTask";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.frmTask_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numWeek)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCount)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkLevel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numWeek;
        private System.Windows.Forms.NumericUpDown numYear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblWeek;
        private System.Windows.Forms.ComboBox cmbField;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txbName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkDebt;
        private System.Windows.Forms.Label lblSuperImportant;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TrackBar trkLevel;
        private System.Windows.Forms.Label lblNormal;
        private System.Windows.Forms.Label lblLowImportance;
        private System.Windows.Forms.Label lblImportant;
        private System.Windows.Forms.Label lblNotImportant;
        private System.Windows.Forms.CheckBox chkDay;
        private System.Windows.Forms.NumericUpDown numCount;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkNumberTask;
        private System.Windows.Forms.CheckBox chkRepeating;
    }
}