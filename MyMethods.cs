using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISCOFIN_v1
{
    public class MyMethods
    {
        /// <summary>
        /// Método utilizado para autocompletar o a palavra de acordo com a coleção da caixa de combinação.
        /// </summary>
        /// <param name="me">Objeto do tipo ComboBox</param>
        public static DataTable DataGridViewConfig(DataGridView me, DataTable dataSource, Dictionary<string, int> dgConfig, int mode = 1, DataGridViewCellStyle dataGridViewCellStyle = null)
        {
            /** Método DataGridViewConfig
            *   - recebe o datagridview 'me'
            *   - recebe o texto da consulta SQL 'sqlQuery' no banco de dados
            *   - recebe o número de colunas 'columnCount' para a consulta SQL no banco de dados
            *   - recebe o dicionário 'dgConfig' que contém os pares:
            *       [índice da coluna da consulta, peso de preenchimento da coluna no datagridview]
            *       *Colocar apenas o índice das colunas desejadas no datagridview e seus respectivos pesos de preenchimento 
            *       *A soma dos pesos de preenchimento das colunas deve ser 100
            *
            *   Faz a consulta no banco de dados, configura as colunas do datagridview de acordo com os
            *   parâmetros fornecidos e retorna a tabela de dados 'dataTable' da consulta.
            */
            me.DataSource = dataSource;
            if (dataGridViewCellStyle != null) { me.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle; }
            else { me.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold); }
            foreach (DataGridViewColumn col in me.Columns)
            {
                if (dgConfig.ContainsKey(col.Name))
                {
                    me.Columns[col.Name].Visible = true;
                    me.Columns[col.Name].SortMode = DataGridViewColumnSortMode.NotSortable;
                    switch (mode)
                    {
                        case 1:
                            me.Columns[col.Name].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            me.Columns[col.Name].FillWeight = dgConfig[col.Name];
                            break;
                        case 2:
                            me.Columns[col.Name].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                            me.Columns[col.Name].Width = dgConfig[col.Name];
                            break;
                    }
                }
                else
                {
                    me.Columns[col.Name].Visible = false;
                }
            }
            return dataSource;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sender"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T GetTag<T>(object sender, string key)
        {
            Dictionary<string, string> tags = new Dictionary<string, string>();
            if ((sender as Control).Tag is null) return default;
            string[] tagValue = (sender as Control).Tag.ToString().Split(';');
            foreach (string tag in tagValue) tags.Add(tag.Split(':')[0], tag.Split(':')[1]);
            try { return (T)Convert.ChangeType(tags[key], typeof(T)); }
            catch { return default; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="closePanel"></param>
        public static void ResetPanel(Panel panel, bool closePanel = true)
        {
            /** Método ResetPanel
            *   - recebe o painel 'panel' a ser limpo
            *   - recebe a variável 'closePanel'
            *
            *   Limpa o painel fornecido.
            *   Se 'closePanel' for verdadeiro, limpa, também, os datagridviews do painel.
            *   Se a Tag de algum rótulo for "-1", limpa o rótulo.
            */
            for (int i = panel.Controls.Count - 1; i >= 0; i--)
            {
                if (panel.Controls[i].GetType().Equals(typeof(ComboBox)))
                {
                    (panel.Controls[i] as ComboBox).SelectedIndex = -1;
                }
                else if (panel.Controls[i].GetType().Equals(typeof(DataGridView)))
                {
                    if (closePanel) (panel.Controls[i] as DataGridView).DataSource = null;
                }
                else if (panel.Controls[i].GetType().Equals(typeof(Label)))
                {
                    if ((panel.Controls[i] as Label).Tag != null)
                    {
                        if ((panel.Controls[i] as Label).Tag.ToString().Equals("-1"))
                        {
                            (panel.Controls[i] as Label).Text = "";
                        }
                    }
                }
                else if (panel.Controls[i].GetType().Equals(typeof(ListBox)))
                {
                    (panel.Controls[i] as ListBox).SelectedIndex = -1;
                }
                else if (panel.Controls[i].GetType().Equals(typeof(ListView)))
                {
                    (panel.Controls[i] as ListView).Items.Clear();
                }
                else if (panel.Controls[i].GetType().Equals(typeof(MaskedTextBox)))
                {
                    (panel.Controls[i] as MaskedTextBox).Clear();
                }
                else if (panel.Controls[i].GetType().Equals(typeof(NumericUpDown)))
                {
                    (panel.Controls[i] as NumericUpDown).Value = (panel.Controls[i] as NumericUpDown).Minimum;
                }
                else if (panel.Controls[i].GetType().Equals(typeof(Panel)))
                {
                    ResetPanel(panel.Controls[i] as Panel, closePanel);
                }
                else if (panel.Controls[i].GetType().Equals(typeof(SplitContainer)))
                {
                    ResetPanel(panel.Controls[i] as SplitContainer, closePanel);
                }
                else if (panel.Controls[i].GetType().Equals(typeof(TextBox)))
                {
                    (panel.Controls[i] as TextBox).Clear();
                }
                else if (panel.Controls[i].GetType().Equals(typeof(ToolStrip)))
                {
                    foreach (ToolStripItem item in (panel.Controls[i] as ToolStrip).Items)
                    {
                        if (item.GetType().Equals(typeof(ToolStripComboBox)))
                        {
                            (item as ToolStripComboBox).SelectedIndex = -1;
                        }
                        else if (item.GetType().Equals(typeof(ToolStripLabel)))
                        {
                            if ((item as ToolStripLabel).Tag != null)
                            {
                                if ((item as ToolStripLabel).Tag != null)
                                {
                                    if ((item as ToolStripLabel).Tag.ToString().Equals("-1"))
                                    {
                                        (item as ToolStripLabel).Text = "";
                                    }
                                }
                            }
                        }
                        else if (item.GetType().Equals(typeof(ToolStripProgressBar)))
                        {
                            (item as ToolStripProgressBar).Value = 0;
                        }
                        else if (item.GetType().Equals(typeof(ToolStripTextBox)))
                        {
                            (item as ToolStripTextBox).Clear();
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="closePanel"></param>
        public static void ResetPanel(SplitContainer panel, bool closePanel = true)
        {
            /** Método ResetPanel
            *   - recebe o split container 'panel' a ser limpo
            *   - recebe a variável 'closePanel'
            *
            *   Limpa o split container fornecido.
            *   Se 'closePanel' for verdadeiro, limpa, também, os datagridviews do painel.
            *   Se a Tag de algum rótulo for "-1", limpa o rótulo.
            */
            foreach (SplitterPanel splitter in panel.Controls)
            {
                for (int i = splitter.Controls.Count - 1; i >= 0; i--)
                {
                    if (splitter.Controls[i].GetType().Equals(typeof(ComboBox)))
                    {
                        (splitter.Controls[i] as ComboBox).SelectedIndex = -1;
                    }
                    else if (splitter.Controls[i].GetType().Equals(typeof(DataGridView)))
                    {
                        if (closePanel) (splitter.Controls[i] as DataGridView).DataSource = null;
                    }
                    else if (splitter.Controls[i].GetType().Equals(typeof(Label)))
                    {
                        if ((splitter.Controls[i] as Label).Tag != null)
                        {
                            if ((splitter.Controls[i] as Label).Tag.ToString().Equals("-1"))
                            {
                                (splitter.Controls[i] as Label).Text = "";
                            }
                        }
                    }
                    else if (splitter.Controls[i].GetType().Equals(typeof(ListBox)))
                    {
                        (splitter.Controls[i] as ListBox).SelectedIndex = -1;
                    }
                    else if (splitter.Controls[i].GetType().Equals(typeof(ListView)))
                    {
                        (splitter.Controls[i] as ListView).Items.Clear();
                    }
                    else if (splitter.Controls[i].GetType().Equals(typeof(MaskedTextBox)))
                    {
                        (splitter.Controls[i] as MaskedTextBox).Clear();
                    }
                    else if (splitter.Controls[i].GetType().Equals(typeof(NumericUpDown)))
                    {
                        (splitter.Controls[i] as NumericUpDown).Value = (panel.Controls[i] as NumericUpDown).Minimum;
                    }
                    else if (splitter.Controls[i].GetType().Equals(typeof(Panel)))
                    {
                        ResetPanel(splitter.Controls[i] as Panel, closePanel);
                    }
                    else if (splitter.Controls[i].GetType().Equals(typeof(SplitContainer)))
                    {
                        ResetPanel(splitter.Controls[i] as SplitContainer, closePanel);
                    }
                    else if (splitter.Controls[i].GetType().Equals(typeof(TextBox)))
                    {
                        (splitter.Controls[i] as TextBox).Clear();
                    }
                    else if (splitter.Controls[i].GetType().Equals(typeof(ToolStrip)))
                    {
                        foreach (ToolStripItem item in (splitter.Controls[i] as ToolStrip).Items)
                        {
                            if (item.GetType().Equals(typeof(ToolStripComboBox)))
                            {
                                (item as ToolStripComboBox).SelectedIndex = -1;
                            }
                            else if (item.GetType().Equals(typeof(ToolStripLabel)))
                            {
                                if ((item as ToolStripLabel).Tag != null)
                                {
                                    if ((item as ToolStripLabel).Tag != null)
                                    {
                                        if ((item as ToolStripLabel).Tag.ToString().Equals("-1"))
                                        {
                                            (item as ToolStripLabel).Text = "";
                                        }
                                    }
                                }
                            }
                            else if (item.GetType().Equals(typeof(ToolStripProgressBar)))
                            {
                                (item as ToolStripProgressBar).Value = 0;
                            }
                            else if (item.GetType().Equals(typeof(ToolStripTextBox)))
                            {
                                (item as ToolStripTextBox).Clear();
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public static bool SelectFirstControl(Control control, bool order, int loopBreak = 50)
        {
            if (control.CanSelect)
            {
                control.Select();
                return true;
            }
            else
            {
                int count = 0;
                while (!control.CanSelect)
                {
                    control = control.GetNextControl(control, order);
                    count++;
                    if (count.Equals(loopBreak))return false;
                }
                control.Select();
                return true;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sender"></param>
        /// <param name="key"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static bool TryGetTag<T>(object sender, string key, out T result)
        {
            Dictionary<string, string> tags = new Dictionary<string, string>();
            if ((sender as Control).Tag is null)
            {
                result = default;
                return false;
            }
            string[] tagValue = (sender as Control).Tag.ToString().Split(';');
            foreach (string tag in tagValue) tags.Add(tag.Split(':')[0], tag.Split(':')[1]);
            try
            {
                result = (T)Convert.ChangeType(tags[key], typeof(T));
                return true;
            }
            catch
            {
                result = default;
                return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        public static bool ValidateEmail(string Email)
        {
            if (string.IsNullOrWhiteSpace(Email)) return false;
            try
            {
                Email = Regex.Replace(Email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));
                string DomainMapper(Match match)
                {
                    var idn = new IdnMapping();
                    string domainName = idn.GetAscii(match.Groups[2].Value);
                    return match.Groups[1].Value + domainName;
                }
            }
            catch { return false; }
            try
            {
                return Regex.IsMatch(Email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch { return false; }
        }
    }
}
