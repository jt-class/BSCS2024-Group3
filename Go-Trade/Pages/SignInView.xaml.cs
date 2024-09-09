namespace Go_Trade.Pages;

public partial class SignInView : ContentPage
{
	public SignInView(SignInModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;

	}
}