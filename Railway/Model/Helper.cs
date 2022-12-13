using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railway.Model
{
    internal class Helper
    {
        internal static List<string> stations = new List<string>() {
            "Минск-Пассажирский",
            "Орша Центральная",
            "Смоленск",
            "Москва-Пассажирская-Белорусская"
        };
        internal static List<string> trains = new List<string>()
        {
            "2",
            "108",
            "706",
            "708"
        };

        internal static List<string> car_type = new List<string>()
        {
            "П",
            "К",
            "СВ"
        };

        internal static Dictionary<string, int> placeCounts = new Dictionary<string, int>()
        {
            { "П", 54 },
            { "К", 36 },
            {"СВ", 18 }
        };
    }
}
