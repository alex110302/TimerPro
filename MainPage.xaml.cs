using Microsoft.Maui.Layouts;
using TimerPro.Custom;

namespace TimerPro;

public partial class MainPage : ContentPage
{
    TimerLogic oTimer = new TimerLogic();

    bool isRunning = false;
    
    public MainPage()
    {
        InitializeComponent();
        Title = "Timer Pro";
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        btnStart.IsEnabled = true;
        btnStop.IsEnabled = false;
    }

    private void BtnStart_OnClicked(object sender, EventArgs e)
    {
        isRunning = true;
        btnStart.IsEnabled = false;
        btnStop.IsEnabled = true;
        
        Application.Current.Dispatcher.StartTimer(TimeSpan.FromSeconds(1), () =>
        {
            if (isRunning)
            {
                oTimer.SetTickCount();
                lblDisplay.Text = oTimer.GetFromatedString();
            }
            
            return isRunning;
        });
    }

    private void BtnStop_OnClicked(object sender, EventArgs e)
    {
        isRunning = false;
        btnStart.IsEnabled = true;
        btnStop.IsEnabled = false;
    }

    private void btnReset_OnClicked(object sender, EventArgs e)
    {
        oTimer.Reset();
        lblDisplay.Text = oTimer.GetFromatedString();
    }
}