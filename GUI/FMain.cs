using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TrungTamNgoaiNgu.GUI.QLKhoaThi;
using TrungTamNgoaiNgu.GUI.QLPhongThi;
using TrungTamNgoaiNgu.GUI.QLThiSinh;

namespace TrungTamNgoaiNgu.GUI
{
    public partial class FMain : Form
    {
        public FMain()
        {
            InitializeComponent();
            GetPage(new FKhoaThi());
        }

        //
        //  public - open
        //
        public static void GetPage(Form F)
        {
            foreach (Form form in pnlContent.Controls.OfType<Form>().ToArray()) { form.Close(); };
            F.TopLevel = false;
            F.Dock = DockStyle.Fill;
            try
            {
                F.Show();
            }
            catch
            {
                MessageBox.Show("Lỗi thao tác!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            pnlContent.Controls.Add(F);
        }

        //
        // setVisibleColDataGridView
        //
        public static void setVisibleColDataGridView(DataGridView dataGridView, string coloumnName)
        {
            try
            {
                dataGridView.Columns[coloumnName].Visible = false;
            }
            catch { }
        }

        public static void setVisibleColDataGridView(DataGridView dataGridView, string column, bool visible)
        {
            try
            {
                dataGridView.Columns[column].Visible = visible;
            }
            catch { }
        }

        public static void setVisibleColDataGridView(DataGridView dataGridView, string[] columnNames)
        {
            foreach (string col in columnNames)
            {
                try
                {
                    dataGridView.Columns[col].Visible = false;
                }
                catch { }
            }
        }

        public static void setVisibleColDataGridView(DataGridView dataGridView, string[] columnNames, bool visible)
        {
            foreach (string col in columnNames)
            {
                try
                {
                    dataGridView.Columns[col].Visible = visible;
                }
                catch { }
            }
        }

        public static void setVisibleColDataGridView(DataGridView dataGridView, int columnIndex)
        {
            try
            {
                dataGridView.Columns[columnIndex].Visible = false;
            }
            catch { }
        }

        public static void setVisibleColDataGridView(DataGridView dataGridView, int columnIndex, bool visible)
        {
            try
            {
                dataGridView.Columns[columnIndex].Visible = visible;
            }
            catch { }
        }

        public static void setVisibleColDataGridView(DataGridView dataGridView, int[] colIndex)
        {
            foreach (int col in colIndex)
            {
                try
                {
                    dataGridView.Columns[col].Visible = false;
                }
                catch { }
            }
        }

        public static void setVisibleColDataGridView(DataGridView dataGridView, int[] colIndex, bool visible)
        {
            foreach (int col in colIndex)
            {
                try
                {
                    dataGridView.Columns[col].Visible = visible;
                }
                catch { }
            }
        }

        //
        // setSizeColDataGridView
        //
        public static void setSizeColDataGridView(DataGridView dataGridView, string columnName)
        {
            try
            {
                dataGridView.Columns[columnName].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch { }
        }

        public static void setSizeColDataGridView(DataGridView dataGridView, string[] columnNames)
        {
            foreach (string col in columnNames)
            {
                try
                {
                    dataGridView.Columns[col].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                catch { }
            }
        }

        public static void setSizeColDataGridView(DataGridView dataGridView, int columnIndex)
        {
            try
            {
                dataGridView.Columns[columnIndex].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch { }
        }

        public static void setSizeColDataGridView(DataGridView dataGridView, int[] columnIndexs)
        {
            foreach (int col in columnIndexs)
            {
                try
                {
                    dataGridView.Columns[col].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                catch { }
            }
        }

        public static void setSizeColDataGridView(DataGridView dataGridView, string columnName, DataGridViewAutoSizeColumnMode mode)
        {
            try
            {
                dataGridView.Columns[columnName].AutoSizeMode = mode;
            }
            catch { }
        }

        public static void setSizeColDataGridView(DataGridView dataGridView, string[] columnNames, DataGridViewAutoSizeColumnMode mode)
        {
            foreach (string col in columnNames)
            {
                try
                {
                    dataGridView.Columns[col].AutoSizeMode = mode;
                }
                catch { }
            }
        }

        public static void setSizeColDataGridView(DataGridView dataGridView, int columnIndex, DataGridViewAutoSizeColumnMode mode)
        {
            try
            {
                dataGridView.Columns[columnIndex].AutoSizeMode = mode;
            }
            catch { }
        }

        public static void setSizeColDataGridView(DataGridView dataGridView, int[] columnIndexs, DataGridViewAutoSizeColumnMode mode)
        {
            foreach (int col in columnIndexs)
            {
                try
                {
                    dataGridView.Columns[col].AutoSizeMode = mode;
                }
                catch { }
            }
        }

        //
        // setHeaderColDataGridView
        //
        public static void setHeaderColDataGridView(DataGridView dataGridView, int columnIndex, string text)
        {
            try
            {
                dataGridView.Columns[columnIndex].HeaderText = text;
            }
            catch { }
        }

        public static void setHeaderColDataGridView(DataGridView dataGridView, int[] columnIndexs, string[] texts)
        {
            if (columnIndexs.Length == texts.Length)
            {
                for (int i = 0; i < columnIndexs.Length; i++)
                {
                    try
                    {
                        dataGridView.Columns[columnIndexs[i]].HeaderText = texts[i];
                    }
                    catch { }
                }
            }
        }

        public static void setHeaderColDataGridView(DataGridView dataGridView, string columnName, string text)
        {
            try
            {
                dataGridView.Columns[columnName].HeaderText = text;
            }
            catch { }
        }

        public static void setHeaderColDataGridView(DataGridView dataGridView, string[] columnNames, string[] texts)
        {
            if (columnNames.Length == texts.Length)
            {

                for (int i = 0; i < columnNames.Length; i++)
                {
                    try
                    {
                        dataGridView.Columns[columnNames[i]].HeaderText = texts[i];
                    }
                    catch { }
                }
            }
            else
            {
                throw new Exception("coloumnNames length or texts length not same!!!");
            }
        }

        //
        // formatDateTime
        //
        private const string dateFormat = "dd/MM/yyyy";
        public static void formatDateTime(DataGridView dataGridView, int columnIndex)
        {
            try
            {
                dataGridView.Columns[columnIndex].DefaultCellStyle.Format = dateFormat;
            }
            catch { }
        }

        public static void formatDateTime(DataGridView dataGridView, string columnName)
        {
            try
            {
                dataGridView.Columns[columnName].DefaultCellStyle.Format = dateFormat;
            }
            catch { }
        }

        public static void formatDateTime(DataGridView dataGridView, int[] columnIndexs)
        {
            foreach (int col in columnIndexs)
            {
                try
                {
                    dataGridView.Columns[col].DefaultCellStyle.Format = dateFormat;
                }
                catch { }
            }
        }

        public static void formatDateTime(DataGridView dataGridView, string[] columnNames)
        {
            foreach (string col in columnNames)
            {
                try
                {
                    dataGridView.Columns[col].DefaultCellStyle.Format = dateFormat;
                }
                catch { }
            }
        }

        //
        // setAlignDataGridView
        //
        public static void setAlignDataGridView(DataGridView dataGridView, int columnIndex, DataGridViewContentAlignment align)
        {
            try
            {
                dataGridView.Columns[columnIndex].DefaultCellStyle.Alignment = align;
            }
            catch { }
        }

        public static void setAlignDataGridView(DataGridView dataGridView, string columnName, DataGridViewContentAlignment align)
        {
            try
            {
                dataGridView.Columns[columnName].DefaultCellStyle.Alignment = align;
            }
            catch { }
        }

        public static void setAlignDataGridView(DataGridView dataGridView, int[] columnIndexs, DataGridViewContentAlignment align)
        {
            foreach (int col in columnIndexs)
            {
                try
                {
                    dataGridView.Columns[col].DefaultCellStyle.Alignment = align;
                }
                catch { }
            }
        }

        public static void setAlignDataGridView(DataGridView dataGridView, string[] columnNames, DataGridViewContentAlignment align)
        {
            foreach (string col in columnNames)
            {
                try
                {
                    dataGridView.Columns[col].DefaultCellStyle.Alignment = align;
                }
                catch { }
            }
        }

        //
        // setAlignNumberDataGridView
        //
        private const DataGridViewContentAlignment numberAlign = DataGridViewContentAlignment.MiddleRight;
        public static void setAlignNumberDataGridView(DataGridView dataGridView, int columnIndex)
        {
            try
            {
                dataGridView.Columns[columnIndex].DefaultCellStyle.Alignment = numberAlign;
            }
            catch { }
        }

        public static void setAlignNumberDataGridView(DataGridView dataGridView, string columnName)
        {
            try
            {
                dataGridView.Columns[columnName].DefaultCellStyle.Alignment = numberAlign;
            }
            catch { }
        }

        public static void setAlignNumberDataGridView(DataGridView dataGridView, int[] columnIndexs)
        {
            foreach (int col in columnIndexs)
            {
                try
                {
                    dataGridView.Columns[col].DefaultCellStyle.Alignment = numberAlign;
                }
                catch { }
            }
        }

        public static void setAlignNumberDataGridView(DataGridView dataGridView, string[] columnNames)
        {
            foreach (string col in columnNames)
            {
                try
                {
                    dataGridView.Columns[col].DefaultCellStyle.Alignment = numberAlign;
                }
                catch { }
            }
        }

        //
        // formatPrice
        //
        private const string numberFormnat = "N0";

        public static void formatPriceDataGridView(DataGridView dataGridView, int columnIndex)
        {
            try
            {
                dataGridView.Columns[columnIndex].DefaultCellStyle.Format = numberFormnat;
                dataGridView.Columns[columnIndex].DefaultCellStyle.Alignment = numberAlign;
            }
            catch { }
        }

        public static void formatPriceDataGridView(DataGridView dataGridView, string columnName)
        {
            try
            {
                dataGridView.Columns[columnName].DefaultCellStyle.Format = numberFormnat;
                dataGridView.Columns[columnName].DefaultCellStyle.Alignment = numberAlign;
            }
            catch { }
        }

        public static void formatPriceDataGridView(DataGridView dataGridView, int[] columnIndexs)
        {
            foreach (int col in columnIndexs)
            {
                try
                {
                    dataGridView.Columns[col].DefaultCellStyle.Format = numberFormnat;
                    dataGridView.Columns[col].DefaultCellStyle.Alignment = numberAlign;
                }
                catch { }
            }
        }

        public static void formatPriceDataGridView(DataGridView dataGridView, string[] columnNames)
        {
            foreach (string col in columnNames)
            {
                try
                {
                    dataGridView.Columns[col].DefaultCellStyle.Format = numberFormnat;
                    dataGridView.Columns[col].DefaultCellStyle.Alignment = numberAlign;
                }
                catch { }
            }
        }

        //
        // format
        //
        public static string formatDateTime(DateTime dateTime)
        {
            return String.Format("{0:dd/MM/yyyy}", dateTime);
        }

        public static string formatDateTime(DateTime? dateTime)
        {
            return String.Format("{0:dd/MM/yyyy}", dateTime);
        }

        public static string formatPrice(double value)
        {
            return String.Format(System.Globalization.CultureInfo.InvariantCulture, "{0:0,0}", value);
        }

        public static string formatPrice(string value)
        {
            try
            {
                return String.Format(System.Globalization.CultureInfo.InvariantCulture, "{0:0,0}", double.Parse(value));
            }
            catch
            {
                throw new FormatException("Lỗi format");
            }
        }

        //
        // SetVisibleBtns
        //
        public static void SetVisible(Button button, bool b)
        {
            if (button.Visible != b && button.Enabled != b)
            {
                button.Visible = b;
                button.Enabled = b;
            }
        }

        public static void SetVisible(List<Button> buttons, bool b)
        {
            foreach (Button button in buttons)
            {
                if (button.Visible != b && button.Enabled != b)
                {
                    button.Visible = b;
                    button.Enabled = b;
                }
            }
        }



        //
        //  public - closed
        //

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Có phải bạn muốn thoát chương trình ?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void resetStyles()
        {
            btnQLKhoaThi.BackColor = Color.DodgerBlue;
            btnQLKhoaThi.ForeColor = Color.White;
            btnQLPhongThi.BackColor = Color.DodgerBlue;
            btnQLPhongThi.ForeColor = Color.White;
            btnQLThiSinh.BackColor = Color.DodgerBlue;
            btnQLThiSinh.ForeColor = Color.White;
        }

        private void btnQLKhoaThi_Click(object sender, EventArgs e)
        {
            resetStyles();
            btnQLKhoaThi.BackColor = Color.White;
            btnQLKhoaThi.ForeColor = Color.DodgerBlue;
            GetPage(new FKhoaThi());
        }

        private void btnQLPhongThi_Click(object sender, EventArgs e)
        {
            resetStyles();
            btnQLPhongThi.BackColor = Color.White;
            btnQLPhongThi.ForeColor = Color.DodgerBlue;
            GetPage(new FPhongThi());
        }

        private void btnQLThiSinh_Click(object sender, EventArgs e)
        {
            resetStyles();
            btnQLThiSinh.BackColor = Color.White;
            btnQLThiSinh.ForeColor = Color.DodgerBlue;
            GetPage(new FThiSinh());
        }
    }
}
