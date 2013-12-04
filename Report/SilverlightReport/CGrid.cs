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
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Report
{
    /// <summary>
    /// Fortified Grid control, support Border and Line.
    /// </summary>
    public class CGrid : Grid
    {
        public CGrid()
        {
            this.BorderBrush = new SolidColorBrush(Colors.Black);
            this.BorderThickness = new Thickness(1);

            this.LineBrush = new SolidColorBrush(Colors.Black);
            this.LineThickness = 1;

            this.Loaded += new RoutedEventHandler(CGrid_Loaded);
        }

        /// <summary>
        /// Gets or sets the Brush that is used to create the border.
        /// </summary>
        public Brush BorderBrush { get; set; }

        /// <summary>
        /// Gets or set the thickness of the border.
        /// </summary>
        public Thickness BorderThickness { get; set; }

        /// <summary>
        /// Gets or sets the Brush that is used to draw the lines.
        /// </summary>
        public Brush LineBrush { get; set; }

        /// <summary>
        /// Gets or set the thickness of the lines.
        /// </summary>
        public double LineThickness { get; set; }

        private bool loaded;

        class SpanItem
        {
            public int Row;
            public int Column;
            public bool IsH;
        }

        void CGrid_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.loaded) return;

            this.loaded = true;
            this.DrawLine();
        }

        private void DrawLine()
        {
            int rowCount = this.RowDefinitions.Count;
            int columnCount = this.ColumnDefinitions.Count;
            if (rowCount == 0) rowCount = 1;
            if (columnCount == 0) columnCount = 1;

            List<SpanItem> spans = new List<SpanItem>();
            foreach (var child in this.Children)
            {
                var fe = child as FrameworkElement;

                int rowSpan = GetRowSpan(fe);
                int columnSpan = GetColumnSpan(fe);
                int row = GetRow(fe);
                int column = GetColumn(fe);

                for (int i = 1; i < rowSpan; i++)
                {
                    for (int j = 0; j < columnSpan; j++)
                    {
                        spans.Add(new SpanItem { Row = row + i - 1, Column = column + j, IsH = true });
                    }
                }

                for (int j = 1; j < columnSpan; j++)
                {
                    for (int i = 0; i < rowSpan; i++)
                    {
                        spans.Add(new SpanItem { Row = row + i, Column = column + j - 1, IsH = false });
                    }
                }
            }

            for (int row = 0; row < rowCount; row++)
            {
                for (int column = 0; column < columnCount; column++)
                {
                    if (spans.FirstOrDefault(item => item.Row == row && item.Column == column && item.IsH) == null)
                    {
                        if (row < rowCount - 1) DrawLine(row, column, VerticalAlignment.Bottom);
                    }

                    if (spans.FirstOrDefault(item => item.Row == row && item.Column == column && !item.IsH) == null)
                    {
                        if (column < columnCount - 1) DrawLine(row, column, HorizontalAlignment.Right);
                    }
                }
            }

            Border border = new Border();
            border.BorderThickness = this.BorderThickness;
            border.BorderBrush = this.BorderBrush;
            this.Children.Add(border);
            if (rowCount > 1) SetRowSpan(border, rowCount);
            if (columnCount > 1) SetColumnSpan(border, columnCount);
        }

        private void DrawLine(int row, int column, HorizontalAlignment hAlign)
        {
            Rectangle vLine = new Rectangle();
            vLine.Fill = this.LineBrush;
            vLine.Width = this.LineThickness;
            vLine.HorizontalAlignment = hAlign;
            this.Children.Add(vLine);
            vLine.SetValue(Grid.RowProperty, row);
            vLine.SetValue(Grid.ColumnProperty, column);
        }

        private void DrawLine(int row, int column, VerticalAlignment vAlign)
        {
            Rectangle hLine = new Rectangle();
            hLine.Fill = this.LineBrush;
            hLine.Height = this.LineThickness;
            hLine.VerticalAlignment = vAlign;
            this.Children.Add(hLine);
            hLine.SetValue(Grid.RowProperty, row);
            hLine.SetValue(Grid.ColumnProperty, column);
        }
    }
}
