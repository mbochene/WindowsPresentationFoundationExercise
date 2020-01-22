using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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

        private string filterIdText = "";
        public string FilterIdText
        {
            get
            {
                return filterIdText;
            }
            set
            {
                filterIdText = value;
                collectionViewSource.View.Refresh();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FilterIdText)));
            }
        }

        private string filterNameText = "";
        public string FilterNameText
        {
            get
            {
                return filterNameText;
            }
            set
            {
                filterNameText = value;
                collectionViewSource.View.Refresh();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FilterNameText)));
            }
        }

        private string filterBreedText = "";
        public string FilterBreedText
        {
            get
            {
                return filterBreedText;
            }
            set
            {
                filterBreedText = value;
                collectionViewSource.View.Refresh();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FilterBreedText)));
            }
        }

        private string filterBirthText = "";
        public string FilterBirthText
        {
            get
            {
                return filterBirthText;
            }
            set
            {
                filterBirthText = value;
                collectionViewSource.View.Refresh();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FilterBirthText)));
            }
        }

        bool FilterCat(Cat cat)
        {
            return (FilterIdText.Equals("") || cat.Id == (int.Parse(FilterIdText, NumberStyles.AllowLeadingSign))) &&
                   cat.Name.Contains(FilterNameText) && cat.Breed.Contains(FilterBreedText)
                   && cat.Birth.ToString("dd/MM/yyyy").Contains(FilterBirthText);
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

            collectionViewSource.View.Filter = (o) => FilterCat((Cat)o);
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
