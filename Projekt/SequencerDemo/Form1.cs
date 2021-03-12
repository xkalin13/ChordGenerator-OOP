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
        Generator g = new Generator();

        private bool playing = false;

        private bool closing = false;

        public OutputDevice outDevice;

        private int outDeviceID = 0;

        private OutputDeviceDialog outDialog = new OutputDeviceDialog();

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

        private void pianoControl1_PianoKeyDown(object sender, PianoKeyEventArgs e)
        {
            #region Guard

            if(playing)
            {
                return;
            }

            #endregion

            outDevice.Send(new ChannelMessage(ChannelCommand.NoteOn, 0, e.NoteID, 127));
        }

        private void pianoControl1_PianoKeyUp(object sender, PianoKeyEventArgs e)
        {
            #region Guard

            if(playing)
            {
                return;
            }

            #endregion

            outDevice.Send(new ChannelMessage(ChannelCommand.NoteOff, 0, e.NoteID, 0));
        }
        private void PlayNote(int note) {

            if (playing)
            {
                return;
            }
            outDevice.Send(new ChannelMessage(ChannelCommand.NoteOn, 0, note, 127));
        }

        private void generateChords_Click(object sender, EventArgs e)
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

        private void play1_Click(object sender, EventArgs e)
        {
            playProgression(1,PlayType.ALTERNATIVE_CHORDS);
        }

        private void play2_Click(object sender, EventArgs e)
        {
            playProgression(2, PlayType.ALTERNATIVE_CHORDS);
        }

        private void play3_Click(object sender, EventArgs e)
        {
            playProgression(3, PlayType.ALTERNATIVE_CHORDS);
        }
        private void PlayProgressionBtn_Click(object sender, EventArgs e)
        {
            playProgression(0,PlayType.MAIN_CHORDS);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // akord|progression
            playMainChord(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // akord|progression
            playMainChord(1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // akord|progression
            playMainChord(2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // akord|progression
            playMainChord(3);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // akord|progression
            playAlternativeChord(0, 0);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // akord|progression
            playAlternativeChord(1, 0);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // akord|progression
            playAlternativeChord(2, 0);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // akord|progression
            playAlternativeChord(3, 0);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // akord|progression
            playAlternativeChord(0, 1);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            // akord|progression
            playAlternativeChord(1, 1);

        }

        private void button11_Click(object sender, EventArgs e)
        {
            // akord|progression
            playAlternativeChord(2, 1);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            // akord|progression
            playAlternativeChord(3, 1);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            // akord|progression
            playAlternativeChord(0, 2);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            // akord|progression
            playAlternativeChord(1, 2);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            // akord|progression
            playAlternativeChord(2, 2);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            // akord|progression
            playAlternativeChord(3, 2);
        }

        private void RandomizeBtn_Click(object sender, EventArgs e)
        {
            string[] progression = g.randomizeProgression();

            this.key.SelectedItem = progression[0];
            this.modificator.SelectedItem = progression[1];
            this.mode.SelectedItem = progression[2];
            this.mood.SelectedItem = progression[3];
        }
        private void button17_Click(object sender, EventArgs e)
        {
            playKeyChord(0);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            playKeyChord(1);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            playKeyChord(2);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            playKeyChord(3);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            playKeyChord(4);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            playKeyChord(5);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            playKeyChord(6);
        }
        private void playChord(int chord,PlayType playtype, int progression = 0) {
            for (int j = 0; j < 3; j++)
            {
                PlayNote(g.playNote(chord, j, playtype, progression));

            }
        }
        private void playKeyChord(int chord) {
            playChord(chord, PlayType.KEY_CHORDS);
        }
        private void playMainChord(int chord) {
            playChord(chord, PlayType.MAIN_CHORDS);
        }
        private void playAlternativeChord(int chord, int progression)
        {
            playChord(chord,PlayType.ALTERNATIVE_CHORDS,progression);
        }
        //private void playProgression()
        private void playProgression(int id, PlayType playType)
        {
            for (int i = 0; i < 4; i++)//akordy
            {
                for (int j = 0; j < 3; j++)//noty v akordu
                {
                    PlayNote(g.playNote(i, j, playType));

                }
                Thread.Sleep(1000);//pockat po akordu
            }
        }
        private void GenerateChords()
        {

            //g.GenerateChordProgression("C", "major", " ", "Cliché");
            g.GenerateChordProgression(key.Text, mode.Text, modificator.Text, mood.Text);
            setChordNames();
        }
        private void setChordNames()
        {
            //chord1
            button1.Text = g.getChordName(0, 0);
            button2.Text = g.getChordName(0, 1);
            button3.Text = g.getChordName(0, 2);
            button4.Text = g.getChordName(0, 3);
            //chord 2
            button5.Text = g.getChordName(1, 0);
            button6.Text = g.getChordName(1, 1);
            button7.Text = g.getChordName(1, 2);
            button8.Text = g.getChordName(1, 3);
            //chord3
            button9.Text = g.getChordName(2, 0);
            button10.Text = g.getChordName(2, 1);
            button11.Text = g.getChordName(2, 2);
            button12.Text = g.getChordName(2, 3);
            //chord4
            button13.Text = g.getChordName(3, 0);
            button14.Text = g.getChordName(3, 1);
            button15.Text = g.getChordName(3, 2);
            button16.Text = g.getChordName(3, 3);


            //key7chords

            string[] s = g.getChordsInKey();

            button17.Text = s[0];
            button18.Text = s[1];
            button19.Text = s[2];
            button20.Text = s[3];
            button21.Text = s[4];
            button22.Text = s[5];
            button23.Text = s[6];
        }


    }
}