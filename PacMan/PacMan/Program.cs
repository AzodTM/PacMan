﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace PacMan
{
    class Program
    {

        static void Main(string[] args)
        {

            int xPacman = 23, yPacman = 45;  //coordinates pacman/координаты Пакмена
            int xEnemy1 = 22, yEnemy1 = 21; //coordinates enemy #1/координаты врага №1
            char enemy1Score;               //наступил ли враг на *?
            string enemy1move = "moveLeft";                // направление движения врага
            //int xEnemy2 = 20, yEnemy2 = 24;  //coordinates enemy #2/координаты врага №2
            //int xEnemy3 = 25, yEnemy3 = 24;  //coordinates enemy #3/координаты врага №3
            int time = 0;                    //time/время
            int score = 0;                   //score/очки
            int delay = 100;                 //delay/задержка
            #region Map PacMan World/Карта Мира Пакмена
            char[,] map = new char[55, 47]  //Игровая карта
            {   
               // 0   1   2   3   4   5   6   7   8   9  10  11  12  13  14  15  16  17  18  19  20  21  22  23  24  25  26  27  28  29  30  31  32  33  34  35  36  37  38  39  40  41  42  43  44  45  46   
                {'+','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','+',' ','+','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','+'},//0
                {'|','*',' ','*',' ','*',' ','*',' ','*',' ','*',' ','*',' ','*',' ','*',' ','*',' ','*','|',' ','|','*',' ','*',' ','*',' ','*',' ','*',' ','*',' ','*',' ','*',' ','*',' ','*',' ','*','|'},//1
                {'|',' ','+','-','-','-','-','-','-','-','+',' ','+','-','-','-','-','-','-','-','+',' ','|',' ','|',' ','+','-','-','-','-','-','-','-','+',' ','+','-','-','-','-','-','-','-','+',' ','|'},//2
                {'|','Ж','|',' ',' ',' ',' ',' ',' ',' ','|','*','|',' ',' ',' ',' ',' ',' ',' ','|','*','|',' ','|','*','|',' ',' ',' ',' ',' ',' ',' ','|','*','|',' ',' ',' ',' ',' ',' ',' ','|','Ж','|'},//3
                {'|',' ','|',' ',' ',' ',' ',' ',' ',' ','|',' ','|',' ',' ',' ',' ',' ',' ',' ','|',' ','|',' ','|',' ','|',' ',' ',' ',' ',' ',' ',' ','|',' ','|',' ',' ',' ',' ',' ',' ',' ','|',' ','|'},//4
                {'|','*','|',' ',' ',' ',' ',' ',' ',' ','|','*','|',' ',' ',' ',' ',' ',' ',' ','|','*','|',' ','|','*','|',' ',' ',' ',' ',' ',' ',' ','|','*','|',' ',' ',' ',' ',' ',' ',' ','|','*','|'},//5
                {'|',' ','|',' ',' ',' ',' ',' ',' ',' ','|',' ','|',' ',' ',' ',' ',' ',' ',' ','|',' ','|',' ','|',' ','|',' ',' ',' ',' ',' ',' ',' ','|',' ','|',' ',' ',' ',' ',' ',' ',' ','|',' ','|'},//6
                {'|','*','|',' ',' ',' ',' ',' ',' ',' ','|','*','|',' ',' ',' ',' ',' ',' ',' ','|','*','|',' ','|','*','|',' ',' ',' ',' ',' ',' ',' ','|','*','|',' ',' ',' ',' ',' ',' ',' ','|','*','|'},//7
                {'|',' ','+','-','-','-','-','-','-','-','+',' ','+','-','-','-','-','-','-','-','+',' ','+','-','+',' ','+','-','-','-','-','-','-','-','+',' ','+','-','-','-','-','-','-','-','+',' ','|'},//8
                {'|','*',' ','*',' ','*',' ','*',' ','*',' ','*',' ','*',' ','*',' ','*',' ','*',' ','*',' ','*',' ','*',' ','*',' ','*',' ','*',' ','*',' ','*',' ','*',' ','*',' ','*',' ','*',' ','*','|'},//9
                {'|',' ','+','-','-','-','-','-','-','-','+',' ','+','-','+',' ','+','-','-','-','-','-','-','-','-','-','-','-','-','-','+',' ','+','-','+',' ','+','-','-','-','-','-','-','-','+',' ','|'},//10
                {'|','*','|',' ',' ',' ',' ',' ',' ',' ','|','*','|',' ','|','*','|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|','*','|',' ','|','*','|',' ',' ',' ',' ',' ',' ',' ','|','*','|'},//11
                {'|',' ','|',' ',' ',' ',' ',' ',' ',' ','|',' ','|',' ','|',' ','|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|',' ','|',' ','|',' ','|',' ',' ',' ',' ',' ',' ',' ','|',' ','|'},//12
                {'|','*','|',' ',' ',' ',' ',' ',' ',' ','|','*','|',' ','|','*','|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|','*','|',' ','|','*','|',' ',' ',' ',' ',' ',' ',' ','|','*','|'},//13
                {'|',' ','+','-','-','-','-','-','-','-','+',' ','|',' ','|',' ','+','-','-','-','-','-','+',' ','+','-','-','-','-','-','+',' ','|',' ','|',' ','+','-','-','-','-','-','-','-','+',' ','|'},//14
                {'|','*',' ','*',' ','*',' ','*',' ','*',' ','*','|',' ','|','*',' ','*',' ','*',' ','*','|',' ','|','*',' ','*',' ','*',' ','*','|',' ','|','*',' ','*',' ','*',' ','*',' ','*',' ','*','|'},//15
                {'+','-','-','-','-','-','-','-','-','-','+',' ','|',' ','+','-','-','-','-','-','+',' ','|','-','|',' ','+','-','-','-','-','-','+',' ','|',' ','+','-','-','-','-','-','-','-','-','-','+'},//16
                {' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|','*','|',' ',' ',' ',' ',' ',' ',' ','|',' ','|',' ','|',' ','|',' ',' ',' ',' ',' ',' ',' ','|','*','|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' '},//17
                {' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|',' ','|',' ','+','-','-','-','-','-','+',' ','+','-','+',' ','+','-','-','-','-','-','+',' ','|',' ','|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' '},//18
                {' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|','*','|',' ','|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|',' ','|','*','|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' '},//19
                {' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|',' ','|',' ','|',' ','+','-','-','-','-','-','-','-','-','-','-','-','-','-','+',' ','|',' ','|',' ','|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' '},//20
                {' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|','*','|',' ','|',' ','|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|',' ','|',' ','|','*','|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' '},//21
                {' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|',' ','|',' ','|',' ','|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|',' ','|',' ','|',' ','|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' '},//22
                {' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|','*','|',' ','|',' ','|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|',' ','|',' ','|','*','|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' '},//23
                {' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|',' ','|',' ','|',' ','|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|',' ','|',' ','|',' ','|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' '},//24
                {' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|','*','|',' ','|',' ','|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|',' ','|',' ','|','*','|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' '},//25
                {'+','-','-','-','-','-','-','-','-','-','+',' ','+','-','+',' ','|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|',' ','+','-','+',' ','+','-','-','-','-','-','-','-','-','-','+'},//26
                {'<',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',' ',' ',' ',' ','|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','>'},//27 Центр
                {'+','-','-','-','-','-','-','-','-','-','+',' ','+','-','+',' ','|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|',' ','+','-','+',' ','+','-','-','-','-','-','-','-','-','-','+'},//28
                {' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|','*','|',' ','|',' ','|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|',' ','|',' ','|','*','|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' '},//29
                {' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|',' ','|',' ','|',' ','|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|',' ','|',' ','|',' ','|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' '},//30
                {' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|','*','|',' ','|',' ','|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|',' ','|',' ','|','*','|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' '},//31
                {' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|',' ','|',' ','|',' ','|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|',' ','|',' ','|',' ','|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' '},//32
                {' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|','*','|',' ','|',' ','|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|',' ','|',' ','|','*','|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' '},//33
                {' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|',' ','|',' ','|',' ','+','-','-','-','-','-','-','-','-','-','-','-','-','-','+',' ','|',' ','|',' ','|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' '},//34
                {' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|','*','|',' ','|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|',' ','|','*','|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' '},//35
                {' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|',' ','|',' ','+','-','-','-','-','-','+',' ','+','-','+',' ','+','-','-','-','-','-','+',' ','|',' ','|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' '},//36
                {' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|','*','|',' ',' ',' ',' ',' ',' ',' ','|',' ','|',' ','|',' ','|',' ',' ',' ',' ',' ',' ',' ','|','*','|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' '},//37
                {'+','-','-','-','-','-','-','-','-','-','+',' ','|',' ','+','-','-','-','-','-','+',' ','|',' ','|',' ','+','-','-','-','-','-','+',' ','|',' ','+','-','-','-','-','-','-','-','-','-','+'},//38
                {'|','*',' ','*',' ','*',' ','*',' ','*',' ','*','|',' ','|','*',' ','*',' ','*',' ','*','|',' ','|','*',' ','*',' ','*',' ','*','|',' ','|','*',' ','*',' ','*',' ','*',' ','*',' ','*','|'},//39
                {'|',' ','+','-','-','-','-','-','-','-','+',' ','|',' ','|',' ','+','-','-','-','-','-','+',' ','+','-','-','-','-','-','+',' ','|',' ','|',' ','+','-','-','-','-','-','-','-','+',' ','|'},//40
                {'|','*','|',' ',' ',' ',' ',' ',' ',' ','|','*','|',' ','|','*','|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|','*','|',' ','|','*','|',' ',' ',' ',' ',' ',' ',' ','|','*','|'},//41
                {'|',' ','|',' ',' ',' ',' ',' ',' ',' ','|',' ','|',' ','|',' ','|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|',' ','|',' ','|',' ','|',' ',' ',' ',' ',' ',' ',' ','|',' ','|'},//42
                {'|','*','|',' ',' ',' ',' ',' ',' ',' ','|','*','|',' ','|','*','|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|','*','|',' ','|','*','|',' ',' ',' ',' ',' ',' ',' ','|','*','|'},//43
                {'|',' ','+','-','-','-','-','-','-','-','+',' ','+','-','+',' ','+','-','-','-','-','-','-','-','-','-','-','-','-','-','+',' ','+','-','+',' ','+','-','-','-','-','-','-','-','+',' ','|'},//44
                {'|','*',' ','*',' ','*',' ','*',' ','*',' ','*',' ','*',' ','*',' ','*',' ','*',' ','*',' ',' ',' ','*',' ','*',' ','*',' ','*',' ','*',' ','*',' ','*',' ','*',' ','*',' ','*',' ','*','|'},//45
                {'|',' ','+','-','-','-','-','-','-','-','+',' ','+','-','-','-','-','-','-','-','+',' ','+','-','+',' ','+','-','-','-','-','-','-','-','+',' ','+','-','-','-','-','-','-','-','+',' ','|'},//46
                {'|','*','|',' ',' ',' ',' ',' ',' ',' ','|','*','|',' ',' ',' ',' ',' ',' ',' ','|','*','|',' ','|','*','|',' ',' ',' ',' ',' ',' ',' ','|','*','|',' ',' ',' ',' ',' ',' ',' ','|','*','|'},//47
                {'|',' ','|',' ',' ',' ',' ',' ',' ',' ','|',' ','|',' ',' ',' ',' ',' ',' ',' ','|',' ','|',' ','|',' ','|',' ',' ',' ',' ',' ',' ',' ','|',' ','|',' ',' ',' ',' ',' ',' ',' ','|',' ','|'},//48
                {'|','*','|',' ',' ',' ',' ',' ',' ',' ','|','*','|',' ',' ',' ',' ',' ',' ',' ','|','*','|',' ','|','*','|',' ',' ',' ',' ',' ',' ',' ','|','*','|',' ',' ',' ',' ',' ',' ',' ','|','*','|'},//49
                {'|',' ','|',' ',' ',' ',' ',' ',' ',' ','|',' ','|',' ',' ',' ',' ',' ',' ',' ','|',' ','|',' ','|',' ','|',' ',' ',' ',' ',' ',' ',' ','|',' ','|',' ',' ',' ',' ',' ',' ',' ','|',' ','|'},//50
                {'|','Ж','|',' ',' ',' ',' ',' ',' ',' ','|','*','|',' ',' ',' ',' ',' ',' ',' ','|','*','|',' ','|','*','|',' ',' ',' ',' ',' ',' ',' ','|','*','|',' ',' ',' ',' ',' ',' ',' ','|','Ж','|'},//51
                {'|',' ','+','-','-','-','-','-','-','-','+',' ','+','-','-','-','-','-','-','-','+',' ','|',' ','|',' ','+','-','-','-','-','-','-','-','+',' ','+','-','-','-','-','-','-','-','+',' ','|'},//52
                {'|','*',' ','*',' ','*',' ','*',' ','*',' ','*',' ','*',' ','*',' ','*',' ','*',' ','*','|',' ','|','*',' ','*',' ','*',' ','*',' ','*',' ','*',' ','*',' ','*',' ','*',' ','*',' ','*','|'},//53
                {'+','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','+',' ','+','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','+'},//54
               // 0   1   2   3   4   5   6   7   8   9  10  11  12  13  14  15  16  17  18  19  20  21  22  23  24  25  26  27  28  29  30  31  32  33  34  35  36  37  38  39  40  41  42  43  44  45  46   
            };
            #endregion

            string moove = "mooveUp", tryMoove;




            while (true)
            {
                string s = "";
                Console.Clear();
                map[yPacman, xPacman] = '☺';
                map[yEnemy1, xEnemy1] = '☻';
                Console.WriteLine("Score/Очки = {0}", score);
                Console.WriteLine("Time/Время = {0} seconds", time / 1000);
                for (int i = 0; i < 55; i++)
                {
                    for (int j = 0; j < 47; j++)
                    {
                        s += map[i, j];
                    }
                    s += '\n';
                }

                Console.Write(s);

                #region direction/направление





                if (Console.KeyAvailable)
                {

                    var way = Console.ReadKey(true).Key;

                    if (way == ConsoleKey.LeftArrow)
                    {
                        tryMoove = "mooveLeft";
                        if (map[yPacman, xPacman - 1] != '|' && map[yPacman, xPacman - 1] != '+' && map[yPacman, xPacman - 1] != '-')
                            moove = tryMoove;

                    }
                    else if (way == ConsoleKey.RightArrow)
                    {
                        tryMoove = "mooveRigth";
                        if (map[yPacman, xPacman + 1] != '|' && map[yPacman, xPacman + 1] != '+' && map[yPacman, xPacman + 1] != '-')
                            moove = tryMoove;

                    }
                    else if (way == ConsoleKey.UpArrow)
                    {
                        tryMoove = "mooveUp";
                        if (map[yPacman - 1, xPacman] != '|' && map[yPacman - 1, xPacman] != '+' && map[yPacman - 1, xPacman] != '-')
                            moove = tryMoove;

                    }
                    else if (way == ConsoleKey.DownArrow)
                    {
                        tryMoove = "mooveDown";
                        if (map[yPacman + 1, xPacman] != '|' && map[yPacman + 1, xPacman] != '+' && map[yPacman + 1, xPacman] != '-')
                            moove = tryMoove;

                    }
                }

                if (moove == "mooveLeft")
                {
                    if (map[yPacman, xPacman - 1] != '|' && map[yPacman, xPacman - 1] != '+' && map[yPacman, xPacman - 1] != '-')
                    {
                        if (map[yPacman, xPacman - 1] == '*')
                        {
                            score += 100;
                        }
                        else if (map[yPacman, xPacman - 1] == 'Ж')
                        {
                            score += 1000;
                        }
                        map[yPacman, xPacman] = ' ';
                        xPacman = xPacman - 1;
                    }
                }
                else if (moove == "mooveRigth")
                {
                    if (map[yPacman, xPacman + 1] != '|' && map[yPacman, xPacman + 1] != '+' && map[yPacman, xPacman + 1] != '-')
                    {
                        if (map[yPacman, xPacman + 1] == '*')
                        {
                            score += 100;
                        }
                        else if (map[yPacman, xPacman - 1] == 'Ж')
                        {
                            score += 1000;
                        }
                        map[yPacman, xPacman] = ' ';
                        xPacman = xPacman + 1;
                    }
                }
                else if (moove == "mooveUp")
                {
                    if (map[yPacman - 1, xPacman] != '|' && map[yPacman - 1, xPacman] != '+' && map[yPacman - 1, xPacman] != '-')
                    {
                        if (map[yPacman - 1, xPacman] == '*')
                        {
                            score += 100;
                        }
                        else if (map[yPacman - 1, xPacman] == 'Ж')
                        {
                            score += 1000;
                        }
                        map[yPacman, xPacman] = ' ';
                        yPacman = yPacman - 1;
                    }
                }
                else if (moove == "mooveDown")
                {
                    if (map[yPacman + 1, xPacman] != '|' && map[yPacman + 1, xPacman] != '+' && map[yPacman + 1, xPacman] != '-')
                    {
                        if (map[yPacman + 1, xPacman] == '*')
                        {
                            score += 100;
                        }
                        else if (map[yPacman + 1, xPacman] == 'Ж')
                        {
                            score += 1000;
                        }
                        map[yPacman, xPacman] = ' ';
                        yPacman = yPacman + 1;
                    }
                }
                if (yPacman == 27 && xPacman == 46)
                {
                    xPacman = 1;
                }

                if (yPacman == 27 && xPacman == 0)
                {
                    xPacman = 45;
                }
                #endregion

                Thread.Sleep(delay);
                time = time + delay;
                #region Enemy/Враги
                if (time == 5000)
                {
                    map[yEnemy1, xEnemy1] = ' ';
                    yEnemy1 = yEnemy1 - 2;
                }
                if (time > 5000)
                {
                    #region enemy try move to left
                    if (moove == "mooveLeft")
                    {
                        if (map[yEnemy1, xEnemy1 - 1] != '|' && map[yEnemy1, xEnemy1 - 1] != '+' && map[yEnemy1, xEnemy1 - 1] != '-')
                        {
                            if (map[yEnemy1, xEnemy1 - 1] == '*')
                            {
                                enemy1Score = '*';
                            }
                            else if (map[yEnemy1, xEnemy1 - 1] == 'Ж')
                            {
                                enemy1Score = 'Ж';
                            }
                            else if (map[yEnemy1, xEnemy1 - 1] == ' ')
                            {
                                enemy1Score = ' ';
                            }
                            map[yEnemy1, xEnemy1] = ' ';//////////////////////////
                            xEnemy1--;
                        }
                        else
                        {
                            if (yEnemy1 - 1 ==  ' ' )
                            {
                                map[yEnemy1, xEnemy1] = ' ';
                                yEnemy1--;
                            }
                            else if (xEnemy1 + 1 == ' ')
                            {
                                map[yEnemy1, xEnemy1] = ' ';
                                xEnemy1++;
                            }
                            else if (yEnemy1 + 1 == ' ')
                            {
                                map[yEnemy1, xEnemy1] = ' ';
                                yEnemy1++;
                            }

                        }
                    }
                    #endregion
                    #region  enemy try move to rigth
                    else if (moove == "mooveRigth")
                    {
                        if (map[yEnemy1, xEnemy1 + 1] != '|' && map[yEnemy1, xEnemy1 + 1] != '+' && map[yEnemy1, xEnemy1 + 1] != '-')
                        {
                            if (map[yEnemy1, xEnemy1 + 1] == '*')
                            {
                                enemy1Score = '*';
                            }
                            else if (map[yEnemy1, xEnemy1 + 1] == 'Ж')
                            {
                                enemy1Score = 'Ж';
                            }
                            else if (map[yEnemy1, xEnemy1 + 1] == ' ')
                            {
                                enemy1Score = ' ';
                            }
                            map[yEnemy1, xEnemy1] = ' '; /////////////////////
                            xEnemy1++;
                        }
                        else
                        {
                            if (xEnemy1 - 1 == ' ')
                            {
                                map[yEnemy1, xEnemy1] = ' ';
                                xEnemy1--;
                            }
                            else if (xEnemy1 - 1 == ' ')
                            {
                                map[yEnemy1, xEnemy1] = ' ';
                                xEnemy1--;
                            }
                            
                            else if (yEnemy1 - 1 == ' ')
                            {
                                map[yEnemy1, xEnemy1] = ' ';
                                yEnemy1--;
                            }

                        }
                    }
                    #endregion
                    #region enemy try move to up
                    else if (moove == "mooveUp")
                    {
                        if (map[yEnemy1 - 1, xEnemy1] != '|' && map[yEnemy1 - 1, xEnemy1] != '+' && map[yEnemy1 - 1, xEnemy1] != '-')
                        {
                            if (map[yEnemy1 - 1, xEnemy1] == '*')
                            {
                                enemy1Score = '*';
                            }
                            else if (map[yEnemy1 - 1, xEnemy1] == 'Ж')
                            {
                                enemy1Score = 'Ж';
                            }
                            else if (map[yEnemy1 - 1, xEnemy1] == ' ')
                            {
                                enemy1Score = ' ';
                            }
                            map[yEnemy1, xEnemy1] = ' '; //////////////////////////
                            yEnemy1--;
                        }
                        else
                        {
                            if (xEnemy1 + 1 == ' ')
                            {
                                map[yEnemy1, xEnemy1] = ' ';
                                xEnemy1++;
                            }
                            else if (yEnemy1 + 1 == ' ')
                            {
                                map[yEnemy1, xEnemy1] = ' ';
                                yEnemy1++;
                            }

                            else if (xEnemy1 - 1 == ' ')
                            {
                                map[yEnemy1, xEnemy1] = ' ';
                                xEnemy1--;
                            }

                        }
                    }
                    #endregion
                    #region enemy try move to down
                    else if (moove == "mooveDown")
                    {
                        if (map[yEnemy1 + 1, xEnemy1] != '|' && map[yEnemy1 + 1, xEnemy1] != '+' && map[yEnemy1 + 1, xEnemy1] != '-')
                        {
                            if (map[yEnemy1 + 1, xEnemy1] == '*')
                            {
                                enemy1Score = '*';
                            }
                            else if (map[yEnemy1 + 1, xEnemy1] == 'Ж')
                            {
                                enemy1Score = 'Ж';
                            }
                            else if (map[yEnemy1 + 1, xEnemy1] == ' ')
                            {
                                enemy1Score = ' ';
                            }
                            map[yEnemy1, xEnemy1] = ' '; //////////////////
                            yEnemy1++;
                        }
                        else
                        {
                            if (xEnemy1 - 1 == ' ')
                            {
                                map[yEnemy1, xEnemy1] = ' ';
                                xEnemy1--;
                            }
                            else if (yEnemy1 - 1 == ' ')
                            {
                                map[yEnemy1, xEnemy1] = ' ';
                                yEnemy1--;
                            }

                            else if (xEnemy1 + 1 == ' ')
                            {
                                map[yEnemy1, xEnemy1] = ' ';
                                xEnemy1++;
                            }

                        }
                    }
                    #endregion
                }   
                #endregion
                



            }
        }
    }
}


