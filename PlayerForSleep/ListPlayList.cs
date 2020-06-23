using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerForSleep
{
    [Serializable]
    public class ListPlayList
    {
        public List<PlayList> lPlayList;

        public int iPlayList;
        public int iMusic;

        public ListPlayList()
        {
            lPlayList = new List<PlayList>();
            iPlayList = 0;
            iMusic = 0;
        }
    }
}
