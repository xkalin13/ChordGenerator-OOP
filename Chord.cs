using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ChordGenerator
{
    public class Chord
    {
        public struct Mode
        {
            public string Name { get; }
            public int Offset { get; }
            public int[] StepsToNext { get; }
            public string[] ChordType { get; }
            public Mode(string name, int offset, int[] stepsToNext, string[] chordType)
            {
                Name = name;
                Offset = offset;
                StepsToNext = stepsToNext;
                ChordType = chordType;
            }
        }

        public string name;

        public List<Note> chordNotes;
        public Note baseNote;
        public Mode chordType;

        public Chord(string name,Note baseNote, List<Note> chordNotes) {
            this.name = name;
            this.baseNote = baseNote;
            this.chordNotes = chordNotes;

        }

        public static readonly Dictionary<String, int[]> publicProgressions = new Dictionary<String, int[]>();
        public static readonly List<Mode> publicModes = new List<Mode>();
        public static void SetProgressions()
        {
            publicProgressions.Add("Alternative", new int[] { 5, 3, 0, 4 });
            publicProgressions.Add("Nostalgy", new int[] { 0, 0, 3, 5 });
            publicProgressions.Add("Cliché", new int[] { 0, 4, 5, 3 });
            publicProgressions.Add("Basic", new int[] { 0, 5, 2, 6 });
            publicProgressions.Add("Strange", new int[] { 0, 5, 3, 4 });
            publicProgressions.Add("Weird", new int[] { 0, 5, 1, 4 });
            publicProgressions.Add("Never Ending", new int[] { 0, 5, 1, 3 });
            publicProgressions.Add("Energy", new int[] { 0, 2, 3, 5 });
            publicProgressions.Add("Extra", new int[] { 0, 3, 2, 5 });
            publicProgressions.Add("Memories", new int[] { 0, 3, 0, 4 });
            publicProgressions.Add("Riot", new int[] { 3, 0, 3, 4 });
            publicProgressions.Add("Sad", new int[] { 0, 3, 4, 4 });
        }
        public static void SetModes()
        {
            publicModes.Add(new Mode("major", 3, new int[] { 2, 2, 1, 2, 2, 2, 1 }, new string[] { "", "m", "m", "", "", "m", "dim" }));
            publicModes.Add(new Mode("minor", 9, new int[] { 2, 1, 2, 2, 1, 2, 2 }, new string[] { "m", "dim", "", "m", "m", "", "" }));
        }
        public static List<Chord> GetProgressionFromBaseAndMode(string rootNote, string mode, List<int> mood)
        {
            Mode tmpMode = publicModes.Find(x => x.Name == mode);

            int[] absSteps = GetAbsoluteSteps(mode);
            List<Note> tmpScale = Note.GetScale(rootNote, absSteps);

            List<Chord> chordsInKey = new List<Chord>();

            for (int i = 0; i < tmpScale.Count; i++)
            {
                chordsInKey.Add(new Chord(tmpScale[i].name + tmpMode.ChordType[i], tmpScale[i],Chord.GetChordNotes(tmpScale,i)));
            } 

            return GetProgression(mood, chordsInKey);
        }

        
        public static List<Chord> GetProgression(List<int> mood, List<Chord> chordsInKey)
        {
            List<Chord> actualChordProgression = new List<Chord>();
            for (int i = 0; i < mood.Count; i++)
            {
                actualChordProgression.Add(chordsInKey[mood[i]]);
            }
            return actualChordProgression;
        }
        public static List<Chord> RecalculateAllChordsInKey(string modeName, List<Note> scale)
        {
            Mode tmpMode = publicModes.Find(x => x.Name == modeName);

            List<Chord> tmpChordsInKey = new List<Chord>();

            for (var i = 0; i < 7; i++)
            {
                //name /mode /details
                tmpChordsInKey.Add(new Chord(
                        scale[i].name + tmpMode.ChordType[i],
                        scale[i],
                        Chord.GetChordNotes(scale,i)
                        ));
            }
           return tmpChordsInKey;
        }
        public static int[] GetAbsoluteSteps(string modeName)
        {
            Mode tmpMode = publicModes.Find(x => x.Name == modeName);

            int[] absoluteSteps = new int[8];
            int rollingTotal = 0;

            for (int i = 0; i < tmpMode.StepsToNext.Length; i++)
            {
                absoluteSteps[i] = rollingTotal;
                rollingTotal += tmpMode.StepsToNext[i];
            }

            return absoluteSteps;
        }
        public static List<Chord> RecalculateMainProgression(List<int> mood, List<Chord> chordsInKey)
        {
            Console.WriteLine("recalculateMainProgression");
            return GetProgression(mood, chordsInKey);
            
        }
        public static List<List<Chord>> RecalculateAlternatives(string note, string mode, List<int> mood)
        {
            List<List<Chord>> tempAlternativeProgression = new List<List<Chord>>();

            Note rootNoteDetails = Note.GetNoteDetails(note);
            List<Note> orderedNotes = Note.GetAllNotesInOrder(rootNoteDetails);

            // kvinotvy kruh
            List<Note> circleOfFifths = Note.GetCircleOfFifths(rootNoteDetails);

            // otocit kruh
            int offset = publicModes.Find(x => x.Name == mode).Offset;

            List<Note> innerCircle = Note.RotateCircleOfFifths(Note.GetCircleOfFifths(rootNoteDetails), offset);

            string oppositeMode = publicModes.Find(x => x.Name != mode).Name;

            //opacny mode
            tempAlternativeProgression.Add(GetProgressionFromBaseAndMode(innerCircle[0].noteArray[0], oppositeMode, mood));
            // +1 rotace
            tempAlternativeProgression.Add(GetProgressionFromBaseAndMode(circleOfFifths[1].noteArray[0], mode, mood));
            // -1 rotace
            tempAlternativeProgression.Add(GetProgressionFromBaseAndMode(circleOfFifths[11].noteArray[0], mode, mood));

            return tempAlternativeProgression;
        }
        public List<Note> GetChord() {
            return chordNotes;
        }
        public static List<Note> GetChordNotes(List<Note> scale, int baseNoteIndex)
        {

            List<Note> tmpScaleNotes = scale;

            List<Note> notesInChord = new List<Note>();

            for (int i = 0; i < 3; i++)
            {
                notesInChord.Add(tmpScaleNotes[baseNoteIndex]);
                baseNoteIndex += 2;

                if (baseNoteIndex >= scale.Count)
                {
                    baseNoteIndex -= scale.Count;
                }
            }
            return notesInChord;

        }

    }
}
