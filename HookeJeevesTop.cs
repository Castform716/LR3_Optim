using System;
using System.Collections.Generic;
using System.Text;

namespace LR3_Optim
{
    class HookeJeevesTop
    {

        public delegate double Function(double[] vars);

        //fucntion - целевая функция
        // X - начальные координаты
        // е - точность
        // h - шаг
        static public double[] HookeJeevesMethod(Function function, double[] X, double e, double h, double max_step)
        {
            double step = 0; ;
            double N = X.Length;
            double[] X_b = X, X1, X_ob;
            double f = function(X);
            double f_b = function(X), f1 = 0;



            while (h > e)
            {
                // проводим исследование по координатам
                X = X_b;
                f = f_b;
                X1 = X;
                for (int i = 0; i < N; i++)
                {
                    X1[i] = X[i] + h;
                    f1 = function(X1);
                    if (f1 > f)
                    {
                        X = X1;
                        f = f1;
                    }
                    else
                    {
                        X1[i] = X[i] - h;
                        f1 = function(X1);
                        if (f1 > f)
                        {
                            X = X1;
                            f = f1;
                        }
                    }
                }
                //проверяем текущее значение и значение в базисной точке на меньше
                if (f > f_b)
                {
                    while (step < max_step)
                    {
                        //берем новую базисную точку и значение в ней, сохранив предыдущие  значения
                        X_ob = X_b;
                        X_b = X;
                        f_b = f;
                        //делаем шаг поиска по образцу
                        for (int i = 0; i < N; i++)
                        {
                            X_b[i] = X_ob[i] + 2 * (X_b[i] - X_ob[i]);
                        }
                        //проводим исследование от новой точки, нам нужны временные переменные 
                        X = X_b;
                        //Console.WriteLine("X: " + X[0] + " Y: " + X[1]);
                        f = function(X);
                        //первая координата
                        X1 = X;
                        for (int i = 0; i < N; i++)
                        {
                            X1[i] = X[i] + h;
                            f1 = function(X1);
                            if (f1 > f)
                            {
                                X = X1;
                                f = f1;
                            }
                            else
                            {
                                X1[i] = X[i] - h;
                                f1 = function(X1);
                                if (f1 > f)
                                {
                                    X = X1;
                                    f = f1;
                                }
                            }
                        }
                        if (f <= f_b)
                            break;
                        step++;
                    }
                }
                //в противном случае уменьшаем шаг
                h = h / 10;
                //и продолжаем исследования

            }
            return X_b;
        }
    }

}
