using System;
using System.Collections.Generic;
using System.Text;

namespace ChordGenerator
{
    class Note //notograficky zapis + notamidi & notaarray
    {
        public string RealNoteName { get; }
        public NoteDetails NoteDetails { get; }

        public Note(string realNoteName, NoteDetails noteDetails)
        {
            RealNoteName = realNoteName;
            NoteDetails = noteDetails;
        }

        public string prettifyNoteStr(string passedNote)//bere zakladni notu ||| D. a vraci string D
        {
            Console.WriteLine("prettifyNoteStr");
            string RealNoteName = passedNote;

            for (int i = 0; i < noteModifiers.Length; i++)
            {
                //pro 3 znamenka
                NoteModifiers tmpNoteModifier = noteModifiers[i];

                if (RealNoteName.Contains(tmpNoteModifier.HelpSign.ToString()))//je tam znamenko?
                {
                    // replace v  "C." '.' za  ' '
                    RealNoteName = RealNoteName.Replace(tmpNoteModifier.HelpSign.ToString(), tmpNoteModifier.PreSign.ToString());

                    break;//z foru
                }
            }

            return RealNoteName;
        }
        public Note[] notesInChord(Chord passedChord)
        {

            int baseNoteIndex = -1;
            Note[] tmpScaleNotes = actualScaleNotes;//mistni actualScaleNotes
            for (int i = 0; i < tmpScaleNotes.Length; i++)
            {
                Note tmpScaleNote = tmpScaleNotes[i];
                if (tmpScaleNote.NoteDetails.MidiNumber == passedChord.BaseNoteDetails.MidiNumber)
                {
                    baseNoteIndex = i;
                    break;
                }
            }

            if (baseNoteIndex >= 0)
            {
                // get [0, 2, 4] 
                Note[] notesInChord = new Note[3];

                //prvni nota je base
                notesInChord[0] = tmpScaleNotes[baseNoteIndex];

                int secondNote = baseNoteIndex + 2;
                if (secondNote >= tmpScaleNotes.Length)
                {
                    secondNote -= tmpScaleNotes.Length;
                }
                //druha nota je vypoctena 0 + 2noty
                notesInChord[1] = actualScaleNotes[secondNote];


                int thirdNote = baseNoteIndex + 4;
                if (thirdNote >= tmpScaleNotes.Length)
                {
                    thirdNote -= tmpScaleNotes.Length;
                }
                //treti nota je 0+4noty
                notesInChord[2] = tmpScaleNotes[thirdNote];

                return notesInChord;
            }
            else
            {
                Console.WriteLine("OFF-KEY");

                NoteDetails[] allNotes = getAllNotesInOrder(passedChord.BaseNoteDetails);
                Note[] formattedNotes = new Note[3];
                NoteDetails[] notesInChord = new NoteDetails[3];
                //nota je mimo stupnici 

                notesInChord[0] = allNotes[0];
                notesInChord[1] = allNotes[4];
                notesInChord[2] = allNotes[7];

                int indexer = 0;

                for (int i = 0; i < notesInChord.Length; i++)
                {
                    NoteDetails tmpNote = notesInChord[i];

                    for (int j = 0; j < tmpNote.NoteArray.Length; j++)
                    {
                        string noteVal = tmpNote.NoteArray[j];

                        if (passedChord.ChordName[0] == noteVal[0])
                        {
                            formattedNotes[indexer] = new Note(prettifyNoteStr(noteVal), tmpNote);
                            indexer++;
                            break;//vyskoci z prvniho foru
                        }
                    }
                    if (indexer <= i)// neni plny
                    {
                        string noteVal = tmpNote.NoteArray[0];
                        string name = prettifyNoteStr(noteVal);
                        formattedNotes[indexer] = new Note(name, tmpNote);
                        indexer++;
                    }
                }

                return formattedNotes;
            }
        }
        public NoteDetails[] getAllNotesInOrder(NoteDetails rootNoteDetails)
        {
            Console.WriteLine("getAllNotesInOrder");

            //pole tonu =  midi+jmenatonu
            NoteDetails[] orderedNotes = new NoteDetails[noteDetails.Length];

            for (int i = 0; i < noteDetails.Length; i++)//projede vsechny noty a zacne vkladat notu do noveho poleNot az teprve od prvniho tonu |G | = G A B C---
            {

                NoteDetails note = noteDetails[i];

                //pokud se shoduje midi z konkretni noty a zakladni noty
                if (note.MidiNumber == rootNoteDetails.MidiNumber)//pokud preskoci vrati se na zacatek k |C|
                {
                    int startIndex = i;
                    int j = 0;
                    while (j < noteDetails.Length)//kolikata celkova nota pole not to je 
                    {

                        int trueIndex = startIndex + j;
                        // pokud pretece pole odecte se delka aby se jelo znovu

                        if (trueIndex >= noteDetails.Length)
                        {
                            trueIndex -= noteDetails.Length;
                        }

                        orderedNotes[j] = noteDetails[trueIndex];
                        j++;
                    }
                    break;
                    // nasel midiNumber
                }
            }
            return orderedNotes;
        }
        public Note[] getScale(string rootNoteName, int[] steps)//vrati pole not spravne zapsanych s midi num podle poradi
        {
            Console.WriteLine("getScale");

            NoteDetails rootNoteDetails = getNoteDetails(rootNoteName);//vraci  jednu notu - midi cislo a array stringumena tonu 
            NoteDetails[] notesInOrder = getAllNotesInOrder(rootNoteDetails);// seradi noty ve stupnici ||| Ddur =  D D# E F F# G G# A A# B C C#


            // pole not tonin
            NoteDetails[] detailScale = new NoteDetails[7];//todo 12

            for (int i = 0; i < steps.Length; i++)
            {
                //vlozi noty ze stupnice do pole ale pouze ty ktere tam patri pomoci krokovani||| Ddur =  D E F F# G A B C#
                detailScale[i] = notesInOrder[steps[i]];
            }

            Note[] tmpScale = new Note[7]; //todo 12 CDEFGAHC

            char currentLetter = rootNoteName[0];// prvni pismeno = ze stringu jmena tonu           

            for (int i = 0; i < detailScale.Length; i++)// pro vsechny nazvy tonu
            {

                NoteDetails tmpNoteDetails = detailScale[i]; //nota z toniny podle poradi

                for (int j = 0; j < detailScale[i].NoteArray.Length; j++)
                {
                    string currentNote = tmpNoteDetails.NoteArray[j];

                    if (currentNote[0] == currentLetter)
                    {
                        //pokud je nazev tonu z pole nazvu == tonu ze stringu, vlozi ton s lepsim jmenem do stupnice
                        string RealNoteNameStr = prettifyNoteStr(currentNote);

                        tmpScale[i] = new Note(RealNoteNameStr, tmpNoteDetails);//prida notu do pole not s hezkym jmenem
                    }

                }
                // inkrementace - posouvame se od pismena v abecede dale
                // C D E F G | A B ------C D E F G | A B -------C
                if (currentLetter.Equals('G'))
                {
                    // otoceni abecedy na zacatek
                    currentLetter = 'A';
                }
                else
                {
                    //inkrement abecedne pomoci ascii tabulky  a+1=b b+1=c
                    currentLetter = (Char)(Convert.ToUInt16(currentLetter) + 1);
                }
            }
            return tmpScale;
        }


    }
}
