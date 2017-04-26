namespace TabelaFipe.UI
{
    partial class ListaMarcasForm
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSair = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvMarcas = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsMarcas = new System.Windows.Forms.BindingSource(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarcas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMarcas)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAdd,
            this.menuSair});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(790, 32);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuAdd
            // 
            this.menuAdd.Image = global::TabelaFipe.UI.Properties.Resources.plus;
            this.menuAdd.Name = "menuAdd";
            this.menuAdd.Size = new System.Drawing.Size(94, 28);
            this.menuAdd.Text = "&Adicionar";
            this.menuAdd.Click += new System.EventHandler(this.menuAdd_Click);
            // 
            // menuSair
            // 
            this.menuSair.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.menuSair.Image = global::TabelaFipe.UI.Properties.Resources.cancel_stop_exit_1583;
            this.menuSair.Name = "menuSair";
            this.menuSair.Size = new System.Drawing.Size(62, 28);
            this.menuSair.Text = "Sai&r";
            this.menuSair.Click += new System.EventHandler(this.menuSair_Click);
            // 
            // dgvMarcas
            // 
            this.dgvMarcas.AllowUserToAddRows = false;
            this.dgvMarcas.AllowUserToDeleteRows = false;
            this.dgvMarcas.AutoGenerateColumns = false;
            this.dgvMarcas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMarcas.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvMarcas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMarcas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Nome});
            this.dgvMarcas.DataSource = this.bsMarcas;
            this.dgvMarcas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMarcas.Location = new System.Drawing.Point(0, 32);
            this.dgvMarcas.Name = "dgvMarcas";
            this.dgvMarcas.ReadOnly = true;
            this.dgvMarcas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMarcas.Size = new System.Drawing.Size(790, 340);
            this.dgvMarcas.TabIndex = 1;
            this.dgvMarcas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMarcas_CellDoubleClick);
            this.dgvMarcas.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvMarcas_KeyUp);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // Nome
            // 
            this.Nome.DataPropertyName = "Nome";
            this.Nome.HeaderText = "Nome";
            this.Nome.Name = "Nome";
            this.Nome.ReadOnly = true;
            // 
            // ListaMarcasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 372);
            this.Controls.Add(this.dgvMarcas);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ListaMarcasForm";
            this.ShowIcon = false;
            this.Text = "Lista de Marcas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ListaMarcasForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarcas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMarcas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuAdd;
        private System.Windows.Forms.ToolStripMenuItem menuSair;
        private System.Windows.Forms.DataGridView dgvMarcas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
        private System.Windows.Forms.BindingSource bsMarcas;
    }
}