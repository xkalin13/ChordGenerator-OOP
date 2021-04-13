using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using Sanford.Multimedia.Midi;
namespace ChordGenerator
{

    public partial class Generator
    {

        public string[] getRandomizedProgression()
        {
            Console.WriteLine("getRandomizedProgression");
            actualBaseNote = baseNotes[getRandomItem(baseNotes.Length)];
            actualNoteModifier = noteModifiers[getRandomItem(noteModifiers.Length)];
            actualMode = chordModes[getRandomItem(chordModes.Length)];
            actualChordProgression = chordProgressions[getRandomItem(chordProgressions.Length)];

            return new string[] { actualBaseNote.ToString(), actualNoteModifier.PreSign.ToString(), actualMode.Name.ToString(), actualChordProgression.Name.ToString() };
        }
        public void RecalculateScale()
        {
            Console.WriteLine("recalculateScale");
            actualScaleNotes = note.getScale(actualBaseNote.ToString() + actualNoteModifier.HelpSign.ToString(), GetAbsoluteSteps(actualMode));
        }
       
        public int getRandomItem(int length)
        {
            return rnd.Next(0, length);
        }


        public void GenerateChordProgression(string passedKey, string passedMode, string passedModificator, string passedProgression)
        {
            Console.WriteLine("GenerateChordProgression");
            AssignVars();//inicializace dat            
            setValues(passedKey[0], passedModificator[0], passedMode, passedProgression);//prvni char ze stringu

            RecalculateScale();
            chord.recalculateAllChordsInKey();
            progression.recalculateMainProgression();
            recalculateAlternatives();
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

            Mode oppositeMode;

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




    }
}