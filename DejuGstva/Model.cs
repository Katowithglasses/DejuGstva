using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Text.Json;

namespace DejuGstva
{
    public class Model
    {
        private Student editStudent;

        public List<Student> Students { get; set; } = new List<Student>();
        public event EventHandler StudentChenged;
        public event EventHandler EditStudentChanged;
        public Student EditStudent
        {
            get => editStudent; set
            { editStudent = value;
                EditStudentChanged?.Invoke(this, null);
            }
        }


        internal ObservableCollection<Student> GetStudent()
        {
            return new ObservableCollection<Student>(Students);
        }

        internal void CreateStudent(Student student)
        {
            EditStudent = new Student { FIO = student.FIO, Group = student.Group };
            Students.Add(EditStudent);
            StudentChenged?.Invoke(this, null);
        }

        internal void SetEditStudent(Student student)
        {
            EditStudent = student;
        }

        public void Save()
        { 
        var json = JsonSerializer.Serialize(Students, typeof(List<Student>));
            File.WriteAllText("students.db", json);
        }

        public void Load()
        {
            string file = "students.db";
            if (!File.Exists(file) || new FileInfo(file).Length == 0)
            {
                Students = new List<Student>();
                return;
            }
            string json = File.ReadAllText(file);
            Students = (List<Student>)JsonSerializer.Deserialize(json, typeof(List<Student>));
            StudentChenged?.Invoke(this, null);
        }

        public List<Student> GetDejurnih(Student student)
        {
            List<Student> dejurnie = new List<Student>();
            List<Student> chosenDejur = new List<Student>();
            int sredDejurst = 30 / Students.Count;
            for (int i = 0; i < Students.Count; i++)
            {
                if (Students[i].DateOfDejurstva.Count < sredDejurst)
                {
                    dejurnie.Add(Students[i]);
                }
            }

            Random rnd = new Random();
            for (int i = 0; i <= 1; i++)
            {
                int getDejurniy = rnd.Next(0, dejurnie.Count);
                chosenDejur.Add(dejurnie[getDejurniy]);
                dejurnie.Remove(dejurnie[getDejurniy]);
            }

            return chosenDejur;

        }
    }
}
