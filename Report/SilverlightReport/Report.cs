/************************************************************************
 * Copyright: Seaking
 *
 * License:  This software abides by the LGPL license terms. For further
 *           licensing information please visit http://silverlightreport.codeplex.com/license.
 *
 * Author:   Seaking
 *
 ************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;
using System.Windows.Resources;
using System.Xml;

namespace Report
{
    /// <summary>
    /// Silverlight Report.
    /// </summary>
    [ContentProperty("Bands")]
    public class Report
    {
        public Report()
        {
            this.bands = new List<ReportBand>();
            this.bandsMetadata = new Dictionary<ReportBandKind, string>();

            this.virtualPage.Opacity = 0;
            this.popup.Child = this.virtualPage;
            this.popup.IsOpen = true;

            this.PageSize = new Size(827, 1169);//A4
            this.PageMargin = new Thickness(50);
        }

        private ReportBand pageHeaderBand;
        private ReportBand reportHeaderBand;
        private List<ReportBand> detailBands;
        private ReportBand reportFooterBand;
        private ReportBand pageFooterBand;
        private ReportBand topMarginBand;
        private ReportBand bottomMarginBand;

        private Preview preview;
        
        private List<ReportPage> pages;
        private ReportPage currentPage;

        private List<ReportBand> bands;
        private Dictionary<ReportBandKind, string> bandsMetadata;

        private Popup popup = new Popup();
        private StackPanel virtualPage = new StackPanel();

        /// <summary>
        /// Gets or sets the size of a report page.
        /// </summary>
        public Size PageSize { get; set; }

        /// <summary>
        /// Gets or sets the margin of a report page.
        /// </summary>
        public Thickness PageMargin { get; set; }

        /// <summary>
        /// Gets or sets the DataContext of a report.
        /// </summary>
        public object DataContext { get; set; }

        /// <summary>
        /// Gets or sets the ItemsSource of the report.
        /// </summary>
        public IList ItemsSource { get; set; }
        
        /// <summary>
        /// Gets the ReportBand collection of the report.
        /// </summary>
        public List<ReportBand> Bands
        {
            get { return bands; }
        }

        /// <summary>
        /// Gets or sets the DataGrid of the report.
        /// </summary>
        public CDataGrid DataGrid { get; set; }

        private double ContentWidth
        {
            get { return this.PageSize.Width - this.PageMargin.Left - this.PageMargin.Right; }
        }

        private double ContentHeight
        {
            get { return this.PageSize.Height - this.PageMargin.Top - this.PageMargin.Bottom; }
        }

        #region Summary

        public static readonly DependencyProperty SummaryProperty =
            DependencyProperty.RegisterAttached("Summary", typeof(Summary), typeof(UIElement),
                                                new PropertyMetadata(null,
                                                                     new PropertyChangedCallback(SummaryChangedCallBack)));

        private static void SummaryChangedCallBack(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            
        }

        public static void SetSummary(UIElement element, Summary value)
        {
            element.SetValue(SummaryProperty, value);
        }

        public static Summary GetSummary(UIElement element)
        {
            return (Summary)element.GetValue(SummaryProperty);
        }

        #endregion

        #region Preview , Print
        /// <summary>
        /// Show Preview window.
        /// </summary>
        public void Preview()
        {
            if (this.preview == null)
            {
                this.preview = new Preview();
                this.preview.BeginPrint += Printer_BeginPrint;
                this.preview.EndPrint += Printer_EndPrint;
                this.preview.PrintPage += Printer_PrintPage;
            }

            this.preview.Show();
        }

#if SILVERLIGHT
        private Printer printer;
#endif

        /// <summary>
        /// Print whole report.
        /// </summary>
        public void Print()
        {
#if SILVERLIGHT
            if (this.printer == null)
            {
                this.printer = new Printer();
                this.printer.BeginPrint += new EventHandler<XBeginPrintEventArgs>(Printer_BeginPrint);
                this.printer.EndPrint += new EventHandler<EventArgs>(Printer_EndPrint);
                this.printer.PrintPage += new EventHandler<XPrintPageEventArgs>(Printer_PrintPage);
            }

            this.printer.Print();
#endif
        }

        void Printer_BeginPrint(object sender, XBeginPrintEventArgs e)
        {
            this.ParseDataGrid();

            this.GenerateBands();

            this.VirtualLayout();

            this.GeneratePages();

            e.PageCount = this.pages.Count;
        }

        void Printer_EndPrint(object sender, EventArgs e)
        {
            if (this.currentPage != null) this.currentPage.ReleaseVisual();
        }

        void Printer_PrintPage(object sender, XPrintPageEventArgs e)
        {
            int pageNo = e.PageNo;
            if (pageNo < 1) pageNo = 1;
            if (pageNo > this.pages.Count) pageNo = this.pages.Count;

            if (this.currentPage != null) this.currentPage.ReleaseVisual();

            this.currentPage = this.pages[pageNo - 1];
            e.PageVisual = this.currentPage.GenerateVisual(this.PageSize.Width, this.PageSize.Height, this.PageMargin);
        }
        #endregion

        #region GenerateBands
        private void ParseDataGrid()
        {
            if (this.DataGrid != null)
            {
                if (this.bandsMetadata.ContainsKey(ReportBandKind.Detail))
                {
                    throw new Exception("Can't use DataGrid and DetailBand both.");
                }

                var header = this.DataGrid.GenerateHeader();

                ReportBand pageHeaderBand = this.bands.FirstOrDefault(band => band.Kind == ReportBandKind.PageHeader);
                if (pageFooterBand == null)
                {
                    pageHeaderBand = new ReportBand();
                    pageHeaderBand.Kind = ReportBandKind.PageHeader;
                    this.bands.Add(pageHeaderBand);
                }

                pageHeaderBand.Children.Add(header);
            }
        }

        private void GenerateBands()
        {
            this.pageHeaderBand = this.bands.FirstOrDefault(band => band.Kind == ReportBandKind.PageHeader);
            this.pageFooterBand = this.bands.FirstOrDefault(band => band.Kind == ReportBandKind.PageFooter);
            this.reportHeaderBand = this.bands.FirstOrDefault(band => band.Kind == ReportBandKind.ReportHeader);
            this.reportFooterBand = this.bands.FirstOrDefault(band => band.Kind == ReportBandKind.ReportFooter);
            this.topMarginBand = this.bands.FirstOrDefault(band => band.Kind == ReportBandKind.TopMargin);
            this.bottomMarginBand = this.bands.FirstOrDefault(band => band.Kind == ReportBandKind.BottomMargin);

            if (this.DataGrid != null || this.bandsMetadata.ContainsKey(ReportBandKind.Detail))
            {
                this.detailBands = new List<ReportBand>();

                if (this.ItemsSource == null)
                {
                    this.detailBands.Add(this.GenerateDetailBand());
                }
                else
                {
                    foreach (var item in this.ItemsSource)
                    {
                        var band = this.GenerateDetailBand();
                        band.DataContext = item;
                        this.detailBands.Add(band);
                    }
                }
            }
        }

        private ReportBand GenerateDetailBand()
        {
            if (this.DataGrid != null) return this.DataGrid.GenerateDetailBand();

            if (this.bandsMetadata.ContainsKey(ReportBandKind.Detail))
            {
                string detailXaml = this.bandsMetadata[ReportBandKind.Detail];

#if SILVERLIGHT
                return XamlReader.Load(detailXaml) as ReportBand;
#else
                using (MemoryStream stream = new MemoryStream())
                {
                    StreamWriter writer = new StreamWriter(stream, System.Text.Encoding.Unicode);
                    writer.Write(detailXaml);
                    writer.Flush();
                    stream.Position = 0;
                    return XamlReader.Load(stream) as ReportBand;
                    Report report = XamlReader.Load(stream) as Report;
                }
#endif
            }

            return null;
        }

        #endregion

        #region VirtualLayout
        private void VirtualLayout()
        {
            virtualPage.Width = this.ContentWidth;

            //if (this.pageHeaderBand != null) virtualPage.Children.Add(this.pageHeaderBand);
            //if (this.reportHeaderBand != null) virtualPage.Children.Add(this.reportHeaderBand);

            foreach (var band in this.bands)
            {
                band.DataContext = this.DataContext;
                if (band.Kind != ReportBandKind.Detail) virtualPage.Children.Add(band);
            }

            if (this.detailBands != null)
            {
                foreach (var band in this.detailBands)
                {
                    virtualPage.Children.Add(band);
                }
            }

            //if (this.reportFooterBand != null) virtualPage.Children.Add(this.reportFooterBand);
            //if (this.pageFooterBand != null) virtualPage.Children.Add(this.pageFooterBand);

            popup.UpdateLayout();

            foreach (var child in virtualPage.Children)
            {
                ReportBand band = (child as ReportBand);
                band.RenderHeight = band.ActualHeight;
                band.RenderWidth = band.ActualWidth;
            }

            virtualPage.Children.Clear();
        }
        #endregion

        #region GeneratePages
        private void GeneratePages()
        {
            List<XReportOriginalPage> oriPages = new List<XReportOriginalPage>();

            bool reportHeaderAdded = this.reportHeaderBand == null;
            bool reportFooterAdded = this.reportFooterBand == null;
            int detailAdded = 0;
            int detailCount = this.detailBands == null ? 0 : this.detailBands.Count;

            while (!reportHeaderAdded || !reportFooterAdded || detailAdded < detailCount)
            {
                XReportOriginalPage oriPage = new XReportOriginalPage(this.ContentWidth, this.ContentHeight);
                oriPages.Add(oriPage);

                //First, add pageheader and pagefooter
                if (this.pageHeaderBand != null) oriPage.PageHeaderBand = this.pageHeaderBand;
                if (this.pageFooterBand != null) oriPage.PageFooterBand = this.pageFooterBand;
                if (this.topMarginBand != null) oriPage.TopMarginBand = this.topMarginBand;
                if (this.bottomMarginBand != null) oriPage.BottomMarginBand = this.bottomMarginBand;

                //page can't contain pageheader and pagefooter
                if (oriPage.RemainHeight <= 0) throw new Exception("PageSize is too small.");

                //first band flag, except pageheader or pagefooter
                bool isFirstBand = true;

                if (!reportHeaderAdded)
                {
                    oriPage.AddBand(this.reportHeaderBand);
                    reportHeaderAdded = true;

                    isFirstBand = false;
                }

                //exist remain detail and page can contain complete detail
                while (detailAdded < detailCount &&
                    (oriPage.RemainHeight >= this.detailBands[detailAdded].RenderHeight || isFirstBand))
                {
                    oriPage.AddBand(this.detailBands[detailAdded++]);

                    isFirstBand = false;
                }

                if (!reportFooterAdded &&
                    (oriPage.RemainHeight >= this.reportFooterBand.RenderHeight || isFirstBand))
                {
                    oriPage.AddBand(this.reportFooterBand);
                    reportFooterAdded = true;
                }
            }

            this.pages = new List<ReportPage>();

            foreach (var oriPage in oriPages)
            {
                var realPages = oriPage.GeneratePages();
                foreach (var realPage in realPages)
                {
                    realPage.No = this.pages.Count + 1;
                    this.pages.Add(realPage);
                }
            }
        }
        #endregion

        #region LoadFromXaml
        public static Report LoadFromXaml(string file)
        {
            string xaml = ReadXaml(file);
            if (string.IsNullOrEmpty(xaml)) throw new Exception("Read Xaml faild.");

#if SILVERLIGHT
            Report report = XamlReader.Load(xaml) as Report;
#else
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream, System.Text.Encoding.Unicode);
            writer.Write(xaml);
            writer.Flush();
            stream.Position = 0;
            Report report = XamlReader.Load(stream) as Report;
            stream.Close();   
#endif
            if (report == null) throw new Exception("Invalid xaml.");

            List<string> bandsXaml = new List<string>();
            byte[] bytes = Encoding.UTF8.GetBytes(xaml);
            using (MemoryStream memoryStream = new MemoryStream(bytes))
            {
                using (XmlReader xmlReader = XmlReader.Create(memoryStream))
                {
                    xmlReader.Read();
                    string rootName = xmlReader.Name;
                    string prefix = rootName.Substring(0, rootName.IndexOf(':'));
                    string bandName = string.Format("{0}:{1}", prefix, typeof(ReportBand).Name);

                    while (xmlReader.ReadToFollowing(bandName))
                    {
                        bandsXaml.Add(xmlReader.ReadOuterXml());
                    }
                }
            }

            foreach (string bandXaml in bandsXaml)
            {
                byte[] bandBytes = Encoding.UTF8.GetBytes(bandXaml);
                using (MemoryStream bandMemStream = new MemoryStream(bandBytes))
                {
                    using (XmlReader bandReader = XmlReader.Create(bandMemStream))
                    {
                        bandReader.Read();
                        bool hasKind = bandReader.MoveToAttribute("Kind");
                        if (hasKind)
                        {
                            string strKind = bandReader.Value;
                            ReportBandKind kind = (ReportBandKind)Enum.Parse(typeof(ReportBandKind), strKind, false);
                            report.bandsMetadata[kind] = bandXaml;
                        }
                    }
                }
            }

            return report;
        }

        public static string ReadXaml(string file)
        {
            Uri fileUri = new Uri(file, UriKind.Relative);
            StreamResourceInfo streamInfo = Application.GetResourceStream(fileUri);

            string xaml = null;
            if ((streamInfo != null) && (streamInfo.Stream != null))
            {
                using (StreamReader reader = new StreamReader(streamInfo.Stream))
                {
                    xaml = reader.ReadToEnd();
                }
            }

            return xaml;
        }

        #endregion
    }
}
