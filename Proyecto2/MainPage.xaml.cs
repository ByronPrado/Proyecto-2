
namespace Proyecto2;

public partial class MainPage : ContentPage
{	
	private ViewModel.MainViewModel viewModel;
	public MainPage()
	{
		InitializeComponent();
		viewModel = new ViewModel.MainViewModel();
		BindingContext = viewModel;

	}
}

