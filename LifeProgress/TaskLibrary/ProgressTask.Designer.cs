namespace TaskLibrary
{
    partial class ProgressTask
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
            this.lblName = new System.Windows.Forms.Label();
            this.prgStatus = new System.Windows.Forms.ProgressBar();
            this.lblNumber = new System.Windows.Forms.Label();
            this.lblPercents = new System.Windows.Forms.Label();
            this.lblDebt = new System.Windows.Forms.Label();
            this.lblCur = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblName.Location = new System.Drawing.Point(25, 2);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(263, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Название регулярного задания";
            // 
            // prgStatus
            // 
            this.prgStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.prgStatus.Location = new System.Drawing.Point(357, 3);
            this.prgStatus.Name = "prgStatus";
            this.prgStatus.Size = new System.Drawing.Size(103, 12);
            this.prgStatus.TabIndex = 1;
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Location = new System.Drawing.Point(3, 2);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(16, 13);
            this.lblNumber.TabIndex = 0;
            this.lblNumber.Text = "0)";
            // 
            // lblPercents
            // 
            this.lblPercents.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPercents.AutoSize = true;
            this.lblPercents.Location = new System.Drawing.Point(466, 2);
            this.lblPercents.Name = "lblPercents";
            this.lblPercents.Size = new System.Drawing.Size(36, 13);
            this.lblPercents.TabIndex = 0;
            this.lblPercents.Text = "100 %";
            // 
            // lblDebt
            // 
            this.lblDebt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDebt.AutoSize = true;
            this.lblDebt.Location = new System.Drawing.Point(347, 3);
            this.lblDebt.Name = "lblDebt";
            this.lblDebt.Size = new System.Drawing.Size(11, 13);
            this.lblDebt.TabIndex = 3;
            this.lblDebt.Text = "*";
            // 
            // lblCur
            // 
            this.lblCur.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCur.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCur.Location = new System.Drawing.Point(285, 2);
            this.lblCur.Name = "lblCur";
            this.lblCur.Size = new System.Drawing.Size(25, 13);
            this.lblCur.TabIndex = 4;
            this.lblCur.Text = "0";
            this.lblCur.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFrom
            // 
            this.lblFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(306, 2);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(19, 13);
            this.lblFrom.TabIndex = 4;
            this.lblFrom.Text = "из";
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTotal.Location = new System.Drawing.Point(320, 2);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(25, 13);
            this.lblTotal.TabIndex = 4;
            this.lblTotal.Text = "111";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ProgressTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.lblCur);
            this.Controls.Add(this.lblDebt);
            this.Controls.Add(this.prgStatus);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.lblPercents);
            this.Controls.Add(this.lblName);
            this.MaximumSize = new System.Drawing.Size(0, 20);
            this.MinimumSize = new System.Drawing.Size(500, 20);
            this.Name = "ProgressTask";
            this.Size = new System.Drawing.Size(500, 20);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.ProgressBar prgStatus;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Label lblPercents;
        private System.Windows.Forms.Label lblDebt;
        private System.Windows.Forms.Label lblCur;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblTotal;
    }
}
