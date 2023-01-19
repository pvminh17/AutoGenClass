namespace AutoGenClass
{
    partial class Converter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Converter));
            this.tboxSrc = new System.Windows.Forms.RichTextBox();
            this.tboxDes = new System.Windows.Forms.RichTextBox();
            this.btnDLLtoJavaClass = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tboxSrc
            // 
            this.tboxSrc.Location = new System.Drawing.Point(12, 83);
            this.tboxSrc.Name = "tboxSrc";
            this.tboxSrc.Size = new System.Drawing.Size(541, 538);
            this.tboxSrc.TabIndex = 0;
            this.tboxSrc.Text = "";
            // 
            // tboxDes
            // 
            this.tboxDes.Location = new System.Drawing.Point(612, 83);
            this.tboxDes.Name = "tboxDes";
            this.tboxDes.Size = new System.Drawing.Size(541, 538);
            this.tboxDes.TabIndex = 1;
            this.tboxDes.Text = "";
            // 
            // btnDLLtoJavaClass
            // 
            this.btnDLLtoJavaClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDLLtoJavaClass.Location = new System.Drawing.Point(12, 22);
            this.btnDLLtoJavaClass.Name = "btnDLLtoJavaClass";
            this.btnDLLtoJavaClass.Size = new System.Drawing.Size(223, 35);
            this.btnDLLtoJavaClass.TabIndex = 2;
            this.btnDLLtoJavaClass.Text = "DDL to Java properties";
            this.btnDLLtoJavaClass.UseVisualStyleBackColor = true;
            this.btnDLLtoJavaClass.Click += new System.EventHandler(this.btnDLLtoJavaClass_Click);
            // 
            // Converter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 640);
            this.Controls.Add(this.btnDLLtoJavaClass);
            this.Controls.Add(this.tboxDes);
            this.Controls.Add(this.tboxSrc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Converter";
            this.Text = "Converter v.0.1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox tboxSrc;
        private System.Windows.Forms.RichTextBox tboxDes;
        private System.Windows.Forms.Button btnDLLtoJavaClass;
    }
}

