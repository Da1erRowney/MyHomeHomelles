using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Мой_домашний_бомж
{
    public partial class Form1 : Form
    {
        public string StatusChoise = "NoN";
        private TimeSpan gameTime;
        private int currentDay;
        public bool StatusGame =true;
        private DatabaseServiceUser _databaseService;
        public SQLiteConnection CreateDatabase(string databasePath)
        {
            SQLiteConnection connection = new SQLiteConnection(databasePath);
            connection.CreateTable<User>();
            return connection;
        }
        public Form1()
        {
            InitializeComponent();

            timer1.Start();

            timer2.Start();
            gameTime = TimeSpan.Zero;
            currentDay = 1;
            button1.Text = "";
            button2.Text = "";
            button3.Text = "";
            button4.Text = "";
            button5.Text = "";
            button6.Text = "";
            button7.Text = "";
            button8.Text = "";

            label9. Text = "";
            label10.Text = "";
            label11.Text = "";
            label12.Text = "";
            label13.Text = "";
            label14.Text = "";
            label15.Text = "";
            label16.Text = "";
            this.BackgroundImage = Properties.Resources.первыйлежит ;
            string databasePath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "user.db");
            //string databasePath = @"C:\Users\Èãîðü ×åðíåíêî\source\repos\MauiApp2\MauiApp2\user.db";
            SQLiteConnection connection = CreateDatabase(databasePath);
            _databaseService = new DatabaseServiceUser(databasePath);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
                if (progressBarHunger.Value != 0)
                {
                    progressBarHunger.Value -= 10;
                }
                if (progressBarMorale.Value >= 15)
                {

                    progressBarMorale.Value -= 15;
                }
                else
                progressBarMorale.Value =0 ;
            if (progressBarHunger.Value == 0)
                {

                    if (progressBarHp.Value - 5 >= 0)
                        progressBarHp.Value -= 15;
                    else
                        progressBarHp.Value = 0;
                }
                if (progressBarMorale.Value == 0)
                {

                    if (progressBarHp.Value - 5 >= 0 && progressBarHp.Value>=15)
                        progressBarHp.Value -= 15;
                    else
                        progressBarHp.Value = 0;
                }
                if (progressBarDrug.Value >= 100)
                {
                    if (progressBarHp.Value - 5 >= 0)
                        progressBarHp.Value -= 25;
                    else
                        progressBarHp.Value = 0;
                }
                if (progressBarDiseases.Value >= 50)
                {
                    if (progressBarHp.Value - 15 >= 0)
                        progressBarHp.Value -= 15;
                    else
                        progressBarHp.Value = 0;
                }
                if (progressBarAlcoholism.Value >= 100)
                {
                    if (progressBarHp.Value - 7 >= 0)
                        progressBarHp.Value -= 30;
                    else
                        progressBarHp.Value = 0;
                }
            
          
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (StatusChoise == "NoN")
            {
                label9. Text = "Вернуться назад";
                label10.Text = "Пельмени";
                label11.Text = "Шаурма";
                label12.Text = "А4 бокс";
                label13.Text = "Анус бургер";
                label14.Text = "Помпушки";
                label15.Text = "Хинкали";
                label16.Text = "Фикалии";

                button2.BackgroundImage = Properties.Resources.shaurma;
                button3.BackgroundImage = Properties.Resources.pelmeni;
                button4.BackgroundImage = Properties.Resources.a4;
                button5.BackgroundImage = Properties.Resources.angus;
                button6.BackgroundImage = Properties.Resources.ponchiki;
                button7.BackgroundImage = Properties.Resources.hinkali;
                button8.BackgroundImage = Properties.Resources.ficalii;

                StatusChoise = "ChoiseFood";
                return;
            }
             else
            {
                label9. Text = "Еда";
                label10.Text = "Алкоголь";
                label11.Text = "Напитки";
                label12.Text = "Курилки";
                label13.Text = "Лекарства";
                label14.Text = "Живность";
                label15.Text = "Оружие";
                label16.Text = "Надежда";
                Random random = new Random();
                int randomNumber = random.Next(1, 3);
                if (randomNumber == 1)
                    this.BackgroundImage = Properties.Resources.первыйлежит;
                else
                    this.BackgroundImage = Properties.Resources.первыйпоза;
                button1.BackgroundImage = Properties.Resources.food;
                button2.BackgroundImage = Properties.Resources.alcohol;
                button3.BackgroundImage = Properties.Resources.drink;
                button4.BackgroundImage = Properties.Resources.vape;
                button5.BackgroundImage = Properties.Resources.medicine;
                button6.BackgroundImage = Properties.Resources.animal;
                button7.BackgroundImage = Properties.Resources.weapon;
                button8.BackgroundImage = Properties.Resources.hope;
                StatusChoise = "NoN";
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (StatusChoise == "NoN")
            {
                label9. Text = "Вернуться назад";
                label10.Text = "Свояк синий";
                label11.Text = "Спирт";
                label12.Text = "Самогон";
                label13.Text = "Балтика 7";
                label14.Text = "Арарат";
                label15.Text = "Омывайка";
                label16.Text = "Виски";
                StatusChoise = "ChoiseAlcohol";
                button1.BackgroundImage = Properties.Resources.alcohol;
                button2.BackgroundImage = Properties.Resources.svayk;
                button3.BackgroundImage = Properties.Resources.spirt;
                button4.BackgroundImage = Properties.Resources.samagon;
                button5.BackgroundImage = Properties.Resources.baltika;
                button6.BackgroundImage = Properties.Resources.ararat;
                button7.BackgroundImage = Properties.Resources.omavaika;
                button8.BackgroundImage = Properties.Resources.viski;
                return;
            }
            if (StatusChoise == "ChoiseFood")
            {
                if (progressBarHp.Value + 5 >= progressBarHp.Maximum) { progressBarHp.Value =100; }

                else
                    progressBarHp.Value += 5;

                if (progressBarHunger.Value + 30 >= progressBarHunger.Maximum) { progressBarHunger.Value =100; }

                else
                    progressBarHunger.Value += 30;
            }
            if (StatusChoise == "ChoiseAlcohol")
            {
                if (progressBarDrug.Value - 10 <= progressBarDrug.Minimum) { progressBarDrug.Value = 0; }

                else
                    progressBarDrug.Value -= 10;

                if (progressBarHp.Value - 10 <= progressBarHp.Minimum) { progressBarHp.Value = 0; }

                else
                    progressBarHp.Value -= 10;
                if (progressBarHunger.Value + 20 >= progressBarHunger.Maximum) { progressBarHunger.Value = 100; }

                else
                    progressBarHunger.Value += 20;
                if (progressBarAlcoholism.Value + 30 >= progressBarAlcoholism.Maximum) { progressBarAlcoholism.Value = 100; }
                
                else
                    progressBarAlcoholism.Value += 30;
            }
            if (StatusChoise == "ChoiseDrink")
            {

                progressBarHp.Value += 0;
                if (progressBarHunger.Value + 10 >= progressBarHunger.Maximum) { progressBarHunger.Value = 100; }
                else
                progressBarHunger.Value += 10;
                if (progressBarDiseases.Value + 15 >= progressBarDiseases.Maximum) { progressBarDiseases.Value = 100; }
                else
                    progressBarDiseases.Value += 15;

            }
            if (StatusChoise == "ChoiseVape")
            {
                if (progressBarDrug.Value + 2 >= progressBarDrug.Maximum) { progressBarDrug.Value = 100; }
                else
                    progressBarDrug.Value += 2;
                if (progressBarHp.Value +5 >= progressBarHp.Maximum) { progressBarHp.Value = 100; }

                else
                    progressBarHp.Value += 5;
               
            }
            if (StatusChoise == "ChoiseMedicines")
            {
                if (progressBarAlcoholism.Value - 10 <= progressBarAlcoholism.Minimum) { progressBarAlcoholism.Value = 0; }

                else
                    progressBarAlcoholism.Value -= 10;

                if (progressBarHp.Value + 5 >= progressBarHp.Maximum) { progressBarHp.Value = 100; }

                else
                    progressBarHp.Value += 5;

                progressBarDrug.Value += 0;
                if (progressBarDiseases.Value -5 <= progressBarDiseases.Minimum) { progressBarDiseases.Value = 0; }
                else
                    progressBarDiseases.Value -= 5;
            }
            if (StatusChoise == "ChoiseAnimal")
            {
                if (progressBarHunger.Value + 20 >= progressBarHunger.Maximum) { progressBarHunger.Value = 100; }
                else
                    progressBarHunger.Value += 20;
                if (progressBarDiseases.Value +15 >= progressBarDiseases.Maximum) { progressBarDiseases.Value = 100; }
                else
                    progressBarDiseases.Value += 15;
            }
            if (StatusChoise == "ChoiseWeapon")
            {
                if (progressBarHp.Value -15 <= progressBarHp.Minimum) { progressBarHp.Value = 0; }

                else
                    progressBarHp.Value -= 15;
            }
            if (StatusChoise == "ChoiseHope")
            {
                if (progressBarMorale.Value + 10 >= progressBarMorale.Maximum) { progressBarMorale.Value = 0; }

                else
                    progressBarMorale.Value += 10;
            }

        }

        //public void ReturnStatusAfterRandomize()
        //{
        //    label9.Text = "Еда";
        //    label10.Text = "Алкоголь";
        //    label11.Text = "Напитки";
        //    label12.Text = "Курилки";
        //    label13.Text = "Лекарства";
        //    label14.Text = "Живность";
        //    label15.Text = "Оружие";
        //    label16.Text = "Надежда";
        //    button1.BackgroundImage = Properties.Resources.food;
        //    button2.BackgroundImage = Properties.Resources.alcohol;
        //    button3.BackgroundImage = Properties.Resources.drink;
        //    button4.BackgroundImage = Properties.Resources.vape;
        //    button5.BackgroundImage = Properties.Resources.medicine;
        //    button6.BackgroundImage = Properties.Resources.animal;
        //    button7.BackgroundImage = Properties.Resources.weapon;
        //    button8.BackgroundImage = Properties.Resources.hope;
        //    StatusChoise = "NoN";
        //}
        private void button3_Click(object sender, EventArgs e)
        {
            if (StatusChoise == "NoN")
            {
                label9. Text = "Вернуться назад";
                label10.Text = "Лужа";
                label11.Text = "Святой источник";
                label12.Text = "Пепси";
                label13.Text = "Кока Кола";
                label14.Text = "Ред бул";
                label15.Text = "Боржоми";
                label16.Text = "Моя Семья";
                StatusChoise = "ChoiseDrink";
                Random random = new Random();
                int randomNumber = random.Next(1, 3);
                if(randomNumber==1)
                this.BackgroundImage = Properties.Resources.первыйпьетвтор;
                else
                this.BackgroundImage = Properties.Resources.первыйпьетпер;
                button1.BackgroundImage = Properties.Resources.drink;
                button2.BackgroundImage = Properties.Resources.lyga;
                button3.BackgroundImage = Properties.Resources.svytou;
                button4.BackgroundImage = Properties.Resources.pepsi;
                button5.BackgroundImage = Properties.Resources.cola;
                button6.BackgroundImage = Properties.Resources.redbull;
                button7.BackgroundImage = Properties.Resources.borjomi;
                button8.BackgroundImage = Properties.Resources.family;
                return;
            }
            if (StatusChoise == "ChoiseFood")
            {
                if (progressBarHp.Value + 7 >= progressBarHp.Maximum) { progressBarHp.Value = 100; }

                else
                    progressBarHp.Value += 7;
                if (progressBarHunger.Value + 35 >= progressBarHunger.Maximum) { progressBarHunger.Value = 100; }

                else
                    progressBarHunger.Value += 35;
            }
            if (StatusChoise == "ChoiseAlcohol")
            {
                if (progressBarDrug.Value - 10 <= progressBarDrug.Minimum) { progressBarDrug.Value = 0; }

                else
                    progressBarDrug.Value -= 10;
                if (progressBarHp.Value - 15 <= progressBarHp.Minimum) { progressBarHp.Value = 0; }

                else
                    progressBarHp.Value -= 15;

                if (progressBarHunger.Value + 20 >= progressBarHunger.Maximum) { progressBarHunger.Value = 100; }

                else
                    progressBarHunger.Value += 20;
                if (progressBarAlcoholism.Value + 30 >= progressBarAlcoholism.Maximum) { progressBarAlcoholism.Value = 100; }

                else
                    progressBarAlcoholism.Value += 30;
            }
            if (StatusChoise == "ChoiseDrink")
            {
                if (progressBarHp.Value +1 >= progressBarHp.Maximum) { progressBarHp.Value = 100; }

                else
                    progressBarHp.Value += 1;
                
                    if (progressBarHunger.Value + 10 >= progressBarHunger.Maximum) { progressBarHunger.Value = 100; }

                    else
                        progressBarHunger.Value += 10;

            }
            if (StatusChoise == "ChoiseVape")
            {
                if (progressBarDrug.Value + 2 >= progressBarDrug.Maximum) { progressBarDrug.Value = 100; }

                else
                    progressBarDrug.Value += 2;
                if (progressBarHp.Value + 5 >= progressBarHp.Maximum) { progressBarHp.Value = 100; }

                else
                    progressBarHp.Value += 5;
               
            }
            if (StatusChoise == "ChoiseMedicines")
            {
                if (progressBarAlcoholism.Value - 10 <= progressBarAlcoholism.Minimum) { progressBarAlcoholism.Value = 0; }

                else
                    progressBarAlcoholism.Value -= 10;
                if (progressBarHp.Value + 7 >= progressBarHp.Maximum) { progressBarHp.Value = 100; }

                else
                    progressBarHp.Value += 7;
                if (progressBarDiseases.Value - 7 <= progressBarDiseases.Minimum) { progressBarDiseases.Value = 0; }

                else
                    progressBarDiseases.Value -= 7;
            }
            if (StatusChoise == "ChoiseAnimal")
            {
                if (progressBarHunger.Value + 25 >= progressBarHunger.Maximum) { progressBarHunger.Value = 100; }

                else
                    progressBarHunger.Value += 25;
                if (progressBarDiseases.Value + 20 >= progressBarDiseases.Maximum) { progressBarDiseases.Value = 100; }

                else
                    progressBarDiseases.Value += 20;
            }
            if (StatusChoise == "ChoiseWeapon")
            {
                if (progressBarHp.Value - 20 <= progressBarHp.Minimum) { progressBarHp.Value = 0; }

                else
                    progressBarHp.Value -= 20;
            }
            if (StatusChoise == "ChoiseHope")
            {
                if (progressBarMorale.Value + 15 >= progressBarMorale.Maximum) { progressBarMorale.Value = 100; }

                else
                    progressBarMorale.Value += 15;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (StatusChoise == "NoN")
            {
                label9. Text = "Вернуться назад";
                label10.Text = "Астра";
                label11.Text = "Минск красный";
                label12.Text = "Собрание голд";
                label13.Text = "Чапмэн";
                label14.Text = "HotSpot";
                label15.Text = "Freeze Monkey";
                label16.Text = "Анархия-Подонки";
                this.BackgroundImage = Properties.Resources.первыйсидит;
                button1.BackgroundImage = Properties.Resources.vape;
                button2.BackgroundImage = Properties.Resources.astra;
                button3.BackgroundImage = Properties.Resources.minsk;
                button4.BackgroundImage = Properties.Resources.sobranie;
                button5.BackgroundImage = Properties.Resources.chapman;
                button6.BackgroundImage = Properties.Resources.hotspot;
                button7.BackgroundImage = Properties.Resources.freeze;
                button8.BackgroundImage = Properties.Resources.anarhia;
                StatusChoise = "ChoiseVape";
                return;
            }
            if (StatusChoise == "ChoiseFood")
            {
                if (progressBarHp.Value + 10 >= progressBarHp.Maximum) { progressBarHp.Value = 100; }

                else
                    progressBarHp.Value += 10;
                if (progressBarHunger.Value + 35 >= progressBarHunger.Maximum) { progressBarHunger.Value = 100; }

                else
                    progressBarHunger.Value += 35;
            }
            if (StatusChoise == "ChoiseAlcohol")
            {
                if (progressBarDrug.Value - 10 <= progressBarDrug.Minimum) { progressBarDrug.Value = 0; }

                else
                    progressBarDrug.Value -= 10;

                if (progressBarHp.Value - 15 <= progressBarHp.Minimum) { progressBarHp.Value = 0; }

                else
                    progressBarHp.Value -= 15;
                if (progressBarHunger.Value + 20 >= progressBarHunger.Maximum) { progressBarHunger.Value = 100; }

                else
                    progressBarHunger.Value += 20;
                if (progressBarAlcoholism.Value + 25 >= progressBarAlcoholism.Maximum) { progressBarAlcoholism.Value = 100; }

                else
                    progressBarAlcoholism.Value += 25;
            }
            if (StatusChoise == "ChoiseDrink")
            {
                if (progressBarHunger.Value + 15 >= progressBarHunger.Maximum) { progressBarHunger.Value = 100; }

                else
                    progressBarHunger.Value += 15;


            }
            if (StatusChoise == "ChoiseVape")
            {
                if (progressBarDrug.Value + 5 >= progressBarDrug.Maximum) { progressBarDrug.Value = 100; }

                else
                    progressBarDrug.Value += 5;
                if (progressBarHp.Value + 10 >= progressBarHp.Maximum) { progressBarHp.Value = 100; }

                else
                    progressBarHp.Value += 10;
                
            }
            if (StatusChoise == "ChoiseMedicines")
            {
                if (progressBarAlcoholism.Value - 10 <= progressBarAlcoholism.Minimum) { progressBarAlcoholism.Value = 0; }

                else
                    progressBarAlcoholism.Value -= 10;
                if (progressBarHp.Value + 10 >= progressBarHp.Maximum) { progressBarHp.Value = 100; }

                else
                    progressBarHp.Value += 10;
                if (progressBarDiseases.Value - 10 <= progressBarDiseases.Minimum) { progressBarDiseases.Value = 0; }

                else
                    progressBarDiseases.Value -= 10;
            }
            if (StatusChoise == "ChoiseAnimal")
            {
                if (progressBarHunger.Value + 20 >= progressBarHunger.Maximum) { progressBarHunger.Value = 100; }

                else
                    progressBarHunger.Value += 20;
                if (progressBarDiseases.Value + 20 >= progressBarDiseases.Maximum) { progressBarDiseases.Value = 100; }

                else
                    progressBarDiseases.Value += 20;
            }
            if (StatusChoise == "ChoiseWeapon")
            {
                if (progressBarHp.Value - 25 <= progressBarHp.Minimum) { progressBarHp.Value = 0; }

                else
                    progressBarHp.Value -= 25;
            }
            if (StatusChoise == "ChoiseHope")
            {
                if (progressBarMorale.Value + 20 >= progressBarMorale.Maximum) { progressBarMorale.Value = 100; }

                else
                    progressBarMorale.Value += 20;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (StatusChoise == "NoN")
            {
                label9. Text = "Вернуться назад";
                label10.Text = "Подорожник";
                label11.Text = "Активированный Уголь";
                label12.Text = "Ношпа";
                label13.Text = "Морфий";
                label14.Text = "Xanax";
                label15.Text = "Лирика";
                label16.Text = "Шишки";
              
                    this.BackgroundImage = Properties.Resources.первыйколится;
                button1.BackgroundImage = Properties.Resources.medicine;
                button2.BackgroundImage = Properties.Resources.podorojnik;
                button3.BackgroundImage = Properties.Resources.ygol;
                button4.BackgroundImage = Properties.Resources.nospa;
                button5.BackgroundImage = Properties.Resources.morphine;
                button6.BackgroundImage = Properties.Resources.xanax;
                button7.BackgroundImage = Properties.Resources.lirica;
                button8.BackgroundImage = Properties.Resources.shishki;
                StatusChoise = "ChoiseMedicines";
                return;
            }
            if (StatusChoise == "ChoiseFood")
            {
                if (progressBarHp.Value + 20 >= progressBarHp.Maximum) { progressBarHp.Value = 100; }

                else
                    progressBarHp.Value += 20;
                if (progressBarHunger.Value + 35 >= progressBarHunger.Maximum) { progressBarHunger.Value = 100; }

                else
                    progressBarHunger.Value += 35;
            }
            if (StatusChoise == "ChoiseAlcohol")
            {
                if (progressBarDrug.Value - 10 <= progressBarDrug.Minimum) { progressBarDrug.Value = 0; }

                else
                    progressBarDrug.Value -= 10;
                if (progressBarHp.Value - 10 <= progressBarHp.Minimum) { progressBarHp.Value = 0; }


                progressBarHp.Value -= 10;
                if (progressBarHunger.Value + 10 >= progressBarHunger.Maximum) { progressBarHunger.Value = 100; }

                else
                    progressBarHunger.Value += 10;
                if (progressBarAlcoholism.Value + 20 >= progressBarAlcoholism.Maximum) { progressBarAlcoholism.Value = 100; }

                else
                    progressBarAlcoholism.Value += 20;
            }
            if (StatusChoise == "ChoiseDrink")
            {
                if (progressBarHp.Value + 5 >= progressBarHp.Maximum) { progressBarHp.Value = 100; }

                else
                    progressBarHp.Value += 5;
                if (progressBarHunger.Value + 15 >= progressBarHunger.Maximum) { progressBarHunger.Value = 100; }

                else
                    progressBarHunger.Value += 15;


            }
            if (StatusChoise == "ChoiseVape")
            {
                if (progressBarDrug.Value + 5 >= progressBarDrug.Maximum) { progressBarDrug.Value = 100; }

                else
                    progressBarDrug.Value += 5;
                if (progressBarHp.Value + 10 >= progressBarHp.Maximum) { progressBarHp.Value = 100; }

                else
                    progressBarHp.Value += 10;
              
            }
            if (StatusChoise == "ChoiseMedicines")
            {
                if (progressBarAlcoholism.Value - 10 <= progressBarAlcoholism.Minimum) { progressBarAlcoholism.Value = 0; }

                else
                    progressBarAlcoholism.Value -= 10;

                if (progressBarHp.Value + 10 >= progressBarHp.Maximum) { progressBarHp.Value = 100; }

                else
                    progressBarHp.Value += 10;
                if (progressBarDrug.Value + 10 >= progressBarDrug.Maximum) { progressBarDrug.Value = 100; }

                else
                    progressBarDrug.Value += 10;

            }
            if (StatusChoise == "ChoiseAnimal")
            {
                if (progressBarHunger.Value + 25 >= progressBarHunger.Maximum) { progressBarHunger.Value = 100; }

                else
                    progressBarHunger.Value += 25;
                if (progressBarDiseases.Value + 10 >= progressBarDiseases.Maximum) { progressBarDiseases.Value = 100; }

                else
                    progressBarDiseases.Value += 10;
                MessageBox.Show("Респект за бабку");
            }
            if (StatusChoise == "ChoiseWeapon")
            {
                if (progressBarHp.Value - 5 <= progressBarHp.Minimum) { progressBarHp.Value = 0; }

                else
                    progressBarHp.Value -= 5;
            }
            if (StatusChoise == "ChoiseHope")
            {
                if (progressBarMorale.Value + 25 >= progressBarMorale.Maximum) { progressBarMorale.Value = 100; }

                else
                    progressBarMorale.Value += 25;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (StatusChoise == "NoN")
            {
                label9. Text = "Вернуться назад";
                label10.Text = "Голубь";
                label11.Text = "Собака";
                label12.Text = "Кошка";
                label13.Text = "Бабка";
                label14.Text = "Крыса";
                label15.Text = "Таракан";
                label16.Text = "Грифон";
                StatusChoise = "ChoiseAnimal";
                button1.BackgroundImage = Properties.Resources.animal;
                button2.BackgroundImage = Properties.Resources.golub;
                button3.BackgroundImage = Properties.Resources.sobaka;
                button4.BackgroundImage = Properties.Resources.koshka;
                button5.BackgroundImage = Properties.Resources.babka;
                button6.BackgroundImage = Properties.Resources.krisa;
                button7.BackgroundImage = Properties.Resources.tarakan;
                button8.BackgroundImage = Properties.Resources.grifon;
                return;
            }
            if (StatusChoise == "ChoiseFood")
            {
                if (progressBarHp.Value + 25 >= progressBarHp.Maximum) { progressBarHp.Value = 100; }

                else
                    progressBarHp.Value += 25;
                if (progressBarHunger.Value + 20 >= progressBarHunger.Maximum) { progressBarHunger.Value = 100; }

                else
                    progressBarHunger.Value += 20;
            }
            if (StatusChoise == "ChoiseAlcohol")
            {
                if (progressBarDrug.Value - 10 <= progressBarDrug.Minimum) { progressBarDrug.Value = 0; }

                else
                    progressBarDrug.Value -= 10;
                if (progressBarHp.Value - 5 <= progressBarHp.Minimum) { progressBarHp.Value = 0; }

                else
                    progressBarHp.Value -= 5;
                if (progressBarHunger.Value + 15 >= progressBarHunger.Maximum) { progressBarHunger.Value = 100; }

                else
                    progressBarHunger.Value += 15;
                if (progressBarAlcoholism.Value + 25 >= progressBarAlcoholism.Maximum) { progressBarAlcoholism.Value = 100; }

                else
                    progressBarAlcoholism.Value += 25;
            }
            if (StatusChoise == "ChoiseDrink")
            {
                if (progressBarHp.Value + 20 >= progressBarHp.Maximum) { progressBarHp.Value = 100; }

                else
                    progressBarHp.Value += 20;
                if (progressBarHunger.Value + 10 >= progressBarHunger.Maximum) { progressBarHunger.Value = 100; }

                else
                    progressBarHunger.Value += 10;


            }
            if (StatusChoise == "ChoiseVape")
            {
                if (progressBarDrug.Value + 10 >= progressBarDrug.Maximum) { progressBarDrug.Value = 100; }

                else
                    progressBarDrug.Value += 10;
                if (progressBarHp.Value + 15 >= progressBarHp.Maximum) { progressBarHp.Value = 100; }

                else
                    progressBarHp.Value += 15;
              
            }
            if (StatusChoise == "ChoiseMedicines")
            {
                if (progressBarAlcoholism.Value - 10 <= progressBarAlcoholism.Minimum) { progressBarAlcoholism.Value = 0; }

                else
                    progressBarAlcoholism.Value -= 10;
                if (progressBarHp.Value + 20 >= progressBarHp.Maximum) { progressBarHp.Value = 100; }

                else
                    progressBarHp.Value += 20;
                if (progressBarDrug.Value + 20 >= progressBarDrug.Maximum) { progressBarDrug.Value = 100; }

                else
                    progressBarDrug.Value += 20;
                if (progressBarDiseases.Value - 10 <= progressBarDiseases.Minimum) { progressBarDiseases.Value = 0; }

                else
                    progressBarDiseases.Value -= 10;
            }
            if (StatusChoise == "ChoiseAnimal")
            {
                if (progressBarHunger.Value + 10 >= progressBarHunger.Maximum) { progressBarHunger.Value = 100; }

                else
                    progressBarHunger.Value += 10;
                if (progressBarDiseases.Value + 15 >= progressBarDiseases.Maximum) { progressBarDiseases.Value = 100; }

                else
                    progressBarDiseases.Value += 15;
            }
            if (StatusChoise == "ChoiseWeapon")
            {
                if (progressBarHp.Value - 15 <= progressBarHp.Minimum) { progressBarHp.Value = 0; }

                else
                    progressBarHp.Value -= 15;
            }
            if (StatusChoise == "ChoiseHope")
            {
                if (progressBarMorale.Value - 50 <= progressBarMorale.Minimum) { progressBarMorale.Value = 0; }

                else
                    progressBarMorale.Value -= 50;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

            if (StatusChoise == "NoN")
            {
                label9. Text = "Вернуться назад";
                label10.Text = "Розочка";
                label11.Text = "Кастет";
                label12.Text = "Бита";
                label13.Text = "Дротик";
                label14.Text = "Гвоздомет";
                label15.Text = "Макаров";
                label16.Text = "Плазменная пушка";
                button1.BackgroundImage = Properties.Resources.weapon;
                button2.BackgroundImage = Properties.Resources.rozochka;
                button3.BackgroundImage = Properties.Resources.kastet;
                button4.BackgroundImage = Properties.Resources.bita;
                button5.BackgroundImage = Properties.Resources.drotik;
                button6.BackgroundImage = Properties.Resources.gvozdomet;
                button7.BackgroundImage = Properties.Resources.macarov;
                button8.BackgroundImage = Properties.Resources.plazmenay;
                StatusChoise = "ChoiseWeapon";
                return;
            }
            if (StatusChoise == "ChoiseFood")
            {
                if (progressBarHp.Value + 25 >= progressBarHp.Maximum) { progressBarHp.Value = 100; }

                else
                    progressBarHp.Value += 25;
                if (progressBarHunger.Value + 25 >= progressBarHunger.Maximum) { progressBarHunger.Value = 100; }

                else
                    progressBarHunger.Value += 25;
            }
            if (StatusChoise == "ChoiseAlcohol")
            {
                if (progressBarDrug.Value - 10 <= progressBarDrug.Minimum) { progressBarDrug.Value = 0; }

                else
                    progressBarDrug.Value -= 10;
                if (progressBarHp.Value - 20 <= progressBarHp.Minimum) { progressBarHp.Value = 0; }

                else
                    progressBarHp.Value -= 20;
                if (progressBarHunger.Value + 15 >= progressBarHunger.Maximum) { progressBarHunger.Value = 100; }

                else
                    progressBarHunger.Value += 15;

                if (progressBarAlcoholism.Value + 40 >= progressBarAlcoholism.Maximum) { progressBarAlcoholism.Value = 100; }

                else
                    progressBarAlcoholism.Value += 40;
                if (progressBarDiseases.Value + 15 >= progressBarDiseases.Maximum) { progressBarDiseases.Value = 100; }

                else
                    progressBarDiseases.Value += 15;
            }
            if (StatusChoise == "ChoiseDrink")
            {
                if (progressBarHp.Value + 20 >= progressBarHp.Maximum) { progressBarHp.Value = 100; }

                else
                    progressBarHp.Value += 20;
                if (progressBarHunger.Value + 10 >= progressBarHunger.Maximum) { progressBarHunger.Value = 100; }

                else
                    progressBarHunger.Value += 10;


            }
            if (StatusChoise == "ChoiseVape")
            {
                if (progressBarHp.Value + 20 >= progressBarHp.Maximum) { progressBarHp.Value = 100; }

                else
                    progressBarHp.Value += 20;
            
            }
            if (StatusChoise == "ChoiseMedicines")
            {
                if (progressBarAlcoholism.Value - 10 <= progressBarAlcoholism.Minimum) { progressBarAlcoholism.Value = 0; }

                else
                    progressBarAlcoholism.Value -= 10;
                if (progressBarHp.Value + 30 >= progressBarHp.Maximum) { progressBarHp.Value = 100; }

                else
                    progressBarHp.Value += 30;
                if (progressBarDrug.Value + 30 >= progressBarDrug.Maximum) { progressBarDrug.Value = 100; }

                else
                    progressBarDrug.Value += 30;
                if (progressBarDiseases.Value - 15 <= progressBarDiseases.Minimum) { progressBarDiseases.Value = 0; }

                else
                    progressBarDiseases.Value -= 15;
            }
            if (StatusChoise == "ChoiseAnimal")
            {
                if (progressBarHunger.Value + 10 >= progressBarHunger.Maximum) { progressBarHunger.Value = 100; }

                else
                    progressBarHunger.Value += 10;
                if (progressBarDiseases.Value + 30 >= progressBarDiseases.Maximum) { progressBarDiseases.Value = 100; }

                else
                    progressBarDiseases.Value += 30;
            }
            if (StatusChoise == "ChoiseWeapon")
            {
                if (progressBarHp.Value - 50 <= progressBarHp.Minimum) { progressBarHp.Value = 0; }

                else
                    progressBarHp.Value -= 50;
            }
            if (StatusChoise == "ChoiseHope")
            {
                if (progressBarMorale.Value - 25 <= progressBarMorale.Minimum) { progressBarMorale.Value = 0; }

                else
                    progressBarMorale.Value -= 25;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (StatusChoise == "NoN")
            {
                label9. Text = "Вернуться назад";
                label10.Text = "Помолиться";
                label11.Text = "Прочитать Каран";
                label12.Text = "Сходить в Мечеть";
                label13.Text = "Стать Мусульманом";
                label14.Text = "Вступить в секту";
                label15.Text = "Крутка в Геншине";
                label16.Text = "Жертва приношение";
                Random random = new Random();
                int randomNumber = random.Next(1, 3);
                if (randomNumber == 1)
                    this.BackgroundImage = Properties.Resources.первыймолитсяпер;
                else
                    this.BackgroundImage = Properties.Resources.первыймолитсявтор;
                button1.BackgroundImage = Properties.Resources.hope;
                button2.BackgroundImage = Properties.Resources.pomolitca;
                button3.BackgroundImage = Properties.Resources.caran;
                button4.BackgroundImage = Properties.Resources.mechet;
                button5.BackgroundImage = Properties.Resources.musulman;
                button6.BackgroundImage = Properties.Resources.secta;
                button7.BackgroundImage = Properties.Resources.krutka;
                button8.BackgroundImage = Properties.Resources.jertva;
                StatusChoise = "ChoiseHope";
                return;
            }
            if (StatusChoise == "ChoiseFood")
            {
                if (progressBarHp.Value + 5 >= progressBarHp.Maximum) { progressBarHp.Value = 100; }

                else
                    progressBarHp.Value += 5;
                if (progressBarHunger.Value + 5 >= progressBarHunger.Maximum) { progressBarHunger.Value = 100; }

                else
                    progressBarHunger.Value += 5;

                if (progressBarDiseases.Value +15 >= progressBarDiseases.Maximum) { progressBarDiseases.Value = 100; }

                else
                    progressBarDiseases.Value += 15;
            }
            if (StatusChoise == "ChoiseAlcohol")
            {
                if (progressBarDrug.Value - 10 <= progressBarDrug.Minimum) { progressBarDrug.Value = 0; }

                else
                    progressBarDrug.Value -= 10;

                if (progressBarHp.Value - 15 <= progressBarHp.Minimum) { progressBarHp.Value = 0; }

                else
                    progressBarHp.Value -= 15;
                if (progressBarHunger.Value + 20 >= progressBarHunger.Maximum) { progressBarHunger.Value = 100; }

                else
                    progressBarHunger.Value += 20;
                if (progressBarAlcoholism.Value + 40 >= progressBarAlcoholism.Maximum) { progressBarAlcoholism.Value = 100; }

                else
                    progressBarAlcoholism.Value += 40;
            }
            if (StatusChoise == "ChoiseDrink")
            {
                if (progressBarHp.Value + 30 >= progressBarHp.Maximum) { progressBarHp.Value = 100; }

                else
                    progressBarHp.Value += 30;

                if (progressBarHunger.Value + 10 >= progressBarHunger.Maximum) { progressBarHunger.Value = 100; }

                else
                    progressBarHunger.Value += 10;


            }
            if (StatusChoise == "ChoiseVape")
            {
                if (progressBarDrug.Value + 30 >= progressBarDrug.Maximum) { progressBarDrug.Value = 100; }

                else
                    progressBarDrug.Value += 30;
                if (progressBarHp.Value - 10 <= progressBarHp.Minimum) { progressBarHp.Value = 0; }

                else
                    progressBarHp.Value -= 10;
               
            }
            if (StatusChoise == "ChoiseMedicines")
            {
                if (progressBarAlcoholism.Value - 10 <= progressBarAlcoholism.Minimum) { progressBarAlcoholism.Value = 0; }

                else
                    progressBarAlcoholism.Value -= 10;
                if (progressBarHp.Value + 30 >= progressBarHp.Maximum) { progressBarHp.Value = 100; }

                else
                    progressBarHp.Value += 30;
                if (progressBarDrug.Value + 30 >= progressBarDrug.Maximum) { progressBarDrug.Value = 100; }

                else
                    progressBarDrug.Value += 30;
                if (progressBarDiseases.Value - 20 <= progressBarDiseases.Minimum) { progressBarDiseases.Value = 0; }

                else
                    progressBarDiseases.Value -= 20;
            }
            if (StatusChoise == "ChoiseAnimal")
            {
                if (progressBarHunger.Value + 20 >= progressBarHunger.Maximum) { progressBarHunger.Value = 100; }

                else
                    progressBarHunger.Value += 20;
            }
            if (StatusChoise == "ChoiseWeapon")
            {
                if (progressBarHp.Value - 100 <= progressBarHp.Minimum) { progressBarHp.Value = 0; }

                else
                    progressBarHp.Value -= 100;
            }
            if (StatusChoise == "ChoiseHope")
            {
                if (progressBarMorale.Value + 60 >= progressBarMorale.Maximum) { progressBarMorale.Value = 100; }

                else
                    progressBarMorale.Value += 60;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            
            // Обновление времени игры
            gameTime = gameTime.Add(TimeSpan.FromSeconds(300));
            // Обновление дня
            if (gameTime.TotalHours >= 24)
            {
                currentDay++;
                gameTime = TimeSpan.Zero;
                if (currentDay == 2)
                {
                    //Form1 form1 = new Form1();
                    //form1.BackgroundImage = Properties.Resources.BackgroundcitySeamlessSoBroken;
                }
            }

            label8.Text = "День " + currentDay.ToString() + " | Время: " + gameTime.ToString("hh':'mm");

            // Проверка условий поражения
            if (progressBarHp.Value <= 0)
            {
                timer2.Stop();
                timer1.Stop();
                MessageBox.Show("Вы скончались\nВы прожили " + currentDay.ToString() + "день(дней)");
            }
            if (progressBarDiseases.Value == 100)
            {
                timer2.Stop();
                timer1.Stop();
                MessageBox.Show("Вы заболели и умерли\nВы прожили " + currentDay.ToString() + "день(дней)");
            }
        

        }

        private  void button9_Click(object sender, EventArgs e)
        {


            // Показать Form1
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (StatusGame)
            {
                button10.Text = "Продолжить";
                timer2.Stop();
                timer1.Stop();
                StatusGame = false;
                MessageBox.Show("Пауза");
            }
            else
            {
                button10.Text = "Пауза";
                timer2.Start();
                timer1.Start();
                StatusGame = true;

                MessageBox.Show("Игра продолжилась");
            }

        }
    }
}
