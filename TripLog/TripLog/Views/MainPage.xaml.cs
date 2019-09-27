namespace TripLog.Views
{
    using System;

    using Xamarin.Forms;

    using Models;
    using ViewModels;

    public partial class MainPage : ContentPage
    {
        private CombinedFactory _combinedFactory;
        private readonly BaseViewModel _vm;

        public MainPage(BaseViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;
            _vm = viewModel;
        }

        public void Init(CombinedFactory combinedFactory)
        {
            _combinedFactory = combinedFactory; 
        }

        private void OnNewClicked(object sender, EventArgs args)
        {
            var newEntryPage = _combinedFactory.Build(ViewType.New);

            Navigation.PushAsync(newEntryPage);
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var entry = (TripLogEntry)e.Item;

            var detailView = _combinedFactory.Build(ViewType.Detail, entry);

            Navigation.PushAsync(detailView);

            trips.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            _vm.Init();
        }
    }
}
