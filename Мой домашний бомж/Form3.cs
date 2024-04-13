using SQLite;
using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace Мой_домашний_бомж
{
    public partial class Form3 : Form
    {
        private bool statusButton = false;
        private DatabaseServiceUser _databaseService;


        public SQLiteConnection CreateDatabase(string databasePath)
        {
            SQLiteConnection connection = new SQLiteConnection(databasePath);
            connection.CreateTable<User>();
            return connection;
        }
        public Form3()
        {
            InitializeComponent();
            ChangePole();
            string databasePath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "user.db");
            //string databasePath = @"C:\Users\Èãîðü ×åðíåíêî\source\repos\MauiApp2\MauiApp2\user.db";
            SQLiteConnection connection = CreateDatabase(databasePath);
            _databaseService = new DatabaseServiceUser(databasePath);

        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!statusButton)
            {
                button5.Text = "Отмена";
                label1.Visible = true;
                textBox1.Visible = true;
                label2.Visible = true;
                textBox2.Visible = true;

                label3.Visible = true;
                textBox3.Visible = true;
                statusButton = true;
                button1.Enabled = false;
                button2.Visible = true;
                label5.Visible = true;
                textBox4.Visible = true;
            }
            else
            {

                button2.Visible = false;
                button1.Text = "Регистрация";
                button5.Enabled = true;
                ChangePole();
            }
        }
        private void ChangePole()
        {
            label1.Visible = false;
            textBox1.Visible = false;
            label2.Visible = false;
            textBox2.Visible = false;
            label4.Visible = false;
            button2.Visible = false;
            label3.Visible = false;
            textBox3.Visible = false;
            label5.Visible = false;
            textBox4.Visible = false;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (!statusButton)
            {
                button1.Text = "Отмена";
                label1.Visible = true;
                textBox1.Visible = true;
                label2.Visible = true;
                textBox2.Visible = true;
                label3.Visible = false;
                textBox3.Visible = false;
                statusButton = true;
                button5.Enabled = false;
                button2.Visible = true;
            }
            else
            {
                button2.Visible = false;
                button1.Enabled = true;
                button5.Text = "Авторихзация";
                statusButton = false;
                ChangePole();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Регистрация")
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                {
                    MessageBox.Show("Заполните поля Логин, пароль и повторение пароля");
                }
                else
                {
                    if (textBox2.Text != textBox3.Text)
                    {
                        MessageBox.Show("Пароли не совпадают");
                    }
                    else
                    {
                        string email = textBox1.Text;
                        string password1=textBox2.Text;
                        if (password1.Length < 8 || !HasLetterAndDigit(password1))
                        {
                            MessageBox.Show("Ошибка", "Пароль меньше 8 символов либо очень простой");
                            return;
                        }
                        email = email.ToLower();

                        if (!IsValidEmail(email))
                        {
                            MessageBox.Show("Ошибка", "Убедитесь, что почта написана правильно");
                            return;
                        }
                        var generator = new RandomWordGenerator();
                        string randomWord = generator.GenerateRandomWord();
                        var user = new User
                        {
                            Email = email,
                            Password = password1,
                            MailCode = randomWord,
                            UserName= "Пользовательский никнейм"
                        };

                        _databaseService.InsertUser(user);
                        MessageBox.Show("Успех");
                    }
                }
            }
            else if (button5.Text == "Авторизация")
            {
                if (textBox1.Text == "" || textBox2.Text == "" )
                {
                    MessageBox.Show("Заполните поля Логин и пароль");
                }
                else
                {
                    string email = textBox1.Text;
                    email = email.ToLower();
                    User user = _databaseService.GetUserByEmail(email);
                    if (user != null)
                    {
                        if(textBox2.Text==user.Password)
                        label6.Text = "Ник: " + user.UserName;
                        label6.Text = "Почта: " + user.UserName;
                        label6.Text = "Пароль: " + user.UserName;
                        label6.Text = "Максимальное количество прожитых дней: 0" ;
                        label6.Text = "Полученные достижения: 0 ";
                        MessageBox.Show("Успех");
                     
                    }
                }
            }
        }
        private bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
        }

        private bool HasLetterAndDigit(string input)
        {
            return Regex.IsMatch(input, @"[a-zA-Z]") && Regex.IsMatch(input, @"\d");
        }
       

    }
    public class RandomWordGenerator
    {
        private static readonly Random random = new Random();
        private const string Characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public string GenerateRandomWord()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < 6; i++) // Ãåíåðèðóåì äî 6 ñèìâîëîâ
            {
                int index = random.Next(Characters.Length);
                char randomChar = Characters[index];
                sb.Append(randomChar);
            }

            return sb.ToString();
        }
    }
}
