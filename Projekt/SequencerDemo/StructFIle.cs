using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChordGenerator
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
    public struct Chord //jmeno +dur/mol + detail not
    {
        public string ChordName { get; private set; }
        public ChordType Mode { get; private set; }
        public NoteDetails BaseNoteDetails { get; private set; }

        public Chord(string chordName, ChordType mode, NoteDetails details)
        {
            ChordName = chordName;
            Mode = mode;
            BaseNoteDetails = details;
        }
    }
    public struct Note //notograficky zapis + notamidi & notaarray
    {
        public string RealNoteName { get; }
        public NoteDetails NoteDetails { get; }

        public Note(string realNoteName, NoteDetails noteDetails)
        {
            RealNoteName = realNoteName;
            NoteDetails = noteDetails;
        }
    }
    public struct NoteModifiers //jmeno & offset od tonu & znamenko pomocne & znamenko noty
    {
        public string Name { get; }
        public int Offset { get; }
        public char HelpSign { get; }
        public char PreSign { get; }

        public NoteModifiers(string name, int offset, char sign, char modify)
        {
            Name = name;
            Offset = offset;
            HelpSign = sign;
            PreSign = modify;
        }
    }
    public struct NoteDetails //cislo midi & pole nazvu noty
    {
        public int MidiNumber { get; set; }
        public string[] NoteArray { get; set; }
        public NoteDetails(int midiNumber, string[] noteArray)
        {
            MidiNumber = midiNumber;
            NoteArray = noteArray;
        }
    }
    public struct Mode // jmeno modu & offset kruhu & opacny mod & kroky actualChordProgression & pole typu akordu
    {
        public string Name { get; }
        public int InnerOffset { get; }
        public string OpositeMode { get; }
        public int[] StepsToNext { get; }
        public ChordType[] ChordType { get; }
        public Mode(string name, int innerOffset, string opositeMode, int[] stepsToNext, ChordType[] chordType)
        {
            Name = name;
            InnerOffset = innerOffset;
            OpositeMode = opositeMode;
            StepsToNext = stepsToNext;
            ChordType = chordType;
        }
    }
    public struct Progressions
    {
        public string Name { get; }
        public int[] Steps { get; }

        public Progressions(String name, int[] steps)
        {
            Name = name;
            Steps = steps;
        }
    }
}
