using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WorkTImer.Model;

namespace WorkTImer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Init();

            var vm = new ViewModel.MainWindowViewModel();
            vm.Show();
        }

        /// <summary>
        /// 初期化処理
        /// </summary>
        public void Init()
        {
            AppStatus.Init();
        }

    }
}
