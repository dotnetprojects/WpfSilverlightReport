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
using System.Windows;
using System.Windows.Controls;

namespace Report
{
    public class Printer : IPrinter
    {
        public Printer()
        {
        }

        public event EventHandler<XPrintPageEventArgs> PrintPage;
        public event EventHandler<XBeginPrintEventArgs> BeginPrint;
        public event EventHandler<EventArgs> EndPrint;

       
        private int pageNo;
        private int pageCount;

        /// <summary>
        /// Print whole report.
        /// </summary>
        public void Print()
        {
            PrintDialog dialog = new PrintDialog();
            if (dialog.ShowDialog() != true) return;


            if (this.BeginPrint != null)
            {
                var args = new XBeginPrintEventArgs();
                this.BeginPrint(this, args);

                this.pageCount = args.PageCount;
                this.pageNo = 1;

                for (int i = 0; i < args.PageCount; i++)
                {
                    var ppage = new XPrintPageEventArgs(i);
                    PrintPage(this, ppage);

                    ppage.PageVisual.Measure(new Size(dialog.PrintableAreaWidth, dialog.PrintableAreaHeight));
                    ppage.PageVisual.Arrange(new Rect(new Point(50, 50), ppage.PageVisual.DesiredSize));

                    dialog.PrintVisual(ppage.PageVisual, "XReport");


                }
            }

            if (this.EndPrint != null)
            {
                this.EndPrint(this, EventArgs.Empty);
            }
        }

        //void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        //{
        //    if (this.PrintPage == null) throw new Exception("PrintPage event is empty.");

        //    XPrintPageEventArgs args = new XPrintPageEventArgs(pageNo);
        //    this.PrintPage(this, args);

        //    e.PageVisual = args.PageVisual;
        //    e.HasMorePages = this.pageNo++ < this.pageCount;
        //}

        //void printDocument_EndPrint(object sender, EndPrintEventArgs e)
        //{
        //    if (this.EndPrint != null) this.EndPrint(this, EventArgs.Empty);
        //}
    }
}
