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
        public NoteDetails Details { get; private set; }

        public Chord(string chordName, ChordType mode, NoteDetails details)
        {
            ChordName = chordName;
            Mode = mode;
            Details = details;
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
        public char Sign { get; }
        public char Modify { get; }

        public NoteModifiers(string name, int offset, char sign, char modify)
        {
            Name = name;
            Offset = offset;
            Sign = sign;
            Modify = modify;
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
    public struct Mode // jmeno modu & offset kruhu & opacny mod & kroky progression & pole typu akordu
    {
        public string Name { get; }
        public int InnerOffset { get; }
        public string OpositeMode { get; }
        public int[] StepsToNext { get; }
        public ChordType[] ChordType { get; }
        public Mode(string name, int innerOffset, string opositeMode, int[] stepToNext, ChordType[] chordType)
        {
            Name = name;
            InnerOffset = innerOffset;
            OpositeMode = opositeMode;
            StepsToNext = stepToNext;
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
public class Generator
    {


 
        //Vars & instances
        public static NoteModifiers[] NoteModifiers = new NoteModifiers[3];
        public static NoteDetails[] detailNoty = new NoteDetails[12];
        public static Mode[] Mode = new Mode[2];
        public static Progressions[] Progressions = new Progressions[15];

        public static char[] baseNotes = new char[] { 'C', 'D', 'E', 'F', 'G', 'A', 'B' };
        public NoteModifiers noteModifier = NoteModifiers[1];
        public Progressions progression = Progressions[2];
        public Mode mode;//TODO check
        public char baseNote = baseNotes[0];
        ChordType[] ChordTypes1 = new ChordType[7];
        ChordType[] ChordTypes2 = new ChordType[7];
        public void setValues(char key, char modificator,string modeVal, string cadence)
        {
            Console.WriteLine("set values");

            //nastaveni key
            Console.WriteLine("base index "+ Array.IndexOf(baseNotes, key));

            baseNote = baseNotes[Array.IndexOf(baseNotes, key)];

            Console.WriteLine("base note: "+baseNote);

            //nastaveni modifikatoru
            for (int i = 0; i < NoteModifiers.Length; i++)//3
            {
                Console.WriteLine("NoteModifiers.Sign: " + NoteModifiers[i].Sign);
                Console.WriteLine("NoteModifiers i: " + i);
                if (NoteModifiers[i].Modify == modificator)//kdyz je meno stejne jako mode ze vstupu
                {
                    Console.WriteLine("NoteModifiers se rovna " + NoteModifiers[i].Modify + " : " + modificator);
                    noteModifier = NoteModifiers[i];
                    break;//z loopu
                }
            }

            //nastaveni mode
            for (int i = 0; i < Mode.Length; i++)
            {
                Console.WriteLine("Mode.Name: "+Mode[i].Name);
                Console.WriteLine("mode i: " + i);
                if (Mode[i].Name.Contains(modeVal))//kdyz je meno stejne jako mode ze vstupu
                {
                    Console.WriteLine("Mode se rovna " + Mode[i].Name+" : "+modeVal);
                    mode = Mode[i];
                    Console.WriteLine("Mode je---------- " + mode.Name + " : oposite-" + mode.OpositeMode);
                    break;//z loopu
                }
                
            }

            //nastaveni cadence
            for (int i = 0; i < Progressions.Length; i++)
            {
                Console.WriteLine("Progressions.Name: " + Progressions[i].Name);
                Console.WriteLine("Progressions i: " + i);
                if (Progressions[i].Name.Equals(cadence))//kdyz je jmeno kadence stejne jako progress
                {
                    Console.WriteLine("Progressions se rovna " + Progressions[i].Name + " : " + cadence);
                    progression = Progressions[i];
                    break;//z loopu
                }

            }



        }


        Random rnd = new Random();
        public void AssignVars()//done
        {
            Console.WriteLine("ASSIGN");
            //modifiery
            Console.WriteLine("ASSIGN-modifier");
            NoteModifiers[0] = new NoteModifiers("flat", -1, '-', 'b');
            NoteModifiers[1] = new NoteModifiers("natural", 0, '.', ' ');
            NoteModifiers[2] = new NoteModifiers("sharp", 1, '+', '#');

            //noty stupnice
            Console.WriteLine("ASSIGN-noteDetail 1-4");
            detailNoty[0] = new NoteDetails(60, new string[] { "C.", "B+", "D--" });
            detailNoty[1] = new NoteDetails(61, new string[] { "C+", "D-" });
            detailNoty[2] = new NoteDetails(62, new string[] { "D.", "C++", "E--" });
            detailNoty[3] = new NoteDetails(63, new string[] { "D+", "E-", "F--" });
            Console.WriteLine("ASSIGN-noteDetail 5-8");
            detailNoty[4] = new NoteDetails(64, new string[] { "E.", "F-", "D++" });
            detailNoty[5] = new NoteDetails(65, new string[] { "F.", "E+", "G--" });
            detailNoty[6] = new NoteDetails(66, new string[] { "F+", "G-" });
            detailNoty[7] = new NoteDetails(67, new string[] { "G.", "F++", "A--" });
            Console.WriteLine("ASSIGN-noteDetail 9-12");
            detailNoty[8] = new NoteDetails(68, new string[] { "G+", "A-" });
            detailNoty[9] = new NoteDetails(69, new string[] { "A.", "G++", "B--" });
            detailNoty[10] = new NoteDetails(70, new string[] { "A+", "B-", "C--" });
            detailNoty[11] = new NoteDetails(71, new string[] { "B.", "C-", "A++" });


            //Mody
            Console.WriteLine("ASSIGN-mody");
            

            //DUR
            Console.WriteLine("ASSIGN-dur");
            ChordTypes1[0] = new ChordType("major", "");
            ChordTypes1[1] = new ChordType("minor", "m");
            ChordTypes1[2] = new ChordType("minor", "m");
            ChordTypes1[3] = new ChordType("major", "");

            ChordTypes1[4] = new ChordType("major", "");
            ChordTypes1[5] = new ChordType("minor", "m");
            ChordTypes1[6] = new ChordType("diminished", "dim");
            Console.WriteLine("ASSIGN-dur-Mode");
            Mode[0] = new Mode("major", 3, "minor", new int[] { 2, 2, 1, 2, 2, 2, 1 }, ChordTypes1);
            Console.WriteLine("******************" + Mode[0].ChordType);
            //MOLL
            Console.WriteLine("ASSIGN-moll");
            ChordTypes2[0] = new ChordType("minor", "m");
            ChordTypes2[1] = new ChordType("diminished", "dim");
            ChordTypes2[2] = new ChordType("major", "");
            ChordTypes2[3] = new ChordType("minor", "m");
            ChordTypes2[4] = new ChordType("minor", "m");

            ChordTypes2[5] = new ChordType("major", "");
            ChordTypes2[6] = new ChordType("major", "");
            
            Console.WriteLine("ASSIGN-moll-mode");

            Mode[1] = new Mode("minor", 9, "major", new int[] { 2, 1, 2, 2, 1, 2, 2 }, ChordTypes2);
            Console.WriteLine("******************" + Mode[1].ChordType);
            //kadence
            Console.WriteLine("ASSIGN-progression");

            Progressions[0] = new Progressions("Alternative", new int[] { 5, 3, 0, 4 });
            Progressions[1] = new Progressions("Canon", new int[] { 0, 4, 5, 2, 3, 0, 3, 4 });
            Progressions[2] = new Progressions("Cliché", new int[] { 0, 4, 5, 3 });
            Progressions[3] = new Progressions("Cliché 2", new int[] { 0, 5, 2, 6 });
            Progressions[4] = new Progressions("Creepy", new int[] { 0, 5, 3, 4 });
            Progressions[5] = new Progressions("Creepy 2", new int[] { 0, 5, 1, 4 });
            Progressions[6] = new Progressions("Endless", new int[] { 0, 5, 1, 3 });
            Progressions[7] = new Progressions("Energetic", new int[] { 0, 2, 3, 5 });
            Progressions[8] = new Progressions("Grungy", new int[] { 0, 3, 2, 5 });
            Progressions[9] = new Progressions("Memories", new int[] { 0, 3, 0, 4 });
            Progressions[10] = new Progressions("Rebellious", new int[] { 3, 0, 3, 4 });
            Progressions[11] = new Progressions("Sad", new int[] { 0, 3, 4, 4 });
            Progressions[12] = new Progressions("Twelve Bar Blues", new int[] { 0, 0, 0, 0, 3, 3, 0, 0, 4, 3, 0, 4 });
            Progressions[13] = new Progressions("Wistful", new int[] { 0, 0, 3, 5 });

        }
        public void randomizeProgression()//done
        {

            noteModifier = NoteModifiers[randomItem(NoteModifiers.Length)];
            progression = Progressions[randomItem(Progressions.Length)];
            baseNote = baseNotes[randomItem(baseNotes.Length)];
            //mode = Mode[randomItem(Mode.Length)];
        }

        Note[] scale = new Note[7];//obsahuje spravne zapsane noty s midi podle poradi

        public void recalculateScale()//done
        {
            Console.WriteLine("generate scale");
            scale = getScale(baseNote.ToString() + noteModifier.Sign.ToString(), getAbsoluteSteps(mode));
        }

        public int[] getAbsoluteSteps(Mode mode)//done
        {
            int[] absoluteSteps = new int[mode.StepsToNext.Length];
            var rollingTotal = 0;
            for (var i = 0; i < mode.StepsToNext.Length; i++)
            {
                absoluteSteps[i] = rollingTotal;
                rollingTotal += mode.StepsToNext[i];
            }
            return absoluteSteps;
        }

        public int randomItem(int length)//done
        {
            return rnd.Next(0, length);
        }

        Chord[] keyChords = new Chord[7];//TODO DELKA

        //todo alternativy        
        public NoteDetails getNoteDetails(string noteStr) {//vrati konretni popis noty podle zadane noty
            Console.WriteLine("getNoteDetails");
            NoteDetails notyVporadi = new NoteDetails();

            for (var i = 0; i < detailNoty.Length; i++){
                //zvoli notu kazdy cyklus
                var currentNote = detailNoty[i];
                //projede pole s nazvy tonu
                for (var j = 0; j < currentNote.NoteArray.Length; j++){
                    //pokud je tento ton = tonu ze stringu 
                    var currentNoteVal = currentNote.NoteArray[j];
                    if (currentNoteVal == noteStr){
                        //zjisti ve kterem poli je vybrana nota a vrati konkretni notu z pole not
                        notyVporadi = currentNote;
                        break;
                    }
                }
                Console.WriteLine(notyVporadi.MidiNumber);
                if (!notyVporadi.MidiNumber.Equals(null)){
                    //kdyby detail uz byl vlozen vyskoci
                    break;
                }
            }
 
            return notyVporadi;
        }
   
        public NoteDetails[] getAllNotesInOrder(NoteDetails rootNoteDetails){ //pole tonu =  midi+jmenatonu
            Console.WriteLine("getAllNotesInOrder");
            NoteDetails[] orderedNotes = new NoteDetails[detailNoty.Length];
            
            for (var i = 0; i < detailNoty.Length; i++)//projede vsechny noty a zacne vkladat notu do noveho poleNot az teprve od prvniho tonu |G | = G A B C---
            {

                NoteDetails note = detailNoty[i];
                //Console.WriteLine("rootNoteDetails: " + rootNoteDetails.MidiNumber);
                //Console.WriteLine("NoteDetails[i]: " + note.MidiNumber);
                //pokud se shoduje midi z konkretni noty a zakladni noty
                if (note.MidiNumber == rootNoteDetails.MidiNumber)//pokud preskoci vrati se na zacatek k |C|
                {
                    //Console.WriteLine(note.MidiNumber+" tedka hodnota se rovna root "+ rootNoteDetails.MidiNumber);
                    int startIndex = i; 
                    int j = 0;                    
                    while (j < detailNoty.Length)//kolikata celkova nota pole not to je 
                    {

                        var trueIndex = startIndex + j;
                        // pokud pretece pole odecte se delka aby se jelo znovu

                        if (trueIndex >= detailNoty.Length)
                        {
                            trueIndex -= detailNoty.Length;
                        }

                        orderedNotes[j] = detailNoty[trueIndex];
                        //Console.WriteLine("[i]  " + i+j);
                        //Console.WriteLine("orderedNotes[i]  "+ orderedNotes[i].MidiNumber);
                        //orderedNotes[i].len = NoteDetails[trueIndex].len;//todo nebere to delku len
                        j++;
                    }
                    //Console.WriteLine("break");
                    break;
                    // nasel midiNumber
                }
            }
            for (int i = 0; i < 12; i++)
            {
                Console.WriteLine("---"+ orderedNotes[i].NoteArray.Length);
            }
            return orderedNotes;
        }
    
        public string prettifyNoteStr(string note)//bere zakladni notu ||| D. a vraci string D
        {
            Console.WriteLine("prettifyNoteStr");
            string RealNoteName = note;

            for (var i = 0; i < NoteModifiers.Length; i++){//pro 3 znamenka
                var noteModifier = NoteModifiers[i];
                Console.WriteLine("Sign=="+ NoteModifiers[i].Sign +" nota: "+ RealNoteName);
                //The method returns -1 if the character or string is not found in this instance.
                if (RealNoteName.Contains(NoteModifiers[i].Sign.ToString()))//je tam znamenko?
                {// replace v  "C." '.' za  ' '
                    Console.WriteLine("noteModifier.Sign: " + noteModifier.Sign);
                    Console.WriteLine("noteModifier.Modify: " + noteModifier.Modify.ToString());
                    RealNoteName=RealNoteName.Replace(noteModifier.Sign.ToString(), noteModifier.Modify.ToString());
                    
                    Console.WriteLine("new STRING: " + RealNoteName);
                    break;//z foru
                }
            }

            return RealNoteName;
        }
           
        public Note[] getScale(string rootNoteStr, int[] steps)//vrati pole not spravne zapsanych s midi num podle poradi
        {
            Console.WriteLine("getScale");
            // This will return an array of notes representing a scale.
            // baseNote and returned notes should be something like "C+", "C-" or "C."
            // absoluteSteps is a 0-based array of notes.
            

            NoteDetails rootNoteDetails = getNoteDetails(rootNoteStr);//vraci  jednu notu - midi cislo a array stringumena tonu 
            //Console.WriteLine("roooot"+rootNoteDetails.MidiNumber);
            NoteDetails[] notesInOrder = getAllNotesInOrder(rootNoteDetails);// seradi noty ve stupnici ||| Ddur =  D D# E F F# G G# A A# B C C#
            

            // pole not tonin
            //Console.WriteLine("NoteDetails.Length: "+ NoteDetails.Length);
            NoteDetails[] detailScale = new NoteDetails[7];//todo 12
            Console.WriteLine("--------------"+ notesInOrder.Length);
            for (int i = 0; i < 12; i++)
            {
                Console.WriteLine("notesInOrder " + notesInOrder[i].MidiNumber);
            }
            for (var i = 0; i < steps.Length; i++)
            {
                //vlozi noty ze stupnice do pole ale pouze ty ktere tam patri pomoci krokovani||| Ddur =  D E F F# G A B C#
               
               
               // Console.WriteLine("notesInOrder len: " + notesInOrder[steps[i]].len);
                //Console.WriteLine(i+" < " + steps.Length);
                //Console.WriteLine(notesInOrder[steps[i]].NoteArray + " v indexu steps[i]" + steps[i]);
                detailScale[i] = notesInOrder[steps[i]];
                


            }
            /*foreach (var item in detailScale)
            {
                Console.WriteLine("Delka: "+item.NoteArray.Length); /7x3
            }*/
            //Console.WriteLine("notograficky-NoteDetails.Length"+ NoteDetails.Length);
            // notograficky spravny zapis vsech not stupnice.
            Console.WriteLine("++++++++" + detailScale.Length);
            Note[] strScale = new Note[7]; //todo 12 CDEFGAHC

            var currentLetter = rootNoteStr[0];// prvni pismeno = ze stringu jmena tonu           

            Console.WriteLine("-------------------------------------------------");
            for (var i = 0; i < detailScale.Length; i++){// pro vsechny nazvy tonu
                Console.WriteLine("i+: " + i);
                NoteDetails noteDetailse = detailScale[i]; //nota z toniny podle poradi
                Console.WriteLine("Delka aktualniho pole stringu "+ detailScale[i].NoteArray.Length);
                //TODO
                for (var j = 0; j < detailScale[i].NoteArray.Length; j++){//3
                    //Console.WriteLine("noteDetailse.NoteArray[j] " + noteDetailse.NoteArray[j]);
                    var noteStr = noteDetailse.NoteArray[j];

                    if (noteStr[0] == currentLetter)
                    {
                        //Console.WriteLine("jsem vevnitr s indexem" + j);
                        //pokud je nazev tonu z pole nazvu == tonu ze stringu, vlozi ton s lepsim jmenem do stupnice
                        string RealNoteNameStr = prettifyNoteStr(noteStr);

                        strScale[i] = new Note(RealNoteNameStr, noteDetailse);//prida notu do pole not s hezkym jmenem
                        Console.WriteLine("Scale " + strScale[j].RealNoteName);
                    }
                    
                }
                // inkrementace - posouvame se od pismena v abecede dale
                // C D E F G | A B ------C D E F G | A B -------C
                if (currentLetter.Equals('G')){
                    // otoceni abecedy na zacatek
                    currentLetter = 'A';
                }
                else{
                    //inkrement abecedne pomoci ascii tabulky  a+1=b b+1=c
                    currentLetter = (Char)(Convert.ToUInt16(currentLetter) + 1);
                    Console.WriteLine("currentLetter " + currentLetter);
                }
            }
            Console.WriteLine("pocet in str"+strScale.Length);
            foreach (var item in strScale)
            {
                Console.WriteLine("currentLetter " + item.RealNoteName);
            }
            return strScale;
        }

        public Chord[] getProgressionFromBaseAndMode(string rootNote, Mode mode)
        {
            int[] absSteps = getAbsoluteSteps(mode);
            Note[] scaler = getScale(rootNote, absSteps);//vrati 7

            Chord[] chordsInKey = new Chord[scaler.Length];//pole akordu ve stupnici
            Console.WriteLine("scale.Length " + scaler.Length);
            for (var i = 0; i < scaler.Length; i++)//7 udela akordy ze stupnice 7x
            {
                //name /mode /details
                Console.WriteLine("scalerNameChord " + scaler[i].RealNoteName);
                Console.WriteLine("scalertype " + mode.ChordType[i].Symbol);
                Console.WriteLine("scalerNameChord " + scaler[i].NoteDetails);
                chordsInKey[i] = new Chord(scaler[i].RealNoteName + mode.ChordType[i].Symbol, mode.ChordType[i], scaler[i].NoteDetails);
            }

            return getProgression(progression, chordsInKey);
        }

    
        public Chord[] getProgression(Progressions progressionDetails, Chord[] chordsInKey)
        {
            Console.WriteLine("POOOOOOOOOOOCET KADENCI" + progressionDetails.Steps.Length);
            Chord[] progression = new Chord[progressionDetails.Steps.Length];//pole akordu ktere vezme stupnici a vezme jen ty ktere maji kadenci
            for (var i = 0; i < progressionDetails.Steps.Length; i++)
            {//podle poctu akordu
                var step = progressionDetails.Steps[i];//projede pole kadenci 
                progression[i] = chordsInKey[step];//vrati ktery akord je na kroku step 
            }
            return progression;
        }

        
        public void recalculateAllChordsInKey()//cdefgab
        {
            Console.WriteLine("recalculateAllChordsInKey");
            Console.WriteLine("ChordTypes " + ChordTypes1.Length);
            Console.WriteLine("--------------------------------------");
            Chord[] allChordsInKey = new Chord[ChordTypes1.Length];

            for (var i = 0; i < allChordsInKey.Length; i++)
            {
                //name /mode /details
                /*Console.WriteLine("scale[i].RealNoteName "+ scale[i].RealNoteName);
                Console.WriteLine("mode.ChordType[i].Symbol "+ mode.ChordType[i].Symbol.ToString());
                Console.WriteLine("mode.ChordType[i] " + mode.ChordType[i].ToString());
                Console.WriteLine("scale[i].NoteDetails " + scale[i].NoteDetails.ToString());*/

                allChordsInKey[i] = new Chord(scale[i].RealNoteName + mode.ChordType[i].Symbol, mode.ChordType[i], scale[i].NoteDetails);
            }
            keyChords = allChordsInKey;
            foreach (var item in keyChords)
            {
                Console.WriteLine("KEYCHORD:   " + item.ChordName);
            }
        }
        
        Chord[] mainProgression = new Chord[4];// pole 4 akordu = progression
        public void recalculateMainProgression()
        {
            Console.WriteLine("recalculateMainProgression");
            string rootNoteStr = baseNote.ToString() + noteModifier.Sign.ToString();//string D-
            Chord[] progression = getProgressionFromBaseAndMode(rootNoteStr, mode);//vklada string a
            Console.WriteLine("progression n"+ progression.ToString());
            mainProgression = progression;

            // $scope.mainProgression = $scope.getProgression($scope.progression, $scope.allChordsInKey);
        }

        public void GenerateChordProgression(string key, string mode, string modificator, string cadence)
        {
            Console.WriteLine("generate chord");
            AssignVars();//inicializace dat

            
            setValues(key[0], modificator[0], mode, cadence);//prvni char ze stringu
            Console.WriteLine("---------------");
            recalculateScale();
            recalculateAllChordsInKey();
            recalculateMainProgression();
            
            //recalculateAlternatives();
            playProgression();

        }
        public void playProgression() {
            Console.WriteLine("play progression");
            Console.WriteLine("mainProgression.Length "+ mainProgression.Length);
            for (int i = 0; i < mainProgression.Length; i++)//za kazdy akord
            {
                var chord = mainProgression[i];
                Note[] akord = notesInChord(chord);

                foreach (var note in akord)
                {
                    //playNote(chord.Details.MidiNumber);
                    //scaler[i].RealNoteName + mode.ChordType[i].Symbol, mode.ChordType[i]
                    Console.WriteLine(note.RealNoteName + note.NoteDetails.MidiNumber);
                }//za kazdou notu z akordu
                
            }
        
        }
        public int playNote(int kolikakord,int koliknota) {

            Note[] akord= notesInChord(mainProgression[kolikakord]);
            return akord[koliknota].NoteDetails.MidiNumber;
            //outDevice.Send(new ChannelMessage(ChannelCommand.NoteOn, 0, id, 127));

        }
        public Note[] notesInChord(Chord chord)
        {

            var baseNoteIndex = -1;
            var scaler = scale;//mistni scale
            for (var i = 0; i < scaler.Length; i++)
            {
                var note = scale[i];
                if (note.NoteDetails.MidiNumber == chord.Details.MidiNumber)
                {
                    baseNoteIndex = i;
                    break;
                }
            }

            if (baseNoteIndex >= 0)
            {
                // get [0, 2, 4] of $scope.scale, starting at base note
                Note[] notesInChord = new Note[3];

                //prvni nota je bass
                notesInChord[0]=scaler[baseNoteIndex];
                Console.WriteLine("notesInChord[0"+ notesInChord[0].RealNoteName);
                var second = baseNoteIndex + 2;
                if (second >= scaler.Length)
                {
                    second = second - scaler.Length;
                }
                //druha nota je vypoctena 0 + 2noty
                notesInChord[1] = scaler[second];
                Console.WriteLine("notesInChord[1" + notesInChord[1].RealNoteName);
                var third = baseNoteIndex + 4;
                if (third >= scaler.Length)
                {
                    third = third - scaler.Length;
                }
                //treti nota je 0+4noty
                notesInChord[2] = scaler[third];
                Console.WriteLine("notesInChord[2]" + notesInChord[2].RealNoteName);
                return notesInChord;
            }
            else
            {
                Console.WriteLine("PLNSSSSSS");
                return null;
                //return []; // this is weird.

                // If the base note _isn't_ found, we've got an off-key chord.
                // get [0, 4, 7] of allNotes

                //var allNotes = $scope.getAllNotesInOrder(chord.baseNote);
/*
                Note[] notesInChord = new Note[3];
                notesInChord.push(allNotes[0]);
                notesInChord.push(allNotes[4]);
                notesInChord.push(allNotes[7]);

                var formattedNotes = [];

                for (var i = 0; i < notesInChord.length; i++)
                {
                    var note = notesInChord[i];
                    for (var j = 0; j < note.vals.length; j++)
                    {
                        var noteVal = note.vals[j];
                        if (chord.name.charAt(0) === noteVal.charAt(0))
                        {
                            /*var name = $scope.prettifyNoteStr(noteVal);
                            formattedNotes.push({
                            name: name,
                            details: note
                            });
                            break;
                        }
                    }
                    if (formattedNotes.length <= i) {
                        var noteVal = note.vals[0];
                        var name = $scope.prettifyNoteStr(noteVal);
                        f/*ormattedNotes.push({
                            name: name,
                            details: note
                         });
                    }
                }

                return formattedNotes;*/
            }
        }
        public int getNumberChords() {
            return mainProgression.Length;
        }
    }
}
