using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _6laba.DataSet1TableAdapters;
using System.Data.OleDb;

namespace _6laba
{
    public partial class Form1 : Form
    {
        public Int32 temp1 = -1;
        public Int32 temp2 = -1;
        public Int32 temp3 = -1;
        public Int32 tempClient1 = -1;
        public Int32 tempLot1 = -1;
        public Int32 tempLot4 = -1;
        public Int32 tempLot3 = -1;
        public DateTime tempLot5;
        public DateTime tempLot6;
        public Form1()
        {
            InitializeComponent();
            bindingNavigator1.BindingSource = сделкаBindingSource;
            bindingNavigator2.BindingSource = лотBindingSource;
            bindingNavigator3.BindingSource = клиентBindingSource;
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.Клиент". При необходимости она может быть перемещена или удалена.
            this.клиентTableAdapter.Fill(this.dataSet1.Клиент);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.Лот". При необходимости она может быть перемещена или удалена.
            this.лотTableAdapter.Fill(this.dataSet1.Лот);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.Сделка". При необходимости она может быть перемещена или удалена.
            this.сделкаTableAdapter.Fill(this.dataSet1.Сделка);
            
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void открытьОдиночнуюЗаписьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void bindingNavigator2_RefreshItems(object sender, EventArgs e)
        {

        }

        private void toolStripButton19_Click(object sender, EventArgs e)
        {
            try
            {
                this.сделкаTableAdapter.Update(dataSet1.Сделка);
                dataSet1.AcceptChanges();
                MessageBox.Show("Данные успешно сохранены!");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Ошибка! Нарушена целостность данных");
            }
        }

        private void сохранитьToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.лотTableAdapter.Update(dataSet1.Лот);
                dataSet1.AcceptChanges();
                MessageBox.Show("Данные успешно сохранены!");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Ошибка! Нарушена целостность данных");
            }
        }

        private void toolStripButton20_Click(object sender, EventArgs e)
        {
            try
            {
                this.клиентTableAdapter.Update(dataSet1.Клиент);
                dataSet1.AcceptChanges();
                MessageBox.Show("Данные успешно сохранены!");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Ошибка! Нарушена целостность данных");
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dataGridView2_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
                DataGridViewCell cell = dataGridView1.CurrentCell;
                if (cell.ValueType.Name == "DateTime")
                {
                    MessageBox.Show("Была введена неверная дата!");
                }
                if (cell.ValueType.Name == "Int32")
                {
                    if (e.Exception.TargetSite.DeclaringType.Name == "UniqueConstraint")
                    {
                        MessageBox.Show("Введены неверные данные! Необходимо ввести уникальный ключ.");
                    }
                    else
                    {
                        MessageBox.Show("Введены неверные данные! Необходимо ввести натуральное число.");
                    }
                }
            }
            catch (Exception exp)
            {

            }
            
        }

