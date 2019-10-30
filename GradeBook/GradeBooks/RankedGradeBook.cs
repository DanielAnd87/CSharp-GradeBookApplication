using System;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook  : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            this.Type = GradeBookType.Ranked;
        }


        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();

                return 'F';
            }
            else if (averageGrade >= 0.8D)
            {
                return 'A';
            }else if (averageGrade >= 0.6D)
            {
                return 'B';
            }else if (averageGrade >= 0.4D)
            {
                return 'C';
            }else if (averageGrade >= 0.2D)
            {
                return 'D';
            }else
            {
                return 'F';
            }

        }
    }
}