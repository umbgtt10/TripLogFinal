using System;
using System.Collections.Generic;
using System.Text;
using TripLog.ViewModels;
using Xamarin.Forms;

namespace TripLog.Views
{
    public class ViewFactory
    {
        public ContentPage Build(TripLogViewModelType modelType, BaseViewModel viewModel)
        {
            switch (modelType)
            {
                case TripLogViewModelType.Main:
                    var mainPage = new MainPage(viewModel);
                    return mainPage;
                case TripLogViewModelType.New:
                    var newEntryPage = new NewEntryPage(viewModel);
                    return newEntryPage;
                case TripLogViewModelType.Detail:
                    var detailPage = new DetailPage(viewModel);
                    return detailPage;
                default:
                    throw new Exception($"Unknown {modelType}");
            }
        }
    }
}
