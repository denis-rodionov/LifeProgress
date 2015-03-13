namespace TaskLibrary
{
    partial class MyTracker
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
            this.tracker = new System.Windows.Forms.TrackBar();
            this.lblPercent = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tracker)).BeginInit();
            this.SuspendLayout();
            // 
            // tracker
            // 
            this.tracker.Location = new System.Drawing.Point(169, 0);
            this.tracker.Maximum = 100;
            this.tracker.Name = "tracker";
            this.tracker.Size = new System.Drawing.Size(212, 45);
            this.tracker.TabIndex = 5;
            this.tracker.Value = 10;
            this.tracker.Scroll += new System.EventHandler(this.tracker_Scroll);
            // 
            // lblPercent
            // 
            this.lblPercent.AutoSize = true;
            this.lblPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPercent.Location = new System.Drawing.Point(387, 0);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(62, 26);
            this.lblPercent.TabIndex = 4;
            this.lblPercent.Text = "60 %";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblName.Location = new System.Drawing.Point(3, 4);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(87, 20);
            this.lblName.TabIndex = 6;
            this.lblName.Text = "Field name";
            // 
            // MyTracker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.tracker);
            this.Controls.Add(this.lblPercent);
            this.Name = "MyTracker";
            this.Size = new System.Drawing.Size(453, 33);
            this.Load += new System.EventHandler(this.MyTracker_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tracker)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar tracker;
        private System.Windows.Forms.Label lblPercent;
        private System.Windows.Forms.Label lblName;
    }
}
