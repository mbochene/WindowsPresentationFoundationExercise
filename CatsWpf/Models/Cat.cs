using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatsWpf.Models
{
    public class Cat : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Id")); }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name")); }
        }

        private string breed;
        public string Breed
        {
            get { return breed; }
            set { breed = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Breed")); }
        }

        private DateTime birth;
        public DateTime Birth
        {
            get { return birth; }
            set { birth = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Birth")); }
        }

        public Cat(int id, string name, string breed, DateTime birth)
        {
            Id = id;
            Name = name;
            Breed = breed;
            Birth = birth;
        }
    }
}
