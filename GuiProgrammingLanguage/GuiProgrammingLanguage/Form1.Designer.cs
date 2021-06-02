
namespace GuiProgrammingLanguage
{
    partial class RootIDE
    {
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RootIDE));
            this.txt_code = new System.Windows.Forms.RichTextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_linecount = new System.Windows.Forms.RichTextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btn_exec = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_performance = new System.Windows.Forms.Label();
            this.panel = new System.Windows.Forms.Panel();
            this.btn_saida = new System.Windows.Forms.Button();
            this.btn_memoria = new System.Windows.Forms.Button();
            this.txt_memory = new System.Windows.Forms.RichTextBox();
            this.txt_output = new System.Windows.Forms.RichTextBox();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_exec)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_code
            // 
            this.txt_code.AcceptsTab = true;
            this.txt_code.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txt_code.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_code.CausesValidation = false;
            this.txt_code.DetectUrls = false;
            resources.ApplyResources(this.txt_code, "txt_code");
            this.txt_code.ForeColor = System.Drawing.Color.White;
            this.txt_code.Name = "txt_code";
            this.txt_code.ShowSelectionMargin = true;
            this.txt_code.TextChanged += new System.EventHandler(this.txt_code_TextChanged_1);
            // 
            // panel4
            // 
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.panel4.Controls.Add(this.pictureBox1);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Name = "panel4";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Name = "label3";
            // 
            // txt_linecount
            // 
            this.txt_linecount.AcceptsTab = true;
            resources.ApplyResources(this.txt_linecount, "txt_linecount");
            this.txt_linecount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txt_linecount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_linecount.CausesValidation = false;
            this.txt_linecount.DetectUrls = false;
            this.txt_linecount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(198)))), ((int)(((byte)(198)))));
            this.txt_linecount.Name = "txt_linecount";
            this.txt_linecount.ReadOnly = true;
            this.txt_linecount.ShortcutsEnabled = false;
            this.txt_linecount.ShowSelectionMargin = true;
            // 
            // panel5
            // 
            resources.ApplyResources(this.panel5, "panel5");
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.panel5.Controls.Add(this.btn_exec);
            this.panel5.Name = "panel5";
            // 
            // btn_exec
            // 
            this.btn_exec.BackColor = System.Drawing.Color.Transparent;
            this.btn_exec.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btn_exec, "btn_exec");
            this.btn_exec.Name = "btn_exec";
            this.btn_exec.TabStop = false;
            this.btn_exec.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panel1.Controls.Add(this.lbl_performance);
            this.panel1.Name = "panel1";
            // 
            // lbl_performance
            // 
            resources.ApplyResources(this.lbl_performance, "lbl_performance");
            this.lbl_performance.ForeColor = System.Drawing.Color.White;
            this.lbl_performance.Name = "lbl_performance";
            // 
            // panel
            // 
            this.panel.Controls.Add(this.txt_output);
            this.panel.Controls.Add(this.btn_saida);
            this.panel.Controls.Add(this.txt_memory);
            this.panel.Controls.Add(this.btn_memoria);
            resources.ApplyResources(this.panel, "panel");
            this.panel.Name = "panel";
            // 
            // btn_saida
            // 
            this.btn_saida.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.btn_saida, "btn_saida");
            this.btn_saida.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.btn_saida.FlatAppearance.BorderSize = 2;
            this.btn_saida.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.btn_saida.Name = "btn_saida";
            this.btn_saida.UseVisualStyleBackColor = false;
            this.btn_saida.Click += new System.EventHandler(this.btn_memoria_Click);
            // 
            // btn_memoria
            // 
            this.btn_memoria.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.btn_memoria, "btn_memoria");
            this.btn_memoria.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.btn_memoria.FlatAppearance.BorderSize = 2;
            this.btn_memoria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.btn_memoria.Name = "btn_memoria";
            this.btn_memoria.UseVisualStyleBackColor = false;
            this.btn_memoria.Click += new System.EventHandler(this.btn_saída_Click);
            // 
            // txt_memory
            // 
            this.txt_memory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.txt_memory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_memory.Cursor = System.Windows.Forms.Cursors.Arrow;
            resources.ApplyResources(this.txt_memory, "txt_memory");
            this.txt_memory.ForeColor = System.Drawing.Color.White;
            this.txt_memory.Name = "txt_memory";
            this.txt_memory.ReadOnly = true;
            // 
            // txt_output
            // 
            this.txt_output.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.txt_output.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_output.Cursor = System.Windows.Forms.Cursors.Arrow;
            resources.ApplyResources(this.txt_output, "txt_output");
            this.txt_output.ForeColor = System.Drawing.Color.White;
            this.txt_output.Name = "txt_output";
            this.txt_output.ReadOnly = true;
            // 
            // RootIDE
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.txt_code);
            this.Controls.Add(this.txt_linecount);
            this.Controls.Add(this.panel);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Name = "RootIDE";
            this.Load += new System.EventHandler(this.RootIDE_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btn_exec)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox txt_code;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RichTextBox txt_linecount;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox btn_exec;
        private System.Windows.Forms.Label lbl_performance;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button btn_memoria;
        private System.Windows.Forms.Button btn_saida;
        private System.Windows.Forms.RichTextBox txt_memory;
        private System.Windows.Forms.RichTextBox txt_output;
    }
}

