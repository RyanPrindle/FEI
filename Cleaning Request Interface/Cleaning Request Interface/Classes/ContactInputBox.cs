using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Cleaning_Request_Interface
{
    class ContactInputBox
    {
        public static DialogResult Show(String title, String promptText, ref String answer, ContactBoxValidation validation)
        {
            Form addContactForm = new Form();
            Label labelFirst = new Label();             
            TextBox textBoxFirst = new TextBox();
            
            Button buttonOk = new Button();
            Button buttonCancel = new Button();
           
            addContactForm.Text = title;
            labelFirst.Text = promptText;
            textBoxFirst.Text = answer;
                buttonOk.Text = "OK";
                buttonCancel.Text = "Cancel";            
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            labelFirst.SetBounds(9, 20, 372, 13);
            textBoxFirst.SetBounds(12, 36, 372, 20);
            labelFirst.AutoSize = true;
            textBoxFirst.Anchor = textBoxFirst.Anchor | AnchorStyles.Right;
            textBoxFirst.Select(0, 0);
            
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            
                buttonOk.SetBounds(228, 124, 75, 23);
                buttonCancel.SetBounds(309, 124, 75, 23);
                addContactForm.ClientSize = new Size(396, 163);
                addContactForm.Controls.AddRange(new Control[] { labelFirst, textBoxFirst, buttonOk, buttonCancel });
                addContactForm.ClientSize = new Size(Math.Max(300, labelFirst.Right + 10), addContactForm.ClientSize.Height);
            

            addContactForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            addContactForm.StartPosition = FormStartPosition.CenterScreen;
            addContactForm.MinimizeBox = false;
            addContactForm.MaximizeBox = false;
            addContactForm.AcceptButton = buttonOk;
            addContactForm.CancelButton = buttonCancel;
            if (validation != null)
            {
                addContactForm.FormClosing += delegate(object sender, FormClosingEventArgs e)
                {
                    if (addContactForm.DialogResult == DialogResult.OK)
                    {
                        string errorText = validation(textBoxFirst.Text);
                        if (e.Cancel = (errorText != ""))
                        {
                            MessageBox.Show(addContactForm, errorText, "Validation Error",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBoxFirst.Focus();
                        }
                    }
                };
            }
            DialogResult dialogResult = addContactForm.ShowDialog();
            if (addContactForm.DialogResult == DialogResult.OK)
            {
                answer = textBoxFirst.Text;                
            }          
            return dialogResult;
        }
    }
    public delegate string ContactBoxValidation(string errorMessage);
}
