
namespace WindowsFormsApp2
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
            this.button1 = new System.Windows.Forms.Button();
            this.publicKeyATextBox = new System.Windows.Forms.TextBox();
            this.publicKeyBTextBox = new System.Windows.Forms.TextBox();
            this.secretKeyTextBox = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.createSecretKey = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(18, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(893, 29);
            this.button1.TabIndex = 0;
            this.button1.Text = "Создать свой открытый 🔑";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // publicKeyATextBox
            // 
            this.publicKeyATextBox.Location = new System.Drawing.Point(206, 65);
            this.publicKeyATextBox.Name = "publicKeyATextBox";
            this.publicKeyATextBox.Size = new System.Drawing.Size(705, 27);
            this.publicKeyATextBox.TabIndex = 1;
            this.publicKeyATextBox.TextChanged += new System.EventHandler(this.publicKeyATextBox_TextChanged);
            // 
            // publicKeyBTextBox
            // 
            this.publicKeyBTextBox.Location = new System.Drawing.Point(206, 115);
            this.publicKeyBTextBox.Name = "publicKeyBTextBox";
            this.publicKeyBTextBox.Size = new System.Drawing.Size(705, 27);
            this.publicKeyBTextBox.TabIndex = 2;
            this.publicKeyBTextBox.TextChanged += new System.EventHandler(this.publicKeyBTextBox_TextChanged);
            // 
            // secretKeyTextBox
            // 
            this.secretKeyTextBox.Location = new System.Drawing.Point(18, 209);
            this.secretKeyTextBox.Name = "secretKeyTextBox";
            this.secretKeyTextBox.Size = new System.Drawing.Size(893, 27);
            this.secretKeyTextBox.TabIndex = 3;
            this.secretKeyTextBox.TextChanged += new System.EventHandler(this.secretKeyTextBox_TextChanged);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(18, 265);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(354, 201);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(557, 265);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(354, 201);
            this.richTextBox2.TabIndex = 5;
            this.richTextBox2.Text = "";
            this.richTextBox2.TextChanged += new System.EventHandler(this.richTextBox2_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Свой открытый ключ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Открытый ключ абонента";
            // 
            // createSecretKey
            // 
            this.createSecretKey.Location = new System.Drawing.Point(18, 161);
            this.createSecretKey.Name = "createSecretKey";
            this.createSecretKey.Size = new System.Drawing.Size(893, 30);
            this.createSecretKey.TabIndex = 7;
            this.createSecretKey.Text = "Сформировать секретный ключ🗝";
            this.createSecretKey.UseVisualStyleBackColor = true;
            this.createSecretKey.Click += new System.EventHandler(this.createSecretKey_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(378, 265);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(173, 86);
            this.button3.TabIndex = 8;
            this.button3.Text = "Зашифровать →";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(378, 384);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(173, 82);
            this.button4.TabIndex = 9;
            this.button4.Text = "Расшифровать ←";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 493);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.createSecretKey);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.secretKeyTextBox);
            this.Controls.Add(this.publicKeyBTextBox);
            this.Controls.Add(this.publicKeyATextBox);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox publicKeyATextBox;
        private System.Windows.Forms.TextBox publicKeyBTextBox;
        private System.Windows.Forms.TextBox secretKeyTextBox;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button createSecretKey;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}

