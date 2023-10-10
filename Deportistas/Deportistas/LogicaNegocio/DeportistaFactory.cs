using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using System.Windows;
using Deportistas.LogicaNegocio;
using DocumentFormat.OpenXml.Spreadsheet;

namespace Deportistas.Dominio
{
    public class DeportistaFactory : IDeportistas

    {
        public bool registrarDeportista(Deportista deportista)
        {
            try
            {
                string filePath = "bdDeportistas.xlsx";

                XLWorkbook workbook;

                try
                {
                    workbook = new XLWorkbook(filePath);
                }
                catch (Exception ex)
                {
                    workbook = new XLWorkbook();
                }

                IXLWorksheet worksheet;

                worksheet = workbook.Worksheets.FirstOrDefault(ws => ws.Name == "Deportistas") ?? workbook.Worksheets.Add("Deportistas");

                // Verificar si la hoja de cálculo no tiene cabecera y agregarla
                if (worksheet.FirstRowUsed() == null)
                {
                    var headerRow = worksheet.Row(1);
                    headerRow.Cell(1).Value = "Apellido Paterno";
                    headerRow.Cell(2).Value = "Apellido Materno";
                    headerRow.Cell(3).Value = "Nombres";
                    headerRow.Cell(4).Value = "Fecha de Nacimiento";
                    headerRow.Cell(5).Value = "Sexo";
                    headerRow.Cell(6).Value = "Edad";
                    headerRow.Cell(7).Value = "Curp";
                    headerRow.Cell(8).Value = "Teléfono";
                    headerRow.Cell(9).Value = "No Interior";
                    headerRow.Cell(10).Value = "No Exterior";
                    headerRow.Cell(11).Value = "Estado";
                    headerRow.Cell(12).Value = "Correo";
                    headerRow.Cell(13).Value = "Institución";
                    headerRow.Cell(14).Value = "Semestre";
                    headerRow.Cell(15).Value = "Deporte";
                    headerRow.Cell(16).Value = "Matrícula";
                    headerRow.Cell(17).Value = "Grado";
                    headerRow.Cell(18).Value = "Nombre grado";
                    headerRow.Cell(19).Value = "Facultad";
                    headerRow.Cell(20).Value = "Región";
                    headerRow.Cell(21).Value = "Plan de Estudios";
                    headerRow.Cell(22).Value = "Fecha de Ingreso a IES";
                    headerRow.Cell(23).Value = "No Seguro";
                    headerRow.Cell(24).Value = "Colonia";
                    headerRow.Cell(25).Value = "Delegación o Municipio";
                    headerRow.Cell(26).Value = "Peso en Kg";
                    headerRow.Cell(27).Value = "Estatura en CM";
                    headerRow.Cell(28).Value = "Talla Int";
                    headerRow.Cell(29).Value = "Talla Ext";
                    headerRow.Cell(30).Value = "No. Calzado";
                    headerRow.Cell(31).Value = "Area";
                }

                int lastRow = worksheet.LastRowUsed()?.RowNumber() + 1 ?? 2;

                worksheet.Cell(lastRow, 1).Value = deportista.ApellidoPaterno;
                worksheet.Cell(lastRow, 2).Value = deportista.ApellidoMaterno;
                worksheet.Cell(lastRow, 3).Value = deportista.Nombres;
                worksheet.Cell(lastRow, 4).Value = deportista.FechaNacimiento;
                worksheet.Cell(lastRow, 5).Value = deportista.Sexo;
                worksheet.Cell(lastRow, 6).Value = deportista.Edad;
                worksheet.Cell(lastRow, 7).Value = deportista.Curp;
                worksheet.Cell(lastRow, 8).Value = deportista.Telefono;
                worksheet.Cell(lastRow, 9).Value = deportista.NumInterior;
                worksheet.Cell(lastRow, 10).Value = deportista.NumExterior;
                worksheet.Cell(lastRow, 11).Value = deportista.Estado;
                worksheet.Cell(lastRow, 12).Value = deportista.Correo;
                worksheet.Cell(lastRow, 13).Value = deportista.Institucion;
                worksheet.Cell(lastRow, 14).Value = deportista.Semestre;
                worksheet.Cell(lastRow, 15).Value = deportista.Deporte;
                worksheet.Cell(lastRow, 16).Value = deportista.Matricula;
                worksheet.Cell(lastRow, 17).Value = deportista.Grado;
                worksheet.Cell(lastRow, 18).Value = deportista.NombreGrado;
                worksheet.Cell(lastRow, 19).Value = deportista.Facultad;
                worksheet.Cell(lastRow, 20).Value = deportista.Region;
                worksheet.Cell(lastRow, 21).Value = deportista.PlanDeEstudios;
                worksheet.Cell(lastRow, 22).Value = deportista.FechaIngresoIES;
                worksheet.Cell(lastRow, 23).Value = deportista.NoSeguro;
                worksheet.Cell(lastRow, 24).Value = deportista.Colonia;
                worksheet.Cell(lastRow, 25).Value = deportista.Delegacion;
                worksheet.Cell(lastRow, 26).Value = deportista.PesoKg;
                worksheet.Cell(lastRow, 27).Value = deportista.EstaturaCm;
                worksheet.Cell(lastRow, 28).Value = deportista.TallaInt;
                worksheet.Cell(lastRow, 29).Value = deportista.TallaExt;
                worksheet.Cell(lastRow, 30).Value = deportista.NoCalzado;
                worksheet.Cell(lastRow, 31).Value = deportista.Area;

                workbook.SaveAs(filePath);

                return true;
            }
            catch (System.IO.IOException e)
            {
                MessageBox.Show("Por favor, cierre el documento Excel para poder hacer un nuevo registro.",
                    "El Excel está abierto", MessageBoxButton.OK);
                return false;
            }
        }
    }
}