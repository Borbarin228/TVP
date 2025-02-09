
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
        private int timer = 0;
        private TrafficLight trafficLight = new TrafficLight();
        private WalkerLight walkerLight = new WalkerLight();
        private Color lightColor = Colors.Gray;
        public MainPage()
        {
            InitializeComponent();
            InitializeLights();
            InitializeWalker();
            StartTrafficLightAsync();
            

        }
        private void InitializeWalker()
        {

            walker.Add(Light(Colors.Gray), 0, 0);
            walker.Add(Light(Colors.Gray), 0, 1);

        }

        public async void StartTrafficLightAsync() {
            while (true) { 
                await TimerUpdate();
                lightColor = trafficLight.UpdateLights(timer);
                //для машины цвета
                lightColor = walkerLight.UpdateLight(Math.Abs( timer-12));
                //для пешехода цвета

            }
        }
        private void InitializeLights() {

            lights.Add(Light(Colors.Gray), 0, 0);
            lights.Add(Light(Colors.Gray), 0, 1);
            lights.Add(Light(Colors.Gray), 0, 2);
        }

        public Ellipse Light(Color color)
        {
            var currentLight = new Ellipse();

            currentLight.Fill = color;
            currentLight.HeightRequest = 150;
            currentLight.WidthRequest = 150;
            return currentLight;
        }

        
        private async Task TimerUpdate() {
            await Task.Delay(1000);
            timer += 1;
            if (timer == 25)
                timer = 0;
        }
        

       
    }

}
