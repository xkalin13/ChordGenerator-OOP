using System.Threading;
using Sanford.Multimedia.Midi;
using Sanford.Multimedia.Midi.UI;


namespace ChordGenerator
{
    public class Player
    {

        public OutputDevice OutDevice = new OutputDevice(0);
        public Generator Generator;


        public enum PlayType
        {
            Key,
            Main,
            Alternative
        };

        public Player(Generator generator) {
            this.Generator = generator;
        }


        public void PlayChords(PlayType playType, int chordInOrder, int alternativeIndex)
        {

            if (playType == PlayType.Main)
            {
                PlayMainChord(chordInOrder);
            }
            else if (playType == PlayType.Key)
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

            PlayChord(Generator.MainProgression[passedChordNumber]);
        }
        public void PlayAlternativeChord(int progressionId,int passedChordNumber)
        {

            PlayChord(Generator.AlternativeProgressions[passedChordNumber][progressionId]);
        }
        public void PlayKeyChord(int passedChordNumber)
        {

            PlayChord(Generator.ChordsInKey[passedChordNumber]);
        }

        private void PlayNote(int note, int volume = 127)
        {

            OutDevice.Send(new ChannelMessage(ChannelCommand.NoteOn, 0, note, volume));


        }
        private void StopNote(int midi) {
            
            OutDevice.Send(new ChannelMessage(ChannelCommand.NoteOff,0, midi));
        }
        public void PianoControl1_PianoKeyUp(object sender, PianoKeyEventArgs e)
        {

            OutDevice.Send(new ChannelMessage(ChannelCommand.NoteOff, 0, e.NoteID, 0));
        }
        public void PianoControl1_PianoKeyDown(object sender, PianoKeyEventArgs e)
        {

            OutDevice.Send(new ChannelMessage(ChannelCommand.NoteOn, 0, e.NoteID, 127));
        }
    }
}
