namespace WebAppMVC.Models
{
    public class ParsJson
    {
        public string[] Json { get; set; }
        public int MaxElem { get; set; }

        public ParsJson(string[] json)
        {
            Json = json;
            MaxElem = GetMaxElem();
        }

        public StudentInfo GetStudentInfo()
        {
            Random random = new Random();
            var ElemNumber = random.Next(1,MaxElem);
            return GetStudent(ElemNumber);
        }

        private int GetMaxElem()
        {
            int maxElem = 0;
            if (Json.Length != 0)
            {
                foreach (var item in Json)
                {
                    if (item.IndexOf("name") != -1) maxElem++;
                }
            }
            return maxElem;
        }

        private StudentInfo GetStudent(int elemNumber)
        {
            int count = 0;
            StudentInfo studentInfo = new StudentInfo();

            for (int i = 0; i < Json.Length; i++)
            {
                if (Json[i].IndexOf("name") != -1)
                {
                    count++;
                }

                Random random = new Random();
                if (count == elemNumber)
                {
                    studentInfo.Id = random.Next(int.MaxValue);
                    studentInfo.Name = Json[i].InMidleOf("\"name\": \"", "\"");
                    studentInfo.Math = Json[i + 2].InMidleOf("\"math\": \"", "\"");
                    studentInfo.English = Json[i + 3].InMidleOf("\"english\": \"", "\"");
                    studentInfo.Chemistry = Json[i + 4].InMidleOf("\"chemistry\": \"", "\"");
                    studentInfo.Physics = Json[i + 5].InMidleOf("\"physics\": \"", "\"");
                    break;
                }
            }

            return studentInfo;
        }
    }
}

