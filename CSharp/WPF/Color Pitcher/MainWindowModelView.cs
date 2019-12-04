using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ColorPitcher
{
    class MainWindowModelView : INotifyPropertyChanged
    {
        public ObservableCollection<Color> ListColors { get; set; } = new ObservableCollection<Color>();

        private Color selectedColor = Color.FromArgb(255, 0, 0, 0);
        private Command addCmd;
        private Command delCmd;
        public bool IsNoDoubleColor
        {
            get { return !(ListColors.Any(o => o.Equals(selectedColor))); }
        }
        public Command AddCmd
        {
            get
            {
                return addCmd ?? (addCmd = new Command((o)=>
                {
                    ListColors.Add(CopyColor(selectedColor));
                    Alpha = 255; Red = 0; Green = 0; Blue = 0;
                }));
            }
        }
        public Command DelCmd
        {
            get
            {
                return delCmd ?? (delCmd = new Command((o) =>
                {
                    Color color = (Color)o;
                    ListColors?.Remove((Color)o);
                }));
            }
        }
        public Color SelectedColor
        {
            get { return selectedColor; }
            set
            {
                selectedColor = value;
                OnPropertyChanged(nameof(SelectedColor));
                OnPropertyChanged(nameof(SelectedColorInvert));
                OnPropertyChanged(nameof(IsNoDoubleColor));
            }
        }

        public Color SelectedColorInvert
        {
            get { return Color.FromArgb(255, (byte)(255 - selectedColor.R), (byte)(255 - selectedColor.G), (byte)(255 - selectedColor.B)); }
        }
        public Color CopyColor(Color c) => Color.FromArgb(c.A, c.R, c.G, c.B);
        //public void CheckDoubleColor() => ListColors.Any(o => o.Equals(selectedColor));
        public byte Alpha
        {
            get { return selectedColor.A; }
            set
            {
                SelectedColor = Color.FromArgb(value, selectedColor.R, selectedColor.G, selectedColor.B);
                
                OnPropertyChanged(nameof(Alpha));
            }
        }
        public byte Red
        {
            get { return selectedColor.R; }
            set
            {
                SelectedColor = Color.FromArgb(selectedColor.A, value, selectedColor.G, selectedColor.B);
                OnPropertyChanged(nameof(Red));
            }
        }
        public byte Green
        {
            get { return selectedColor.G; }
            set
            {
                SelectedColor = Color.FromArgb(selectedColor.A, selectedColor.R, value, selectedColor.B);
                OnPropertyChanged(nameof(Green));
            }
        }
        public byte Blue
        {
            get { return selectedColor.B; }
            set
            {
                SelectedColor = Color.FromArgb(selectedColor.A, selectedColor.R, selectedColor.G, value);
                OnPropertyChanged(nameof(Blue));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
