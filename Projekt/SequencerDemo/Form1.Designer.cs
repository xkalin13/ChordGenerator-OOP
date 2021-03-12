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
            if (disposing && (components != null))
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
            this.GenerateChordsBtn = new System.Windows.Forms.Button();
            this.pianoControl1 = new Sanford.Multimedia.Midi.UI.PianoControl();
            this.key = new System.Windows.Forms.ComboBox();
            this.modificator = new System.Windows.Forms.ComboBox();
            this.mood = new System.Windows.Forms.ComboBox();
            this.mode = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.PlayProgressionBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.RandomizeBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.play1 = new System.Windows.Forms.Button();
            this.play2 = new System.Windows.Forms.Button();
            this.play3 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.button21 = new System.Windows.Forms.Button();
            this.button22 = new System.Windows.Forms.Button();
            this.button23 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GenerateChordsBtn
            // 
            this.GenerateChordsBtn.Location = new System.Drawing.Point(571, 74);
            this.GenerateChordsBtn.Name = "GenerateChordsBtn";
            this.GenerateChordsBtn.Size = new System.Drawing.Size(137, 23);
            this.GenerateChordsBtn.TabIndex = 1;
            this.GenerateChordsBtn.Text = "GenerateChords";
            this.GenerateChordsBtn.UseVisualStyleBackColor = true;
            this.GenerateChordsBtn.Click += new System.EventHandler(this.generateChords_Click);
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
            this.key.Location = new System.Drawing.Point(164, 74);
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
            "b"});
            this.modificator.Location = new System.Drawing.Point(253, 74);
            this.modificator.Name = "modificator";
            this.modificator.Size = new System.Drawing.Size(45, 21);
            this.modificator.TabIndex = 12;
            // 
            // mood
            // 
            this.mood.FormattingEnabled = true;
            this.mood.Items.AddRange(new object[] {
            "Alternative",
            "Cliché",
            "Cliché 2",
            "Creepy",
            "Creepy 2",
            "Endless",
            "Energetic",
            "Memories",
            "Rebellious",
            "Sad",
            "Wistful"});
            this.mood.Location = new System.Drawing.Point(434, 74);
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
            this.mode.Location = new System.Drawing.Point(339, 74);
            this.mode.Name = "mode";
            this.mode.Size = new System.Drawing.Size(57, 21);
            this.mode.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Marlett", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(171, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 14);
            this.label1.TabIndex = 15;
            this.label1.Text = "Key";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Marlett", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(250, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 14);
            this.label2.TabIndex = 16;
            this.label2.Text = "Modificator";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Marlett", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(358, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 14);
            this.label3.TabIndex = 17;
            this.label3.Text = "Mode";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Marlett", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(467, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 14);
            this.label4.TabIndex = 18;
            this.label4.Text = "Mood";
            // 
            // PlayProgressionBtn
            // 
            this.PlayProgressionBtn.Location = new System.Drawing.Point(141, 244);
            this.PlayProgressionBtn.Name = "PlayProgressionBtn";
            this.PlayProgressionBtn.Size = new System.Drawing.Size(137, 23);
            this.PlayProgressionBtn.TabIndex = 19;
            this.PlayProgressionBtn.Text = "PlayProgression";
            this.PlayProgressionBtn.UseVisualStyleBackColor = true;
            this.PlayProgressionBtn.Click += new System.EventHandler(this.PlayProgressionBtn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(83, 188);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 25);
            this.button1.TabIndex = 23;
            this.button1.Text = " ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(149, 188);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(50, 25);
            this.button2.TabIndex = 22;
            this.button2.Text = " ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(215, 188);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(50, 25);
            this.button3.TabIndex = 21;
            this.button3.Text = " ";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(284, 188);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(50, 25);
            this.button4.TabIndex = 20;
            this.button4.Text = " ";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // RandomizeBtn
            // 
            this.RandomizeBtn.Location = new System.Drawing.Point(606, 45);
            this.RandomizeBtn.Name = "RandomizeBtn";
            this.RandomizeBtn.Size = new System.Drawing.Size(75, 23);
            this.RandomizeBtn.TabIndex = 24;
            this.RandomizeBtn.Text = "Randomize";
            this.RandomizeBtn.UseVisualStyleBackColor = true;
            this.RandomizeBtn.Click += new System.EventHandler(this.RandomizeBtn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(146, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "MAIN PROGRESSION";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(500, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(194, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "ALTERNATIVE PROGRESSIONS";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(434, 190);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(50, 25);
            this.button5.TabIndex = 30;
            this.button5.Text = " ";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(503, 190);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(50, 25);
            this.button6.TabIndex = 29;
            this.button6.Text = " ";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(571, 190);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(50, 25);
            this.button7.TabIndex = 28;
            this.button7.Text = " ";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(644, 190);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(50, 25);
            this.button8.TabIndex = 27;
            this.button8.Text = " ";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(434, 233);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(50, 25);
            this.button9.TabIndex = 34;
            this.button9.Text = " ";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(503, 233);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(50, 25);
            this.button10.TabIndex = 33;
            this.button10.Text = " ";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(571, 233);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(50, 25);
            this.button11.TabIndex = 32;
            this.button11.Text = " ";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(644, 233);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(50, 25);
            this.button12.TabIndex = 31;
            this.button12.Text = " ";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(434, 280);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(50, 25);
            this.button13.TabIndex = 38;
            this.button13.Text = " ";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(503, 280);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(50, 25);
            this.button14.TabIndex = 37;
            this.button14.Text = " ";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(571, 280);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(50, 25);
            this.button15.TabIndex = 36;
            this.button15.Text = " ";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(644, 280);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(50, 25);
            this.button16.TabIndex = 35;
            this.button16.Text = " ";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // play1
            // 
            this.play1.Font = new System.Drawing.Font("Marlett", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.play1.Location = new System.Drawing.Point(708, 192);
            this.play1.Name = "play1";
            this.play1.Size = new System.Drawing.Size(38, 23);
            this.play1.TabIndex = 43;
            this.play1.Text = "►";
            this.play1.UseVisualStyleBackColor = true;
            this.play1.Click += new System.EventHandler(this.play1_Click);
            // 
            // play2
            // 
            this.play2.Font = new System.Drawing.Font("Marlett", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.play2.Location = new System.Drawing.Point(708, 233);
            this.play2.Name = "play2";
            this.play2.Size = new System.Drawing.Size(38, 23);
            this.play2.TabIndex = 44;
            this.play2.Text = "►";
            this.play2.UseVisualStyleBackColor = true;
            this.play2.Click += new System.EventHandler(this.play2_Click);
            // 
            // play3
            // 
            this.play3.Font = new System.Drawing.Font("Marlett", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.play3.Location = new System.Drawing.Point(708, 282);
            this.play3.Name = "play3";
            this.play3.Size = new System.Drawing.Size(38, 23);
            this.play3.TabIndex = 45;
            this.play3.Text = "►";
            this.play3.UseVisualStyleBackColor = true;
            this.play3.Click += new System.EventHandler(this.play3_Click);
            // 
            // button17
            // 
            this.button17.Location = new System.Drawing.Point(15, 296);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(50, 25);
            this.button17.TabIndex = 49;
            this.button17.Text = " ";
            this.button17.UseVisualStyleBackColor = true;
            this.button17.Click += new System.EventHandler(this.button17_Click);
            // 
            // button18
            // 
            this.button18.Location = new System.Drawing.Point(71, 296);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(50, 25);
            this.button18.TabIndex = 48;
            this.button18.Text = " ";
            this.button18.UseVisualStyleBackColor = true;
            this.button18.Click += new System.EventHandler(this.button18_Click);
            // 
            // button19
            // 
            this.button19.Location = new System.Drawing.Point(128, 296);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(50, 25);
            this.button19.TabIndex = 47;
            this.button19.Text = " ";
            this.button19.UseVisualStyleBackColor = true;
            this.button19.Click += new System.EventHandler(this.button19_Click);
            // 
            // button20
            // 
            this.button20.Location = new System.Drawing.Point(184, 296);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(50, 25);
            this.button20.TabIndex = 46;
            this.button20.Text = " ";
            this.button20.UseVisualStyleBackColor = true;
            this.button20.Click += new System.EventHandler(this.button20_Click);
            // 
            // button21
            // 
            this.button21.Location = new System.Drawing.Point(241, 296);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(50, 25);
            this.button21.TabIndex = 52;
            this.button21.Text = " ";
            this.button21.UseVisualStyleBackColor = true;
            this.button21.Click += new System.EventHandler(this.button21_Click);
            // 
            // button22
            // 
            this.button22.Location = new System.Drawing.Point(297, 296);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(50, 25);
            this.button22.TabIndex = 51;
            this.button22.Text = " ";
            this.button22.UseVisualStyleBackColor = true;
            this.button22.Click += new System.EventHandler(this.button22_Click);
            // 
            // button23
            // 
            this.button23.Location = new System.Drawing.Point(353, 296);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(50, 25);
            this.button23.TabIndex = 50;
            this.button23.Text = " ";
            this.button23.UseVisualStyleBackColor = true;
            this.button23.Click += new System.EventHandler(this.button23_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.button21);
            this.Controls.Add(this.button22);
            this.Controls.Add(this.button23);
            this.Controls.Add(this.button17);
            this.Controls.Add(this.button18);
            this.Controls.Add(this.button19);
            this.Controls.Add(this.button20);
            this.Controls.Add(this.play3);
            this.Controls.Add(this.play2);
            this.Controls.Add(this.play1);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.button15);
            this.Controls.Add(this.button16);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.RandomizeBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.PlayProgressionBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mode);
            this.Controls.Add(this.mood);
            this.Controls.Add(this.modificator);
            this.Controls.Add(this.key);
            this.Controls.Add(this.pianoControl1);
            this.Controls.Add(this.GenerateChordsBtn);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "CHORD GENERATOR";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button GenerateChordsBtn;
        private Sanford.Multimedia.Midi.UI.PianoControl pianoControl1;
        private System.Windows.Forms.ComboBox key;
        private System.Windows.Forms.ComboBox modificator;
        private System.Windows.Forms.ComboBox mood;
        private System.Windows.Forms.ComboBox mode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button PlayProgressionBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button RandomizeBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button play1;
        private System.Windows.Forms.Button play2;
        private System.Windows.Forms.Button play3;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.Button button21;
        private System.Windows.Forms.Button button22;
        private System.Windows.Forms.Button button23;
    }
}

