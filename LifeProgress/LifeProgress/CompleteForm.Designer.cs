namespace LifeProgress
{
    partial class CompleteForm
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
            this.txbValue = new System.Windows.Forms.TextBox();
            this.trkValue = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDone = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trkValue)).BeginInit();
            this.SuspendLayout();
            // 
            // txbValue
            // 
            this.txbValue.Location = new System.Drawing.Point(63, 12);
            this.txbValue.Name = "txbValue";
            this.txbValue.Size = new System.Drawing.Size(31, 20);
            this.txbValue.TabIndex = 0;
            this.txbValue.Text = "100";
            // 
            // trkValue
            // 
            this.trkValue.Location = new System.Drawing.Point(12, -1);
            this.trkValue.Maximum = 100;
            this.trkValue.Name = "trkValue";
            this.trkValue.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trkValue.Size = new System.Drawing.Size(45, 104);
            this.trkValue.TabIndex = 3;
            this.trkValue.TickFrequency = 10;
            this.trkValue.Value = 100;
            this.trkValue.Scroll += new System.EventHandler(this.trkValue_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(100, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "%";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(63, 39);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(80, 30);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Œ ";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(121, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(22, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "X";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(63, 75);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(79, 27);
            this.btnDone.TabIndex = 2;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // CompleteForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(157, 107);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trkValue);
            this.Controls.Add(this.txbValue);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CompleteForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CompleteForm";
            this.Load += new System.EventHandler(this.CompleteForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trkValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbValue;
        private System.Windows.Forms.TrackBar trkValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDone;
    }
}