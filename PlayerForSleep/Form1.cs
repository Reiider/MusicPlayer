using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using AxWMPLib;

namespace PlayerForSleep
{
    public partial class Form1 : Form
    {
        int h;
        int m;
        int s;

        ListPlayList lpl;

        string rootDir;

        bool stopPlayer;
        string dirPath;
        int nowPlayIndex = 0;
        int nowPlayList = 0;

        bool pause = false;
        bool mediaEnds = false;

        ContextMenuStrip cmsbAdd;
        
        public Form1()
        {
            InitializeComponent();
            wmp.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(player_PlayStateChange);          
            wmp.Visible = false;

            rootDir = System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile);
            rootDir += "\\PlayerForSleep";
            System.IO.Directory.CreateDirectory(rootDir);
            rootDir += "\\ListPlayLists.lpl";
            
            lpl = new ListPlayList();

            if (!loadSetting())
            {
                nudHour.Value = h = 1;
                nudMin.Value = m = 30;
                nudSec.Value = s = 0;

                cbWillStop.Checked = true;
                cbEndMusic.Checked = true;
                cbRandom.Checked = true;
                cbExit.Checked = true;
                lpl.lPlayList.Add(new PlayList("Новй плейлист"));
            }
            else
            {
                while(tcListsMusic.TabPages.Count != 0) tcListsMusic.TabPages.RemoveAt(0); // удаляем существующие табы
                for(int intList = 0; intList < lpl.lPlayList.Count; intList++)
                {
                    resetTab(intList);
                }
                nowPlayIndex = lpl.iMusic;
                nowPlayList = lpl.iPlayList;
                nudHour.Value = h = lpl.lPlayList[nowPlayList].h;
                nudMin.Value = m = lpl.lPlayList[nowPlayList].m;
                nudSec.Value = s = lpl.lPlayList[nowPlayList].s;
                nudVolume.Value = lpl.lPlayList[nowPlayList].volume;
                cbWillStop.Checked = lpl.lPlayList[nowPlayList].pauseAfter;
                cbEndMusic.Checked = lpl.lPlayList[nowPlayList].pauseAfterEndMusic;
                cbRandom.Checked = lpl.lPlayList[nowPlayList].randomPlay;
                cbExit.Checked = lpl.lPlayList[nowPlayList].exitAfter;

                playCurrentMusic();
            }
            this.WindowState = FormWindowState.Minimized;
        }

        private void resetTab(int iTab)
        {
            bool isNewTab = false;
            PlayList playList = lpl.lPlayList[iTab]; // получаем плей лист из списка
            TabPage value;
            try
            {
                value = tcListsMusic.TabPages[iTab]; // задаем имя табу
            }
            catch
            {
                value = new TabPage(playList.nameList);
                isNewTab = true;
            }
            value.AutoScroll = true;
            value.BackColor = Color.Black;           
            
            List<Music> listM = playList.lMusic; // получаем название песен в выбранном плейлисте
            for (int intMusic = value.Controls.Count; intMusic < listM.Count; intMusic++)
            {
                ListMusic lm = new ListMusic(); //создаем элемент (Song)
                lm.set(listM[intMusic].name, iTab, intMusic);
                lm.deleteSong += deleteMusic;
                lm.playSong += clickToMusic;
                lm.Location = new Point(0, 16*intMusic - value.VerticalScroll.Value);
                value.Controls.Add(lm);// добавляем элемент на панель-таб
            }
            if(isNewTab) tcListsMusic.TabPages.Add(value); // добавляем таб на панель
        }

        private void deleteMusic(int list, int music)
        {
            int scroll = tcListsMusic.SelectedTab.VerticalScroll.Value;
            lpl.lPlayList[list].lMusic.RemoveAt(music);
            int count = tcListsMusic.TabPages[list].Controls.Count;
            List<ListMusic> llm = new List<ListMusic>();
            foreach (object o in tcListsMusic.TabPages[list].Controls)
            {
                llm.Add((ListMusic)o);
            }
            llm.RemoveAt(music);
            for (int i = music; i < count-1; i++)
            {
                llm[i].Location = new Point(0, 16 * i);
                llm[i].Index = i;
            }
            tcListsMusic.TabPages[list].Controls.Clear();
            foreach (ListMusic lm in llm)
            {
                tcListsMusic.TabPages[list].Controls.Add(lm);
            }
            tcListsMusic.TabPages[list].VerticalScroll.Value = scroll;
            tcListsMusic.TabPages[list].VerticalScroll.Value = scroll;
        }

        private void clickToMusic(int list, int music)
        {
            nowPlayIndex = music;
            nowPlayList = list;
            playCurrentMusic();
        }

