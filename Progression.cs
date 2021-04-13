using System;
using System.Collections.Generic;
using System.Text;

namespace ChordGenerator
{
    public class Progression
    {

        public string Name { get; }
        public int[] Steps { get; }

        public Progression(String name, int[] steps)
        {
            Name = name;
            Steps = steps;
        }

        public Chord[] GetProgressionFromBaseAndMode(string passedRootNote, Mode passedMode)
        {
            int[] absSteps = GetAbsoluteSteps(passedMode);
            Note[] tmpScale = GetScale(passedRootNote, absSteps);

            Chord[] chordsInKey = new Chord[tmpScale.Length];//pole akordu ve stupnici

            for (var i = 0; i < tmpScale.Length; i++)//7 udela akordy ze stupnice
            {
                //name /mode /details
                Console.WriteLine("scalerNameChord " + tmpScale[i].RealNoteName + passedMode.ChordType[i].Symbol);

                chordsInKey[i] = new Chord(tmpScale[i].RealNoteName + passedMode.ChordType[i].Symbol, passedMode.ChordType[i], tmpScale[i].NoteDetails);
            }

            return getProgression(actualChordProgression, chordsInKey);
        }
        public Chord[] getProgression(Progressions progressionDetails, Chord[] chordsInKey)
        {
            Chord[] actualChordProgression = new Chord[progressionDetails.Steps.Length];//pole akordu ktere vezme stupnici a vezme jen ty ktere maji kadenci
            for (int i = 0; i < progressionDetails.Steps.Length; i++)
            {
                int step = progressionDetails.Steps[i];//projede pole kadenci 
                actualChordProgression[i] = chordsInKey[step];//vrati ktery tempChord je na kroku step 
            }
            return actualChordProgression;
        }
        public void RecalculateMainProgression()
        {
            Console.WriteLine("recalculateMainProgression");
            string rootNoteName = actualBaseNote.ToString() + actualNoteModifier.HelpSign.ToString();//string D-
            Chord[] actualChordProgression = getProgressionFromBaseAndMode(rootNoteName, actualMode);//vklada string a
            mainProgression = actualChordProgression;
        }
        


    }
}
