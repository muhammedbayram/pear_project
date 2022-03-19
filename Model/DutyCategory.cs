namespace pear_project
{
    public class DutyCategory
    {
        public int Id { get; set; }
        public enum Duty { Temizlik, Tadilat, Özel_Ders, Diğer }
        public Duty duty { get; set; }

        public int personDetailId { get; set; }
        public PersonDetail personDetail { get; set; }


        public virtual ICollection<Person>? Persons { get; set; }

    }
}