        private void highlightCurrentMusic()
        {
            int scroll = tcListsMusic.TabPages[nowPlayList].VerticalScroll.Value;
            int count = tcListsMusic.TabPages[nowPlayList].Controls.Count;
            List<ListMusic> llm = new List<ListMusic>();
            foreach (object o in tcListsMusic.TabPages[nowPlayList].Controls)
            {
                llm.Add((ListMusic)o);
            }
            for (int i = 0; i < count; i++)
            {
                llm[i].Location = new Point(0, 16 * i);
                if (i == nowPlayIndex) llm[i].setColor();
                else llm[i].resetColor();
            }
            tcListsMusic.TabPages[nowPlayList].Controls.Clear();
            foreach (ListMusic lm in llm)
            {
                tcListsMusic.TabPages[nowPlayList].Controls.Add(lm);
            }
            if (nowPlayIndex == 0) tcListsMusic.TabPages[nowPlayList].VerticalScroll.Value = tcListsMusic.TabPages[nowPlayList].VerticalScroll.Minimum;
            else if (nowPlayIndex == lpl.lPlayList[nowPlayList].lMusic.Count - 1) tcListsMusic.TabPages[nowPlayList].VerticalScroll.Value = tcListsMusic.TabPages[nowPlayList].VerticalScroll.Maximum;
            else
            {
                tcListsMusic.TabPages[nowPlayList].VerticalScroll.Value = scroll;
                tcListsMusic.TabPages[nowPlayList].VerticalScroll.Value = scroll;
            }
        }
// изменение текста таба и удаление
       
        ContextMenuStrip cmDelPlayList = new ContextMenuStrip();
        int lastIndTab = 0;
        void tcListsMusic_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                //сохранить параметр текущего листа
                lpl.lPlayList[lastIndTab].h = (int)nudHour.Value;
                lpl.lPlayList[lastIndTab].m = (int)nudMin.Value;
                lpl.lPlayList[lastIndTab].s = (int)nudSec.Value;
                lpl.lPlayList[lastIndTab].pauseAfter = cbWillStop.Checked;
                lpl.lPlayList[lastIndTab].pauseAfterEndMusic = cbEndMusic.Checked;
                lpl.lPlayList[lastIndTab].randomPlay = cbRandom.Checked;
                lpl.lPlayList[lastIndTab].exitAfter = cbExit.Checked;
                lpl.lPlayList[lastIndTab].volume = (int)nudVolume.Value;
            }
            catch { }
            if (lastIndTab != tcListsMusic.SelectedIndex)
            {
                //загрузить параметры нового листа
                lastIndTab = tcListsMusic.SelectedIndex;
                nudHour.Value = lpl.lPlayList[lastIndTab].h;
                nudMin.Value = lpl.lPlayList[lastIndTab].m;
                nudSec.Value = lpl.lPlayList[lastIndTab].s;
                cbWillStop.Checked = lpl.lPlayList[lastIndTab].pauseAfter;
                cbEndMusic.Checked = lpl.lPlayList[lastIndTab].pauseAfterEndMusic;
                cbRandom.Checked = lpl.lPlayList[lastIndTab].randomPlay;
                cbExit.Checked = lpl.lPlayList[lastIndTab].exitAfter;
                nudVolume.Value = lpl.lPlayList[lastIndTab].volume;
            }
            
            TabControl tc = (TabControl)sender;

            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                cmDelPlayList.Items.Clear();
                cmDelPlayList.Items.Add("Переименовать плейлист \"" + tcListsMusic.SelectedTab.Text + "\"");
                cmDelPlayList.Items.Add("Удалить плейлист \"" + tcListsMusic.SelectedTab.Text+"\"");
                cmDelPlayList.Items[0].Click += changeTabText;
                cmDelPlayList.Items[1].Click += deletePlayList;
                cmDelPlayList.Show(this.Location.X + tc.Location.X + e.X, this.Location.Y + tc.Location.Y + e.Y);
            }
        }

        private void changeTabText(object sender, EventArgs e)
        {
            TextBox tb = new TextBox();
            tb.Location = tcListsMusic.Location;
            this.Controls.Add(tb);
            tb.Height = 20;
            tb.Width = this.Width - 8;
            tb.BringToFront();
            tb.Leave += closeChangeTabText;
            tb.Text = tcListsMusic.SelectedTab.Text; 
            tb.Focus();
            tb.KeyPress += new KeyPressEventHandler(closeChangeTabTextKeyEv);
        }

        private void closeChangeTabText(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tcListsMusic.SelectedTab.Text = tb.Text;
            lpl.lPlayList[tcListsMusic.SelectedIndex].nameList = tb.Text;
            tb.Dispose();
        }

        private void closeChangeTabTextKeyEv(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                this.button2.Focus();
            }
        }

        private void deletePlayList(object sender, EventArgs e)
        {
            tcListsMusic.TabPages.RemoveAt(tcListsMusic.SelectedIndex);
            lpl.lPlayList.RemoveAt(tcListsMusic.SelectedIndex);
            nowPlayList = 0;
        }

