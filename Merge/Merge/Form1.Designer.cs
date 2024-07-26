namespace ExcelFileRenamer
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.ListBox listBoxFiles;
        private System.Windows.Forms.Button btnRenameFiles;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnSelectFolderForMerge;
        private System.Windows.Forms.ListBox listBoxMergeFiles;
        private System.Windows.Forms.Button btnMergeFiles;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Button btnSelectReferenceFile;
        private System.Windows.Forms.TextBox txtReferenceFile;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.listBoxFiles = new System.Windows.Forms.ListBox();
            this.btnRenameFiles = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnSelectFolderForMerge = new System.Windows.Forms.Button();
            this.listBoxMergeFiles = new System.Windows.Forms.ListBox();
            this.btnMergeFiles = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.btnSelectReferenceFile = new System.Windows.Forms.Button();
            this.txtReferenceFile = new System.Windows.Forms.TextBox();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Location = new System.Drawing.Point(4, 4);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(150, 30);
            this.btnSelectFolder.TabIndex = 0;
            this.btnSelectFolder.Text = "폴더 선택";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // listBoxFiles
            // 
            this.listBoxFiles.FormattingEnabled = true;
            this.listBoxFiles.ItemHeight = 15;
            this.listBoxFiles.Location = new System.Drawing.Point(6, 35);
            this.listBoxFiles.Name = "listBoxFiles";
            this.listBoxFiles.Size = new System.Drawing.Size(450, 184);
            this.listBoxFiles.TabIndex = 1;
            // 
            // btnRenameFiles
            // 
            this.btnRenameFiles.Location = new System.Drawing.Point(6, 225);
            this.btnRenameFiles.Name = "btnRenameFiles";
            this.btnRenameFiles.Size = new System.Drawing.Size(150, 30);
            this.btnRenameFiles.TabIndex = 2;
            this.btnRenameFiles.Text = "시작";
            this.btnRenameFiles.UseVisualStyleBackColor = true;
            this.btnRenameFiles.Click += new System.EventHandler(this.btnRenameFiles_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(500, 290);
            this.tabControl.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnSelectFolder);
            this.tabPage1.Controls.Add(this.listBoxFiles);
            this.tabPage1.Controls.Add(this.btnRenameFiles);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(452, 262);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "1단계";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtReferenceFile);
            this.tabPage2.Controls.Add(this.btnSelectReferenceFile);
            this.tabPage2.Controls.Add(this.lblPassword);
            this.tabPage2.Controls.Add(this.txtPassword);
            this.tabPage2.Controls.Add(this.btnSelectFolderForMerge);
            this.tabPage2.Controls.Add(this.listBoxMergeFiles);
            this.tabPage2.Controls.Add(this.btnMergeFiles);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(452, 262);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "2단계";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnSelectFolderForMerge
            // 
            this.btnSelectFolderForMerge.Location = new System.Drawing.Point(6, 35);
            this.btnSelectFolderForMerge.Name = "btnSelectFolderForMerge";
            this.btnSelectFolderForMerge.Size = new System.Drawing.Size(150, 30);
            this.btnSelectFolderForMerge.TabIndex = 0;
            this.btnSelectFolderForMerge.Text = "폴더 선택";
            this.btnSelectFolderForMerge.UseVisualStyleBackColor = true;
            this.btnSelectFolderForMerge.Click += new System.EventHandler(this.btnSelectFolderForMerge_Click);
            // 
            // listBoxMergeFiles
            // 
            this.listBoxMergeFiles.FormattingEnabled = true;
            this.listBoxMergeFiles.ItemHeight = 15;
            this.listBoxMergeFiles.Location = new System.Drawing.Point(6, 64);
            this.listBoxMergeFiles.Name = "listBoxMergeFiles";
            this.listBoxMergeFiles.Size = new System.Drawing.Size(450, 124);
            this.listBoxMergeFiles.TabIndex = 1;
            // 
            // btnMergeFiles
            // 
            this.btnMergeFiles.Location = new System.Drawing.Point(6, 225);
            this.btnMergeFiles.Name = "btnMergeFiles";
            this.btnMergeFiles.Size = new System.Drawing.Size(150, 30);
            this.btnMergeFiles.TabIndex = 2;
            this.btnMergeFiles.Text = "파일 합치기";
            this.btnMergeFiles.UseVisualStyleBackColor = true;
            this.btnMergeFiles.Click += new System.EventHandler(this.btnMergeFiles_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(95, 6);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(150, 23);
            this.txtPassword.TabIndex = 3;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(6, 9);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(83, 15);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "엑셀 파일 암호:";
            // 
            // btnSelectReferenceFile
            // 
            this.btnSelectReferenceFile.Location = new System.Drawing.Point(6, 194);
            this.btnSelectReferenceFile.Name = "btnSelectReferenceFile";
            this.btnSelectReferenceFile.Size = new System.Drawing.Size(150, 30);
            this.btnSelectReferenceFile.TabIndex = 5;
            this.btnSelectReferenceFile.Text = "참조 파일 선택";
            this.btnSelectReferenceFile.UseVisualStyleBackColor = true;
            this.btnSelectReferenceFile.Click += new System.EventHandler(this.btnSelectReferenceFile_Click);
            // 
            // txtReferenceFile
            // 
            this.txtReferenceFile.Location = new System.Drawing.Point(162, 194);
            this.txtReferenceFile.Name = "txtReferenceFile";
            this.txtReferenceFile.Size = new System.Drawing.Size(294, 23);
            this.txtReferenceFile.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 311);
            this.Controls.Add(this.tabControl);
            this.Name = "Form1";
            this.Text = "혜진_정산업로드파일 만들기";
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
