using System.Collections.Generic;

namespace CTADispatchSim.Models
{
    public static class CTAStations
    {
        public static Dictionary<string, List<string>> LineStations = new Dictionary<string, List<string>>
        {
            //Pink, Orange, Brown and Purple contain a loop segment, they loop the loop.
            ["Pink"] = new List<string>
            {
                "54th/Cermak","Cicero","Kostner","Pulaski","Central Park","Kedzie","California",
"Western","Damen","18th","Polk","Ashland","Morgan","Clinton","Clark/Lake","State/Lake",
"Washington/Wabash","Adams/Wabash","Harold Washington Library","Quincy","Washington/Wells",
"Clinton","Morgan","Ashland","Polk","18th","Damen","Western","California","Kedzie","Central Park",
"Pulaski","Kostner","Cicero","54th/Cermak"
            },

            ["Orange"] = new List<string>
            {
                "Midway","Pulaski","Kedzie","Western","35th/Archer","Ashland","Halsted","Roosevelt",
"Harold Washington Library","LaSalle/Van Buren","Quincy","Washington/Wells","Clark/Lake",
"State/Lake","Washington/Wabash","Adams/Wabash","Roosevelt","Halsted","Ashland",
"35th/Archer","Western","Kedzie","Pulaski","Midway"
            },

            ["Brown"] = new List<string>
            {
              "Kimball","Kedzie","Francisco","Rockwell","Western","Damen","Montrose","Irving Park",
"Addison","Paulina","Southport","Belmont","Wellington","Diversey","Fullerton","Armitage",
"Sedgwick","Chicago","Merchandise Mart","Washington/Wells","Quincy","LaSalle/Van Buren",
"Harold Washington Library","Adams/Wabash","Washington/Wabash","State/Lake","Clark/Lake",
"Merchandise Mart","Chicago","Sedgwick","Armitage","Fullerton","Diversey","Wellington","Belmont","Southport",
"Paulina","Addison","Irving Park","Montrose","Damen","Western","Rockwell","Francisco",
"Kedzie","Kimball"
            },

            ["Purple"] = new List<string>
            {
                "Linden","Central","Noyes","Foster","Davis","Dempster","Evanston Main Street","South Boulevard",
"Howard","Wilson","Belmont","Wellington","Diversey","Fullerton","Armitage","Sedgewick","Chicago",
"Merchandise Mart","Clark/Lake","State/Lake","Washington/Wabash","Adams/Wabash",
"Harold Washington Library","LaSalle/Van Buren","Quincy","Washington/Wells","Merchandise Mart",
"Chicago","Sedgewick","Armitage","Fullerton","Diversey","Wellington","Belmont","Wilson","Howard",
"South Boulevard","Evanston Main Street","Dempster","Davis","Foster","Noyes","Central","Linden"
            },


            //Green, Yellow, Red, Blue go into the loop but do not loop the loop.
            ["Green"] = new List<string>
            {"Harlem/Lake","Oak Park","Ridgeland","Austin","Central","Cicero","Pulaski",
"Conservatory-Central Park Drive","Kedzie","California","Damen","Ashland","Morgan",
"Clinton","Clark/Lake","State/Lake","Washington/Wabash","Adams/Wabash","Roosevelt",
"Cermak-McCormick Place","35th-Bronzeville-IIT","Indiana","43rd","47th","51st","Garfield",
"Halsted","Ashland/63rd","Halsted","Garfield","51st","47th","43rd","Indiana","35th-Bronzeville-IIT",
"Cermak-McCormick Place","Roosevelt","Adams/Wabash","Washington/Wabash","State/Lake","Clark/Lake",
"Clinton","Morgan","Ashland","Damen","California","Kedzie","Conservatory-Central Park Drive",
"Pulaski","Cicero","Central","Austin","Ridgeland","Oak Park","Harlem/Lake",
            },

            ["Yellow"] = new List<string>
            {
                "Howard", "Oakton/Skokie", "Dempster/Skokie", "Oakton/Skokie", "Howard"
            },

            ["Red"] = new List<string>
{
    "95th/Dan Ryan","87th","79th","69th","63rd","Garfield","47th","Sox-35th","Cermak-Chinatown",
"Roosevelt","Harrison","Jackson","Monroe","Lake","Grand","Chicago","Clark/Division",
"North/Clybourn","Fullerton","Belmont","Addison","Sheridan","Wilson","Lawrence","Argyle",
"Berwyn","Thorndale","Granville","Loyola","Morse","Jarvis","Howard","Jarvis","Morse","Loyola",
"Granville","Thorndale","Bryn Mawr","Berwyn","Argyle","Lawrence","Wilson","Sheridan","Addison",
"Belmont","Fullerton","North/Clybourn","Clark/Division","Chicago","Grand","Lake","Monroe",
"Jackson","Harrison","Roosevelt","Cermak-Chinatown","Sox-35th","47th","Garfield","63rd",
"69th","79th","87th","95th/Dan Ryan"
},
            ["Blue"] = new List<string>
{
    "Forest Park","Harlem (Forest Park Branch)","Oak Park","Austin","Cicero","Pulaski","Kedzie-Homan",
"Western (Forest Park Branch)","Illinois Medical District",
"Racine","UIC-Halsted","Clinton","LaSalle","Jackson","Monroe","Washington","Clark/Lake",
"Grand","Chicago","Division","Damen","Western (O'Hare Branch)","California","Logan Square",
"Belmont","Addison","Irving Park","Montrose","Jefferson Park","Harlem (O'Hare Branch)","Cumberland",
"Rosemont","O'Hare","Rosemont","Cumberland","Harlem (O'Hare Branch)","Jefferson Park","Montrose",
"Irving Park","Addison","Belmont","Logan Square","California","Western (O'Hare Branch)","Damen",
"Division","Chicago","Grand","Clark/Lake","Washington","Monroe","Jackson","LaSalle","Clinton",
"UIC-Halsted","Racine","Illinois Medical District","Western (Forest Park Branch)","Kedzie-Homan",
"Pulaski","Cicero","Austin","Oak Park","Harlem (Forest Park Branch)","Forest Park"
}
        };
    }
}
