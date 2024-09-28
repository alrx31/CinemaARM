namespace cinemaARM
{
    partial class RegisterForm
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
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            checkBox1 = new CheckBox();
            button1 = new Button();
            button2 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 24F);
            textBox1.Location = new Point(143, 61);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(200, 50);
            textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 24F);
            textBox2.Location = new Point(143, 152);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(200, 50);
            textBox2.TabIndex = 2;
            // 
            // textBox3
            // 
            textBox3.Font = new Font("Segoe UI", 24F);
            textBox3.Location = new Point(143, 242);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(200, 50);
            textBox3.TabIndex = 3;
            // 
            // textBox4
            // 
            textBox4.Font = new Font("Segoe UI", 24F);
            textBox4.Location = new Point(143, 390);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(200, 50);
            textBox4.TabIndex = 5;
            // 
            // textBox5
            // 
            textBox5.Font = new Font("Segoe UI", 24F);
            textBox5.Location = new Point(143, 481);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(200, 50);
            textBox5.TabIndex = 6;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Segoe UI", 16F);
            checkBox1.Location = new Point(178, 308);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(109, 34);
            checkBox1.TabIndex = 7;
            checkBox1.Text = "Админ?";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 16F);
            button1.Location = new Point(268, 639);
            button1.Name = "button1";
            button1.Size = new Size(200, 50);
            button1.TabIndex = 8;
            button1.Text = "Отемена";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 16F);
            button2.Location = new Point(36, 639);
            button2.Name = "button2";
            button2.Size = new Size(220, 50);
            button2.TabIndex = 9;
            button2.Text = "Зарегистрировать";
            button2.UseVisualStyleBackColor = true;
            button2.Click += Register_event;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(211, 33);
            label1.Name = "label1";
            label1.Size = new Size(49, 25);
            label1.TabIndex = 10;
            label1.Text = "Имя";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F);
            label2.Location = new Point(211, 124);
            label2.Name = "label2";
            label2.Size = new Size(91, 25);
            label2.TabIndex = 11;
            label2.Text = "Фамилия";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F);
            label3.Location = new Point(211, 214);
            label3.Name = "label3";
            label3.Size = new Size(65, 25);
            label3.TabIndex = 12;
            label3.Text = "Логин";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14F);
            label4.Location = new Point(211, 362);
            label4.Name = "label4";
            label4.Size = new Size(78, 25);
            label4.TabIndex = 13;
            label4.Text = "Пароль";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14F);
            label5.Location = new Point(160, 453);
            label5.Name = "label5";
            label5.Size = new Size(174, 25);
            label5.TabIndex = 14;
            label5.Text = "Повторите пароль";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 16F);
            label6.ForeColor = Color.OrangeRed;
            label6.Location = new Point(143, 556);
            label6.Name = "label6";
            label6.Size = new Size(71, 30);
            label6.TabIndex = 15;
            label6.Text = "label6";
            label6.Visible = false;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(501, 701);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(checkBox1);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "RegisterForm";
            Text = "Регистрация";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private CheckBox checkBox1;
        private Button button1;
        private Button button2;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}