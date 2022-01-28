// Exercise 8.21: TurtleGraphics.cs
// Drawing turtle graphics based on turtle commands.
using System;

public class TurtleGraphics
{
   const int MAXCOMMANDS = 100; // maximum size of command array
   const int SIZE = 20; // size of the drawing area

   static int[,] floor; // array representing the floor
   static int[,] commandArray; // list of commands

   static int count; // the current number of commands
   static int xPos; // the x Position of the turtle
   static int yPos; // the y Position of the turtle

   // enters the commands for the turtle graphics
   public static void Main(string[] args)
   {
      count = 0;
      commandArray = new int[MAXCOMMANDS, 2];
      floor = new int[SIZE, SIZE];

      Console.Write("Enter command (9 to end input): ");
      int inputCommand = int.Parse(Console.ReadLine());

      while (inputCommand != 9 && count < MAXCOMMANDS)
      {
         commandArray[count, 0] = inputCommand;

         // prompt for forward spaces
         if (inputCommand == 5)
         {
            Console.Write("Enter forward spaces: ");
            commandArray[count, 1] =
               int.Parse(Console.ReadLine());
         } 

         ++count;

         Console.Write("Enter command (9 to end input): ");
         inputCommand = int.Parse(Console.ReadLine());
      } 

      ExecuteCommands();
   } 

   // executes the commands in the command array
   public static void ExecuteCommands()
   {
      int commandNumber = 0; // the current position in the array
      int direction = 0; // the direction the turtle is facing
      int distance = 0; // the distance the turtle will travel
      int command; // the current command
      bool penDown = false; // whether the pen is up or down
      xPos = 0;
      yPos = 0;

      command = commandArray[commandNumber, 0];

      // continue executing commands until either reach the end
      // or reach the max commands
      while (commandNumber < count)
      {
         // determine what command was entered 
         // and perform desired action
         switch (command)
         {
            case 1: // pen up
               penDown = false;
               break;
            case 2: // pen down
               penDown = true;
               break;
            case 3: // turn right
               direction = TurnRight(direction);
               break;
            case 4: // turn left
               direction = TurnLeft(direction);
               break;
            case 5: // move
               distance = commandArray[commandNumber, 1];
               MovePen(penDown, floor, direction, distance);
               break;
            case 6: // display the drawing
               Console.WriteLine("\nThe drawing is:\n");
               PrintArray(floor);
               break;
         } 

         command = commandArray[++commandNumber, 0];
      } 
   }  

   // method to turn turtle to the right
   public static int TurnRight(int d)
   {
      return ++d > 3 ? 0 : d;
   } 

   // method to turn turtle to the left
   public static int TurnLeft(int d)
   {
      return --d < 0 ? 3 : d;
   } 

   // method to move the pen 
   public static void MovePen(bool down, int[,] floor, int dir, int dist)
   {
      int j; // looping variable

      // determine which way to move pen
      switch (dir)
      {
         case 0: // move to right
            for (j = 1; j <= dist && yPos + j < SIZE; j++)
            {
               if (down)
               {
                  floor[xPos, yPos + j] = 1;
               }
            }

            yPos += j - 1;
            break;

         case 1: // move down
            for (j = 1; j <= dist && xPos + j < SIZE; j++)
            {
               if (down) 
               {
                  floor[xPos + j, yPos] = 1;
               }
            }

            xPos += j - 1;
            break;

         case 2: // move to left
            for (j = 1; j <= dist && yPos - j >= 0; j++)
            {
               if (down)
               {
                  floor[xPos, yPos - j] = 1;
               }
            }

            yPos -= j - 1;
            break;

         case 3: // move up
            for (j = 1; j <= dist && xPos - j >= 0; j++)
            {
               if (down)
               {
                  floor[xPos - j, yPos] = 1;
               }
            }

            xPos -= j - 1;
            break;
      } 
   } 

   // method to display array drawing
   public static void PrintArray(int[,] floor)
   {
      // display array
      for (int i = 0; i < SIZE; i++)
      {
         for (int j = 0; j < SIZE; j++)
         {
            Console.Write((floor[i, j] == 1 ? "*" : " "));
         }

         Console.WriteLine();
      } 
   } 
} 



/**************************************************************************
 * (C) Copyright 1992-2017 by Deitel & Associates, Inc. and               *
 * Pearson Education, Inc. All Rights Reserved.                           *
 *                                                                        *
 * DISCLAIMER: The authors and publisher of this book have used their     *
 * best efforts in preparing the book. These efforts include the          *
 * development, research, and testing of the theories and programs        *
 * to determine their effectiveness. The authors and publisher make       *
 * no warranty of any kind, expressed or implied, with regard to these    *
 * programs or to the documentation contained in these books. The authors *
 * and publisher shall not be liable in any event for incidental or       *
 * consequential damages in connection with, or arising out of, the       *
 * furnishing, performance, or use of these programs.                     *
 *************************************************************************/
