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
        static int[] Enemy (ref string enemyMove,int xEnemy,int yEnemy,int xPac,int yPac, string pacManMove,ref char enemyScore,char[,] map) // принимаем значение направления движения
                                                                                                                                             // координаты врага и пакмена
        {
            string enemyReMove = " ";
            bool up = false, down = false, left = false, rigth = false; //создание переменных для проверки свободно по сторонам
            int[] coordinates = new int[2]; //таблица для возврата значения координат
            if (enemyMove == "moveLeft")
            {
                enemyReMove = "moveRigth";
            }
            else if (enemyMove == "moveRigth")
            {
                enemyReMove = "moveLeft";
            }
            else if (enemyMove == "moveUp")
            {
                enemyReMove = "moveDown";
            }
            else if (enemyMove == "moveDown")
            {
                enemyReMove = "moveRigth";
            }


           
            #region control point/контрольные точки
            //if ((xEnemy == 1 && yEnemy == 9) || (xEnemy == 1 && yEnemy == 45) || (xEnemy == 11 && yEnemy == 1) ||
            //   (xEnemy == 11 && yEnemy == 9) || (xEnemy == 11 && yEnemy == 15) || (xEnemy == 11 && yEnemy == 27) ||
            //   (xEnemy == 11 && yEnemy == 39) || (xEnemy == 11 && yEnemy == 45) || (xEnemy == 11 && yEnemy == 53) ||
            //   (xEnemy == 15 && yEnemy == 9) || (xEnemy == 15 && yEnemy == 27) || (xEnemy == 15 && yEnemy == 45) ||
            //   (xEnemy == 21 && yEnemy == 9) || (xEnemy == 21 && yEnemy == 19) || (xEnemy == 21 && yEnemy == 35) ||
            //   (xEnemy == 21 && yEnemy == 45) || (xEnemy == 25 && yEnemy == 9) || (xEnemy == 25 && yEnemy == 19) ||
            //   (xEnemy == 25 && yEnemy == 35) || (xEnemy == 25 && yEnemy == 45) || (xEnemy == 31 && yEnemy == 9) ||
            //   (xEnemy == 31 && yEnemy == 27) || (xEnemy == 31 && yEnemy == 45) || (xEnemy == 35 && yEnemy == 1) ||
            //   (xEnemy == 35 && yEnemy == 9) || (xEnemy == 35 && yEnemy == 15) || (xEnemy == 35 && yEnemy == 27) ||
            //   (xEnemy == 35 && yEnemy == 39) || (xEnemy == 35 && yEnemy == 45) || (xEnemy == 35 && yEnemy == 53) ||
            //   (xEnemy == 35 && yEnemy == 9) || (xEnemy == 45 && yEnemy == 45))
            #region move Left
            if (enemyMove == "moveLeft")
            {

                if (map[yEnemy, xEnemy - 1] == '+' || map[yEnemy, xEnemy - 1] == '|' || //поиск тупика
                    map[yEnemy, xEnemy - 1] == '-')
                {
                    if (map[yEnemy - 1, xEnemy] != '+' && map[yEnemy - 1, xEnemy] != '|' &&
                        map[yEnemy - 1, xEnemy] != '-')
                    {
                        up = true;
                    }
                    if (map[yEnemy + 1, xEnemy] != '+' && map[yEnemy + 1, xEnemy] != '|' &&
                        map[yEnemy + 1, xEnemy] != '-')
                    {
                        down = true;
                    }
                    if (yPac >= yEnemy)
                    {
                        if (down == true)
                        {
                            enemyMove = "moveDown";
                        }
                        else if (up == true)
                        {
                            enemyMove = "moveUp";
                        }
                    }
                    else
                    {
                        if (up == true)
                        {
                            enemyMove = "moveUp";
                        }
                        else if (down == true)
                        {
                            enemyMove = "moveDown";
                        }
                    }

                }
                else if (map[yEnemy + 1, xEnemy] == ' ' || map[yEnemy - 1, xEnemy] == ' ') //если тупика небыло
                {


                    if (yEnemy > yPac && map[yEnemy - 1, xEnemy] == ' ')
                    {
                        enemyMove = "moveUp";
                    }
                    else if (yEnemy <= yPac && map[yEnemy + 1, xEnemy] == ' ')
                    {
                        enemyMove = "moveDown";
                    }
                    else if (xEnemy >= xPac && map[yEnemy, xEnemy - 1] == ' ')
                    {
                        enemyMove = "moveLeft";
                    }
                }
            }

            #endregion
            #region move Rigth
            else if (enemyMove == "moveRigth")
            {

                if (map[yEnemy, xEnemy + 1] == '+' || map[yEnemy, xEnemy + 1] == '|' || //поиск тупика
                    map[yEnemy, xEnemy + 1] == '-')
                {
                    if (map[yEnemy - 1, xEnemy] != '+' && map[yEnemy - 1, xEnemy] != '|' &&
                       map[yEnemy - 1, xEnemy] != '-')
                    {
                        up = true;
                    }
                    if (map[yEnemy + 1, xEnemy] != '+' && map[yEnemy + 1, xEnemy] != '|' &&
                        map[yEnemy + 1, xEnemy] != '-')
                    {
                        down = true;
                    }
                    if (yPac >= yEnemy)
                    {
                        if (down == true)
                        {
                            enemyMove = "moveDown";
                        }
                        else if (up == true)
                        {
                            enemyMove = "moveUp";
                        }
                    }
                    else
                    {
                        if (up == true)
                        {
                            enemyMove = "moveUp";
                        }
                        else if (down == true)
                        {
                            enemyMove = "moveDown";
                        }
                    }
                }
                else if (map[yEnemy + 1, xEnemy] == ' ' || map[yEnemy - 1, xEnemy] == ' ') //если тупика небыло
                {


                    if (yEnemy > yPac && map[yEnemy - 1, xEnemy] == ' ')
                    {
                        enemyMove = "moveUp";
                    }
                    else if (yEnemy <= yPac && map[yEnemy + 1, xEnemy] == ' ')
                    {
                        enemyMove = "moveDown";
                    }
                    else if (xEnemy >= xPac && map[yEnemy, xEnemy + 1] == ' ')
                    {
                        enemyMove = "moveRigth";
                    }
                }

            }
            #endregion
            #region move UP
            else if (enemyMove == "moveUp")
            {
                if (map[yEnemy - 1, xEnemy] == '+' || map[yEnemy - 1, xEnemy] == '|' || //поиск тупика
                   map[yEnemy - 1, xEnemy] == '-')
                {
                    if (map[yEnemy, xEnemy - 1] != '+' && map[yEnemy, xEnemy - 1] != '|' &&
                        map[yEnemy, xEnemy - 1] != '-')
                    {
                        left = true;
                    }
                    if (map[yEnemy, xEnemy + 1] != '+' && map[yEnemy, xEnemy + 1] != '|' &&
                        map[yEnemy, xEnemy + 1] != '-')
                    {
                        rigth = true;
                    }
                    if (xPac >= xEnemy)
                    {
                        if (rigth == true)
                        {
                            enemyMove = "moveRigth";
                        }
                        else if (left == true)
                        {
                            enemyMove = "moveLeft";
                        }
                    }
                    else
                    {
                        if (left == true)
                        {
                            enemyMove = "moveLeft";
                        }
                        else if (rigth == true)
                        {
                            enemyMove = "moveRigth";
                        }
                    }

                }
                else if (map[yEnemy, xEnemy + 1] == ' ' || map[yEnemy, xEnemy - 1] == ' ') //если тупика небыло
                {

                    if (xEnemy >= xPac && map[yEnemy, xEnemy - 1] == ' ')
                    {
                        enemyMove = "moveLeft";
                    }
                    else if (xEnemy < xPac && map[yEnemy, xEnemy + 1] == ' ')
                    {
                        enemyMove = "moveRigth";
                    }
                    else if (yEnemy <= yPac && map[yEnemy - 1, xEnemy] == ' ')
                    {
                        enemyMove = "moveUp";
                    }



                }
            }
            #endregion
            #region move Down
            else if (enemyMove == "moveDown")
            {
                if (map[yEnemy + 1, xEnemy] == '+' || map[yEnemy + 1, xEnemy] == '|' || //поиск тупика
                   map[yEnemy + 1, xEnemy] == '-')
                {
                    if (map[yEnemy, xEnemy + 1] != '+' && map[yEnemy, xEnemy + 1] != '|' &&
                        map[yEnemy, xEnemy + 1] != '-')
                    {
                        rigth = true;
                    }
                    if (map[yEnemy, xEnemy - 1] != '+' && map[yEnemy, xEnemy - 1] != '|' &&
                        map[yEnemy, xEnemy - 1] != '-')
                    {
                        left = true;
                    }
                    if (xPac >= xEnemy)
                    {
                        if (rigth == true)
                        {
                            enemyMove = "moveRigth";
                        }
                        else if (left == true)
                        {
                            enemyMove = "moveLeft";
                        }
                    }
                    else
                    {
                        if (left == true)
                        {
                            enemyMove = "moveLeft";
                        }
                        else if (rigth == true)
                        {
                            enemyMove = "moveRigth";
                        }
                    }

                }
                else if (map[yEnemy, xEnemy + 1] == ' ' || map[yEnemy, xEnemy - 1] == ' ') //если тупика небыло
                {


                    if (xEnemy >= xPac && map[yEnemy, xEnemy - 1] == ' ')
                    {
                        enemyMove = "moveLeft";
                    }
                    else if (xEnemy < xPac && map[yEnemy, xEnemy + 1] == ' ')
                    {
                        enemyMove = "moveRigth";
                    }
                    else if (yEnemy <= yPac && map[yEnemy + 1, xEnemy] == ' ')
                    {
                        enemyMove = "moveDown";
                    }


                }

            }
            #endregion
            
           
            
            #endregion



            if (map[yEnemy, xEnemy - 1] == '<')
            {
                enemyMove = "moveRigth";
            }
            if (map[yEnemy, xEnemy + 1] == '>')
            {
                enemyMove = "moveLeft";
            }
            
           
            if (enemyMove == "moveLeft")
            {
                xEnemy--;
                if (map[yEnemy,xEnemy - 1] == '*')
                {
                    enemyScore = '*';
                }
                else if (map[yEnemy, xEnemy - 1] == 'Ж')
                {
                    enemyScore = 'Ж';
                }
                else
                {
                    enemyScore = ' ';
                }
                
            }
            else if (enemyMove == "moveRigth")
            {
                xEnemy++;
                if (map[yEnemy, xEnemy + 1] == '*')
                {
                    enemyScore = '*';
                }
                else if (map[yEnemy, xEnemy + 1] == 'Ж')
                {
                    enemyScore = 'Ж';
                }
                else
                {
                    enemyScore = ' ';
                }
                
            }
            else if (enemyMove == "moveUp")
            {
                yEnemy--;
                if (map[yEnemy - 1, xEnemy] == '*')
                {
                    enemyScore = '*';
                }
                else if (map[yEnemy - 1, xEnemy] == 'Ж')
                {
                    enemyScore = 'Ж';
                }
                else
                {
                    enemyScore = ' ';
                }
                
            }
            else if (enemyMove == "moveDown")
            {
                yEnemy++;
                if (map[yEnemy + 1, xEnemy] == '*')
                {
                    enemyScore = '*';
                }
                else if (map[yEnemy + 1, xEnemy] == 'Ж')
                {
                    enemyScore = 'Ж';
                }
                else
                {
                    enemyScore = ' ';
                }
                
            }
            
            coordinates[0] = (yEnemy);
            coordinates[1] = (xEnemy);
            return coordinates;
        }

        //_________________________________________________________________________________________________________________________________________________________________________
        static void Main(string[] args)
        {

            int xPacman = 23, yPacman = 45;  //coordinates pacman/координаты Пакмена
            int xEnemy1 = 22, yEnemy1 = 21; //coordinates enemy #1/координаты врага №1
            int xEnemy2 = 20, yEnemy2 = 21;  //coordinates enemy #2/координаты врага №2
            char enemy1Score = ' ';               //наступил ли враг на *?
            char enemy2Score = ' ';
            string enemy1move = "moveLeft";                // направление движения врага
            string enemy2move = "moveRigth";
           
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

            string move = "moveUp", tryMove;




            while (true)
            {
                string s = "";
                Console.Clear();
                map[yPacman, xPacman] = '☺';
                map[yEnemy1, xEnemy1] = '☻';
                map[yEnemy2, xEnemy2] = '†';
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
                        tryMove = "moveLeft";
                        if (map[yPacman, xPacman - 1] != '|' && map[yPacman, xPacman - 1] != '+' && map[yPacman, xPacman - 1] != '-')
                            move = tryMove;

                    }
                    else if (way == ConsoleKey.RightArrow)
                    {
                        tryMove = "moveRigth";
                        if (map[yPacman, xPacman + 1] != '|' && map[yPacman, xPacman + 1] != '+' && map[yPacman, xPacman + 1] != '-')
                            move = tryMove;

                    }
                    else if (way == ConsoleKey.UpArrow)
                    {
                        tryMove = "moveUp";
                        if (map[yPacman - 1, xPacman] != '|' && map[yPacman - 1, xPacman] != '+' && map[yPacman - 1, xPacman] != '-')
                            move = tryMove;

                    }
                    else if (way == ConsoleKey.DownArrow)
                    {
                        tryMove = "moveDown";
                        if (map[yPacman + 1, xPacman] != '|' && map[yPacman + 1, xPacman] != '+' && map[yPacman + 1, xPacman] != '-')
                            move = tryMove;

                    }
                }

                if (move == "moveLeft")
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
                else if (move == "moveRigth")
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
                else if (move == "moveUp")
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
                else if (move == "moveDown")
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
                #region Enemy #1/Враг №1
                if (time == 5000)
                {
                    map[yEnemy1, xEnemy1] = ' ';
                    yEnemy1 = yEnemy1 - 2;
                    enemy1move = move;
                }
                if (time > 5000)
                {

                    int[] coordinates = new int[2];
                    coordinates = Enemy(ref enemy1move, xEnemy1, yEnemy1, xPacman, yPacman,move,ref enemy1Score,map);
                    map[yEnemy1, xEnemy1] = enemy1Score;
                    yEnemy1 = coordinates[0];
                    xEnemy1 = coordinates[1];
                }
                #endregion
                #region Enemy #2/Враг №2
                if (time == 10000)
                {
                    map[yEnemy2, xEnemy2] = ' ';
                    yEnemy2 = yEnemy2 - 2;
                    enemy1move = move;
                }
                if (time > 10000)
                {

                    int[] coordinates = new int[2];
                    coordinates = Enemy(ref enemy2move, xEnemy2, yEnemy2, xPacman, yPacman, move, ref enemy2Score, map);
                    map[yEnemy2, xEnemy2] = enemy2Score;
                    yEnemy2 = coordinates[0];
                    xEnemy2 = coordinates[1];
                }
                #endregion
                #endregion
                if (((yEnemy1 == yPacman) && (xEnemy1 == xPacman)) ||  ((yEnemy2 == yPacman) && (xEnemy2 == xPacman)))
                {
                   // Console.Clear();
                    Console.WriteLine("You Loose");
                    Console.ReadKey();
                    break;
                }


            }
        }
    }
}


