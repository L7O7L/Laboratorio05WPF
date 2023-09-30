using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Laboratorio05
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            

        }

        private void Button_click(object sender, RoutedEventArgs e)
        {

            try
            {

                string connectionString = "Data Source=DESKTOP-RBF7IIL\\SQLEXPRESS;Initial Catalog=Neptuno;User ID=tecsup;Password=123456";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();
                    SqlCommand cmd = new SqlCommand("NuevoEmpleado", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdEmpleado", int.Parse(txtIdEmpleado.Text));
                    cmd.Parameters.AddWithValue("@Apellidos", txtApellidos.Text);
                    cmd.Parameters.AddWithValue("@Nombre", txtNombres.Text);
                    cmd.Parameters.AddWithValue("@Cargo", txtCargo.Text);
                    cmd.Parameters.AddWithValue("@Tratamiento", txtTratamiento.Text);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", txtFechaNacimiento.Text);
                    cmd.Parameters.AddWithValue("@FechaContratacion", txtFechaContratacion.Text);
                    cmd.Parameters.AddWithValue("@Direccion", txtDirección.Text);
                    cmd.Parameters.AddWithValue("@Ciudad", txtCiudad.Text);
                    cmd.Parameters.AddWithValue("@Region", txtRegion.Text);
                    cmd.Parameters.AddWithValue("@CodPostal", txtCodPostal.Text);
                    cmd.Parameters.AddWithValue("@Pais", txtPais.Text);
                    cmd.Parameters.AddWithValue("@TelDomicilio", txtTelefono.Text);
                    cmd.Parameters.AddWithValue("@Extension", txtExtension.Text);
                    cmd.Parameters.AddWithValue("@Notas", txtNotas.Text);
                    cmd.Parameters.AddWithValue("@Jefe", int.Parse(txtJefe.Text));
                    cmd.Parameters.AddWithValue("@SueldoBasico", double.Parse(txtSueldoBasico.Text));
                    cmd.Parameters.AddWithValue("@Activo", int.Parse(txtActivo.Text));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Empleado Creado");

                }

            }catch (Exception ex)
            {

                MessageBox.Show("Error al insertar empleado: " + ex.Message);

            }

        }
    }
}
