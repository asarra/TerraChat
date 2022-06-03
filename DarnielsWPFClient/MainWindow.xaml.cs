using De.TerraChat.Base.Interfaces;
using De.TerraChat.ChrisLu;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DarnielsWPFClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public IChatProxy Proxy { get; set; } = new ChatProxy();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        public dynamic Data { 
            get
            {
                var d = Proxy.GetMessages();
                return new ObservableCollection<dynamic>(d);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(""));
        }
    }  
}

