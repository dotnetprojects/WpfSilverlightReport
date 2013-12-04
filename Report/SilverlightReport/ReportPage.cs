/************************************************************************
 * Copyright: Seaking
 *
 * License:  This software abides by the LGPL license terms. For further
 *           licensing information please visit http://silverlightreport.codeplex.com/license.
 *
 * Author:   Seaking
 *
 ************************************************************************/

using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Report
{
    internal class XReportOriginalPage
    {
        public XReportOriginalPage(double contentWidth, double contentHeight)
        {
            this.contentWidth = contentWidth;
            this.contentHeight = contentHeight;
        }

        private double contentWidth;
        private double contentHeight;
        private List<ReportBand> bands = new List<ReportBand>();

        public double RemainHeight
        {
            get
            {
                double remainHeight = contentHeight;

                if (this.PageHeaderBand != null) remainHeight -= this.PageHeaderBand.RenderHeight;
                if (this.PageFooterBand != null) remainHeight -= this.PageFooterBand.RenderHeight;
                if (this.TopMarginBand != null) remainHeight -= this.TopMarginBand.RenderHeight;
                if (this.BottomMarginBand != null) remainHeight -= this.BottomMarginBand.RenderHeight;

                foreach (ReportBand band in this.bands)
                {
                    remainHeight -= band.RenderHeight;
                }
                return remainHeight;
            }
        }

        public ReportBand TopMarginBand { get; set; }

        public ReportBand BottomMarginBand { get; set; }

        public ReportBand PageHeaderBand { get; set; }

        public ReportBand PageFooterBand { get; set; }

        public void AddBand(ReportBand band)
        {
            this.bands.Add(band);
        }

        public List<ReportPage> GeneratePages()
        {
            List<ReportPage> pages = new List<ReportPage>();

            ReportPage page = new ReportPage();
            pages.Add(page);

            //todo: multi page

            if (this.PageHeaderBand != null)
            {
                page.PageHeaderBand = new ReportPage.BandItem { Band = this.PageHeaderBand, Margin = new Thickness(0) };
            }

            if (this.PageFooterBand != null)
            {
                page.PageFooterBand = new ReportPage.BandItem { Band = this.PageFooterBand, Margin = new Thickness(0) };
            }

            if (this.TopMarginBand != null)
            {
                page.TopMarginBand = new ReportPage.BandItem { Band = this.TopMarginBand, Margin = new Thickness(0) };
            }

            if (this.BottomMarginBand != null)
            {
                page.BottomMarginBand = new ReportPage.BandItem { Band = this.BottomMarginBand, Margin = new Thickness(0) };
            }

            foreach (var band in this.bands)
            {
                page.AddBand(band, new Thickness(0));
            }

            return pages;
        }
    }

    internal class ReportPage
    {
        public class BandItem
        {
            public ReportBand Band;
            public Thickness Margin;
        }

        public ReportPage()
        {
            this.rootVisual.Child = this.grid;

            this.grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            this.grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            this.grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

            this.grid.Children.Add(this.panel);
            this.panel.SetValue(Grid.RowProperty, 1);
        }

        private Border rootVisual = new Border();
        private Grid grid = new Grid();
        private StackPanel panel = new StackPanel();
        private List<BandItem> bands = new List<BandItem>();

        public int No { get; set; }

        public BandItem PageHeaderBand { get; set; }

        public BandItem PageFooterBand { get; set; }

        public BandItem TopMarginBand { get; set; }

        public BandItem BottomMarginBand { get; set; }

        public BandItem ReportHeaderBand { get; set; }

        public void AddBand(ReportBand band, Thickness margin)
        {
            var bandItem = new BandItem { Band = band, Margin = margin };

            if (band.Kind == ReportBandKind.ReportHeader) this.ReportHeaderBand = bandItem;
            else this.bands.Add(bandItem);
        }

        public UIElement GenerateVisual(double pageWidth, double pageHeight, Thickness margin, ReportInformation info)
        {
            this.rootVisual.Width = pageWidth;
            this.rootVisual.Height = pageHeight;
            this.grid.Margin = margin;

            if (this.TopMarginBand != null)
            {
                this.TopMarginBand.Band.DataContext = info;
                this.AddChildren(this.grid, this.TopMarginBand);
                this.TopMarginBand.Band.SetValue(Grid.RowProperty, 0);
            }

            if (this.bands != null && this.bands.Count > 0)
            {
                if (this.ReportHeaderBand != null)
                {
                    this.ReportHeaderBand.Band.DataContext = info;
                    this.AddChildren(this.panel, this.ReportHeaderBand);
                }
                if (this.PageHeaderBand != null)
                {
                    this.PageHeaderBand.Band.DataContext = info;
                    this.AddChildren(this.panel, this.PageHeaderBand);
                }
                foreach (var band in this.bands)
                {
                    this.AddChildren(this.panel, band);
                }
                if (this.PageFooterBand != null)
                {
                    this.PageFooterBand.Band.DataContext = info;
                    this.AddChildren(this.panel, this.PageFooterBand);
                }
            }

            if (this.BottomMarginBand != null)
            {
                this.BottomMarginBand.Band.DataContext = info;
                this.AddChildren(this.grid, this.BottomMarginBand);
                this.BottomMarginBand.Band.SetValue(Grid.RowProperty, 2);
            }

            return this.rootVisual;
        }

        private void AddChildren(Panel panel, BandItem item)
        {
            item.Band.Margin = item.Margin;
            panel.Children.Add(item.Band);
        }

        public void ReleaseVisual()
        {
            this.panel.Children.Clear();

            for (int i = this.grid.Children.Count - 1; i >= 0; i--)
            {
                if (this.grid.Children[i] != this.panel) this.grid.Children.RemoveAt(i);
            }
        }
    }
}
