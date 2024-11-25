namespace cinemaARM
{
    partial class AddServeForm
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
            textBox1 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBox2 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 16F);
            textBox1.Location = new Point(121, 107);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(228, 43);
            textBox1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F);
            label1.Location = new Point(128, 63);
            label1.Name = "label1";
            label1.Size = new Size(70, 37);
            label1.TabIndex = 2;
            label1.Text = "Имя";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16F);
            label2.Location = new Point(128, 203);
            label2.Name = "label2";
            label2.Size = new Size(94, 37);
            label2.TabIndex = 3;
            label2.Text = "Место";
            // 
            // label3
            // 
            label3.AutoEllipsis = true;
            label3.Font = new Font("Segoe UI", 16F);
            label3.ForeColor = Color.OrangeRed;
            label3.Location = new Point(45, 327);
            label3.MaximumSize = new Size(457, 0);
            label3.MinimumSize = new Size(457, 133);
            label3.Name = "label3";
            label3.Size = new Size(457, 133);
            label3.TabIndex = 4;
            label3.Text = "label3";
            label3.UseCompatibleTextRendering = true;
            label3.Visible = false;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 16F);
            textBox2.Location = new Point(128, 247);
            textBox2.Margin = new Padding(3, 4, 3, 4);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(228, 43);
            textBox2.TabIndex = 5;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 16F);
            button1.Location = new Point(21, 514);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(229, 67);
            button1.TabIndex = 6;
            button1.Text = "Записать";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Add_Serve;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 16F);
            button2.Location = new Point(128, 612);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(229, 67);
            button2.TabIndex = 7;
            button2.Text = "Отмена";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 16F);
            button3.Location = new Point(282, 514);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(229, 67);
            button3.TabIndex = 8;
            button3.Text = "Снять";
            button3.UseVisualStyleBackColor = true;
            button3.Click += RemoveServe;
            // 
            // AddServeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(558, 692);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            Name = "AddServeForm";
            Text = "Забронировать место";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox2;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}