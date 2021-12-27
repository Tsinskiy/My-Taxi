
namespace AdminsTools
{
    partial class FormAddNewCar
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbCarNumber = new System.Windows.Forms.TextBox();
            this.tbDriverName = new System.Windows.Forms.TextBox();
            this.tbSurname7 = new System.Windows.Forms.Label();
            this.tbCarDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Car Number";
            // 
            // tbCarNumber
            // 
            this.tbCarNumber.Location = new System.Drawing.Point(155, 21);
            this.tbCarNumber.Name = "tbCarNumber";
            this.tbCarNumber.Size = new System.Drawing.Size(242, 20);
            this.tbCarNumber.TabIndex = 1;
            this.tbCarNumber.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbCarNumber_KeyUp);
            // 
            // tbDriverName
            // 
            this.tbDriverName.Location = new System.Drawing.Point(155, 68);
            this.tbDriverName.Name = "tbDriverName";
            this.tbDriverName.Size = new System.Drawing.Size(242, 20);
            this.tbDriverName.TabIndex = 2;
            this.tbDriverName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbDriverName_KeyUp);
            // 
            // tbSurname7
            // 
            this.tbSurname7.AutoSize = true;
            this.tbSurname7.Location = new System.Drawing.Point(22, 75);
            this.tbSurname7.Name = "tbSurname7";
            this.tbSurname7.Size = new System.Drawing.Size(66, 13);
            this.tbSurname7.TabIndex = 2;
            this.tbSurname7.Text = "Driver Name";
            // 
            // tbCarDescription
            // 
            this.tbCarDescription.Location = new System.Drawing.Point(155, 119);
            this.tbCarDescription.Multiline = true;
            this.tbCarDescription.Name = "tbCarDescription";
            this.tbCarDescription.Size = new System.Drawing.Size(242, 90);
            this.tbCarDescription.TabIndex = 3;
            this.tbCarDescription.TextChanged += new System.EventHandler(this.tbCarDescription_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Car Descriptipon";
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnOk.Location = new System.Drawing.Point(155, 229);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(107, 24);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "Add";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnCancel.Location = new System.Drawing.Point(290, 228);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(107, 25);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // FormAddNewCar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 275);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.tbCarDescription);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbDriverName);
            this.Controls.Add(this.tbSurname7);
            this.Controls.Add(this.tbCarNumber);
            this.Controls.Add(this.label1);
            this.Name = "FormAddNewCar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form Add New Car";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbCarNumber;
        private System.Windows.Forms.TextBox tbDriverName;
        private System.Windows.Forms.Label tbSurname7;
        private System.Windows.Forms.TextBox tbCarDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}