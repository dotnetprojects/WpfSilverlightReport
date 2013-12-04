using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Resources;

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

            Uri fileUri = new Uri(fullName, UriKind.Relative);

            StreamResourceInfo streamInfo = Application.GetResourceStream(fileUri);

            string xaml = null;
            if ((streamInfo != null) && (streamInfo.Stream != null))
            {
                using (StreamReader reader = new StreamReader(streamInfo.Stream))
                {
                    xaml = reader.ReadToEnd();
                }
            }

            this.tabXaml.Header = name;
            this.txtXaml.Text = xaml;

            this.report = Report.Report.LoadFromString(xaml);
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
