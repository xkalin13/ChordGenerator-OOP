using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using Sanford.Multimedia.Midi;
using Sanford.Multimedia.Midi.UI;


namespace ChordGenerator
{
    public class Player //TODO implement rythm
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
            
            foreach ( Note note in chord.GetChord())
            {

                PlayNote(note.midiNumber);

            }
            Thread.Sleep(800);
            foreach (Note note in chord.GetChord())
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
