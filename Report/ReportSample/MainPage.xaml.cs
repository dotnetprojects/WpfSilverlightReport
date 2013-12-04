using System.Windows;
using System.Windows.Controls;

namespace ReportSample
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();

            this.cmbSample.SelectionChanged += new SelectionChangedEventHandler(cmbSample_SelectionChanged);
            this.cmbSample.SelectedIndex = 0;
        }

        private Report.Report report;

        void cmbSample_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string name =  this.cmbSample.SelectedItem as string;
            string fullName = string.Format("/ReportSample;component/{0}", name);

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
