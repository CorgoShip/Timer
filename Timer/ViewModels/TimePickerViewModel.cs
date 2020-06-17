using Timer.ViewModels.Commands;

namespace Timer.ViewModels
{
    public class TimePickerViewModel
    {
        public static int timeSet = 5*60; // defaultni hodnota je 5 minut
        public TimeSetCMD SetTimer { get; private set; }

        public TimeSetCMD SetTime { get; private set; }

        public TimePickerViewModel()
        {
            SetTimer = new TimeSetCMD(DebugTime);
            SetTime = new TimeSetCMD(ParseTime);
        }

        public void ParseTime(string param) // nastavi odpocet na pozadovany cas
        {
            if (param == "btn5min")
            {
                timeSet = 5*60; // prevod na sekundy
            }
            else if (param == "btn3min")
            {
                timeSet = 3*60; // prevod na sekundy
            }
            else
            {
                timeSet = 1*60; // prevod na sekundy
            }            
        }

        public void DebugTime(string _)
        {            
            CountDown CD = new CountDown();
            Timer.App.Current.MainWindow.Close(); // zavre predchozi okno
            CD.Show(); // zobrazi okno s odpocetem
        }
    }
}
