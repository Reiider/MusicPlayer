namespace PlayerForSleep
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.bSetting = new System.Windows.Forms.Button();
            this.bExit = new System.Windows.Forms.Button();
            this.bNextSong = new System.Windows.Forms.Button();
            this.bPrevious = new System.Windows.Forms.Button();
            this.bAdd = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.cbRandom = new System.Windows.Forms.CheckBox();
            this.nudVolume = new System.Windows.Forms.NumericUpDown();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.nudHour = new System.Windows.Forms.NumericUpDown();
            this.nudMin = new System.Windows.Forms.NumericUpDown();
            this.nudSec = new System.Windows.Forms.NumericUpDown();
            this.cbEndMusic = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.sleeper = new System.Windows.Forms.Timer(this.components);
            this.cbWillStop = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.wmp = new AxWMPLib.AxWindowsMediaPlayer();
            this.tcListsMusic = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cbExit = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wmp)).BeginInit();
            this.tcListsMusic.SuspendLayout();
            this.SuspendLayout();
            // 
            // bSetting
            // 
            this.bSetting.BackgroundImage = global::PlayerForSleep.images.settings;
            this.bSetting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bSetting.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bSetting.FlatAppearance.BorderSize = 2;
            this.bSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bSetting.Location = new System.Drawing.Point(3, 3);
            this.bSetting.Name = "bSetting";
            this.bSetting.Size = new System.Drawing.Size(20, 20);
            this.bSetting.TabIndex = 1;
            this.bSetting.UseVisualStyleBackColor = true;
            this.bSetting.Click += new System.EventHandler(this.bSetting_Click);
            // 
            // bExit
            // 
            this.bExit.BackgroundImage = global::PlayerForSleep.images.exit;
            this.bExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bExit.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bExit.FlatAppearance.BorderSize = 2;
            this.bExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.bExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bExit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bExit.Location = new System.Drawing.Point(325, 3);
            this.bExit.Name = "bExit";
            this.bExit.Size = new System.Drawing.Size(20, 20);
            this.bExit.TabIndex = 0;
            this.bExit.UseVisualStyleBackColor = false;
            this.bExit.Click += new System.EventHandler(this.button1_Click);
            // 
            // bNextSong
            // 
            this.bNextSong.BackColor = System.Drawing.Color.Black;
            this.bNextSong.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bNextSong.ForeColor = System.Drawing.Color.White;
            this.bNextSong.Location = new System.Drawing.Point(266, 139);
            this.bNextSong.Name = "bNextSong";
            this.bNextSong.Size = new System.Drawing.Size(55, 29);
            this.bNextSong.TabIndex = 3;
            this.bNextSong.Text = "next";
            this.bNextSong.UseVisualStyleBackColor = false;
            this.bNextSong.Click += new System.EventHandler(this.bNextSong_Click);
            // 
            // bPrevious
            // 
            this.bPrevious.BackColor = System.Drawing.Color.Black;
            this.bPrevious.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bPrevious.ForeColor = System.Drawing.Color.White;
            this.bPrevious.Location = new System.Drawing.Point(12, 139);
            this.bPrevious.Name = "bPrevious";
            this.bPrevious.Size = new System.Drawing.Size(56, 30);
            this.bPrevious.TabIndex = 4;
            this.bPrevious.Text = "previous";
            this.bPrevious.UseVisualStyleBackColor = false;
            this.bPrevious.Click += new System.EventHandler(this.bPrevious_Click);
            // 
            // bAdd
            // 
            this.bAdd.BackColor = System.Drawing.Color.Black;
            this.bAdd.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bAdd.ForeColor = System.Drawing.Color.White;
            this.bAdd.Location = new System.Drawing.Point(4, 338);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(107, 25);
            this.bAdd.TabIndex = 6;
            this.bAdd.Text = "Добавить";
            this.bAdd.UseVisualStyleBackColor = false;
            this.bAdd.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Black;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(130, 139);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "pause";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cbRandom
            // 
            this.cbRandom.AutoSize = true;
            this.cbRandom.ForeColor = System.Drawing.Color.White;
            this.cbRandom.Location = new System.Drawing.Point(12, 116);
            this.cbRandom.Name = "cbRandom";
            this.cbRandom.Size = new System.Drawing.Size(126, 17);
            this.cbRandom.TabIndex = 8;
            this.cbRandom.Text = "Случайный порядок";
            this.cbRandom.UseVisualStyleBackColor = true;
            // 
            // nudVolume
            // 
            this.nudVolume.Location = new System.Drawing.Point(186, 113);
            this.nudVolume.Name = "nudVolume";
            this.nudVolume.Size = new System.Drawing.Size(59, 20);
            this.nudVolume.TabIndex = 9;
            this.nudVolume.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudVolume.ValueChanged += new System.EventHandler(this.nudVolume_ValueChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // nudHour
            // 
            this.nudHour.BackColor = System.Drawing.Color.Black;
            this.nudHour.ForeColor = System.Drawing.Color.White;
            this.nudHour.Location = new System.Drawing.Point(102, 33);
            this.nudHour.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.nudHour.Name = "nudHour";
            this.nudHour.Size = new System.Drawing.Size(37, 20);
            this.nudHour.TabIndex = 15;
            this.nudHour.Value = new decimal(new int[] {
            23,
            0,
            0,
            0});
            // 
            // nudMin
            // 
            this.nudMin.BackColor = System.Drawing.Color.Black;
            this.nudMin.ForeColor = System.Drawing.Color.White;
            this.nudMin.Location = new System.Drawing.Point(145, 33);
            this.nudMin.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.nudMin.Name = "nudMin";
            this.nudMin.Size = new System.Drawing.Size(37, 20);
            this.nudMin.TabIndex = 16;
            this.nudMin.Value = new decimal(new int[] {
            59,
            0,
            0,
            0});
            // 
            // nudSec
            // 
            this.nudSec.BackColor = System.Drawing.Color.Black;
            this.nudSec.ForeColor = System.Drawing.Color.White;
            this.nudSec.Location = new System.Drawing.Point(188, 33);
            this.nudSec.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.nudSec.Name = "nudSec";
            this.nudSec.Size = new System.Drawing.Size(35, 20);
            this.nudSec.TabIndex = 17;
            this.nudSec.Value = new decimal(new int[] {
            59,
            0,
            0,
            0});
            // 
            // cbEndMusic
            // 
            this.cbEndMusic.AutoSize = true;
            this.cbEndMusic.ForeColor = System.Drawing.Color.White;
            this.cbEndMusic.Location = new System.Drawing.Point(12, 59);
            this.cbEndMusic.Name = "cbEndMusic";
            this.cbEndMusic.Size = new System.Drawing.Size(152, 17);
            this.cbEndMusic.TabIndex = 18;
            this.cbEndMusic.Text = "по завершению мелодии";
            this.cbEndMusic.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(255, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Громкость";
            // 
            // sleeper
            // 
            this.sleeper.Interval = 1000;
            this.sleeper.Tick += new System.EventHandler(this.sleeper_Tick);
            // 
            // cbWillStop
            // 
            this.cbWillStop.AutoSize = true;
            this.cbWillStop.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cbWillStop.ForeColor = System.Drawing.Color.White;
            this.cbWillStop.Location = new System.Drawing.Point(12, 34);
            this.cbWillStop.Name = "cbWillStop";
            this.cbWillStop.Size = new System.Drawing.Size(89, 17);
            this.cbWillStop.TabIndex = 20;
            this.cbWillStop.Text = "Пауза через";
            this.cbWillStop.UseVisualStyleBackColor = false;
            this.cbWillStop.CheckedChanged += new System.EventHandler(this.cbWillStop_CheckedChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(247, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(54, 33);
            this.button1.TabIndex = 21;
            this.button1.Text = "сброс";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // wmp
            // 
            this.wmp.Enabled = true;
            this.wmp.Location = new System.Drawing.Point(39, 3);
            this.wmp.Name = "wmp";
            this.wmp.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("wmp.OcxState")));
            this.wmp.Size = new System.Drawing.Size(10, 10);
            this.wmp.TabIndex = 10;
            this.wmp.Visible = false;
            // 
            // tcListsMusic
            // 
            this.tcListsMusic.Controls.Add(this.tabPage1);
            this.tcListsMusic.Location = new System.Drawing.Point(4, 175);
            this.tcListsMusic.Name = "tcListsMusic";
            this.tcListsMusic.SelectedIndex = 0;
            this.tcListsMusic.Size = new System.Drawing.Size(341, 157);
            this.tcListsMusic.TabIndex = 22;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(333, 131);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Новый плейлист";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cbExit
            // 
            this.cbExit.AutoSize = true;
            this.cbExit.Location = new System.Drawing.Point(330, 29);
            this.cbExit.Name = "cbExit";
            this.cbExit.Size = new System.Drawing.Size(15, 14);
            this.cbExit.TabIndex = 23;
            this.cbExit.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(349, 367);
            this.ControlBox = false;
            this.Controls.Add(this.cbExit);
            this.Controls.Add(this.tcListsMusic);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbWillStop);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbEndMusic);
            this.Controls.Add(this.nudSec);
            this.Controls.Add(this.nudMin);
            this.Controls.Add(this.nudHour);
            this.Controls.Add(this.nudVolume);
            this.Controls.Add(this.cbRandom);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.bAdd);
            this.Controls.Add(this.bPrevious);
            this.Controls.Add(this.bNextSong);
            this.Controls.Add(this.bSetting);
            this.Controls.Add(this.bExit);
            this.Controls.Add(this.wmp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "TimeForSleep";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.nudVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wmp)).EndInit();
            this.tcListsMusic.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bExit;
        private System.Windows.Forms.Button bSetting;
        private System.Windows.Forms.Button bNextSong;
        private System.Windows.Forms.Button bPrevious;
        private System.Windows.Forms.Button bAdd;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox cbRandom;
        private System.Windows.Forms.NumericUpDown nudVolume;
        private AxWMPLib.AxWindowsMediaPlayer wmp;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NumericUpDown nudHour;
        private System.Windows.Forms.NumericUpDown nudMin;
        private System.Windows.Forms.NumericUpDown nudSec;
        private System.Windows.Forms.CheckBox cbEndMusic;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer sleeper;
        private System.Windows.Forms.CheckBox cbWillStop;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabControl tcListsMusic;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckBox cbExit;
    }
}

