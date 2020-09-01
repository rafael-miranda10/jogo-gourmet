using JogoGourmet.Domain.Resources;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace JogoGourmet.Domain.Utils
{
    public static class CaixaDeDialogo
    {
        public static DialogResult Exibir(string titulo, string texto, ref string valor)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();

            form.Text = titulo;
            label.Text = texto;
            textBox.Text = valor;

            buttonOk.Text = Constantes.Ok;
            buttonOk.DialogResult = DialogResult.Yes;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(310, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;

            DialogResult dialogResult = form.ShowDialog();
            valor = textBox.Text;
            return dialogResult;
        }
    }
}
