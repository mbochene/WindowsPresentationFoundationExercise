using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatsWpf.Models
{
    public class CatsModel
    {
        public ObservableCollection<Cat> Cats { get; } = new ObservableCollection<Cat>();
        public CatsModel()
        {
            Cats.Add(new Cat(1, "Coco", "british", new DateTime(2019, 03, 20)));
            Cats.Add(new Cat(2, "Chanel", "ragdoll", new DateTime(2020, 01, 01)));
        }
    }
}
