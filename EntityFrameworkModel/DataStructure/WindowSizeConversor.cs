using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DataStructure
{
    public class WindowSizeConversor
    {
        public static int[] FromWindowSizeEnumToWindowSizeArray(WindowSizeEnum toConvert)
        {
            switch (toConvert)
            {
                case WindowSizeEnum.WIDTH_1920_X_HEIGHT_1080:
                    return new int[] { 1920, 1080 };
                case WindowSizeEnum.WIDTH_1600_X_HEIGHT_900:
                    return new int[] { 1600, 900 };
                case WindowSizeEnum.WIDTH_1440_X_HEIGHT_900:
                    return new int[] { 1440, 900 };
                case WindowSizeEnum.WIDTH_1280_X_HEIGHT_720:
                    return new int[] { 1280, 720 };
                case WindowSizeEnum.WIDTH_1152_X_HEIGHT_864:
                    return new int[] { 1152, 864 };
                case WindowSizeEnum.WIDTH_1024_X_HEIGHT_768:
                    return new int[] { 1024, 768 };
                default:
                    return new int[] { 800, 600 };
            }
        }
    }
}
