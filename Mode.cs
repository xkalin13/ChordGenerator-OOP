namespace ChordGenerator
{
    public class Mode { 
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
}
