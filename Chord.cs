using System;
using System.Collections.Generic;
using System.Text;

namespace ChordGenerator
{
    public partial class Chord
    {
        public struct ChordType
        {
            public string Name { get; }
            public string Symbol { get; }

            public ChordType(string name, string symbol)
            {
                Name = name;
                Symbol = symbol;
            }
        }

        public string ChordName { get; private set; }
        public ChordType Mode { get; private set; }
        public NoteDetails BaseNoteDetails { get; private set; }

        public Chord(string chordName, ChordType mode, NoteDetails details)
        {
            ChordName = chordName;
            Mode = mode;
            BaseNoteDetails = details;
        }
        public string GetChordName(PlayType playType, int passedChordNumber, int passedChordProgression = 0)
        {
            string tempChord;
            if (playType == PlayType.MAIN_CHORDS)
            {
                tempChord = mainProgression[passedChordNumber].ChordName;
            }
            else if (playType == PlayType.ALTERNATIVE_CHORDS)
            {
                tempChord = alternativeChordProgressions[passedChordProgression][passedChordNumber].ChordName;
            }
            else
            {
                tempChord = allChordsInKey[passedChordNumber].ChordName;
            }

            return tempChord;
        }

        public void recalculateAllChordsInKey()//cdefgab
        {
            Chord[] tmpChordsInKey = new Chord[chordTypeBuilder1.Length];

            for (var i = 0; i < allChordsInKey.Length; i++)
            {
                //name /mode /details
                tmpChordsInKey[i] = new Chord(
                        actualScaleNotes[i].RealNoteName + actualMode.ChordType[i].Symbol,
                        actualMode.ChordType[i],
                        actualScaleNotes[i].NoteDetails
                        );
            }
            //getProgressionFromBaseAndMode();
            allChordsInKey = tmpChordsInKey;
        }
    }
}
