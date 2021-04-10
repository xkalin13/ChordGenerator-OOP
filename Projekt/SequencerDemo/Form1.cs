using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Sanford.Multimedia.Midi;
using Sanford.Multimedia.Midi.UI;
using ChordGenerator;

namespace SequencerDemo
{
    public partial class Form1 : Form
    {
        readonly Generator g = new Generator();

        private readonly bool playing = false;

        private bool closing = false;

        public OutputDevice outDevice;

        private readonly int outDeviceID = 0;

        private readonly OutputDeviceDialog outDialog = new OutputDeviceDialog();

        public Form1()
        {

            InitializeComponent();

            this.key.SelectedItem = "C";
            this.modificator.SelectedItem = " ";
            this.mode.SelectedItem = "major";
            this.mood.SelectedItem = "Cliché";
            g.AssignVars();
            GenerateChords();
        }

        protected override void OnLoad(EventArgs e)
        {
            if(OutputDevice.DeviceCount == 0)
            {
                MessageBox.Show("No MIDI output devices available.", "Error!",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);

                Close();
            }
            else
            {
                try
                {
                    outDevice = new OutputDevice(outDeviceID);

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error!",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    Close();
                }
            }

            base.OnLoad(e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            pianoControl1.PressPianoKey(e.KeyCode);

            base.OnKeyDown(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            pianoControl1.ReleasePianoKey(e.KeyCode);

            base.OnKeyUp(e);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            closing = true;

            base.OnClosing(e);
        }


  
        private void HandleChannelMessagePlayed(object sender, ChannelMessageEventArgs e)
        {
            if(closing)
            {
                return;
            }

            outDevice.Send(e.Message);
            pianoControl1.Send(e.Message);
        }

        private void HandleChased(object sender, ChasedEventArgs e)
        {
            foreach(ChannelMessage message in e.Messages)
            {
                outDevice.Send(message);
            }
        }

        private void PianoControl1_PianoKeyDown(object sender, PianoKeyEventArgs e)
        {
            #region Guard

            if(playing)
            {
                return;
            }

            #endregion

            outDevice.Send(new ChannelMessage(ChannelCommand.NoteOn, 0, e.NoteID, 127));
        }

        private void PianoControl1_PianoKeyUp(object sender, PianoKeyEventArgs e)
        {
            #region Guard

            if(playing)
            {
                return;
            }

            #endregion

            outDevice.Send(new ChannelMessage(ChannelCommand.NoteOff, 0, e.NoteID, 0));
        }
        private void PlayNote(int note,int volume = 127) {

            if (playing)
            {
                return;
            }
            outDevice.Send(new ChannelMessage(ChannelCommand.NoteOn, 0, note, volume));
            //TODO moznost ztlumit notu pro kratsi delku tonu
            //outDevice.Send(new ChannelMessage(ChannelCommand.NoteOff, 0, note, volume));
        }

        private void GenerateChords_Click(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("key: " + key.SelectedItem.ToString());
                Console.WriteLine("mode: " + mode.SelectedItem.ToString());
                Console.WriteLine("modificator: " + modificator.SelectedItem.ToString());
                Console.WriteLine("mood: " + mood.SelectedItem.ToString());
                GenerateChords();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void Play1_Click(object sender, EventArgs e)
        {
            PlayProgression(PlayType.ALTERNATIVE_CHORDS,0);
        }

        private void Play2_Click(object sender, EventArgs e)
        {
            PlayProgression(PlayType.ALTERNATIVE_CHORDS,1);
        }

        private void Play3_Click(object sender, EventArgs e)
        {
            PlayProgression( PlayType.ALTERNATIVE_CHORDS,2);
        }
        private void PlayProgressionBtn_Click(object sender, EventArgs e)
        {
            PlayProgression(PlayType.MAIN_CHORDS);
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            // akord|progression
            PlayMainChord(0);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            // akord|progression
            PlayMainChord(1);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            // akord|progression
            PlayMainChord(2);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            // akord|progression
            PlayMainChord(3);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            // akord|progression
            PlayAlternativeChord(0, 0);
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            // akord|progression
            PlayAlternativeChord(1, 0);
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            // akord|progression
            PlayAlternativeChord(2, 0);
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            // akord|progression
            PlayAlternativeChord(3, 0);
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            // akord|progression
            PlayAlternativeChord(0, 1);
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            // akord|progression
            PlayAlternativeChord(1, 1);

        }

        private void Button11_Click(object sender, EventArgs e)
        {
            // akord|progression
            PlayAlternativeChord(2, 1);
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            // akord|progression
            PlayAlternativeChord(3, 1);
        }

        private void Button13_Click(object sender, EventArgs e)
        {
            // akord|progression
            PlayAlternativeChord(0, 2);
        }

        private void Button14_Click(object sender, EventArgs e)
        {
            // akord|progression
            PlayAlternativeChord(1, 2);
        }

        private void Button15_Click(object sender, EventArgs e)
        {
            // akord|progression
            PlayAlternativeChord(2, 2);
        }

        private void Button16_Click(object sender, EventArgs e)
        {
            // akord|progression
            PlayAlternativeChord(3, 2);
        }

        private void RandomizeBtn_Click(object sender, EventArgs e)
        {
            string[] progression = g.randomizeProgression();

            this.key.SelectedItem = progression[0];
            this.modificator.SelectedItem = progression[1];
            this.mode.SelectedItem = progression[2];
            this.mood.SelectedItem = progression[3];
        }
        private void Button17_Click(object sender, EventArgs e)
        {
            PlayKeyChord(0);
        }

        private void Button18_Click(object sender, EventArgs e)
        {
            PlayKeyChord(1);
        }

        private void Button19_Click(object sender, EventArgs e)
        {
            PlayKeyChord(2);
        }

        private void Button20_Click(object sender, EventArgs e)
        {
            PlayKeyChord(3);
        }

        private void Button21_Click(object sender, EventArgs e)
        {
            PlayKeyChord(4);
        }

        private void Button22_Click(object sender, EventArgs e)
        {
            PlayKeyChord(5);
        }

        private void Button23_Click(object sender, EventArgs e)
        {
            PlayKeyChord(6);
        }
        private void PlayChord(int chordNumber,PlayType playType, int alternativeProgressionId = 0) {
            for (int j = 0; j < 3; j++)
            {
                PlayNote(g.playNote(chordNumber, j, playType, alternativeProgressionId));
                //playNote(g.playNote(chordNumber, j, playType, alternativeProgressionId) +12);
            }
            
        }
        private void PlayKeyChord(int chord) {
            PlayChord(chord, PlayType.KEY_CHORDS);
        }
        private void PlayMainChord(int chord) {
            PlayChord(chord, PlayType.MAIN_CHORDS);
        }
        private void PlayAlternativeChord(int chord, int progression)
        {
            PlayChord(chord,PlayType.ALTERNATIVE_CHORDS,progression);
        }
        private void PlayProgression(PlayType playType,int alternativeProgressionId=0)
        {


            for (int i = 0; i < 4; i++)//akordy
            {
                //bass
                PlayBass(i,playType, alternativeProgressionId);
                PlayChord(i,playType,alternativeProgressionId);
                Thread.Sleep(1000);
            }
        }
        private void PlayBass(int chordNumber, PlayType playType, int alternativeProgressionId = 0) {
            PlayNote(g.playNote(chordNumber, 0, playType, alternativeProgressionId) - 12);
           // playNote(g.playNote(chordNumber, 0, playType, alternativeProgressionId));//-24 je o 2 oktavy dolu
        }
        private void GenerateChords()
        {

            //g.GenerateChordProgression("C", "major", " ", "Cliché");
            g.GenerateChordProgression(key.Text, mode.Text, modificator.Text, mood.Text);
            SetChordNames();
        }
        private void SetChordNames()
        {
            //main
            button1.Text = g.getChordName(PlayType.MAIN_CHORDS, 0);
            button2.Text = g.getChordName(PlayType.MAIN_CHORDS, 1);
            button3.Text = g.getChordName(PlayType.MAIN_CHORDS, 2);
            button4.Text = g.getChordName(PlayType.MAIN_CHORDS, 3);

            //ALTERNATIVE

            //chord 1
            button5.Text = g.getChordName(PlayType.ALTERNATIVE_CHORDS, 0, 0);
            button6.Text = g.getChordName(PlayType.ALTERNATIVE_CHORDS, 1, 0);
            button7.Text = g.getChordName(PlayType.ALTERNATIVE_CHORDS, 2, 0);
            button8.Text = g.getChordName(PlayType.ALTERNATIVE_CHORDS, 3, 0);
            //chord 2
            button9.Text = g.getChordName(PlayType.ALTERNATIVE_CHORDS, 0, 1);
            button10.Text = g.getChordName(PlayType.ALTERNATIVE_CHORDS, 1, 1);
            button11.Text = g.getChordName(PlayType.ALTERNATIVE_CHORDS, 2, 1);
            button12.Text = g.getChordName(PlayType.ALTERNATIVE_CHORDS, 3, 1);
            //chord4
            button13.Text = g.getChordName(PlayType.ALTERNATIVE_CHORDS, 0, 2);
            button14.Text = g.getChordName(PlayType.ALTERNATIVE_CHORDS, 1, 2);
            button15.Text = g.getChordName(PlayType.ALTERNATIVE_CHORDS, 2, 2);
            button16.Text = g.getChordName(PlayType.ALTERNATIVE_CHORDS, 3, 2);


            //key chords

            button17.Text = g.getChordName(PlayType.KEY_CHORDS, 0);
            button18.Text = g.getChordName(PlayType.KEY_CHORDS, 1);
            button19.Text = g.getChordName(PlayType.KEY_CHORDS, 2);
            button20.Text = g.getChordName(PlayType.KEY_CHORDS, 3);
            button21.Text = g.getChordName(PlayType.KEY_CHORDS, 4);
            button22.Text = g.getChordName(PlayType.KEY_CHORDS, 5);
            button23.Text = g.getChordName(PlayType.KEY_CHORDS, 6);
        }
    }
}