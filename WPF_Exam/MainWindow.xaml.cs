using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Exam
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();

        int failCount = 0;
        int timeSpent = 0;
        int symbsTyped = 0;
        bool IsCaps;
        string trainingSymbs = "";
        Random rnd;
        int textCapacity = 45; //для бесконечного мода
        bool fail = false;
        double old_bug = 0;

        public MainWindow()
        {
            InitializeComponent();

            //System.Windows.Forms.MessageBox.Show(InputLanguage.CurrentInputLanguage.Culture.Name); //для проверки работы CurrentInputLanguage ru-RU en-US

            rb_symb1.Content = ",./<>?";
            rb_symb2.Content = ";'\\:\"|";
            rb_symb5.Content = "$%^&*";

            myTimer.Tick += new EventHandler(myTimer_Tick);
            myTimer.Interval = 1000;

            rnd = new Random();
        }
        //просто комментарий с клавишами символов/цифр
        /*
        D1; //!
        D2; //eng @ РУС "
        D3; //eng # РУС №
        D4; //eng $ РУС ;
        D5; //%
        D6; //eng ^ РУС :
        D7; //eng & РУС ?
        D8; //*
        D9; //(
        D0; //)
        OemMinus; //-_
        OemPlus; //=+
        OemOpenBrackets; //eng[{
        Oem6; //eng ]}
        Oem5; //\|
        Oem1; //eng ;:
        OemQuotes; //eng '"
        OemComma; //eng ,<
        OemPeriod; //eng .>
        OemQuestion; //end /? //РУС .,
         */
        //просто комментарий с клваишами букв
        /*
        Q; //й
        W; //ц
        E; //у
        R; //к
        T; //е
        Y; //н
        U; //г
        I; //ш
        O; //щ
        P; //з
        OemOpenBrackets; //х
        Oem6; //ъ
        A; //ф
        S; //ы
        D; //в
        F; //а
        G; //п
        H; //р
        J; //о
        K; //л
        L; //д
        Oem1; //ж
        OemQuotes; //э
        Z; //я
        X; //ч
        C; //с
        V; //м
        B; //и
        N; //т
        M; //ь
        OemComma; //б
        OemPeriod; //ю
         */
        private void EngLetterCap()
        {
            Q.Content = "Q";
            W.Content = "W";
            E.Content = "E";
            R.Content = "R";
            T.Content = "T";
            Y.Content = "Y";
            U.Content = "U";
            I.Content = "I";
            O.Content = "O";
            P.Content = "P";
            A.Content = "A";
            S.Content = "S";
            D.Content = "D";
            F.Content = "F";
            G.Content = "G";
            H.Content = "H";
            J.Content = "J";
            K.Content = "K";
            L.Content = "L";
            Z.Content = "Z";
            X.Content = "X";
            C.Content = "C";
            V.Content = "V";
            B.Content = "B";
            N.Content = "N";
            M.Content = "M";
        }
        private void RuLetterCap()
        {
            Q.Content = "Й";
            W.Content = "Ц";
            E.Content = "У";
            R.Content = "К";
            T.Content = "Е";
            Y.Content = "Н";
            U.Content = "Г";
            I.Content = "Ш";
            O.Content = "Щ";
            P.Content = "З";
            OemOpenBrackets.Content = "Х";
            Oem6.Content = "Ъ";
            A.Content = "Ф";
            S.Content = "Ы";
            D.Content = "В";
            F.Content = "А";
            G.Content = "П";
            H.Content = "Р";
            J.Content = "О";
            K.Content = "Л";
            L.Content = "Д";
            Oem1.Content = "Ж";
            OemQuotes.Content = "Э";
            Z.Content = "Я";
            X.Content = "Ч";
            C.Content = "С";
            V.Content = "М";
            B.Content = "И";
            N.Content = "Т";
            M.Content = "Ь";
            OemComma.Content = "Б";
            OemPeriod.Content = "Ю";
        }
        private void RuLetter()
        {
            Q.Content = "й";
            W.Content = "ц";
            E.Content = "у";
            R.Content = "к";
            T.Content = "е";
            Y.Content = "н";
            U.Content = "г";
            I.Content = "ш";
            O.Content = "щ";
            P.Content = "з";
            OemOpenBrackets.Content = "х";
            Oem6.Content = "ъ";
            A.Content = "ф";
            S.Content = "ы";
            D.Content = "в";
            F.Content = "а";
            G.Content = "п";
            H.Content = "р";
            J.Content = "о";
            K.Content = "л";
            L.Content = "д";
            Oem1.Content = "ж";
            OemQuotes.Content = "э";
            Z.Content = "я";
            X.Content = "ч";
            C.Content = "с";
            V.Content = "м";
            B.Content = "и";
            N.Content = "т";
            M.Content = "ь";
            OemComma.Content = "б";
            OemPeriod.Content = "ю";
        }
        private void EngLetter()
        {
            Q.Content = "q";
            W.Content = "w";
            E.Content = "e";
            R.Content = "r";
            T.Content = "t";
            Y.Content = "y";
            U.Content = "u";
            I.Content = "i";
            O.Content = "o";
            P.Content = "p";
            A.Content = "a";
            S.Content = "s";
            D.Content = "d";
            F.Content = "f";
            G.Content = "g";
            H.Content = "h";
            J.Content = "j";
            K.Content = "k";
            L.Content = "l";
            Z.Content = "z";
            X.Content = "x";
            C.Content = "c";
            V.Content = "v";
            B.Content = "b";
            N.Content = "n";
            M.Content = "m";
        }
        private void EngSymbShift()
        {
            D1.Content = "!";
            D2.Content = "@";
            D3.Content = "#";
            D4.Content = "$";
            D5.Content = "%";
            D6.Content = "^";
            D7.Content = "&";
            D8.Content = "*";
            D9.Content = "(";
            D0.Content = ")";
            OemMinus.Content = "_";
            OemPlus.Content = "+";
            OemOpenBrackets.Content = "{";
            Oem6.Content = "}";
            Oem5.Content = "|";
            Oem1.Content = ":";
            OemQuotes.Content = "\"";
            OemComma.Content = "<";
            OemPeriod.Content = ">";
            OemQuestion.Content = "?";
        }
        private void EngSymb()
        {
            D1.Content = "1";
            D2.Content = "2";
            D3.Content = "3";
            D4.Content = "4";
            D5.Content = "5";
            D6.Content = "6";
            D7.Content = "7";
            D8.Content = "8";
            D9.Content = "9";
            D0.Content = "0";
            OemMinus.Content = "-";
            OemPlus.Content = "=";
            OemOpenBrackets.Content = "[";
            Oem6.Content = "]";
            Oem5.Content = "\\";
            Oem1.Content = ";";
            OemQuotes.Content = "'";
            OemComma.Content = ",";
            OemPeriod.Content = ".";
            OemQuestion.Content = "/";
        }
        private void RuSymbShift()
        {
            D1.Content = "!";
            D2.Content = "\"";
            D3.Content = "№";
            D4.Content = ";";
            D5.Content = "%";
            D6.Content = ":";
            D7.Content = "?";
            D8.Content = "*";
            D9.Content = "(";
            D0.Content = ")";
            OemMinus.Content = "_";
            OemPlus.Content = "+";
            Oem5.Content = "|";
            OemQuestion.Content = ",";
        }
        private void RuSymb()
        {
            D1.Content = "1";
            D2.Content = "2";
            D3.Content = "3";
            D4.Content = "4";
            D5.Content = "5";
            D6.Content = "6";
            D7.Content = "7";
            D8.Content = "8";
            D9.Content = "9";
            D0.Content = "0";
            OemMinus.Content = "-";
            OemPlus.Content = "=";
            Oem5.Content = "\\";
            OemQuestion.Content = ".";
        }

        private void Bug_moveFunc()
        {
            TranslateTransform bug_move = new TranslateTransform();
            r_bug.RenderTransform = bug_move;
            var Anime = new DoubleAnimation();
            Anime.From = old_bug;
            Anime.To = (fail==false) ? 1.0 * progB_fail.Width / progB_fail.Maximum * progB_fail.Value : 0;
            old_bug = 1.0 * progB_fail.Width / progB_fail.Maximum * progB_fail.Value;
            Anime.Duration = TimeSpan.FromSeconds(1);
            bug_move.BeginAnimation(TranslateTransform.XProperty, Anime);
            if(Anime.To >= progB_fail.Width && fail==false)
            {
                fail = true;
                bt_stop_Click(null, null);
            }
        }
        private void myTimer_Tick(object sender, EventArgs e)
        {
            timeSpent += 1;
            l_symbMin.Content = $"Символы/минута: {(Decimal.ToInt32((decimal)(1.0 * symbsTyped / timeSpent) * 60)).ToString()}";
            l_timeSpent.Content = $"Времени прошло: {timeSpent}";
            if (rb_infinity.IsChecked == true)
            {
                if (cb_fail.IsChecked == true)
                {
                    progB_fail.Value += 1 * slider_dif.Value;
                    //if (progB_fail.Value >= progB_fail.Maximum)
                    //{
                    //    fail = true;
                    //    bt_stop_Click(null, null);
                    //}
                    Bug_moveFunc();
                }
            }
            user_text.Background = Brushes.Yellow;
            write_text.Background = Brushes.LightGray;
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            user_text.Focus();
            IsCaps = Keyboard.IsKeyToggled(Key.CapsLock);
            string language = InputLanguage.CurrentInputLanguage.Culture.Name;

            if (language == "ru-RU")
            {
                if (IsCaps == true) RuLetterCap();
                else RuLetter();
                RuSymb();
            }
            if (language == "en-US")
            {
                if (IsCaps == true) EngLetterCap();
                else EngLetter();
                EngSymb();
            }
            foreach (UIElement it in grid_keyBoard.Children)
            {
                if (it is StackPanel)
                {
                    foreach (var item in (it as StackPanel).Children)
                    {
                        if (item is System.Windows.Controls.Button)
                        {
                            if ((item as System.Windows.Controls.Button).Name == e.Key.ToString())
                            {
                                (item as System.Windows.Controls.Button).Opacity = 0.5;
                                if (e.Key.ToString() == "LeftShift" || e.Key.ToString() == "RightShift")
                                {
                                    if (language == "ru-RU")
                                    {
                                        RuSymbShift();
                                        if (IsCaps)
                                        {
                                            RuLetter();
                                        }
                                        else
                                        {
                                            RuLetterCap();
                                        }
                                    }
                                    if (language == "en-US")
                                    {
                                        EngSymbShift();
                                        if (IsCaps)
                                        {
                                            EngLetter();
                                        }
                                        else
                                        {
                                            EngLetterCap();
                                        }
                                    }
                                }
                                else if (e.Key.ToString() == "Capital")
                                {
                                    if (language == "ru-RU")
                                    {
                                        IsCaps = Keyboard.IsKeyToggled(Key.CapsLock);
                                        if (IsCaps)
                                        {
                                            RuLetterCap();
                                            IsCaps = Keyboard.IsKeyToggled(Key.CapsLock);
                                        }
                                        else
                                        {
                                            RuLetter();
                                            IsCaps = Keyboard.IsKeyToggled(Key.CapsLock);
                                        }
                                    }
                                    if (language == "en-US")
                                    {
                                        IsCaps = Keyboard.IsKeyToggled(Key.CapsLock);
                                        if (IsCaps)
                                        {
                                            EngLetterCap();
                                            IsCaps = Keyboard.IsKeyToggled(Key.CapsLock);
                                        }
                                        else
                                        {
                                            EngLetter();
                                            IsCaps = Keyboard.IsKeyToggled(Key.CapsLock);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (IsCaps) Capital.Background = Brushes.Coral;
            else Capital.Background = Brushes.LightCoral;
        }

        private void Window_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            string language = InputLanguage.CurrentInputLanguage.Culture.Name;

            if (language == "ru-RU")
            {
                if (IsCaps == true) RuLetterCap();
                else RuLetter();
                RuSymb();
            }
            if (language == "en-US")
            {
                if (IsCaps == true) EngLetterCap();
                else EngLetter();
                EngSymb();
            }
            foreach (UIElement it in grid_keyBoard.Children)
            {
                if (it is StackPanel)
                {
                    foreach (var item in (it as StackPanel).Children)
                    {
                        if (item is System.Windows.Controls.Button)
                        {
                            if ((item as System.Windows.Controls.Button).Name == e.Key.ToString())
                            {
                                (item as System.Windows.Controls.Button).Opacity = 1;
                                if (e.Key.ToString() == "LeftShift" || e.Key.ToString() == "RightShift")
                                {
                                    if (language == "ru-RU")
                                    {
                                        RuSymb();
                                        if (IsCaps)
                                        {
                                            RuLetterCap();
                                        }
                                        else
                                        {
                                            RuLetter();
                                        }
                                    }
                                    if (language == "en-US")
                                    {
                                        EngSymb();
                                        if (IsCaps)
                                        {
                                            EngLetterCap();
                                        }
                                        else
                                        {
                                            EngLetter();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (IsCaps) Capital.Background = Brushes.Coral;
            else Capital.Background = Brushes.LightCoral;

            if (bt_start.IsEnabled == false)
            {
                if (rb_infinity.IsChecked == true)
                {
                    if (user_text.Text != "" && write_text.Text != "")
                    {
                        if (user_text.Text[0] == write_text.Text[0])
                        {
                            user_text.Background = Brushes.LightGreen;
                            write_text.Background = Brushes.LightGreen;
                            if (cb_fail.IsChecked == true)
                            {
                                progB_fail.Value -= 3;
                                //TranslateTransform bug_move = new TranslateTransform(1.0 * progB_fail.Width / progB_fail.Maximum * progB_fail.Value, 0);
                                //r_bug.RenderTransform = bug_move;
                                //Bug_moveFunc();
                            }
                            string temp = "";
                            bool isSpace = false;
                            for (int i = 1; i < write_text.Text.Length; i++)
                            {
                                temp += write_text.Text[i];
                                if (write_text.Text[i] == ' ') isSpace = true;
                                else isSpace = false;
                            }
                            if (isSpace == false)
                            {
                                int chanceSpace = rnd.Next(4);
                                if (chanceSpace == 1) { temp += " "; }
                                else { temp += trainingSymbs[rnd.Next(trainingSymbs.Length)]; }
                            }
                            else { temp += trainingSymbs[rnd.Next(trainingSymbs.Length)]; }
                            write_text.Text = temp;
                            symbsTyped += 1;
                        }
                        else
                        {
                            user_text.Background = Brushes.Red;
                            write_text.Background = Brushes.Red;
                            failCount += 1;
                            l_fails.Content = $"Ошибки: {failCount}";
                            if (cb_fail.IsChecked == true)
                            {
                                progB_fail.Value += 6 * slider_dif.Value;
                                //TranslateTransform bug_move = new TranslateTransform(1.0 * progB_fail.Width / progB_fail.Maximum * progB_fail.Value, 0);
                                //r_bug.RenderTransform = bug_move;
                                //Bug_moveFunc();
                            }
                        }
                        user_text.Text = "";
                    }
                }
                if (rb_someWords.IsChecked == true)
                {
                    if (write_text.Text == "")
                    {
                        bt_stop_Click(null, null);
                        progB_toEnd.Value = 100;
                    }
                    else if (user_text.Text != "" && write_text.Text != "")
                    {
                        if (user_text.Text[0] == write_text.Text[0])
                        {
                            progB_toEnd.Value = Decimal.ToInt32((decimal)100 / (list_wordsCount.SelectedIndex+11)*symbsTyped/6);
                            user_text.Background = Brushes.LightGreen;
                            write_text.Background = Brushes.LightGreen;
                            symbsTyped += 1;
                            string temp = "";
                            for (int i = 1; i < write_text.Text.Length; i++)
                            {
                                temp += write_text.Text[i];
                            }
                            write_text.Text = temp;
                        }
                        else
                        {
                            user_text.Background = Brushes.Red;
                            write_text.Background = Brushes.Red;
                            failCount += 1;
                            l_fails.Content = $"Ошибки: {failCount}";
                        }
                        user_text.Text = "";
                    }
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 10; i <= 40; i++)
            {
                list_wordsCount.Items.Add(i);
            }
            list_wordsCount.SelectedIndex = 0;

            IsCaps = Keyboard.IsKeyToggled(Key.CapsLock);

            if (InputLanguage.CurrentInputLanguage.Culture.Name == "ru-RU")
            {
                if (IsCaps == true) RuLetterCap();
                else RuLetter();
                RuSymb();
            }
            if (InputLanguage.CurrentInputLanguage.Culture.Name == "en-US")
            {
                if (IsCaps == true) EngLetterCap();
                else EngLetter();
                EngSymb();
            }
            if (IsCaps) Capital.Background = Brushes.Coral;
            else Capital.Background = Brushes.LightCoral;
        }

        private void rb_infinity_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                list_wordsCount.IsEnabled = false;
                cb_fail.IsEnabled = true;
            }
            catch (Exception) { }
        }
        private void rb_someWords_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                list_wordsCount.IsEnabled = true;
                cb_fail.IsEnabled = false;
            }
            catch (Exception) { }
        }
        private void rb_ru_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                EngLetters.IsEnabled = false;
                ruLetters.IsEnabled = true;
            }
            catch (Exception) { }
        }
        private void rb_us_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                EngLetters.IsEnabled = true;
                ruLetters.IsEnabled = false;
            }
            catch (Exception) { }
        }
        private void rb_bothLang_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                EngLetters.IsEnabled = true;
                ruLetters.IsEnabled = true;
            }
            catch (Exception) { }
        }
        private void rb_writeLetters_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                gb_lang.IsEnabled = true;
                cb_caps.IsEnabled = true;
                ruLetters.IsEnabled = rb_us.IsChecked == true ? false : true;
                EngLetters.IsEnabled = rb_ru.IsChecked == true ? false : true;
                numbers.IsEnabled = false;
                symbols.IsEnabled = false;
            }
            catch (Exception) { }
        }
        private void rb_writeNumbers_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                gb_lang.IsEnabled = false;
                cb_caps.IsEnabled = false;
                ruLetters.IsEnabled = false;
                EngLetters.IsEnabled = false;
                numbers.IsEnabled = true;
                symbols.IsEnabled = false;
            }
            catch (Exception) { }
        }
        private void rb_writeSymbols_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                gb_lang.IsEnabled = false;
                cb_caps.IsEnabled = false;
                EngLetters.IsEnabled = false;
                ruLetters.IsEnabled = false;
                numbers.IsEnabled = false;
                symbols.IsEnabled = true;
            }
            catch (Exception) { }
        }
        private void rb_writeAll_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                gb_lang.IsEnabled = true;
                cb_caps.IsEnabled = true;
                ruLetters.IsEnabled = rb_us.IsChecked == true ? false : true;
                EngLetters.IsEnabled = rb_ru.IsChecked == true ? false : true;
                numbers.IsEnabled = true;
                symbols.IsEnabled = true;
            }
            catch (Exception) { }
        }

        private void trainingSymbsAdd()
        {
            if (rb_writeLetters.IsChecked == true)
            {
                if (rb_ru.IsChecked == true)
                {
                    foreach (UIElement item in gb_ruLetters.Children)
                    {
                        if (item is System.Windows.Controls.RadioButton)
                        {
                            if ((item as System.Windows.Controls.RadioButton).IsChecked == true)
                            {
                                if ((item as System.Windows.Controls.RadioButton).Content.ToString() == "Все")
                                {
                                    trainingSymbs += "абвгдежзийклмнопрстуфхцчшщъыьэюя";
                                    if (cb_caps.IsChecked == true) trainingSymbs += "абвгдежзийклмнопрстуфхцчшщъыьэюя".ToUpper();
                                }
                                else
                                {
                                    trainingSymbs += (item as System.Windows.Controls.RadioButton).Content.ToString();
                                    if (cb_caps.IsChecked == true) trainingSymbs += (item as System.Windows.Controls.RadioButton).Content.ToString().ToUpper();
                                }
                            }
                        }
                    }
                }
                else if (rb_us.IsChecked == true)
                {
                    foreach (UIElement item in gb_EngLetters.Children)
                    {
                        if (item is System.Windows.Controls.RadioButton)
                        {
                            if ((item as System.Windows.Controls.RadioButton).IsChecked == true)
                            {
                                if ((item as System.Windows.Controls.RadioButton).Content.ToString() == "Все")
                                {
                                    trainingSymbs += "qwertyuiopasdfghjklzxcvbnm";
                                    if (cb_caps.IsChecked == true) trainingSymbs += "qwertyuiopasdfghjklzxcvbnm".ToUpper();
                                }
                                else
                                {
                                    trainingSymbs += (item as System.Windows.Controls.RadioButton).Content.ToString();
                                    if (cb_caps.IsChecked == true) trainingSymbs += (item as System.Windows.Controls.RadioButton).Content.ToString().ToUpper();
                                }
                            }
                        }
                    }
                }
                else
                {
                    foreach (UIElement item in gb_ruLetters.Children)
                    {
                        if (item is System.Windows.Controls.RadioButton)
                        {
                            if ((item as System.Windows.Controls.RadioButton).IsChecked == true)
                            {
                                if ((item as System.Windows.Controls.RadioButton).Content.ToString() == "Все")
                                {
                                    trainingSymbs += "абвгдежзийклмнопрстуфхцчшщъыьэюя";
                                    if (cb_caps.IsChecked == true) trainingSymbs += "абвгдежзийклмнопрстуфхцчшщъыьэюя".ToUpper();
                                }
                                else
                                {
                                    trainingSymbs += (item as System.Windows.Controls.RadioButton).Content.ToString();
                                    if (cb_caps.IsChecked == true) trainingSymbs += (item as System.Windows.Controls.RadioButton).Content.ToString().ToUpper();
                                }
                            }
                        }
                    }
                    foreach (UIElement item in gb_EngLetters.Children)
                    {
                        if (item is System.Windows.Controls.RadioButton)
                        {
                            if ((item as System.Windows.Controls.RadioButton).IsChecked == true)
                            {
                                if ((item as System.Windows.Controls.RadioButton).Content.ToString() == "Все")
                                {
                                    trainingSymbs += "qwertyuiopasdfghjklzxcvbnm";
                                    if (cb_caps.IsChecked == true) trainingSymbs += "qwertyuiopasdfghjklzxcvbnm".ToUpper();
                                }
                                else
                                {
                                    trainingSymbs += (item as System.Windows.Controls.RadioButton).Content.ToString();
                                    if (cb_caps.IsChecked == true) trainingSymbs += (item as System.Windows.Controls.RadioButton).Content.ToString().ToUpper();
                                }
                            }
                        }
                    }
                }
            }
            if (rb_writeNumbers.IsChecked == true)
            {
                foreach (UIElement item in gb_numbers.Children)
                {
                    if (item is System.Windows.Controls.RadioButton)
                    {
                        if ((item as System.Windows.Controls.RadioButton).IsChecked == true)
                        {
                            if ((item as System.Windows.Controls.RadioButton).Content.ToString() == "Все")
                            {
                                trainingSymbs += "1234567890";
                            }
                            else trainingSymbs += (item as System.Windows.Controls.RadioButton).Content.ToString();
                        }
                    }
                }
            }
            if (rb_writeSymbols.IsChecked == true)
            {
                foreach (UIElement item in gb_symbols.Children)
                {
                    if (item is System.Windows.Controls.RadioButton)
                    {
                        if ((item as System.Windows.Controls.RadioButton).IsChecked == true)
                        {
                            if ((item as System.Windows.Controls.RadioButton).Content.ToString() == "Все")
                            {
                                trainingSymbs += ",./<>?;'\\:\"|$%^&*[]{}-=_+!@#№()";
                            }
                            else trainingSymbs += (item as System.Windows.Controls.RadioButton).Content.ToString();
                        }
                    }
                }
            }
            if (rb_writeAll.IsChecked == true)
            {
                foreach (UIElement item in gb_symbols.Children)
                {
                    if (item is System.Windows.Controls.RadioButton)
                    {
                        if ((item as System.Windows.Controls.RadioButton).IsChecked == true)
                        {
                            if ((item as System.Windows.Controls.RadioButton).Content.ToString() == "Все")
                            {
                                trainingSymbs += ",./<>?;'\\:\"|$%^&*[]{}-=_+!@#№()";
                            }
                            else trainingSymbs += (item as System.Windows.Controls.RadioButton).Content.ToString();
                        }
                    }
                }
                foreach (UIElement item in gb_numbers.Children)
                {
                    if (item is System.Windows.Controls.RadioButton)
                    {
                        if ((item as System.Windows.Controls.RadioButton).IsChecked == true)
                        {
                            if ((item as System.Windows.Controls.RadioButton).Content.ToString() == "Все")
                            {
                                trainingSymbs += "1234567890";
                            }
                            else trainingSymbs += (item as System.Windows.Controls.RadioButton).Content.ToString();
                        }
                    }
                }
                foreach (UIElement item in gb_ruLetters.Children)
                {
                    if (item is System.Windows.Controls.RadioButton)
                    {
                        if ((item as System.Windows.Controls.RadioButton).IsChecked == true)
                        {
                            if ((item as System.Windows.Controls.RadioButton).Content.ToString() == "Все")
                            {
                                trainingSymbs += "абвгдежзийклмнопрстуфхцчшщъыьэюя";
                                if (cb_caps.IsChecked == true) trainingSymbs += "абвгдежзийклмнопрстуфхцчшщъыьэюя".ToUpper();
                            }
                            else
                            {
                                trainingSymbs += (item as System.Windows.Controls.RadioButton).Content.ToString();
                                if (cb_caps.IsChecked == true) trainingSymbs += (item as System.Windows.Controls.RadioButton).Content.ToString().ToUpper();
                            }
                        }
                    }
                }
                foreach (UIElement item in gb_EngLetters.Children)
                {
                    if (item is System.Windows.Controls.RadioButton)
                    {
                        if ((item as System.Windows.Controls.RadioButton).IsChecked == true)
                        {
                            if ((item as System.Windows.Controls.RadioButton).Content.ToString() == "Все")
                            {
                                trainingSymbs += "qwertyuiopasdfghjklzxcvbnm";
                                if (cb_caps.IsChecked == true) trainingSymbs += "qwertyuiopasdfghjklzxcvbnm".ToUpper();
                            }
                            else
                            {
                                trainingSymbs += (item as System.Windows.Controls.RadioButton).Content.ToString();
                                if (cb_caps.IsChecked == true) trainingSymbs += (item as System.Windows.Controls.RadioButton).Content.ToString().ToUpper();
                            }
                        }
                    }
                }
            }
        }

        private void writeTextFill()
        {
            string temp = "";
            if (rb_infinity.IsChecked == true)
            {
                bool isSpace = true;
                for (int i = 0; i < textCapacity; i++)
                {
                    if (isSpace == false)
                    {
                        int chanceSpace = rnd.Next(4);
                        if (chanceSpace == 1) { temp += " "; isSpace = true; }
                        else { temp += trainingSymbs[rnd.Next(trainingSymbs.Length)]; isSpace = false; }
                    }
                    else { temp += trainingSymbs[rnd.Next(trainingSymbs.Length)]; isSpace = false; }
                }
                write_text.Text = temp;
            }
            if (rb_someWords.IsChecked == true)
            {
                for (int i = 0; i < list_wordsCount.SelectedIndex + 10; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        temp += trainingSymbs[rnd.Next(trainingSymbs.Length)];
                    }
                    if (i != list_wordsCount.SelectedIndex + 10-1) temp += " ";
                }
                write_text.Text = temp;
            }
        }

        private void bt_start_Click(object sender, RoutedEventArgs e)
        {
            progB_toEnd.Value = 0;
            progB_fail.Value = 0;
            l_fails.Content = "Ошибки: 0";
            failCount = 0;
            timeSpent = 0;
            symbsTyped = 0;
            bt_start.IsEnabled = false;
            bt_stop.IsEnabled = true;
            tab_settings.IsEnabled = false;

            trainingSymbs = "";
            trainingSymbsAdd();
            //System.Windows.Forms.MessageBox.Show(trainingSymbs); //для проверки заполнения массива
            writeTextFill();
            user_text.IsEnabled = true;
            user_text.Focus();
            myTimer.Start();
        }

        private void bt_stop_Click(object sender, RoutedEventArgs e)
        {
            myTimer.Stop();
            if (fail == true)
            {
                bt_stop.Opacity = 0;
                bt_start.Opacity = 0;
                var Anime = new DoubleAnimation();
                Anime.From = 0;
                Anime.To = Height;
                Anime.Duration = TimeSpan.FromSeconds(2.5);
                img_lose.BeginAnimation(Image.HeightProperty, Anime);
                System.Windows.Forms.MessageBox.Show("Ужасный жук добрался до вас...", "Вы проигарли!");
                Anime.From = img_lose.Height;
                Anime.To = 0;
                Anime.Duration = TimeSpan.FromSeconds(2);
                img_lose.BeginAnimation(Image.HeightProperty, Anime);
                bt_stop.Opacity = 1;
                bt_start.Opacity = 1;
            }
            //TranslateTransform bug_start = new TranslateTransform(0, 0);
            //r_bug.RenderTransform = bug_start;
            Bug_moveFunc();
            fail = false;
            progB_fail.Value = 0;
            progB_toEnd.Value = 0;
            user_text.Text = "";
            write_text.Text = "";
            failCount = 0;
            timeSpent = 0;
            symbsTyped = 0;
            bt_start.IsEnabled = true;
            bt_stop.IsEnabled = false;
            tab_settings.IsEnabled = true;

            user_text.IsEnabled = false;
            user_text.Background = Brushes.Yellow;
            write_text.Background = Brushes.LightGray;
        }
    }
}
