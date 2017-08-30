namespace UpdateProject.DataFormat
{
    public class dataFormat4
    {
        public int number { get; set; }
        public string routeName { get; set; }
        public override string ToString()
        {
            return string.Format("number:{0,10}\t\t Route:{1,10}", number, routeName);
        }
    }
    public class dataFormat7
    {
        public int number { get; set; }
        public string type { get; set; }
        public override string ToString()
        {
            return string.Format("number:{0,10}\t\t type:{1,10}", number, type);
        }
    }
}
