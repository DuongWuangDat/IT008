using System;
using System.Windows.Forms;

public static class InputDialog
{
    public static string ShowDialog(string caption, string prompt)
    {
        Form promptForm = new Form
        {
            Width = 300,
            Height = 150,
            FormBorderStyle = FormBorderStyle.FixedDialog,
            Text = caption,
            StartPosition = FormStartPosition.CenterScreen
        };

        Label label = new Label() { Left = 50, Top = 20, Text = prompt };
        TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 200 };
        Button confirmation = new Button() { Text = "OK", Left = 50, Width = 70, Top = 80, DialogResult = DialogResult.OK };
        Button cancel = new Button() { Text = "Cancel", Left = 150, Width = 70, Top = 80, DialogResult = DialogResult.Cancel };

        confirmation.Click += (sender, e) => { promptForm.Close(); };

        promptForm.Controls.Add(label);
        promptForm.Controls.Add(textBox);
        promptForm.Controls.Add(confirmation);
        promptForm.Controls.Add(cancel);

        DialogResult dialogResult = promptForm.ShowDialog();

        if (dialogResult == DialogResult.OK)
        {
            return textBox.Text;
        }
        else
        {
            return null; // Người dùng đã bấm Cancel hoặc đóng hộp thoại
        }
    }
}
