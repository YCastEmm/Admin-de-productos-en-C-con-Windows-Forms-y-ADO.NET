using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Admin_Productos.Persistidor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Admin_Productos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto();

            if (textBoxID.Text.Trim() != "")
                producto.Id = int.Parse(textBoxID.Text);

            producto.Descripcion = textBoxDescripcion.Text;
            producto.Marca = textBoxMarca.Text;
            producto.Precio = double.Parse(textBoxPrecio.Text);

            ADOPersister persister = new ADOPersister();
            persister.Save(producto); //Insert o Update

            //Mostrar al usuario el ID dado por la base de datos.
            textBoxID.Text = producto.Id.ToString();

            RefrescarListaProd(); //Recarga la lista en la IU

            ClearFrom();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefrescarListaProd();
        }

        /// <summary>
        /// Recarga la lista de productos desde la base de datos.
        /// </summary>
        private void RefrescarListaProd()
        {
            //Leer desde la caja de texto de busqueda.
            string partOfDescription = textBoxBuscador.Text;

            ADOPersister persister = new ADOPersister();

            List<Producto> productos =
                persister.Find(partOfDescription: partOfDescription);

            dataGridViewProductos.DataSource = productos;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearFrom();
        }

        /// <summary>
        /// Limpia el formulario prmitiendo el ingreso de un nuevo producto.
        /// </summary>
        private void ClearFrom()
        {
            textBoxID.Text = "";
            textBoxDescripcion.Text = "";
            textBoxMarca.Text = "";
            textBoxPrecio.Text = "";
        }

        private void dataGridViewProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bool haySeleccion = (e.RowIndex != -1);
            if (haySeleccion)
            {
                var row = dataGridViewProductos.Rows[e.RowIndex];
                int id = Convert.ToInt32(row.Cells["ID"].Value);
                //Marcar todo el registro o producto en la IU
                row.Selected = true;

                CargarFormulario(id);
            }
        }

        /// <summary>
        /// Carga el formulario de un producto desde la base de datos.
        /// </summary>
        /// <param name="id">
        /// Id de un producto.
        /// </param>
        private void CargarFormulario(int id)
        {
            ADOPersister persister = new ADOPersister();
            Producto producto = persister.Load(id);

            textBoxID.Text = producto.Id.ToString();
            textBoxDescripcion.Text = producto.Descripcion;
            textBoxMarca.Text = producto.Marca;
            textBoxPrecio.Text = producto.Precio.ToString();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBoxID.Text);

            Producto producto = GetProducto(id);
            string msg = $"¿ Esta seguro de eliminar {producto.Descripcion} ?";

            DialogResult buttonResultado =
                MessageBox.Show(msg,
                            "Eliminar",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question,
                            MessageBoxDefaultButton.Button2
                            );

            if (buttonResultado == DialogResult.Yes)
            {

                ADOPersister persister = new ADOPersister();
                persister.Remove(id);

                ClearFrom();
                RefrescarListaProd();
            }
        }

        private Producto GetProducto(int id)
        {
            ADOPersister persister = new ADOPersister();
            Producto producto = persister.Load(id);
            return producto;
        }

        private void linkLabelBuscar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RefrescarListaProd();
        }

        private void linkLabelSearchAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textBoxBuscador.Text = ""; //Limpio la descripcion del buscador
            RefrescarListaProd();
        }
        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            RefrescarListaProd();
        }

        private void buttonReiniciar_Click(object sender, EventArgs e)
        {
            textBoxBuscador.Text = "";
            RefrescarListaProd();
        }

    }
}
