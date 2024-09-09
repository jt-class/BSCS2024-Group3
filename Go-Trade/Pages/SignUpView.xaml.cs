namespace Go_Trade.Pages;

public partial class SignUpView : ContentPage
{
	public SignUpView(SignUpModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}