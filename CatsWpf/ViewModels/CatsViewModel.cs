using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using CatsWpf.Models;
using CatsWpf.MVVM;

namespace CatsWpf.ViewModels
{
    public class CatsViewModel : IViewModel, INotifyPropertyChanged
    {
        private readonly CollectionViewSource collectionViewSource;

        private CatsModel CatsModel { get; } // Source dla collectionViewSource
        public ICollectionView Cats { get; } // korzysta z View collectionViewSource (może przechowywać przefiltorwany widok); ItemsSource dla ListView

        public event PropertyChangedEventHandler PropertyChanged;

        public Action Close { get; set; }
        public RelayCommand<object> AddCommand { get; }
        public RelayCommand<object> EditCommand { get; }
        public RelayCommand<object> DeleteCommand { get; }

        private Cat selectedCat;
        public Cat SelectedCat
        {
            get { return selectedCat; }
            set
            {
                selectedCat = value;
                EditCommand.NotifyCanExecuteChanged();
                DeleteCommand.NotifyCanExecuteChanged();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedCat)));
            }
        }

        public CatsViewModel(CatsModel catsModel)
        {
            CatsModel = catsModel;
            AddCommand = new RelayCommand<object>(o => AddCat());
            EditCommand = new RelayCommand<object>(o => EditCat(SelectedCat), o => SelectedCat != null);
            DeleteCommand = new RelayCommand<object>(o => DeleteCat(SelectedCat), o => SelectedCat != null);

            collectionViewSource = new CollectionViewSource
            {
                Source = CatsModel.Cats
            };
            //filtrowanie
            Cats = collectionViewSource.View;
        }

        public void AddCat()
        {
            CatViewModel catViewModel = new CatViewModel(CatsModel);
            ((App)Application.Current).WindowService.ShowDialog(catViewModel);
        }

        public void EditCat(Cat cat)
        {
            if (cat != null)
            {
                CatViewModel catViewModel = new CatViewModel(CatsModel, cat);
                ((App)Application.Current).WindowService.ShowDialog(catViewModel);
            }
        }

        public void DeleteCat(Cat cat)
        {
            if (cat != null)
                CatsModel.Cats.Remove(cat);
        }
    }
}
