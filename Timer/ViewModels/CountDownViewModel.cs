using System;
using System.ComponentModel;
using System.IO;
using System.Media;
using System.Windows.Threading;

namespace Timer.ViewModels
{
    class CountDownViewModel : INotifyPropertyChanged
    {
        private enum Sounds // zvuk k prehrani
        {
            None,
            Tick,
            Whisle
        }

        public int TimeLeft { get; set; } // zbyvajici cas v sekundach
        public int Minutes { get; set; } // pocet zbyvajicich minut
        public int TenSecs { get; set; } // pocet zbyvajicich desitek sekund
        public int Secs { get; set; } // pocet zbyvajicich jednotek sekund
        public string Color1 { get; set; } // barva minut (prvni cislice)
        public string Color2 { get; set; } // barva sekund (druha a treti cislice)
        public bool[] Number1 { get; set; } // prvni cislice
        public bool[] Number2 { get; set; } // druha cislice
        public bool[] Number3 { get; set; } // treti cislice

        private bool[][] _numbers = new bool[][] // obsahuje informatici ktera cislice ma ktere segmenty viditelne a ktere ne
        {
            // segment    A     B     C     D     E     F      G
            new bool[] {true, true, true, true, true, true, false},      // 0
            new bool[] {false, true, true, false, false, false, false},  // 1
            new bool[] {true, true, false, true, true, false, true},     // 2
            new bool[] {true, true, true, true, false, false, true},     // 3
            new bool[] {false, true, true, false, false, true, true},    // 4
            new bool[] {true, false, true, true, false, true, true},     // 5
            new bool[] {true, false, true, true, true, true, true},      // 6
            new bool[] {true, true, true, false, false, false, false},   // 7
            new bool[] {true, true, true, true, true, true, true},       // 8
            new bool[] {true, true, true, true, false, true, true},      // 9
            new bool[] {false, false, false, false, false, false, false} // NULL (vsechny segmenty jsou skryte)
        };

        private void NotifyPropertyChanged(string v) // notifiace o zmene stavu promenne (parametr je identifikator zmenene promenne)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }

        private DispatcherTimer DT = new DispatcherTimer(); // vytvoreni timeru

        public CountDownViewModel(int timeLeft) // parametr je pozadovana delka odpoctu
        {
            this.TimeLeft = timeLeft;
            Color1 = "Red";
            Color2 = "Lime";
            ParseTime(); // napise uvodni stav odpoctu            
            DT.Interval = new TimeSpan(0, 0, 1); // nastavi interval timeru na 1s
            DT.Tick += new EventHandler(dispatcherTimer_Tick);
            DT.Start();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {                        
            if (TimeLeft == 0)
            {
                // pokud zbyvajici cas klesne na nulu, nic nedelame
            }
            else // jinak snizime cas o jednu sekundu
            {                
                TimeLeft--;
                ParseTime(); // prekresli cas
            }
        }

        private void ParseTime() // rozdeli zbyvajici cas na minuty, desitky sekund a jednotky sekund
        {
            Minutes = TimeLeft / 60;
            int seconds = TimeLeft % 60;
            TenSecs = seconds / 10;
            Secs = seconds % 10;

            if (Minutes != 0 && seconds == 0) // zobrazení 0 na konci každé minuty bude provázeno delším zvukem
            {
                PlaySound(Sounds.None);
            }

            if (TimeLeft == 0) // posledni nula bude cervena
            {
                PlaySound(Sounds.Whisle); // poslední červená nula bude provázena dlouhým hvizdem
                Color2 = "Red";
                NotifyPropertyChanged("Color2");
            }
            else if (TimeLeft <= 10) // poslednich 10 sekund bude zlutych
            {
                Color2 = "Yellow";
                NotifyPropertyChanged("Color2");
                PlaySound(Sounds.Tick); // zobrazení každé žluté číslice bude provázeno krátkým tiknutím
            }

            if (Minutes == 0) // pokud zustava mene nez 60 sekund
            {
                Number1 = _numbers[10]; // nic nezobrazi
            }
            else 
            {                
                Number1 = _numbers[Minutes]; // priradi nove hodnoty do vykreslovanych cisel
            }

            if (Minutes == 0 && TenSecs == 0) // pokud zustava mene nez 10 sekund
            {
                Number2 = _numbers[10]; // nic nezobrazi
            }
            else 
            {                
                Number2 = _numbers[TenSecs];
            }           
            
            Number3 = _numbers[Secs];

            NotifyPropertyChanged("Number1"); // notifikace o zmene stavu promennych, zaridi prekresleni v GUI
            NotifyPropertyChanged("Number2");
            NotifyPropertyChanged("Number3");
        }

        void PlaySound(Sounds sounds) // prehraje pozadovany zvuk
        {
            SoundPlayer player;
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

            if (sounds == Sounds.Tick)
            {                
                player = new SoundPlayer(Path.Combine(projectDirectory, @".\watch-tick.wav"));
            }
            else if (sounds == Sounds.Whisle)
            {
                player = new SoundPlayer(Path.Combine(projectDirectory, @".\whistle.wav"));
            }
            else
            {
                player = new SoundPlayer(Path.Combine(projectDirectory, @".\impact-action.wav"));
            }

            player.Load();
            player.Play();            
        }
    }
}
