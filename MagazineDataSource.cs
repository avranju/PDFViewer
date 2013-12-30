using PDFViewer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFViewer
{
    class MagazineDataSource
    {
        private string[] _pageUrls;

        private int _currentPage = 0;
        public int CurrentPage
        {
            get
            {
                return _currentPage;
            }

            set
            {
                _currentPage = value;
            }
        }

        public MagazineDataSource(string[] pageUrls)
        {
            _pageUrls = pageUrls;
            Pages = new ObservableCollection<Page>();
            CurrentPage = 0;
        }

        public ObservableCollection<Page> Pages { get; set; }
    }
}
