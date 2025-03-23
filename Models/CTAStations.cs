using System.Collections.Generic;

namespace CTADispatchSim.Models
{
    public static class CTAStations
    {
        public static Dictionary<string, List<(string Station, double Distance)>> LineStations = new()
        {
            ["Yellow"] = new List<(string, double)>
            {
                ("Howard", 2.1),
                ("Oakton/Skokie", 1.7),
                ("Dempster/Skokie", 1.9),
                ("Change Tracks (Dempster/Skokie)", 0.1),  // ✅ Track switch before return
                ("Dempster/Skokie", 1.9),
                ("Oakton/Skokie", 1.7),
                ("Howard", 2.1),
                ("Change Tracks (Howard)", 0.1)  // ✅ Track switch before restarting route
            },
            ["Red"] = new List<(string, double)>
            {
                ("Howard", 1.2), ("Jarvis", 0.8), ("Morse", 0.9), ("Loyola", 1.1),
                ("Granville", 0.7), ("Thorndale", 0.5), ("Bryn Mawr", 0.6), ("Berwyn", 0.6),
                ("Argyle", 0.7), ("Lawrence", 0.5), ("Wilson", 1.2), ("Sheridan", 0.8),
                ("Addison", 1.1), ("Belmont", 0.9), ("Fullerton", 1.3), ("North/Clybourn", 1.6),
                ("Clark/Division", 0.9), ("Chicago", 0.8), ("Grand", 0.7), ("Lake", 0.6),
                ("Monroe", 0.7), ("Jackson", 0.5), ("Harrison", 0.7), ("Roosevelt", 1.2),
                ("Cermak-Chinatown", 1.3), ("Sox-35th", 1.7), ("47th", 2.2), ("Garfield", 1.9),
                ("63rd", 1.7), ("69th", 1.5), ("79th", 1.6), ("87th", 1.4),
                ("95th/Dan Ryan", 0.0), ("Change Tracks (95th/Dan Ryan)", 0.1),  // ✅ Track switch before return
                ("87th", 1.4), ("79th", 1.6), ("69th", 1.5), ("63rd", 1.7),
                ("Garfield", 1.9), ("47th", 2.2), ("Sox-35th", 1.7), ("Cermak-Chinatown", 1.3),
                ("Roosevelt", 1.2), ("Harrison", 0.7), ("Jackson", 0.5), ("Monroe", 0.7),
                ("Lake", 0.6), ("Grand", 0.7), ("Chicago", 0.8), ("Clark/Division", 0.9),
                ("North/Clybourn", 1.6), ("Fullerton", 1.3), ("Belmont", 0.9),
                ("Addison", 1.1), ("Sheridan", 0.8), ("Wilson", 1.2), ("Lawrence", 0.5),
                ("Argyle", 0.7), ("Berwyn", 0.6), ("Bryn Mawr", 0.6), ("Thorndale", 0.5),
                ("Granville", 0.7), ("Loyola", 1.1), ("Morse", 0.9), ("Jarvis", 0.8),
                ("Howard", 1.2), ("Change Tracks (Howard)", 0.1)  // ✅ Track switch before restarting route
            },
            // 🔄 Other lines should follow this same format (Blue, Green, Pink, Orange, Brown, Purple)

            ["Blue"] = new List<(string Station, double Distance)>
            {
                ("O'Hare", 1.6), ("Rosemont", 1.5), ("Cumberland", 1.3), ("Harlem (O'Hare Branch)", 1.2),
                ("Jefferson Park", 2.1), ("Montrose", 1.0), ("Irving Park", 1.1), ("Addison", 1.2),
                ("Belmont", 1.1), ("Logan Square", 1.3), ("California", 0.7), ("Western", 0.9),
                ("Damen", 1.0), ("Division", 1.0), ("Chicago", 0.7), ("Grand", 0.8),
                ("Clark/Lake", 0.6), ("Washington", 0.5), ("Monroe", 0.6), ("Jackson", 0.5),
                ("LaSalle", 0.6), ("Clinton", 0.9), ("UIC-Halsted", 1.0), ("Racine", 0.8),
                ("Illinois Medical District", 0.9), ("Western (Forest Park Branch)", 1.2),
                ("Kedzie-Homan", 1.1), ("Pulaski", 1.4), ("Cicero", 1.3), ("Austin", 1.5),
                ("Oak Park", 1.3), ("Harlem (Forest Park Branch)", 1.4), ("Forest Park", 0.0),

                ("Change Tracks (Forest Park)", 0.1), // ✅ Track switch before return

                ("Forest Park", 0.0), ("Harlem (Forest Park Branch)", 1.4), ("Oak Park", 1.3),
                ("Austin", 1.5), ("Cicero", 1.3), ("Pulaski", 1.4), ("Kedzie-Homan", 1.1),
                ("Western (Forest Park Branch)", 1.2), ("Illinois Medical District", 0.9),
                ("Racine", 0.8), ("UIC-Halsted", 1.0), ("Clinton", 0.9), ("LaSalle", 0.6),
                ("Jackson", 0.5), ("Monroe", 0.6), ("Washington", 0.5), ("Clark/Lake", 0.6),
                ("Grand", 0.8), ("Chicago", 0.7), ("Division", 1.0), ("Damen", 1.0),
                ("Western", 0.9), ("California", 0.7), ("Logan Square", 1.3), ("Belmont", 1.1),
                ("Addison", 1.2), ("Irving Park", 1.1), ("Montrose", 1.0), ("Jefferson Park", 2.1),
                ("Harlem (O'Hare Branch)", 1.2), ("Cumberland", 1.3), ("Rosemont", 1.5),
                ("O'Hare", 0.0),

                ("Change Tracks (O'Hare)", 0.1) // ✅ Track switch before restarting route
            },


            ["Green"] = new List<(string Station, double Distance)>{
                 // West Branch (Outbound toward The Loop)
                 ("Harlem/Lake", 0.0), ("Oak Park", 1.0),
                 ("Ridgeland", 1.0), ("Austin", 1.0),
                 ("Central", 1.0), ("Laramie", 1.0),
                 ("Cicero", 1.0), ("Pulaski", 1.0),
                 ("Conservatory/Central Park Drive", 1.0), ("Kedzie", 1.0),
                 ("California", 1.0), ("Damen", 1.5),
                 ("Ashland", 1.0), ("Morgan", 1.0),
                 ("Clinton", 1.0),

                 // The Loop Section (Counterclockwise)
                 ("Clark/Lake", 1.0), ("State/Lake", 1.0),
                 ("Washington/​Wabash", 1.0),
                 ("Adams/Wabash", 1.0),

                 // Southbound Exit from The Loop
                 ("Roosevelt", 1.0), ("Cermak-McCormick Place", 1.0),
                 ("35th/Bronzeville/IIT", 1.0),
                 ("Indiana", 1.0), ("43rd", 1.0),
                 ("47th", 1.0), ("51st", 1.0), ("Garfield", 1.0),

                 // Split Branch 2: Ashland/63rd
                 ("Halsted", 1.0), ("Ashland/63rd", 1.0),

                 // 🛤 Change Tracks at Ashland/63rd (Train turns back)
                 ("Change Tracks", 0.0),

                 ("Halsted", 1.0), ("Garfield", 1.0),

                 // 🛤 Change Tracks at Garfield (Final merge point)
                 ("Change Tracks", 0.0), 

                 // Northbound (Returning to The Loop, then Harlem/Lake)
                 ("51st", 1.0), ("47th", 1.0),
                 ("43rd", 1.0), ("Indiana", 1.0),
                 ("35th/Bronzeville/IIT", 1.0),
                 ("Cermak-McCormick Place", 1.0),
                 ("Roosevelt", 1.0), 

                 // Enter The Loop (Counterclockwise)
                 ("Adams/Wabash", 1.0),
                 ("Washington/​Wabash", 1.0),
                 ("State/Lake", 1.0),
                 ("Clark/Lake", 1.0),
                 ("Clinton", 1.0),
                 ("Morgan", 1.0),
                 ("Ashland", 1.0),
                 ("Damen", 1.5),
                 ("California", 1.0),
                 ("Kedzie", 1.0),
                 ("Conservatory/Central Park Drive", 1.0),
                 ("Pulaski", 1.0),
                 ("Cicero", 1.0),
                 ("Laramie", 1.0),
                 ("Central", 1.0),
                 ("Austin", 1.0),
                 ("Ridgeland", 1.0), ("Oak Park", 1.0),
                 ("Harlem/Lake", 1.0)
            },

            ["Pink"] = new List<(string Station, double Distance)>
            {
                // 🚆 Pink Line - 54th/Cermak to The Loop
                ("54th/Cermak", 0.9), ("Cicero", 1.2), ("Kostner", 0.6), ("Pulaski", 1.1),
                ("Central Park", 0.8), ("Kedzie", 0.9), ("California", 0.7), ("Western", 1.0),
                ("Damen", 0.6), ("18th", 1.2), ("Polk", 0.9), ("Ashland", 1.0),
                ("Clinton", 0.8), ("Clark/Lake", 0.6),
            
                // 🚆 Pink Line enters The Loop (Clockwise)
                ("State/Lake", 0.5), ("Washington/Wabash", 0.4), ("Adams/Wabash", 0.6),
                ("Harold Washington Library", 0.7), ("LaSalle/Van Buren", 0.5), ("Quincy", 0.6),
                ("Washington/Wells", 0.7),
            
                // 🚆 Exiting The Loop - Return via original route
                ("Clinton", 0.8), ("Morgan", 0.7), ("Ashland", 1.0), ("Polk", 0.9),
                ("18th", 1.2), ("Damen", 0.6), ("Western", 1.0), ("California", 0.7),
                ("Kedzie", 0.9), ("Central Park", 0.8), ("Pulaski", 1.1), ("Kostner", 0.6),
                ("Cicero", 1.2), ("54th/Cermak", 0.9),

                ("Change Tracks (54th/Cermak)", 0.1) // ✅ Track switch before restarting route
            },

            ["Orange"] = new List<(string Station, double Distance)>
            {
                ("Midway", 0.0),
                ("Pulaski", 1.0),
                ("Kedzie", 1.0),
                ("Western", 1.0),
                ("35th/Archer", 1.0),
                ("Ashland", 1.0),
                ("Halsted", 1.0),
                ("Roosevelt", 1.0),
                
                // Enters The Loop (Clockwise)
                ("Harold Washington Library", 1.0),
                ("LaSalle/Van Buren", 1.0),
                ("Quincy", 1.0),
                ("Washington/Wells", 1.0),
                ("Clark/Lake", 1.0),
                ("State/Lake", 1.0),
                ("Washington/Wabash", 1.0),
                ("Adams/Wabash", 1.0),

                
                // 🛤 Change Tracks after completing The Loop
                
                
                // Return trip back to Midway
                ("Roosevelt", 1.0),
                ("Halsted", 1.0),
                ("Ashland", 1.0),
                ("35th/Archer", 1.0),
                ("Western", 1.0),
                ("Kedzie", 1.0),
                ("Pulaski", 1.0),
                ("Midway", 1.0),
                
                // 🛤 Change Tracks at Midway (to begin next outbound loop)
                ("Change Tracks", 0.0)
            },


            ["Brown"] = new List<(string Station, double Distance)>
{
                ("Kimball", 0.0),
                ("Kedzie", 1.0),
                ("Francisco", 1.0),
                ("Rockwell", 1.0),
                ("Western", 1.0),
                ("Damen", 1.0),
                ("Montrose", 1.0),
                ("Irving Park", 1.0),
                ("Addison", 1.0),
                ("Paulina", 1.0),
                ("Southport", 1.0),
                ("Belmont", 1.0),
                ("Wellington", 1.0),
                ("Diversey", 1.0),
                ("Fullerton", 1.0),
                ("Armitage", 1.0),
                ("Sedgwick", 1.0),
                ("Chicago", 1.0),
                ("Merchandise Mart", 1.0),

                // Enters The Loop (Counterclockwise)
                ("Washington/Wells", 1.0),
                ("Quincy", 1.0),
                ("LaSalle/Van Buren", 1.0),
                ("Harold Washington Library", 1.0),
                ("Adams/Wabash", 1.0),
                ("Washington/Wabash", 1.0),
                ("State/Lake", 1.0),
                ("Clark/Lake", 1.0),

                                // Return trip northbound (reverse order)
                ("Merchandise Mart", 1.0),
                ("Chicago", 1.0),
                ("Sedgwick", 1.0),
                ("Armitage", 1.0),
                ("Fullerton", 1.0),
                ("Diversey", 1.0),
                ("Wellington", 1.0),
                ("Belmont", 1.0),
                ("Southport", 1.0),
                ("Paulina", 1.0),
                ("Addison", 1.0),
                ("Irving Park", 1.0),
                ("Montrose", 1.0),
                ("Damen", 1.0),
                ("Western", 1.0),
                ("Rockwell", 1.0),
                ("Francisco", 1.0),
                ("Kedzie", 1.0),
                ("Kimball", 1.0),
                // 🛤 Change Tracks at Kimball (to begin next Loop)
                ("Change Tracks", 0.0)
            },

            ["Purple"] = new List<(string Station, double Distance)>
        {
            ("Linden", 0.0),
            ("Central", 1.0),
            ("Noyes", 1.0),
            ("Foster", 1.0),
            ("Davis", 1.0),
            ("Dempster", 1.0),
            ("Main", 1.0),
            ("South Boulevard", 1.0),
            ("Howard", 1.0),
        
            // Express segment - shares Red Line track south of Howard
            ("Wilson", 4.3),
            ("Belmont", 1.0),
            ("Wellington", 1.0),
            ("Diversey", 1.0),
            ("Fullerton", 1.0),
            ("Armitage", 1.0),
            ("Sedgwick", 1.0),
            ("Chicago", 1.0),
            ("Merchandise Mart", 1.0),
        
            // Enters The Loop (Clockwise, same as Brown)
            ("Clark/Lake", 1.0),
            ("State/Lake", 1.0),
            ("Washington/Wabash", 1.0),
            ("Adams/Wabash", 1.0),
            ("Harold Washington Library", 1.0),
            ("LaSalle/Van Buren", 1.0),
            ("Quincy", 1.0),
            ("Washington/Wells", 1.0),
        
            // Return trip northbound
            ("Merchandise Mart", 1.0),
            ("Chicago", 1.0),
            ("Sedgwick", 1.0),
            ("Armitage", 1.0),
            ("Fullerton", 1.0),
            ("Diversey", 1.0),
            ("Wellington", 1.0),
            ("Belmont", 1.0),
            ("Wilson", 1.0),
            ("Howard", 4.3),
            ("South Boulevard", 1.0),
            ("Main", 1.0),
            ("Dempster", 1.0),
            ("Davis", 1.0),
            ("Foster", 1.0),
            ("Noyes", 1.0),
            ("Central", 1.0),
            ("Linden", 1.0),        
            // 🛤 Change Tracks at Linden
            ("Change Tracks", 0.0)
        },
        };

    }
}

