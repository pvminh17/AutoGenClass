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
            this.ToIDAO = new System.Windows.Forms.Button();
            this.buttonToDAOImpl = new System.Windows.Forms.Button();
            this.buttonToIService = new System.Windows.Forms.Button();
            this.buttonToServiceImpl = new System.Windows.Forms.Button();
            this.buttonToRequest = new System.Windows.Forms.Button();
            this.buttonToResponse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCusEntityName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAutoCamel = new System.Windows.Forms.TextBox();
            this.btnAutoCamel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tboxSrc
            // 
            this.tboxSrc.Location = new System.Drawing.Point(12, 201);
            this.tboxSrc.Name = "tboxSrc";
            this.tboxSrc.Size = new System.Drawing.Size(541, 699);
            this.tboxSrc.TabIndex = 0;
            this.tboxSrc.Text = "";
            // 
            // tboxDes
            // 
            this.tboxDes.Location = new System.Drawing.Point(601, 201);
            this.tboxDes.Name = "tboxDes";
            this.tboxDes.Size = new System.Drawing.Size(843, 699);
            this.tboxDes.TabIndex = 1;
            this.tboxDes.Text = "";
            // 
            // btnDLLtoJavaClass
            // 
            this.btnDLLtoJavaClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDLLtoJavaClass.Location = new System.Drawing.Point(12, 52);
            this.btnDLLtoJavaClass.Name = "btnDLLtoJavaClass";
            this.btnDLLtoJavaClass.Size = new System.Drawing.Size(223, 35);
            this.btnDLLtoJavaClass.TabIndex = 2;
            this.btnDLLtoJavaClass.Text = "DDL to Java properties";
            this.btnDLLtoJavaClass.UseVisualStyleBackColor = true;
            this.btnDLLtoJavaClass.Click += new System.EventHandler(this.btnDLLtoJavaClass_Click);
            // 
            // ToIDAO
            // 
            this.ToIDAO.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToIDAO.Location = new System.Drawing.Point(241, 52);
            this.ToIDAO.Name = "ToIDAO";
            this.ToIDAO.Size = new System.Drawing.Size(223, 35);
            this.ToIDAO.TabIndex = 3;
            this.ToIDAO.Text = "DDL to IDAO";
            this.ToIDAO.UseVisualStyleBackColor = true;
            this.ToIDAO.Click += new System.EventHandler(this.ToIDAO_Click);
            // 
            // buttonToDAOImpl
            // 
            this.buttonToDAOImpl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonToDAOImpl.Location = new System.Drawing.Point(470, 52);
            this.buttonToDAOImpl.Name = "buttonToDAOImpl";
            this.buttonToDAOImpl.Size = new System.Drawing.Size(223, 35);
            this.buttonToDAOImpl.TabIndex = 4;
            this.buttonToDAOImpl.Text = "DDL to DAOImpl";
            this.buttonToDAOImpl.UseVisualStyleBackColor = true;
            this.buttonToDAOImpl.Click += new System.EventHandler(this.buttonToDAOImpl_Click);
            // 
            // buttonToIService
            // 
            this.buttonToIService.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonToIService.Location = new System.Drawing.Point(699, 52);
            this.buttonToIService.Name = "buttonToIService";
            this.buttonToIService.Size = new System.Drawing.Size(223, 35);
            this.buttonToIService.TabIndex = 5;
            this.buttonToIService.Text = "DDL to IService";
            this.buttonToIService.UseVisualStyleBackColor = true;
            this.buttonToIService.Click += new System.EventHandler(this.buttonToIService_Click);
            // 
            // buttonToServiceImpl
            // 
            this.buttonToServiceImpl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonToServiceImpl.Location = new System.Drawing.Point(12, 93);
            this.buttonToServiceImpl.Name = "buttonToServiceImpl";
            this.buttonToServiceImpl.Size = new System.Drawing.Size(223, 35);
            this.buttonToServiceImpl.TabIndex = 6;
            this.buttonToServiceImpl.Text = "DDL to ServiceImpl";
            this.buttonToServiceImpl.UseVisualStyleBackColor = true;
            this.buttonToServiceImpl.Click += new System.EventHandler(this.buttonToServiceImpl_Click);
            // 
            // buttonToRequest
            // 
            this.buttonToRequest.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonToRequest.Location = new System.Drawing.Point(241, 93);
            this.buttonToRequest.Name = "buttonToRequest";
            this.buttonToRequest.Size = new System.Drawing.Size(223, 35);
            this.buttonToRequest.TabIndex = 7;
            this.buttonToRequest.Text = "DDL to Request";
            this.buttonToRequest.UseVisualStyleBackColor = true;
            this.buttonToRequest.Click += new System.EventHandler(this.buttonToRequest_Click);
            // 
            // buttonToResponse
            // 
            this.buttonToResponse.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonToResponse.Location = new System.Drawing.Point(470, 93);
            this.buttonToResponse.Name = "buttonToResponse";
            this.buttonToResponse.Size = new System.Drawing.Size(223, 35);
            this.buttonToResponse.TabIndex = 8;
            this.buttonToResponse.Text = "DDL to Response";
            this.buttonToResponse.UseVisualStyleBackColor = true;
            this.buttonToResponse.Click += new System.EventHandler(this.buttonToResponse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Custom entity name";
            // 
            // txtCusEntityName
            // 
            this.txtCusEntityName.Location = new System.Drawing.Point(135, 6);
            this.txtCusEntityName.Name = "txtCusEntityName";
            this.txtCusEntityName.Size = new System.Drawing.Size(329, 20);
            this.txtCusEntityName.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 182);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "DDL:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(611, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Result:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(559, 493);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = ">>>>>";
            // 
            // txtAutoCamel
            // 
            this.txtAutoCamel.Location = new System.Drawing.Point(1163, 29);
            this.txtAutoCamel.Name = "txtAutoCamel";
            this.txtAutoCamel.Size = new System.Drawing.Size(202, 20);
            this.txtAutoCamel.TabIndex = 14;
            // 
            // btnAutoCamel
            // 
            this.btnAutoCamel.Location = new System.Drawing.Point(1061, 27);
            this.btnAutoCamel.Name = "btnAutoCamel";
            this.btnAutoCamel.Size = new System.Drawing.Size(82, 23);
            this.btnAutoCamel.TabIndex = 15;
            this.btnAutoCamel.Text = "Auto Camel";
            this.btnAutoCamel.UseVisualStyleBackColor = true;
            this.btnAutoCamel.Click += new System.EventHandler(this.btnAutoCamel_Click);
            // 
            // Converter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1456, 912);
            this.Controls.Add(this.btnAutoCamel);
            this.Controls.Add(this.txtAutoCamel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCusEntityName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonToResponse);
            this.Controls.Add(this.buttonToRequest);
            this.Controls.Add(this.buttonToServiceImpl);
            this.Controls.Add(this.buttonToIService);
            this.Controls.Add(this.buttonToDAOImpl);
            this.Controls.Add(this.ToIDAO);
            this.Controls.Add(this.btnDLLtoJavaClass);
            this.Controls.Add(this.tboxDes);
            this.Controls.Add(this.tboxSrc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Converter";
            this.Text = "Converter v.0.1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox tboxSrc;
        private System.Windows.Forms.RichTextBox tboxDes;
        private System.Windows.Forms.Button btnDLLtoJavaClass;
        private System.Windows.Forms.Button ToIDAO;
        private System.Windows.Forms.Button buttonToDAOImpl;
        private System.Windows.Forms.Button buttonToIService;
        private System.Windows.Forms.Button buttonToServiceImpl;
        private System.Windows.Forms.Button buttonToRequest;
        private System.Windows.Forms.Button buttonToResponse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCusEntityName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAutoCamel;
        private System.Windows.Forms.Button btnAutoCamel;
    }
}

