namespace yuasdw
{
    partial class frmHome
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
            this.btnStoreStatus = new System.Windows.Forms.Button();
            this.btnPriceBook = new System.Windows.Forms.Button();
            this.btnVendors = new System.Windows.Forms.Button();
            this.btnUser = new System.Windows.Forms.Button();
            this.btnTimeClock = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStoreStatus
            // 
            this.btnStoreStatus.Location = new System.Drawing.Point(226, 55);
            this.btnStoreStatus.Name = "btnStoreStatus";
            this.btnStoreStatus.Size = new System.Drawing.Size(128, 94);
            this.btnStoreStatus.TabIndex = 1;
            this.btnStoreStatus.Text = "Store Status";
            this.btnStoreStatus.UseVisualStyleBackColor = true;
            this.btnStoreStatus.Click += new System.EventHandler(this.btnStoreStatus_Click);
            // 
            // btnPriceBook
            // 
            this.btnPriceBook.Location = new System.Drawing.Point(376, 55);
            this.btnPriceBook.Name = "btnPriceBook";
            this.btnPriceBook.Size = new System.Drawing.Size(128, 94);
            this.btnPriceBook.TabIndex = 2;
            this.btnPriceBook.Text = "PriceBook";
            this.btnPriceBook.UseVisualStyleBackColor = true;
            this.btnPriceBook.Click += new System.EventHandler(this.btnPriceBook_Click);
            // 
            // btnVendors
            // 
            this.btnVendors.Location = new System.Drawing.Point(74, 167);
            this.btnVendors.Name = "btnVendors";
            this.btnVendors.Size = new System.Drawing.Size(128, 94);
            this.btnVendors.TabIndex = 3;
            this.btnVendors.Text = "Vendors";
            this.btnVendors.UseVisualStyleBackColor = true;
            this.btnVendors.Click += new System.EventHandler(this.btnVendors_Click);
            // 
            // btnUser
            // 
            this.btnUser.Location = new System.Drawing.Point(226, 167);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(128, 94);
            this.btnUser.TabIndex = 4;
            this.btnUser.Text = "Users";
            this.btnUser.UseVisualStyleBackColor = true;
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // btnTimeClock
            // 
            this.btnTimeClock.Location = new System.Drawing.Point(376, 167);
            this.btnTimeClock.Name = "btnTimeClock";
            this.btnTimeClock.Size = new System.Drawing.Size(128, 94);
            this.btnTimeClock.TabIndex = 5;
            this.btnTimeClock.Text = "Time Clock";
            this.btnTimeClock.UseVisualStyleBackColor = true;
            this.btnTimeClock.Click += new System.EventHandler(this.btnTimeClock_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(12, 281);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(66, 22);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 15.75F);
            this.label1.Location = new System.Drawing.Point(240, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 26);
            this.label1.TabIndex = 7;
            this.label1.Text = "Welcome";
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(74, 55);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(128, 94);
            this.btnRegister.TabIndex = 0;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // frmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 315);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnTimeClock);
            this.Controls.Add(this.btnUser);
            this.Controls.Add(this.btnVendors);
            this.Controls.Add(this.btnPriceBook);
            this.Controls.Add(this.btnStoreStatus);
            this.Controls.Add(this.btnRegister);
            this.Name = "frmHome";
            this.Text = "frmHome";
            this.Load += new System.EventHandler(this.frmHome_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnStoreStatus;
        private System.Windows.Forms.Button btnPriceBook;
        private System.Windows.Forms.Button btnVendors;
        private System.Windows.Forms.Button btnUser;
        private System.Windows.Forms.Button btnTimeClock;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label label1;
    }
}