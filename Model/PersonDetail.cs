namespace pear_project
{
    public class PersonDetail
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int DutyFee { get; set; }
        public int Age { get; set; }
        public double Rating { get; set; }
        public enum Gender { Male, Female, Other }
        public Gender gender { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }

        public virtual ICollection<DutyCategory> dutyCategories { get; set; }

    }
}