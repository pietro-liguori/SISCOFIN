using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISCOFIN_v1
{
    /// <summary>
    /// 
    /// </summary>
    public class MyEvents
    {
        /// <summary>
        /// Evento <see cref="CheckBox.CheckedChanged"/> para controles do tipo <see cref="CheckBox"/>.
        /// <para>
        /// Maximiza ou minimiza o <see cref="SplitterPanel"/> inferior do <see cref="SplitContainer"/> 
        /// ao qual o <see cref="CheckBox"/> está associado.
        /// </para>A mudança do valor do <see cref="CheckBox"/> é feita ao clicar no botão 
        /// associado ao <see cref="SplitContainer"/> através do método 
        /// <see cref="MyEvents.ExpanderClick(object, EventArgs)"/>.
        /// <list type="bullet">
        /// <item><description>As propriedades <paramref name="MaximumSize"/>, 
        /// <paramref name="MinimumSize"/> e <paramref name="SplitterWidth"/> do 
        /// <see cref="SplitContainer"/> devem ser definidas, 
        /// conforme design necessário.</description>
        /// </item><item><description>A propriedade <paramref name="Panel1MinSize"/> do 
        /// <see cref="SplitContainer"/> é igual a diferença entre as propriedades 
        /// <paramref name="MinimumSize.Height"/> e <paramref name="SplitterWidth"/> do 
        /// <see cref="SplitContainer"/>.</description>
        /// </item><item><description>A propriedade <paramref name="Panel2MinSize"/> do 
        /// <see cref="SplitContainer"/> é igual a 0.</description>
        /// </item><item><description>A propriedade <paramref name="FixedPanel"/> do 
        /// <see cref="SplitContainer"/> é <paramref name="Panel1"/>.</description>
        /// </item><item><description>A propriedade <paramref name="IsSplitterFixed"/> do 
        /// <see cref="SplitContainer"/> é igual a <paramref name="true"/>.</description>
        /// </item><item><description>A propriedade <paramref name="Orientation"/> do 
        /// <see cref="SplitContainer"/> é <paramref name="Horizontal"/>.</description>
        /// </item><item><description>A propriedade <paramref name="Dock"/> do 
        /// <see cref="SplitContainer"/> é <paramref name="Top"/> ou <paramref name="Bottom"/>.</description>
        /// </item></list></summary>
        /// <param name="sender">Representa o <see cref="object"/> do controle que disparou o evento.</param>
        /// <param name="e">Recebe os dados da classe <see cref="EventArgs"/> para o evento.</param>
        public static void CollapsePanel(object sender, EventArgs e)
        {
            if (Globals.IsRunning) return;
            CheckBox me = (CheckBox)sender;
            Control ctl = me.Parent;
            while (!ctl.GetType().Equals(typeof(SplitContainer)))
            {
                ctl = ctl.Parent;
            }
            SplitContainer sp = (SplitContainer)ctl;
            sp.Panel2Collapsed = !me.Checked;
            sp.TabStop = !sp.Panel2Collapsed;
            switch (sp.Panel2Collapsed)
            {
                case true:
                    sp.Size = sp.MinimumSize;
                    break;
                case false:
                    sp.Size = sp.MaximumSize;
                    break;
            }
        }
        /// <summary>
        /// Evento <see cref="Control.TextChanged"/> para controles do tipo <see cref="ComboBox"/>.
        /// <para>
        /// Autocompleta o texto do <see cref="ComboBox"/>, se houver o texto na lista.
        /// </para>
        /// </summary>
        /// <param name="sender">Representa o <see cref="object"/> do controle que disparou o evento.</param>
        /// <param name="e">Recebe os dados da classe <see cref="EventArgs"/> para o evento.</param>
        public static void ComboBoxAutoComplete(object sender, EventArgs e)
        {
            ComboBox me = sender as ComboBox;
            if (!me.SelectedIndex.Equals(-1) || Globals.IsBackspace || Globals.IsDelete || Globals.IsRunning) return;
            Globals.IsRunning = true;
            int n = me.SelectionStart;
            me.SelectedIndex = me.FindString(me.Text);
            me.SelectionStart = n;
            me.SelectionLength = me.Text.Length - n;
            Globals.IsRunning = false;
            Globals.IsBackspace = false;
            Globals.IsDelete = false;
        }
        /// <summary>
        /// Evento <see cref="Control.KeyDown"/> para controles do tipo <see cref="ComboBox"/>.
        /// <para>
        /// Configura as variáveis <see cref="Globals.IsBackspace"/> e <see cref="Globals.IsDelete"/>
        /// para o evento <see cref="ComboBoxAutoComplete"/>.
        /// </para>
        /// <para>
        /// Para caixas de combinação com propriedade Tag igual a "0" ou "1", apresentará o seguinte 
        /// comportamento ao pressionar as teclas Delete e Backspace:
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>Caso "0": comportamento normal das teclas.</description>
        /// </item>
        /// <item>
        /// <description>Caso "1": apaga o texto da caixa de combinação.</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="sender">Representa o <see cref="object"/> do controle que disparou o evento.</param>
        /// <param name="e">Recebe os dados da classe <see cref="KeyEventArgs"/> para o evento.</param>
        public static void ComboBoxDelBack(object sender, KeyEventArgs e)
        {
            Globals.IsBackspace = false;
            Globals.IsDelete = false;
            if (sender.GetType().Equals(typeof(ToolStripComboBox)))
            {
                ToolStripComboBox me = (ToolStripComboBox)sender;
                if (e.KeyCode.Equals(Keys.Back) && !me.Text.Equals(string.Empty))
                {
                    Globals.IsBackspace = true;
                    if (me.Tag != null)
                    {
                        try { if (((int)me.Tag).Equals(1)) me.SelectedIndex = -1; }
                        catch { }
                    }
                }
                else if (e.KeyCode.Equals(Keys.Delete) && !me.Text.Equals(string.Empty))
                {
                    Globals.IsDelete = true;
                    if (me.Tag != null)
                    {
                        try { if (((int)me.Tag).Equals(1)) me.SelectedIndex = -1; }
                        catch { }
                    }
                }
            }
            if (sender.GetType().Equals(typeof(ComboBox)))
            {
                ComboBox me = (ComboBox)sender;
                if (e.KeyCode.Equals(Keys.Back) && !me.Text.Equals(string.Empty))
                {
                    Globals.IsBackspace = true;
                    if (me.Tag != null)
                    {
                        try { if (((int)me.Tag).Equals(1)) me.SelectedIndex = -1; }
                        catch { }
                    }
                }
                else if (e.KeyCode.Equals(Keys.Delete) && !me.Text.Equals(string.Empty))
                {
                    Globals.IsDelete = true;
                    if (me.Tag != null)
                    {
                        try { if (((int)me.Tag).Equals(1)) me.SelectedIndex = -1; }
                        catch { }
                    }
                }
            }
        }
        public static void ControlValidation(object sender, EventArgs e)
        {
            string newValue = string.Empty;
            if (sender.GetType().Equals(typeof(CheckBox)))
            {
                newValue = (sender as CheckBox).Checked.ToString();
                goto ValidateControl;
            }
            else if (sender.GetType().Equals(typeof(ComboBox)))
            {
                if ((sender as ComboBox).SelectedValue != null) newValue = (sender as ComboBox).SelectedValue.ToString();
                else newValue = "-1";
                goto ValidateControl;
            }
            else if (sender.GetType().Equals(typeof(DateTimePicker)))
            {
                newValue = (sender as DateTimePicker).Value.ToString("yyyy-MM-dd");
                newValue = "\"" + newValue + "\"";
                goto ValidateControl;
            }
            else if (sender.GetType().Equals(typeof(MaskedTextBox)))
            {
                newValue = (sender as MaskedTextBox).Text.Replace("'", "''").Trim();
                newValue = "\"" + newValue + "\"";
                goto ValidateControl;
            }
            else if (sender.GetType().Equals(typeof(NumericUpDown)))
            {
                newValue = (sender as NumericUpDown).Value.ToString();
                goto ValidateControl;
            }
            else if (sender.GetType().Equals(typeof(RadioButton)))
            {
                newValue = (sender as RadioButton).Checked.ToString();
                goto ValidateControl;
            }
            else if (sender.GetType().Equals(typeof(TagBox)))
            {
                if ((sender as TagBox).SelectedItems != null)
                {
                    foreach (int i in (sender as TagBox).SelectedItems.Keys) newValue += i + ";";
                }
                if (!newValue.Equals(string.Empty)) newValue = "[" + newValue.Substring(0, newValue.Length - 1) + "]";
                newValue = "\"" + newValue + "\"";
                goto ValidateControl;
            }
            else if (sender.GetType().Equals(typeof(TextBox)))
            {
                string mask = MyMethods.GetTag<string>(sender, "Mask");
                switch (mask)
                {
                    case "Decimal":
                        if (decimal.TryParse((sender as TextBox).Text, out decimal value)) newValue = value.ToString();
                        else newValue = "0";
                        break;
                    case "None":
                        newValue = (sender as TextBox).Text.Replace("'", "''").Trim();
                        newValue = "\"" + newValue + "\"";
                        break;
                    default:
                        newValue = (sender as TextBox).Text.Replace("'", "''").Trim();
                        newValue = '\u0022' + newValue + '\u0022';
                        break;
                }
                goto ValidateControl;
            }
            return;
        ValidateControl:
            string propertyName = MyMethods.GetTag<string>(sender, "Property") is null ? string.Empty : MyMethods.GetTag<string>(sender, "Property");
            string className = MyMethods.GetTag<string>(sender, "Class") is null ? string.Empty : MyMethods.GetTag<string>(sender, "Class");
            string code = className + "." + propertyName + " = " + newValue;
            ScriptOptions scriptClass = Program.ScriptClass[className.Split('.')[0]];
            try { var eval = CSharpScript.EvaluateAsync(code, options: scriptClass).Result; }
            catch{ }
        }

        /// <summary>
        /// Evento <see cref="DataGridView.CellMouseDown"/> para controles do tipo <see cref="DataGridView"/>.
        /// <para>Habilita a seleção de células ou linhas com o botão direito do mouse.</para>
        /// </summary>
        /// <param name="sender">Representa o <see cref="object"/> do controle que disparou o evento.</param>
        /// <param name="e">Recebe os dados da classe <see cref="DataGridViewCellMouseEventArgs"/> para o evento.</param>
        public static void DataGridViewRightClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView me = (DataGridView)sender;
            if (e.Button.Equals(MouseButtons.Right))
            {
                try
                {
                    Globals.SelectedIndex = e.RowIndex;
                    me.Rows[e.RowIndex].Selected = true;
                }
                catch { }
            }
        }
        /// <summary>
        /// Evento <see cref="Control.KeyDown"/> para controles do tipo <see cref="TextBox"/>.
        /// <list type="bullet">
        /// <item>
        /// <description>Máscara de texto para valores com formatação "###.###.###.##0,00".</description>
        /// </item>
        /// <item>
        /// <description>Permite apenas a digitação de números.</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="sender">Representa o <see cref="object"/> do controle que disparou o evento.</param>
        /// <param name="e">Recebe os dados da classe <see cref="KeyEventArgs"/> para o evento.</param>
        public static void DecimalMask(object sender, KeyEventArgs e)
        {
            if ((sender as TextBox).ReadOnly) return;
            if (e.KeyCode >= Keys.Left && e.KeyCode <= Keys.Down) return;
            if ((e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) || (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9) || e.KeyCode.Equals(Keys.Back) || e.KeyCode.Equals(Keys.Delete))
            {
                TextBox me = (TextBox)sender;
                string mask = "0,00";
                int selLenght = me.SelectionLength;
                int selStart = me.SelectionStart;
                int rOffset = me.TextLength - selStart;
                int selOffset = 0;
                string txt = me.Text;
                if (selLenght.Equals(0))
                {
                    switch (e.KeyCode)
                    {
                        case Keys.Back:
                            if (selStart.Equals(0)) return;
                            if (txt.Substring(selStart - 1, 1).Equals(",") || txt.Substring(selStart - 1, 1).Equals(".")) selOffset = -1;
                            txt = txt.Remove(selStart + selOffset - 1, 1);
                            break;
                        case Keys.Delete:
                            if (selStart.Equals(txt.Length)) return;
                            rOffset--;
                            if (txt.Substring(selStart, 1).Equals(",") || txt.Substring(selStart, 1).Equals("."))
                            {
                                rOffset--;
                                selOffset = 1;
                            }
                            txt = txt.Remove(selStart + selOffset, 1);
                            break;
                        default:
                            if (me.Text.Length.Equals(18))
                            {
                                e.SuppressKeyPress = true;
                                return;
                            }
                            txt = txt.Insert(selStart, e.KeyCode.ToString().Substring(e.KeyCode.ToString().Length - 1));
                            break;
                    }
                }
                else
                {
                    if (e.KeyCode.Equals(Keys.Back) || e.KeyCode.Equals(Keys.Delete)) { txt = txt.Remove(selStart, selLenght); }
                    else { txt = txt.Remove(selStart, selLenght).Insert(selStart, e.KeyCode.ToString().Substring(e.KeyCode.ToString().Length - 1)); }
                }
                try { txt = long.Parse(txt.Replace(",", "").Replace(".", "")).ToString(); }
                catch { txt = "0"; }
                if (txt.Length < 3) { txt = mask.Substring(0, mask.Length - txt.Length) + txt; }
                else { txt = txt.Insert(txt.Length - 2, ","); }
                txt = string.Format("{0:#,#0.00}", Convert.ToDecimal(txt));
                me.Text = txt;
                try { me.SelectionStart = txt.Length - rOffset + selLenght; }
                catch { me.SelectionStart = 0; }
            }
            e.SuppressKeyPress = true;
        }
        /// <summary>
        /// Evento <see cref="Control.Click"/> para controles do tipo <see cref="PictureBox"/>.
        /// <para>
        /// Altera o valor do <see cref="CheckBox"/> associado ao botão expansor (<see cref="PictureBox"/>) 
        /// para disparar o evento <see cref="MyEvents.CollapsePanel"/>.
        /// <list type="bullet">
        /// <item>
        /// <description>O nome dos controles <see cref="CheckBox"/> e <see cref="PictureBox"/> associados devem ser
        ///  iguais após a segunda letra (as duas primeiras letras são o código do tipo do controle).</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        /// <param name="sender">Representa o <see cref="object"/> do controle que disparou o evento.</param>
        /// <param name="e">Recebe os dados da classe <see cref="EventArgs"/> para o evento.</param>
        public static void ExpanderClick(object sender, EventArgs e)
        {
            if (sender.GetType().Equals(typeof(PictureBox)))
            {
                PictureBox me = sender as PictureBox;
                SplitterPanel pn = me.Parent as SplitterPanel;
                CheckBox ck = pn.Controls[pn.Controls.IndexOfKey("ck" + me.Name.Substring(2))] as CheckBox;
                ck.Checked = !ck.Checked;
            }
            else if (sender.GetType().Equals(typeof(Button)))
            {
                Button me = sender as Button;
                SplitterPanel pn = me.Parent as SplitterPanel;
                CheckBox ck = pn.Controls[pn.Controls.IndexOfKey("ck" + me.Name.Substring(2))] as CheckBox;
                ck.Checked = !ck.Checked;
            }
            else if (sender.GetType().Equals(typeof(Label)))
            {
                Label me = sender as Label;
                SplitterPanel pn = me.Parent as SplitterPanel;
                CheckBox ck = pn.Controls[pn.Controls.IndexOfKey("ck" + me.Name.Substring(2))] as CheckBox;
                ck.Checked = !ck.Checked;
            }

        }
        /// <summary>
        /// Evento <see cref="Control.KeyPress"/> para controles diversos.
        /// <para>
        /// Impede a digitação de caracteres.
        /// </para>
        /// </summary>
        /// <param name="sender">Representa o <see cref="object"/> do controle que disparou o evento.</param>
        /// <param name="e">Recebe os dados da classe <see cref="KeyPressEventArgs"/> para o evento.</param>
        public static void NoTyping(object sender, KeyPressEventArgs e)
        {
            /** Evento NoTyping
            *   - recebe o objeto 'sender'
            *   - recebe os argumentos de evento 'e'
            *
            *   Evento KeyPress para controles diversos.
            *   Impede a digitação de caracteres.
            */

            if (!char.IsControl(e.KeyChar)) e.Handled = true;
        }
        /// <summary>
        /// Evento <see cref="Control.KeyPress"/> para controles do tipo <see cref="ComboBox"/>.
        /// <para>
        /// Impede a digitação de texto que não exista na lista suspensa.
        /// </para>
        /// </summary>
        /// <param name="sender">Representa o <see cref="object"/> do controle que disparou o evento.</param>
        /// <param name="e">Recebe os dados da classe <see cref="KeyPressEventArgs"/> para o evento.</param>
        public static void OnlyMatchComboBox(object sender, KeyPressEventArgs e)
        {
            ComboBox me = (ComboBox)sender;
            if (char.IsControl(e.KeyChar)) return;
            if (char.IsLetter(e.KeyChar))
            {
                e.KeyChar = char.Parse(e.KeyChar.ToString().ToUpper());
                if (!me.FindString(me.Text.Substring(0, me.SelectionStart) + e.KeyChar.ToString()).Equals(-1)) return;
            }
            e.Handled = true;
        }
        /// <summary>
        /// Evento <see cref="Control.KeyPress"/> para controles diversos.
        /// <para>
        /// Habilita apenas a digitação de números.
        /// </para>
        /// </summary>
        /// <param name="sender">Representa o <see cref="object"/> do controle que disparou o evento.</param>
        /// <param name="e">Recebe os dados da classe <see cref="KeyPressEventArgs"/> para o evento.</param>
        public static void OnlyNumbers(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) || char.IsNumber(e.KeyChar)) return;
            e.Handled = true;
        }
        /// <summary>
        /// Evento <see cref="Control.KeyPress"/> para controles diversos.
        /// <para>
        /// Impede a digitação de letras.
        /// </para>
        /// </summary>
        /// <param name="sender">Representa o <see cref="object"/> do controle que disparou o evento.</param>
        /// <param name="e">Recebe os dados da classe <see cref="KeyPressEventArgs"/> para o evento.</param>
        public static void NoLetters(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar)) return;
            e.Handled = true;
        }
        /// <summary>
        /// Evento <see cref="Control.Enter"/> para controles dos tipos <see cref="TextBox"/>, <see cref="ComboBox"/>
        ///  e <see cref="MaskedTextBox"/>.
        ///  <para>
        ///  Põe o cursor no final do texto ao receber o foco.
        /// </para>
        /// </summary>
        /// <param name="sender">Representa o <see cref="object"/> do controle que disparou o evento.</param>
        /// <param name="e">Recebe os dados da classe <see cref="EventArgs"/> para o evento.</param>
        public static void SelectionStartOnEnd(object sender, EventArgs e)
        {
            Control me = (Control)sender;
            if (me.GetType().Equals(typeof(TextBox))) (sender as TextBox).SelectionStart = (sender as TextBox).TextLength;
            else if (me.GetType().Equals(typeof(MaskedTextBox))) (sender as MaskedTextBox).SelectionStart = (sender as MaskedTextBox).TextLength;
            else if (me.GetType().Equals(typeof(ComboBox))) (sender as ComboBox).SelectionStart = (sender as ComboBox).Text.Length;
        }
        /// <summary>
        /// Evento <see cref="Control.KeyPress"/> para controles diversos.
        /// <para>
        /// Habilita apenas a digitação de caracteres maiúsculos.
        /// </para>
        /// </summary>
        /// <param name="sender">Representa o <see cref="object"/> do controle que disparou o evento.</param>
        /// <param name="e">Recebe os dados da classe <see cref="KeyPressEventArgs"/> para o evento.</param>
        public static void UpperCharChasing(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar)) e.KeyChar = char.Parse(e.KeyChar.ToString().ToUpper());
        }
    }
}
