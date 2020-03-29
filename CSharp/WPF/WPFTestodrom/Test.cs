using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace WPFTestodrom
{
    [Serializable]
    public class Test : INotifyPropertyChanged
    {
        private string theme = "";
        private string name = "";
        public string Name
        {
            get { return name; }
            set
            {
                if (value != null && !value.Equals(name))
                {
                    name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }
        public string Theme
        {
            get { return theme; }
            set
            {
               if (value != null && !value.Equals(theme))
                {
                    theme = value;
                    OnPropertyChanged(nameof(Theme));
                }
            }
        }

        public ObservableCollection<Question> Questions { get; private set; } = new ObservableCollection<Question>();
        [field: NonSerialized]

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        public override string ToString() => $"{Name} ({Questions.Count()}воп.)";

        public bool IsEmpty() => (Name == "" || Theme == "" || Questions.Count() == 0) ? true : false;

        public static bool operator ==(Test t1, Test t2) => (t1.Name == t2.Name && t1.Theme == t2.Theme) ? true : false;

        public static bool operator !=(Test t1, Test t2) => !(t1 == t2);
        public Test Copy(Test t)
        {
            this.Name = t.Name;
            this.Theme = t.Theme;

            this.Questions.Clear();
            foreach (var item in t.Questions)
            {
                this.Questions.Add(new Question().Copy(item));
            }

            return this;
        }
    }

    [Serializable]
    public class Question
    {
        public string Name { get; set; } = "";
        public List<Answer> Answers { get; private set; } = new List<Answer>();

        public override string ToString() => $"{Name}";
        public Question()
        {
            for (int i = 0; i < 4; i++)
            {
                Answers.Add(new Answer());
            }
        }

        public bool isCorrect() => (Name != "" && Answers.All(a => a.Name != "") && Answers.Any(a => a.isCorrect)) ? true : false;

        public static bool operator ==(Question q1, Question q2)
        {
            var result = q1.Name.Except(q2.Name).ToList();
            return (q1.Name == q2.Name && result.Count() == 0) ? true : false;
        }

        public static bool operator !=(Question q1, Question q2) => !(q1 == q2);
        public Question Copy(Question q)
        {
            this.Name = q.Name;
            this.Answers.Clear();
            q.Answers.ForEach(a => this.Answers.Add(new Answer().Copy(a)));

            return this;
        }
    }

    [Serializable]
    public class Answer
    {
        public string Name { get; set; } = "";
        public bool isCorrect { get; set; } = false;

        public override string ToString() => $"{Name} ({(isCorrect ? "В" : "Не в")}ерный)";

        public static bool operator ==(Answer a1, Answer a2) => (a1.Name == a2.Name && a1.isCorrect == a2.isCorrect) ? true : false;

        public static bool operator !=(Answer a1, Answer a2) => !(a1 == a2);

        public Answer Copy(Answer a)
        {
            this.Name = a.Name;
            this.isCorrect = a.isCorrect;

            return this;
        }
    }
}
