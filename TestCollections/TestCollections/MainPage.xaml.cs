using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCollections;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly:Dependency(typeof(ValueProvider))]

namespace TestCollections
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
    }

    public class MainPageViewModel
    {
        public IValueProvider ValueProvider { get; set; }

        public MainPageViewModel()
        {
            ValueProvider = DependencyService.Get<IValueProvider>();
        }
    }
    public interface IValueProvider
    {
        IList<string> Values { get; set; }
    }

    public class ValueProvider : IValueProvider
    {
        private IList<string> _valueProvider;

        IList<string> IValueProvider.Values
        {
            get => _valueProvider ?? (_valueProvider = new ObservableCollection<string>
            {
                "first string",
                "second string",
            });
            set => _valueProvider = value;
        }
    }
}