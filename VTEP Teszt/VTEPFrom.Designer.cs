

namespace VTEP_Teszt
{


    partial class VTEPForm
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
            txtResponse = new TextBox();
            panel1 = new Panel();
            lbStatus = new Label();
            btnSave = new Button();
            btnStart = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // txtResponse
            // 
            txtResponse.AcceptsReturn = true;
            txtResponse.Location = new Point(12, 12);
            txtResponse.Multiline = true;
            txtResponse.Name = "txtResponse";
            txtResponse.ScrollBars = ScrollBars.Horizontal;
            txtResponse.Size = new Size(624, 509);
            txtResponse.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(lbStatus);
            panel1.Controls.Add(btnSave);
            panel1.Controls.Add(btnStart);
            panel1.Location = new Point(642, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(193, 509);
            panel1.TabIndex = 1;
            // 
            // lbStatus
            // 
            lbStatus.AutoSize = true;
            lbStatus.Location = new Point(14, 483);
            lbStatus.Name = "lbStatus";
            lbStatus.Size = new Size(0, 15);
            lbStatus.TabIndex = 2;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(14, 430);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(161, 30);
            btnSave.TabIndex = 1;
            btnSave.Text = "Eredmény Mentése";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(14, 19);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(161, 28);
            btnStart.TabIndex = 0;
            btnStart.Text = "START";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // VTEPForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(847, 533);
            Controls.Add(panel1);
            Controls.Add(txtResponse);
            Name = "VTEPForm";
            Text = "VTEP Teszt";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtResponse;
        private Panel panel1;
        private Button btnStart;
        private Label lbStatus;
        private Button btnSave;
    }
}

