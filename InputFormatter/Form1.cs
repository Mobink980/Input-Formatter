using System;
using System.Windows.Forms;

namespace InputFormatter
{
    public partial class Form1 : Form
    {
        #region Constructor
        //The default Constructor
        public Form1()
        {
            InitializeComponent();
        }

        #endregion

        /*
         * pattern is the format that we are getting input from the user:
         s ==> character of a string including lowercase and uppercase
         d ==> digit {0, 1, 2, 3, 4, 5, 6, 7, 8, 9}
         Other signs in the pattern have the same meaning.
         */
        readonly string pattern = "dd:ss:dd";
        
        //TextChanged function will be called, anytime the text inside the textBox is changed.
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%% Determining the label.
            if (this.textBox.Text.Length < pattern.Length) 
                label.Text = "Please Enter The Text: Entered " + this.textBox.Text.Length.ToString() + " out of " + pattern.Length.ToString();
            else
                label.Text = "You're All Done. Thank you!";
            //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
            labelFormat.Text = pattern; //Attaching pattern to the label labelFormat
            //focus the user input text
            FocusInputText();

            if (this.textBox.Text.Length <= pattern.Length) //Update the textBox by correct input
            {           
                this.textBox.Text = InputFormatter(pattern);
            }
            else
            {           //if the text overseeds the pattern, then remove extra text from the textBox    
                this.textBox.Text = this.textBox.Text.Remove(pattern.Length , this.textBox.Text.Length - pattern.Length); //Remove the unvalid character
            }
           
        }


        #region Private Helpers
        /// <summary>
        /// This Method Helps to Maintain a Specific Pattern Within The textBox. 
        /// </summary>
        /// <param name="pattern">The pattern defined when calling the method</param>
        private string InputFormatter(string pattern)
        {

            //focus the user input text
            FocusInputText();

            for (int i = 0; i < this.textBox.Text.Length; i++)
            {
                if ((int)this.textBox.Text[i] > 31) //Assuring that we got a character or the right ascci code
                {
                    if ((int)this.textBox.Text[i] > 47 && (int)this.textBox.Text[i] < 58) //If we got a digit
                    {
                        if (pattern[i] != 'd')
                        { //If the pattern is not correct    
                            return DeleteCharacter(i); //Remove the unvalid character
                            
                             //MessageBox.Show("Hi");

                        }
                    }
                    
                    else if ((int)this.textBox.Text[i] > 64 && (int)this.textBox.Text[i] < 91) //If we got a capital letter
                    {
                        if (pattern[i] != 's')
                        { //If the pattern is not correct  
                            return DeleteCharacter(i); //Remove the unvalid character
                           // MessageBox.Show("Hi");
                            
                        }
                    }

                    else if ((int)this.textBox.Text[i] > 96 && (int)this.textBox.Text[i] < 123) //If we got a lowercase letter
                    {
                        if (pattern[i] != 's')
                        { //If the pattern is not correct   
                            return DeleteCharacter(i); //Remove the unvalid character                                                   
                        }
                    }

                    else //If we got one of the allowed signs
                    {
                        if (pattern[i] != this.textBox.Text[i])
                        { //If signs do not match
                            return DeleteCharacter(i); //Remove the unvalid character
                           // MessageBox.Show("Hi");
                            
                        }
                    }
                  
                }
           
            }

            //focus the user input text
            FocusInputText();
            return this.textBox.Text;
        }

        /// <summary>
        /// Helps to remove an unvalid character from the textBox
        /// </summary>
        private string DeleteCharacter(int i)
        {                      
            // Delete the character to the left of the selection
            string str = this.textBox.Text.Remove(i, 1);

            //focus the user input text
            FocusInputText();
       
            return str;
        }

        /// <summary>
        /// Focuses the user's input text.
        /// </summary>
        private void FocusInputText()
        {
            this.textBox.Focus();

            // Restore the selection start
            textBox.SelectionStart = this.textBox.Text.Length;

            // Set selection length to zero
            textBox.SelectionLength = 0;
        }
        #endregion
       
    }
}
