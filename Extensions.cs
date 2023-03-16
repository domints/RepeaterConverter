using System.Collections.Generic;
using System.Linq;

namespace RepeaterConverter
{
    public static class Extensions
    {
        public static List<List<Repeater>> GetMax100Groups(this List<IGrouping<int, Repeater>> groups)
        {
            List<List<Repeater>> result = new List<List<Repeater>>();

            List<Repeater> currentList = new List<Repeater>();
            for(int i = 9; i >= 0; i--)
            {
                if(currentList.Count + groups[i].Count() < 100)
                {
                    currentList.AddRange(groups[i]);
                }
                else
                {
                    result.Add(currentList);
                    currentList = new List<Repeater>();
                    currentList.AddRange(groups[i]);
                }
            }

            result.Add(currentList);

            return result;
        }
    }
}