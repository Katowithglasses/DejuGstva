using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DejuGstva
{
    class GejuGstvaLIstVM : Mvvm1125.MvvmNotify, IPageVM
    {
        public ObservableCollection<Student> Students { get; set; }
        public Mvvm1125.MvvmCommand CreateStudent { get; set; }
        public Mvvm1125.MvvmCommand RedStudent { get; set; }
        public Mvvm1125.MvvmCommand ShoseDejurnix { get; set; }
        Model model;
        private Student student = new Student();

        //ReceptBook receptBook;

        public Student Student { get => student; set { student = value; NotifyPropertyChanged(); } }



        public void SetModel(Model model)
        {
            this.model = model;
            Students = model.GetStudent();
            model.StudentChenged += Model_PersenChenged;
            CreateStudent = new Mvvm1125.MvvmCommand(() => {
                //PageContainer.ChangePageTo(PageType.RedGejurniy);
                model.CreateStudent(Student);
                
            }, () => true);
            RedStudent = new Mvvm1125.MvvmCommand(() => {
                PageContainer.ChangePageTo(PageType.RedGejurniy);
                model.SetEditStudent(Student);
            }, () => Student != null);

            ShoseDejurnix = new Mvvm1125.MvvmCommand(() => { new AccDejurn( model.GetDejurnih(Student)).Show(); } , () => Student != null);
        }

        private void Model_PersenChenged(object sender, EventArgs e)
        {
            Students = model.GetStudent();
            NotifyPropertyChanged("Students");
        }
    }
}
