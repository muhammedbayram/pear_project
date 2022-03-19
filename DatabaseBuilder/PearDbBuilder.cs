using Microsoft.EntityFrameworkCore;


namespace pear_project
{
    public static class PearDbBuilder
    {


        static void SetDataToDB(ModelBuilder modelBuilder)
        {

        }
        public static void TableBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(entity =>
              {
                  entity.HasKey(p => p.Id);
                  entity.Property(p => p.Name).IsRequired();
                  entity.HasOne(p => p.PersonDetail).WithOne(d => d.Person).HasForeignKey<Person>("PersonDetailId");
              });


            modelBuilder.Entity<PersonDetail>(entity =>
           {
               entity.HasKey(e => e.Id);
               entity.Property(e => e.Description).IsRequired();
               entity.Property(e => e.DutyFee).IsRequired();
               entity.Property(e => e.gender).IsRequired();
               entity.Property(e => e.Age).IsRequired();
               entity.Property(e => e.Rating).IsRequired();
           });

            modelBuilder.Entity<DutyCategory>(entity =>
             {
                 entity.HasKey(e => e.Id);
                 entity.Property(e => e.duty).IsRequired();
                 entity.HasOne(e => e.personDetail).WithMany(c => c.dutyCategories).HasForeignKey(e => e.personDetailId);

             });

            //     modelBuilder.Entity<Address>().HasData(
            //  new Address
            //  {
            //      Id = 1,
            //      Name = "Adems",
            //      OpenAddress1 = "bagcilar sok mahalllesi",
            //      OpenAddress2 = "caminin arkasi",
            //      CountryId = 1,
            //      CityId = 2,
            //      DistrictId = 3

            //  });

            //     modelBuilder.Entity<Country>().HasData(
            // new Country
            // {
            //     Id = 1,
            //     Name = "Turkey",
            //     Code = 001,
            //     HasState = false

            // });
            //     modelBuilder.Entity<City>().HasData(
            //         new City
            //         {
            //             Id = 1,
            //             Name = "Ankara",
            //             CountryId = 1,



            //         });

            //     modelBuilder.Entity<State>().HasData(
            //        new State
            //        {
            //            Id = 1,
            //            Name = "New York",
            //            CountryId = 2

            //        });

            SetDataToDB(modelBuilder);
        }
    }


}