/************************************************************************
 * Copyright: Seaking
 *
 * License:  This software abides by the LGPL license terms. For further
 *           licensing information please visit http://silverlightreport.codeplex.com/license.
 *
 * Author:   Seaking
 *
 ************************************************************************/

using System.Windows.Controls;

namespace Report
{
    /// <summary>
    /// Specifies the types of bands used in SilverlightReport.
    /// </summary>
    public enum ReportBandKind
    {
        /// <summary>
        /// Objects placed in this band are displayed once, at the beginning of the report. 
        /// Usually contains the report title and any other information only required at the start of the report. 
        /// </summary>
        ReportHeader,

        /// <summary>
        /// Objects placed in this band are displayed at the top of each page. 
        /// These can be used to display the date, report name, etc. 
        /// </summary>
        TopMargin, 

        /// <summary>
        /// Objects placed in this band are displayed at the top of each page, below the TopMarginBand. 
        /// Normally used to contain the header of a table continued from the previous page. 
        /// </summary>
        PageHeader, 

        /// <summary>
        /// Objects placed in this band are displayed at the beginning of each group of records. 
        /// Typically holds the field headers for the group.
        /// Warning: The current version does not support this Kind. 
        /// </summary>
        GroupHeader, 

        /// <summary>
        /// Objects placed in this band are displayed with each new record from the primary data source. 
        /// The band of this type contains the bulk of the report data as it is re-printed for each record, 
        /// typically displays individual records. 
        /// </summary>
        Detail, 

        /// <summary>
        /// Objects placed in this band are displayed at the end of each group of records. 
        /// Normally used to provide summary values based upon the group's data. 
        /// Warning: The current version does not support this Kind. 
        /// </summary>
        GroupFooter, 

        /// <summary>
        /// Objects placed in this band are displayed at the bottom of each page, above the BottomMarginBand.
        /// Normally used to contain the footer of a table continued on the following page. 
        /// </summary>
        PageFooter, 
        
        /// <summary>
        /// Objects placed in this band are displayed at the bottom of each page. 
        /// This section usually contains the page number and other auxiliary information. 
        /// </summary>
        BottomMargin, 

        /// <summary>
        /// Objects placed in this band are displayed once, at the end of the report. 
        /// Used to display information only required once at the end of the report such as grand totals. 
        /// </summary>
        ReportFooter
    }

    /// <summary>
    /// A Report Band represents a specific area on a report page, 
    /// used to define how to render report controls which belong to it. 
    /// </summary>
    public class ReportBand : StackPanel
    {
        /// <summary>
        /// Gets or sets the kind of the ReportBand.
        /// </summary>
        public ReportBandKind Kind { get; set; }

        internal double RenderHeight { get; set; }
        internal double RenderWidth { get; set; }
    }
}
