namespace UpdateProject.DataFormat
{
    public class dataFormat6
    {
        public string name { get; set; }
        public string Surname { get; set; }
        public int salary { get; set; }
        public override string ToString()
        {
            return string.Format("name:{0,10}\t\t surname:{1,10}\t\t{2,10}", name, Surname,salary);
        }
    }
}
