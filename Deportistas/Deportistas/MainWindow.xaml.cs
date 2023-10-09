using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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
using ClosedXML.Excel;
using OfficeOpenXml;
using Path = System.IO.Path;
using Deportistas.Dominio;

namespace Deportistas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<string> Tipos { get; set; }
        public List<string> Modalidades { get; set; }

        public List<string> Horarios { get; set; }

        public List<string> Sexo { get; set; }

        public List<string> Semestre { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Tipos = new List<string>()
            {
                "Estudiante UV", "Derechohabiente", "Trabajador UV", "Condonado",
                "Público en general", "Egresado UV", "Jubilado"
            };

            Modalidades = new List<string>()
            {
                "Libre", "Clase A 16 años", "Clase B 16 años", "Clase A 8 años",
                "Clase B 8 años", "Clase trabajores", "Equipo natación", "Equipo triatlon"
            };

            Horarios = new List<string>()
            {
                "6:00 6:50", "7:00 7:50", "8:00 8:50", "12:00 12:50", "13:00 13:50",
                "14:00 14:50", "15:00 15:50", "16:00 16:50 17:00 17:50", "18:00 18:50", "19:00 19:50"
            };

            Sexo = new List<string>()
            {
                "Masculino", "Femenino"
            };
            List<string> Semestres = new List<string>()
            {
                "1",
                "2",
                "3",
                "4",
                "5",
                "6",
                "7",
                "8",
                "9",
                "10",
                "11",
                "12",
                "13",
                "14",
                "15"
            };
            List<string> Estados = new List<string>()
            {
                "Aguascalientes",
                "Baja California",
                "Baja California Sur",
                "Campeche",
                "Chiapas",
                "Chihuahua",
                "Coahuila",
                "Colima",
                "Durango",
                "Guanajuato",
                "Guerrero",
                "Hidalgo",
                "Jalisco",
                "México",
                "Ciudad de México",
                "Michoacán",
                "Morelos",
                "Nayarit",
                "Nuevo León",
                "Oaxaca",
                "Puebla",
                "Querétaro",
                "Quintana Roo",
                "San Luis Potosí",
                "Sinaloa",
                "Sonora",
                "Tabasco",
                "Tamaulipas",
                "Tlaxcala",
                "Veracruz",
                "Yucatán",
                "Zacatecas"
            };
            cbSexo.ItemsSource = Sexo;
            cbSemestre.ItemsSource = Semestres;
            cbEstado.ItemsSource = Estados;
            tfApellidoPaterno.TextChanged += LimpiarCampo;
            tfApellidoMaterno.TextChanged += LimpiarCampo;
            tfNombres.TextChanged += LimpiarCampo;
            tfEdad.TextChanged += LimpiarCampo;
            tfCurp.TextChanged += LimpiarCampo;
            tfTelefono.TextChanged += LimpiarCampo;
            tfNumExterior.TextChanged += LimpiarCampo;
            tfCorreo.TextChanged += LimpiarCampo;
            tfIntitucion.TextChanged += LimpiarCampo;
            tbDeporte.TextChanged += LimpiarCampo;
            tfMatricula.TextChanged += LimpiarCampo;
            tfGrado.TextChanged += LimpiarCampo;
            tfNombreDeGrado.TextChanged += LimpiarCampo;
            tfFacultad.TextChanged += LimpiarCampo;
            tfRegion.TextChanged += LimpiarCampo;
            tfPlanDeEstudios.TextChanged += LimpiarCampo;
            tfNoSeguro.TextChanged += LimpiarCampo;
            tfColonia.TextChanged += LimpiarCampo;
            tfDelegacion.TextChanged += LimpiarCampo;
            tfPesoKg.TextChanged += LimpiarCampo;
            tfEstaturaCm.TextChanged += LimpiarCampo;
            tfTallaInt.TextChanged += LimpiarCampo;
            tfTallaExt.TextChanged += LimpiarCampo;
            tfNoCalzado.TextChanged += LimpiarCampo;
        }

        private void tfEdad_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!EsNumero(tfEdad.Text))
            {
                MessageBox.Show("La edad debe ser un valor numérico.", "Entrada no válida", MessageBoxButton.OK, MessageBoxImage.Warning);
                tfEdad.Clear();
            }
        }

        private bool EsNumero(string texto)
        {
            return int.TryParse(texto, out _);
        }

        private void LimpiarCampo(object sender, TextChangedEventArgs e)
        {
            var campo = sender as Control;
            campo.ClearValue(Border.BorderBrushProperty);
        }

        private void MarcarCampoVacio(Control campo)
        {
            campo.BorderBrush = Brushes.Red;
        }

        private void clicGuardar(object sender, RoutedEventArgs e)
        {
            if (!CamposObligatoriosEstanLlenos())
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Campos Vacíos", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            try
            {
                Deportista deportista = new Deportista
                {
                    ApellidoPaterno = tfApellidoPaterno.Text,
                    ApellidoMaterno = tfApellidoMaterno.Text,
                    Nombres = tfNombres.Text,
                    FechaNacimiento = dpFechaNacimiento.SelectedDate ?? DateTime.MinValue,
                    Sexo = cbSexo.Text,
                    Edad = int.Parse(tfEdad.Text),
                    Curp = tfCurp.Text,
                    Telefono = tfTelefono.Text,
                    NumInterior = tfNumInterior.Text,
                    NumExterior = tfNumExterior.Text,
                    Estado = cbEstado.Text,
                    Correo = tfCorreo.Text,
                    Institucion = tfIntitucion.Text,
                    Semestre = cbSemestre.Text,
                    Deporte = tbDeporte.Text,
                    Matricula = tfMatricula.Text,
                    Grado = tfGrado.Text,
                    NombreDeGrado = tfNombreDeGrado.Text,
                    Facultad = tfFacultad.Text,
                    Region = tfRegion.Text,
                    PlanDeEstudios = tfPlanDeEstudios.Text,
                    FechaIngresoIES = dpFechaIngresoIES.SelectedDate ?? DateTime.MinValue,
                    NoSeguro = tfNoSeguro.Text,
                    Colonia = tfColonia.Text,
                    Delegacion = tfDelegacion.Text,
                    PesoKg = decimal.Parse(tfPesoKg.Text),
                    EstaturaCm = int.Parse(tfEstaturaCm.Text),
                    TallaInt = tfTallaInt.Text,
                    TallaExt = tfTallaExt.Text,
                    NoCalzado = tfNoCalzado.Text
                };

                DeportistaFactory deportistaFactory = new DeportistaFactory();
                bool registroExitoso = deportistaFactory.registrarDeportista(deportista);

                if (registroExitoso)
                {
                    MessageBox.Show("El deportista se registró con éxito.", "Registro Exitoso", MessageBoxButton.OK);
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al registrar al deportista:", "Contacte al administrador", MessageBoxButton.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al registrar al deportista: " + ex.Message, "Error", MessageBoxButton.OK);
            }
        }

        private bool CamposObligatoriosEstanLlenos()
        {
            bool camposLlenos = true;

            if (string.IsNullOrWhiteSpace(tfApellidoPaterno.Text))
            {
                MarcarCampoVacio(tfApellidoPaterno);
                camposLlenos = false;
            }

            if (string.IsNullOrWhiteSpace(tfApellidoMaterno.Text))
            {
                MarcarCampoVacio(tfApellidoMaterno);
                camposLlenos = false;
            }

            if (string.IsNullOrWhiteSpace(tfNombres.Text))
            {
                MarcarCampoVacio(tfNombres);
                camposLlenos = false;
            }

            if (dpFechaNacimiento.SelectedDate == null)
            {
                // Marcar el DatePicker si no se ha seleccionado una fecha.
                camposLlenos = false;
            }

            if (string.IsNullOrWhiteSpace(cbSexo.Text))
            {
                // Marcar el ComboBox de Sexo si no se ha seleccionado un valor.
                camposLlenos = false;
            }

            if (string.IsNullOrWhiteSpace(tfEdad.Text))
            {
                MarcarCampoVacio(tfEdad);
                camposLlenos = false;
            }

            if (string.IsNullOrWhiteSpace(tfCurp.Text))
            {
                MarcarCampoVacio(tfCurp);
                camposLlenos = false;
            }

            if (string.IsNullOrWhiteSpace(tfTelefono.Text))
            {
                MarcarCampoVacio(tfTelefono);
                camposLlenos = false;
            }

            if (string.IsNullOrWhiteSpace(tfNumExterior.Text))
            {
                MarcarCampoVacio(tfNumExterior);
                camposLlenos = false;
            }

            if (string.IsNullOrWhiteSpace(cbEstado.Text))
            {
                // Marcar el ComboBox de Estado si no se ha seleccionado un valor.
                camposLlenos = false;
            }

            if (string.IsNullOrWhiteSpace(tfCorreo.Text))
            {
                MarcarCampoVacio(tfCorreo);
                camposLlenos = false;
            }

            if (string.IsNullOrWhiteSpace(tfIntitucion.Text))
            {
                MarcarCampoVacio(tfIntitucion);
                camposLlenos = false;
            }

            if (string.IsNullOrWhiteSpace(cbSemestre.Text))
            {
                // Marcar el ComboBox de Semestre si no se ha seleccionado un valor.
                camposLlenos = false;
            }

            if (string.IsNullOrWhiteSpace(tbDeporte.Text))
            {
                MarcarCampoVacio(tbDeporte);
                camposLlenos = false;
            }

            if (string.IsNullOrWhiteSpace(tfMatricula.Text))
            {
                MarcarCampoVacio(tfMatricula);
                camposLlenos = false;
            }

            if (string.IsNullOrWhiteSpace(tfGrado.Text))
            {
                MarcarCampoVacio(tfGrado);
                camposLlenos = false;
            }

            if (string.IsNullOrWhiteSpace(tfNombreDeGrado.Text))
            {
                MarcarCampoVacio(tfNombreDeGrado);
                camposLlenos = false;
            }

            if (string.IsNullOrWhiteSpace(tfFacultad.Text))
            {
                MarcarCampoVacio(tfFacultad);
                camposLlenos = false;
            }

            if (string.IsNullOrWhiteSpace(tfRegion.Text))
            {
                MarcarCampoVacio(tfRegion);
                camposLlenos = false;
            }

            if (string.IsNullOrWhiteSpace(tfPlanDeEstudios.Text))
            {
                MarcarCampoVacio(tfPlanDeEstudios);
                camposLlenos = false;
            }

            if (dpFechaIngresoIES.SelectedDate == null)
            {
                // Marcar el DatePicker si no se ha seleccionado una fecha.
                camposLlenos = false;
            }

            if (string.IsNullOrWhiteSpace(tfNoSeguro.Text))
            {
                MarcarCampoVacio(tfNoSeguro);
                camposLlenos = false;
            }

            if (string.IsNullOrWhiteSpace(tfColonia.Text))
            {
                MarcarCampoVacio(tfColonia);
                camposLlenos = false;
            }

            if (string.IsNullOrWhiteSpace(tfDelegacion.Text))
            {
                MarcarCampoVacio(tfDelegacion);
                camposLlenos = false;
            }

            if (string.IsNullOrWhiteSpace(tfPesoKg.Text))
            {
                MarcarCampoVacio(tfPesoKg);
                camposLlenos = false;
            }

            if (string.IsNullOrWhiteSpace(tfEstaturaCm.Text))
            {
                MarcarCampoVacio(tfEstaturaCm);
                camposLlenos = false;
            }

            if (string.IsNullOrWhiteSpace(tfTallaInt.Text))
            {
                MarcarCampoVacio(tfTallaInt);
                camposLlenos = false;
            }

            if (string.IsNullOrWhiteSpace(tfTallaExt.Text))
            {
                MarcarCampoVacio(tfTallaExt);
                camposLlenos = false;
            }

            if (string.IsNullOrWhiteSpace(tfNoCalzado.Text))
            {
                MarcarCampoVacio(tfNoCalzado);
                camposLlenos = false;
            }

            return camposLlenos;
        }

        private void textBoxNumeric_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!EsNumeroDecimalValido(e.Text))
            {
                e.Handled = true;
            }
        }

        private bool EsNumeroDecimalValido(string texto)
        {
            string patron = @"^[0-9]*(\.[0-9]*)?$";
            return System.Text.RegularExpressions.Regex.IsMatch(texto, patron);
        }
    }
}