using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace DejuGstva
{
    class MainVM : Mvvm1125.MvvmNotify
    {
        Model model;
        public Page CurrentPage { get; set; }

        public string Messege
        {
            get;
            set;
        }

        public MainVM()
        {
            model = new Model();
            PageContainer.SetModel(model);
            CurrentPage = PageContainer.GetPageByType(PageType.GejuGstvaLIst);
            PageContainer.CurrentPageChanged += PageContainer_CurrentPageChanged;
            model.Load();
            Application.Current.Exit += (o, e) => model.Save();
        }

        void PageContainer_CurrentPageChanged(object sender, PageType e)
        {
            CurrentPage = PageContainer.GetPageByType(e);
            NotifyPropertyChanged("CurrentPage");
        }
    }
}
