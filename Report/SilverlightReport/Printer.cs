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
using System.Windows.Printing;

namespace Report
{
    public class Printer : IPrinter
    {
        public Printer()
        {
            this.printDocument.PrintPage += printDocument_PrintPage;
            this.printDocument.EndPrint += printDocument_EndPrint;
        }

        public event EventHandler<XPrintPageEventArgs> PrintPage;
        public event EventHandler<XBeginPrintEventArgs> BeginPrint;
        public event EventHandler<EventArgs> EndPrint;

        private PrintDocument printDocument = new PrintDocument();

        private int pageNo;
        private int pageCount;

        /// <summary>
        /// Print whole report.
        /// </summary>
        public void Print()
        {
            if (this.BeginPrint != null)
            {
                var args = new XBeginPrintEventArgs();
                this.BeginPrint(this, args);

                this.pageCount = args.PageCount;
                this.pageNo = 1;
            }

            this.printDocument.Print("XReport");
        }

        void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (this.PrintPage == null) throw new Exception("PrintPage event is empty.");

            XPrintPageEventArgs args = new XPrintPageEventArgs(pageNo);
            this.PrintPage(this, args);

            e.PageVisual = args.PageVisual;
            e.HasMorePages = this.pageNo++ < this.pageCount;
        }

        void printDocument_EndPrint(object sender, EndPrintEventArgs e)
        {
            if (this.EndPrint != null) this.EndPrint(this, EventArgs.Empty);
        }
    }
}
