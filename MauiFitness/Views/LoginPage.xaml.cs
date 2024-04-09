namespace MauiFitness.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    private async void Btn_Login_Clicked(object sender, EventArgs e)
    {
        lblError.Text = string.Empty;
        if (user_name.Text == "user123" && password.Text == "12345")
        {
            //Update UI
            lblUser.Text = $"ID    : {user_name.Text}\n";
            LoginView.IsVisible = false;
            LogoutView.IsVisible = true;
        }
        else
            lblError.Text = "Wrong Username or Password";
        await DisplayAlert("Error", "Wrong username or password ", "OK");
    }

    private async void Btn_Logout_Clicked(object sender, EventArgs e)
    {
        try
        {
            //Update UI
            lblUser.Text = string.Empty;
            LogoutView.IsVisible = false;
            LoginView.IsVisible = true;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Alert", ex.Message, "OK");
        }
    }
}