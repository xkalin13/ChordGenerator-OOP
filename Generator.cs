using System;
using System.Collections.Generic;
using System.Linq;
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


        Random rnd = new Random();

        private char selectedRootNote;
        private char selectedModifier;
        private string selectedMode;
        private List<int> selectedProgression;

        public static List<Note> scale;

        public List<List<Chord>> alternativeProgressions;
        public List<Chord> chordsInKey;
        public List<Chord> mainProgression;

        public Generator() { }
        public void RandomizeProgression()
        {
            Console.WriteLine("getRandomizedProgression");
            selectedRootNote = Note.publicRootNotes.ElementAt(getRandomItem(Note.publicRootNotes.Length));
            selectedModifier = Note.publicModifiers.ElementAt(getRandomItem(Note.publicModifiers.Count)).Value;
            selectedMode = Chord.publicModes.ElementAt(getRandomItem(Chord.publicModes.Count)).Name;
            selectedProgression = Chord.publicProgressions.ElementAt(getRandomItem(Chord.publicProgressions.Count)).Value.ToList();
        }
        public string[] GetProgressionInfo()
        {
            string mood = "";

            foreach (var item in Chord.publicProgressions) {
                if (Enumerable.SequenceEqual(item.Value, selectedProgression)) {
                    mood = item.Key;
                }
            }

            return new string[] { 
                selectedRootNote.ToString(),
                selectedModifier.ToString(),
                selectedMode,
                mood };

        }
        public int getRandomItem(int length)
        {
            return rnd.Next(0, length);
        }
        public void GenerateChordProgression(string rootNote, string modifier, string mode, string progression)
        {
            Console.WriteLine("GenerateChordProgression");
       
            SetValues(rootNote[0], modifier[0], mode, progression);

            scale = Note.RecalculateScale(selectedRootNote.ToString() + selectedModifier, selectedMode);
            chordsInKey = Chord.RecalculateAllChordsInKey(selectedMode, scale);
            mainProgression = Chord.RecalculateMainProgression(selectedProgression,chordsInKey);

            alternativeProgressions = Chord.RecalculateAlternatives(selectedRootNote.ToString() + selectedModifier, selectedMode, selectedProgression);
        }
        public List<Chord> GetChordsInKey() {
            return chordsInKey;
        }


        public void SetValues(char rootNote, char modifier, string mode, string progression)
        {
            Console.WriteLine("Setting values");

            Console.WriteLine("-----base note-----");
            selectedRootNote = rootNote;
            Console.WriteLine("-----modificator-----");
            selectedModifier = modifier;
            Console.WriteLine("-----mode-----");
            selectedMode = mode;
            Console.WriteLine("-----progression-based-on-mood-----");
            selectedProgression = Chord.publicProgressions[progression].ToList();

        }
        public string GetChordName(Player.PlayType playType, int passedChordNumber, int passedChordProgression = 0)
        {
            string tempChord;
            if (playType == Player.PlayType.MAIN_CHORDS)
            {
                tempChord = mainProgression[passedChordNumber].name;
            }
            else if (playType == Player.PlayType.ALTERNATIVE_CHORDS)
            {
                tempChord = alternativeProgressions[passedChordProgression][passedChordNumber].name;
            }
            else
            {
                tempChord = chordsInKey[passedChordNumber].name;
            }

            return tempChord;
        }
    }
}