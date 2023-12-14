using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenesysDiceBot.config
{

    // This is a class that will read and extract the data from our config JSON file we made.
    internal class JSONReader
    {
        // Reference the token and prefix here.
        public string token { get; set; }
        public string prefix { get; set; }

        // Method that reads our JSON File
        public async Task ReadJSON()
        {
            // To read the file, we need a StreamReader.
            // Provide the path of our config json file to the StreamReader
            using (StreamReader sr = new StreamReader("config.json"))
            {
                // This reads the json file to the end and then extracts/deserializes the data from it as an object.
                string json = await sr.ReadToEndAsync();
                JSONStructure data = JsonConvert.DeserializeObject<JSONStructure>(json);

                // Sets the properties of the token and prefix the JSONStructure needs to do its job as an object, to the properties read and extracted by the ReadJSON method in the json file.
                this.token = data.token;
                this.prefix = data.prefix;
            }
        }
    }

    // This class is sealed to keep the token secure and safe
    internal sealed class JSONStructure
    {
        // Reference the token and prefix again as class properties
        public string token { get; set; }
        public string prefix { get; set; }
    }
}
