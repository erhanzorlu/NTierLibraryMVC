namespace Project.ViewModels.VMClasses
{
    public class AdminAuthorVM
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName
        {
            get

            { return  FirstName + " " + LastName; }

        }
    }
}
