using System;
using System.Collections.Generic;
using System.Text;

namespace ChordGenerator
{
    class NoteModifier
    {
        public NoteModifiers(string name, int offset, char sign, char modify)
        {
            Name = name;
            Offset = offset;
            HelpSign = sign;
            PreSign = modify;
        }
    }
}
