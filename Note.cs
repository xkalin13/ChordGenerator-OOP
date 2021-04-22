using System;
using System.Collections.Generic;
using System.Linq;

namespace ChordGenerator
{
    public class Note 
    {
        public static readonly char[] PublicRootNotes = new char[] { 'C', 'D', 'E', 'F', 'G', 'A', 'B' };
        public static Dictionary<int, char> PublicModifiers = new Dictionary<int, char>();
        public static List<Note> PublicNoteDetails = new List<Note>();

        public string Name { get; set; }
        public int midiNumber { get; private set; }
        public int offset { get; private set; }
        public string[] noteArray { get; private set; }

        public Note(int midiNumber, string[] noteArray) {
            this.midiNumber = midiNumber;
            this.noteArray = noteArray;
        }

        public static void SetModifiers() { 
            PublicModifiers.Add(-1, 'b');
            PublicModifiers.Add(0, ' ');
            PublicModifiers.Add(1, '#');
        }
        public static void SetNoteDetails() {
            PublicNoteDetails.Add(new Note(60, new string[] { "C ", "B#", "Dbb" }));
            PublicNoteDetails.Add(new Note(49, new string[] { "C#", "Db" }));
            PublicNoteDetails.Add(new Note(50, new string[] { "D ", "C##", "Ebb" }));
            PublicNoteDetails.Add(new Note(51, new string[] { "D#", "Eb", "Fbb" }));

            PublicNoteDetails.Add(new Note(52, new string[] { "E ", "Fb", "D##" }));
            PublicNoteDetails.Add(new Note(53, new string[] { "F ", "E#", "Gbb" }));
            PublicNoteDetails.Add(new Note(54, new string[] { "F#", "Gb" }));
            PublicNoteDetails.Add(new Note(55, new string[] { "G ", "F##", "Abb" }));

            PublicNoteDetails.Add(new Note(56, new string[] { "G#", "Ab" }));
            PublicNoteDetails.Add(new Note(57, new string[] { "A ", "G##", "Bbb" }));
            PublicNoteDetails.Add(new Note(58, new string[] { "A#", "Bb", "Cbb" }));
            PublicNoteDetails.Add(new Note(59, new string[] { "B ", "Cb", "A##" }));
        }

        public static List<Note> GetScale(string rootNoteName, int[] steps)
        {

            Note rootNote = GetNoteDetails(rootNoteName);
            List<Note> notesInOrder = GetAllNotesInOrder(rootNote);
            List<Note> detailScale = new List<Note>();//7
            for (int i = 0; i < steps.Length-1; i++)
            {
                detailScale.Add(notesInOrder[steps[i]]);
            }

            List<Note> tmpScale = new List<Note>(); //12

            char currentLetter = rootNoteName[0];

            foreach (Note tmpNoteDetails in detailScale)
            {
                foreach (String currentNote in tmpNoteDetails.noteArray)
                {
                    if (currentNote[0] == currentLetter)
                    {

                        tmpScale.Add(tmpNoteDetails);
                        tmpScale.ElementAt(tmpScale.Count-1).Name = currentNote;
                    }
                }
                if (currentLetter.Equals('G'))
                {
                    currentLetter = 'A';
                }
                else
                {
                    currentLetter = (Char)(Convert.ToUInt16(currentLetter) + 1);
                }
            }
           
            return tmpScale;
        }

        public static Note GetNoteDetails(string noteStr)
        {
            foreach (Note currentNote in PublicNoteDetails)
            {
                foreach (string noteName in currentNote.noteArray)
                {
                    if (noteStr == noteName)
                    {
                        return currentNote;
                    }
                }
            }
            return null;
        }

        public static List<Note> GetAllNotesInOrder(Note rootNote)
        {
            List<Note> tmpNotes = PublicNoteDetails;
            int shiftValue = 0;

            foreach (Note note in PublicNoteDetails)
            {                
                if (rootNote.midiNumber == note.midiNumber)
                {
                    break;
                }
                shiftValue++;
            }

            for (int i = 0; i < shiftValue; i++)
            {
                Note tmpNote = tmpNotes[0];
                tmpNotes.RemoveAt(0);
                tmpNotes.Add(tmpNote);
            }
            return tmpNotes;
        }

        public static List<Note> RecalculateScale(string note,string selectedMode)
        {
            return GetScale(note, Chord.GetAbsoluteSteps(selectedMode));
        }

        public static List<Note> GetCircleOfFifths(Note passedNote)
        {
            List<Note> circle = new List<Note>();

            circle.Add(passedNote);

            for (int i = 1; i < 12; i++)
            {
                Note tmpLast = circle.Last();
                Note tmpSeventh = GetAllNotesInOrder(tmpLast).ElementAt(7);
                circle.Add(tmpSeventh);
            }

            return circle;
        }

        public static List<Note> RotateCircleOfFifths(List<Note> circleOfFifths, int offset)
        {
            List<Note> newCircle = circleOfFifths;
 
            for (int i = 0; i < offset; i++)
            {
                Note tmpNote = newCircle[0];
                newCircle.RemoveAt(0);
                newCircle.Add(tmpNote);
            }

            return newCircle;

        }
    }
    
}
