namespace IELauncher
{
    partial class Gui
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Gui));
            SettingsLabel = new Label();
            startUpUrlTextBox = new TextBox();
            label2 = new Label();
            applyButton = new Button();
            OKButton = new Button();
            cancelButton = new Button();
            aboutLink = new LinkLabel();
            SuspendLayout();
            // 
            // SettingsLabel
            // 
            SettingsLabel.Anchor = AnchorStyles.Top;
            SettingsLabel.AutoSize = true;
            SettingsLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            SettingsLabel.Location = new Point(87, 9);
            SettingsLabel.Name = "SettingsLabel";
            SettingsLabel.Size = new Size(252, 25);
            SettingsLabel.TabIndex = 0;
            SettingsLabel.Text = "Internet Explorer Launcher";
            SettingsLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // startUpUrlTextBox
            // 
            startUpUrlTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            startUpUrlTextBox.Location = new Point(90, 48);
            startUpUrlTextBox.Name = "startUpUrlTextBox";
            startUpUrlTextBox.Size = new Size(324, 23);
            startUpUrlTextBox.TabIndex = 1;
            startUpUrlTextBox.TextChanged += startUpUrlTextBox_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 51);
            label2.Name = "label2";
            label2.Size = new Size(72, 15);
            label2.TabIndex = 2;
            label2.Text = "Startup URL:";
            // 
            // applyButton
            // 
            applyButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            applyButton.Location = new Point(339, 109);
            applyButton.Name = "applyButton";
            applyButton.Size = new Size(75, 23);
            applyButton.TabIndex = 3;
            applyButton.Text = "Save";
            applyButton.UseVisualStyleBackColor = true;
            applyButton.Click += applyButton_Click;
            // 
            // OKButton
            // 
            OKButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            OKButton.Location = new Point(177, 109);
            OKButton.Name = "OKButton";
            OKButton.Size = new Size(75, 23);
            OKButton.TabIndex = 4;
            OKButton.Text = "Run IE";
            OKButton.UseVisualStyleBackColor = true;
            OKButton.Click += OKButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cancelButton.Location = new Point(258, 109);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 23);
            cancelButton.TabIndex = 5;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // aboutLink
            // 
            aboutLink.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            aboutLink.AutoSize = true;
            aboutLink.Location = new Point(12, 105);
            aboutLink.Name = "aboutLink";
            aboutLink.Size = new Size(146, 30);
            aboutLink.TabIndex = 6;
            aboutLink.TabStop = true;
            aboutLink.Text = "About\r\nInternet Explorer Launcher";
            aboutLink.LinkClicked += aboutLink_LinkClicked;
            // 
            // Gui
            // 
            AcceptButton = OKButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelButton;
            ClientSize = new Size(426, 144);
            ControlBox = false;
            Controls.Add(aboutLink);
            Controls.Add(cancelButton);
            Controls.Add(OKButton);
            Controls.Add(applyButton);
            Controls.Add(label2);
            Controls.Add(startUpUrlTextBox);
            Controls.Add(SettingsLabel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Gui";
            Text = "Internet Explorer Launcher";
            FormClosing += Gui_FormClosing;
            Load += Gui_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label SettingsLabel;
        private TextBox startUpUrlTextBox;
        private Label label2;
        private Button applyButton;
        private Button OKButton;
        private Button cancelButton;
        private LinkLabel aboutLink;
    }
}