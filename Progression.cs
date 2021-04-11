using System;
using System.Collections.Generic;
using System.Text;

namespace ChordGenerator
{
    class Progression
    {

        public string Name { get; }
        public int[] Steps { get; }

        public Progression(String name, int[] steps)
        {
            Name = name;
            Steps = steps;
        }

        public Chord[] getProgressionFromBaseAndMode(string passedRootNote, Mode passedMode)
        {
            int[] absSteps = getAbsoluteSteps(passedMode);
            Note[] tmpScale = getScale(passedRootNote, absSteps);

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
        public void recalculateAlternatives()
        {
            Chord[][] tempAlternativeProgression = new Chord[3][];

            NoteDetails rootNoteDetails = getNoteDetails(actualBaseNote.ToString() + actualNoteModifier.HelpSign.ToString());
            NoteDetails[] orderedNotes = getAllNotesInOrder(rootNoteDetails);

            // kvinotvy kruh
            NoteDetails[] circleOfFifths = getCircleOfFifths(rootNoteDetails);

            // otocit kruh
            NoteDetails[] innerCircle = rotateCircleOfFifths(circleOfFifths, actualMode.InnerOffset);
            //molovy zaklad

            Mode oppositeMode = new Mode();

            for (int i = 0; i < chordModes.Length; i++)
            {
                if (chordModes[i].Name == actualMode.OpositeMode)
                {
                    oppositeMode = chordModes[i];
                }
            }

            tempAlternativeProgression[0] = getProgressionFromBaseAndMode(innerCircle[0].NoteArray[0], oppositeMode);//tady

            // +1 a -1 rotation
            string[] bases = { circleOfFifths[1].NoteArray[0], circleOfFifths[circleOfFifths.Length - 1].NoteArray[0] };
            for (int i = 0; i < bases.Length; i++)
            {
                tempAlternativeProgression[i + 1] = getProgressionFromBaseAndMode(bases[i], actualMode);
            }

            alternativeChordProgressions = tempAlternativeProgression;
        }
        public void recalculateMainProgression()
        {
            Console.WriteLine("recalculateMainProgression");
            string rootNoteName = actualBaseNote.ToString() + actualNoteModifier.HelpSign.ToString();//string D-
            Chord[] actualChordProgression = getProgressionFromBaseAndMode(rootNoteName, actualMode);//vklada string a
            mainProgression = actualChordProgression;
        }
        public void GenerateChordProgression(string passedKey, string passedMode, string passedModificator, string passedProgression)
        {
            Console.WriteLine("GenerateChordProgression");
            AssignVars();//inicializace dat            
            setValues(passedKey[0], passedModificator[0], passedMode, passedProgression);//prvni char ze stringu

            recalculateScale();
            recalculateAllChordsInKey();
            recalculateMainProgression();
            recalculateAlternatives();
        }


    }
}
