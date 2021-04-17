using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using Sanford.Multimedia.Midi;
using Sanford.Multimedia.Midi.UI;


namespace ChordGenerator
{
    public class Player //TODO implement player
    {

        public OutputDevice outDevice = new OutputDevice(0);

        private readonly OutputDeviceDialog outDialog = new OutputDeviceDialog();


        public Generator generator;


        public enum PlayType
        {
            KEY_CHORDS,
            MAIN_CHORDS,
            ALTERNATIVE_CHORDS
        };

        public Player(Generator generator) {
            this.generator = generator;
        }


        /*private void PlayNote(int note, int volume = 127)
        {

            if (playing)
            {
                return;
            }
            outDevice.Send(new ChannelMessage(ChannelCommand.NoteOn, 0, note, volume));
        }*/
     
        /*public void PlayProgression(PlayType playType, int alternativeProgressionId = 0)
        {


            for (int i = 0; i < 4; i++)//akordy
            {
                //bass
                PlayBass(i, playType, alternativeProgressionId);
                PlayChord(i, playType, alternativeProgressionId);
                Thread.Sleep(1000);
            }
        }*/



        public void PlayChords(PlayType playType, int chordInOrder, int alternativeIndex)
        {

            if (playType == PlayType.MAIN_CHORDS)
            {
                PlayMainChord(chordInOrder);
            }
            else if (playType == PlayType.KEY_CHORDS)
            {
               PlayKeyChord(chordInOrder);
            }
            else{
               PlayAlternativeChord(chordInOrder, alternativeIndex);
            }

        }
        public void PlayChord(Chord chord) {
            
            foreach ( Note note in chord.GetChordNotes())
            {

                PlayNote(note.midiNumber);

            }
            Thread.Sleep(500);
            foreach (Note note in chord.GetChordNotes())
            {

                StopNote(note.midiNumber);

            }
            
        }
        public void PlayMainChord(int passedChordNumber)
        {

            PlayChord(generator.mainProgression[passedChordNumber]);
        }
        public void PlayAlternativeChord(int progressionId,int passedChordNumber)
        {

            PlayChord(generator.alternativeProgressions[passedChordNumber][progressionId]);
        }
        public void PlayKeyChord(int passedChordNumber)
        {

            PlayChord(generator.chordsInKey[passedChordNumber]);
        }

        private void PlayNote(int note, int volume = 127)
        {

            outDevice.Send(new ChannelMessage(ChannelCommand.NoteOn, 0, note, volume));


        }
        private void StopNote(int midi) {
            
            outDevice.Send(new ChannelMessage(ChannelCommand.NoteOff,0, midi));
        }
        public void PianoControl1_PianoKeyUp(object sender, PianoKeyEventArgs e)
        {

            outDevice.Send(new ChannelMessage(ChannelCommand.NoteOff, 0, e.NoteID, 0));
        }
        public void PianoControl1_PianoKeyDown(object sender, PianoKeyEventArgs e)
        {

            outDevice.Send(new ChannelMessage(ChannelCommand.NoteOn, 0, e.NoteID, 127));
        }
    }
}
