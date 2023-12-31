﻿namespace Chatv2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            MessageSender = new RichTextBox();
            datanickname = new TextBox();
            labelnickname = new Label();
            savebutton = new Button();
            connectbutton = new Button();
            onlinetext = new Label();
            Messages = new TextBox();
            LabelTyping = new Label();
            SuspendLayout();
            // 
            // MessageSender
            // 
            MessageSender.BackColor = Color.FromArgb(64, 64, 64);
            MessageSender.BorderStyle = BorderStyle.None;
            MessageSender.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            MessageSender.ForeColor = SystemColors.Window;
            MessageSender.Location = new Point(12, 495);
            MessageSender.Name = "MessageSender";
            MessageSender.Size = new Size(760, 54);
            MessageSender.TabIndex = 1;
            MessageSender.Text = "";
            MessageSender.TextChanged += SendTyping;
            MessageSender.KeyDown += SendMessage;
            // 
            // datanickname
            // 
            datanickname.BackColor = Color.FromArgb(64, 64, 64);
            datanickname.BorderStyle = BorderStyle.FixedSingle;
            datanickname.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            datanickname.ForeColor = SystemColors.Window;
            datanickname.Location = new Point(12, 89);
            datanickname.MaxLength = 25;
            datanickname.Name = "datanickname";
            datanickname.Size = new Size(167, 27);
            datanickname.TabIndex = 3;
            // 
            // labelnickname
            // 
            labelnickname.AutoSize = true;
            labelnickname.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            labelnickname.Location = new Point(12, 65);
            labelnickname.Name = "labelnickname";
            labelnickname.Size = new Size(88, 21);
            labelnickname.TabIndex = 4;
            labelnickname.Text = "Nickname";
            // 
            // savebutton
            // 
            savebutton.BackColor = Color.FromArgb(128, 255, 128);
            savebutton.Cursor = Cursors.Hand;
            savebutton.FlatStyle = FlatStyle.Flat;
            savebutton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            savebutton.ForeColor = Color.Black;
            savebutton.Location = new Point(12, 122);
            savebutton.Name = "savebutton";
            savebutton.Size = new Size(167, 26);
            savebutton.TabIndex = 5;
            savebutton.Text = "Salvar";
            savebutton.UseVisualStyleBackColor = false;
            savebutton.Click += SaveModify;
            // 
            // connectbutton
            // 
            connectbutton.BackColor = Color.FromArgb(128, 255, 128);
            connectbutton.Cursor = Cursors.Hand;
            connectbutton.FlatStyle = FlatStyle.Flat;
            connectbutton.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            connectbutton.ForeColor = Color.Black;
            connectbutton.Location = new Point(185, 89);
            connectbutton.Name = "connectbutton";
            connectbutton.Size = new Size(166, 59);
            connectbutton.TabIndex = 6;
            connectbutton.Text = "Conectar";
            connectbutton.UseVisualStyleBackColor = false;
            connectbutton.Click += ConnectToServer;
            // 
            // onlinetext
            // 
            onlinetext.AutoSize = true;
            onlinetext.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            onlinetext.ForeColor = Color.FromArgb(128, 255, 128);
            onlinetext.Location = new Point(717, 129);
            onlinetext.Name = "onlinetext";
            onlinetext.Size = new Size(0, 13);
            onlinetext.TabIndex = 7;
            // 
            // Messages
            // 
            Messages.BackColor = Color.FromArgb(64, 64, 64);
            Messages.BorderStyle = BorderStyle.None;
            Messages.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Messages.ForeColor = SystemColors.Window;
            Messages.Location = new Point(12, 154);
            Messages.Multiline = true;
            Messages.Name = "Messages";
            Messages.ReadOnly = true;
            Messages.Size = new Size(760, 265);
            Messages.TabIndex = 8;
            // 
            // LabelTyping
            // 
            LabelTyping.AutoSize = true;
            LabelTyping.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            LabelTyping.ForeColor = SystemColors.ButtonFace;
            LabelTyping.Location = new Point(12, 465);
            LabelTyping.Name = "LabelTyping";
            LabelTyping.Size = new Size(0, 17);
            LabelTyping.TabIndex = 9;
            LabelTyping.TextAlign = ContentAlignment.TopCenter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(784, 561);
            Controls.Add(LabelTyping);
            Controls.Add(Messages);
            Controls.Add(onlinetext);
            Controls.Add(connectbutton);
            Controls.Add(savebutton);
            Controls.Add(labelnickname);
            Controls.Add(datanickname);
            Controls.Add(MessageSender);
            ForeColor = SystemColors.ControlLightLight;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "4uChat";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private RichTextBox MessageSender;
        private TextBox datanickname;
        private Label labelnickname;
        private Button savebutton;
        private Button connectbutton;
        private Label onlinetext;
        private TextBox Messages;
        private Label LabelTyping;
    }
}