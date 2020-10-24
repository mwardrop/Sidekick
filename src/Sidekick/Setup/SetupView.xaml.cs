using System;
using System.Windows;
using Sidekick.Views;

namespace Sidekick.Setup
{
    public partial class SetupView : BaseView
    {
        private readonly SetupViewModel viewModel;

        public SetupView(IServiceProvider serviceProvider, SetupViewModel viewModel)
            : base("settings", serviceProvider)
        {
            this.viewModel = viewModel;

            InitializeComponent();
            DataContext = viewModel;

            Topmost = true;
            Dispatcher.Invoke(async () =>
            {
                await System.Threading.Tasks.Task.Delay(1000);
                Topmost = false;
            });
        }

        private async void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            await viewModel.Save();
        }

        private void DiscardChanges_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Close();
        }
    }
}
