using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace PacMan
{
    class Program
    {
        static int[] Enemy (int shift,ref string enemyMove,int xEnemy,int yEnemy,int xPac,int yPac, string pacManMove,char[,] map,ref char[,] enemyScoreCoordinate) // принимаем значение направления движения
                                                                                                                                             // координаты врага и пакмена
        {
            string enemyReMove = " "; //проверка обратного направления
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
                enemyReMove = "moveUp";
            }


            //Логика поиска пути на поворотах
            #region control point/контрольные точки 
            #region move Left
            if (enemyMove == "moveLeft")
            {

                if (map[yEnemy, xEnemy - 1] == '+' || map[yEnemy, xEnemy - 1] == '|' || //поиск тупика
                    map[yEnemy, xEnemy - 1] == '-')
                {
                    if (map[yEnemy - 1, xEnemy] != '+' && map[yEnemy - 1, xEnemy] != '|' && //поиск свободного поворота
                        map[yEnemy - 1, xEnemy] != '-')
                    {
                        up = true;
                    }
                    if (map[yEnemy + 1, xEnemy] != '+' && map[yEnemy + 1, xEnemy] != '|' && //поиск свободного поворота
                        map[yEnemy + 1, xEnemy] != '-')
                    {
                        down = true;
                    }
                    if (yPac >= yEnemy)  //смена направления движения
                    {
                        if (down == true)
                        {
                            enemyMove = "moveDown";
                        }
                        else if (up == true) //смена направления движения
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
            //разворот при заходе в зону сквозного прохода 
            #region Разворот

            if (map[yEnemy, xEnemy - 1] == '<')
            {
                enemyMove = enemyReMove;
            }
            if (map[yEnemy, xEnemy + 1] == '>')
            {
                enemyMove = enemyReMove;
            }
            #endregion



            //подсчет действий если направление движения уже определено

            if (enemyMove == "moveLeft")
            #region смещение влево
            {


                if (map[yEnemy, xEnemy - 1] == '*' || map[yEnemy, xEnemy - 1] == 'Ж' || map[yEnemy, xEnemy - 1] == ' ')   //проверка что находится в направлении движения
                {
                    enemyScoreCoordinate[yEnemy, xEnemy - 1] = map[yEnemy, xEnemy - 1]; //записываем знак перед собой в отдельный массив
                }
                
                Console.SetCursorPosition(xEnemy, yEnemy + shift);  // отрисовка того что было на месте врага до того как он наступил сюда
                if (enemyScoreCoordinate[yEnemy,xEnemy] == '*')
                {
                    Console.WriteLine("*");
                }
                else if (enemyScoreCoordinate[yEnemy, xEnemy] == 'Ж')
                {
                    Console.WriteLine("Ж");
                }
                else if (enemyScoreCoordinate[yEnemy, xEnemy] == ' ')
                {
                    Console.WriteLine(" ");
                }
                xEnemy--;                                                   //смещение врага по направлению движения
                Console.SetCursorPosition(xEnemy, yEnemy + shift);          // отрисовка врага в новой позиции
                Console.WriteLine("☻");
            }
#endregion
            else if (enemyMove == "moveRigth")
            #region
            {

                if (map[yEnemy, xEnemy + 1] == '*' || map[yEnemy, xEnemy + 1] == 'Ж' || map[yEnemy, xEnemy + 1] == ' ')
                {
                    enemyScoreCoordinate[yEnemy, xEnemy + 1] = map[yEnemy, xEnemy + 1];
                }
                //map[yEnemy, xEnemy] = enemyScore;
                Console.SetCursorPosition(xEnemy, yEnemy + shift);
                if (enemyScoreCoordinate[yEnemy, xEnemy] == '*')
                {
                    Console.WriteLine("*");
                }
                else if (enemyScoreCoordinate[yEnemy, xEnemy] == 'Ж')
                {
                    Console.WriteLine("Ж");
                }
                else if (enemyScoreCoordinate[yEnemy, xEnemy] == ' ')
                {
                    Console.WriteLine(" ");
                }
                xEnemy++;
                Console.SetCursorPosition(xEnemy, yEnemy + shift);
                Console.WriteLine("☻");
            }
            else if (enemyMove == "moveUp")
            {


                if (map[yEnemy - 1, xEnemy] == '*' || map[yEnemy - 1, xEnemy] == 'Ж' || map[yEnemy - 1, xEnemy] == ' ')
                {
                    enemyScoreCoordinate[yEnemy - 1, xEnemy] = map[yEnemy - 1, xEnemy];
                }
                //map[yEnemy, xEnemy] = enemyScore;
                Console.SetCursorPosition(xEnemy, yEnemy + shift);
                if (enemyScoreCoordinate[yEnemy, xEnemy] == '*')
                {
                    Console.WriteLine("*");
                }
                else if (enemyScoreCoordinate[yEnemy, xEnemy] == 'Ж')
                {
                    Console.WriteLine("Ж");
                }
                else if (enemyScoreCoordinate[yEnemy, xEnemy] == ' ')
                {
                    Console.WriteLine(" ");
                }
                yEnemy--;
                Console.SetCursorPosition(xEnemy, yEnemy + shift);
                Console.WriteLine("☻");
            }
            else if (enemyMove == "moveDown")
            {


                if (map[yEnemy + 1, xEnemy] == '*' || map[yEnemy + 1, xEnemy] == 'Ж' || map[yEnemy + 1, xEnemy] == ' ')
                {
                    enemyScoreCoordinate[yEnemy + 1, xEnemy] = map[yEnemy + 1, xEnemy];
                }
               //map[yEnemy, xEnemy] = enemyScore;
                Console.SetCursorPosition(xEnemy, yEnemy + shift);
                if (enemyScoreCoordinate[yEnemy, xEnemy] == '*')
                {
                    Console.WriteLine("*");
                }
                else if (enemyScoreCoordinate[yEnemy, xEnemy] == 'Ж')
                {
                    Console.WriteLine("Ж");
                }
                else if (enemyScoreCoordinate[yEnemy, xEnemy] == ' ')
                {
                    Console.WriteLine(" ");
                }
                yEnemy++;
                Console.SetCursorPosition(xEnemy, yEnemy + shift);
                Console.WriteLine("☻");
            }
            
            coordinates[0] = (yEnemy);
            coordinates[1] = (xEnemy);
            return coordinates;
        }

        //_________________________________________________________________________________________________________________________________________________________________________
        static void Main(string[] args)
        {
            const  int shift = 2;
            Console.SetWindowSize(50, 60);
           
            char[,] enemyScoreCoordinate = new char[55, 47]; //таблица записывает показания куда идет враг, чтобы не потерять * и Ж  
            for (int i = 0; i < 55; i++)
            {
                for (int j = 0; j < 47; j++)
                {
                    enemyScoreCoordinate[i, j] = ' ';
                }
            }
            string s = "";
            int xPacman = 23, yPacman = 45;  //coordinates pacman/координаты Пакмена
            
            int xEnemy1 = 23, yEnemy1 = 21; //coordinates enemy #1/координаты врага №1
            
            int xEnemy2 = 21, yEnemy2 = 21;  //coordinates enemy #2/координаты врага №2

            int xEnemy3 = 25, yEnemy3 = 21;  //coordinates enemy #2/координаты врага №2
            
            string enemy1move = "moveLeft";                // направление движения врага
            string enemy2move = "moveRigth";
            string enemy3move = "moveLeft"; 
           
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
            for (int i = 0; i < 55; i++)
            {
                for (int j = 0; j < 47; j++)
                {
                    s += map[i, j];
                }
                s += '\n';
            }
            Console.SetCursorPosition(0, shift);
            Console.Write(s);
            Console.SetCursorPosition(xEnemy1, yEnemy1 + shift);
            Console.WriteLine("☻");
            Console.SetCursorPosition(xEnemy2, yEnemy2 + shift);
            Console.WriteLine("☻");
            Console.SetCursorPosition(xEnemy3, yEnemy3 + shift);
            Console.WriteLine("☻");





            while (true)
            {
                
                
                
               
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Score/Очки = {0}", score);
                Console.SetCursorPosition(0, 1);
                Console.WriteLine("Time/Время = {0} seconds", time / 1000);
                Console.SetCursorPosition(xPacman, yPacman + shift);
                Console.WriteLine("☺");
                

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
                        
                        Console.SetCursorPosition(xPacman, yPacman + shift);
                        Console.WriteLine(" ");
                        xPacman--;
                        
                        Console.SetCursorPosition(xPacman, yPacman + shift);
                        Console.WriteLine("☺");
                        
                        if (map[yPacman, xPacman] == '<')
                        {
                            Console.SetCursorPosition(xPacman, yPacman + shift);
                            Console.WriteLine("<");
                        }
                        
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
                        
                        Console.SetCursorPosition(xPacman, yPacman + shift);
                        Console.WriteLine(" ");
                        xPacman++;
                        Console.SetCursorPosition(xPacman, yPacman + shift);
                        Console.WriteLine("☺");
                        if (map[yPacman, xPacman] == '>')
                        {
                            Console.SetCursorPosition(xPacman, yPacman + shift);
                            Console.WriteLine(">");
                        }
                        
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
                       
                        Console.SetCursorPosition(xPacman, yPacman + shift);
                        Console.WriteLine(" ");
                        yPacman--;
                        Console.SetCursorPosition(xPacman, yPacman + shift);
                        Console.WriteLine("☺");
                        
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
                        
                        Console.SetCursorPosition(xPacman, yPacman + shift);
                        Console.WriteLine(" ");
                        yPacman++;
                        Console.SetCursorPosition(xPacman, yPacman + shift);
                        Console.WriteLine("☺");
                        
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
                    Console.SetCursorPosition(xEnemy1, yEnemy1 + shift);
                    Console.WriteLine(" ");
                    yEnemy1 = yEnemy1 - 2;
                    enemy1move = move;
                }
                if (time > 5000)
                {

                    int[] coordinates = new int[2];
                    coordinates = Enemy(shift,ref enemy1move, xEnemy1, yEnemy1, xPacman, yPacman,move,map,ref enemyScoreCoordinate);
                    map[yEnemy1, xEnemy1] = enemyScoreCoordinate[yEnemy1,xEnemy1];
                    yEnemy1 = coordinates[0];
                    xEnemy1 = coordinates[1];
                }
                #endregion
                #region Enemy #2/Враг №2
                if (time == 10000)
                {
                    map[yEnemy2, xEnemy2] = ' ';
                    Console.SetCursorPosition(xEnemy2, yEnemy2 + shift);
                    Console.WriteLine(" ");
                    yEnemy2 = yEnemy2 - 2;
                    enemy2move = move;
                }
                if (time > 10000)
                {

                    int[] coordinates = new int[2];
                    coordinates = Enemy(shift,ref enemy2move, xEnemy2, yEnemy2, xPacman, yPacman, move, map,ref enemyScoreCoordinate);
                    map[yEnemy2, xEnemy2] = enemyScoreCoordinate[yEnemy2,xEnemy2];
                    yEnemy2 = coordinates[0];
                    xEnemy2 = coordinates[1];
                }
                #endregion
                #region Enemy #2/Враг №3
                if (time == 15000)
                {
                    map[yEnemy3, xEnemy3] = ' ';
                    Console.SetCursorPosition(xEnemy3, yEnemy3 + shift);
                    Console.WriteLine(" ");
                    yEnemy3 = yEnemy3 - 2;
                    enemy3move = move;
                }
                if (time > 15000)
                {

                    int[] coordinates = new int[2];
                    coordinates = Enemy(shift, ref enemy3move, xEnemy3, yEnemy3, xPacman, yPacman, move, map, ref enemyScoreCoordinate);
                    map[yEnemy3, xEnemy3] = enemyScoreCoordinate[yEnemy3, xEnemy3];
                    yEnemy3 = coordinates[0];
                    xEnemy3 = coordinates[1];
                }
                #endregion
                #endregion
                if ((yEnemy1 == yPacman && xEnemy1 == xPacman) || (yEnemy2 == yPacman && xEnemy2 == xPacman) ||
                    (yEnemy3 == yPacman && xEnemy3 == xPacman))
                {
                    Console.Clear();
                    Console.SetCursorPosition(18,30);
                    Console.WriteLine("YOU ARE DEAD!!!");
                    Thread.Sleep(9999999);

                }


            }
        }
    }
}


