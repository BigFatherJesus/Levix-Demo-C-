﻿namespace LevixDemoApp.GUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.ComboBox locationComboBox;
        private System.Windows.Forms.RadioButton gamingLaptopRadioButton;
        private System.Windows.Forms.RadioButton nonGamingLaptopRadioButton;
        private System.Windows.Forms.TextBox customUrlTextBox;
        private System.Windows.Forms.CheckBox[] dayCheckBoxes = new System.Windows.Forms.CheckBox[7];
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Configuration";

            // Location ComboBox
            this.locationComboBox = new System.Windows.Forms.ComboBox();
            this.locationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.locationComboBox.Items.AddRange(new object[] {
                "Den Bosch", "Veghel", "Uden", "Oss", "Geffen"
            });
            this.locationComboBox.Location = new System.Drawing.Point(50, 50);
            this.locationComboBox.Size = new System.Drawing.Size(200, 21);
            this.Controls.Add(this.locationComboBox);

            // Gaming Laptop Radio Button
            this.gamingLaptopRadioButton = new System.Windows.Forms.RadioButton();
            this.gamingLaptopRadioButton.Text = "Gaming Laptop";
            this.gamingLaptopRadioButton.Location = new System.Drawing.Point(50, 90);
            this.Controls.Add(this.gamingLaptopRadioButton);

            // Non-Gaming Laptop Radio Button
            this.nonGamingLaptopRadioButton = new System.Windows.Forms.RadioButton();
            this.nonGamingLaptopRadioButton.Text = "Non-Gaming Laptop";
            this.nonGamingLaptopRadioButton.Location = new System.Drawing.Point(50, 120);
            this.Controls.Add(this.nonGamingLaptopRadioButton);

            // Custom URL TextBox
            this.customUrlTextBox = new System.Windows.Forms.TextBox();
            this.customUrlTextBox.Location = new System.Drawing.Point(50, 160);
            this.customUrlTextBox.Size = new System.Drawing.Size(200, 20);
            this.Controls.Add(this.customUrlTextBox);

            // Day Checkboxes
            string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            for (int i = 0; i < 7; i++)
            {
                this.dayCheckBoxes[i] = new System.Windows.Forms.CheckBox();
                this.dayCheckBoxes[i].Text = days[i];
                this.dayCheckBoxes[i].Location = new System.Drawing.Point(50, 200 + (i * 30));
                this.Controls.Add(this.dayCheckBoxes[i]);
            }

            // Save Button
            this.saveButton = new System.Windows.Forms.Button();
            this.saveButton.Text = "Save";
            this.saveButton.Location = new System.Drawing.Point(50, 410);
            this.Controls.Add(this.saveButton);

            // Cancel Button
            this.cancelButton = new System.Windows.Forms.Button();
            this.cancelButton.Text = "Cancel";
            this.cancelButton.Location = new System.Drawing.Point(150, 410);
            this.Controls.Add(this.cancelButton);
        }

        #endregion
    }
}