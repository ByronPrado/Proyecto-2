
namespace Proyecto2;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		BindingContext= new ViewModel.MainViewModel();

	}
}

