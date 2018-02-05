using System;
using System.Collections.Generic;

namespace PileOfBeans.Haystack
{
    public class SortByColorResult
    {
        public IList<Straw> Reds { get; set; }
        public IList<Straw> Greens { get; set; }
        public IList<Straw> Blues { get; set; }
        public IList<Straw> Grays { get; set; }

        private struct colorValue
        {
            public SortByColorResult.colorTypeEnum color;
            public int value;

            public colorValue(SortByColorResult.colorTypeEnum col, int val)
            {
                this.color = col;
                this.value = val;
            }
        }

        private IList<colorValue> Colors { get; set; }
        private IList<List<HashSet<Straw>>> MasterColorHashlist { get; set; }
        private TimeSpan startTime;
        private TimeSpan endTime;
        public static TimeSpan executionTime;

        private enum colorTypeEnum
        {
            Red = 0,
            Green,
            Blue,
            Gray,
            ColorCount
        }

        private int GetIndex(decimal length)
        {
            return (int)((length * 10) - 1);
        }

        private void AddToHashList(Straw s, SortByColorResult.colorTypeEnum maxcol)
        {
            decimal length = s.LengthInCm;
            int index = GetIndex(length);
            HashSet<Straw> sHashList = null;
            List<HashSet<Straw>> LHashList = null;

            LHashList = MasterColorHashlist[(int)maxcol];
            sHashList = LHashList[index];

            //check if the elemnt is already in the list
            if (sHashList == null)
                sHashList = new HashSet<Straw>();

            sHashList.Add(s);
            LHashList[index] = sHashList;
            MasterColorHashlist[(int)maxcol] = LHashList;
        }

        private colorValue GetMaxColorValue()
        {
            int maxval = Colors[0].value;
            SortByColorResult.colorTypeEnum maxcol = Colors[0].color;
            for (int i = 1; i < Colors.Count; i++)
            {
                if (Colors[i].value > maxval)
                {
                    maxval = Colors[i].value;
                    maxcol = Colors[i].color;
                }
            }

            return new colorValue(maxcol, maxval);
        }

        private void CopyFromLinkedList()
        {
            List<HashSet<Straw>> LHashList = null;
            for (int j = 0; j < (int)SortByColorResult.colorTypeEnum.ColorCount; j++)
            {
                LHashList = MasterColorHashlist[j];
                for (int i = 49; i < 200; i++)
                {
                    HashSet<Straw> sHashList = LHashList[i];
                    if (sHashList != null)
                    {
                        IEnumerator<Straw> it = sHashList.GetEnumerator();
                        while (it.MoveNext())
                        {
                            if (j == (int)SortByColorResult.colorTypeEnum.Red)
                                Reds.Add(it.Current);
                            else if (j == (int)SortByColorResult.colorTypeEnum.Gray)
                                Grays.Add(it.Current);
                            else if (j == (int)SortByColorResult.colorTypeEnum.Green)
                                Greens.Add(it.Current);
                            else if (j == (int)SortByColorResult.colorTypeEnum.Blue)
                                Blues.Add(it.Current);
                        }
                    }
                }
            }
        }

        public SortByColorResult(Haystack obj)
        {
            startTime = DateTime.Now.TimeOfDay;

            Reds = new List<Straw>();
            Greens = new List<Straw>();
            Blues = new List<Straw>();
            Grays = new List<Straw>();
            Colors = new List<colorValue>();

            MasterColorHashlist = new List<List<HashSet<Straw>>>();
            for (int j = 0; j < (int)SortByColorResult.colorTypeEnum.ColorCount; j++)
            {
                MasterColorHashlist.Add(new List<HashSet<Straw>>(new HashSet<Straw>[200]));
            }

            IEnumerator<Straw> it = obj.Pile.GetEnumerator();
            while (it.MoveNext())
            {
                Straw s = it.Current;
                int colorRed = s.ColorRed;
                int colorGreen = s.ColorGreen;
                int colorBlue = s.ColorBlue;

                //check for gray
                if ((colorRed == colorGreen) && (colorGreen == colorBlue))
                {
                    AddToHashList(s, colorTypeEnum.Gray);
                }
                else
                {
                    //Add the colors to list
                    colorValue cr = new colorValue(colorTypeEnum.Red, colorRed);
                    Colors.Add(cr);
                    colorValue cg = new colorValue(colorTypeEnum.Green, colorGreen);
                    Colors.Add(cg);
                    colorValue cb = new colorValue(colorTypeEnum.Blue, colorBlue);
                    Colors.Add(cb);
                    colorValue maxcolor = GetMaxColorValue();
                    AddToHashList(s, maxcolor.color);
                    Colors.Clear();
                }
            }

            //Copy from linkedlist to the final list
            CopyFromLinkedList();
            endTime = DateTime.Now.TimeOfDay;
            executionTime = endTime - startTime;
        }
    }
}