// .. изменение текста таба

        private bool loadSetting()
        {
            FileInfo fi1 = new FileInfo(rootDir);
 
            if (!fi1.Exists) 
            {
                return false;
            }

            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(rootDir, FileMode.OpenOrCreate))
            {
                lpl = (ListPlayList)formatter.Deserialize(fs);
            }

            return true;
        }

        private void saveSetting()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(rootDir, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, lpl);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bSetting_Click(object sender, EventArgs e)
        {
            lpl.iPlayList = nowPlayList;
            lpl.iMusic = nowPlayIndex;
            
            lpl.lPlayList[nowPlayList].h = (int)nudHour.Value;
            lpl.lPlayList[nowPlayList].m = (int)nudMin.Value;
            lpl.lPlayList[nowPlayList].s = (int)nudSec.Value;
            lpl.lPlayList[nowPlayList].pauseAfter = cbWillStop.Checked;
            lpl.lPlayList[nowPlayList].pauseAfterEndMusic = cbEndMusic.Checked;
            lpl.lPlayList[nowPlayList].randomPlay = cbRandom.Checked;
            lpl.lPlayList[nowPlayList].exitAfter = cbExit.Checked;
            lpl.lPlayList[nowPlayList].volume = (int)nudVolume.Value;

            saveSetting();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!pause)
            {
                wmp.Ctlcontrols.pause();
                pause = !pause;
            }
            else
            {
                wmp.Ctlcontrols.play();
                pause = !pause;
                if (wmp.playState != WMPLib.WMPPlayState.wmppsPlaying)
                {
                    playCurrentMusic();
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            cmsbAdd.Show(bAdd, new Point(0, -cmsbAdd.Height));
        }

        private void playCurrentMusic()
        {
            if (wmp.playState == WMPLib.WMPPlayState.wmppsPlaying) wmp.Ctlcontrols.stop();
            highlightCurrentMusic();
            wmp.URL = lpl.lPlayList[nowPlayList].lMusic[nowPlayIndex].dir;
            stopPlayer = false;
            pause = false;
            if (cbWillStop.Checked && !sleeper.Enabled) sleeper.Start();
            wmp.Ctlcontrols.play();

            lpl.iMusic = nowPlayIndex;
            lpl.iPlayList = nowPlayList;

            saveSetting();
        }

        private void bNextSong_Click(object sender, EventArgs e)
        {
            if (cbRandom.Checked)
            {
                nowPlayIndex = lpl.lPlayList[tcListsMusic.SelectedIndex].getIndNextRandom(nowPlayIndex);
                int val = tcListsMusic.TabPages[nowPlayList].VerticalScroll.Maximum * nowPlayIndex / lpl.lPlayList[nowPlayList].lMusic.Count;
                tcListsMusic.TabPages[nowPlayList].VerticalScroll.Value = val;
                tcListsMusic.TabPages[nowPlayList].VerticalScroll.Value = val;
            }
            else
            {
                if (nowPlayIndex < lpl.lPlayList[tcListsMusic.SelectedIndex].lMusic.Count - 1)
                {
                    nowPlayIndex++;
                    int val = tcListsMusic.TabPages[nowPlayList].VerticalScroll.Maximum * nowPlayIndex / lpl.lPlayList[nowPlayList].lMusic.Count;
                    tcListsMusic.TabPages[nowPlayList].VerticalScroll.Value = val;
                    tcListsMusic.TabPages[nowPlayList].VerticalScroll.Value = val;
                    
                }
                else
                {
                    nowPlayIndex = 0;
                }
            }
            playCurrentMusic();
        }

        private void bPrevious_Click(object sender, EventArgs e)
        {
            if (cbRandom.Checked)
            {
                nowPlayIndex = lpl.lPlayList[tcListsMusic.SelectedIndex].getIndPreviousRandom(nowPlayIndex);
            }
            else
            {
                if (nowPlayIndex == 0)
                {
                    nowPlayIndex = lpl.lPlayList[tcListsMusic.SelectedIndex].lMusic.Count-1;
                }
                else
                {
                    nowPlayIndex--;
                    if (nowPlayIndex < 8)
                    {
                        tcListsMusic.TabPages[nowPlayList].VerticalScroll.Value = 0;
                        tcListsMusic.TabPages[nowPlayList].VerticalScroll.Value = 0;
                    }
                    else
                    {
                        tcListsMusic.TabPages[nowPlayList].VerticalScroll.Value = tcListsMusic.TabPages[nowPlayList].VerticalScroll.Maximum * nowPlayIndex / lpl.lPlayList[nowPlayList].lMusic.Count;
                        tcListsMusic.TabPages[nowPlayList].VerticalScroll.Value = tcListsMusic.TabPages[nowPlayList].VerticalScroll.Maximum * nowPlayIndex / lpl.lPlayList[nowPlayList].lMusic.Count;
                    }
                }
            }
            playCurrentMusic();
        }

        private void nudVolume_ValueChanged(object sender, EventArgs e)
        {
            wmp.settings.volume = (int)nudVolume.Value;
        }

        private void player_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == 8) mediaEnds = true; 
            if (e.newState == 1 && mediaEnds) 
            {
                mediaEnds = false; 
                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(!stopPlayer){
                mediaEnds = false;
                bNextSong_Click(new Object(), new EventArgs());
            }
            else if (cbExit.Checked) this.Close();
            timer1.Stop();
        }

        private void sleeper_Tick(object sender, EventArgs e)
        {
            if (nudSec.Value > 0) nudSec.Value--;
            else
            {
                if (nudMin.Value > 0) nudMin.Value--;
                else
                {
                    if (nudHour.Value > 0) nudHour.Value--;
                    else
                    {
                        if (cbEndMusic.Checked) stopPlayer = true;
                        else
                        {
                            timer1.Stop();
                            wmp.Ctlcontrols.pause();
                            pause = true;
                            sleeper.Stop();
                            if (cbExit.Checked)
                            {
                                this.Close();
                            }
                        }
                        return;
                    }
                    nudMin.Value = 59;
                }
                nudSec.Value = 59;
            }
        }

        private void cbWillStop_CheckedChanged(object sender, EventArgs e)
        {
            if (cbWillStop.Checked) sleeper.Start();
            else sleeper.Stop();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            nudHour.Value = h;
            nudMin.Value = m;
            nudSec.Value = s;
            cbWillStop.Checked = false;
            cbWillStop.Checked = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmsbAdd = new ContextMenuStrip();
            cmsbAdd.Items.Add("Добавить плейлист");
            cmsbAdd.Items[0].Click += addPlayList;
            cmsbAdd.Items.Add("Добавить папку");
            cmsbAdd.Items[1].Click += addFolder;
            cmsbAdd.Items.Add("Добавить музыку");
            cmsbAdd.Items[2].Click += addMusic;

            tcListsMusic.MouseClick += tcListsMusic_MouseClick; // появление контекстного меню для удаления плейлиста
        }       

        private void addPlayList(object sender, EventArgs e)
        {
            lpl.lPlayList.Add(new PlayList("Новый плейлист"));
            TabPage tp = new TabPage("Новый плейлист");
            tp.BackColor = Color.Black;
            tcListsMusic.TabPages.Add(tp);
            tcListsMusic.SelectTab(tp);
        }

        private void addFolder(object sender, EventArgs e)
        {
            FolderBrowserDialog DirDialog = new FolderBrowserDialog();
            DirDialog.Description = "Выбор директории";
            DirDialog.SelectedPath = dirPath;

            if (DirDialog.ShowDialog() == DialogResult.OK)
            {
                string[] list = { };
                dirPath = DirDialog.SelectedPath;
                try
                {
                    list = Directory.GetFiles(DirDialog.SelectedPath, "*", SearchOption.AllDirectories);
                }
                catch (UnauthorizedAccessException uex)
                {
                    MessageBox.Show(uex.Message.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

                int ind = tcListsMusic.SelectedIndex;
                foreach (var file in list)
                {
                    int find = file.LastIndexOf("\\");
                    string s = file.Substring(find + 1, file.Length - find - 1);
                    find = s.LastIndexOf(".");
                    string typefile = s.Substring(find + 1, s.Length - find - 1);
                    if (typefile == "mp3" || typefile == "wav" || typefile == "wma" || typefile == "aac")
                    {
                        s = s.Substring(0, find);
                        lpl.lPlayList[ind].lMusic.Add(new Music(s, file));
                    }
                }
                lpl.lPlayList[ind].createRandomList();
                resetTab(ind);
            }
        }

        private void addMusic(object sender, EventArgs e)
        {
            OpenFileDialog OPF = new OpenFileDialog();
            OPF.Multiselect = true;
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                int ind = tcListsMusic.SelectedIndex;
                foreach (string file in OPF.FileNames)
                {
                    int find = file.LastIndexOf("\\");
                    string s = file.Substring(find + 1, file.Length - find - 1);
                    find = s.LastIndexOf(".");
                    string typefile = s.Substring(find + 1, s.Length - find - 1);
                    if (typefile == "mp3" || typefile == "wav" || typefile == "wma" || typefile == "aac")
                    {
                        s = s.Substring(0, find);
                        lpl.lPlayList[ind].lMusic.Add(new Music(s, file));
                    }
                }
                lpl.lPlayList[ind].createRandomList();
                resetTab(ind);
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }
    }
}
