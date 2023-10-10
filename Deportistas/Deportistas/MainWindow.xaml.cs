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
            List<string> edades = new List<string>
            {
                "17",
                "18",
                "19",
                "20",
                "21",
                "22",
                "23",
                "24",
                "25",
                "26"
            };
            List<string> deportes = new List<string>
            {
                "Ajedrez",
                "Atletismo",
                "Bádminton",
                "Baloncesto",
                "Baloncesto 3x3",
                "Béisbol",
                "Boxeo universitario",
                "Escalada deportiva",
                "Esgrima",
                "Futbol Asociación",
                "Futbol Bardas",
                "Gimnasia aeróbica",
                "Handball",
                "Judo",
                "Karate Do",
                "Levantamiento de pesas",
                "Lucha Universitaria",
                "Natación",
                "Rugby Sevens",
                "Softbol",
                "Tae Kwon do",
                "Tenis de Mesa",
                "Tenis",
                "Tiro con Arco",
                "Tochito",
                "Triatlón",
                "Voleibol de Sala",
                "Voleibol de playa"
            };

            List<string> regiones = new List<string>
            {
                "Xalapa",
                "Veracruz-Boca del Río",
                "Orizaba-Córdoba",
                "Poza Rica-Tuxpan",
                "Coatzacoalcos-Minatitlán",
                "Universidad Veracruzana Intercultural"
            };
            List<string> areas = new List<string>
            {
                "Artes",
                "Ciencias Biológicas y Agropecuarias",
                "Ciencias de la Salud",
                "Económico-Administrativa",
                "Humanidades",
                "Técnica"
            };
            List<string> grados = new List<string>
            {
                "Técnico",
                "Técnico Superior Universitario",
                "Licenciatura",
                "Especialidad",
                "Maestría",
                "Doctorado"
            };
            List<string> Nombregrados = new List<string>
        {
            "Administración (abierta)",
            "Administración (Escolarizada)",
            "Administración de Negocios Internacionales",
            "Administración Turística",
            "Agroecología y soberanía Alimentaria (Mixta)",
            "Agroecología y Soberanía Alimentaria, UVI",
            "Agronegocios Internacionales",
            "Antropología Histórica",
            "Antropología Lingüística",
            "Antropología Social",
            "Arqueología",
            "Arquitectura",
            "Artes Visuales",
            "Biología",
            "Biología Marina",
            "Ciencias Atmosféricas",
            "Ciencias de la Comunicación (Abierta)",
            "Ciencias de la Comunicación (Escolarizada)",
            "Ciencias Políticas y Gestión Pública",
            "Cirujano Dentista",
            "Contaduría (Abierta)",
            "Contaduría (Escolarizada)",
            "Danza Contemporánea",
            "Derecho (Abierta)",
            "Derecho (Escolarizada)",
            "Derecho con enfoque de pluralismo Jurídico (Mixta)",
            "Derecho con enfoque de Pluralismo Jurídico, UVI",
            "Desarrollo del Talento Humano en las Organizaciones",
            "Desarrollo Integral de las Personas con Discapacidad",
            "Didáctica del Francés",
            "Dirección Estratégica de Recursos Humanos",
            "Diseño de la Comunicación Visual",
            "Docencia Mediada por Tecnología",
            "Doctorado en Alta Dirección de Organizaciones",
            "Doctorado en Arquitectura y Urbanismo",
            "Doctorado en Biología Integrativa",
            "Doctorado en Ciencia del Comportamiento",
            "Doctorado en Ciencias Administrativas y Gestión para el Desarrollo",
            "Doctorado en Ciencias Agropecuarias",
            "Doctorado en Ciencias Biomédicas",
            "Doctorado en Ciencias de la Computación",
            "Doctorado en Ciencias de la Enfermería",
            "Doctorado en Ciencias de la Salud",
            "Doctorado en Ciencias en Ecología y Biotecnología",
            "Doctorado en Ciencias Sociales",
            "Doctorado en Derecho",
            "Doctorado en Ecología Tropical",
            "Doctorado en Ecología y Pesquerías",
            "Doctorado en Estudios del Lenguaje y Lingüística Aplicada",
            "Doctorado en Filosofía",
            "Doctorado en Historia y Estudios Regionales",
            "Doctorado en Ingeniería",
            "Doctorado en Ingeniería Aplicada",
            "Doctorado en Ingeniería Química",
            "Doctorado en Innovación en Educación Superior",
            "Doctorado en Inteligencia Artificial",
            "Doctorado en Investigación Educativa",
            "Doctorado en Investigación Psicológica en Educación Inclusiva",
            "Doctorado en Investigación Químico-Biológica",
            "Doctorado en Investigaciones Cerebrales",
            "Doctorado en Investigaciones Económicas y Sociales",
            "Doctorado en Literatura Hispanoamericana",
            "Doctorado en Matemáticas",
            "Doctorado en Materiales y Nanociencia",
            "Doctorado en Micología Aplicada",
            "Doctorado en Música",
            "Doctorado en Neuroetología",
            "Doctorado en Psicología",
            "Doctorado en Sistemas y Ambientes Educativos",
            "Economía",
            "Educación Física, Deporte y Recreación",
            "Educación Musical",
            "Enfermería",
            "Enseñanza de las Artes",
            "Enseñanza de las Artes (Semiescolarizada)",
            "Enseñanza de Lengua y Cultura Francesas",
            "Especialidad en Administración del Comercio Exterior",
            "Especialidad en Administración y Gestión de la Enfermería",
            "Especialidad en Administración y Gestión de Proyectos Arquitectónicos y Urbanos",
            "Especialidad en Diagnóstico y Gestión Ambiental",
            "Especialidad en Diseño de Cartel",
            "Especialidad en Endodoncia",
            "Especialidad en Enfermería en Cuidados Intensivos del Adulto en Estado Crítico",
            "Especialidad en Enfermería Quirúrgica",
            "Especialidad en Enseñanza y Divulgación de la Filosofía",
            "Especialidad en Estudios Cinematográficos",
            "Especialidad en Estudios de Opinión",
            "Especialidad en Gestión e Impacto Ambiental",
            "Especialidad en Métodos Estadísticos",
            "Especialidad en Odontopediatría",
            "Especialidad en Promoción de la Lectura",
            "Especialidad en Promoción de la Lectura",
            "Especialidad en Salud Materna y Perinatal",
            "Especialidad en Tributación Empresarial",
            "Especialización en Enfermería en Cuidados Intensivos del Adulto en Estado Crítico",
            "Estadística",
            "Estudios de Jazz",
            "Filosofía",
            "Física",
            "Fotografía",
            "Geografía",
            "Gestión Intercultural",
            "Gestión Intercultural (Mixta)",
            "Gestión Intercultural para el Desarrollo, UVI",
            "Gestión y Dirección de Negocios",
            "Historia",
            "Ingeniería Ambiental",
            "Ingeniería Biomédica",
            "Ingeniería Civil",
            "Ingeniería de Ciberseguridad e Infraestructura de Cómputo",
            "Ingeniería de Software",
            "Ingeniería en Alimentos",
            "Ingeniería en Biotecnología",
            "Ingeniería en Electrónica y Comunicaciones",
            "Ingeniería en Instrumentación Electrónica",
            "Ingeniería en Sistemas de Producción Agropecuaria (A distancia)",
            "Ingeniería en Sistemas de Producción Agropecuaria (Escolarizada)",
            "Ingeniería en Sistemas y Tecnologías de la Información",
            "Ingeniería en Tecnologías Computacionales",
            "Ingeniería Industrial",
            "Ingeniería Informática",
            "Ingeniería Mecánica Eléctrica",
            "Ingeniería Mecatrónica",
            "Ingeniería Metalúrgica y Ciencias de los Materiales",
            "Ingeniería Naval",
            "Ingeniería Petrolera",
            "Ingeniería Química",
            "Ingeniería Topográfica Geodésica",
            "Ingeniero Agrónomo",
            "Lengua Inglesa y Didáctica del Inglés",
            "Lengua y Literatura Hispánicas",
            "Logística Internacional y Aduanas",
            "Maestría en Administración",
            "Maestría en Administración de Sistemas de Salud",
            "Maestría en Administración de Sistemas de Salud (Virtual)",
            "Maestría en Arquitectura",
            "Maestría en Artes Escénicas",
            "Maestría en Auditoría",
            "Maestría en Biología Integrativa",
            "Maestría en Biomedicina Traslacional",
            "Maestría en Ciencia Animal",
            "Maestría en Ciencias Agropecuarias",
            "Maestría en Ciencias Alimentarias",
            "Maestría en Ciencias Biológicas",
            "Maestría en Ciencias de la Ingeniería",
            "Maestría en Ciencias de la Salud",
            "Maestría en Ciencias de la Tierra",
            "Maestría en Ciencias del Ambiente",
            "Maestría en Ciencias en Ecología Forestal",
            "Maestría en Ciencias en Ecología y Biotecnología",
            "Maestría en Ciencias en Micro y Nanosistemas",
            "Maestría en Ciencias en Procesos Biológicos",
            "Maestría en Ciencias en Tecnología Energética",
            "Maestría en Ciencias para el aprendizaje",
            "Maestría en Ciencias Sociales",
            "Maestría en Derechos Humanos y Justicia Constitucional",
            "Maestría en Desarrollo Agropecuario",
            "Maestría en Desarrollo Humano",
            "Maestría en Dirección Empresarial",
            "Maestría en Dirección Estratégica e Innovación Tecnológica",
            "Maestría en Ecología Tropical",
            "Maestría en Ecología y Pesquerías",
            "Maestría en Economía Ambiental y Ecológica",
            "Maestría en Economía y Sociedad de China y América Latina (Virtual)",
            "Maestría en Educación para la Interculturalidad y la Sustentabilidad",
            "Maestría en Enfermería",
            "Maestría en Enfermería",
            "Maestría en Enseñanza del Inglés como Lengua Extranjera",
            "Maestría en Enseñanza del Inglés como Lengua Extranjera",
            "Maestría en Estudios de Género",
            "Maestría en Estudios de la Cultura y la Comunicación",
            "Maestría en Estudios Transdisciplinarios para la Sostenibilidad",
            "Maestría en Estudios Tributarios",
            "Maestría en Farmacia Clínica",
            "Maestría en Finanzas Empresariales",
            "Maestría en Física",
            "Maestría en Gestión Ambiental para la Sustentabilidad",
            "Maestría en Gestión de las Tecnologías de Información en las Organizaciones",
            "Maestría en Gestión de Negocios",
            "Maestría en Gestión de Negocios (Virtual)",
            "Maestría en Gestión de Recursos Humanos, Trabajo y Organizaciones",
            "Maestría en Gestión del Aprendizaje",
            "Maestría en Historia Contemporánea",
            "Maestría en Horticultura Tropical",
            "Maestría en Ingeniería Aplicada",
            "Maestría en Ingeniería de Corrosión",
            "Maestría en Ingeniería de la Calidad",
            "Maestría en Ingeniería de Procesos",
            "Maestría en Ingeniería Electrónica y Computación",
            "Maestría en Ingeniería Química",
            "Maestría en Innovación y Emprendimiento de Negocios",
            "Maestría en Innovación y Emprendimiento de Negocios (Virtual)",
            "Maestría en Inteligencia Artificial",
            "Maestría en Investigación Clínica",
            "Maestría en Investigación Educativa",
            "Maestría en Investigación en Psicología Aplicada a la Educación",
            "Maestría en Investigación Odontológica, Virtual",
            "Maestría en Laboratorio Clínico",
            "Maestría en Literatura Mexicana",
            "Maestría en Maestriah Ipan Totlahtol Iwan Tonemilis (Lengua y Cultura Nahua)",
            "Maestría en Manejo de Ecosistemas Marinos y Costeros",
            "Maestría en Manejo y Explotación de los Agrosistemas de la Caña de Azúcar",
            "Maestría en Matemáticas",
            "Maestría en Mediación Artística Interdisciplinar",
            "Maestría en Medicina Forense",
            "Maestría en Música",
            "Maestría en Neuroetología",
            "Maestría en Nutrición y Calidad de Vida",
            "Maestría en Pedagogía de las Artes",
            "Maestría en Pedagogía de las Artes Virtual",
            "Maestría en Prevención Integral del Consumo de Drogas, Virtual",
            "Maestría en Química Bioorgánica",
            "Maestría en Química Clínica",
            "Maestría en Rehabilitación Oral",
            "Maestría en Salud Pública",
            "Maestría en Salud, Arte y Comunidad",
            "Maestría en Seguridad Alimentaria y Nutricional",
            "Maestría en Sistemas Interactivos Centrados en el Usuario",
            "Maestría en Vías Terrestres",
            "Maestría Psicología de las Organizaciones y Talento Humano (Virtual)",
            "Matemáticas",
            "Médico Cirujano",
            "Médico Veterinario Zootecnista",
            "Música",
            "Nutrición",
            "Pedagogía (Abierta)",
            "Pedagogía (Escolarizada)",
            "Psicología",
            "Psicología",
            "Publicidad y Relaciones Públicas",
            "Química Clínica",
            "Química Industrial",
            "Químico Farmacéutico Biólogo",
            "Quiropráctica",
            "Radiología, Minatitlán",
            "Radiología, Veracruz",
            "Sistemas Computacionales Administrativos",
            "Sociología",
            "Sociología (Abierta)",
            "Teatro",
            "Técnico en danza Contemporánea",
            "Técnico en Dibujo y Pintura",
            "Técnico en Música: Alientos",
            "Técnico en Música: Canto",
            "Técnico en Música: Cuerdas",
            "Técnico en Música: Guitarra",
            "Técnico en Música: Percusiones",
            "Técnico en Música: Piano",
            "Tecnologías de Información en las Organizaciones",
            "Trabajo Social",
            "TSU: Enfermería, Coatzacoalcos",
            "TSU: Histotecnólogo y Embalsamador, Boca del Río",
            "TSU: Protesista Dental",
            "TSU: Radiología"};

            cbSexo.ItemsSource = Sexo;
            cbSemestre.ItemsSource = Semestres;
            cbEstado.ItemsSource = Estados;
            cbEdad.ItemsSource = edades;
            cbDeporte.ItemsSource = deportes;
            cbRegion.ItemsSource = regiones;
            cbArea.ItemsSource = areas;
            cbGrado.ItemsSource = grados;
            cbNombreGrado.ItemsSource = Nombregrados;

            cbDeporte.SelectionChanged += LimpiarCampo;
            cbSemestre.SelectionChanged += LimpiarCampo;
            cbEstado.SelectionChanged += LimpiarCampo;
            cbEdad.SelectionChanged += LimpiarCampo;
            cbDeporte.SelectionChanged += LimpiarCampo;
            cbRegion.SelectionChanged += LimpiarCampo;
            cbArea.SelectionChanged += LimpiarCampo;
            cbSexo.SelectionChanged += LimpiarCampo;
            cbGrado.SelectionChanged += LimpiarCampo;
            cbNombreGrado.SelectionChanged += LimpiarCampo;

            tfApellidoPaterno.TextChanged += LimpiarCampo;
            tfApellidoMaterno.TextChanged += LimpiarCampo;
            tfNombres.TextChanged += LimpiarCampo;
            tfCurp.TextChanged += LimpiarCampo;
            tfTelefono.TextChanged += LimpiarCampo;
            tfNumExterior.TextChanged += LimpiarCampo;
            tfNumInterior.TextChanged += LimpiarCampo;
            tfCorreo.TextChanged += LimpiarCampo;
            tfIntitucion.TextChanged += LimpiarCampo;
            tfMatricula.TextChanged += LimpiarCampo;
            tfFacultad.TextChanged += LimpiarCampo;
            tfPlanDeEstudios.TextChanged += LimpiarCampo;
            tfNoSeguro.TextChanged += LimpiarCampo;
            tfColonia.TextChanged += LimpiarCampo;
            tfDelegacion.TextChanged += LimpiarCampo;
            tfPesoKg.TextChanged += LimpiarCampo;
            tfEstaturaCm.TextChanged += LimpiarCampo;
            tfTallaInt.TextChanged += LimpiarCampo;
            tfTallaExt.TextChanged += LimpiarCampo;
            tfNoCalzado.TextChanged += LimpiarCampo;

            dpFechaIngresoIES.SelectedDateChanged += LimpiarCampo;
            dpFechaNacimiento.SelectedDateChanged += LimpiarCampo;
        }

        private void LimpiarCampo(object sender, SelectionChangedEventArgs e)
        {
            var campo = sender as Control;
            campo.ClearValue(Border.BorderBrushProperty);
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
                    Edad = int.Parse(cbEdad.Text),
                    Curp = tfCurp.Text,
                    Telefono = tfTelefono.Text,
                    NumInterior = tfNumInterior.Text,
                    NumExterior = tfNumExterior.Text,
                    Estado = cbEstado.Text,
                    Correo = tfCorreo.Text,
                    Institucion = tfIntitucion.Text,
                    Semestre = cbSemestre.Text,
                    Deporte = cbDeporte.Text,
                    Matricula = tfMatricula.Text,
                    Grado = cbGrado.Text,
                    Facultad = tfFacultad.Text,
                    Region = cbRegion.Text,
                    PlanDeEstudios = tfPlanDeEstudios.Text,
                    FechaIngresoIES = dpFechaIngresoIES.SelectedDate ?? DateTime.MinValue,
                    NoSeguro = tfNoSeguro.Text,
                    Colonia = tfColonia.Text,
                    Delegacion = tfDelegacion.Text,
                    PesoKg = decimal.Parse(tfPesoKg.Text),
                    EstaturaCm = decimal.Parse(tfEstaturaCm.Text),
                    TallaInt = tfTallaInt.Text,
                    TallaExt = tfTallaExt.Text,
                    NoCalzado = tfNoCalzado.Text,
                    NombreGrado = cbNombreGrado.Text,
                    Area = cbArea.Text
                };

                DeportistaFactory deportistaFactory = new DeportistaFactory();
                bool registroExitoso = deportistaFactory.registrarDeportista(deportista);

                if (registroExitoso)
                {
                    MessageBox.Show("El deportista se registró con éxito.", "Registro Exitoso", MessageBoxButton.OK);
                    LimpiarCampos();
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
                MarcarCampoVacio(dpFechaNacimiento);
                camposLlenos = false;
            }

            if (string.IsNullOrWhiteSpace(cbSexo.Text))
            {
                MarcarCampoVacio(cbSexo);
                camposLlenos = false;
            }

            if (string.IsNullOrWhiteSpace(cbEdad.Text))
            {
                MarcarCampoVacio(cbEdad);
                camposLlenos = false;
            }

            if (string.IsNullOrWhiteSpace(cbArea.Text))
            {
                MarcarCampoVacio(cbArea);
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

            if (string.IsNullOrWhiteSpace(cbEstado.Text))
            {
                MarcarCampoVacio(cbEstado);
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
                MarcarCampoVacio(cbSemestre);
                camposLlenos = false;
            }

            if (string.IsNullOrWhiteSpace(cbDeporte.Text))
            {
                MarcarCampoVacio(cbDeporte);
                camposLlenos = false;
            }

            if (string.IsNullOrWhiteSpace(tfMatricula.Text))
            {
                MarcarCampoVacio(tfMatricula);
                camposLlenos = false;
            }

            if (string.IsNullOrWhiteSpace(cbGrado.Text))
            {
                MarcarCampoVacio(cbGrado);
                camposLlenos = false;
            }

            if (string.IsNullOrWhiteSpace(tfFacultad.Text))
            {
                MarcarCampoVacio(tfFacultad);
                camposLlenos = false;
            }

            if (string.IsNullOrWhiteSpace(cbRegion.Text))
            {
                MarcarCampoVacio(cbRegion);
                camposLlenos = false;
            }

            if (string.IsNullOrWhiteSpace(tfPlanDeEstudios.Text))
            {
                MarcarCampoVacio(tfPlanDeEstudios);
                camposLlenos = false;
            }

            if (dpFechaIngresoIES.SelectedDate == null)
            {
                MarcarCampoVacio(dpFechaIngresoIES);
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
            if (string.IsNullOrWhiteSpace(cbGrado.Text))
            {
                MarcarCampoVacio(cbGrado);
                camposLlenos = false;
            }
            if (string.IsNullOrWhiteSpace(cbNombreGrado.Text))
            {
                MarcarCampoVacio(cbNombreGrado);
                camposLlenos = false;
            }
            if (string.IsNullOrWhiteSpace(tfNumInterior.Text))
            {
                MarcarCampoVacio(tfNumInterior);
                camposLlenos = false;
            }
            if (string.IsNullOrWhiteSpace(cbArea.Text))
            {
                MarcarCampoVacio(cbArea);
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

        private void LimpiarCampos()
        {
            tfApellidoPaterno.Clear();
            tfApellidoMaterno.Clear();
            tfNombres.Clear();
            dpFechaNacimiento.SelectedDate = null;
            cbSexo.SelectedIndex = -1;
            cbEdad.SelectedIndex = -1;
            tfCurp.Clear();
            tfTelefono.Clear();
            tfNumInterior.Clear();
            tfNumExterior.Clear();
            cbEstado.SelectedIndex = -1;
            tfCorreo.Clear();
            cbSemestre.SelectedIndex = -1;
            cbDeporte.SelectedIndex = -1;
            tfMatricula.Clear();
            cbGrado.SelectedIndex = -1;
            cbNombreGrado.SelectedIndex = -1;
            tfFacultad.Clear();
            tfPlanDeEstudios.Clear();
            dpFechaIngresoIES.SelectedDate = null;
            tfNoSeguro.Clear();
            tfColonia.Clear();
            tfDelegacion.Clear();
            tfPesoKg.Clear();
            tfEstaturaCm.Clear();
            tfTallaInt.Clear();
            tfTallaExt.Clear();
            tfNoCalzado.Clear();
            cbArea.SelectedIndex = -1;
            cbRegion.SelectedIndex = -1;
        }
    }
}