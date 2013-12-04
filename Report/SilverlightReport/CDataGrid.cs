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
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace Report
{
    /// <summary>
    /// This class provides a quick method to add a CGrid in PageHeader, a CGrid in DetailBand.
    /// </summary>
    [ContentProperty("Columns")]
    public class CDataGrid
    {
        public CDataGrid()
        {
            this.columns = new List<CDataGridColumn>();
            this.Width = Double.NaN;
            this.HeaderFontWeight = FontWeights.Bold;
            this.CellPadding = new Thickness(4);
        }

        private List<CDataGridColumn> columns;

        /// <summary>
        /// Gets the columns of this instance of CDataGrid.
        /// </summary>
        public List<CDataGridColumn> Columns
        {
            get { return columns; }
        }

        /// <summary>
        /// Gets or sets the width of this instance of CDataGrid. The default value is Double.NaN.
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// Gets or sets the CellPadding of this instance of CDataGrid. The default value is new Thickness(4).
        /// </summary>
        public Thickness CellPadding { get; set; }

        /// <summary>
        /// Gets or sets the HeaderHorizontalAlignment of this instance of CDataGrid.
        /// </summary>
        public HorizontalAlignment HeaderHorizontalAlignment { get; set; }

        /// <summary>
        /// Gets or sets the HeaderFontWeight of this instance of CDataGrid. The default value is FontWeights.Bold.
        /// </summary>
        public FontWeight HeaderFontWeight { get; set; }

        /// <summary>
        /// Gets or sets the TextWrapping of this instance of CDataGrid.
        /// </summary>
        public TextWrapping TextWrapping { get; set; }

        internal FrameworkElement GenerateHeader()
        {
            CGrid gridHeader = new CGrid { Width = this.Width };

            foreach (var column in this.columns)
            {
                var width = new GridLength(column.Width, GridUnitType.Star);

                gridHeader.ColumnDefinitions.Add(new ColumnDefinition { Width = width });

                TextBlock txbHeader = new TextBlock();
                txbHeader.HorizontalAlignment = this.HeaderHorizontalAlignment;
                txbHeader.Text = column.Header;
                txbHeader.Margin = this.CellPadding;
                txbHeader.TextWrapping = this.TextWrapping;
                txbHeader.FontWeight = this.HeaderFontWeight;
                gridHeader.Children.Add(txbHeader);
                Grid.SetColumn(txbHeader, columns.IndexOf(column));
            }

            return gridHeader;
        }

        internal ReportBand GenerateDetailBand()
        {
            CGrid gridBody = new CGrid { Width = this.Width, BorderThickness = new Thickness(1, 0, 1, 1) };

            foreach (var column in this.columns)
            {
                var width = new GridLength(column.Width, GridUnitType.Star);

                gridBody.ColumnDefinitions.Add(new ColumnDefinition { Width = width });

                TextBlock txbBody = new TextBlock();
                txbBody.HorizontalAlignment = column.ContentHorizontalAlignment;
                txbBody.SetBinding(TextBlock.TextProperty, column.Binding);
                txbBody.Margin = this.CellPadding;
                txbBody.TextWrapping = this.TextWrapping;
                gridBody.Children.Add(txbBody);
                Grid.SetColumn(txbBody, columns.IndexOf(column));
            }

            ReportBand band = new ReportBand();
            band.Kind = ReportBandKind.Detail;
            band.Children.Add(gridBody);

            return band;
        }

        internal Dictionary<ReportBandKind, FrameworkElement> GenerateFrameworkElement()
        {
            var elements = new Dictionary<ReportBandKind, FrameworkElement>();

            CGrid gridHeader = new CGrid { Width = this.Width };
            CGrid gridBody = new CGrid { Width = this.Width, BorderThickness = new Thickness(1, 0, 1, 1) };

            foreach (var column in this.columns)
            {
                var width = new GridLength(column.Width, GridUnitType.Star);

                gridHeader.ColumnDefinitions.Add(new ColumnDefinition { Width = width });
                gridBody.ColumnDefinitions.Add(new ColumnDefinition { Width = width });

                TextBlock txbHeader = new TextBlock();
                txbHeader.Text = column.Header;
                txbHeader.Margin = this.CellPadding;
                txbHeader.TextWrapping = this.TextWrapping;
                txbHeader.FontWeight = FontWeights.Bold;
                gridHeader.Children.Add(txbHeader);
                Grid.SetColumn(txbHeader, columns.IndexOf(column));

                TextBlock txbBody = new TextBlock();
                txbBody.SetBinding(TextBlock.TextProperty, column.Binding);
                txbBody.Margin = this.CellPadding;
                txbBody.TextWrapping = this.TextWrapping;
                gridBody.Children.Add(txbBody);
                Grid.SetColumn(txbBody, columns.IndexOf(column));
            }

            elements.Add(ReportBandKind.PageHeader, gridHeader);
            elements.Add(ReportBandKind.Detail, gridBody);

            return elements;
        }
    }
}
