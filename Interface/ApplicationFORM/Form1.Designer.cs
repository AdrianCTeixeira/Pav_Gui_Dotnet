namespace ApplicationFORM
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
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.labelMarketCurrency = new System.Windows.Forms.Label();
            this.labelBaseCurrency = new System.Windows.Forms.Label();
            this.labelMarketCurrencyLong = new System.Windows.Forms.Label();
            this.labelMarketName = new System.Windows.Forms.Label();
            this.labelMinTradeSize = new System.Windows.Forms.Label();
            this.labelBaseCurrencyLong = new System.Windows.Forms.Label();
            this.labelNotice = new System.Windows.Forms.Label();
            this.labelCreated = new System.Windows.Forms.Label();
            this.labelIsRestricted = new System.Windows.Forms.Label();
            this.labelIsActive = new System.Windows.Forms.Label();
            this.labelIsSponsored = new System.Windows.Forms.Label();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.labelPrice = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.metroPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(231, 176);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 91);
            this.button1.TabIndex = 0;
            this.button1.Text = "Salvar Lista no BD";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(277, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(157, 139);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 49);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(198, 21);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.comboBox1_Format);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(357, 176);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 91);
            this.button2.TabIndex = 3;
            this.button2.Text = "Obter Lista no BD";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // labelMarketCurrency
            // 
            this.labelMarketCurrency.AutoSize = true;
            this.labelMarketCurrency.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelMarketCurrency.Location = new System.Drawing.Point(9, 79);
            this.labelMarketCurrency.Name = "labelMarketCurrency";
            this.labelMarketCurrency.Size = new System.Drawing.Size(88, 13);
            this.labelMarketCurrency.TabIndex = 4;
            this.labelMarketCurrency.Text = "MarketCurrency: ";
            this.labelMarketCurrency.Visible = false;
            this.labelMarketCurrency.Click += new System.EventHandler(this.labelMarketCurrency_Click);
            // 
            // labelBaseCurrency
            // 
            this.labelBaseCurrency.AutoSize = true;
            this.labelBaseCurrency.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelBaseCurrency.Location = new System.Drawing.Point(9, 96);
            this.labelBaseCurrency.Name = "labelBaseCurrency";
            this.labelBaseCurrency.Size = new System.Drawing.Size(79, 13);
            this.labelBaseCurrency.TabIndex = 5;
            this.labelBaseCurrency.Text = "BaseCurrency: ";
            this.labelBaseCurrency.Visible = false;
            this.labelBaseCurrency.Click += new System.EventHandler(this.labelBaseCurrency_Click);
            // 
            // labelMarketCurrencyLong
            // 
            this.labelMarketCurrencyLong.AutoSize = true;
            this.labelMarketCurrencyLong.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelMarketCurrencyLong.Location = new System.Drawing.Point(9, 113);
            this.labelMarketCurrencyLong.Name = "labelMarketCurrencyLong";
            this.labelMarketCurrencyLong.Size = new System.Drawing.Size(112, 13);
            this.labelMarketCurrencyLong.TabIndex = 6;
            this.labelMarketCurrencyLong.Text = "MarketCurrencyLong: ";
            this.labelMarketCurrencyLong.Visible = false;
            this.labelMarketCurrencyLong.Click += new System.EventHandler(this.labelMarketCurrencyLong_Click);
            // 
            // labelMarketName
            // 
            this.labelMarketName.AutoSize = true;
            this.labelMarketName.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelMarketName.Location = new System.Drawing.Point(9, 164);
            this.labelMarketName.Name = "labelMarketName";
            this.labelMarketName.Size = new System.Drawing.Size(74, 13);
            this.labelMarketName.TabIndex = 9;
            this.labelMarketName.Text = "MarketName: ";
            this.labelMarketName.Visible = false;
            this.labelMarketName.Click += new System.EventHandler(this.labelMarketName_Click);
            // 
            // labelMinTradeSize
            // 
            this.labelMinTradeSize.AutoSize = true;
            this.labelMinTradeSize.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelMinTradeSize.Location = new System.Drawing.Point(9, 147);
            this.labelMinTradeSize.Name = "labelMinTradeSize";
            this.labelMinTradeSize.Size = new System.Drawing.Size(78, 13);
            this.labelMinTradeSize.TabIndex = 8;
            this.labelMinTradeSize.Text = "MinTradeSize: ";
            this.labelMinTradeSize.Visible = false;
            this.labelMinTradeSize.Click += new System.EventHandler(this.labelMinTradeSize_Click);
            // 
            // labelBaseCurrencyLong
            // 
            this.labelBaseCurrencyLong.AutoSize = true;
            this.labelBaseCurrencyLong.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelBaseCurrencyLong.Location = new System.Drawing.Point(9, 130);
            this.labelBaseCurrencyLong.Name = "labelBaseCurrencyLong";
            this.labelBaseCurrencyLong.Size = new System.Drawing.Size(103, 13);
            this.labelBaseCurrencyLong.TabIndex = 7;
            this.labelBaseCurrencyLong.Text = "BaseCurrencyLong: ";
            this.labelBaseCurrencyLong.Visible = false;
            this.labelBaseCurrencyLong.Click += new System.EventHandler(this.labelBaseCurrencyLong_Click);
            // 
            // labelNotice
            // 
            this.labelNotice.AutoSize = true;
            this.labelNotice.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelNotice.Location = new System.Drawing.Point(9, 232);
            this.labelNotice.Name = "labelNotice";
            this.labelNotice.Size = new System.Drawing.Size(44, 13);
            this.labelNotice.TabIndex = 13;
            this.labelNotice.Text = "Notice: ";
            this.labelNotice.Visible = false;
            this.labelNotice.Click += new System.EventHandler(this.labelNotice_Click);
            // 
            // labelCreated
            // 
            this.labelCreated.AutoSize = true;
            this.labelCreated.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelCreated.Location = new System.Drawing.Point(9, 215);
            this.labelCreated.Name = "labelCreated";
            this.labelCreated.Size = new System.Drawing.Size(50, 13);
            this.labelCreated.TabIndex = 12;
            this.labelCreated.Text = "Created: ";
            this.labelCreated.Visible = false;
            this.labelCreated.Click += new System.EventHandler(this.labelCreated_Click);
            // 
            // labelIsRestricted
            // 
            this.labelIsRestricted.AutoSize = true;
            this.labelIsRestricted.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelIsRestricted.Location = new System.Drawing.Point(9, 198);
            this.labelIsRestricted.Name = "labelIsRestricted";
            this.labelIsRestricted.Size = new System.Drawing.Size(69, 13);
            this.labelIsRestricted.TabIndex = 11;
            this.labelIsRestricted.Text = "IsRestricted: ";
            this.labelIsRestricted.Visible = false;
            this.labelIsRestricted.Click += new System.EventHandler(this.labelIsRestricted_Click);
            // 
            // labelIsActive
            // 
            this.labelIsActive.AutoSize = true;
            this.labelIsActive.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelIsActive.Location = new System.Drawing.Point(9, 181);
            this.labelIsActive.Name = "labelIsActive";
            this.labelIsActive.Size = new System.Drawing.Size(51, 13);
            this.labelIsActive.TabIndex = 10;
            this.labelIsActive.Text = "IsActive: ";
            this.labelIsActive.Visible = false;
            this.labelIsActive.Click += new System.EventHandler(this.labelIsActive_Click);
            // 
            // labelIsSponsored
            // 
            this.labelIsSponsored.AutoSize = true;
            this.labelIsSponsored.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelIsSponsored.Location = new System.Drawing.Point(9, 248);
            this.labelIsSponsored.Name = "labelIsSponsored";
            this.labelIsSponsored.Size = new System.Drawing.Size(72, 13);
            this.labelIsSponsored.TabIndex = 14;
            this.labelIsSponsored.Text = "IsSponsored: ";
            this.labelIsSponsored.Visible = false;
            this.labelIsSponsored.Click += new System.EventHandler(this.labelIsSponsored_Click);
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.labelPrice);
            this.metroPanel1.Controls.Add(this.labelNotice);
            this.metroPanel1.Controls.Add(this.labelIsSponsored);
            this.metroPanel1.Controls.Add(this.comboBox1);
            this.metroPanel1.Controls.Add(this.labelCreated);
            this.metroPanel1.Controls.Add(this.button1);
            this.metroPanel1.Controls.Add(this.labelIsRestricted);
            this.metroPanel1.Controls.Add(this.pictureBox1);
            this.metroPanel1.Controls.Add(this.labelIsActive);
            this.metroPanel1.Controls.Add(this.button2);
            this.metroPanel1.Controls.Add(this.labelMarketName);
            this.metroPanel1.Controls.Add(this.labelMarketCurrency);
            this.metroPanel1.Controls.Add(this.labelMinTradeSize);
            this.metroPanel1.Controls.Add(this.labelBaseCurrency);
            this.metroPanel1.Controls.Add(this.labelBaseCurrencyLong);
            this.metroPanel1.Controls.Add(this.labelMarketCurrencyLong);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(0, -2);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(484, 284);
            this.metroPanel1.TabIndex = 15;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelPrice.Location = new System.Drawing.Point(9, 264);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(37, 13);
            this.labelPrice.TabIndex = 15;
            this.labelPrice.Text = "Price: ";
            this.labelPrice.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 282);
            this.Controls.Add(this.metroPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label labelMarketCurrency;
        private System.Windows.Forms.Label labelBaseCurrency;
        private System.Windows.Forms.Label labelMarketCurrencyLong;
        private System.Windows.Forms.Label labelMarketName;
        private System.Windows.Forms.Label labelMinTradeSize;
        private System.Windows.Forms.Label labelBaseCurrencyLong;
        private System.Windows.Forms.Label labelNotice;
        private System.Windows.Forms.Label labelCreated;
        private System.Windows.Forms.Label labelIsRestricted;
        private System.Windows.Forms.Label labelIsActive;
        private System.Windows.Forms.Label labelIsSponsored;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private System.Windows.Forms.Label labelPrice;
    }
}

