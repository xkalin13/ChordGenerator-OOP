using System;
using System.Collections.Generic;
using System.Text;

namespace ChordGenerator
{

    public class NoteDetails //jmeno & offset od tonu & znamenko pomocne & znamenko noty
    {
        public int MidiNumber { get; set; }
        public string[] NoteArray { get; set; }

        public NoteDetails(int midiNumber, string[] noteArray)
        {
            MidiNumber = midiNumber;
            NoteArray = noteArray;
        }

        public NoteDetails()
        {

        }

        public static NoteDetails GetNoteDetails(string noteStr)//vrati konretni popis noty podle zadane noty
        {
            Console.WriteLine("getNoteDetails");

            NoteDetails tempOrderedNotes = new NoteDetails();

            for (int i = 0; i < noteDetails.Length; i++)
            {
                //zvoli notu kazdy cyklus
                NoteDetails currentNote =  noteDetails[i];
                //projede pole s nazvy tonu
                for (int j = 0; j < currentNote.NoteArray.Length; j++)
                {
                    //pokud je tento ton = tonu ze stringu 
                    string currentNoteVal = currentNote.NoteArray[j];
                    if (currentNoteVal == noteStr)
                    {
                        //zjisti ve kterem poli je vybrana nota a vrati konkretni notu z pole not
                        tempOrderedNotes = currentNote;
                        break;
                    }
                }
                if (tempOrderedNotes.MidiNumber > 10)
                {
                    //kdyby detail uz byl vlozen vyskoci
                    break;
                }
            }

            return tempOrderedNotes;
        }


        public NoteDetails[] getCircleOfFifths(NoteDetails passedNote)
        {
            // podle referencni noty vytvori kvintovy kruh
            NoteDetails[] circle = new NoteDetails[12];
            circle[0] = passedNote;
            for (int i = 1; i < circle.Length; i++)
            {
                NoteDetails[] sevenFifths = getAllNotesInOrder(circle[i - 1]);
                circle[i] = sevenFifths[7];
            }

            return circle;
        }
        public NoteDetails[] rotateCircleOfFifths(NoteDetails[] circleOfFifths, int passedOffset)
        {
            NoteDetails[] newCircle = new NoteDetails[circleOfFifths.Length];

            for (int i = 0; i < circleOfFifths.Length; i++)//projede kruh
            {
                if (passedOffset == circleOfFifths.Length)
                {
                    passedOffset = 0;
                }
                newCircle[i] = circleOfFifths[passedOffset];
                passedOffset++;

            }
            return newCircle;
        }

    }

}
