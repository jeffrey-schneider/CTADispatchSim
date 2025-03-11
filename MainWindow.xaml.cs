using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Threading;

namespace CTADispatchSim
{

    public enum TrackDirection
    {
        Inbound,
        Outbound
    }

    
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public ObservableCollection<Train> Trains { get; set; } = new ObservableCollection<Train>();
        public ObservableCollection<TrackBlock> TrackBlocks { get; set; } = new ObservableCollection<TrackBlock>();

        private TrackBlock _testTrackBlock;
        private DispatcherTimer trainMovementTimer;


        public TrackBlock TestTrackBlock
        {
            get => _testTrackBlock;
            set
            {
                _testTrackBlock = value;
                OnPropertyChanged(nameof(TestTrackBlock));
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            Debug.WriteLine("✅ MainWindow constructor started!"); // Debug Message
            
            LoadTracks();
            LoadTrains();
            
            trainMovementTimer = new DispatcherTimer();
            trainMovementTimer.Interval = TimeSpan.FromSeconds(3); //move trains every 3 seconds
            trainMovementTimer.Tick += MoveTrains;
            trainMovementTimer.Start();

            Debug.WriteLine("🚆 Train movement timer started!"); // Debug message
        }

        public void StartTrainTimer()
        {
            if(trainMovementTimer != null)
            {
                trainMovementTimer.Start();
                Debug.WriteLine("🚀 Train movement timer started manually from OnStartup!");            
            }
        }




        private void MoveTrains(object sender, EventArgs e)
        {
            foreach (var train in Trains)
            {
                Debug.WriteLine($"🚆 {train.Name} is at {train.CurrentStation}");

                var currentTrack = TrackBlocks.FirstOrDefault(t =>
                    t.StartStation == train.CurrentStation &&
                    t.Direction == train.Direction);

                if (currentTrack != null)
                {
                    train.CurrentStation = currentTrack.EndStation;

                    // 🚆 Special Handling for The Loop (Green Line - Pass Through)
                    if (train.CurrentStation == "Clark/Lake" && train.Direction == TrackDirection.Inbound)
                    {
                        Debug.WriteLine($"🔄 {train.Name} has entered The Loop at Clark/Lake.");
                    }
                    else if (train.CurrentStation == "Adams/Wabash" && train.Direction == TrackDirection.Inbound)
                    {
                        Debug.WriteLine($"⚠ {train.Name} is at Adams/Wabash and must continue to Roosevelt.");
                        train.CurrentStation = "Roosevelt"; // Ensure it exits The Loop correctly
                    }
                    else if (train.CurrentStation == "Roosevelt" && train.Direction == TrackDirection.Inbound)
                    {
                        // 🚆 Ensure train exits The Loop and transitions to outbound
                        Debug.WriteLine($"🚆 {train.Name} has exited The Loop at Roosevelt and is switching to Outbound.");
                        train.Direction = TrackDirection.Outbound;
                    }
                    else if (train.CurrentStation == "Ashland/63rd" && train.Direction == TrackDirection.Outbound)
                    {
                        // 🚆 Train reached the end of the outbound route - switch to inbound
                        Debug.WriteLine($"🔄 {train.Name} reached Ashland/63rd and is reversing to Inbound.");
                        train.Direction = TrackDirection.Inbound;
                    }
                    else if (train.CurrentStation == "Harlem/Lake" && train.Direction == TrackDirection.Inbound)
                    {
                        // 🚆 Train reached the end of the inbound route - switch to outbound
                        Debug.WriteLine($"🔄 {train.Name} reached Harlem/Lake and is reversing to Outbound.");
                        train.Direction = TrackDirection.Outbound;
                    }
                    else
                    {
                        Debug.WriteLine($"➡ {train.Name} moved to {train.CurrentStation}");
                    }
                }
                else
                {
                    // Train reached end, ensure it loops correctly
                    if (train.Direction == TrackDirection.Outbound && train.CurrentStation == "Ashland/63rd")
                    {
                        train.CurrentStation = "Halsted"; // Start inbound path from Ashland/63rd
                        train.Direction = TrackDirection.Inbound;
                        Debug.WriteLine($"🔄 {train.Name} reversed and is now inbound at {train.CurrentStation}");
                    }
                    else if (train.Direction == TrackDirection.Inbound && train.CurrentStation == "Harlem/Lake")
                    {
                        train.Direction = TrackDirection.Outbound;
                        Debug.WriteLine($"🔄 {train.Name} reversed direction and is now outbound at {train.CurrentStation}");
                    }
                }
            }
        }




        private void MoveTrainsPurple(object sender, EventArgs e)
        {
            foreach (var train in Trains)
            {
                Debug.WriteLine($"🚆 {train.Name} is at {train.CurrentStation}");

                var currentTrack = TrackBlocks.FirstOrDefault(t =>
                    t.StartStation == train.CurrentStation &&
                    t.Direction == train.Direction);

                if (currentTrack != null)
                {
                    train.CurrentStation = currentTrack.EndStation;

                    // 🚆 Special Handling for The Loop (Purple Line Express - Clockwise)
                    if (train.CurrentStation == "Clark/Lake" && train.Direction == TrackDirection.Inbound)
                    {
                        Debug.WriteLine($"🔄 {train.Name} has entered The Loop at Clark/Lake.");
                    }
                    else if (train.CurrentStation == "Washington/Wells" && train.Direction == TrackDirection.Inbound)
                    {
                        // 🚆 Train completes The Loop and switches to Outbound
                        Debug.WriteLine($"🚆 {train.Name} has exited The Loop at Washington/Wells and is switching to Outbound.");
                        train.Direction = TrackDirection.Outbound;
                    }
                    else
                    {
                        Debug.WriteLine($"➡ {train.Name} moved to {train.CurrentStation}");
                    }
                }
                else
                {
                    // Train reached end, loop back
                    if (train.Direction == TrackDirection.Inbound)
                    {
                        train.CurrentStation = TrackBlocks.First(t => t.Direction == TrackDirection.Outbound).StartStation;
                        train.Direction = TrackDirection.Outbound;
                        Debug.WriteLine($"🔄 {train.Name} reversed direction and is now outbound at {train.CurrentStation}");
                    }
                    else
                    {
                        train.CurrentStation = TrackBlocks.First(t => t.Direction == TrackDirection.Inbound).StartStation;
                        train.Direction = TrackDirection.Inbound;
                        Debug.WriteLine($"🔄 {train.Name} reversed direction and is now inbound at {train.CurrentStation}");
                    }
                }
            }
        }


        private void MoveTrainsBrown(object sender, EventArgs e)
        {
            foreach (var train in Trains)
            {
                Debug.WriteLine($"🚆 {train.Name} is at {train.CurrentStation}");

                var currentTrack = TrackBlocks.FirstOrDefault(t =>
                    t.StartStation == train.CurrentStation &&
                    t.Direction == train.Direction);

                if (currentTrack != null)
                {
                    train.CurrentStation = currentTrack.EndStation;

                    // 🚆 Special Handling for The Loop (Brown Line Counterclockwise)
                    if (train.CurrentStation == "Washington/Wells" && train.Direction == TrackDirection.Inbound)
                    {
                        Debug.WriteLine($"🔄 {train.Name} has entered The Loop at Washington/Wells.");
                    }
                    else if (train.CurrentStation == "Clark/Lake" && train.Direction == TrackDirection.Inbound)
                    {
                        // 🚆 Train completes The Loop and switches to Outbound
                        Debug.WriteLine($"🚆 {train.Name} has exited The Loop at Clark/Lake and is switching to Outbound.");
                        train.Direction = TrackDirection.Outbound;
                    }
                    else
                    {
                        Debug.WriteLine($"➡ {train.Name} moved to {train.CurrentStation}");
                    }
                }
                else
                {
                    // Train reached end, loop back
                    if (train.Direction == TrackDirection.Inbound)
                    {
                        train.CurrentStation = TrackBlocks.First(t => t.Direction == TrackDirection.Outbound).StartStation;
                        train.Direction = TrackDirection.Outbound;
                        Debug.WriteLine($"🔄 {train.Name} reversed direction and is now outbound at {train.CurrentStation}");
                    }
                    else
                    {
                        train.CurrentStation = TrackBlocks.First(t => t.Direction == TrackDirection.Inbound).StartStation;
                        train.Direction = TrackDirection.Inbound;
                        Debug.WriteLine($"🔄 {train.Name} reversed direction and is now inbound at {train.CurrentStation}");
                    }
                }
            }
        }



        private void MoveTrainsOrange(object sender, EventArgs e)
        {
            foreach (var train in Trains)
            {
                Debug.WriteLine($"🚆 {train.Name} is at {train.CurrentStation}");

                var currentTrack = TrackBlocks.FirstOrDefault(t =>
                    t.StartStation == train.CurrentStation &&
                    t.Direction == train.Direction);

                if (currentTrack != null)
                {
                    train.CurrentStation = currentTrack.EndStation;

                    // 🚆 Special Handling for The Loop (Orange Line)
                    if (train.CurrentStation == "Harold Washington Library" && train.Direction == TrackDirection.Inbound)
                    {
                        Debug.WriteLine($"🔄 {train.Name} has entered The Loop at Harold Washington Library.");
                    }
                    else if (train.CurrentStation == "Adams/Wabash" && train.Direction == TrackDirection.Inbound)
                    {
                        // 🚆 Train completes The Loop and switches to Outbound
                        Debug.WriteLine($"🚆 {train.Name} has exited The Loop at Adams/Wabash and is switching to Outbound.");
                        train.Direction = TrackDirection.Outbound;
                    }
                    else
                    {
                        Debug.WriteLine($"➡ {train.Name} moved to {train.CurrentStation}");
                    }
                }
                else
                {
                    // Train reached end, loop back
                    if (train.Direction == TrackDirection.Inbound)
                    {
                        train.CurrentStation = TrackBlocks.First(t => t.Direction == TrackDirection.Outbound).StartStation;
                        train.Direction = TrackDirection.Outbound;
                        Debug.WriteLine($"🔄 {train.Name} reversed direction and is now outbound at {train.CurrentStation}");
                    }
                    else
                    {
                        train.CurrentStation = TrackBlocks.First(t => t.Direction == TrackDirection.Inbound).StartStation;
                        train.Direction = TrackDirection.Inbound;
                        Debug.WriteLine($"🔄 {train.Name} reversed direction and is now inbound at {train.CurrentStation}");
                    }
                }
            }
        }


        private void MoveTrainsPink(object sender, EventArgs e)
        {
            foreach (var train in Trains)
            {
                Debug.WriteLine($"🚆 {train.Name} is at {train.CurrentStation}");

                var currentTrack = TrackBlocks.FirstOrDefault(t =>
                    t.StartStation == train.CurrentStation &&
                    t.Direction == train.Direction);

                if (currentTrack != null)
                {
                    train.CurrentStation = currentTrack.EndStation;

                    // 🚆 Special Handling for The Loop
                    if (train.CurrentStation == "Clark/Lake" && train.Direction == TrackDirection.Inbound)
                    {
                        Debug.WriteLine($"🔄 {train.Name} has entered The Loop at Clark/Lake.");
                    }
                    else if (train.CurrentStation == "Washington/Wells" && train.Direction == TrackDirection.Inbound)
                    {
                        // 🚆 Train completes The Loop and switches to Outbound
                        Debug.WriteLine($"🚆 {train.Name} has exited The Loop at Washington/Wells and is switching to Outbound.");
                        train.Direction = TrackDirection.Outbound;
                    }
                    else
                    {
                        Debug.WriteLine($"➡ {train.Name} moved to {train.CurrentStation}");
                    }
                }
                else
                {
                    // Train reached the end, loop back
                    if (train.Direction == TrackDirection.Inbound)
                    {
                        train.CurrentStation = TrackBlocks.First(t => t.Direction == TrackDirection.Outbound).StartStation;
                        train.Direction = TrackDirection.Outbound;
                        Debug.WriteLine($"🔄 {train.Name} reversed direction and is now outbound at {train.CurrentStation}");
                    }
                    else
                    {
                        train.CurrentStation = TrackBlocks.First(t => t.Direction == TrackDirection.Inbound).StartStation;
                        train.Direction = TrackDirection.Inbound;
                        Debug.WriteLine($"🔄 {train.Name} reversed direction and is now inbound at {train.CurrentStation}");
                    }
                }
            }
        }


        private void MoveTrainsYellow(object sender, EventArgs e)
        {
            foreach (var train in Trains)
            {
                Debug.WriteLine($"🚆 {train.Name} is at {train.CurrentStation}");

                // Find the correct track based on the train's direction
                var currentTrack = TrackBlocks.FirstOrDefault(t =>
                    t.StartStation == train.CurrentStation &&
                    (train.Direction == TrackDirection.Inbound ? t.Direction == TrackDirection.Inbound : t.Direction == TrackDirection.Outbound)
                );

                if (currentTrack != null)
                {
                    train.CurrentStation = currentTrack.EndStation;
                    Debug.WriteLine($"➡ {train.Name} moved to {train.CurrentStation}");
                }
                else
                {
                    // Train reached end of the route, loop it back
                    var resetTrack = TrackBlocks.FirstOrDefault(t => t.Direction == (train.Direction == TrackDirection.Inbound ? TrackDirection.Outbound : TrackDirection.Inbound));
                    if (resetTrack != null)
                    {
                        train.CurrentStation = resetTrack.StartStation;
                        train.Direction = train.Direction == TrackDirection.Inbound ? TrackDirection.Outbound : TrackDirection.Inbound;
                        Debug.WriteLine($"🔄 {train.Name} reversed direction and is now at {train.CurrentStation}");
                    }
                }
            }
        }

        private void LoadTracks()
        {
            // Green Line (Inbound toward The Loop)
            TrackBlocks.Add(new TrackBlock("Harlem/Lake", "Oak Park", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Oak Park", "Ridgeland", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Ridgeland", "Austin", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Austin", "Central", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Central", "Laramie", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Laramie", "Cicero", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Cicero", "Pulaski", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Pulaski", "Conservatory-Central Park", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Conservatory-Central Park", "Kedzie", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Kedzie", "California", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("California", "Damen", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Damen", "Ashland", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Ashland", "Morgan", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Morgan", "Clinton", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Clinton", "Clark/Lake", TrackDirection.Inbound, true)); // Entry into The Loop

            // The Loop (Green Line - Pass Through)
            TrackBlocks.Add(new TrackBlock("Clark/Lake", "State/Lake", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("State/Lake", "Washington/Wabash", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Washington/Wabash", "Adams/Wabash", TrackDirection.Inbound, true)); // Exit from The Loop
            TrackBlocks.Add(new TrackBlock("Adams/Wabash", "Roosevelt", TrackDirection.Inbound, true)); // Exit from The Loop

            // Green Line (Outbound returning to Harlem/Lake)
            TrackBlocks.Add(new TrackBlock("Roosevelt", "Cermak/McCormick Place", TrackDirection.Outbound, true));
            TrackBlocks.Add(new TrackBlock("Cermak/McCormick Place", "35th/Bronzeville/IIT", TrackDirection.Outbound, true));
            TrackBlocks.Add(new TrackBlock("35th/Bronzeville/IIT", "Indiana", TrackDirection.Outbound, true));
            TrackBlocks.Add(new TrackBlock("Indiana", "43rd", TrackDirection.Outbound, true));
            TrackBlocks.Add(new TrackBlock("43rd", "47th", TrackDirection.Outbound, true));
            TrackBlocks.Add(new TrackBlock("47th", "51st", TrackDirection.Outbound, true));
            TrackBlocks.Add(new TrackBlock("51st", "Garfield", TrackDirection.Outbound, true));
            TrackBlocks.Add(new TrackBlock("Garfield", "Halsted", TrackDirection.Outbound, true));
            TrackBlocks.Add(new TrackBlock("Halsted", "Ashland/63rd", TrackDirection.Outbound, true));

            // Green Line (Inbound returning to Harlem/Lake)
            TrackBlocks.Add(new TrackBlock("Ashland/63rd", "Halsted", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Halsted", "Garfield", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Garfield", "51st", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("51st", "47th", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("47th", "43rd", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("43rd", "Indiana", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Indiana", "35th/Bronzeville/IIT", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("35th/Bronzeville/IIT", "Cermak/McCormick Place", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Cermak/McCormick Place", "Roosevelt", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Roosevelt", "Adams/Wabash", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Adams/Wabash", "State/Lake", TrackDirection.Outbound, true));
            TrackBlocks.Add(new TrackBlock("State/Lake", "Clark/Lake", TrackDirection.Outbound, true)); // Entry back through The Loop
            TrackBlocks.Add(new TrackBlock("Clark/Lake", "Clinton", TrackDirection.Outbound, true));
            TrackBlocks.Add(new TrackBlock("Clinton", "Ashland", TrackDirection.Outbound, true));
            TrackBlocks.Add(new TrackBlock("Ashland", "California", TrackDirection.Outbound, true));
            TrackBlocks.Add(new TrackBlock("California", "Kedzie", TrackDirection.Outbound, true));
            TrackBlocks.Add(new TrackBlock("Kedzie", "Conservatory-Central Park", TrackDirection.Outbound, true));
            TrackBlocks.Add(new TrackBlock("Conservatory-Central Park", "Pulaski", TrackDirection.Outbound, true));
            TrackBlocks.Add(new TrackBlock("Pulaski", "Cicero", TrackDirection.Outbound, true));
            TrackBlocks.Add(new TrackBlock("Cicero", "Laramie", TrackDirection.Outbound, true));
            TrackBlocks.Add(new TrackBlock("Laramie", "Central", TrackDirection.Outbound, true));
            TrackBlocks.Add(new TrackBlock("Central", "Austin", TrackDirection.Outbound, true));
            TrackBlocks.Add(new TrackBlock("Austin", "Ridgeland", TrackDirection.Outbound, true));
            TrackBlocks.Add(new TrackBlock("Ridgeland", "Oak Park", TrackDirection.Outbound, true));
            TrackBlocks.Add(new TrackBlock("Oak Park", "Harlem/Lake", TrackDirection.Outbound, true)); // Final stop, loops back
        }





        private void LoadTracksPurple()
        {
            // Purple Line Express (Inbound toward The Loop)
            TrackBlocks.Add(new TrackBlock("Linden", "Central", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Central", "Noyes", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Noyes", "Foster", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Foster", "Davis", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Davis", "Dempster", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Dempster", "Main", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Main", "South Blvd", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("South Blvd", "Howard", TrackDirection.Inbound, true)); // Transfer to Red Line
            TrackBlocks.Add(new TrackBlock("South Blvd", "Howard", TrackDirection.Inbound, true)); // Transfer to Red Line
            TrackBlocks.Add(new TrackBlock("Howard", "Belmont", TrackDirection.Inbound, true)); // Express to Loop
            TrackBlocks.Add(new TrackBlock("Belmont", "Fullerton", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Fullerton", "Clark/Lake", TrackDirection.Inbound, true)); // Entry into The Loop

            // The Loop (Purple Line Express - Clockwise)
            TrackBlocks.Add(new TrackBlock("Clark/Lake", "State/Lake", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("State/Lake", "Washington/Wabash", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Washington/Wabash", "Adams/Wabash", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Adams/Wabash", "Harold Washington Library", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Harold Washington Library", "LaSalle/Van Buren", TrackDirection.Inbound, true)); // Exit from The Loop
            TrackBlocks.Add(new TrackBlock("LaSalle/Van Buren", "Quincy", TrackDirection.Inbound, true)); // Exit from The Loop
            TrackBlocks.Add(new TrackBlock("Quincy", "Washington/Wells", TrackDirection.Inbound, true)); // Exit from The Loop

            // Purple Line Express (Outbound returning to Linden)
            TrackBlocks.Add(new TrackBlock("Washington/Wells", "Fullerton", TrackDirection.Outbound, true));
            TrackBlocks.Add(new TrackBlock("Fullerton", "Belmont", TrackDirection.Outbound, true));
            TrackBlocks.Add(new TrackBlock("Belmont", "Howard", TrackDirection.Outbound, true)); // Express to Howard
            TrackBlocks.Add(new TrackBlock("Howard", "South Blvd", TrackDirection.Outbound, true));
            TrackBlocks.Add(new TrackBlock("South Blvd", "Main", TrackDirection.Outbound, true));
            TrackBlocks.Add(new TrackBlock("Main", "Dempster", TrackDirection.Outbound, true));
            TrackBlocks.Add(new TrackBlock("Dempster", "Davis", TrackDirection.Outbound, true));
            TrackBlocks.Add(new TrackBlock("Davis", "Foster", TrackDirection.Outbound, true));
            TrackBlocks.Add(new TrackBlock("Foster", "Noyes", TrackDirection.Outbound, true));
            TrackBlocks.Add(new TrackBlock("Noyes", "Central", TrackDirection.Outbound, true));
            TrackBlocks.Add(new TrackBlock("Central", "Linden", TrackDirection.Outbound, true)); // Final stop, loops back
        }


        private void LoadTracksBrown()
        {
            // Brown Line (Inbound toward The Loop)
            TrackBlocks.Add(new TrackBlock("Kimball", "Kedzie", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Kedzie", "Francisco", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Francisco", "Rockwell", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Rockwell", "Western", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Western", "Damen", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Damen", "Montrose", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Montrose", "Irving Park", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Irving Park", "Addison", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Addison", "Paulina", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Paulina", "Southport", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Southport", "Belmont", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Belmont", "Wellington", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Wellington", "Diversey", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Diversey", "Fullerton", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Fullerton", "Armitage", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Armitage", "Sedgwick", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Sedgwick", "Chicago", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Chicago", "Merchandise Mart", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Merchandise Mart", "Washington/Wells", TrackDirection.Inbound, true)); // Entry into The Loop

            // The Loop (Brown Line Counterclockwise)
            TrackBlocks.Add(new TrackBlock("Washington/Wells", "Quincy", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Quincy", "LaSalle/Van Buren", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("LaSalle/Van Buren", "Harold Washington Library-State/Van Buren", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Harold Washington Library-State/Van Buren", "Adams/Wabash", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Adams/Wabash", "Washington/Wabash", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Washington/Wabash", "State/Lake", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("State/Lake", "Clark/Lake", TrackDirection.Inbound, true)); // Exit from The Loop

            // Brown Line (Outbound returning to Kimball)
            TrackBlocks.Add(new TrackBlock("Clark/Lake", "Merchandise Mart", TrackDirection.Outbound, true));
            TrackBlocks.Add(new TrackBlock("Merchandise Mart", "Chicago", TrackDirection.Outbound, true));
            TrackBlocks.Add(new TrackBlock("Chicago", "Sedgwick", TrackDirection.Outbound, true));
            TrackBlocks.Add(new TrackBlock("Sedgwick", "Armitage", TrackDirection.Outbound, true));
            TrackBlocks.Add(new TrackBlock("Armitage", "Fullerton", TrackDirection.Outbound, true));
            TrackBlocks.Add(new TrackBlock("Fullerton", "Diversey", TrackDirection.Outbound, true));
            TrackBlocks.Add(new TrackBlock("Diversey", "Wellington", TrackDirection.Outbound, true));
            TrackBlocks.Add(new TrackBlock("Wellington", "Belmont", TrackDirection.Outbound, true));
            TrackBlocks.Add(new TrackBlock("Belmont", "Southport", TrackDirection.Outbound, true));
            TrackBlocks.Add(new TrackBlock("Southport", "Paulina", TrackDirection.Outbound, true));
            TrackBlocks.Add(new TrackBlock("Paulina", "Addison", TrackDirection.Outbound, true));
            TrackBlocks.Add(new TrackBlock("Addison", "Irving Park", TrackDirection.Outbound, true));
            TrackBlocks.Add(new TrackBlock("Irving Park", "Montrose", TrackDirection.Outbound, true));
            TrackBlocks.Add(new TrackBlock("Montrose", "Damen", TrackDirection.Outbound, true));
            TrackBlocks.Add(new TrackBlock("Damen", "Western", TrackDirection.Outbound, true));
            TrackBlocks.Add(new TrackBlock("Western", "Rockwell", TrackDirection.Outbound, true));
            TrackBlocks.Add(new TrackBlock("Rockwell", "Francisco", TrackDirection.Outbound, true));
            TrackBlocks.Add(new TrackBlock("Francisco", "Kedzie", TrackDirection.Outbound, true));
            TrackBlocks.Add(new TrackBlock("Kedzie", "Kimball", TrackDirection.Outbound, true)); // Final stop, loops back
        }


        private void LoadTracksOrange()
        {
            // Orange Line (Inbound toward The Loop)
            TrackBlocks.Add(new TrackBlock("Midway", "Pulaski", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Pulaski", "Kedzie", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Kedzie", "Western", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Western", "35th/Archer", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("35th/Archer", "Ashland", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Ashland", "Halsted", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Halsted", "Roosevelt", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Roosevelt", "Harold Washington Library", TrackDirection.Inbound, true)); // Entry into The Loop

            // The Loop (Orange Line)
            TrackBlocks.Add(new TrackBlock("Harold Washington Library", "LaSalle/Van Buren", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("LaSalle/Van Buren", "Adams/Wabash", TrackDirection.Inbound, true)); // Exit from The Loop

            // Orange Line (Outbound returning to Midway)
            TrackBlocks.Add(new TrackBlock("Adams/Wabash", "Roosevelt", TrackDirection.Outbound, true));
            TrackBlocks.Add(new TrackBlock("Roosevelt", "Halsted", TrackDirection.Outbound, true));
            TrackBlocks.Add(new TrackBlock("Halsted", "Ashland", TrackDirection.Outbound, true));
            TrackBlocks.Add(new TrackBlock("Ashland", "35th/Archer", TrackDirection.Outbound, true));
            TrackBlocks.Add(new TrackBlock("35th/Archer", "Western", TrackDirection.Outbound, true));
            TrackBlocks.Add(new TrackBlock("Western", "Kedzie", TrackDirection.Outbound, true));
            TrackBlocks.Add(new TrackBlock("Kedzie", "Pulaski", TrackDirection.Outbound, true));
            TrackBlocks.Add(new TrackBlock("Pulaski", "Midway", TrackDirection.Outbound, true)); // Final stop, loops back
        }


        private void LoadTracksPink()
        {
            // Pink Line (Inbound toward The Loop)
            TrackBlocks.Add(new TrackBlock("54th/Cermak", "Cicero", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Cicero", "Kostner", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Kostner", "Pulaski", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Pulaski", "Central Park", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Central Park", "Kedzie", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Kedzie", "Western", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Western", "Damen", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Damen", "18th", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("18th", "Polk", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Polk", "Ashland", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Ashland", "Morgan", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Morgan", "Clinton", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Clinton", "Clark/Lake", TrackDirection.Inbound, true)); // Entry into The Loop

            // The Loop (Single track for Pink Line)
            TrackBlocks.Add(new TrackBlock("Clark/Lake", "State/Lake", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("State/Lake", "Adams/Wabash", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Adams/Wabash", "Harold Washington Library", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Harold Washington Library", "Washington/Wells", TrackDirection.Inbound, true)); // Exit from The Loop

            // Pink Line (Outbound returning to 54th/Cermak)
            TrackBlocks.Add(new TrackBlock("Washington/Wells", "Clinton", TrackDirection.Outbound, true));
            TrackBlocks.Add(new TrackBlock("Clinton", "Morgan", TrackDirection.Outbound, true));
            TrackBlocks.Add(new TrackBlock("Morgan", "Ashland", TrackDirection.Outbound, true));
            TrackBlocks.Add(new TrackBlock("Ashland", "Polk", TrackDirection.Outbound, true));
            TrackBlocks.Add(new TrackBlock("Polk", "18th", TrackDirection.Outbound, true));
            TrackBlocks.Add(new TrackBlock("18th", "Damen", TrackDirection.Outbound, true));
            TrackBlocks.Add(new TrackBlock("Damen", "Western", TrackDirection.Outbound, true));
            TrackBlocks.Add(new TrackBlock("Western", "Kedzie", TrackDirection.Outbound, true));
            TrackBlocks.Add(new TrackBlock("Kedzie", "Central Park", TrackDirection.Outbound, true));
            TrackBlocks.Add(new TrackBlock("Central Park", "Pulaski", TrackDirection.Outbound, true));
            TrackBlocks.Add(new TrackBlock("Pulaski", "Kostner", TrackDirection.Outbound, true));
            TrackBlocks.Add(new TrackBlock("Kostner", "Cicero", TrackDirection.Outbound, true));
            TrackBlocks.Add(new TrackBlock("Cicero", "54th/Cermak", TrackDirection.Outbound, true)); // Final stop, loops back
        }


        private void LoadTracksYellow()
        {
            // Example Yellow Line (Skokie Swift) with Inbound and Outbound tracks
            TrackBlocks.Add(new TrackBlock("Dempster-Skokie", "Oakton-Skokie", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Oakton-Skokie", "Howard", TrackDirection.Inbound, true));

            TrackBlocks.Add(new TrackBlock("Howard", "Oakton-Skokie", TrackDirection.Outbound, true));
            TrackBlocks.Add(new TrackBlock("Oakton-Skokie", "Dempster-Skokie", TrackDirection.Outbound, true));
        }

        private void LoadTrains()
        {
            //Trains.Add(new Train("Train 101", "Dempster-Skokie", TrackDirection.Inbound));
            //Trains.Add(new Train("Train 202", "Howard", TrackDirection.Outbound));
            //Trains.Add(new Train("Train 303", "Oakton-Skokie", TrackDirection.Inbound));
            //Trains.Add(new Train("Train 404", "Oakton-Skokie", TrackDirection.Outbound));
            //Trains.Add(new Train("Pink Line Train 501", "54th/Cermak", TrackDirection.Inbound));
            //Trains.Add(new Train("Orange Line Train 601", "Midway", TrackDirection.Inbound));
            //Trains.Add(new Train("Brown Line Train 701", "Kimball", TrackDirection.Inbound));        
            //Trains.Add(new Train("Purple Line Express 801", "Linden", TrackDirection.Inbound));
            Trains.Add(new Train("Green Line Train 901", "Harlem/Lake", TrackDirection.Inbound));
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }



    public class Train : INotifyPropertyChanged
    {
        public string Name { get; set; }

        private string _currentStation;
        public string CurrentStation
        {
            get => _currentStation;
            set
            {
                if (_currentStation != value)
                {
                    _currentStation = value;
                    OnPropertyChanged(nameof(CurrentStation));
                }
            }
        }

        private TrackDirection _direction;
        public TrackDirection Direction
        {
            get => _direction;
            set
            {
                if (_direction != value)
                {
                    _direction = value;
                    OnPropertyChanged(nameof(Direction));
                }
            }
        }

        public Train(string name, string station, TrackDirection direction)
        {
            Name = name;
            _currentStation = station;
            _direction = direction;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class TrackBlock : INotifyPropertyChanged
    {
        public string StartStation { get; set; }
        public string EndStation { get; set; }
        public TrackDirection Direction { get; set; }

        private bool _isAvailable;
        public bool IsAvailable
        {
            get => _isAvailable;
            set
            {
                if (_isAvailable != value)
                {
                    _isAvailable = value;
                    OnPropertyChanged(nameof(IsAvailable));
                }
            }
        }

        public TrackBlock(string start, string end, TrackDirection direction, bool available)
        {
            StartStation = start;
            EndStation = end;
            Direction = direction;
            _isAvailable = available;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
