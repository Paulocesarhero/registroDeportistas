using Microsoft.Win32;
using System;
using System.Collections.Generic;
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

        public MainWindow()
        {
            InitializeComponent();
            Tipos = new List<string>()
            {
                "Estudiante UV", "Derechohabiente", "Trabajador UV", "Condonado",
                "Público en general", "Egresado UV", "Jubilado"
            };
            cbTipo.ItemsSource = Tipos;

            Modalidades = new List<string>()
            {
                "Libre", "Clase A 16 años", "Clase B 16 años", "Clase A 8 años",
                "Clase B 8 años", "Clase trabajores", "Equipo natación", "Equipo triatlon"
            };
            cbModalidad.ItemsSource = Modalidades;

            Horarios = new List<string>()
            {
                "6:00 6:50", "7:00 7:50", "8:00 8:50", "12:00 12:50", "13:00 13:50",
                "14:00 14:50", "15:00 15:50", "16:00 16:50 17:00 17:50", "18:00 18:50", "19:00 19:50"
            };
            cbHorario.ItemsSource = Horarios;

            Sexo = new List<string>()
            {
                "Masculino", "Femenino"
            };
            cbSexo.ItemsSource = Sexo;
        }

        private void clicGuardar(object sender, RoutedEventArgs e)
        {
            DatosPersona persona = new DatosPersona
            {
                Codigo = tfCodigo.Text,
                Nombre = tfNombre.Text,
                Tipo = cbTipo.Text,
                Modalidad = cbModalidad.Text,
                Telefono = tfTelefono.Text,
                Edad = tfEdad.Text,
                NoCredencial = tfNoCredencial.Text,
                Correo = tfCorreo.Text,
                Horario = cbHorario.Text,
                Sexo = cbSexo.Text
            };
            string filePath = "Deportistas.xlsx";

            ExportarAExcel(persona, filePath);
        }

        private void ExportarAExcel(DatosPersona persona, string filePath)
        {
            XLWorkbook workbook;

            try
            {
                // Intenta cargar el archivo Excel existente
                workbook = new XLWorkbook(filePath);
            }
            catch (Exception ex)
            {
                // Si se produce una excepción al cargar, crea un nuevo workbook
                workbook = new XLWorkbook();
            }

            IXLWorksheet worksheet;

            // Intenta cargar la hoja de trabajo existente o crear una nueva
            worksheet = workbook.Worksheets.FirstOrDefault(ws => ws.Name == "Personas") ?? workbook.Worksheets.Add("Personas");

            // Encuentra la primera fila vacía en la hoja de trabajo
            int row = worksheet.LastRowUsed()?.RowNumber() + 1 ?? 2;

            // Llena los datos en la siguiente fila vacía
            worksheet.Cell(row, 1).Value = persona.Codigo;
            worksheet.Cell(row, 2).Value = persona.Nombre;
            worksheet.Cell(row, 3).Value = persona.Tipo;
            worksheet.Cell(row, 4).Value = persona.Modalidad;
            worksheet.Cell(row, 5).Value = persona.Telefono;
            worksheet.Cell(row, 6).Value = persona.Edad;
            worksheet.Cell(row, 7).Value = persona.NoCredencial;
            worksheet.Cell(row, 8).Value = persona.Correo;
            worksheet.Cell(row, 9).Value = persona.Horario;
            worksheet.Cell(row, 10).Value = persona.Sexo;

            // Guarda el archivo de Excel
            try
            {
                workbook.SaveAs(filePath);
            }
            catch (System.IO.IOException e)
            {
                MessageBox.Show("Por favor cierre el documento excel para poder hacer un nuevo registro",
                    "El excel está abierto", MessageBoxButton.OK);
            }
        }
    }
}

public class DatosPersona
{
    public string Codigo { get; set; }
    public string Nombre { get; set; }
    public string Tipo { get; set; }
    public string Modalidad { get; set; }
    public string Telefono { get; set; }
    public string Edad { get; set; }
    public string NoCredencial { get; set; }
    public string Correo { get; set; }
    public string Horario { get; set; }
    public string Sexo { get; set; }
}