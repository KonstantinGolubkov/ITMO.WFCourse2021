using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITMO.WFCourse2021.Lab02_08.RegForm.ValidatingInputValues
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                        //при установке флажка в ЭУ checkBox1 “Расширенные возможности” 
                        //на форме появляется надпись и поле ввода для дополнительных данных
                Label lbl = new Label();
                lbl.Location = new System.Drawing.Point(16, 96);
                lbl.Size = new System.Drawing.Size(32, 23);
                lbl.Name = "labelll";
                lbl.TabIndex = 2;
                lbl.Text = "PIN2";
                groupBox1.Controls.Add(lbl);
                TextBox txt = new TextBox();
                txt.Location = new System.Drawing.Point(96, 96);
                txt.Size = new System.Drawing.Size(184, 20);
                txt.Name = "textboxx";
                txt.TabIndex = 1;
                txt.Text = "";
                groupBox1.Controls.Add(txt);

                //для появляющегося дополнительного поля "PIN2" недопустимыми значениями будут буквы,
                //txt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
                //txt.Validating += new System.ComponentModel.CancelEventHandler (this.textBox2_Validating);

            }
            else
            {
                        //при снятии флажка в ЭУ checkBox1 “Расширенные возможности” 
                        //из формы удаляется надпись и поле ввода для дополнительных данных
                int lcv;
                lcv = groupBox1.Controls.Count;// определяется количество элементов
                while (lcv > 4)
                {
                    groupBox1.Controls.RemoveAt(lcv - 1);
                    lcv -= 1;
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
                    //для элемента TextBox1 недопустимыми значениями будут цифры 
            if (char.IsDigit(e.KeyChar))
            {
                    //При ошибке ввода появляется мигающая иконка уведомления, 
                    //при наведении на нее всплывает поясняющее сообщение об ошибке
                errorProvider1.SetError(textBox1, "Must be letter");

                e.Handled = true;
                MessageBox.Show("Поле Name не может содержать цифры");
            }
        }

        //private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    //для элемента TextBox2 недопустимыми значениями будут буквы,
        //    if (!char.IsDigit(e.KeyChar))
        //    {
        //        e.Handled = true;
        //        MessageBox.Show("Поле PIN не может содержать буквы");
        //    }
        //}

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (textBox2.Text == "")
            {
                e.Cancel = false;
            }
            else
            {
                try
                {
                    double.Parse(textBox2.Text);
                    e.Cancel = false;
                }
                catch
                {
                    e.Cancel = true;
                    MessageBox.Show("Поле PIN не может содержать буквы");
                }
            }
        }
    }
}
