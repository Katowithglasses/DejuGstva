using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DejuGstva
{
    /// <summary>
    /// Логика взаимодействия для AccDejurn.xaml
    /// </summary>
    public partial class AccDejurn : Window
    {
        public ObservableCollection<Student> Dejurnie { get; set; }

        public AccDejurn(List<Student> lists)
        {
            InitializeComponent
                ();
            Dejurnie = new ObservableCollection<Student>(lists);
            DataContext = this;
        }


    }
}
