using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChordGenerator
{
    public enum PlayType
    {
        KEY_CHORDS,
        MAIN_CHORDS,
        ALTERNATIVE_CHORDS
    };
    public partial class DataSetters
    {

        
        //Vars & instances
        Random rnd = new Random();
        public NoteModifier[] noteModifiers = new NoteModifier[3];
        public NoteDetails[] noteDetails = new NoteDetails[12];
        public Mode[] chordModes = new Mode[2];
        public Progression[] chordProgressions = new Progression[12];
        public char[] baseNotes = new char[] { 'C', 'D', 'E', 'F', 'G', 'A', 'B' };


        private NoteModifier actualNoteModifier = new NoteModifier();
        private Progression actualChordProgression = new Progression();
        private Mode actualMode = new Mode();
        public char actualBaseNote;
        private Note[] actualScaleNotes = new Note[12];

        private Chord.ChordType[] chordTypeBuilder1 = new Chord.ChordType[7];
        private Chord.ChordType[] chordTypeBuilder2 = new Chord.ChordType[7];
        private Chord[][] alternativeChordProgressions;


        private Chord[] allChordsInKey = new Chord[7];
        private Chord[] mainProgression = new Chord[4];

        public void setValues(char passedKey, char passedModificator, string passedMode, string passedProgression)
        {
            Console.WriteLine("Setting values");

            Console.WriteLine("-----base note-----");
            actualBaseNote = baseNotes[Array.IndexOf(baseNotes, passedKey)];
            Console.WriteLine("-----modificator-----");
            //nastaveni modifikatoru
            for (int i = 0; i < noteModifiers.Length; i++)//3
            {
                if (noteModifiers[i].PreSign == passedModificator)//kdyz je meno stejne jako mode ze vstupu
                {
                    actualNoteModifier = noteModifiers[i];
                    break;//z loopu
                }
            }
            Console.WriteLine("-----mode-----");
            //nastaveni mode
            for (int i = 0; i < chordModes.Length; i++)
            {
                if (chordModes[i].Name.Contains(passedMode))//kdyz je meno stejne jako mode ze vstupu
                {
                    actualMode = chordModes[i];
                    break;//z loopu
                }
            }

            Console.WriteLine("-----progression-based-on-mood-----");
            //nastaveni cadence
            for (int i = 0; i < chordProgressions.Length; i++)
            {
                if (chordProgressions[i].Name.Equals(passedProgression))//kdyz je jmeno kadence stejne jako progress
                {
                    actualChordProgression = chordProgressions[i];
                    break;//z loopu
                }
            }
        }

        public void AssignVars()
        {
            Console.WriteLine("AssignVars");

            //modifiery
            Console.WriteLine("-----modificator-----");
            noteModifiers[0] = new NoteModifier("flat", -1, '-', 'b');
            noteModifiers[1] = new NoteModifier("natural", 0, '.', ' ');
            noteModifiers[2] = new NoteModifier("sharp", 1, '+', '#');

            //noty stupnice
            Console.WriteLine("-----modificator-----");
            noteDetails[0] = new NoteDetails(60, new string[] { "C.", "B+", "D--" });
            noteDetails[1] = new NoteDetails(61, new string[] { "C+", "D-" });
            noteDetails[2] = new NoteDetails(62, new string[] { "D.", "C++", "E--" });
            noteDetails[3] = new NoteDetails(63, new string[] { "D+", "E-", "F--" });

            noteDetails[4] = new NoteDetails(64, new string[] { "E.", "F-", "D++" });
            noteDetails[5] = new NoteDetails(65, new string[] { "F.", "E+", "G--" });
            noteDetails[6] = new NoteDetails(66, new string[] { "F+", "G-" });
            noteDetails[7] = new NoteDetails(67, new string[] { "G.", "F++", "A--" });

            noteDetails[8] = new NoteDetails(68, new string[] { "G+", "A-" });
            noteDetails[9] = new NoteDetails(69, new string[] { "A.", "G++", "B--" });
            noteDetails[10] = new NoteDetails(70, new string[] { "A+", "B-", "C--" });
            noteDetails[11] = new NoteDetails(71, new string[] { "B.", "C-", "A++" });


            //Mody
            Console.WriteLine("-----modes-----");

            //DUR
            chordTypeBuilder1[0] = new Chord.ChordType("major", "");
            chordTypeBuilder1[1] = new Chord.ChordType("minor", "m");
            chordTypeBuilder1[2] = new Chord.ChordType("minor", "m");
            chordTypeBuilder1[3] = new Chord.ChordType("major", "");
            chordTypeBuilder1[4] = new Chord.ChordType("major", "");
            chordTypeBuilder1[5] = new Chord.ChordType("minor", "m");
            chordTypeBuilder1[6] = new Chord.ChordType("diminished", "dim");

            chordModes[0] = new Mode("major", 3, "minor", new int[] { 2, 2, 1, 2, 2, 2, 1 }, chordTypeBuilder1);

            //MOLL
            chordTypeBuilder2[0] = new Chord.ChordType("minor", "m");
            chordTypeBuilder2[1] = new Chord.ChordType("diminished", "dim");
            chordTypeBuilder2[2] = new Chord.ChordType("major", "");
            chordTypeBuilder2[3] = new Chord.ChordType("minor", "m");
            chordTypeBuilder2[4] = new Chord.ChordType("minor", "m");
            chordTypeBuilder2[5] = new Chord.ChordType("major", "");
            chordTypeBuilder2[6] = new Chord.ChordType("major", "");

            chordModes[1] = new Mode("minor", 9, "major", new int[] { 2, 1, 2, 2, 1, 2, 2 }, chordTypeBuilder2);

            //kadence
            Console.WriteLine("-----progressions-----");
            chordProgressions[0] = new Progression("Alternative", new int[] { 5, 3, 0, 4 });
            chordProgressions[1] = new Progression("Nostalgy", new int[] { 0, 0, 3, 5 });
            chordProgressions[2] = new Progression("Cliché", new int[] { 0, 4, 5, 3 });
            chordProgressions[3] = new Progression("Basic", new int[] { 0, 5, 2, 6 });
            chordProgressions[4] = new Progression("Strange", new int[] { 0, 5, 3, 4 });
            chordProgressions[5] = new Progression("Weird", new int[] { 0, 5, 1, 4 });
            chordProgressions[6] = new Progression("Never Ending", new int[] { 0, 5, 1, 3 });
            chordProgressions[7] = new Progression("Energy", new int[] { 0, 2, 3, 5 });
            chordProgressions[8] = new Progression("Extra", new int[] { 0, 3, 2, 5 });
            chordProgressions[9] = new Progression("Memories", new int[] { 0, 3, 0, 4 });
            chordProgressions[10] = new Progression("Riot", new int[] { 3, 0, 3, 4 });
            chordProgressions[11] = new Progression("Sad", new int[] { 0, 3, 4, 4 });

        }
    }
}
