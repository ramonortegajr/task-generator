namespace Task_Generator
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.taskTextBox = new System.Windows.Forms.RichTextBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.checkTimeTimer = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(297, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "What\'s your done task for today?";
            // 
            // taskTextBox
            // 
            this.taskTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taskTextBox.Location = new System.Drawing.Point(12, 120);
            this.taskTextBox.Name = "taskTextBox";
            this.taskTextBox.Size = new System.Drawing.Size(632, 95);
            this.taskTextBox.TabIndex = 1;
            this.taskTextBox.Text = "";
            this.taskTextBox.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // submitButton
            // 
            this.submitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitButton.Location = new System.Drawing.Point(10, 232);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(634, 60);
            this.submitButton.TabIndex = 2;
            this.submitButton.Text = "Submit Task";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // checkTimeTimer
            // 
            this.checkTimeTimer.Enabled = true;
            this.checkTimeTimer.Interval = 60000;
            this.checkTimeTimer.Tick += new System.EventHandler(this.checkTimeTimer_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(185, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(287, 32);
            this.label2.TabIndex = 3;
            this.label2.Text = "TASK GENERATOR";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 338);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.taskTextBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox taskTextBox;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Timer checkTimeTimer;
        private System.Windows.Forms.Label label2;
    }
}

