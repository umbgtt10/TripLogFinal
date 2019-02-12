namespace TripLog.Views
{
    using System.ComponentModel;

    using Xamarin.Forms;

    using ViewModels;

    public class ViewFactory
    {
        public ContentPage Build(ViewType modelType, BaseViewModel viewModel)
        {
            switch (modelType)
            {
                case ViewType.Main:
                    var mainPage = new MainPage(viewModel);
                    return mainPage;
                case ViewType.New:
                    var newEntryPage = new NewEntryPage(viewModel);
                    return newEntryPage;
                case ViewType.Detail:
                    var detailPage = new DetailPage(viewModel);
                    return detailPage;
                default:
                    throw new InvalidEnumArgumentException($"Unknown {modelType}");
            }
        }
    }
}
