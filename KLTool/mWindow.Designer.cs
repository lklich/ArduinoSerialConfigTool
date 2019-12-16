namespace KLTool
{
    partial class mWindow
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
            this.cbPort = new System.Windows.Forms.ComboBox();
            this.grConfig = new System.Windows.Forms.GroupBox();
            this.minLight = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.chDebug = new System.Windows.Forms.CheckBox();
            this.numHist = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numCzas = new System.Windows.Forms.NumericUpDown();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.sPort = new System.IO.Ports.SerialPort(this.components);
            this.pAnalyze = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lLev = new System.Windows.Forms.Label();
            this.lMov = new System.Windows.Forms.Label();
            this.labelDay = new System.Windows.Forms.Label();
            this.lDay = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.lRelay = new System.Windows.Forms.Label();
            this.btnDebug = new System.Windows.Forms.Button();
            this.btnConfig = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDefault = new System.Windows.Forms.Button();
            this.grConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minLight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCzas)).BeginInit();
            this.pAnalyze.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Port urządzenia:";
            // 
            // cbPort
            // 
            this.cbPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPort.FormattingEnabled = true;
            this.cbPort.Location = new System.Drawing.Point(134, 12);
            this.cbPort.Name = "cbPort";
            this.cbPort.Size = new System.Drawing.Size(166, 24);
            this.cbPort.TabIndex = 2;
            this.cbPort.DropDown += new System.EventHandler(this.cbPort_DropDown);
            // 
            // grConfig
            // 
            this.grConfig.Controls.Add(this.btnDefault);
            this.grConfig.Controls.Add(this.minLight);
            this.grConfig.Controls.Add(this.label5);
            this.grConfig.Controls.Add(this.chDebug);
            this.grConfig.Controls.Add(this.numHist);
            this.grConfig.Controls.Add(this.label4);
            this.grConfig.Controls.Add(this.label3);
            this.grConfig.Controls.Add(this.numCzas);
            this.grConfig.Enabled = false;
            this.grConfig.Location = new System.Drawing.Point(12, 42);
            this.grConfig.Name = "grConfig";
            this.grConfig.Size = new System.Drawing.Size(408, 92);
            this.grConfig.TabIndex = 3;
            this.grConfig.TabStop = false;
            this.grConfig.Text = "Parametry";
            // 
            // minLight
            // 
            this.minLight.Location = new System.Drawing.Point(164, 59);
            this.minLight.Maximum = new decimal(new int[] {
            254,
            0,
            0,
            0});
            this.minLight.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.minLight.Name = "minLight";
            this.minLight.Size = new System.Drawing.Size(62, 22);
            this.minLight.TabIndex = 7;
            this.minLight.Value = new decimal(new int[] {
            170,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(6, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "Minimalny poziom światła:";
            // 
            // chDebug
            // 
            this.chDebug.AutoSize = true;
            this.chDebug.Location = new System.Drawing.Point(9, 98);
            this.chDebug.Name = "chDebug";
            this.chDebug.Size = new System.Drawing.Size(140, 20);
            this.chDebug.TabIndex = 5;
            this.chDebug.Text = "Tryb debugowania";
            this.chDebug.UseVisualStyleBackColor = true;
            this.chDebug.Visible = false;
            // 
            // numHist
            // 
            this.numHist.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numHist.Location = new System.Drawing.Point(274, 21);
            this.numHist.Maximum = new decimal(new int[] {
            199,
            0,
            0,
            0});
            this.numHist.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numHist.Name = "numHist";
            this.numHist.Size = new System.Drawing.Size(62, 22);
            this.numHist.TabIndex = 4;
            this.numHist.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(206, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Histereza:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(6, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Czas do wyłączenia:";
            // 
            // numCzas
            // 
            this.numCzas.Location = new System.Drawing.Point(129, 21);
            this.numCzas.Maximum = new decimal(new int[] {
            254,
            0,
            0,
            0});
            this.numCzas.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numCzas.Name = "numCzas";
            this.numCzas.Size = new System.Drawing.Size(62, 22);
            this.numCzas.TabIndex = 1;
            this.numCzas.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(318, 12);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(85, 23);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "Połącz";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(12, 166);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.Size = new System.Drawing.Size(408, 217);
            this.txtLog.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(18, 137);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Log połączenia";
            // 
            // sPort
            // 
            this.sPort.ErrorReceived += new System.IO.Ports.SerialErrorReceivedEventHandler(this.sPort_ErrorReceived);
            // 
            // pAnalyze
            // 
            this.pAnalyze.Controls.Add(this.lRelay);
            this.pAnalyze.Controls.Add(this.label8);
            this.pAnalyze.Controls.Add(this.lDay);
            this.pAnalyze.Controls.Add(this.labelDay);
            this.pAnalyze.Controls.Add(this.lMov);
            this.pAnalyze.Controls.Add(this.lLev);
            this.pAnalyze.Controls.Add(this.label7);
            this.pAnalyze.Controls.Add(this.label6);
            this.pAnalyze.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.pAnalyze.Location = new System.Drawing.Point(12, 140);
            this.pAnalyze.Name = "pAnalyze";
            this.pAnalyze.Size = new System.Drawing.Size(408, 243);
            this.pAnalyze.TabIndex = 10;
            this.pAnalyze.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(217, 24);
            this.label6.TabIndex = 0;
            this.label6.Text = "Aktualny poziom światła:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(104, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 24);
            this.label7.TabIndex = 1;
            this.label7.Text = "Wykryto ruch:";
            // 
            // lLev
            // 
            this.lLev.AutoSize = true;
            this.lLev.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lLev.Location = new System.Drawing.Point(227, 16);
            this.lLev.Name = "lLev";
            this.lLev.Size = new System.Drawing.Size(19, 20);
            this.lLev.TabIndex = 2;
            this.lLev.Text = "0";
            // 
            // lMov
            // 
            this.lMov.AutoSize = true;
            this.lMov.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lMov.Location = new System.Drawing.Point(227, 55);
            this.lMov.Name = "lMov";
            this.lMov.Size = new System.Drawing.Size(96, 20);
            this.lMov.TabIndex = 3;
            this.lMov.Text = "Brak ruchu";
            // 
            // labelDay
            // 
            this.labelDay.AutoSize = true;
            this.labelDay.Location = new System.Drawing.Point(165, 86);
            this.labelDay.Name = "labelDay";
            this.labelDay.Size = new System.Drawing.Size(63, 24);
            this.labelDay.TabIndex = 4;
            this.labelDay.Text = "Dzień:";
            // 
            // lDay
            // 
            this.lDay.AutoSize = true;
            this.lDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lDay.Location = new System.Drawing.Point(227, 88);
            this.lDay.Name = "lDay";
            this.lDay.Size = new System.Drawing.Size(35, 20);
            this.lDay.TabIndex = 5;
            this.lDay.Text = "Nie";
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(123, 122);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 24);
            this.label8.TabIndex = 6;
            this.label8.Text = "Przekaźnik:";
            // 
            // lRelay
            // 
            this.lRelay.AutoSize = true;
            this.lRelay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lRelay.Location = new System.Drawing.Point(227, 124);
            this.lRelay.Name = "lRelay";
            this.lRelay.Size = new System.Drawing.Size(94, 20);
            this.lRelay.TabIndex = 7;
            this.lRelay.Text = "Wyłączony";
            // 
            // btnDebug
            // 
            this.btnDebug.Enabled = false;
            this.btnDebug.Image = global::KLTool.Properties.Resources.szczegoly;
            this.btnDebug.Location = new System.Drawing.Point(164, 389);
            this.btnDebug.Name = "btnDebug";
            this.btnDebug.Size = new System.Drawing.Size(110, 33);
            this.btnDebug.TabIndex = 9;
            this.btnDebug.Text = "Analizator";
            this.btnDebug.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnDebug.UseVisualStyleBackColor = true;
            this.btnDebug.Click += new System.EventHandler(this.btnDebug_Click);
            // 
            // btnConfig
            // 
            this.btnConfig.Enabled = false;
            this.btnConfig.Image = global::KLTool.Properties.Resources.naprawy;
            this.btnConfig.Location = new System.Drawing.Point(27, 389);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(94, 32);
            this.btnConfig.TabIndex = 8;
            this.btnConfig.Text = "Wyślij";
            this.btnConfig.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnConfig.UseVisualStyleBackColor = true;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // btnExit
            // 
            this.btnExit.Image = global::KLTool.Properties.Resources.zamknij;
            this.btnExit.Location = new System.Drawing.Point(303, 389);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 32);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Zakończ";
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDefault
            // 
            this.btnDefault.Location = new System.Drawing.Point(261, 58);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(130, 23);
            this.btnDefault.TabIndex = 8;
            this.btnDefault.Text = "Resetuj domyślne";
            this.btnDefault.UseVisualStyleBackColor = true;
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // mWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 429);
            this.Controls.Add(this.pAnalyze);
            this.Controls.Add(this.btnDebug);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.grConfig);
            this.Controls.Add(this.cbPort);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "mWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LK Tool 1.0 ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mWindow_FormClosing);
            this.Load += new System.EventHandler(this.mWindow_Load);
            this.grConfig.ResumeLayout(false);
            this.grConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minLight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCzas)).EndInit();
            this.pAnalyze.ResumeLayout(false);
            this.pAnalyze.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbPort;
        private System.Windows.Forms.GroupBox grConfig;
        private System.Windows.Forms.NumericUpDown minLight;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chDebug;
        private System.Windows.Forms.NumericUpDown numHist;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numCzas;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnConfig;
        private System.IO.Ports.SerialPort sPort;
        private System.Windows.Forms.Button btnDebug;
        private System.Windows.Forms.Panel pAnalyze;
        private System.Windows.Forms.Label lDay;
        private System.Windows.Forms.Label labelDay;
        private System.Windows.Forms.Label lMov;
        private System.Windows.Forms.Label lLev;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lRelay;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnDefault;
    }
}