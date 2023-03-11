namespace projet
{
    partial class Bilan
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
            this.t_MoyAnn = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.b_Rechercher = new System.Windows.Forms.Button();
            this.t_Niveau = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.t_Etudiant = new System.Windows.Forms.ComboBox();
            this.t_Filiere = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // t_MoyAnn
            // 
            this.t_MoyAnn.Location = new System.Drawing.Point(337, 417);
            this.t_MoyAnn.Name = "t_MoyAnn";
            this.t_MoyAnn.Size = new System.Drawing.Size(276, 27);
            this.t_MoyAnn.TabIndex = 38;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(80, 413);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 20);
            this.label2.TabIndex = 37;
            this.label2.Text = "Moyenne annuelle";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(42, 161);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(709, 217);
            this.dataGridView1.TabIndex = 36;
            // 
            // b_Rechercher
            // 
            this.b_Rechercher.Location = new System.Drawing.Point(522, 93);
            this.b_Rechercher.Name = "b_Rechercher";
            this.b_Rechercher.Size = new System.Drawing.Size(229, 29);
            this.b_Rechercher.TabIndex = 35;
            this.b_Rechercher.Text = "Rechercher";
            this.b_Rechercher.UseVisualStyleBackColor = true;
            // 
            // t_Niveau
            // 
            this.t_Niveau.FormattingEnabled = true;
            this.t_Niveau.Location = new System.Drawing.Point(522, 36);
            this.t_Niveau.Name = "t_Niveau";
            this.t_Niveau.Size = new System.Drawing.Size(221, 28);
            this.t_Niveau.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(422, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 33;
            this.label1.Text = "Niveau";
            // 
            // t_Etudiant
            // 
            this.t_Etudiant.FormattingEnabled = true;
            this.t_Etudiant.Location = new System.Drawing.Point(176, 93);
            this.t_Etudiant.Name = "t_Etudiant";
            this.t_Etudiant.Size = new System.Drawing.Size(179, 28);
            this.t_Etudiant.TabIndex = 32;
            // 
            // t_Filiere
            // 
            this.t_Filiere.FormattingEnabled = true;
            this.t_Filiere.Location = new System.Drawing.Point(176, 36);
            this.t_Filiere.Name = "t_Filiere";
            this.t_Filiere.Size = new System.Drawing.Size(179, 28);
            this.t_Filiere.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 20);
            this.label4.TabIndex = 30;
            this.label4.Text = "Etudiant";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 20);
            this.label3.TabIndex = 29;
            this.label3.Text = "Filière";
            // 
            // Bilan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 498);
            this.Controls.Add(this.t_MoyAnn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.b_Rechercher);
            this.Controls.Add(this.t_Niveau);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.t_Etudiant);
            this.Controls.Add(this.t_Filiere);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Name = "Bilan";
            this.Text = "Bilan annuel";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Bilan_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox t_MoyAnn;
        private Label label2;
        private DataGridView dataGridView1;
        private Button b_Rechercher;
        private ComboBox t_Niveau;
        private Label label1;
        private ComboBox t_Etudiant;
        private ComboBox t_Filiere;
        private Label label4;
        private Label label3;
    }
}