using System;
using System.Collections.Generic;
using System.Text;

namespace ChordGenerator
{
    public class NoteModifier
    {
        public string Name { get; }
        public int Offset { get; }
        public char HelpSign { get; }
        public char PreSign { get; }

        public NoteModifier(string name, int offset, char sign, char modify)
        {
            Name = name;
            Offset = offset;
            HelpSign = sign;
            PreSign = modify;
        }
    }
}
