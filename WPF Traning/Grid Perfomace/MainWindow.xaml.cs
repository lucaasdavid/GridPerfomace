using System;
using System.Collections;
using System.Collections.Generic;
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
using System.Globalization;
using System.Timers;
using System.Diagnostics;
using Grid_Perfomace.Componentes.Entidade;
using Grid_Perfomace.Componentes.Service;

namespace Grid_Perfomace
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<TextBox> textBoxes;
        public static Stopwatch temporizador;
        public PerformanceCounter cpuUsage;

        public MainWindow()
        {
            InitializeComponent();
            textBoxes = new List<TextBox>();
            temporizador = new Stopwatch();
            cpuUsage = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            DataGrid.BeginningEdit += (s, ss) => ss.Cancel = false;
            TempoDeProcesso.Text = "0 ms";
        }

        async private void BtnGerarList_Click(object sender, RoutedEventArgs e)
        {
            if (ValidarFormulario())
            {
                temporizador.Reset();
                temporizador.Start();
                TempoDeProcesso.Text = " ";
                TotalDeLinhas.Text = txtNrLinhas.Text;

                List<Coluna> colunas = new ColunaService().GerarListaColuna(int.Parse(txtNrMin.Text), int.Parse(txtNrMax.Text), int.Parse(txtNrLinhas.Text));

                if (DataGrid.Items.Count != 0)
                {
                    DataGrid.DataContext = null;
                }

                DataGrid.DataContext = colunas;
                if (varrerGrid.IsChecked.Value)
                {
                    string dados = "Gerando dados da lista...";
                    PbStatus.Minimum = 0;
                    PbStatus.Maximum = colunas.Count;
                    PbStatus.Visibility = Visibility.Visible;
                    Cpu.Visibility = Visibility.Visible;

                    for (int i = 0; i < colunas.Count; i++)
                    {
                        PbStatus.Value = i + 1;
                        DataGrid.SelectedIndex = i;
                        DataGrid.ScrollIntoView(DataGrid.SelectedItem);
                        await Task.Delay(1);
                        GerandoDados.Text = dados;
                        Cpu.Text = getCurrentCpuUsage();
                    }

                    string processamento = "Tempo de processamento";
                    GerandoDados.Text = processamento;
                }

                PbStatus.Visibility = Visibility.Hidden;
                Cpu.Visibility = Visibility.Hidden;
                temporizador.Stop();
                TempoDeProcesso.Text = temporizador.ElapsedMilliseconds.ToString() + " ms";
            }
        }

        #region Validação de entrada + recursos

        private bool ValidarFormulario()
        {
            if (String.IsNullOrEmpty(txtNrLinhas.Text))
            {
                textBoxes.Add(txtNrLinhas);
            }
            if (String.IsNullOrEmpty(txtNrMin.Text))
            {
                textBoxes.Add(txtNrMin);
            }
            if (String.IsNullOrEmpty(txtNrMax.Text))
            {
                textBoxes.Add(txtNrMax);
            }

            bool isValid = textBoxes.Where(x => String.IsNullOrEmpty(x.Text)).ToList().Count == 0;

            if (!isValid)
            {
                MessageBox.Show(string.Format("Os campos precisam ser preenchido!"));

                foreach (TextBox textBox in textBoxes)
                {
                    textBox.BorderBrush = Brushes.Red;
                }
            }
            return isValid;
        }

        // CPU USAGE
        public string getCurrentCpuUsage()
        {
            return "CPU" + cpuUsage.NextValue() + "%";
        }

        private void txtNrLinhas_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtNrLinhas.Text))
            {
                txtNrLinhas.BorderBrush = Brushes.LightGray;
            }
        }
        
        private void txtNrMin_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtNrMin.Text))
            {
                txtNrMin.BorderBrush = Brushes.LightGray;
            }
        }

        private void txtNrMax_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtNrMax.Text))
            {
                txtNrMax.BorderBrush = Brushes.LightGray;
            }
        }
        #endregion
    }
}
