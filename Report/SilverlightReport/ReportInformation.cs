using System;
using System.ComponentModel;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Report
{
    public class ReportInformation : INotifyPropertyChanged
    {
        #region Implementation of INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }

        private int _pageCount;

        public int PageCount
        {
            get { return _pageCount; }
            set
            {
                _pageCount = value;
                RaisePropertyChanged("PageCount");
            }
        }

        private int _currentPage;

        public int CurrentPage
        {
            get { return _currentPage; }
            set
            {
                _currentPage = value;
                RaisePropertyChanged("CurrentPage");
            }
        }


        private string _printDateTime;

        public string PrintDateTime
        {
            get
            {
                if (string.IsNullOrEmpty(this._printDateTime))
                {
                    this._printDateTime = DateTime.Now.ToString();
                }

                return _printDateTime;
            }
        }

        private object _dataContext;

        public object DataContext
        {
            get { return _dataContext; }
            set
            {
                _dataContext = value;
                RaisePropertyChanged("DataContext");
            }
        }

        #endregion
    }
}
