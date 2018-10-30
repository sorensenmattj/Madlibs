using Newtonsoft.Json;
using System.Collections.Generic;

namespace MadLibs.MadLibsComponents
{
    public class RootJsonObject
    {
        [JsonProperty("madlibs")]
        public List<MadLib> Madlibs { get; set; }
    }
}
