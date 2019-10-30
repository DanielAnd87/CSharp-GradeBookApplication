﻿using System;
using System.Collections.Generic;
using System.Linq;
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

            List<double> grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();
            int threshold = (int) Math.Ceiling(Students.Count * 0.2);





            if (grades[threshold - 1] <= averageGrade)
            {
                return 'A';
            }
            if (grades[threshold*2 - 1] <= averageGrade)
            {
                return 'B';
            }
            if (grades[threshold * 3 - 1] <= averageGrade)
            {
                return 'C';
            }
            if (grades[threshold * 4 - 1] <= averageGrade)
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