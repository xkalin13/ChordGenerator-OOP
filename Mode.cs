using System;
using System.Collections.Generic;
using System.Text;

namespace ChordGenerator
{
    class Mode
    {
        // jmeno modu & offset kruhu & opacny mod & kroky actualChordProgression & pole typu akordu
        
        public string Name { get; }
        public int InnerOffset { get; }
        public string OpositeMode { get; }
        public int[] StepsToNext { get; }
        public Chord.ChordType[] ChordType { get; }
        public Mode(string name, int innerOffset, string opositeMode, int[] stepsToNext, ChordType[] chordType)
        {
            Name = name;
            InnerOffset = innerOffset;
            OpositeMode = opositeMode;
            StepsToNext = stepsToNext;
            ChordType = chordType;
        }
        public int[] getAbsoluteSteps(Mode passedMode)
        {
            int[] absoluteSteps = new int[passedMode.StepsToNext.Length];
            int rollingTotal = 0;
            for (int i = 0; i < passedMode.StepsToNext.Length; i++)
            {
                absoluteSteps[i] = rollingTotal;
                rollingTotal += passedMode.StepsToNext[i];
            }
            return absoluteSteps;
        }

    }
}
