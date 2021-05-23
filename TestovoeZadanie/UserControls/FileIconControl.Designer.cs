
namespace TestovoeZadanie.UserControls
{
    partial class FileIconControl
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
            this.FileNameLable = new System.Windows.Forms.Label();
            this.FileRootLable = new System.Windows.Forms.Label();
            this.FilePic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.FilePic)).BeginInit();
            this.SuspendLayout();
            // 
            // FileNameLable
            // 
            this.FileNameLable.AutoSize = true;
            this.FileNameLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FileNameLable.Location = new System.Drawing.Point(86, 16);
            this.FileNameLable.Name = "FileNameLable";
            this.FileNameLable.Size = new System.Drawing.Size(41, 13);
            this.FileNameLable.TabIndex = 1;
            this.FileNameLable.Text = "label1";
            // 
            // FileRootLable
            // 
            this.FileRootLable.AutoSize = true;
            this.FileRootLable.Location = new System.Drawing.Point(86, 38);
            this.FileRootLable.Name = "FileRootLable";
            this.FileRootLable.Size = new System.Drawing.Size(35, 13);
            this.FileRootLable.TabIndex = 2;
            this.FileRootLable.Text = "label2";
            // 
            // FilePic
            // 
            this.FilePic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.FilePic.Location = new System.Drawing.Point(3, 3);
            this.FilePic.Name = "FilePic";
            this.FilePic.Size = new System.Drawing.Size(77, 75);
            this.FilePic.TabIndex = 0;
            this.FilePic.TabStop = false;
            // 
            // FileIconControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.FileRootLable);
            this.Controls.Add(this.FileNameLable);
            this.Controls.Add(this.FilePic);
            this.Name = "FileIconControl";
            this.Size = new System.Drawing.Size(209, 81);
            this.Enter += new System.EventHandler(this.FileIconControl_Enter);
            this.Leave += new System.EventHandler(this.FileIconControl_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.FilePic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox FilePic;
        private System.Windows.Forms.Label FileNameLable;
        private System.Windows.Forms.Label FileRootLable;
    }
}
