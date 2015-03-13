namespace TaskLibrary
{
    partial class CheckTask
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
            this.lblNumber = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblDay = new System.Windows.Forms.Label();
            this.lblDebt = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Location = new System.Drawing.Point(3, 0);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(16, 13);
            this.lblNumber.TabIndex = 0;
            this.lblNumber.Text = "1)";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(25, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(200, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Название запланированного задания";
            // 
            // lblDay
            // 
            this.lblDay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDay.Location = new System.Drawing.Point(371, 0);
            this.lblDay.Name = "lblDay";
            this.lblDay.Size = new System.Drawing.Size(121, 13);
            this.lblDay.TabIndex = 1;
            this.lblDay.Text = "Воскресение";
            this.lblDay.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblDebt
            // 
            this.lblDebt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDebt.AutoSize = true;
            this.lblDebt.Location = new System.Drawing.Point(498, 0);
            this.lblDebt.Name = "lblDebt";
            this.lblDebt.Size = new System.Drawing.Size(11, 13);
            this.lblDebt.TabIndex = 2;
            this.lblDebt.Text = "*";
            // 
            // CheckTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblDebt);
            this.Controls.Add(this.lblDay);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblNumber);
            this.Name = "CheckTask";
            this.Size = new System.Drawing.Size(512, 17);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDay;
        private System.Windows.Forms.Label lblDebt;
    }
}
