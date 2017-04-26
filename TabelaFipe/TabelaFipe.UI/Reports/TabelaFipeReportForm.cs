using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TabelaFipe.BLL;

namespace TabelaFipe.UI.Reports
{
    public partial class TabelaFipeReportForm : Form
    {
        public TabelaFipeReportForm()
        {
            InitializeComponent();
        }

        private void TabelaFipeReportForm_Load(object sender, EventArgs e)
        {

            try
            {
                var marcaBo = new MarcaBO();
                var marcas = marcaBo.Listar();

                var relatorio = new List<Marca>();
                foreach (var marca in marcas)
                {
                    var itemRelatorio = new Marca
                    {
                        Id = marca.Id,
                        Nome = marca.Nome,
                        Modelos = marca.Modelos
                    };

                    relatorio.Add(itemRelatorio);
                }

                MarcaBindingSource.DataSource = relatorio;

                reportViewer1.LocalReport.SubreportProcessing += LocalReport_SubreportProcessing;

                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;

                this.reportViewer1.RefreshReport();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void LocalReport_SubreportProcessing(object sender, Microsoft.Reporting.WinForms.SubreportProcessingEventArgs e)
        {
            var id = e.Parameters[0].Values[0].ToString().ToInt();

            if (e.Parameters[0].Name.Equals("pMarcaId"))
            {
                //Modelos
                var modeloBo = new ModeloBO();
                var modelos = modeloBo.Listar(x => x.Marca_Id == id);
                var dsModelos = new ReportDataSource("dsModelos", modelos);
                e.DataSources.Add(dsModelos);
            }
            else
            {
                //Anos Modelos
                var anoBo = new AnoModeloBO();
                var anos = anoBo.Listar(x => x.Modelo_Id == id);
                var dsAnos = new ReportDataSource("dsAno", anos);
                e.DataSources.Add(dsAnos);
            }
        }
    }
}
