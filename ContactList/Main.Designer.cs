
namespace ContactList
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.rtbComment = new System.Windows.Forms.RichTextBox();
            this.tbFirstName = new System.Windows.Forms.TextBox();
            this.tbLastName = new System.Windows.Forms.TextBox();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.tbCompany = new System.Windows.Forms.TextBox();
            this.tbPosition = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbPhoneNr = new System.Windows.Forms.TextBox();
            this.butSave = new System.Windows.Forms.Button();
            this.butDelete = new System.Windows.Forms.Button();
            this.dgvContactList = new System.Windows.Forms.DataGridView();
            this.butRefresh = new System.Windows.Forms.Button();
            this.butEditContact = new System.Windows.Forms.Button();
            this.butSaveAsNew = new System.Windows.Forms.Button();
            this.butAddPicture = new System.Windows.Forms.Button();
            this.pbProfilPicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContactList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProfilPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 225);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Imię:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 269);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nazwisko:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(184, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Zdjęcie (kliknij ramkę aby dodać):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 357);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Email:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 401);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Typ:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 445);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "Firma:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 533);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "Uwagi:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 489);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "Stanowisko:";
            // 
            // cmbType
            // 
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(12, 419);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(184, 23);
            this.cmbType.TabIndex = 1;
            // 
            // rtbComment
            // 
            this.rtbComment.Location = new System.Drawing.Point(12, 551);
            this.rtbComment.Name = "rtbComment";
            this.rtbComment.Size = new System.Drawing.Size(184, 82);
            this.rtbComment.TabIndex = 3;
            this.rtbComment.Text = "";
            // 
            // tbFirstName
            // 
            this.tbFirstName.Location = new System.Drawing.Point(12, 243);
            this.tbFirstName.Name = "tbFirstName";
            this.tbFirstName.Size = new System.Drawing.Size(184, 23);
            this.tbFirstName.TabIndex = 4;
            // 
            // tbLastName
            // 
            this.tbLastName.Location = new System.Drawing.Point(12, 287);
            this.tbLastName.Name = "tbLastName";
            this.tbLastName.Size = new System.Drawing.Size(184, 23);
            this.tbLastName.TabIndex = 4;
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(12, 375);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(184, 23);
            this.tbEmail.TabIndex = 4;
            // 
            // tbCompany
            // 
            this.tbCompany.Location = new System.Drawing.Point(12, 463);
            this.tbCompany.Name = "tbCompany";
            this.tbCompany.Size = new System.Drawing.Size(184, 23);
            this.tbCompany.TabIndex = 4;
            // 
            // tbPosition
            // 
            this.tbPosition.Location = new System.Drawing.Point(12, 507);
            this.tbPosition.Name = "tbPosition";
            this.tbPosition.Size = new System.Drawing.Size(184, 23);
            this.tbPosition.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 313);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(24, 15);
            this.label9.TabIndex = 0;
            this.label9.Text = "Tel:";
            // 
            // tbPhoneNr
            // 
            this.tbPhoneNr.Location = new System.Drawing.Point(12, 331);
            this.tbPhoneNr.Name = "tbPhoneNr";
            this.tbPhoneNr.Size = new System.Drawing.Size(184, 23);
            this.tbPhoneNr.TabIndex = 4;
            // 
            // butSave
            // 
            this.butSave.Location = new System.Drawing.Point(241, 9);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(75, 46);
            this.butSave.TabIndex = 5;
            this.butSave.Text = "Zapisz";
            this.butSave.UseVisualStyleBackColor = true;
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // butDelete
            // 
            this.butDelete.Location = new System.Drawing.Point(605, 9);
            this.butDelete.Name = "butDelete";
            this.butDelete.Size = new System.Drawing.Size(75, 46);
            this.butDelete.TabIndex = 5;
            this.butDelete.Text = "Usuń";
            this.butDelete.UseVisualStyleBackColor = true;
            this.butDelete.Click += new System.EventHandler(this.butDelete_Click);
            // 
            // dgvContactList
            // 
            this.dgvContactList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvContactList.BackgroundColor = System.Drawing.Color.White;
            this.dgvContactList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContactList.Location = new System.Drawing.Point(241, 61);
            this.dgvContactList.Name = "dgvContactList";
            this.dgvContactList.RowHeadersVisible = false;
            this.dgvContactList.RowTemplate.Height = 25;
            this.dgvContactList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvContactList.Size = new System.Drawing.Size(955, 572);
            this.dgvContactList.TabIndex = 6;
            // 
            // butRefresh
            // 
            this.butRefresh.Location = new System.Drawing.Point(686, 9);
            this.butRefresh.Name = "butRefresh";
            this.butRefresh.Size = new System.Drawing.Size(75, 46);
            this.butRefresh.TabIndex = 5;
            this.butRefresh.Text = "Odśwież";
            this.butRefresh.UseVisualStyleBackColor = true;
            this.butRefresh.Click += new System.EventHandler(this.burRefresh_Click);
            // 
            // butEditContact
            // 
            this.butEditContact.Location = new System.Drawing.Point(524, 9);
            this.butEditContact.Name = "butEditContact";
            this.butEditContact.Size = new System.Drawing.Size(75, 46);
            this.butEditContact.TabIndex = 5;
            this.butEditContact.Text = "Edycja";
            this.butEditContact.UseVisualStyleBackColor = true;
            this.butEditContact.Click += new System.EventHandler(this.bEditContact_Click);
            // 
            // butSaveAsNew
            // 
            this.butSaveAsNew.Location = new System.Drawing.Point(322, 9);
            this.butSaveAsNew.Name = "butSaveAsNew";
            this.butSaveAsNew.Size = new System.Drawing.Size(75, 46);
            this.butSaveAsNew.TabIndex = 7;
            this.butSaveAsNew.Text = "Zapisz Nowy";
            this.butSaveAsNew.UseVisualStyleBackColor = true;
            this.butSaveAsNew.Click += new System.EventHandler(this.butSaveAsNew_Click);
            // 
            // butAddPicture
            // 
            this.butAddPicture.Location = new System.Drawing.Point(403, 9);
            this.butAddPicture.Name = "butAddPicture";
            this.butAddPicture.Size = new System.Drawing.Size(75, 46);
            this.butAddPicture.TabIndex = 8;
            this.butAddPicture.Text = "Dodaj zdjęcie";
            this.butAddPicture.UseVisualStyleBackColor = true;
            this.butAddPicture.Click += new System.EventHandler(this.butAddPicture_Click);
            // 
            // pbProfilPicture
            // 
            this.pbProfilPicture.Location = new System.Drawing.Point(12, 27);
            this.pbProfilPicture.Name = "pbProfilPicture";
            this.pbProfilPicture.Size = new System.Drawing.Size(184, 185);
            this.pbProfilPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbProfilPicture.TabIndex = 9;
            this.pbProfilPicture.TabStop = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1247, 649);
            this.Controls.Add(this.pbProfilPicture);
            this.Controls.Add(this.butAddPicture);
            this.Controls.Add(this.butSaveAsNew);
            this.Controls.Add(this.dgvContactList);
            this.Controls.Add(this.butRefresh);
            this.Controls.Add(this.butEditContact);
            this.Controls.Add(this.butDelete);
            this.Controls.Add(this.butSave);
            this.Controls.Add(this.tbPosition);
            this.Controls.Add(this.tbCompany);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.tbPhoneNr);
            this.Controls.Add(this.tbLastName);
            this.Controls.Add(this.tbFirstName);
            this.Controls.Add(this.rtbComment);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MainWindow";
            this.Text = "Lista kontaktów";
            ((System.ComponentModel.ISupportInitialize)(this.dgvContactList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProfilPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.RichTextBox rtbComment;
        private System.Windows.Forms.TextBox tbFirstName;
        private System.Windows.Forms.TextBox tbLastName;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.TextBox tbCompany;
        private System.Windows.Forms.TextBox tbPosition;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbPhoneNr;
        private System.Windows.Forms.Button butSave;
        private System.Windows.Forms.Button butDelete;
        private System.Windows.Forms.DataGridView dgvContactList;
        private System.Windows.Forms.Button butRefresh;
        private System.Windows.Forms.Button butEditContact;
        private System.Windows.Forms.Button butSaveAsNew;
        private System.Windows.Forms.Button butAddPicture;
        private System.Windows.Forms.PictureBox pbProfilPicture;
    }
}

