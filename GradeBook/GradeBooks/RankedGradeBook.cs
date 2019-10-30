using System;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook  : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }


        public override char GetLetterGrade(double averageGrade)
        {



            if (Students.Count < 5)
            {
                throw new InvalidOperationException();

                return 'F';
            }

            double place = (double) CheckPlace(averageGrade);

            if (place / Students.Count >= 0.8D)
            {
                return 'A';
            }
            if (place / Students.Count >= 0.6D)
            {
                return 'B';
            }
            if (place / Students.Count >= 0.4D)
            {
                return 'C';
            }
            if (place / Students.Count >= 0.2D)
            {
                return 'D';
            }
            return 'F';

        }

        private int CheckPlace(double averageGrade)
        {
            int i = 0;
            double[] arr = new double[Students.Count];
            foreach (Student student in Students)
            {
                arr[i] = student.AverageGrade;
                i++;
            }
            Array.Sort(arr);
            i = 0;
            foreach (int score in arr)
            {
                if (averageGrade > score) return i; 
                i++;
            }

            return Students.Count;

        }
    }
}