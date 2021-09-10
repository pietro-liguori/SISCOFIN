using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISCOFIN_v1
{
    public partial class TagBox : UserControl
    {
        private static SortedDictionary<long, string> selectedItems;
        public Font ComboBoxFont { get => TagSource.Font; set => TagSource.Font = value; }
        public string ComboBoxText { get => TagSource.Text; set => TagSource.Text = value; }
        [DefaultValue(null)]
        [Browsable(false)]
        public object DataSource { get => TagSource.DataSource; set => TagSource.DataSource = value; }
        [Browsable(false)]
        public string DisplayMember { get => TagSource.DisplayMember; set => TagSource.DisplayMember = value; }
        [Browsable(false)]
        public string ValueMember { get => TagSource.ValueMember; set => TagSource.ValueMember = value; }
        public bool SubtitleAutoSize { get => Subtitle.AutoSize; set => Subtitle.AutoSize = value; }
        public Color SubtitleBackColor { get => Subtitle.BackColor; set => Subtitle.BackColor = value; }
        public Font SubtitleFont { get => Subtitle.Font; set => Subtitle.Font = value; }
        public Color SubtitleForeColor { get => Subtitle.ForeColor; set => Subtitle.ForeColor = value; }
        public Padding SubtitlePadding { get => Subtitle.Padding; set => Subtitle.Padding = value; }
        public Size SubtitleSize { get => Subtitle.Size; set => Subtitle.Size = value; }
        public string SubtitleText { get => Subtitle.Text; set => Subtitle.Text = value; }
        public bool TitleAutoSize { get => Title.AutoSize; set => Title.AutoSize = value; }
        public Color TitleBackColor { get => Title.BackColor; set => Title.BackColor = value; }
        public Font TitleFont { get => Title.Font; set => Title.Font = value; }
        public Color TitleForeColor { get => Title.ForeColor; set => Title.ForeColor = value; }
        public Padding TitlePadding { get => Title.Padding; set => Title.Padding = value; }
        public Size TitleSize { get => Title.Size; set => Title.Size = value; }
        public string TitleText { get => Title.Text; set => Title.Text = value; }
        [Browsable(false)]
        public SortedDictionary<long, string> SelectedItems { get => selectedItems; set => selectedItems = value; }
        [Browsable(false)]
        public int SelectedIndex { get => TagSource.SelectedIndex; set => TagSource.SelectedIndex = value; }
        public TagBox()
        {
            InitializeComponent();
            selectedItems = new SortedDictionary<long, string>();
            SelectedItems = new SortedDictionary<long, string>();
            TitleText = string.Empty;
            SubtitleText = string.Empty;
            TagSource.KeyPress += new KeyPressEventHandler(MyEvents.NoTyping);
            TagSource.KeyDown += new KeyEventHandler(MyEvents.ComboBoxDelBack);

        }
        public void Clear()
        {
            if (SelectedItems == null) return;
            TagFlow.Controls.Clear();
            SelectedItems.Clear();
        }
        public void Add(DataTable dataSource)
        {
            if (SelectedItems == null) SelectedItems = new SortedDictionary<long, string>();
            foreach (DataRow row in dataSource.Rows)
            {
                FlowLayoutPanel fl = new FlowLayoutPanel
                {
                    AutoSize = true,
                    Dock = DockStyle.Left,
                    Margin = new Padding(0, 0, 2, 2),
                    Name = "tag" + (long)row["Id"]
                };
                fl.Show();
                TagFlow.Controls.Add(fl);
                Label lb = new Label
                {
                    Text = (string)row["Name"],
                    TextAlign = ContentAlignment.MiddleLeft,
                    BackColor = Color.FromArgb(230, 230, 230),
                    Font = new Font("Segoe UI", 10),
                    ForeColor = Color.FromArgb(50, 50, 50),
                    Margin = new Padding(0),
                    AutoSize = true,
                    Name = "tagLabel" + (long)row["Id"]
                };
                lb.Show();
                fl.Controls.Add(lb);
                PictureBox pb = new PictureBox
                {
                    Image = Properties.Resources.Close_8x8,
                    BackColor = Color.FromArgb(230, 230, 230),
                    SizeMode = PictureBoxSizeMode.CenterImage,
                    Size = new Size(lb.Size.Height, lb.Size.Height),
                    Margin = new Padding(0),
                    Cursor = Cursors.Hand,
                    Name = "tagButton" + (long)row["Id"]
                };
                pb.Click += new EventHandler(TagCloseClick);
                pb.Show();
                fl.Controls.Add(pb);
                SelectedItems.Add((long)row["Id"], (string)row["Name"]);
            }
            TagSource.SelectedIndex = -1;
        }
        public void Add(Dictionary<long, string> dataSource)
        {
            foreach (KeyValuePair<long, string> pair in dataSource)
            {
                FlowLayoutPanel fl = new FlowLayoutPanel
                {
                    AutoSize = true,
                    Dock = DockStyle.Left,
                    Margin = new Padding(0, 0, 2, 2),
                    Name = "tag" + pair.Key
                };
                fl.Show();
                TagFlow.Controls.Add(fl);
                Label lb = new Label
                {
                    Text = pair.Value,
                    TextAlign = ContentAlignment.MiddleLeft,
                    BackColor = Color.FromArgb(230, 230, 230),
                    Font = new Font("Segoe UI", 10),
                    ForeColor = Color.FromArgb(50, 50, 50),
                    Margin = new Padding(0),
                    AutoSize = true,
                    Name = "tagLabel" + pair.Key
                };
                lb.Show();
                fl.Controls.Add(lb);
                PictureBox pb = new PictureBox
                {
                    Image = Properties.Resources.Close_8x8,
                    BackColor = Color.FromArgb(230, 230, 230),
                    SizeMode = PictureBoxSizeMode.CenterImage,
                    Size = new Size(lb.Size.Height, lb.Size.Height),
                    Margin = new Padding(0),
                    Cursor = Cursors.Hand,
                    Name = "tagButton" + pair.Key
                };
                pb.Click += new EventHandler(TagCloseClick);
                pb.Show();
                fl.Controls.Add(pb);
                SelectedItems.Add(pair.Key, pair.Value);
            }
            TagSource.SelectedIndex = -1;
        }
        public void Add(SortedDictionary<long, string> dataSource)
        {
            foreach (KeyValuePair<long, string> pair in dataSource)
            {
                FlowLayoutPanel fl = new FlowLayoutPanel
                {
                    AutoSize = true,
                    Dock = DockStyle.Left,
                    Margin = new Padding(0, 0, 2, 2),
                    Name = "tag" + pair.Key
                };
                fl.Show();
                TagFlow.Controls.Add(fl);
                Label lb = new Label
                {
                    Text = pair.Value,
                    TextAlign = ContentAlignment.MiddleLeft,
                    BackColor = Color.FromArgb(230, 230, 230),
                    Font = new Font("Segoe UI", 10),
                    ForeColor = Color.FromArgb(50, 50, 50),
                    Margin = new Padding(0),
                    AutoSize = true,
                    Name = "tagLabel" + pair.Key
                };
                lb.Show();
                fl.Controls.Add(lb);
                PictureBox pb = new PictureBox
                {
                    Image = Properties.Resources.Close_8x8,
                    BackColor = Color.FromArgb(230, 230, 230),
                    SizeMode = PictureBoxSizeMode.CenterImage,
                    Size = new Size(lb.Size.Height, lb.Size.Height),
                    Margin = new Padding(0),
                    Cursor = Cursors.Hand,
                    Name = "tagButton" + pair.Key
                };
                pb.Click += new EventHandler(TagCloseClick);
                pb.Show();
                fl.Controls.Add(pb);
                SelectedItems.Add(pair.Key, pair.Value);
            }
            TagSource.SelectedIndex = -1;
        }
        public void Remove(int key)
        {
            SelectedItems.Remove(key);
            TagFlow.Controls.RemoveByKey("tag" + key);
        }
        public void RemoveAt(int index)
        {
            SelectedItems.Remove(int.Parse(TagFlow.Controls[index].Name.Substring(3)));
            TagFlow.Controls.RemoveAt(index);
        }
        private void TagCloseClick(object sender, EventArgs e) 
        { 
            Remove(int.Parse((sender as PictureBox).Name.Substring(9)));
            TagSource.Focus();
        }
        private void SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Globals.IsRunning) return;
            ComboBox me = sender as ComboBox;
            if (me.SelectedIndex.Equals(-1)) return;
            if (SelectedItems != null)
            {
                if (SelectedItems.ContainsKey((long)me.SelectedValue))
                {
                    me.SelectedIndex = -1;
                    return;
                }
            }
            DataTable dataSource = new DataTable();
            dataSource.Columns.Add("Id", typeof(long));
            dataSource.Columns.Add("Name", typeof(string));
            dataSource.Rows.Add((long)me.SelectedValue, me.Text);
            Add(dataSource);
        }
        private void TagsResize(object sender, EventArgs e)
        {
            Size = new Size(Size.Width, TagFlow.Size.Height + TagSource.Size.Height);
        }
        private void DropList(object sender, EventArgs e)
        {
            TagSource.DroppedDown = true;
        }
    }
}
