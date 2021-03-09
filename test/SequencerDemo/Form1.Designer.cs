using Sanford.Multimedia.Midi;

namespace SequencerDemo
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.generateChords = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mIDIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outputDeviceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMidiFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.pianoControl1 = new Sanford.Multimedia.Midi.UI.PianoControl();
            this.sequence1 = new Sanford.Multimedia.Midi.Sequence();
            this.sequencer1 = new Sanford.Multimedia.Midi.Sequencer();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.chord1 = new System.Windows.Forms.Button();
            this.chord2 = new System.Windows.Forms.Button();
            this.chord3 = new System.Windows.Forms.Button();
            this.chord4 = new System.Windows.Forms.Button();
            this.key = new System.Windows.Forms.ComboBox();
            this.modificator = new System.Windows.Forms.ComboBox();
            this.mood = new System.Windows.Forms.ComboBox();
            this.mode = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.playbutton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // generateChords
            // 
            this.generateChords.Location = new System.Drawing.Point(286, 109);
            this.generateChords.Name = "generateChords";
            this.generateChords.Size = new System.Drawing.Size(137, 23);
            this.generateChords.TabIndex = 1;
            this.generateChords.Text = "GenerateChords";
            this.generateChords.UseVisualStyleBackColor = true;
            this.generateChords.Click += new System.EventHandler(this.generateChords_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mIDIToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mIDIToolStripMenuItem
            // 
            this.mIDIToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.outputDeviceToolStripMenuItem});
            this.mIDIToolStripMenuItem.Name = "mIDIToolStripMenuItem";
            this.mIDIToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.mIDIToolStripMenuItem.Text = "&MIDI";
            // 
            // outputDeviceToolStripMenuItem
            // 
            this.outputDeviceToolStripMenuItem.Name = "outputDeviceToolStripMenuItem";
            this.outputDeviceToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.outputDeviceToolStripMenuItem.Text = "Output Device...";
            this.outputDeviceToolStripMenuItem.Click += new System.EventHandler(this.outputDeviceToolStripMenuItem_Click);
            // 
            // openMidiFileDialog
            // 
            this.openMidiFileDialog.DefaultExt = "mid";
            this.openMidiFileDialog.Filter = "MIDI files|*.mid|All files|*.*";
            this.openMidiFileDialog.Title = "Open MIDI file";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 439);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // pianoControl1
            // 
            this.pianoControl1.HighNoteID = 109;
            this.pianoControl1.Location = new System.Drawing.Point(0, 344);
            this.pianoControl1.LowNoteID = 21;
            this.pianoControl1.Name = "pianoControl1";
            this.pianoControl1.NoteOnColor = System.Drawing.Color.SkyBlue;
            this.pianoControl1.Size = new System.Drawing.Size(784, 92);
            this.pianoControl1.TabIndex = 5;
            this.pianoControl1.Text = "pianoControl1";
            this.pianoControl1.PianoKeyDown += new System.EventHandler<Sanford.Multimedia.Midi.UI.PianoKeyEventArgs>(this.pianoControl1_PianoKeyDown);
            this.pianoControl1.PianoKeyUp += new System.EventHandler<Sanford.Multimedia.Midi.UI.PianoKeyEventArgs>(this.pianoControl1_PianoKeyUp);
            // 
            // sequence1
            // 
            this.sequence1.Format = 1;
            // 
            // sequencer1
            // 
            this.sequencer1.Position = 0;
            this.sequencer1.Sequence = this.sequence1;
            this.sequencer1.PlayingCompleted += new System.EventHandler(this.HandlePlayingCompleted);
            this.sequencer1.ChannelMessagePlayed += new System.EventHandler<Sanford.Multimedia.Midi.ChannelMessageEventArgs>(this.HandleChannelMessagePlayed);
            this.sequencer1.SysExMessagePlayed += new System.EventHandler<Sanford.Multimedia.Midi.SysExMessageEventArgs>(this.HandleSysExMessagePlayed);
            this.sequencer1.Chased += new System.EventHandler<Sanford.Multimedia.Midi.ChasedEventArgs>(this.HandleChased);
            this.sequencer1.Stopped += new System.EventHandler<Sanford.Multimedia.Midi.StoppedEventArgs>(this.HandleStopped);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // chord1
            // 
            this.chord1.Location = new System.Drawing.Point(164, 209);
            this.chord1.Name = "chord1";
            this.chord1.Size = new System.Drawing.Size(75, 23);
            this.chord1.TabIndex = 7;
            this.chord1.Text = "button1";
            this.chord1.UseVisualStyleBackColor = true;
            // 
            // chord2
            // 
            this.chord2.Location = new System.Drawing.Point(260, 209);
            this.chord2.Name = "chord2";
            this.chord2.Size = new System.Drawing.Size(75, 23);
            this.chord2.TabIndex = 8;
            this.chord2.Text = "button1";
            this.chord2.UseVisualStyleBackColor = true;
            // 
            // chord3
            // 
            this.chord3.Location = new System.Drawing.Point(361, 209);
            this.chord3.Name = "chord3";
            this.chord3.Size = new System.Drawing.Size(75, 23);
            this.chord3.TabIndex = 9;
            this.chord3.Text = "button1";
            this.chord3.UseVisualStyleBackColor = true;
            // 
            // chord4
            // 
            this.chord4.Location = new System.Drawing.Point(457, 209);
            this.chord4.Name = "chord4";
            this.chord4.Size = new System.Drawing.Size(75, 23);
            this.chord4.TabIndex = 10;
            this.chord4.Text = "button1";
            this.chord4.UseVisualStyleBackColor = true;
            // 
            // key
            // 
            this.key.FormattingEnabled = true;
            this.key.Items.AddRange(new object[] {
            "C",
            "D",
            "E",
            "F",
            "G",
            "A",
            "B"});
            this.key.Location = new System.Drawing.Point(164, 72);
            this.key.Name = "key";
            this.key.Size = new System.Drawing.Size(45, 21);
            this.key.TabIndex = 11;
            // 
            // modificator
            // 
            this.modificator.FormattingEnabled = true;
            this.modificator.Items.AddRange(new object[] {
            " ",
            "#",
            "♭ "});
            this.modificator.Location = new System.Drawing.Point(255, 72);
            this.modificator.Name = "modificator";
            this.modificator.Size = new System.Drawing.Size(45, 21);
            this.modificator.TabIndex = 12;
            // 
            // mood
            // 
            this.mood.FormattingEnabled = true;
            this.mood.Items.AddRange(new object[] {
            "Alternative",
            "Canon",
            "Cliché",
            "Cliché 2"});
            this.mood.Location = new System.Drawing.Point(461, 72);
            this.mood.Name = "mood";
            this.mood.Size = new System.Drawing.Size(102, 21);
            this.mood.TabIndex = 13;
            // 
            // mode
            // 
            this.mode.FormattingEnabled = true;
            this.mode.Items.AddRange(new object[] {
            "major",
            "minor"});
            this.mode.Location = new System.Drawing.Point(340, 72);
            this.mode.Name = "mode";
            this.mode.Size = new System.Drawing.Size(57, 21);
            this.mode.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(166, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Key";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(253, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Modificator";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(363, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Mode";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(500, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Mood";
            // 
            // playbutton
            // 
            this.playbutton.Location = new System.Drawing.Point(286, 300);
            this.playbutton.Name = "playbutton";
            this.playbutton.Size = new System.Drawing.Size(137, 23);
            this.playbutton.TabIndex = 19;
            this.playbutton.Text = "PlayProgression";
            this.playbutton.UseVisualStyleBackColor = true;
            this.playbutton.Click += new System.EventHandler(this.playbutton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(457, 253);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 23;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(361, 253);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 22;
            this.button2.Text = "button1";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(260, 253);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 21;
            this.button3.Text = "button1";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(164, 253);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 20;
            this.button4.Text = "button1";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(457, 161);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 27;
            this.button5.Text = "button1";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(361, 161);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 26;
            this.button6.Text = "button1";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(260, 161);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 25;
            this.button7.Text = "button1";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(164, 161);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 24;
            this.button8.Text = "button1";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.playbutton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mode);
            this.Controls.Add(this.mood);
            this.Controls.Add(this.modificator);
            this.Controls.Add(this.key);
            this.Controls.Add(this.chord4);
            this.Controls.Add(this.chord3);
            this.Controls.Add(this.chord2);
            this.Controls.Add(this.chord1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pianoControl1);
            this.Controls.Add(this.generateChords);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "CHORD GENERATOR";
            //default values
            this.key.SelectedItem = "C";
            this.modificator.SelectedItem = " ";
            this.mode.SelectedItem = "major";
            this.mood.SelectedItem = "Cliché";

            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button generateChords;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.OpenFileDialog openMidiFileDialog;
        private Sanford.Multimedia.Midi.UI.PianoControl pianoControl1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripMenuItem mIDIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem outputDeviceToolStripMenuItem;
        private Sequence sequence1;
        private Sequencer sequencer1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button chord1;
        private System.Windows.Forms.Button chord2;
        private System.Windows.Forms.Button chord3;
        private System.Windows.Forms.Button chord4;
        private System.Windows.Forms.ComboBox key;
        private System.Windows.Forms.ComboBox modificator;
        private System.Windows.Forms.ComboBox mood;
        private System.Windows.Forms.ComboBox mode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button playbutton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
    }
}

