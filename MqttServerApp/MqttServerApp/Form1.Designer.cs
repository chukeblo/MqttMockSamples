
namespace MqttServerApp
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.logPanel = new System.Windows.Forms.Panel();
            this.informationPanel = new System.Windows.Forms.Panel();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.urlLabel = new System.Windows.Forms.Label();
            this.connectionStatusLabel = new System.Windows.Forms.Label();
            this.currentConnectionStatusLabel = new System.Windows.Forms.Label();
            this.startServerButton = new System.Windows.Forms.Button();
            this.logPanel.SuspendLayout();
            this.informationPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // logPanel
            // 
            this.logPanel.Controls.Add(this.logTextBox);
            this.logPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.logPanel.Location = new System.Drawing.Point(0, 105);
            this.logPanel.Name = "logPanel";
            this.logPanel.Size = new System.Drawing.Size(800, 345);
            this.logPanel.TabIndex = 0;
            // 
            // informationPanel
            // 
            this.informationPanel.Controls.Add(this.startServerButton);
            this.informationPanel.Controls.Add(this.currentConnectionStatusLabel);
            this.informationPanel.Controls.Add(this.connectionStatusLabel);
            this.informationPanel.Controls.Add(this.urlLabel);
            this.informationPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.informationPanel.Location = new System.Drawing.Point(0, 0);
            this.informationPanel.Name = "informationPanel";
            this.informationPanel.Size = new System.Drawing.Size(800, 105);
            this.informationPanel.TabIndex = 1;
            // 
            // logTextBox
            // 
            this.logTextBox.BackColor = System.Drawing.Color.White;
            this.logTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logTextBox.ForeColor = System.Drawing.Color.Black;
            this.logTextBox.Location = new System.Drawing.Point(0, 0);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ReadOnly = true;
            this.logTextBox.Size = new System.Drawing.Size(800, 345);
            this.logTextBox.TabIndex = 0;
            // 
            // urlLabel
            // 
            this.urlLabel.AutoSize = true;
            this.urlLabel.Location = new System.Drawing.Point(44, 24);
            this.urlLabel.Name = "urlLabel";
            this.urlLabel.Size = new System.Drawing.Size(27, 12);
            this.urlLabel.TabIndex = 0;
            this.urlLabel.Text = "URL";
            // 
            // connectionStatusLabel
            // 
            this.connectionStatusLabel.AutoSize = true;
            this.connectionStatusLabel.Location = new System.Drawing.Point(44, 53);
            this.connectionStatusLabel.Name = "connectionStatusLabel";
            this.connectionStatusLabel.Size = new System.Drawing.Size(99, 12);
            this.connectionStatusLabel.TabIndex = 1;
            this.connectionStatusLabel.Text = "Connection Status";
            // 
            // currentConnectionStatusLabel
            // 
            this.currentConnectionStatusLabel.AutoSize = true;
            this.currentConnectionStatusLabel.Location = new System.Drawing.Point(209, 53);
            this.currentConnectionStatusLabel.Name = "currentConnectionStatusLabel";
            this.currentConnectionStatusLabel.Size = new System.Drawing.Size(46, 12);
            this.currentConnectionStatusLabel.TabIndex = 2;
            this.currentConnectionStatusLabel.Text = "Stopped";
            // 
            // startServerButton
            // 
            this.startServerButton.Location = new System.Drawing.Point(530, 53);
            this.startServerButton.Name = "startServerButton";
            this.startServerButton.Size = new System.Drawing.Size(75, 23);
            this.startServerButton.TabIndex = 3;
            this.startServerButton.Text = "Start Server";
            this.startServerButton.UseVisualStyleBackColor = true;
            this.startServerButton.Click += new System.EventHandler(this.startServerButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.informationPanel);
            this.Controls.Add(this.logPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.logPanel.ResumeLayout(false);
            this.logPanel.PerformLayout();
            this.informationPanel.ResumeLayout(false);
            this.informationPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel logPanel;
        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.Panel informationPanel;
        private System.Windows.Forms.Label urlLabel;
        private System.Windows.Forms.Label connectionStatusLabel;
        private System.Windows.Forms.Label currentConnectionStatusLabel;
        private System.Windows.Forms.Button startServerButton;
    }
}

