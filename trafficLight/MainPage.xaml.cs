
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
        private int timer = -1;
        private TrafficLight trafficLight = new TrafficLight();
        private WalkerLight walkerLight = new WalkerLight();
        private Color lightColor = Colors.Gray;
        private int changedStrokeLight = 0;
        private int changedStrokeWalker = 0;
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
                
                lightColor = trafficLight.UpdateLights(timer);
                UpdateLightColor(lightColor);
                lightColor = walkerLight.UpdateLight(timer);
                UpdateWalkerColor(lightColor);
                await TimerUpdate();
            }
        }
        private void UpdateLightColor(Color changeColor)
        {
            switch (trafficLight.status) {
                case TrafficLight.Status.RedYellow:
                    lights.Add(Light(Colors.Red), 0, 0);
                    lights.Add(Light(Colors.Yellow), 0, 1);
                    lights.Add(Light(Colors.Gray), 0, 2);
                    break;
                case TrafficLight.Status.Red:
                    lights.Add(Light(Colors.Red), 0, 0);
                    lights.Add(Light(Colors.Gray), 0, 1);
                    lights.Add(Light(Colors.Gray), 0, 2);
                    break;
                case TrafficLight.Status.Yellow:
                    lights.Add(Light(Colors.Gray), 0, 0);
                    lights.Add(Light(Colors.Yellow), 0, 1);
                    lights.Add(Light(Colors.Gray), 0, 2);
                    break;
                case TrafficLight.Status.Green:
                    lights.Add(Light(Colors.Gray), 0, 0);
                    lights.Add(Light(Colors.Gray), 0, 1);
                    lights.Add(Light(Colors.Green), 0, 2);
                    break;
                case TrafficLight.Status.Off:
                    lights.Add(Light(Colors.Red), 0, 0);
                    lights.Add(Light(Colors.Gray), 0, 1);
                    lights.Add(Light(Colors.Gray), 0, 2);
                    break;


            }
        }

        private void UpdateWalkerColor(Color lightColor)
        {
            switch (walkerLight.status) { 
            case WalkerLight.Status.Red:
                    walker.Add(Light(Colors.Red), 0, 0);
                    walker.Add(Light(Colors.Gray), 0, 1);

                    break;
            case WalkerLight.Status.Green:
                    walker.Add(Light(Colors.Gray), 0, 0);
                    walker.Add(Light(Colors.Green), 0, 1);

                    break;
            case WalkerLight.Status.None:
                    walker.Add(Light(Colors.Gray), 0, 0);
                    walker.Add(Light(Colors.Gray), 0, 1);

                    break;
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
