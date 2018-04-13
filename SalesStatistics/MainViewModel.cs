using SalesStatistics.Data;
using SalesStatistics.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace SalesStatistics {
    class MainViewModel : INotifyPropertyChanged {
        readonly SalesStatisticsContext salesStatisticsContext;

        public MainViewModel() {
            salesStatisticsContext = new SalesStatisticsContext();

            Type1_Classifiers = new ObservableCollection<Type1_Classifier>(salesStatisticsContext.Set<Type1_Classifier>().ToList());
            Type2_Classifiers = new ObservableCollection<Type2_Classifier>(salesStatisticsContext.Set<Type2_Classifier>().ToList());
            Type3_Classifiers = new ObservableCollection<Type3_Classifier>(salesStatisticsContext.Set<Type3_Classifier>().ToList());
            Type4_Classifiers = new ObservableCollection<Type4_Classifier>(salesStatisticsContext.Set<Type4_Classifier>().ToList());

            SalesStatistics = new ObservableCollection<SalesStatistic>();

            Analytics = new Dictionary<string, Func<DateTime, int>>
            {
                {"день", date => CultureInfo.InvariantCulture.Calendar.GetDayOfYear(date)},
                {"месяц", date => date.Month},
                {"квартал", date => Math.Abs((date.Month - 1)/3) + 1}
            };

            SelectedType1_Classifier = Type1_Classifiers.FirstOrDefault();
            SelectedType2_Classifier = Type2_Classifiers.FirstOrDefault();
            SelectedType3_Classifier = Type3_Classifiers.FirstOrDefault();
            SelectedType4_Classifier = Type4_Classifiers.FirstOrDefault();
            SelectedAnalytic = Analytics.FirstOrDefault();
        }

        public ObservableCollection<Type1_Classifier> Type1_Classifiers { get; set; }
        public ObservableCollection<Type2_Classifier> Type2_Classifiers { get; set; }
        public ObservableCollection<Type3_Classifier> Type3_Classifiers { get; set; }
        public ObservableCollection<Type4_Classifier> Type4_Classifiers { get; set; }

        public ObservableCollection<SalesStatistic> SalesStatistics { get; set; }

        bool type1Checked;
        public bool Type1Checked {
            get { return type1Checked; }
            set { SetField(ref type1Checked, value); }
        }

        bool type2Checked;
        public bool Type2Checked {
            get { return type2Checked; }
            set { SetField(ref type2Checked, value); }
        }

        bool type3Checked;
        public bool Type3Checked {
            get { return type3Checked; }
            set { SetField(ref type3Checked, value); }
        }

        bool type4Checked;
        public bool Type4Checked {
            get { return type4Checked; }
            set { SetField(ref type4Checked, value); }
        }

        Type1_Classifier selectedType1_Classifier;
        public Type1_Classifier SelectedType1_Classifier {
            get { return selectedType1_Classifier; }
            set { SetField(ref selectedType1_Classifier, value); }
        }

        Type2_Classifier selectedType2_Classifier;
        public Type2_Classifier SelectedType2_Classifier {
            get { return selectedType2_Classifier; }
            set { SetField(ref selectedType2_Classifier, value); }
        }

        Type3_Classifier selectedType3_Classifier;
        public Type3_Classifier SelectedType3_Classifier {
            get { return selectedType3_Classifier; }
            set { SetField(ref selectedType3_Classifier, value); }
        }

        Type4_Classifier selectedType4_Classifier;
        public Type4_Classifier SelectedType4_Classifier {
            get { return selectedType4_Classifier; }
            set { SetField(ref selectedType4_Classifier, value); }
        }

        public Dictionary<string, Func<DateTime, int>> Analytics { get; set; }

        public KeyValuePair<string, Func<DateTime, int>> SelectedAnalytic { get; set; }

        ICommand getDataCommand;
        public ICommand GetDataCommand => getDataCommand ?? (getDataCommand = new RelayCommand(() =>
        {
            var sss =
               salesStatisticsContext.Set<SalesStatistic>()
                   .Where(ss => (!Type1Checked || ss.Type1_ClassifierId == SelectedType1_Classifier.ClassifierId)
                             && (!Type2Checked || ss.Type2_ClassifierId == SelectedType2_Classifier.ClassifierId)
                             && (!Type3Checked || ss.Type3_ClassifierId == SelectedType3_Classifier.ClassifierId)
                             && (!Type4Checked || ss.Type4_ClassifierId == SelectedType4_Classifier.ClassifierId))
                             .ToList();

            SalesStatistics.Clear();
            foreach (var ss in sss.ToList())
            {
                SalesStatistics.Add(ss);
            }
        }));

        ICommand getAnalysisCommand;
        public ICommand GetAnalysisCommand => getAnalysisCommand ?? (getAnalysisCommand = new RelayCommand(() => {

            var x = SalesStatistics.GroupBy(ss => new { ss.ShipDate.Year, DatePart = new {Name = SelectedAnalytic.Key, AnalyticType= SelectedAnalytic.Value(ss.ShipDate)}}).ToList();

            var maxs = x.Select(g=>new {Key = g.Key, Max = g.Max(s=>s.Amount), Min = g.Min(s=>s.Amount), Avg = g.Average(s=>s.Amount), Sum = g.Sum(s=>s.Amount), Cnt=g.Count()});

            StringBuilder sb = new StringBuilder();
            foreach (var m in maxs)
            { sb.AppendLine($"Год = {m.Key.Year} {m.Key.DatePart.Name} = {m.Key.DatePart.AnalyticType}  Max = {m.Max} Min = {m.Min} Avg = {m.Avg} Sum = {m.Sum} Count = {m.Cnt}"); }
            MessageBox.Show(sb.ToString(), "Анализ");

        }));

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        protected void SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null) {
            field = value;
            OnPropertyChanged(propertyName);
        }
        #endregion
    }

        #region RelayCommand
        public class RelayCommand : ICommand {
        readonly Action action;

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action action) {
            this.action = action;
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter) => action();
        #endregion
    }
}
