namespace A_program_for_reading_RSS_feeds
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
            this.btnAddFeed = new System.Windows.Forms.Button();
            this.txtFeedUrl = new System.Windows.Forms.TextBox();
            this.lstRSSFeeds = new System.Windows.Forms.ListBox();
            this.txtFeedContent = new System.Windows.Forms.TextBox();
            this.lblFeedUrl = new System.Windows.Forms.Label();
            this.lblRSSFeeds = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAddFeed
            // 
            this.btnAddFeed.Location = new System.Drawing.Point(400, 30);
            this.btnAddFeed.Name = "btnAddFeed";
            this.btnAddFeed.Size = new System.Drawing.Size(75, 23);
            this.btnAddFeed.TabIndex = 0;
            this.btnAddFeed.Text = "Добавить";
            this.btnAddFeed.UseVisualStyleBackColor = true;
            this.btnAddFeed.Click += new System.EventHandler(this.btnAddFeed_Click);
            // 
            // txtFeedUrl
            // 
            this.txtFeedUrl.Location = new System.Drawing.Point(20, 30);
            this.txtFeedUrl.Name = "txtFeedUrl";
            this.txtFeedUrl.Size = new System.Drawing.Size(360, 20);
            this.txtFeedUrl.TabIndex = 1;
            // 
            // lstRSSFeeds
            // 
            this.lstRSSFeeds.FormattingEnabled = true;
            this.lstRSSFeeds.Location = new System.Drawing.Point(20, 100);
            this.lstRSSFeeds.Name = "lstRSSFeeds";
            this.lstRSSFeeds.Size = new System.Drawing.Size(200, 290);
            this.lstRSSFeeds.TabIndex = 2;
            this.lstRSSFeeds.SelectedIndexChanged += new System.EventHandler(this.lstRSSFeeds_SelectedIndexChanged);
            // 
            // txtFeedContent
            // 
            this.txtFeedContent.Location = new System.Drawing.Point(240, 100);
            this.txtFeedContent.Multiline = true;
            this.txtFeedContent.Name = "txtFeedContent";
            this.txtFeedContent.ReadOnly = true;
            this.txtFeedContent.Size = new System.Drawing.Size(400, 290);
            this.txtFeedContent.TabIndex = 3;
            // 
            // lblFeedUrl
            // 
            this.lblFeedUrl.AutoSize = true;
            this.lblFeedUrl.Location = new System.Drawing.Point(20, 10);
            this.lblFeedUrl.Name = "lblFeedUrl";
            this.lblFeedUrl.Size = new System.Drawing.Size(109, 13);
            this.lblFeedUrl.TabIndex = 4;
            this.lblFeedUrl.Text = "URL-адрес ленты";
            // 
            // lblRSSFeeds
            // 
            this.lblRSSFeeds.AutoSize = true;
            this.lblRSSFeeds.Location = new System.Drawing.Point(20, 80);
            this.lblRSSFeeds.Name = "lblRSSFeeds";
            this.lblRSSFeeds.Size = new System.Drawing.Size(82, 13);
            this.lblRSSFeeds.TabIndex = 5;
            this.lblRSSFeeds.Text = "Список лент";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 420);
            this.Controls.Add(this.lblRSSFeeds);
            this.Controls.Add(this.lblFeedUrl);
            this.Controls.Add(this.txtFeedContent);
            this.Controls.Add(this.lstRSSFeeds);
            this.Controls.Add(this.txtFeedUrl);
            this.Controls.Add(this.btnAddFeed);
            this.Name = "Form1";
            this.Text = "RSS Читалка";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnAddFeed;
        private System.Windows.Forms.TextBox txtFeedUrl;
        private System.Windows.Forms.ListBox lstRSSFeeds;
        private System.Windows.Forms.TextBox txtFeedContent;
        private System.Windows.Forms.Label lblFeedUrl;
        private System.Windows.Forms.Label lblRSSFeeds;
    }
}
