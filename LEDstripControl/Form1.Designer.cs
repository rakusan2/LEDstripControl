namespace WindowsFormsApplication1
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.RedControl = new System.Windows.Forms.HScrollBar();
            this.GreenControl = new System.Windows.Forms.HScrollBar();
            this.BlueControl = new System.Windows.Forms.HScrollBar();
            this.radioButtonStationary = new System.Windows.Forms.RadioButton();
            this.radioButtonLmove = new System.Windows.Forms.RadioButton();
            this.radioButtonRmove = new System.Windows.Forms.RadioButton();
            this.radioButtonSlight = new System.Windows.Forms.RadioButton();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.radioButtonClight = new System.Windows.Forms.RadioButton();
            this.Movement = new System.Windows.Forms.GroupBox();
            this.LightChange = new System.Windows.Forms.GroupBox();
            this.InOut = new System.Windows.Forms.CheckBox();
            this.MinLED = new System.Windows.Forms.TextBox();
            this.MaxLED = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxBounce = new System.Windows.Forms.CheckBox();
            this.ChangeIn = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxIn = new System.Windows.Forms.TextBox();
            this.FadeIn = new System.Windows.Forms.RadioButton();
            this.BlinkIn = new System.Windows.Forms.RadioButton();
            this.ChangeOut = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.FadeOut = new System.Windows.Forms.RadioButton();
            this.textBoxOut = new System.Windows.Forms.TextBox();
            this.BlinkOut = new System.Windows.Forms.RadioButton();
            this.Send = new System.Windows.Forms.Button();
            this.Mspeed = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Movement.SuspendLayout();
            this.LightChange.SuspendLayout();
            this.ChangeIn.SuspendLayout();
            this.ChangeOut.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // RedControl
            // 
            this.RedControl.AccessibleName = "red";
            this.RedControl.Enabled = false;
            this.RedControl.LargeChange = 25;
            this.RedControl.Location = new System.Drawing.Point(53, 82);
            this.RedControl.Maximum = 255;
            this.RedControl.Name = "RedControl";
            this.RedControl.Size = new System.Drawing.Size(611, 19);
            this.RedControl.SmallChange = 5;
            this.RedControl.TabIndex = 0;
            this.RedControl.ValueChanged += new System.EventHandler(this.control);
            // 
            // GreenControl
            // 
            this.GreenControl.AccessibleName = "green";
            this.GreenControl.Enabled = false;
            this.GreenControl.LargeChange = 25;
            this.GreenControl.Location = new System.Drawing.Point(53, 112);
            this.GreenControl.Maximum = 255;
            this.GreenControl.Name = "GreenControl";
            this.GreenControl.Size = new System.Drawing.Size(611, 19);
            this.GreenControl.SmallChange = 5;
            this.GreenControl.TabIndex = 1;
            this.GreenControl.ValueChanged += new System.EventHandler(this.control);
            // 
            // BlueControl
            // 
            this.BlueControl.AccessibleName = "blue";
            this.BlueControl.Enabled = false;
            this.BlueControl.LargeChange = 25;
            this.BlueControl.Location = new System.Drawing.Point(53, 143);
            this.BlueControl.Maximum = 255;
            this.BlueControl.Name = "BlueControl";
            this.BlueControl.Size = new System.Drawing.Size(611, 19);
            this.BlueControl.SmallChange = 5;
            this.BlueControl.TabIndex = 2;
            this.BlueControl.Tag = "";
            this.BlueControl.ValueChanged += new System.EventHandler(this.control);
            // 
            // radioButtonStationary
            // 
            this.radioButtonStationary.AccessibleName = "0";
            this.radioButtonStationary.AutoSize = true;
            this.radioButtonStationary.Checked = true;
            this.radioButtonStationary.Location = new System.Drawing.Point(22, 11);
            this.radioButtonStationary.Name = "radioButtonStationary";
            this.radioButtonStationary.Size = new System.Drawing.Size(72, 17);
            this.radioButtonStationary.TabIndex = 1;
            this.radioButtonStationary.TabStop = true;
            this.radioButtonStationary.Text = "Stationary";
            this.radioButtonStationary.UseVisualStyleBackColor = true;
            this.radioButtonStationary.CheckedChanged += new System.EventHandler(this.changedRadio);
            // 
            // radioButtonLmove
            // 
            this.radioButtonLmove.AccessibleName = "2";
            this.radioButtonLmove.AutoSize = true;
            this.radioButtonLmove.Location = new System.Drawing.Point(22, 56);
            this.radioButtonLmove.Name = "radioButtonLmove";
            this.radioButtonLmove.Size = new System.Drawing.Size(73, 17);
            this.radioButtonLmove.TabIndex = 2;
            this.radioButtonLmove.Text = "Move Left";
            this.radioButtonLmove.UseVisualStyleBackColor = true;
            this.radioButtonLmove.CheckedChanged += new System.EventHandler(this.changedRadio);
            // 
            // radioButtonRmove
            // 
            this.radioButtonRmove.AccessibleName = "1";
            this.radioButtonRmove.AutoSize = true;
            this.radioButtonRmove.Location = new System.Drawing.Point(22, 34);
            this.radioButtonRmove.Name = "radioButtonRmove";
            this.radioButtonRmove.Size = new System.Drawing.Size(80, 17);
            this.radioButtonRmove.TabIndex = 3;
            this.radioButtonRmove.Text = "Move Right";
            this.radioButtonRmove.UseVisualStyleBackColor = true;
            this.radioButtonRmove.CheckedChanged += new System.EventHandler(this.changedRadio);
            // 
            // radioButtonSlight
            // 
            this.radioButtonSlight.AccessibleName = "3";
            this.radioButtonSlight.AutoSize = true;
            this.radioButtonSlight.Checked = true;
            this.radioButtonSlight.Location = new System.Drawing.Point(14, 10);
            this.radioButtonSlight.Name = "radioButtonSlight";
            this.radioButtonSlight.Size = new System.Drawing.Size(78, 17);
            this.radioButtonSlight.TabIndex = 1;
            this.radioButtonSlight.TabStop = true;
            this.radioButtonSlight.Text = "Stedy Light";
            this.radioButtonSlight.UseVisualStyleBackColor = true;
            this.radioButtonSlight.CheckedChanged += new System.EventHandler(this.changedRadio);
            // 
            // radioButtonClight
            // 
            this.radioButtonClight.AccessibleName = "4";
            this.radioButtonClight.AutoSize = true;
            this.radioButtonClight.Location = new System.Drawing.Point(14, 33);
            this.radioButtonClight.Name = "radioButtonClight";
            this.radioButtonClight.Size = new System.Drawing.Size(96, 17);
            this.radioButtonClight.TabIndex = 2;
            this.radioButtonClight.Text = "Changing Light";
            this.radioButtonClight.UseVisualStyleBackColor = true;
            this.radioButtonClight.CheckedChanged += new System.EventHandler(this.changedRadio);
            // 
            // Movement
            // 
            this.Movement.BackColor = System.Drawing.Color.Transparent;
            this.Movement.Controls.Add(this.radioButtonRmove);
            this.Movement.Controls.Add(this.radioButtonLmove);
            this.Movement.Controls.Add(this.radioButtonStationary);
            this.Movement.Location = new System.Drawing.Point(31, 174);
            this.Movement.Name = "Movement";
            this.Movement.Size = new System.Drawing.Size(120, 98);
            this.Movement.TabIndex = 4;
            this.Movement.TabStop = false;
            this.Movement.Visible = false;
            // 
            // LightChange
            // 
            this.LightChange.Controls.Add(this.InOut);
            this.LightChange.Controls.Add(this.radioButtonClight);
            this.LightChange.Controls.Add(this.radioButtonSlight);
            this.LightChange.Location = new System.Drawing.Point(322, 175);
            this.LightChange.Name = "LightChange";
            this.LightChange.Size = new System.Drawing.Size(124, 86);
            this.LightChange.TabIndex = 5;
            this.LightChange.TabStop = false;
            this.LightChange.Visible = false;
            // 
            // InOut
            // 
            this.InOut.AccessibleName = "2";
            this.InOut.AutoSize = true;
            this.InOut.Location = new System.Drawing.Point(14, 57);
            this.InOut.Name = "InOut";
            this.InOut.Size = new System.Drawing.Size(107, 17);
            this.InOut.TabIndex = 9;
            this.InOut.Text = "In is same as Out";
            this.InOut.UseVisualStyleBackColor = true;
            this.InOut.Visible = false;
            this.InOut.CheckedChanged += new System.EventHandler(this.checkChange);
            // 
            // MinLED
            // 
            this.MinLED.AccessibleName = "1";
            this.MinLED.Location = new System.Drawing.Point(214, 231);
            this.MinLED.Name = "MinLED";
            this.MinLED.Size = new System.Drawing.Size(92, 20);
            this.MinLED.TabIndex = 6;
            this.MinLED.Visible = false;
            this.MinLED.TextChanged += new System.EventHandler(this.TChanged);
            // 
            // MaxLED
            // 
            this.MaxLED.AccessibleName = "0";
            this.MaxLED.Location = new System.Drawing.Point(214, 208);
            this.MaxLED.Name = "MaxLED";
            this.MaxLED.Size = new System.Drawing.Size(92, 20);
            this.MaxLED.TabIndex = 6;
            this.MaxLED.Visible = false;
            this.MaxLED.TextChanged += new System.EventHandler(this.TChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(157, 212);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Max LED";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(157, 235);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Min LED";
            this.label2.Visible = false;
            // 
            // checkBoxBounce
            // 
            this.checkBoxBounce.AccessibleName = "1";
            this.checkBoxBounce.AutoSize = true;
            this.checkBoxBounce.Location = new System.Drawing.Point(160, 185);
            this.checkBoxBounce.Name = "checkBoxBounce";
            this.checkBoxBounce.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxBounce.Size = new System.Drawing.Size(63, 17);
            this.checkBoxBounce.TabIndex = 8;
            this.checkBoxBounce.Text = "Bounce";
            this.checkBoxBounce.UseVisualStyleBackColor = true;
            this.checkBoxBounce.Visible = false;
            this.checkBoxBounce.CheckedChanged += new System.EventHandler(this.checkChange);
            // 
            // ChangeIn
            // 
            this.ChangeIn.Controls.Add(this.label3);
            this.ChangeIn.Controls.Add(this.textBoxIn);
            this.ChangeIn.Controls.Add(this.FadeIn);
            this.ChangeIn.Controls.Add(this.BlinkIn);
            this.ChangeIn.Location = new System.Drawing.Point(577, 175);
            this.ChangeIn.Name = "ChangeIn";
            this.ChangeIn.Size = new System.Drawing.Size(117, 103);
            this.ChangeIn.TabIndex = 5;
            this.ChangeIn.TabStop = false;
            this.ChangeIn.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Time in ms";
            // 
            // textBoxIn
            // 
            this.textBoxIn.AccessibleName = "3";
            this.textBoxIn.Location = new System.Drawing.Point(14, 77);
            this.textBoxIn.Name = "textBoxIn";
            this.textBoxIn.Size = new System.Drawing.Size(96, 20);
            this.textBoxIn.TabIndex = 3;
            this.textBoxIn.TextChanged += new System.EventHandler(this.TChanged);
            // 
            // FadeIn
            // 
            this.FadeIn.AccessibleName = "8";
            this.FadeIn.AutoSize = true;
            this.FadeIn.Location = new System.Drawing.Point(14, 33);
            this.FadeIn.Name = "FadeIn";
            this.FadeIn.Size = new System.Drawing.Size(60, 17);
            this.FadeIn.TabIndex = 2;
            this.FadeIn.Text = "Fade in";
            this.FadeIn.UseVisualStyleBackColor = true;
            this.FadeIn.CheckedChanged += new System.EventHandler(this.changedRadio);
            // 
            // BlinkIn
            // 
            this.BlinkIn.AccessibleName = "7";
            this.BlinkIn.AutoSize = true;
            this.BlinkIn.Checked = true;
            this.BlinkIn.Location = new System.Drawing.Point(14, 10);
            this.BlinkIn.Name = "BlinkIn";
            this.BlinkIn.Size = new System.Drawing.Size(60, 17);
            this.BlinkIn.TabIndex = 1;
            this.BlinkIn.TabStop = true;
            this.BlinkIn.Text = "Blink In";
            this.BlinkIn.UseVisualStyleBackColor = true;
            this.BlinkIn.CheckedChanged += new System.EventHandler(this.changedRadio);
            // 
            // ChangeOut
            // 
            this.ChangeOut.Controls.Add(this.label4);
            this.ChangeOut.Controls.Add(this.FadeOut);
            this.ChangeOut.Controls.Add(this.textBoxOut);
            this.ChangeOut.Controls.Add(this.BlinkOut);
            this.ChangeOut.Location = new System.Drawing.Point(454, 175);
            this.ChangeOut.Name = "ChangeOut";
            this.ChangeOut.Size = new System.Drawing.Size(117, 103);
            this.ChangeOut.TabIndex = 5;
            this.ChangeOut.TabStop = false;
            this.ChangeOut.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Time in ms";
            // 
            // FadeOut
            // 
            this.FadeOut.AccessibleName = "6";
            this.FadeOut.AutoSize = true;
            this.FadeOut.Location = new System.Drawing.Point(14, 33);
            this.FadeOut.Name = "FadeOut";
            this.FadeOut.Size = new System.Drawing.Size(67, 17);
            this.FadeOut.TabIndex = 2;
            this.FadeOut.Text = "Fade out";
            this.FadeOut.UseVisualStyleBackColor = true;
            this.FadeOut.CheckedChanged += new System.EventHandler(this.changedRadio);
            // 
            // textBoxOut
            // 
            this.textBoxOut.AccessibleName = "2";
            this.textBoxOut.Location = new System.Drawing.Point(14, 76);
            this.textBoxOut.Name = "textBoxOut";
            this.textBoxOut.Size = new System.Drawing.Size(96, 20);
            this.textBoxOut.TabIndex = 3;
            this.textBoxOut.TextChanged += new System.EventHandler(this.TChanged);
            // 
            // BlinkOut
            // 
            this.BlinkOut.AccessibleName = "5";
            this.BlinkOut.AutoSize = true;
            this.BlinkOut.Checked = true;
            this.BlinkOut.Location = new System.Drawing.Point(14, 10);
            this.BlinkOut.Name = "BlinkOut";
            this.BlinkOut.Size = new System.Drawing.Size(68, 17);
            this.BlinkOut.TabIndex = 1;
            this.BlinkOut.TabStop = true;
            this.BlinkOut.Text = "Blink Out";
            this.BlinkOut.UseVisualStyleBackColor = true;
            this.BlinkOut.CheckedChanged += new System.EventHandler(this.changedRadio);
            // 
            // Send
            // 
            this.Send.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Send.Location = new System.Drawing.Point(307, 286);
            this.Send.Name = "Send";
            this.Send.Size = new System.Drawing.Size(107, 42);
            this.Send.TabIndex = 9;
            this.Send.Text = "Send";
            this.Send.UseVisualStyleBackColor = true;
            this.Send.Click += new System.EventHandler(this.Send_Click);
            // 
            // Mspeed
            // 
            this.Mspeed.AccessibleName = "4";
            this.Mspeed.Location = new System.Drawing.Point(214, 257);
            this.Mspeed.Name = "Mspeed";
            this.Mspeed.Size = new System.Drawing.Size(92, 20);
            this.Mspeed.TabIndex = 10;
            this.Mspeed.Visible = false;
            this.Mspeed.TextChanged += new System.EventHandler(this.TChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(157, 259);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Speed";
            this.label5.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(71, 309);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "label6";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(733, 340);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Mspeed);
            this.Controls.Add(this.Send);
            this.Controls.Add(this.checkBoxBounce);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MaxLED);
            this.Controls.Add(this.MinLED);
            this.Controls.Add(this.ChangeOut);
            this.Controls.Add(this.ChangeIn);
            this.Controls.Add(this.LightChange);
            this.Controls.Add(this.Movement);
            this.Controls.Add(this.BlueControl);
            this.Controls.Add(this.GreenControl);
            this.Controls.Add(this.RedControl);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.Movement.ResumeLayout(false);
            this.Movement.PerformLayout();
            this.LightChange.ResumeLayout(false);
            this.LightChange.PerformLayout();
            this.ChangeIn.ResumeLayout(false);
            this.ChangeIn.PerformLayout();
            this.ChangeOut.ResumeLayout(false);
            this.ChangeOut.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.HScrollBar RedControl;
        private System.Windows.Forms.HScrollBar GreenControl;
        private System.Windows.Forms.HScrollBar BlueControl;
        private System.Windows.Forms.RadioButton radioButtonStationary;
        private System.Windows.Forms.RadioButton radioButtonLmove;
        private System.Windows.Forms.RadioButton radioButtonRmove;
        private System.Windows.Forms.RadioButton radioButtonSlight;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.RadioButton radioButtonClight;
        private System.Windows.Forms.GroupBox Movement;
        private System.Windows.Forms.GroupBox LightChange;
        private System.Windows.Forms.TextBox MinLED;
        private System.Windows.Forms.TextBox MaxLED;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxBounce;
        private System.Windows.Forms.GroupBox ChangeIn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxIn;
        private System.Windows.Forms.RadioButton FadeIn;
        private System.Windows.Forms.RadioButton BlinkIn;
        private System.Windows.Forms.GroupBox ChangeOut;
        private System.Windows.Forms.RadioButton FadeOut;
        private System.Windows.Forms.RadioButton BlinkOut;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxOut;
        private System.Windows.Forms.CheckBox InOut;
        private System.Windows.Forms.Button Send;
        private System.Windows.Forms.TextBox Mspeed;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}

