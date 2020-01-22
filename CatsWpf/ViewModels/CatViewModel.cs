using CatsWpf.Models;
using CatsWpf.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatsWpf.ViewModels
{
    public class CatViewModel : MVVM.IViewModel, System.ComponentModel.IDataErrorInfo
    {
        private CatsModel CatsModel { get; }
        private Cat Cat { get; }

        public Action Close { get; set; }
        public RelayCommand<CatViewModel> OkCommand { get; } = new RelayCommand<CatViewModel> ((catViewModel) => { catViewModel.Ok(); });
        public RelayCommand<CatViewModel> CancelCommand { get; } = new RelayCommand<CatViewModel> ((catViewModel) => { catViewModel.Cancel(); });

        public int Id { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public DateTime Birth { get; set; }

        public CatViewModel(CatsModel catsModel, Cat cat = null)
        {
            CatsModel = catsModel;
            Cat = cat;

            if(Cat != null)
            {
                Id = Cat.Id;
                Name = Cat.Name;
                Breed = Cat.Breed;
                Birth = Cat.Birth;
            }
            else
            {
                Birth = DateTime.Now;
            }
        }

        public void Ok()
        {
            if (Cat == null)
            {
                Cat cat = new Cat(Id, Name, Breed, Birth);
                CatsModel.Cats.Add(cat);
            }
            else
            {
                Cat.Id = Id;
                Cat.Name = Name;
                Cat.Breed = Breed;
                Cat.Birth = Birth;
            }
            Close?.Invoke();
        }

        public void Cancel() => Close?.Invoke();

        public string Error { get { return null; } }

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case "Id":
                        foreach(Cat cat in CatsModel.Cats)
                        {
                            if (cat.Id == this.Id && cat!=Cat)
                                return "Cat with such ID already exists!";
                        }
                        break;
                }

                return string.Empty;
            }
        }
    }
}