        private void dataGridView2_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView2_RowLeave(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(tempLot3 != -1 && tempLot4 != -1)
                {
                    DataGridViewCell cell = dataGridView2.CurrentCell;
                    DataRowCollection rows = dataSet1.Лот.Rows;
                    if (cell.ColumnIndex == 0)
                    {
                        Int32 thisPK = System.Convert.ToInt32(cell.Value.ToString());
                        for (int i = 0; i < rows.Count; i++)
                        {
                            if (i == лотBindingSource.Position)
                            {
                                continue;
                            }
                            if (thisPK == System.Convert.ToInt32(rows[i][0].ToString()))
                            {
                                MessageBox.Show("Ошибка! Повторяющийся первичный ключ");
                                rows[лотBindingSource.Position][0] = tempLot1;
                            }
                        }
                    }

                    if (cell.ColumnIndex == 4)
                        if (tempLot6 < System.Convert.ToDateTime(cell.Value.ToString()))
                        {
                            MessageBox.Show("Ошибка! Дата продажи должна быть не раньше даты выставления");
                            rows[cell.RowIndex][4] = tempLot5;
                            rows[cell.RowIndex][5] = tempLot6;
                        }
                    if (cell.ColumnIndex == 5)
                        if (System.Convert.ToDateTime(cell.Value.ToString()) < tempLot5)
                        {
                            MessageBox.Show("Ошибка! Дата продажи должна быть не раньше даты выставления");
                            rows[cell.RowIndex][4] = tempLot5;
                            rows[cell.RowIndex][5] = tempLot6;
                        }

                    if (cell.ColumnIndex == 3)
                    {
                        if (System.Convert.ToInt32(cell.Value.ToString()) < 0)
                        {
                            MessageBox.Show("Ошибка! Стоимость не может быть отрицательной");
                            rows[cell.RowIndex][2] = tempLot3;
                            rows[cell.RowIndex][3] = tempLot4;
                        }
                        if (System.Convert.ToInt32(cell.Value.ToString()) < tempLot3)
                        {
                            MessageBox.Show("Ошибка! Начальная стоимость должна не меньше стоимости продажи");
                            rows[cell.RowIndex][2] = tempLot3;
                            rows[cell.RowIndex][3] = tempLot4;
                        }
                    }
                    if (cell.ColumnIndex == 2)
                    {
                        if (System.Convert.ToInt32(cell.Value.ToString()) < 0)
                        {
                            MessageBox.Show("Ошибка! Стоимость не может быть отрицательной");
                            rows[cell.RowIndex][2] = tempLot3;
                            rows[cell.RowIndex][3] = tempLot4;
                        }
                        if (tempLot4 < System.Convert.ToInt32(cell.Value.ToString()))
                        {
                            MessageBox.Show("Ошибка! Начальная стоимость должна не меньше стоимости продажи");
                            rows[cell.RowIndex][2] = tempLot3;
                            rows[cell.RowIndex][3] = tempLot4;
                        }
                    }
                }
                
            }
            catch (Exception exp)
            {

            }
        }

        private void dataGridView2_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                DataGridViewCell cell = dataGridView2.CurrentCell;
                DataRowCollection rows = dataSet1.Лот.Rows;
                tempLot5 = System.Convert.ToDateTime(rows[cell.RowIndex][4]);
                tempLot6 = System.Convert.ToDateTime(rows[cell.RowIndex][5]);
                tempLot3 = System.Convert.ToInt32(rows[cell.RowIndex][2].ToString());
                tempLot4 = System.Convert.ToInt32(rows[cell.RowIndex][3].ToString());
                tempLot1 = System.Convert.ToInt32(rows[cell.RowIndex][0].ToString());
            }
            catch (Exception exp)
            {

            }
            
        }

        private void dataGridView3_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                DataGridViewCell cell = dataGridView3.CurrentCell;
                DataRowCollection rows = dataSet1.Клиент.Rows;
                tempClient1 = System.Convert.ToInt32(rows[cell.RowIndex][0].ToString());
            }
            catch (Exception exp)
            {

            }
           
        }

        private void dataGridView3_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewCell cell = dataGridView3.CurrentCell;
                DataRowCollection rows = dataSet1.Клиент.Rows;
                if (cell.ColumnIndex == 0)
                {
                    Int32 thisPK = System.Convert.ToInt32(cell.Value.ToString());
                    for (int i = 0; i < rows.Count; i++)
                    {
                        if (i == клиентBindingSource.Position)
                        {
                            continue;
                        }
                        if (thisPK == System.Convert.ToInt32(rows[i][0].ToString()))
                        {
                            MessageBox.Show("Ошибка! Повторяющийся первичный ключ");
                            rows[клиентBindingSource.Position][0] = tempClient1;
                        }
                    }
                }
            }
            catch (Exception exp)
            {

            }
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                DataGridViewCell cell = dataGridView1.CurrentCell;
                DataRowCollection rows = dataSet1.Сделка.Rows;
                temp1 = System.Convert.ToInt32(rows[cell.RowIndex][0].ToString());
                temp2 = System.Convert.ToInt32(rows[cell.RowIndex][1].ToString());
                temp3 = System.Convert.ToInt32(rows[cell.RowIndex][2].ToString());
            }
            catch (Exception exp)
            {

            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(temp1 != -1 && temp2 != -1 && temp3 != -1)
                {
                    DataGridViewCell cell = dataGridView1.CurrentCell;
                    DataRowCollection rows = dataSet1.Сделка.Rows;
                    if (cell.ColumnIndex == 0)
                    {
                        Int32 thisPK = System.Convert.ToInt32(cell.Value.ToString());
                        if (thisPK == temp2)
                        {
                            MessageBox.Show("Ошибка! Покупатель и продавец не должны совпадать");
                            rows[сделкаBindingSource.Position][0] = temp1;
                        }
                        DataRowCollection rowsClient = dataSet1.Клиент.Rows;
                        bool isFinded = false;
                        for (int i = 0; i < rowsClient.Count; i++)
                        {
                            if (thisPK == System.Convert.ToInt32(rowsClient[i][0].ToString()))
                            {
                                isFinded = true;
                            }
                        }
                        if (!isFinded)
                        {
                            MessageBox.Show("Ошибка! Не существует такого первичного ключа");
                            rows[сделкаBindingSource.Position][0] = temp1;
                        }
                    }
                    if (cell.ColumnIndex == 1)
                    {
                        Int32 thisPK = System.Convert.ToInt32(cell.Value.ToString());
                        if (thisPK == temp1)
                        {
                            MessageBox.Show("Ошибка! Покупатель и продавец не должны совпадать");
                            rows[сделкаBindingSource.Position][1] = temp2;
                        }
                        DataRowCollection rowsClient = dataSet1.Клиент.Rows;
                        bool isFinded = false;
                        for (int i = 0; i < rowsClient.Count; i++)
                        {
                            if (thisPK == System.Convert.ToInt32(rowsClient[i][0].ToString()))
                            {
                                isFinded = true;
                            }
                        }
                        if (!isFinded)
                        {
                            MessageBox.Show("Ошибка! Не существует такого первичного ключа");
                            rows[сделкаBindingSource.Position][1] = temp2;
                        }
                    }
                    if (cell.ColumnIndex == 2)
                    {
                        Int32 thisPK = System.Convert.ToInt32(cell.Value.ToString());
                        DataRowCollection rowsLot = dataSet1.Лот.Rows;
                        bool isFinded = false;
                        for (int i = 0; i < rowsLot.Count; i++)
                        {
                            if (thisPK == System.Convert.ToInt32(rowsLot[i][0].ToString()))
                            {
                                isFinded = true;
                            }
                        }
                        if (!isFinded)
                        {
                            MessageBox.Show("Ошибка! Не существует такого первичного ключа");
                            rows[сделкаBindingSource.Position][2] = temp3;
                        }
                    }
                }
                
            }
            catch (Exception exp)
            {

            }
        }
    }
}
