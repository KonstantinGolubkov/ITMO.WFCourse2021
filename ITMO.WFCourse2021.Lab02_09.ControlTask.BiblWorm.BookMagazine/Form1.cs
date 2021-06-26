using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITMO.WFCourse2021.Lab02_09.ControlTask.BiblWorm.BookMagazine
{
    public partial class Form1 : Form
    {
        //создаем список для хранения единиц библиотеки
        List<MyClass.Item> its = new List<MyClass.Item>();

        public Form1()
        {
            InitializeComponent();
        }

        //Вкладка Книги - свойства ЭУ
        public string Author // автор
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }
        public string Title // Название
        {
            get { return textBox2.Text; }
            set { textBox2.Text = value; }
        }
        public string PublishHouse // Издательство
        {
            get { return textBox3.Text; }
            set { textBox3.Text = value; }
        }
        public int Page // Количество страниц
        {
            get { return (int)numericUpDown1.Value; }
            set { numericUpDown1.Value = value; }
        }
        public int Year // Год издания
        {
            get { return (int)numericUpDown2.Value; }
            set { numericUpDown2.Value = value; }
        }
        public int InvNumber // Инвентарный номер
        {
            get { return (int)numericUpDown3.Value; }
            set { numericUpDown3.Value = value; }
        }
        public int PeriodUse // Срок пользования
        {
            get { return (int)numericUpDown4.Value; }
            set { numericUpDown4.Value = value; }
        }
        public bool Existence // Наличие
        {
            get { return checkBox1.Checked; }
            set { checkBox1.Checked = value; }
        }
        public bool SortInvNumber // Сортировка по инвентарному номеру
        {
            get { return checkBox2.Checked; }
            set { checkBox2.Checked = value; }
        }
        public bool ReturnTime // Возвращение в срок
        {
            get { return checkBox3.Checked; }
            set { checkBox3.Checked = value; }
        }

        //Вкладка Книги - обработчик события клика по кнопке "Добавить"
        private void button1_Click(object sender, EventArgs e)
        {
            //Создаем объект класса Book, передав в конструктор свойства формы
            MyClass.Book b = new MyClass.Book(Author, Title, PublishHouse, Page, Year, InvNumber, Existence);
                
            //проверка возврата книги в срок
            //и расчет стоимости с учетом срока пользования книгой
            //и добавить книгу в список
            if (ReturnTime)
                b.ReturnSrok();
                b.PriceBook(PeriodUse);
                its.Add(b);

            //очистка полей ввода для новой информации
            Author = Title = PublishHouse = "";
            Page = InvNumber = PeriodUse = 1;
            Year = 1700;
            Existence = ReturnTime = false;
        }

        //Общий вывод для книг и журналов
        //Обработчик события клика по кнопке "Посмотреть
        private void button2_Click(object sender, EventArgs e)
        {
            //проверка состояния флажка сортировки
            if (SortInvNumber)
                its.Sort();

            //организация вывода информации
            //создаем строку класса StringBuilder
            //с помощью цикла строим строку с информацией о единице хранени
            StringBuilder sb = new StringBuilder();
            foreach (MyClass.Item item in its)
            {
                sb.Append("\n" + item.ToString());
            }
                
            //выводим строки в элемент RichTextBox1
            richTextBox1.Text = sb.ToString();
        }

        //Вкладка Журналы - свойства ЭУ
        public string TitleMagazine // Название
        {
            get { return textBox4.Text; }
            set { textBox4.Text = value; }
        }
        public int VolumeMagazine // Том
        {
            get { return (int)numericUpDown5.Value; }
            set { numericUpDown5.Value = value; }
        }
        public int NumberMagazine // Номер
        {
            get { return (int)numericUpDown6.Value; }
            set { numericUpDown6.Value = value; }
        }
        public int YearMagazine // Год выпуска
        {
            get { return (int)numericUpDown7.Value; }
            set { numericUpDown7.Value = value; }
        }
        public int InvNumberMagazine // Инвентарный номер
        {
            get { return (int)numericUpDown8.Value; }
            set { numericUpDown8.Value = value; }
        }

        //Вкладка Журналы - обработчик события клика по кнопке "Добавить"
        private void button3_Click(object sender, EventArgs e)
        {
            //создаем объект класса Magazine, передав в конструктор свойства формы
            //и добавляем Журнал в список
            MyClass.Magazine b = new MyClass.Magazine(VolumeMagazine, NumberMagazine, TitleMagazine, YearMagazine, InvNumberMagazine, Existence);
            its.Add(b);

            TitleMagazine = "";
            VolumeMagazine = NumberMagazine = InvNumberMagazine = 1;
            Year = 1900;
            Existence = ReturnTime = false;

        }
    }
}
