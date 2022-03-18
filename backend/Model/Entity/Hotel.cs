namespace Hotel_Management.Model.Entity
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int NumRooms { get; set; }
        public bool Active { get; set; } 
        public List<Room> Room { get; set; }
        public List<Employee> Employee { get; set; }
    }
}
