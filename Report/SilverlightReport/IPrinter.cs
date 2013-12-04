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

namespace Report
{
    public class XBeginPrintEventArgs:EventArgs
    {
        public int PageCount { get; set; }
    }

    public class XPrintPageEventArgs : EventArgs
    {
        public XPrintPageEventArgs(int pageNo)
        {
            this.pageNo = pageNo;
        }

        private int pageNo;

        public int PageNo { get { return pageNo; } }

        public UIElement PageVisual { get; set; }
    }

    public interface IPrinter
    {
        event EventHandler<XPrintPageEventArgs> PrintPage;

        event EventHandler<XBeginPrintEventArgs> BeginPrint;

        event EventHandler<EventArgs> EndPrint;
    }
}
