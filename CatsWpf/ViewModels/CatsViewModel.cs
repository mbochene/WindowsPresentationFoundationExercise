using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using CatsWpf.Models;
using CatsWpf.MVVM;

namespace CatsWpf.ViewModels
{
    public class CatsViewModel : IViewModel, INotifyPropertyChanged
    {
        private readonly CollectionViewSource collectionViewSource;

        private CatsModel CatsModel { get; } // Source dla collectionViewSource
        public ICollectionView Cats { get; } // korzysta z View collectionViewSource (może przechowywać przefiltorwany widok)

        public event PropertyChangedEventHandler PropertyChanged;
        public Action Close { get; set; }

        public CatsViewModel(CatsModel catsModel)
        {
            CatsModel = catsModel;
            collectionViewSource = new CollectionViewSource
            {
                Source = CatsModel.Cats
            };
            //filtrowanie
            Cats = collectionViewSource.View;
        }
    }
}
