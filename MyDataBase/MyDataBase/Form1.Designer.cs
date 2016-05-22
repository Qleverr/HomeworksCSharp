namespace MyDataBase
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.Button_SetBD = new System.Windows.Forms.Button();
            this.Button_SaveBD = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // Button_SetBD
            // 
            this.Button_SetBD.Location = new System.Drawing.Point(12, 12);
            this.Button_SetBD.Name = "Button_SetBD";
            this.Button_SetBD.Size = new System.Drawing.Size(172, 23);
            this.Button_SetBD.TabIndex = 0;
            this.Button_SetBD.Text = "Выбрать базу данных";
            this.Button_SetBD.UseVisualStyleBackColor = true;
            this.Button_SetBD.Click += new System.EventHandler(this.Button_SetBD_Click);
            // 
            // Button_SaveBD
            // 
            this.Button_SaveBD.Location = new System.Drawing.Point(238, 397);
            this.Button_SaveBD.Name = "Button_SaveBD";
            this.Button_SaveBD.Size = new System.Drawing.Size(172, 23);
            this.Button_SaveBD.TabIndex = 1;
            this.Button_SaveBD.Text = "Сохранить";
            this.Button_SaveBD.UseVisualStyleBackColor = true;
            this.Button_SaveBD.Click += new System.EventHandler(this.Button_SaveBD_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Location = new System.Drawing.Point(12, 70);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(645, 303);
            this.tabControl1.TabIndex = 2;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 432);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.Button_SaveBD);
            this.Controls.Add(this.Button_SetBD);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Button_SetBD;
        private System.Windows.Forms.Button Button_SaveBD;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

