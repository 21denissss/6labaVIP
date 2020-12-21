using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _6laba
{
    public partial class Form2 : Form
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
        public Form2()
        {
            InitializeComponent();
            this.bindingNavigator1.BindingSource = this.bindingSource1;
            textBox1.DataBindings.Add("Text", bindingSource1, "Код клиента-продавца", true);
            textBox2.DataBindings.Add("Text", bindingSource1, "Код клиента-покупателя", true);
            textBox3.DataBindings.Add("Text", bindingSource1, "Код лота", true);

            this.bindingNavigator2.BindingSource = this.bindingSource2;
            textBoxLot1.DataBindings.Add("Text", bindingSource2, "Код лота", true);
            textBoxLot2.DataBindings.Add("Text", bindingSource2, "Наименование", true);
            textBoxLot3.DataBindings.Add("Text", bindingSource2, "Начальная стоимость", true);
            textBoxLot4.DataBindings.Add("Text", bindingSource2, "Стоимость продажи", true);
            textBoxLot5.DataBindings.Add("Text", bindingSource2, "Дата выставления", true);
            textBoxLot6.DataBindings.Add("Text", bindingSource2, "Дата продажи", true);

            this.bindingNavigator3.BindingSource = this.bindingSource3;
            textBoxClient1.DataBindings.Add("Text", bindingSource3, "Код клиента", true);
            textBoxClient2.DataBindings.Add("Text", bindingSource3, "ФИО", true);
            textBoxClient3.DataBindings.Add("Text", bindingSource3, "Адрес", true);
            textBoxClient4.DataBindings.Add("Text", bindingSource3, "Паспортные данные", true);
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void открытьТабличнуюЗаписьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.form1.Show();
            Program.form1.Form1_Load(sender, e);
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.Клиент". При необходимости она может быть перемещена или удалена.
            this.клиентTableAdapter.Fill(this.dataSet1.Клиент);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.Лот". При необходимости она может быть перемещена или удалена.
            this.лотTableAdapter.Fill(this.dataSet1.Лот);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.Сделка". При необходимости она может быть перемещена или удалена.
            this.сделкаTableAdapter.Fill(this.dataSet1.Сделка);
        }

        private void сохранитьToolStripButton_Click(object sender, EventArgs e)
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

        private void toolStripButton13_Click(object sender, EventArgs e)
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

        private void toolStripButton14_Click(object sender, EventArgs e)
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

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.form1.Show();
            Program.form1.Form1_Load(sender, e);
            this.Hide();
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {

        }

        private void textBoxLot4_ControlRemoved(object sender, ControlEventArgs e)
        {
            
        }

        private void textBoxLot4_Leave(object sender, EventArgs e)
        {
            try
            {
                DataRowCollection rows = dataSet1.Лот.Rows;
                if (System.Convert.ToInt32(textBoxLot4.Text) > 0)
                    rows[bindingSource2.Position][3] = System.Convert.ToInt32(textBoxLot4.Text);
                else
                {
                    rows[bindingSource2.Position][3] = tempLot4;
                    MessageBox.Show("Ошибка! Стоимость не может быть отрицательной");
                }
                if (System.Convert.ToInt32(textBoxLot4.Text) < System.Convert.ToInt32(textBoxLot3.Text))
                {
                    MessageBox.Show("Ошибка! Начальная стоимость должна быть больше или равна стоимости продажи");
                    rows[bindingSource2.Position][3] = tempLot4;
                }
            }
            catch (Exception exp)
            {

            }
            
        }

        private void textBoxLot4_Enter(object sender, EventArgs e)
        {
            try
            {
                tempLot4 = System.Convert.ToInt32(textBoxLot4.Text);

            }
            catch (Exception exp)
            {

            }
        }

        private void textBoxLot3_Enter(object sender, EventArgs e)
        {
            try
            {
                tempLot3 = System.Convert.ToInt32(textBoxLot3.Text);

            }
            catch (Exception exp)
            {

            }
        }

        private void textBoxLot3_Leave(object sender, EventArgs e)
        {
            try
            {
                DataRowCollection rows = dataSet1.Лот.Rows;
                if (System.Convert.ToInt32(textBoxLot3.Text) > 0)
                    rows[bindingSource2.Position][2] = System.Convert.ToInt32(textBoxLot3.Text);
                else
                {
                    rows[bindingSource2.Position][2] = tempLot3;
                    MessageBox.Show("Ошибка! Стоимость не может быть отрицательной");
                }
                if (System.Convert.ToInt32(textBoxLot4.Text) < System.Convert.ToInt32(textBoxLot3.Text))
                {
                    rows[bindingSource2.Position][2] = tempLot3;
                    MessageBox.Show("Ошибка! Начальная стоимость должна быть больше или равна стоимости продажи");
                }
            }
            catch (Exception exp)
            {

            }
            
        }

        private void textBoxLot3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxLot5_Leave(object sender, EventArgs e)
        {
            try
            {
                DataRowCollection rows = dataSet1.Лот.Rows;
                if (System.Convert.ToDateTime(textBoxLot5.Text) > System.Convert.ToDateTime(textBoxLot6.Text))
                {
                    MessageBox.Show("Ошибка! Дата продажи должна быть не раньше даты выставления");
                    rows[bindingSource2.Position][4] = tempLot5;
                }
            }
            catch (Exception exp)
            {

            }
            
        }

        private void textBoxLot5_Enter(object sender, EventArgs e)
        {
            try
            {
                tempLot5 = System.Convert.ToDateTime(textBoxLot5.Text);

            }
            catch (Exception exp)
            {

            }
        }

        private void textBoxLot6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxLot6_Enter(object sender, EventArgs e)
        {
            try
            {
                tempLot6 = System.Convert.ToDateTime(textBoxLot6.Text);

            }
            catch (Exception exp)
            {

            }
        }

        private void textBoxLot6_Leave(object sender, EventArgs e)
        {
            try
            {
                DataRowCollection rows = dataSet1.Лот.Rows;
                if (System.Convert.ToDateTime(textBoxLot5.Text) > System.Convert.ToDateTime(textBoxLot6.Text))
                {
                    MessageBox.Show("Ошибка! Дата продажи должна быть не раньше даты выставления");
                    rows[bindingSource2.Position][5] = tempLot6;
                }
            }
            catch (Exception exp)
            {

            }
            
        }

        private void textBoxLot1_Leave(object sender, EventArgs e)
        {
            try
            {
                DataRowCollection rows = dataSet1.Лот.Rows;
                Int32 thisPK = System.Convert.ToInt32(textBoxLot1.Text);
                //MessageBox.Show(thisPK.ToString());
                for (int i = 0; i < rows.Count; i++)
                {
                    if (i == bindingSource2.Position)
                    {
                        continue;
                    }
                    if (thisPK == System.Convert.ToInt32(rows[i][0].ToString()))
                    {
                        MessageBox.Show("Ошибка! Повторяющийся первичный ключ");
                        rows[bindingSource2.Position][0] = tempLot1;
                    }
                }
            }
            catch (Exception exp)
            {

            }
            
        }

        private void textBoxLot1_Enter(object sender, EventArgs e)
        {
            try
            {
                tempLot1 = System.Convert.ToInt32(textBoxLot1.Text);
            }
            catch (Exception exp)
            {

            }
        }

        private void textBoxClient1_Enter(object sender, EventArgs e)
        {
            try
            {
                tempClient1 = System.Convert.ToInt32(textBoxClient1.Text);
            }
            catch (Exception exp)
            {

            }
        }

        private void textBoxClient1_Leave(object sender, EventArgs e)
        {
            try
            {
                DataRowCollection rows = dataSet1.Клиент.Rows;
                Int32 thisPK = System.Convert.ToInt32(textBoxClient1.Text);
                //MessageBox.Show(thisPK.ToString());
                for (int i = 0; i < rows.Count; i++)
                {
                    if (i == bindingSource3.Position)
                    {
                        continue;
                    }
                    if (thisPK == System.Convert.ToInt32(rows[i][0].ToString()))
                    {
                        MessageBox.Show("Ошибка! Повторяющийся первичный ключ");
                        rows[bindingSource3.Position][0] = tempClient1;
                    }
                }
            }
            catch (Exception exp)
            {

            }
            
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            try
            {
                temp1 = System.Convert.ToInt32(textBox1.Text);
            }
            catch (Exception exp)
            {

            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            try
            {
                DataRowCollection rows = dataSet1.Сделка.Rows;
                Int32 thisPK = System.Convert.ToInt32(textBox1.Text);
                if (thisPK == System.Convert.ToInt32(rows[bindingSource1.Position][1].ToString()))
                {
                    MessageBox.Show("Ошибка! Покупатель и продавец не должны совпадать");
                    rows[bindingSource1.Position][0] = temp1;
                    textBox1.Text = temp1.ToString();
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
                    rows[bindingSource1.Position][0] = temp1;
                    textBox1.Text = temp1.ToString();
                }
            }
            catch (Exception exp)
            {

            }
            
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            try
            {
                temp2 = System.Convert.ToInt32(textBox2.Text);
            }
            catch (Exception exp)
            {

            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            try
            {
                DataRowCollection rows = dataSet1.Сделка.Rows;
                Int32 thisPK = System.Convert.ToInt32(textBox2.Text);
                if (thisPK == System.Convert.ToInt32(rows[bindingSource1.Position][0].ToString()))
                {
                    MessageBox.Show("Ошибка! Покупатель и продавец не должны совпадать");
                    rows[bindingSource1.Position][1] = temp2;
                    textBox2.Text = temp2.ToString();
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
                    rows[bindingSource1.Position][1] = temp2;
                    textBox2.Text = temp2.ToString();
                }
            }
            catch (Exception exp)
            {

            }
            
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            try
            {
                temp3 = System.Convert.ToInt32(textBox3.Text);
            }
            catch (Exception exp)
            {

            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            try
            {
                DataRowCollection rows = dataSet1.Сделка.Rows;
                DataRowCollection rowsLot = dataSet1.Лот.Rows;
                Int32 thisPK = System.Convert.ToInt32(textBox3.Text);
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
                    rows[bindingSource1.Position][2] = temp3;
                    textBox3.Text = temp3.ToString();
                }
            }
            catch (Exception exp)
            {

            }
            
        }
    }
}
