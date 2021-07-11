namespace Entity.Entity
{
    public class Homework
    {
        private int? grade;
        
        public Homework(int id,
                        int lectureId,
                        int studentId,
                        int grade)
        
        {
            Id = id;
            LectureId = lectureId;
            StudentId = studentId;
            Grade = grade;
        }

        public int Id { get; set; }
        
        public int LectureId { get; set; }

        public int StudentId { get; set; }

        public int? Grade 
        {
            get { return grade; }
            set
            {
                if (grade >= 0 && grade <= 5)
                    grade = value;
                else
                    throw new System.Exception();
            }
        }
    }
}
