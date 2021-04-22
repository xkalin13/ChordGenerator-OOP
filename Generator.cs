using System;
using System.Collections.Generic;
using System.Linq;
namespace ChordGenerator
{

    public partial class Generator
    {

        private Random RandomNum = new Random();

        private char SelectedRootNote;
        private char SelectedModifier;
        private string SelectedMode;
        private List<int> SelectedProgression;

        private List<Note> Scale;
        public List<List<Chord>> AlternativeProgressions { get; private set; }
        public List<Chord> ChordsInKey { get; private set; }
        public List<Chord> MainProgression { get; private set; }

        public Generator() { }
        public void RandomizeProgression()
        {
            SelectedRootNote = Note.PublicRootNotes.ElementAt(getRandomItem(Note.PublicRootNotes.Length));
            SelectedModifier = Note.PublicModifiers.ElementAt(getRandomItem(Note.PublicModifiers.Count)).Value;
            SelectedMode = Chord.PublicModes.ElementAt(getRandomItem(Chord.PublicModes.Count)).Name;
            SelectedProgression = Chord.PublicProgressions.ElementAt(getRandomItem(Chord.PublicProgressions.Count)).Value.ToList();
        }
        public string[] GetProgressionInfo()
        {
            string mood = "";

            foreach (var item in Chord.PublicProgressions) {
                if (Enumerable.SequenceEqual(item.Value, SelectedProgression)) {
                    mood = item.Key;
                }
            }

            return new string[] { 
                SelectedRootNote.ToString(),
                SelectedModifier.ToString(),
                SelectedMode,
                mood };

        }
        public int getRandomItem(int length)
        {
            return RandomNum.Next(0, length);
        }
        public void GenerateChordProgression(string rootNote, string modifier, string mode, string progression)
        {
      
            SetValues(rootNote[0], modifier[0], mode, progression);

            this.Scale = Note.RecalculateScale(SelectedRootNote.ToString() + SelectedModifier, SelectedMode);
            
            this.ChordsInKey = Chord.RecalculateAllChordsInKey(SelectedMode,Scale);
            this.MainProgression = Chord.RecalculateMainProgression(SelectedProgression,ChordsInKey);
            this.AlternativeProgressions = Chord.RecalculateAlternatives(SelectedRootNote.ToString() + SelectedModifier, SelectedMode, SelectedProgression);
        }
        public List<Chord> GetChordsInKey() {
            return ChordsInKey;
        }


        public void SetValues(char rootNote, char modifier, string mode, string progression)
        {

            SelectedRootNote = rootNote;
            SelectedModifier = modifier;
            SelectedMode = mode;
            SelectedProgression = Chord.PublicProgressions[progression].ToList();

        }
        public string GetChordName(Player.PlayType playType, int passedChordNumber, int passedChordProgression = 0)
        {
            string tempChord;
            if (playType == Player.PlayType.Main)
            {
                tempChord = MainProgression[passedChordNumber].Name;
            }
            else if (playType == Player.PlayType.Alternative)
            {
                tempChord = AlternativeProgressions[passedChordProgression][passedChordNumber].Name;
            }
            else
            {
                tempChord = ChordsInKey[passedChordNumber].Name;
            }

            return tempChord;
        }

    }
}