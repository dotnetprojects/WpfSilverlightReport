/************************************************************************
 * Copyright: Seaking
 *
 * License:  This software abides by the LGPL license terms. For further
 *           licensing information please visit http://silverlightreport.codeplex.com/license.
 *
 * Author:   Seaking
 *
 ************************************************************************/

namespace Report
{
    public enum SummaryRunning
    {
        None, Report, Group, Page
    }

    public enum SummaryFunc
    {
        Custom, Count, Sum, 
    }

    public class Summary
    {
        public SummaryRunning Running { get; set; }
        public SummaryFunc Func { get; set; }
        public string DataMember { get; set; }
        public bool IgnoreNullValues { get; set; }
    }
}
