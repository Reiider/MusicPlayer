using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerForSleep
{
    [Serializable]
    public struct Music
    {
        public string name;
        public string dir;
        public Music(string name, string dir)
        {
            this.name = name;
            this.dir = dir;
        }
    }
    [Serializable]
    public class PlayList
    {
        public string nameList;
        public int h;
        public int m;
        public int s;
        public bool pauseAfter;
        public bool pauseAfterEndMusic;
        public bool randomPlay;
        public bool exitAfter;

        public int volume;

        public List<Music> lMusic;
        public List<int> lRandomMusic;

        public PlayList()
        {
            nameList = "";
            h = 0;
            m = 0;
            s = 0;
            pauseAfter = false;
            pauseAfterEndMusic = false;
            randomPlay = false;
            exitAfter = false;
            volume = 50;
            lMusic = new List<Music>();
            lRandomMusic = new List<int>();
        }

        public PlayList(string name)
        {
            nameList = name;
            h = 0;
            m = 0;
            s = 0;
            pauseAfter = false;
            pauseAfterEndMusic = false;
            randomPlay = false;
            exitAfter = false;
            volume = 50;
            lMusic = new List<Music>();
            lRandomMusic = new List<int>();
        }

        public void createRandomList()
        {
            DateTime date = DateTime.Now;
            string sRand = date.Second.ToString() + date.Hour.ToString() + date.Minute.ToString() + date.Day.ToString();
            Random random = new Random(int.Parse(sRand));

            List<int> lRand = new List<int>();
            for (int i = 0; i < lMusic.Count; i++)
            {
                lRand.Add(i);
            }

            lRandomMusic.Clear();
            for (int lrCount = lRand.Count; lrCount != 0; lrCount--)
            {
                int rand = random.Next(lrCount);
                lRandomMusic.Add(lRand[rand]);
                lRand.RemoveAt(rand);
            }
        }

        public int getIndNextRandom(int n)
        {
            for(int i = 0; i < lRandomMusic.Count-1; i++){
                if(n == lRandomMusic[i]) return lRandomMusic[i+1];
            }
            createRandomList();
            return lRandomMusic[0];
        }

        public int getIndPreviousRandom(int n)
        {
            for (int i = lRandomMusic.Count - 1; i > 0 ; i--)
            {
                if (n == lRandomMusic[i]) return lRandomMusic[i - 1];
            }
            createRandomList();
            return lRandomMusic[0];
        }
    }
}
