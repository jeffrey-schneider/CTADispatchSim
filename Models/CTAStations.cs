using System.Collections.Generic;

namespace CTADispatchSim.Models
{
    public static class CTAStations
    {
        public static Dictionary<string, List<string>> LineStations = new Dictionary<string, List<string>>
        {
            ["Green"] = new List<string>
            {
                "Harlem/Lake", "Oak Park", "Ridgeland", "Austin", "Central",
                "Laramie", "Cicero", "Pulaski", "Conservatory-Central Park", "Kedzie",
                "California", "Damen", "Ashland", "Morgan", "Clinton", "Clark/Lake",
                "State/Lake", "Washington/Wabash", "Adams/Wabash", "Roosevelt",
                "Cermak/McCormick Place", "35th/Bronzeville/IIT", "Indiana", "43rd",
                "47th", "51st", "Garfield", "Halsted", "Ashland/63rd"
            },

            ["Pink"] = new List<string>
            {
                "54th/Cermak", "Cicero", "Kostner", "Pulaski", "Central Park",
                "Kedzie", "California", "Western", "Damen", "18th", "Polk",
                "Ashland", "Morgan", "Clinton", "Clark/Lake", "State/Lake",
                "Washington/Wabash", "Adams/Wabash", "Harold Washington Library",
                "LaSalle/Van Buren", "Quincy", "Washington/Wells"
            },

            ["Orange"] = new List<string>
            {
                "Midway", "Pulaski", "Kedzie", "Western", "35th/Archer",
                "Ashland", "Halsted", "Roosevelt", "Harold Washington Library",
                "LaSalle/Van Buren", "Quincy", "Washington/Wells", "Clark/Lake",
                "State/Lake", "Washington/Wabash", "Adams/Wabash"
            },

            ["Brown"] = new List<string>
            {
                "Kimball", "Kedzie", "Francisco", "Rockwell", "Western",
                "Damen", "Montrose", "Irving Park", "Addison", "Paulina",
                "Southport", "Belmont", "Wellington", "Diversey", "Fullerton",
                "Armitage", "Sedgwick", "Chicago", "Merchandise Mart",
                "Washington/Wells", "Quincy", "LaSalle/Van Buren",
                "Harold Washington Library", "Adams/Wabash", "Washington/Wabash",
                "State/Lake", "Clark/Lake"
            },

            ["Purple"] = new List<string>
            {
                "Linden", "Central", "Noyes", "Foster", "Davis", "Dempster",
                "Main", "South Blvd", "Howard", "Jarvis", "Morse", "Loyola",
                "Granville", "Thorndale", "Bryn Mawr", "Berwyn", "Argyle",
                "Lawrence", "Wilson", "Sheridan", "Addison", "Belmont",
                "Wellington", "Diversey", "Fullerton", "Armitage",
                "Sedgwick", "Chicago", "Merchandise Mart", "Clark/Lake",
                "State/Lake", "Washington/Wabash", "Adams/Wabash",
                "Washington/Wells"
            },

            ["Yellow"] = new List<string>
            {
                "Dempster/Skokie", "Oakton/Skokie","Howard"
            },

            ["Red"] = new List<string>
{
    "Howard", "Jarvis", "Morse", "Loyola", "Granville", "Thorndale", "Bryn Mawr",
    "Berwyn", "Argyle", "Lawrence", "Wilson", "Sheridan", "Addison", "Belmont",
    "Fullerton", "North/Clybourn", "Clark/Division", "Chicago", "Grand",
    "Lake", "Monroe", "Jackson", "Harrison", "Roosevelt", "Cermak–Chinatown",
    "Sox–35th", "47th", "Garfield", "63rd", "69th", "79th", "87th", "95th/Dan Ryan"
},
            ["Blue"] = new List<string>
{
    "O'Hare", "Rosemont", "Cumberland", "Harlem (O'Hare Branch)", "Jefferson Park",
    "Montrose", "Irving Park", "Addison", "Belmont", "Logan Square", "California",
    "Western", "Damen", "Division", "Chicago", "Grand", "Clark/Lake",
    "Washington", "Monroe", "Jackson", "LaSalle", "Clinton", "UIC-Halsted",
    "Racine", "Illinois Medical District", "Western (Forest Park Branch)",
    "Kedzie-Homan", "Pulaski", "Cicero", "Austin", "Oak Park", "Harlem (Forest Park Branch)",
    "Forest Park"
}
        };
    }
}
