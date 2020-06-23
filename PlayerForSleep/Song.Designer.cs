namespace PlayerForSleep
{
    partial class ListMusic
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.lName = new System.Windows.Forms.Label();
            this.bBlackList = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lName
            // 
            this.lName.AutoSize = true;
            this.lName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.lName.ForeColor = System.Drawing.Color.White;
            this.lName.Location = new System.Drawing.Point(3, 0);
            this.lName.MaximumSize = new System.Drawing.Size(275, 0);
            this.lName.MinimumSize = new System.Drawing.Size(275, 0);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(275, 16);
            this.lName.TabIndex = 0;
            this.lName.Text = "name";
            this.lName.Click += new System.EventHandler(this.label1_Click);
            // 
            // bBlackList
            // 
            this.bBlackList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bBlackList.BackColor = System.Drawing.Color.Black;
            this.bBlackList.BackgroundImage = global::PlayerForSleep.images.exit;
            this.bBlackList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bBlackList.Location = new System.Drawing.Point(283, 0);
            this.bBlackList.Name = "bBlackList";
            this.bBlackList.Size = new System.Drawing.Size(23, 18);
            this.bBlackList.TabIndex = 1;
            this.bBlackList.UseVisualStyleBackColor = false;
            this.bBlackList.Click += new System.EventHandler(this.bBlackList_Click);
            // 
            // ListMusic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.bBlackList);
            this.Controls.Add(this.lName);
            this.Name = "ListMusic";
            this.Size = new System.Drawing.Size(309, 18);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lName;
        private System.Windows.Forms.Button bBlackList;
    }
}
