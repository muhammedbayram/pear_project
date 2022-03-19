namespace pear_project
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
         public int? PersonDetailId { get; set; }
        public PersonDetail? PersonDetail { get; set; }
  
    }
}