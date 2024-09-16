namespace Go_Trade.Pages;

public partial class HomePageView : ContentPage
{
	public HomePageView(HomePage viewModel)
	{
		InitializeComponent(); 
        BindingContext = viewModel;
    }
}