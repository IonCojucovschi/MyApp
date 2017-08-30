namespace UpdateProject.DataFormat
{
    public class dataFormat2
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string vehicleModel { get; set; }
        public string vehNum { get; set; }
        public override string ToString()
        {
            return string.Format("name:{0,10}\t\tsurname:{1,10}\t\tModel:{2,10}\t\tNumber:{3,10}",name,surname,vehicleModel,vehNum);
        }
    }
}
