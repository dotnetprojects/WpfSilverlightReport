/************************************************************************
 * Copyright: Seaking
 *
 * License:  This software abides by the LGPL license terms. For further
 *           licensing information please visit http://silverlightreport.codeplex.com/license.
 *
 * Author:   Seaking
 *
 ************************************************************************/

using System.Windows;
using System.Windows.Data;

namespace Report
{
    /// <summary>
    /// 
    /// </summary>
    public class CDataGridColumn
    {
        public CDataGridColumn()
        {
            this.Width = 1;
        }

        /// <summary>
        /// Gets or sets the Header of this instance of CDataGridColumn. 
        /// </summary>
        public string Header { get; set; }

        /// <summary>
        /// Gets or sets the Binding of this instance of CDataGridColumn. 
        /// </summary>
        public Binding Binding { get; set; }

        /// <summary>
        /// Gets or sets the width of this instance of CDataGridColumn. 
        /// The unit is GridUnitType.Star, ths default value is 1.
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// Gets or sets the ContentHorizontalAlignment of this instance of CDataGridColumn. 
        /// </summary>
        public HorizontalAlignment ContentHorizontalAlignment { get; set; }
    }
}
