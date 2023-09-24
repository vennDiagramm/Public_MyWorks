import java.util.Scanner;

class HelloWorld
{
        public static void main(String[] args){    
            System.out.println("Hello!");
            
            //ReadLine || Reading user input
            Scanner Reader = new Scanner(System.in);

            //Take user input
            System.out.print("What is length of your rectangle? ");
            int length = Reader.nextInt();

            System.out.print("What is the width of your rectangle? ");
            int width = Reader.nextInt();

            //Calculate Perimeter & Area
            int Perimeter = 2 * (length + width);
            System.out.println("Perimeter: " + Perimeter);

            int Area = length * width;
            System.out.println("Area: " + Area);

            // ;))
            System.out.println("Thank You! :D");
        }
}