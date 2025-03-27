namespace Admin_Productos
{
    partial class Form1 : System.Windows.Forms.Form
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.label1 = CreateLabel("ID:", 30, 30);
            this.label2 = CreateLabel("Descripción:", 30, 80);
            this.label3 = CreateLabel("Marca:", 30, 130);
            this.label4 = CreateLabel("Precio:", 30, 180);
            this.labelStock = CreateLabel("Stock:", 30, 230);
            this.label5 = CreateLabel("Buscar por descripción:", 30, 290);

            this.textBoxID = CreateTextBox(160, 25, enabled: false);
            this.textBoxDescripcion = CreateTextBox(160, 75);
            this.textBoxMarca = CreateTextBox(160, 125);
            this.textBoxPrecio = CreateTextBox(160, 175);
            this.textBoxStock = CreateTextBox(160, 225);
            this.textBoxBuscador = CreateTextBox(250, 285);

            this.buttonDelete = CreateButton("Borrar", 650, 25, this.buttonDelete_Click);
            this.buttonClear = CreateButton("Limpiar", 770, 25, this.buttonClear_Click);
            this.buttonSave = CreateButton("Guardar", 890, 25, this.buttonSave_Click);

            this.buttonBuscar = CreateSecondaryButton("Buscar", 720, 282, this.buttonBuscar_Click);
            this.buttonReiniciar = CreateSecondaryButton("Reiniciar", 840, 282, this.buttonReiniciar_Click);


            this.dataGridViewProductos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProductos)).BeginInit();
            this.dataGridViewProductos.Location = new System.Drawing.Point(30, 330);
            this.dataGridViewProductos.Size = new System.Drawing.Size(970, 390);
            this.dataGridViewProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewProductos.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dataGridViewProductos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewProductos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProductos_CellClick);

            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Text = "Administrador de Productos";
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Load += new System.EventHandler(this.Form1_Load);

            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                label1, label2, label3, label4, labelStock, label5,
                textBoxID, textBoxDescripcion, textBoxMarca, textBoxPrecio, textBoxStock, textBoxBuscador,
                buttonDelete, buttonClear, buttonSave,
                buttonBuscar, buttonReiniciar,
                dataGridViewProductos,
            });

            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

            var labelAutor = new Label
            {
                Text = "Desarrollado por Yair Castagnola",
                AutoSize = true,
                Font = new Font("Segoe UI", 10F, FontStyle.Regular),
                ForeColor = Color.SteelBlue,
                Location = new Point(ClientSize.Width - 230, ClientSize.Height - 35),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right
            };
            this.Controls.Add(labelAutor);
        }



        private System.Windows.Forms.Label CreateLabel(string text, int x, int y)
        {
            return new System.Windows.Forms.Label
            {
                Text = text,
                Location = new System.Drawing.Point(x, y),
                AutoSize = true,
                Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.DimGray
            };
        }

        private System.Windows.Forms.TextBox CreateTextBox(int x, int y, bool enabled = true)
        {
            return new System.Windows.Forms.TextBox
            {
                Location = new System.Drawing.Point(x, y),
                Size = new System.Drawing.Size(450, 30),
                Font = new System.Drawing.Font("Segoe UI", 10F),
                Enabled = enabled,
                BackColor = System.Drawing.Color.White
            };
        }

        private System.Windows.Forms.Button CreateButton(string text, int x, int y, System.EventHandler onClick)
        {
            var button = new System.Windows.Forms.Button
            {
                Text = text,
                Location = new System.Drawing.Point(x, y),
                Size = new System.Drawing.Size(110, 40),
                Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold),
                BackColor = System.Drawing.Color.SteelBlue,
                ForeColor = System.Drawing.Color.White,
                FlatStyle = System.Windows.Forms.FlatStyle.Flat
            };
            button.FlatAppearance.BorderSize = 0;
            button.Click += onClick;
            return button;
        }

        private System.Windows.Forms.Button CreateSecondaryButton(string text, int x, int y, System.EventHandler onClick)
        {
            var button = new System.Windows.Forms.Button
            {
                Text = text,
                Location = new System.Drawing.Point(x, y),
                Size = new System.Drawing.Size(100, 30),
                Font = new System.Drawing.Font("Segoe UI", 9F),
                BackColor = System.Drawing.Color.LightGray,
                ForeColor = System.Drawing.Color.Black,
                FlatStyle = System.Windows.Forms.FlatStyle.Flat
            };
            button.FlatAppearance.BorderSize = 0;
            button.Click += onClick;
            return button;
        }

        #endregion

        private System.Windows.Forms.Label label1, label2, label3, label4, label5, labelStock;
        private System.Windows.Forms.TextBox textBoxID, textBoxDescripcion, textBoxMarca, textBoxPrecio, textBoxStock, textBoxBuscador;
        private System.Windows.Forms.Button buttonSave, buttonClear, buttonDelete;
        private System.Windows.Forms.DataGridView dataGridViewProductos;
        private System.Windows.Forms.Button buttonBuscar, buttonReiniciar;

    }
}