namespace projet
{
    partial class matiere
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
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.t_desgn = new System.Windows.Forms.TextBox();
            this.t_Codefilere = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(859, 87);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(193, 31);
            this.button5.TabIndex = 45;
            this.button5.Text = "Rechercher";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(859, 41);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(193, 31);
            this.button4.TabIndex = 44;
            this.button4.Text = "Supprimer";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(591, 142);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(193, 31);
            this.button3.TabIndex = 43;
            this.button3.Text = "Modifier";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(591, 89);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(193, 31);
            this.button2.TabIndex = 42;
            this.button2.Text = "Ajouter";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(591, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(193, 31);
            this.button1.TabIndex = 41;
            this.button1.Text = "Nouveau";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // t_desgn
            // 
            this.t_desgn.Location = new System.Drawing.Point(189, 112);
            this.t_desgn.Name = "t_desgn";
            this.t_desgn.Size = new System.Drawing.Size(375, 27);
            this.t_desgn.TabIndex = 40;
            // 
            // t_Codefilere
            // 
            this.t_Codefilere.Location = new System.Drawing.Point(189, 55);
            this.t_Codefilere.Name = "t_Codefilere";
            this.t_Codefilere.Size = new System.Drawing.Size(375, 27);
            this.t_Codefilere.TabIndex = 39;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 20);
            this.label4.TabIndex = 38;
            this.label4.Text = "Designation";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 20);
            this.label3.TabIndex = 37;
            this.label3.Text = "Code matière";
            // 
            // matiere
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 211);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.t_desgn);
            this.Controls.Add(this.t_Codefilere);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Name = "matiere";
            this.Text = "Gestion des matières";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.matiere_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button5;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button1;
        private TextBox t_desgn;
        private TextBox t_Codefilere;
        private Label label4;
        private Label label3;
    }
}