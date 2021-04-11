﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ChordGenerator
{
    class Player
    {

        private void PlayNote(int note, int volume = 127)
        {

            if (playing)
            {
                return;
            }
            outDevice.Send(new ChannelMessage(ChannelCommand.NoteOn, 0, note, volume));
        }
     
        public void PlayProgression(PlayType playType, int alternativeProgressionId = 0)
        {


            for (int i = 0; i < 4; i++)//akordy
            {
                //bass
                PlayBass(i, playType, alternativeProgressionId);
                PlayChord(i, playType, alternativeProgressionId);
                Thread.Sleep(1000);
            }
        }



        public int playNote(int passedChordNumber, int passedNoteNumber, PlayType playType, int passedChordProgression = 0)
        {
            Note[] tempNote;



            if (playType == PlayType.MAIN_CHORDS)
            {
                tempNote = playMainChord(passedChordNumber);
            }
            else if (playType == PlayType.KEY_CHORDS)
            {
                tempNote = playKeyChord(passedChordNumber);
            }
            else if (playType == PlayType.ALTERNATIVE_CHORDS)
            {
                tempNote = playAlternativeChord(passedChordNumber, passedChordProgression);
            }
            else
            {
                tempNote = null;
            }
            return tempNote[passedNoteNumber].NoteDetails.MidiNumber;
        }
        public Note[] playMainChord(int passedChordNumber)
        {
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

    }
}
