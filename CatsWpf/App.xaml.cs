using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CatsWpf
{
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    public partial class App : Application
    {
        public MVVM.IWindowService WindowService { get; } = new MVVM.WindowService();
        private Models.CatsModel CatsModel { get; } = new Models.CatsModel();
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            CatsWpf.ViewModels.CatsViewModel catsViewModel = new CatsWpf.ViewModels.CatsViewModel(CatsModel);
            WindowService.Show(catsViewModel);
        }
    }
}
