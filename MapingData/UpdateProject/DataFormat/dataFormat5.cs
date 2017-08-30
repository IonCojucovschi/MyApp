namespace UpdateProject.DataFormat
{
    public class dataFormat5
    {
        public int number { get; set; }
        public string routeName { get; set; }
        public override string ToString()
        {
            return string.Format("number:{0,10}\t\t Route:{1,10}", number, routeName);
        }
    }
}
