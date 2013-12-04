using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ReportSample;

namespace WpfReportSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.cmbSample.SelectionChanged += new SelectionChangedEventHandler(cmbSample_SelectionChanged);
            this.cmbSample.SelectedIndex = 0;
        }

        private Report.Report report;

        void cmbSample_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string name = this.cmbSample.SelectedItem as string;
            string fullName = string.Format("/WpfReportSample;component/{0}", name);

            this.tabXaml.Header = name;
            this.txtXaml.Text = Report.Report.ReadXaml(fullName);

            this.report = Report.Report.LoadFromXaml(fullName);
            this.report.ItemsSource = new CustomerCollection();
        }

        private void Print1(object sender, RoutedEventArgs e)
        {
            this.report.Print();
        }

        private void Preview1(object sender, RoutedEventArgs e)
        {
            this.report.Preview();
        }
    }
}
