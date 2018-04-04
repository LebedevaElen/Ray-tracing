namespace CG_4
{
    partial class MainForm
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
            this.GLControl = new OpenTK.GLControl();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.addBtn = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.isTraced = new System.Windows.Forms.CheckBox();
            this.tracingGroupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.recursionDepth = new System.Windows.Forms.NumericUpDown();
            this.loadBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.CheckBox();
            this.lightGroupBox = new System.Windows.Forms.GroupBox();
            this.lightPanel = new System.Windows.Forms.Panel();
            this.saveLightBtn = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lightX = new System.Windows.Forms.TextBox();
            this.lightZ = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lightY = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.LsR = new System.Windows.Forms.TextBox();
            this.LsB = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.LsG = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.LdR = new System.Windows.Forms.TextBox();
            this.LdB = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.LdG = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.LaR = new System.Windows.Forms.TextBox();
            this.LaB = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.LaG = new System.Windows.Forms.TextBox();
            this.tmrLimiter = new System.Windows.Forms.Timer(this.components);
            this.tracingGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recursionDepth)).BeginInit();
            this.lightGroupBox.SuspendLayout();
            this.lightPanel.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // GLControl
            // 
            this.GLControl.BackColor = System.Drawing.Color.Black;
            this.GLControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.GLControl.Location = new System.Drawing.Point(0, 0);
            this.GLControl.Name = "GLControl";
            this.GLControl.Size = new System.Drawing.Size(716, 543);
            this.GLControl.TabIndex = 0;
            this.GLControl.VSync = false;
            this.GLControl.Load += new System.EventHandler(this.GLControl_Load);
            this.GLControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GLControl_MouseDown);
            this.GLControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GLControl_MouseMove);
            this.GLControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GLControl_MouseUp);
            this.GLControl.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.GLControl_MouseWheel);
            // 
            // Timer
            // 
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(722, 32);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(165, 23);
            this.addBtn.TabIndex = 1;
            this.addBtn.Text = "Добавить объекты";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // isTraced
            // 
            this.isTraced.AutoSize = true;
            this.isTraced.Location = new System.Drawing.Point(6, 21);
            this.isTraced.Name = "isTraced";
            this.isTraced.Size = new System.Drawing.Size(143, 17);
            this.isTraced.TabIndex = 2;
            this.isTraced.Text = "Вкл/выкл трассировку";
            this.isTraced.UseVisualStyleBackColor = true;
            this.isTraced.CheckedChanged += new System.EventHandler(this.isTraced_CheckedChanged);
            // 
            // tracingGroupBox
            // 
            this.tracingGroupBox.Controls.Add(this.label1);
            this.tracingGroupBox.Controls.Add(this.recursionDepth);
            this.tracingGroupBox.Controls.Add(this.isTraced);
            this.tracingGroupBox.Location = new System.Drawing.Point(722, 86);
            this.tracingGroupBox.Name = "tracingGroupBox";
            this.tracingGroupBox.Size = new System.Drawing.Size(165, 71);
            this.tracingGroupBox.TabIndex = 3;
            this.tracingGroupBox.TabStop = false;
            this.tracingGroupBox.Text = "Трассировка";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Глубина рекурсии:";
            // 
            // recursionDepth
            // 
            this.recursionDepth.Location = new System.Drawing.Point(109, 41);
            this.recursionDepth.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.recursionDepth.Name = "recursionDepth";
            this.recursionDepth.Size = new System.Drawing.Size(50, 20);
            this.recursionDepth.TabIndex = 3;
            this.recursionDepth.ValueChanged += new System.EventHandler(this.recursionDepth_ValueChanged);
            // 
            // loadBtn
            // 
            this.loadBtn.Location = new System.Drawing.Point(722, 5);
            this.loadBtn.Name = "loadBtn";
            this.loadBtn.Size = new System.Drawing.Size(165, 23);
            this.loadBtn.TabIndex = 4;
            this.loadBtn.Text = "Загрузить объекты";
            this.loadBtn.UseVisualStyleBackColor = true;
            this.loadBtn.Click += new System.EventHandler(this.loadBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.AutoSize = true;
            this.deleteBtn.Location = new System.Drawing.Point(723, 63);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(162, 17);
            this.deleteBtn.TabIndex = 6;
            this.deleteBtn.Text = "Режим удаления объектов";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.CheckedChanged += new System.EventHandler(this.deleteBtn_CheckedChanged);
            // 
            // lightGroupBox
            // 
            this.lightGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lightGroupBox.Controls.Add(this.lightPanel);
            this.lightGroupBox.Location = new System.Drawing.Point(722, 163);
            this.lightGroupBox.Name = "lightGroupBox";
            this.lightGroupBox.Size = new System.Drawing.Size(165, 260);
            this.lightGroupBox.TabIndex = 7;
            this.lightGroupBox.TabStop = false;
            this.lightGroupBox.Text = "Освещение";
            // 
            // lightPanel
            // 
            this.lightPanel.Controls.Add(this.saveLightBtn);
            this.lightPanel.Controls.Add(this.groupBox3);
            this.lightPanel.Controls.Add(this.groupBox2);
            this.lightPanel.Location = new System.Drawing.Point(5, 19);
            this.lightPanel.Name = "lightPanel";
            this.lightPanel.Size = new System.Drawing.Size(158, 234);
            this.lightPanel.TabIndex = 24;
            // 
            // saveLightBtn
            // 
            this.saveLightBtn.Enabled = false;
            this.saveLightBtn.Location = new System.Drawing.Point(1, 209);
            this.saveLightBtn.Name = "saveLightBtn";
            this.saveLightBtn.Size = new System.Drawing.Size(153, 23);
            this.saveLightBtn.TabIndex = 25;
            this.saveLightBtn.Text = "Сохранить изменения";
            this.saveLightBtn.UseVisualStyleBackColor = true;
            this.saveLightBtn.Click += new System.EventHandler(this.saveLightBtn_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.lightX);
            this.groupBox3.Controls.Add(this.lightZ);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.lightY);
            this.groupBox3.Location = new System.Drawing.Point(1, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(152, 47);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Положение";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(101, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Z:";
            // 
            // lightX
            // 
            this.lightX.Location = new System.Drawing.Point(25, 18);
            this.lightX.Name = "lightX";
            this.lightX.Size = new System.Drawing.Size(25, 20);
            this.lightX.TabIndex = 22;
            this.lightX.Enter += new System.EventHandler(this.lightPropertiesChanged);
            this.lightX.Leave += new System.EventHandler(this.textboxLeave);
            // 
            // lightZ
            // 
            this.lightZ.Location = new System.Drawing.Point(118, 18);
            this.lightZ.Name = "lightZ";
            this.lightZ.Size = new System.Drawing.Size(25, 20);
            this.lightZ.TabIndex = 26;
            this.lightZ.Enter += new System.EventHandler(this.lightPropertiesChanged);
            this.lightZ.Leave += new System.EventHandler(this.textboxLeave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "X:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(55, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Y:";
            // 
            // lightY
            // 
            this.lightY.Location = new System.Drawing.Point(73, 18);
            this.lightY.Name = "lightY";
            this.lightY.Size = new System.Drawing.Size(25, 20);
            this.lightY.TabIndex = 24;
            this.lightY.Enter += new System.EventHandler(this.lightPropertiesChanged);
            this.lightY.Leave += new System.EventHandler(this.textboxLeave);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.LsR);
            this.groupBox2.Controls.Add(this.LsB);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.LsG);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.LdR);
            this.groupBox2.Controls.Add(this.LdB);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.LdG);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.LaR);
            this.groupBox2.Controls.Add(this.LaB);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.LaG);
            this.groupBox2.Location = new System.Drawing.Point(1, 53);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(152, 154);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Интенсивность";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 108);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(98, 13);
            this.label12.TabIndex = 29;
            this.label12.Text = "Отраженный свет";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(98, 129);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(17, 13);
            this.label13.TabIndex = 35;
            this.label13.Text = "B:";
            // 
            // LsR
            // 
            this.LsR.Location = new System.Drawing.Point(22, 126);
            this.LsR.Name = "LsR";
            this.LsR.Size = new System.Drawing.Size(25, 20);
            this.LsR.TabIndex = 30;
            this.LsR.Enter += new System.EventHandler(this.lightPropertiesChanged);
            this.LsR.Leave += new System.EventHandler(this.textboxLeave);
            // 
            // LsB
            // 
            this.LsB.Location = new System.Drawing.Point(115, 126);
            this.LsB.Name = "LsB";
            this.LsB.Size = new System.Drawing.Size(25, 20);
            this.LsB.TabIndex = 34;
            this.LsB.Enter += new System.EventHandler(this.lightPropertiesChanged);
            this.LsB.Leave += new System.EventHandler(this.textboxLeave);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 129);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(18, 13);
            this.label14.TabIndex = 31;
            this.label14.Text = "R:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(52, 129);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(18, 13);
            this.label15.TabIndex = 33;
            this.label15.Text = "G:";
            // 
            // LsG
            // 
            this.LsG.Location = new System.Drawing.Point(70, 126);
            this.LsG.Name = "LsG";
            this.LsG.Size = new System.Drawing.Size(25, 20);
            this.LsG.TabIndex = 32;
            this.LsG.Enter += new System.EventHandler(this.lightPropertiesChanged);
            this.LsG.Leave += new System.EventHandler(this.textboxLeave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Рассеянный свет";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(98, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 13);
            this.label8.TabIndex = 28;
            this.label8.Text = "B:";
            // 
            // LdR
            // 
            this.LdR.Location = new System.Drawing.Point(22, 81);
            this.LdR.Name = "LdR";
            this.LdR.Size = new System.Drawing.Size(25, 20);
            this.LdR.TabIndex = 23;
            this.LdR.Enter += new System.EventHandler(this.lightPropertiesChanged);
            this.LdR.Leave += new System.EventHandler(this.textboxLeave);
            // 
            // LdB
            // 
            this.LdB.Location = new System.Drawing.Point(115, 81);
            this.LdB.Name = "LdB";
            this.LdB.Size = new System.Drawing.Size(25, 20);
            this.LdB.TabIndex = 27;
            this.LdB.Enter += new System.EventHandler(this.lightPropertiesChanged);
            this.LdB.Leave += new System.EventHandler(this.textboxLeave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 84);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(18, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "R:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(52, 84);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(18, 13);
            this.label11.TabIndex = 26;
            this.label11.Text = "G:";
            // 
            // LdG
            // 
            this.LdG.Location = new System.Drawing.Point(70, 81);
            this.LdG.Name = "LdG";
            this.LdG.Size = new System.Drawing.Size(25, 20);
            this.LdG.TabIndex = 25;
            this.LdG.Enter += new System.EventHandler(this.lightPropertiesChanged);
            this.LdG.Leave += new System.EventHandler(this.textboxLeave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Фоновый свет";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(98, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "B:";
            // 
            // LaR
            // 
            this.LaR.Location = new System.Drawing.Point(22, 37);
            this.LaR.Name = "LaR";
            this.LaR.Size = new System.Drawing.Size(25, 20);
            this.LaR.TabIndex = 16;
            this.LaR.Enter += new System.EventHandler(this.lightPropertiesChanged);
            this.LaR.Leave += new System.EventHandler(this.textboxLeave);
            // 
            // LaB
            // 
            this.LaB.Location = new System.Drawing.Point(115, 37);
            this.LaB.Name = "LaB";
            this.LaB.Size = new System.Drawing.Size(25, 20);
            this.LaB.TabIndex = 20;
            this.LaB.Enter += new System.EventHandler(this.lightPropertiesChanged);
            this.LaB.Leave += new System.EventHandler(this.textboxLeave);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 40);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(18, 13);
            this.label16.TabIndex = 17;
            this.label16.Text = "R:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(52, 40);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(18, 13);
            this.label17.TabIndex = 19;
            this.label17.Text = "G:";
            // 
            // LaG
            // 
            this.LaG.Location = new System.Drawing.Point(70, 37);
            this.LaG.Name = "LaG";
            this.LaG.Size = new System.Drawing.Size(25, 20);
            this.LaG.TabIndex = 18;
            this.LaG.Enter += new System.EventHandler(this.lightPropertiesChanged);
            this.LaG.Leave += new System.EventHandler(this.textboxLeave);
            // 
            // tmrLimiter
            // 
            this.tmrLimiter.Tick += new System.EventHandler(this.tmrLimiter_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 543);
            this.Controls.Add(this.lightGroupBox);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.loadBtn);
            this.Controls.Add(this.tracingGroupBox);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.GLControl);
            this.MaximumSize = new System.Drawing.Size(908, 582);
            this.MinimumSize = new System.Drawing.Size(908, 582);
            this.Name = "MainForm";
            this.Text = "Ray tracing";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tracingGroupBox.ResumeLayout(false);
            this.tracingGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recursionDepth)).EndInit();
            this.lightGroupBox.ResumeLayout(false);
            this.lightPanel.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenTK.GLControl GLControl;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.CheckBox isTraced;
        private System.Windows.Forms.GroupBox tracingGroupBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown recursionDepth;
        private System.Windows.Forms.Button loadBtn;
        private System.Windows.Forms.CheckBox deleteBtn;
        private System.Windows.Forms.GroupBox lightGroupBox;
        private System.Windows.Forms.Panel lightPanel;
        private System.Windows.Forms.Button saveLightBtn;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox lightX;
        private System.Windows.Forms.TextBox lightZ;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox lightY;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox LsR;
        private System.Windows.Forms.TextBox LsB;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox LsG;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox LdR;
        private System.Windows.Forms.TextBox LdB;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox LdG;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox LaR;
        private System.Windows.Forms.TextBox LaB;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox LaG;
        private System.Windows.Forms.Timer tmrLimiter;
    }
}

