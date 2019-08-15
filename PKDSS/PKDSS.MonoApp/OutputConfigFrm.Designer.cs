namespace PKDSS.MonoApp
{
    partial class OutputConfigFrm
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
            this.chklbOutput = new System.Windows.Forms.CheckedListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnConfigOK = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnConfigCancel = new Bunifu.Framework.UI.BunifuFlatButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // chklbOutput
            // 
            this.chklbOutput.CheckOnClick = true;
            this.chklbOutput.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chklbOutput.FormattingEnabled = true;
            this.chklbOutput.Location = new System.Drawing.Point(9, 6);
            this.chklbOutput.Name = "chklbOutput";
            this.chklbOutput.Size = new System.Drawing.Size(233, 466);
            this.chklbOutput.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PKDSS.MonoApp.Properties.Resources.icons8_automatic_800;
            this.pictureBox1.Location = new System.Drawing.Point(311, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(157, 139);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // btnConfigOK
            // 
            this.btnConfigOK.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(134)))), ((int)(((byte)(255)))));
            this.btnConfigOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(134)))), ((int)(((byte)(255)))));
            this.btnConfigOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConfigOK.BorderRadius = 0;
            this.btnConfigOK.ButtonText = "OK";
            this.btnConfigOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfigOK.DisabledColor = System.Drawing.Color.Gray;
            this.btnConfigOK.Iconcolor = System.Drawing.Color.Transparent;
            this.btnConfigOK.Iconimage = global::PKDSS.MonoApp.Properties.Resources.icons8_checked_80;
            this.btnConfigOK.Iconimage_right = null;
            this.btnConfigOK.Iconimage_right_Selected = null;
            this.btnConfigOK.Iconimage_Selected = null;
            this.btnConfigOK.IconMarginLeft = 0;
            this.btnConfigOK.IconMarginRight = 0;
            this.btnConfigOK.IconRightVisible = true;
            this.btnConfigOK.IconRightZoom = 0D;
            this.btnConfigOK.IconVisible = true;
            this.btnConfigOK.IconZoom = 70D;
            this.btnConfigOK.IsTab = false;
            this.btnConfigOK.Location = new System.Drawing.Point(272, 425);
            this.btnConfigOK.Name = "btnConfigOK";
            this.btnConfigOK.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(134)))), ((int)(((byte)(255)))));
            this.btnConfigOK.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.btnConfigOK.OnHoverTextColor = System.Drawing.Color.White;
            this.btnConfigOK.selected = false;
            this.btnConfigOK.Size = new System.Drawing.Size(102, 47);
            this.btnConfigOK.TabIndex = 2;
            this.btnConfigOK.Text = "OK";
            this.btnConfigOK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfigOK.Textcolor = System.Drawing.Color.White;
            this.btnConfigOK.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfigOK.Click += new System.EventHandler(this.btnConfigOK_Click);
            // 
            // btnConfigCancel
            // 
            this.btnConfigCancel.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnConfigCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(134)))), ((int)(((byte)(255)))));
            this.btnConfigCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConfigCancel.BorderRadius = 0;
            this.btnConfigCancel.ButtonText = "Cancel";
            this.btnConfigCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfigCancel.DisabledColor = System.Drawing.Color.Gray;
            this.btnConfigCancel.Iconcolor = System.Drawing.Color.Transparent;
            this.btnConfigCancel.Iconimage = global::PKDSS.MonoApp.Properties.Resources.icons8_cancel_80;
            this.btnConfigCancel.Iconimage_right = null;
            this.btnConfigCancel.Iconimage_right_Selected = null;
            this.btnConfigCancel.Iconimage_Selected = null;
            this.btnConfigCancel.IconMarginLeft = 0;
            this.btnConfigCancel.IconMarginRight = 0;
            this.btnConfigCancel.IconRightVisible = true;
            this.btnConfigCancel.IconRightZoom = 0D;
            this.btnConfigCancel.IconVisible = true;
            this.btnConfigCancel.IconZoom = 70D;
            this.btnConfigCancel.IsTab = false;
            this.btnConfigCancel.Location = new System.Drawing.Point(401, 425);
            this.btnConfigCancel.Name = "btnConfigCancel";
            this.btnConfigCancel.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(134)))), ((int)(((byte)(255)))));
            this.btnConfigCancel.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.btnConfigCancel.OnHoverTextColor = System.Drawing.Color.White;
            this.btnConfigCancel.selected = false;
            this.btnConfigCancel.Size = new System.Drawing.Size(102, 48);
            this.btnConfigCancel.TabIndex = 1;
            this.btnConfigCancel.Text = "Cancel";
            this.btnConfigCancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfigCancel.Textcolor = System.Drawing.Color.White;
            this.btnConfigCancel.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfigCancel.Click += new System.EventHandler(this.btnConfigCancel_Click);
            // 
            // OutputConfigFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 481);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.chklbOutput);
            this.Controls.Add(this.btnConfigOK);
            this.Controls.Add(this.btnConfigCancel);
            this.Name = "OutputConfigFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OutputConfigFrm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuFlatButton btnConfigCancel;
        private Bunifu.Framework.UI.BunifuFlatButton btnConfigOK;
        private System.Windows.Forms.CheckedListBox chklbOutput;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}