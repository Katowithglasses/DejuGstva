using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DejuGstva
{
    class RedGejurniyVM : Mvvm1125.MvvmNotify, IPageVM
    {
        public Mvvm1125.MvvmCommand CreateStudent { get; set; }
        public Student Student { get => student; set { student = value; NotifyPropertyChanged(); } }
        Model model;
        private Student student;

        public void SetModel(Model model)
        {
            this.model = model;
            model.EditStudentChanged += Model_EditStudentChanged;
            CreateStudent = new Mvvm1125.MvvmCommand(() => { PageContainer.ChangePageTo(PageType.GejuGstvaLIst); }, () => true);
        }

        private void Model_EditStudentChanged(object sender, EventArgs e)
        {
            Student = model.EditStudent;
        }
    }
}
