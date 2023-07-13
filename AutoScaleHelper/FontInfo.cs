using System.Collections.Generic;
using System.Drawing;

namespace AutoScaleHelper
{
    internal class FontInfos
    {
        private static List<FontInfo> fontInfos = new List<FontInfo>();
        /// <summary>
        /// 获取该类型的字体信息，如果没有则进行初始化。
        /// </summary>
        /// <param name="fontName"></param>
        /// <returns></returns>
        public static FontInfo GetFontInfo(string fontName)
        {
            foreach (var fontInfo in fontInfos)
            {
                if (fontInfo.Name == fontName)
                {
                    return fontInfo;
                }
            }

            FontInfo fontInfo1 = new FontInfo(fontName);
            fontInfos.Add(fontInfo1);

            return fontInfo1;
        }
    }


    internal class FontInfo
    {
        public string Name { get; private set; }

        private SortedDictionary<int, float> chnFontHeights;
        private SortedDictionary<int, float> fontHeights;
        private static float[] chnSizes = new float[]
        {
             5.25f,6.75f,  7.5f,  9f,  10.5f,  12f,  14.25f,  15f,  15.75f,  18f,  21.75f,  24f,  26.25f,  36f,  42
        };
        private static float[] cmnSizes = new float[]
        {
             8,9,10,11,12,14,16,18,20,22,24,26,28,36,48,72
        };

        public FontInfo(string name)
        {
            Name = name;

            chnFontHeights = new SortedDictionary<int, float>();
            foreach (var size in chnSizes)
            {
                int height = new Font(name, size).Height;
                chnFontHeights[height] = size;
            }

            fontHeights = new SortedDictionary<int, float>();
            foreach (var size in cmnSizes)
            {
                int height = new Font(name, size).Height;
                fontHeights[height] = size;
            }
        }
        /// <summary>
        /// 根据像素高度和字号类型获取合适的字体大小。
        /// 如选用19磅的字体和中文字号，那么会返回18磅字体的字体大小
        /// </summary>
        /// <param name="height">字体高度（以像素为单位）</param>
        /// <param name="fontSizeType">字号类型</param>
        /// <returns></returns>
        public float GetFloorFontSizeByHeight(int height, FontSizeType fontSizeType)
        {
            float res = 5f;
            if (fontSizeType == FontSizeType.Chinese)
            {
                foreach (var h in chnFontHeights)
                {
                    if (h.Key > height)
                    {
                        break;
                    }
                    res = h.Value;
                }
            }
            else
            {
                foreach (var h in fontHeights)
                {
                    if (h.Key > height)
                    {
                        break;
                    }
                    res = h.Value;
                }
            }

            return res;
        }
        /// <summary>
        /// 获取当前字体大小属于什么字号类型（如果大小在中文字号和国际字号中均能找到，那么优先选取中文）
        /// </summary>
        /// <param name="fontSize">字体大小</param>
        /// <returns>字号类型</returns>
        public static FontSizeType GetFontSizeType(float fontSize)
        {
            foreach (float size in chnSizes)
            {
                if (size == fontSize)
                {
                    return FontSizeType.Chinese;
                }
            }

            foreach (float size in cmnSizes)
            {
                if (size == fontSize)
                {
                    return FontSizeType.Common;
                }
            }

            return FontSizeType.Common;
        }
    }

    public enum FontSizeType
    {
        Common,
        Chinese
    }
}
