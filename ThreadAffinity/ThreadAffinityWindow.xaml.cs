using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace ThreadAffinity
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			Task.Factory.StartNew(ChangeCompanyName);
		}

		private void ChangeCompanyName()
		{
			Thread.Sleep(2500);
			UpdateCompanyName("AV Corp");
		}

		private void UpdateCompanyName(string companyName)
		{
			Dispatcher.Invoke(() =>
			{
				txtMessage.Text = companyName;
			});
		}
	}
}