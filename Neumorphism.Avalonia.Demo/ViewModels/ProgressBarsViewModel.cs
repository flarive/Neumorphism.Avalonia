namespace Neumorphism.Avalonia.Demo.ViewModels
{
    public sealed class ProgressBarsViewModel : ViewModelBase
    {
        private double _progress1;
        public double Progress1
        {
            get { return _progress1; }
            set
            {
                _progress1 = value;
                OnPropertyChanged(nameof(Progress1));
            }
        }

        private double _progress2;
        public double Progress2
        {
            get { return _progress2; }
            set
            {
                _progress2 = value;
                OnPropertyChanged(nameof(Progress2));
            }
        }

        private double _progress3;
        public double Progress3
        {
            get { return _progress3; }
            set
            {
                _progress3 = value;
                OnPropertyChanged(nameof(Progress3));
            }
        }
    }
}
