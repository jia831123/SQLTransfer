namespace SQLTransfer
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Transfer = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.Connection = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ServerName_Source = new System.Windows.Forms.ComboBox();
            this.UserName_Source = new System.Windows.Forms.TextBox();
            this.Password_Source = new System.Windows.Forms.TextBox();
            this.DataBase_Source = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TableName_Source = new System.Windows.Forms.ComboBox();
            this.SaveInputData_Source = new System.Windows.Forms.CheckBox();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ServerName_Traget = new System.Windows.Forms.ComboBox();
            this.UserName_Traget = new System.Windows.Forms.TextBox();
            this.Password_Traget = new System.Windows.Forms.TextBox();
            this.DataBase_Traget = new System.Windows.Forms.ComboBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TableName_Traget = new System.Windows.Forms.ComboBox();
            this.SaveInputData_Traget = new System.Windows.Forms.CheckBox();
            this.Connections = new System.Windows.Forms.TabControl();
            this.Info = new System.Windows.Forms.Button();
            this.Connection.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.Connections.SuspendLayout();
            this.SuspendLayout();
            // 
            // Transfer
            // 
            this.Transfer.Enabled = false;
            this.Transfer.Location = new System.Drawing.Point(437, 514);
            this.Transfer.Name = "Transfer";
            this.Transfer.Size = new System.Drawing.Size(119, 34);
            this.Transfer.TabIndex = 1;
            this.Transfer.Text = "Transfer";
            this.Transfer.UseVisualStyleBackColor = true;
            this.Transfer.Click += new System.EventHandler(this.button3_Click);
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(562, 514);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(119, 34);
            this.Exit.TabIndex = 2;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Connection
            // 
            this.Connection.Controls.Add(this.tabControl2);
            this.Connection.Controls.Add(this.tabControl1);
            this.Connection.Location = new System.Drawing.Point(4, 31);
            this.Connection.Name = "Connection";
            this.Connection.Padding = new System.Windows.Forms.Padding(3);
            this.Connection.Size = new System.Drawing.Size(682, 471);
            this.Connection.TabIndex = 0;
            this.Connection.Text = "Connections";
            this.Connection.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(19, 18);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(646, 223);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.SaveInputData_Source);
            this.tabPage3.Controls.Add(this.TableName_Source);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.checkBox1);
            this.tabPage3.Controls.Add(this.DataBase_Source);
            this.tabPage3.Controls.Add(this.Password_Source);
            this.tabPage3.Controls.Add(this.UserName_Source);
            this.tabPage3.Controls.Add(this.ServerName_Source);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Location = new System.Drawing.Point(4, 31);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(638, 188);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Source-SQL Server";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "User Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 22);
            this.label4.TabIndex = 3;
            this.label4.Text = "Database:";
            // 
            // ServerName_Source
            // 
            this.ServerName_Source.FormattingEnabled = true;
            this.ServerName_Source.Location = new System.Drawing.Point(130, 6);
            this.ServerName_Source.Name = "ServerName_Source";
            this.ServerName_Source.Size = new System.Drawing.Size(324, 30);
            this.ServerName_Source.TabIndex = 4;
            this.ServerName_Source.Text = "210.201.85.214";
            // 
            // UserName_Source
            // 
            this.UserName_Source.Location = new System.Drawing.Point(130, 46);
            this.UserName_Source.Name = "UserName_Source";
            this.UserName_Source.Size = new System.Drawing.Size(324, 28);
            this.UserName_Source.TabIndex = 5;
            this.UserName_Source.Text = "sa";
            // 
            // Password_Source
            // 
            this.Password_Source.Location = new System.Drawing.Point(130, 86);
            this.Password_Source.Name = "Password_Source";
            this.Password_Source.Size = new System.Drawing.Size(324, 28);
            this.Password_Source.TabIndex = 6;
            this.Password_Source.Text = "MyGis@";
            // 
            // DataBase_Source
            // 
            this.DataBase_Source.FormattingEnabled = true;
            this.DataBase_Source.Location = new System.Drawing.Point(130, 121);
            this.DataBase_Source.Name = "DataBase_Source";
            this.DataBase_Source.Size = new System.Drawing.Size(324, 30);
            this.DataBase_Source.TabIndex = 7;
            this.DataBase_Source.SelectedIndexChanged += new System.EventHandler(this.DataBase_SourceChangeValue);
            this.DataBase_Source.SelectedValueChanged += new System.EventHandler(this.DataBase_SourceChangeValue);
            this.DataBase_Source.Click += new System.EventHandler(this.DateBase_SelectedClick);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(462, 48);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(164, 26);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "Windows Authentica";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 163);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 22);
            this.label9.TabIndex = 10;
            this.label9.Text = "TableName";
            // 
            // TableName_Source
            // 
            this.TableName_Source.Enabled = false;
            this.TableName_Source.FormattingEnabled = true;
            this.TableName_Source.Location = new System.Drawing.Point(130, 158);
            this.TableName_Source.Name = "TableName_Source";
            this.TableName_Source.Size = new System.Drawing.Size(324, 30);
            this.TableName_Source.TabIndex = 11;
            this.TableName_Source.SelectedValueChanged += new System.EventHandler(this.UpdateTransferState);
            // 
            // SaveInputData_Source
            // 
            this.SaveInputData_Source.AutoSize = true;
            this.SaveInputData_Source.Location = new System.Drawing.Point(462, 88);
            this.SaveInputData_Source.Name = "SaveInputData_Source";
            this.SaveInputData_Source.Size = new System.Drawing.Size(137, 26);
            this.SaveInputData_Source.TabIndex = 12;
            this.SaveInputData_Source.Text = "Save Input Data";
            this.SaveInputData_Source.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Location = new System.Drawing.Point(19, 247);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(642, 220);
            this.tabControl2.TabIndex = 1;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.SaveInputData_Traget);
            this.tabPage5.Controls.Add(this.TableName_Traget);
            this.tabPage5.Controls.Add(this.label10);
            this.tabPage5.Controls.Add(this.checkBox2);
            this.tabPage5.Controls.Add(this.DataBase_Traget);
            this.tabPage5.Controls.Add(this.Password_Traget);
            this.tabPage5.Controls.Add(this.UserName_Traget);
            this.tabPage5.Controls.Add(this.ServerName_Traget);
            this.tabPage5.Controls.Add(this.label5);
            this.tabPage5.Controls.Add(this.label6);
            this.tabPage5.Controls.Add(this.label7);
            this.tabPage5.Controls.Add(this.label8);
            this.tabPage5.Location = new System.Drawing.Point(4, 31);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(634, 185);
            this.tabPage5.TabIndex = 0;
            this.tabPage5.Text = "Traget-SQL Server";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 22);
            this.label8.TabIndex = 4;
            this.label8.Text = "Server Name:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 22);
            this.label7.TabIndex = 5;
            this.label7.Text = "User Name:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 22);
            this.label6.TabIndex = 6;
            this.label6.Text = "Password:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 22);
            this.label5.TabIndex = 7;
            this.label5.Text = "Database:";
            // 
            // ServerName_Traget
            // 
            this.ServerName_Traget.FormattingEnabled = true;
            this.ServerName_Traget.Location = new System.Drawing.Point(130, 4);
            this.ServerName_Traget.Name = "ServerName_Traget";
            this.ServerName_Traget.Size = new System.Drawing.Size(324, 30);
            this.ServerName_Traget.TabIndex = 8;
            this.ServerName_Traget.Text = "210.201.85.214";
            // 
            // UserName_Traget
            // 
            this.UserName_Traget.Location = new System.Drawing.Point(130, 44);
            this.UserName_Traget.Name = "UserName_Traget";
            this.UserName_Traget.Size = new System.Drawing.Size(324, 28);
            this.UserName_Traget.TabIndex = 9;
            this.UserName_Traget.Text = "sa";
            // 
            // Password_Traget
            // 
            this.Password_Traget.Location = new System.Drawing.Point(130, 84);
            this.Password_Traget.Name = "Password_Traget";
            this.Password_Traget.Size = new System.Drawing.Size(324, 28);
            this.Password_Traget.TabIndex = 10;
            this.Password_Traget.Text = "MyGis@";
            // 
            // DataBase_Traget
            // 
            this.DataBase_Traget.FormattingEnabled = true;
            this.DataBase_Traget.Location = new System.Drawing.Point(130, 120);
            this.DataBase_Traget.Name = "DataBase_Traget";
            this.DataBase_Traget.Size = new System.Drawing.Size(324, 30);
            this.DataBase_Traget.TabIndex = 11;
            this.DataBase_Traget.SelectedValueChanged += new System.EventHandler(this.DataBase_SourceChangeValue);
            this.DataBase_Traget.Click += new System.EventHandler(this.DateBase_SelectedClick);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(470, 47);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(164, 26);
            this.checkBox2.TabIndex = 12;
            this.checkBox2.Text = "Windows Authentica";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 160);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 22);
            this.label10.TabIndex = 13;
            this.label10.Text = "TableName";
            // 
            // TableName_Traget
            // 
            this.TableName_Traget.Enabled = false;
            this.TableName_Traget.FormattingEnabled = true;
            this.TableName_Traget.Location = new System.Drawing.Point(130, 155);
            this.TableName_Traget.Name = "TableName_Traget";
            this.TableName_Traget.Size = new System.Drawing.Size(324, 30);
            this.TableName_Traget.TabIndex = 14;
            this.TableName_Traget.SelectedValueChanged += new System.EventHandler(this.UpdateTransferState);
            // 
            // SaveInputData_Traget
            // 
            this.SaveInputData_Traget.AutoSize = true;
            this.SaveInputData_Traget.Location = new System.Drawing.Point(470, 86);
            this.SaveInputData_Traget.Name = "SaveInputData_Traget";
            this.SaveInputData_Traget.Size = new System.Drawing.Size(137, 26);
            this.SaveInputData_Traget.TabIndex = 13;
            this.SaveInputData_Traget.Text = "Save Input Data";
            this.SaveInputData_Traget.UseVisualStyleBackColor = true;
            // 
            // Connections
            // 
            this.Connections.Controls.Add(this.Connection);
            this.Connections.Location = new System.Drawing.Point(12, 2);
            this.Connections.Name = "Connections";
            this.Connections.SelectedIndex = 0;
            this.Connections.Size = new System.Drawing.Size(690, 506);
            this.Connections.TabIndex = 0;
            // 
            // Info
            // 
            this.Info.Location = new System.Drawing.Point(312, 514);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(119, 34);
            this.Info.TabIndex = 4;
            this.Info.Text = "Info";
            this.Info.UseVisualStyleBackColor = true;
            this.Info.Click += new System.EventHandler(this.Info_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 553);
            this.Controls.Add(this.Info);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Transfer);
            this.Controls.Add(this.Connections);
            this.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "SQLTransfer";
            this.Connection.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.Connections.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Transfer;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.TabPage Connection;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.CheckBox SaveInputData_Traget;
        private System.Windows.Forms.ComboBox TableName_Traget;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.ComboBox DataBase_Traget;
        private System.Windows.Forms.TextBox Password_Traget;
        private System.Windows.Forms.TextBox UserName_Traget;
        private System.Windows.Forms.ComboBox ServerName_Traget;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.CheckBox SaveInputData_Source;
        private System.Windows.Forms.ComboBox TableName_Source;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ComboBox DataBase_Source;
        private System.Windows.Forms.TextBox Password_Source;
        private System.Windows.Forms.TextBox UserName_Source;
        private System.Windows.Forms.ComboBox ServerName_Source;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl Connections;
        private System.Windows.Forms.Button Info;
    }
}

