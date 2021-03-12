using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using Sanford.Multimedia.Midi;
using SequencerDemo;
namespace ChordGenerator
{

    public partial class Generator
    {

        public string[] randomizeProgression()
        {
            Console.WriteLine("randomizeProgression");
            actualBaseNote = baseNotes[getRandomItem(baseNotes.Length)];
            actualNoteModifier = noteModifiers[getRandomItem(noteModifiers.Length)];
            actualMode = chordModes[getRandomItem(chordModes.Length)];
            actualChordProgression = chordProgressions[getRandomItem(chordProgressions.Length)];

            return new string[] { actualBaseNote.ToString(), actualNoteModifier.PreSign.ToString(), actualMode.Name.ToString(), actualChordProgression.Name.ToString() };
        }
        public void recalculateScale()
        {
            Console.WriteLine("recalculateScale");
            actualScaleNotes = getScale(actualBaseNote.ToString() + actualNoteModifier.HelpSign.ToString(), getAbsoluteSteps(actualMode));
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
        public int getRandomItem(int length)
        {
            return rnd.Next(0, length);
        }
        public NoteDetails getNoteDetails(string noteStr)//vrati konretni popis noty podle zadane noty
        {
            Console.WriteLine("getNoteDetails");

            NoteDetails tempOrderedNotes = new NoteDetails();

            for (int i = 0; i < noteDetails.Length; i++)
            {
                //zvoli notu kazdy cyklus
                NoteDetails currentNote = noteDetails[i];
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
        public Chord[] getProgressionFromBaseAndMode(string passedRootNote, Mode passedMode)
        {
            int[] absSteps = getAbsoluteSteps(passedMode);
            Note[] tmpScale = getScale(passedRootNote, absSteps);

            Chord[] chordsInKey = new Chord[tmpScale.Length];//pole akordu ve stupnici

            for (var i = 0; i < tmpScale.Length; i++)//7 udela akordy ze stupnice
            {
                //name /mode /details
                Console.WriteLine("scalerNameChord " + tmpScale[i].RealNoteName + passedMode.ChordType[i].Symbol);

                chordsInKey[i] = new Chord(tmpScale[i].RealNoteName + passedMode.ChordType[i].Symbol, passedMode.ChordType[i], tmpScale[i].NoteDetails);
            }

            return getProgression(actualChordProgression, chordsInKey);
        }
        public Chord[] getProgression(Progressions progressionDetails, Chord[] chordsInKey)
        {
            Chord[] actualChordProgression = new Chord[progressionDetails.Steps.Length];//pole akordu ktere vezme stupnici a vezme jen ty ktere maji kadenci
            for (int i = 0; i < progressionDetails.Steps.Length; i++)
            {
                int step = progressionDetails.Steps[i];//projede pole kadenci 
                actualChordProgression[i] = chordsInKey[step];//vrati ktery tempChord je na kroku step 
            }
            return actualChordProgression;
        }
        public void recalculateAllChordsInKey()//cdefgab
        {
            Chord[] tmpChordsInKey = new Chord[chordTypeBuilder1.Length];

            for (var i = 0; i < allChordsInKey.Length; i++)
            {
                //name /mode /details
                tmpChordsInKey[i] = new Chord(
                        actualScaleNotes[i].RealNoteName + actualMode.ChordType[i].Symbol, 
                        actualMode.ChordType[i],
                        actualScaleNotes[i].NoteDetails
                        );
            }
            //getProgressionFromBaseAndMode();
            allChordsInKey = tmpChordsInKey;
        }
        public void recalculateMainProgression()
        {
            Console.WriteLine("recalculateMainProgression");
            string rootNoteName = actualBaseNote.ToString() + actualNoteModifier.HelpSign.ToString();//string D-
            Chord[] actualChordProgression = getProgressionFromBaseAndMode(rootNoteName, actualMode);//vklada string a
            mainProgression = actualChordProgression;
        }
        public void GenerateChordProgression(string passedKey, string passedMode, string passedModificator, string passedProgression)
        {
            Console.WriteLine("GenerateChordProgression");
            AssignVars();//inicializace dat            
            setValues(passedKey[0], passedModificator[0], passedMode, passedProgression);//prvni char ze stringu

            recalculateScale();
            recalculateAllChordsInKey();
            recalculateMainProgression();
            recalculateAlternatives();
        }
        public void playProgression()
        {
            for (int i = 0; i < mainProgression.Length; i++)//za kazdy tempChord
            {
                var chord = mainProgression[i];
                Note[] tempChord = notesInChord(chord);

                foreach (var note in tempChord)
                {
                    //playNote(chord.BaseNoteDetails.MidiNumber);
                    //scaler[i].RealNoteName + mode.ChordType[i].Symbol, mode.ChordType[i]
                    //Console.WriteLine(note.RealNoteName + note.NoteDetails.MidiNumber);
                }//za kazdou notu z akordu
            }
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
        public void recalculateAlternatives()
        {
            Chord[][] tempAlternativeProgression = new Chord[3][];

            NoteDetails rootNoteDetails = getNoteDetails(actualBaseNote.ToString() + actualNoteModifier.HelpSign.ToString());
            NoteDetails[] orderedNotes = getAllNotesInOrder(rootNoteDetails);

            // kvinotvy kruh
            NoteDetails[] circleOfFifths = getCircleOfFifths(rootNoteDetails);

            // otocit kruh
            NoteDetails[] innerCircle = rotateCircleOfFifths(circleOfFifths, actualMode.InnerOffset);
            //molovy zaklad

            Mode oppositeMode = new Mode();

            for (int i = 0; i < chordModes.Length; i++)
            {
                if (chordModes[i].Name == actualMode.OpositeMode)
                {
                    oppositeMode = chordModes[i];
                }
            }

            tempAlternativeProgression[0] = getProgressionFromBaseAndMode(innerCircle[0].NoteArray[0], oppositeMode);//tady

            // +1 a -1 rotation
            string[] bases = { circleOfFifths[1].NoteArray[0], circleOfFifths[circleOfFifths.Length - 1].NoteArray[0] };
            for (int i = 0; i < bases.Length; i++)
            {
                tempAlternativeProgression[i + 1] = getProgressionFromBaseAndMode(bases[i], actualMode);
            }

            alternativeChordProgressions = tempAlternativeProgression;
        }
        public string getChordName(int passedChordProgression, int passedChordNumber)
        {
            string tempChord;
            if (passedChordProgression == 0)
            {
                tempChord = mainProgression[passedChordNumber].ChordName;
            }
            else
            {                           //3        //4
                tempChord = alternativeChordProgressions[passedChordProgression - 1][passedChordNumber].ChordName;
            }
            return tempChord;
        }
        public string[] getChordsInKey()
        {
            string[] tempChordName = new string[7];

            for (int i = 0; i < tempChordName.Length; i++)
            {
                tempChordName[i] += allChordsInKey[i].ChordName;
            }

            return tempChordName;
        }
        public int getKeyChord(int id)
        {

            return allChordsInKey[id].BaseNoteDetails.MidiNumber;
        }
        public int playNote(int passedChordNumber, int passedNoteNumber, PlayType playType, int passedChordProgression=0) {
            Note[] tempNote;

            if (playType == PlayType.MAIN_CHORDS) {
                tempNote = playMainChord(passedChordNumber);
            }
            else if (playType == PlayType.KEY_CHORDS)
            {
                tempNote = playKeyChord(passedChordNumber);
            }
            else if (playType == PlayType.ALTERNATIVE_CHORDS)
            {
                tempNote = playAlternativeChord(passedChordNumber,passedChordProgression);
            }
            else {
                tempNote = null;
            }
            return tempNote[passedNoteNumber].NoteDetails.MidiNumber;
        }
        public Note[] playMainChord(int passedChordNumber) { 
            return notesInChord(mainProgression[passedChordNumber]);
        }
        public Note[] playKeyChord(int passedChordNumber)
        {
            return notesInChord(allChordsInKey[passedChordNumber]);
        }
        public Note[] playAlternativeChord(int passedChordNumber, int passedChordProgression)
        {
            return notesInChord(alternativeChordProgressions[passedChordProgression][passedChordNumber]);
        }



    }
}