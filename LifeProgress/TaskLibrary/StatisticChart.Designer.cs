namespace TaskLibrary
{
    partial class StatisticChart
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.groupMain = new System.Windows.Forms.GroupBox();
            this.ddlPeriod = new System.Windows.Forms.ComboBox();
            this.chartMain = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartMain)).BeginInit();
            this.SuspendLayout();
            // 
            // groupMain
            // 
            this.groupMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupMain.Controls.Add(this.ddlPeriod);
            this.groupMain.Controls.Add(this.chartMain);
            this.groupMain.Location = new System.Drawing.Point(3, 3);
            this.groupMain.Name = "groupMain";
            this.groupMain.Size = new System.Drawing.Size(509, 305);
            this.groupMain.TabIndex = 1;
            this.groupMain.TabStop = false;
            this.groupMain.Text = "По неделям";
            // 
            // ddlPeriod
            // 
            this.ddlPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlPeriod.FormattingEnabled = true;
            this.ddlPeriod.Items.AddRange(new object[] {
            "За месяц",
            "За два месяца"});
            this.ddlPeriod.Location = new System.Drawing.Point(326, 278);
            this.ddlPeriod.Name = "ddlPeriod";
            this.ddlPeriod.Size = new System.Drawing.Size(177, 21);
            this.ddlPeriod.TabIndex = 1;
            this.ddlPeriod.SelectedIndexChanged += new System.EventHandler(this.ddlPeriod_SelectedIndexChanged);
            // 
            // chartMain
            // 
            this.chartMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chartMain.ChartAreas.Add(chartArea1);
            this.chartMain.Location = new System.Drawing.Point(6, 19);
            this.chartMain.Name = "chartMain";
            this.chartMain.Size = new System.Drawing.Size(497, 252);
            this.chartMain.TabIndex = 0;
            this.chartMain.Text = "chart1";
            // 
            // StatisticChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupMain);
            this.MinimumSize = new System.Drawing.Size(200, 170);
            this.Name = "StatisticChart";
            this.Size = new System.Drawing.Size(521, 311);
            this.Load += new System.EventHandler(this.StatisticChart_Load);
            this.groupMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupMain;
        private System.Windows.Forms.ComboBox ddlPeriod;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMain;
    }
}
