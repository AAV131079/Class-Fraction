using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fraction
{
    class Fraction
    {
        // Nominator
        public int Numerator { get; set; }

        // Denominator
        public int Denominator { get; set; }

        // Constructor by default
        public Fraction() 
        {
            // Nominator
            this.Numerator = 0;
            // Denominator
            this.Denominator = 0;
        }

        // Constructor with parameters
        public Fraction(int nominator, int denominator)
        {
            // Nominator
            this.Numerator = nominator;
            // Denominator
            this.Denominator = denominator;
        }

        // Constructor
        public Fraction(int number)
        {
            // Nominator
            this.Numerator = number;
            // Denominator
            this.Denominator = 1;
        }

        // Constructor
        public Fraction(double number)
        {
            // Check number
            if((int)(Math.Round(number, 1) * 10) != 0)
            {
                // Nominator
                this.Numerator = (int)(Math.Round(number, 1) * 10);
                // Denominator
                this.Denominator = 10;
            }
            else
            {
                // Nominator
                this.Numerator = 0;
                // Denominator
                this.Denominator = 0;
            }
        }

        // Overload + (class + class)
        public static Fraction operator + (Fraction first_instance, Fraction second_instance)
        {
            // Create result object
            Fraction result = new Fraction();

            // Check denominators
            if(first_instance.Denominator == second_instance.Denominator)
            {
                // Numerator
                result.Numerator = first_instance.Numerator + second_instance.Numerator;
                // Denominator
                result.Denominator = first_instance.Denominator;
            }
            else
            {
                // Lowest common denominator
                int LowestCommonDenominator = Fraction._FindLowestCommonDenominator(first_instance.Denominator, second_instance.Denominator);
                // Numerator
                result.Numerator = first_instance.Numerator * (LowestCommonDenominator / first_instance.Denominator) + second_instance.Numerator * (LowestCommonDenominator / second_instance.Denominator);
                // Denominator
                result.Denominator = LowestCommonDenominator;
            }

            // Return result object
            return result;
        }

        // Overload + (class + int)
        public static Fraction operator + (Fraction instance, int number)
        {
            // Create result object
            Fraction result = new Fraction();

            // Lowest common denominator
            int LowestCommonDenominator = Fraction._FindLowestCommonDenominator(instance.Denominator, 1);
            // Numerator
            result.Numerator = instance.Numerator * (LowestCommonDenominator / instance.Denominator) + number * LowestCommonDenominator;
            // Denominator
            result.Denominator = LowestCommonDenominator;

            // Return result object
            return result;
        }

        // Overload + (int + class)
        public static Fraction operator +(int number, Fraction instance)
        {
            // Result object
            Fraction result = instance + number;

            // Return result object
            return result;
        }

        // Overload + (class + double)
        public static Fraction operator + (Fraction first_instance, double number)
        {
            // Create result object
            Fraction second_instance = new Fraction(number);

            // Create result object
            Fraction result = new Fraction();

            // Result object
            result = first_instance + second_instance;
            
            // Return result object
            return result;
        }

        // Overload + (double + class)
        public static Fraction operator + (double number, Fraction second_instance)
        {
            // Create result object
            Fraction first_instance = new Fraction(number);

            // Create result object
            Fraction result = new Fraction();

            // Result object
            result = first_instance + second_instance;

            // Return result object
            return result;
        }
        
        // Overload - (class - class)
        public static Fraction operator - (Fraction first_instance, Fraction second_instance)
        {
            // Create result object
            Fraction result = new Fraction();

            // Check denominators
            if (first_instance.Denominator == second_instance.Denominator)
            {
                // Numerator
                result.Numerator = first_instance.Numerator - second_instance.Numerator;
                // Denominator
                result.Denominator = first_instance.Denominator;
            }
            else
            {
                // Lowest common denominator
                int LowestCommonDenominator = Fraction._FindLowestCommonDenominator(first_instance.Denominator, second_instance.Denominator);
                // Numerator
                result.Numerator = first_instance.Numerator * (LowestCommonDenominator / first_instance.Denominator) - second_instance.Numerator * (LowestCommonDenominator / second_instance.Denominator);
                // Denominator
                result.Denominator = LowestCommonDenominator;
            }

            // Return result object
            return result;
        }

        // Overload - (class - int)
        public static Fraction operator - (Fraction instance, int number)
        {
            // Create result object
            Fraction result = new Fraction();

            // Lowest common denominator
            int LowestCommonDenominator = Fraction._FindLowestCommonDenominator(instance.Denominator, 1);
            // Numerator
            result.Numerator = instance.Numerator * (LowestCommonDenominator / instance.Denominator) - number * LowestCommonDenominator;
            // Denominator
            result.Denominator = LowestCommonDenominator;

            // Return result object
            return result;
        }

        // Overload - (int - class)
        public static Fraction operator - (int number, Fraction instance)
        {
            // Result object
            Fraction result = instance - number;

            // Return result object
            return result;
        }

        // Overload - (class - double)
        public static Fraction operator - (Fraction first_instance, double number)
        {
            // Create second_instance object
            Fraction second_instance = new Fraction(number);

            // Create result object
            Fraction result = new Fraction();

            // Result object
            result = first_instance - second_instance;

            // Return result object
            return result;
        }

        // Overload - (double - class)
        public static Fraction operator - (double number, Fraction second_instance)
        {
            // Create first_instance object
            Fraction first_instance = new Fraction(number);

            // Create result object
            Fraction result = new Fraction();

            // Result object
            result = first_instance - second_instance;

            // Return result object
            return result;
        }

        // Overload * (class * class)
        public static Fraction operator * (Fraction first_instance, Fraction second_instance)
        {
            // Create result object
            Fraction result = new Fraction();

            // Numerator
            result.Numerator = first_instance.Numerator * second_instance.Numerator;
            // Denominator
            result.Denominator = first_instance.Denominator * second_instance.Denominator;

            // Return result object
            return result;
        }

        // Overload * (class * int)
        public static Fraction operator * (Fraction first_instance, int number)
        {
            // Create result object
            Fraction result = new Fraction();

            // Numerator
            result.Numerator = first_instance.Numerator * number;
            // Denominator
            result.Denominator = first_instance.Denominator;

            // Return result object
            return result;
        }

        // Overload * (int * class)
        public static Fraction operator * (int number, Fraction second_instance)
        {
            // Create result object
            Fraction result = new Fraction();

            // Result object
            result = second_instance * number;

            // Return result object
            return result;
        }

        // Overload * (class * double)
        public static Fraction operator * (Fraction first_instance, double number)
        {
            // Create second_instance object
            Fraction second_instance = new Fraction(number);

            // Create result object
            Fraction result = new Fraction();

            // Result object
            result = first_instance * second_instance;

            // Return result object
            return result;
        }

        // Overload * (double * class)
        public static Fraction operator * (double number, Fraction second_instance)
        {
            // Create first_instance object
            Fraction first_instance = new Fraction(number);

            // Create result object
            Fraction result = new Fraction();

            // Result object
            result = first_instance * second_instance;

            // Return result object
            return result;
        }

        // Overload / (class / class)
        public static Fraction operator / (Fraction first_instance, Fraction second_instance)
        {
            // Create result object
            Fraction result = new Fraction();

            // Numerator
            result.Numerator = first_instance.Numerator * second_instance.Denominator;
            // Denominator
            result.Denominator = first_instance.Denominator * second_instance.Numerator;

            // Return result object
            return result;
        }

        // Overload / (class / int)
        public static Fraction operator / (Fraction first_instance, int number)
        {
            // Create result object
            Fraction result = new Fraction();

            // Numerator
            result.Numerator = first_instance.Numerator;
            // Denominator
            result.Denominator = first_instance.Denominator * number;

            // Return result object
            return result;
        }

        // Overload / (int / class)
        public static Fraction operator / (int number, Fraction second_instance)
        {
            // Create result object
            Fraction result = new Fraction();

            // Numerator
            result.Numerator = second_instance.Denominator * number;
            // Denominator
            result.Denominator = second_instance.Numerator;

            // Return result object
            return result;
        }

        // Overload / (class / double)
        public static Fraction operator / (Fraction first_instance, double number)
        {
            // Create second_instance object
            Fraction second_instance = new Fraction(number);

            // Create result object
            Fraction result = new Fraction();

            // Result object
            result = first_instance / second_instance;

            // Return result object
            return result;
        }

        // Overload / (double / class)
        public static Fraction operator / (double number, Fraction second_instance)
        {
            // Create first_instance object
            Fraction first_instance = new Fraction(number);

            // Create result object
            Fraction result = new Fraction();

            // Result object
            result = first_instance / second_instance;

            // Return result object
            return result;
        }

        // Overload == (class == class)
        public static bool operator == (Fraction first_instance, Fraction second_instance)
        {
            // Check instances
            if (first_instance.Numerator == second_instance.Numerator & first_instance.Denominator == second_instance.Denominator)
            {
                // Return value
                return true;
            }
            // Return value
            return false;
        }

        // Overload == (class == int)
        public static bool operator == (Fraction first_instance, int number)
        {
            // Check instance and mumber
            if (first_instance.Numerator == number & first_instance.Denominator == 1)
            {
                // Return value
                return true;
            }
            // Return value
            return false;
        }

        // Overload == (int == class)
        public static bool operator == (int number, Fraction second_instance)
        {
            // Check instance and mumber
            if (second_instance.Numerator == number & second_instance.Denominator == 1)
            {
                // Return value
                return true;
            }
            // Return value
            return false;
        }

        // Overload == (class == double)
        public static bool operator == (Fraction first_instance, double number)
        {
            // Create second_instance object
            Fraction second_instance = new Fraction(number);

            // Return value
            return first_instance == second_instance;
        }

        // Overload == (double == class)
        public static bool operator == (double number, Fraction second_instance)
        {
            // Create first_instance object
            Fraction first_instance = new Fraction(number);

            // Return value
            return first_instance == second_instance;
        }

        // Overload != (class != class)
        public static bool operator != (Fraction first_instance, Fraction second_instance)
        {
            // Check instances
            if (first_instance.Numerator != second_instance.Numerator || first_instance.Denominator != second_instance.Denominator)
            {
                // Return value
                return true;
            }
            // Return value
            return false;
        }

        // Overload != (class != int)
        public static bool operator != (Fraction first_instance, int number)
        {
            // Check instance and mumber
            if (first_instance.Numerator != number || first_instance.Denominator != 1)
            {
                // Return value
                return true;
            }
            // Return value
            return false;
        }

        // Overload != (int != class)
        public static bool operator != (int number, Fraction second_instance)
        {
            // Check instance and mumber
            if (second_instance.Numerator != number || second_instance.Denominator != 1)
            {
                // Return value
                return true;
            }
            // Return value
            return false;
        }

        // Overload != (class != double)
        public static bool operator != (Fraction first_instance, double number)
        {
            // Create second_instance object
            Fraction second_instance = new Fraction(number);

            // Return value
            return first_instance != second_instance;
        }

        // Overload != (double != class)
        public static bool operator != (double number, Fraction second_instance)
        {
            // Create first_instance object
            Fraction first_instance = new Fraction(number);

            // Return value
            return first_instance != second_instance;
        }

        // Overload < (class < class)
        public static bool operator < (Fraction first_instance, Fraction second_instance)
        {
            // Lowest common denominator
            int LowestCommonDenominator = Fraction._FindLowestCommonDenominator(first_instance.Denominator, second_instance.Denominator);
            
            // Check instance and mumber
            if ((first_instance.Numerator * (LowestCommonDenominator / first_instance.Denominator)) < (second_instance.Numerator * (LowestCommonDenominator / second_instance.Denominator)))
            {
                // Return value
                return true;
            }
            // Return value
            return false;
        }

        // Overload < (class < int)
        public static bool operator < (Fraction first_instance, int number)
        {
            // Lowest common denominator
            int LowestCommonDenominator = Fraction._FindLowestCommonDenominator(first_instance.Denominator, 1);

            // Check instance and mumber
            if ((first_instance.Numerator * (LowestCommonDenominator / first_instance.Denominator)) < (number * LowestCommonDenominator))
            {
                // Return value
                return true;
            }
            // Return value
            return false;
        }

        // Overload < (int < class)
        public static bool operator < (int number, Fraction second_instance)
        {
            // Lowest common denominator
            int LowestCommonDenominator = Fraction._FindLowestCommonDenominator(second_instance.Denominator, 1);

            // Check instance and mumber
            if ((number * LowestCommonDenominator) < (second_instance.Numerator * (LowestCommonDenominator / second_instance.Denominator)))
            {
                // Return value
                return true;
            }
            // Return value
            return false;
        }

        // Overload < (class < double)
        public static bool operator < (Fraction first_instance, double number)
        {
            // Create second_instance object
            Fraction second_instance = new Fraction(number);

            // Return value
            return first_instance < second_instance;
        }

        // Overload < (double < class)
        public static bool operator < (double number, Fraction second_instance)
        {
            // Create first_instance object
            Fraction first_instance = new Fraction(number);

            // Return value
            return first_instance < second_instance;
        }

        // Overload > (class > class)
        public static bool operator > (Fraction first_instance, Fraction second_instance)
        {
            // Lowest common denominator
            int LowestCommonDenominator = Fraction._FindLowestCommonDenominator(first_instance.Denominator, second_instance.Denominator);

            // Check instance and mumber
            if ((first_instance.Numerator * (LowestCommonDenominator / first_instance.Denominator)) > (second_instance.Numerator * (LowestCommonDenominator / second_instance.Denominator)))
            {
                // Return value
                return true;
            }
            // Return value
            return false;
        }

        // Overload > (class > int)
        public static bool operator > (Fraction first_instance, int number)
        {
            // Lowest common denominator
            int LowestCommonDenominator = Fraction._FindLowestCommonDenominator(first_instance.Denominator, 1);

            // Check instance and mumber
            if ((first_instance.Numerator * (LowestCommonDenominator / first_instance.Denominator)) > (number * LowestCommonDenominator))
            {
                // Return value
                return true;
            }
            // Return value
            return false;
        }

        // Overload > (int > class)
        public static bool operator > (int number, Fraction second_instance)
        {
            // Lowest common denominator
            int LowestCommonDenominator = Fraction._FindLowestCommonDenominator(second_instance.Denominator, 1);

            // Check instance and mumber
            if ((number * LowestCommonDenominator) > (second_instance.Numerator * (LowestCommonDenominator / second_instance.Denominator)))
            {
                // Return value
                return true;
            }
            // Return value
            return false;
        }

        // Overload > (class > double)
        public static bool operator > (Fraction first_instance, double number)
        {
            // Create second_instance object
            Fraction second_instance = new Fraction(number);

            // Return value
            return first_instance > second_instance;
        }

        // Overload > (double > class)
        public static bool operator > (double number, Fraction second_instance)
        {
            // Create first_instance object
            Fraction first_instance = new Fraction(number);

            // Return value
            return first_instance > second_instance;
        }

        // Find lowest common denomination
        private static int _FindLowestCommonDenominator(int first_denominator, int second_denominator)
        {
            // Variables
            int minimum = 0;
            int[] maximum = new int[2];

            // Search for the maximum of two denominators
            if (first_denominator > second_denominator)
            {
                maximum[0] = first_denominator;
                maximum[1] = first_denominator;
                minimum = second_denominator;
            }
            else
            {
                maximum[0] = second_denominator;
                maximum[1] = second_denominator;
                minimum = first_denominator;
            }
            // Search for lowest common denomination
            int i = 0;
            while (maximum[0] % minimum != 0)
            {
                ++i;
                maximum[0] = maximum[1] * i;
            }
            // Return value
            return maximum[0];
        }

        // Override GetHashCode
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        // Override Equals(Fraction insnance)
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Fraction f = new Fraction(3, 4);

            int a = 10;
            Fraction f1 = f * a;

            Fraction f2 = a * f;

            double d = 1.5;
            Fraction f3 = f + d;

            Fraction f4 = (f1 + (f2 * f3) + a) / d;
        }
    }
}
