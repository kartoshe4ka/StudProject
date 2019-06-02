using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject
{
    class GameAlgorithm
    {
        static string turnOver(string str) // Используется в Exercise7
        {
            string ans = null;
            for (int i = str.Length; i >= 0; --i)
                ans += str[i];
            return ans;
        }

        #region Функции Exersise
        static int Exercise1(int n)
        {
            int m = n + 3;
            return m;
        }
        static int Exercise2(int n)
        {
            int m = 2 * n + 6;
            return m;
        }
        static int Exercise3(int n)
        {
            int m = n / 10;
            return m;
        }
        static int Exercise4(int n)
        {
            int m = n % 10;
            return Math.Abs(m);
        }
        static int Exercise5(int n)
        { 
            int m = 0;
            bool k = false;
            if (n < 0)
            {
                k = true;
                n = Math.Abs(n);
            }

            while (n != 0)
            {
                m += n % 10;
                n /= 10;
                if (k && n/10==0)
                    m += n * -2;
            }

            return m;
        }
        static int Exercise6(int n)
        {
            int m = 0;
            while (n != 0)
            {
                m += 1;
                n /= 10;
            }
            return m;
        }
        static int Exercise7(int n)
        {
            string l = Convert.ToString(n);
            int m = int.Parse(turnOver(l));
            return m;
        }
        static int Exercise8(int n)
        {
            int m = (n / 10) + (n % 10);
            return m;
        }
        static int Exercise9(int n)
        {
            int m;
            if (n > 0 && n <= 50) m = n + 1;
            else m = n - 1;
            return m;
        }
        static int Exercise10(int n)
        {
            int m;
            if (n % 2 == 0) m = n / 2;
            else m = n * 2;
            return m;
        }
        static int Exercise11(int n)
        {
            int m;
            if (n >= 0) m = n % 10;
            else m = Math.Abs(n);
            return m;
        }
        static int Exercise12(int n)
        {
            int m;
            if (n % 3 == 0) m = n / 3;
            else
                m = 0;
            while (n != 0)
            {
                m += n % 10;
                n /= 10;
            }
            return m;
        }
        #endregion

        public static int Exercises(int a, int Level)
        {
            int b = 0;
            switch (Level)
            {
                case 1: b = Exercise1(a); break;
                case 2: b = Exercise2(a); break;
                case 3: b = Exercise3(a); break;
                case 4: b = Exercise4(a); break;
                case 5: b = Exercise5(a); break;
                case 6: b = Exercise6(a); break;
                case 7: b = Exercise7(a); break;
                case 8: b = Exercise8(a); break;
                case 9: b = Exercise9(a); break;
                case 10: b = Exercise10(a); break;
                case 11: b = Exercise11(a); break;
                case 12: b = Exercise12(a); break;
            }
            return b;
        }
    }
}
