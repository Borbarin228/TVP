using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Handlers;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace trafficLight
{
    public partial class MainPage : ContentPage
    {
        enum Status { Stop, Attention, Start}
        private Status status = Status.Stop;
        private PeriodicTimer _timer;
        private CancellationTokenSource _cancellationTokenSource;
        public MainPage()
        {
            InitializeComponent();
            InitializeLights();
            StartTrafficLightAsync();

        }
        public async void StartTrafficLightAsync() { 
            UpdateLights();
            await DelayUpdate();
        }
        private void InitializeLights() { 
            
        }
        private void UpdateLights() {
            Console.WriteLine("1");
        }
        private async Task DelayUpdate() {
            await Task.Delay(10000);
        }
        private void BlinkGreen() { }
        private void TransitionFromRed() { }

       
    }

}
