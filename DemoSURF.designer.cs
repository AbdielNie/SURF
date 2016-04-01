namespace OpenSURFDemo
{
  partial class DemoSURF
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
        this.btnOpenPic1 = new System.Windows.Forms.Button();
        this.btnOpenPic2 = new System.Windows.Forms.Button();
        this.pictureBox1 = new System.Windows.Forms.PictureBox();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
        this.SuspendLayout();
        // 
        // btnOpenPic1
        // 
        this.btnOpenPic1.Location = new System.Drawing.Point(12, 8);
        this.btnOpenPic1.Name = "btnOpenPic1";
        this.btnOpenPic1.Size = new System.Drawing.Size(134, 36);
        this.btnOpenPic1.TabIndex = 1;
        this.btnOpenPic1.Text = "step1:打开图片1";
        this.btnOpenPic1.UseVisualStyleBackColor = true;
        this.btnOpenPic1.Click += new System.EventHandler(this.btnOpenPic1_Click);
        // 
        // btnOpenPic2
        // 
        this.btnOpenPic2.Location = new System.Drawing.Point(166, 8);
        this.btnOpenPic2.Name = "btnOpenPic2";
        this.btnOpenPic2.Size = new System.Drawing.Size(158, 36);
        this.btnOpenPic2.TabIndex = 2;
        this.btnOpenPic2.Text = "step1:打开图片2 并处理";
        this.btnOpenPic2.UseVisualStyleBackColor = true;
        this.btnOpenPic2.Click += new System.EventHandler(this.btnOpenPic2_Click);
        // 
        // pictureBox1
        // 
        this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
        this.pictureBox1.Location = new System.Drawing.Point(3, 50);
        this.pictureBox1.Name = "pictureBox1";
        this.pictureBox1.Size = new System.Drawing.Size(413, 490);
        this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
        this.pictureBox1.TabIndex = 3;
        this.pictureBox1.TabStop = false;
        // 
        // DemoSURF
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(783, 540);
        this.Controls.Add(this.pictureBox1);
        this.Controls.Add(this.btnOpenPic2);
        this.Controls.Add(this.btnOpenPic1);
        this.Name = "DemoSURF";
        this.Text = "DemoSURF";
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnOpenPic1;
      private System.Windows.Forms.Button btnOpenPic2;
      private System.Windows.Forms.PictureBox pictureBox1;
  }
}

