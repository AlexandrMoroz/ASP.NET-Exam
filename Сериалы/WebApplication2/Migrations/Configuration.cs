namespace WebApplication2.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebApplication2.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplication2.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(WebApplication2.Models.ApplicationDbContext context)
        {
            List<Seazon> sez = new List<Seazon>()
            {
                new Seazon { Number = 1 },
                new Seazon { Number = 2 },
                new Seazon { Number = 3 },
                new Seazon { Number = 4 },
                new Seazon { Number = 5 },
                new Seazon { Number = 6 },
                new Seazon { Number = 7 },
                new Seazon { Number = 8 },
                new Seazon { Number = 9 },
                new Seazon { Number = 10 },
                new Seazon { Number = 11 },
                new Seazon { Number = 12 },
                new Seazon { Number = 13 },
                new Seazon { Number = 14 },
                new Seazon { Number = 15 },
                new Seazon { Number = 16 },
                new Seazon { Number = 17 },
                new Seazon { Number = 18 },
                new Seazon { Number = 19 },
                new Seazon { Number = 20 },
                new Seazon { Number = 21 },
                new Seazon { Number = 22 },
                new Seazon { Number = 23 },
                new Seazon { Number = 24 },
                new Seazon { Number = 25 },
                new Seazon { Number = 26 },
                new Seazon { Number = 27 },
                new Seazon { Number = 28 },
                new Seazon { Number = 29 },
                new Seazon { Number = 30 }
            };
            List<Serial> ser = new List<Serial>()
            {
             new Serial {
                 Name = "Сверхестественное",
                 EnglishName="Supernational",
                 Coments= "американский фэнтези-телесериал, созданный Эриком Крипке. Премьера телесериала состоялась на телеканале The WB 13 сентября 2005 года, а затем он стал частью программы телеканала The CW, который образовался после слияния The WB и UPN. С Джаредом Падалеки и Дженсеном Эклсом в главных ролях Сэма и Дина Винчестеров соответственно, сериал повествует о двух братьях — охотниках за нечистью, которые путешествуют по США на чёрной Chevrolet Impala 1967 года, расследуя паранормальные явления, многие из которых основаны на городских легендах и фольклоре, а также сражаются с порождениями зла: демонами, призраками и другой нечистью. Производством шоу занимается компания Warner Bros. Television вместе с Wonderland Sound and Vision.Наряду с Крипке, главными исполнительными продюсерами телесериала в разные годы были Макджи, Роберт Сингер, Филип Сгриккиа, Сера Гэмбл, Джереми Карвер, Джон Шибан, Бен Эдлунд и Адам Гласс. Ещё один исполнительный продюсер и режиссёр Ким Мэннэрс умер от рака лёгких во время производства четвёртого сезона[1]. «Сверхъестественное» стал самым продолжительным североамериканским научно - фантастическим сериалом(до этого им являлось шоу «Тайны Смолвиля», насчитывавший 218 эпизодов)",
                 YearsOfEdition="2005 - ....",
                 ImagePath="supernatural.jpg",
                 Time="50 min",
                 Rate=0
             },
             new Serial {
                 Name = "Доктор Хаус",
                 EnglishName="House MD",
                 Coments= "Сериал рассказывает о команде врачей, которые должны правильно поставить диагноз пациенту и спасти его. Возглавляет команду доктор Грегори Хаус, который ходит с тростью после того, как его мышечный инфаркт в правой ноге слишком поздно правильно диагностировали. Как врач Хаус просто гений, но сам не отличается проникновенностью в общении с больными и с удовольствием избегает их, если только есть возможность. Он сам всё время проводит в борьбе с собственной болью, а трость в его руке только подчеркивает его жесткую, ядовитую манеру общения. Порой его поведение можно назвать почти бесчеловечным, и при этом он прекрасный врач, обладающий нетипичным умом и безупречным инстинктом, что снискало ему глубокое уважение. Будучи инфекционистом, он ещё и замечательный диагност, который любит разгадывать медицинские загадки, чтобы спасти кому-то жизнь. Если бы все было по его воле, то Хаус лечил бы больных не выходя из своего кабинета.",
                 YearsOfEdition="2004 - ...",
                 ImagePath = "1.jpg",
                 Time="30 min",
                 Rate=0
             }
            };
            Studio studios = new Studio()
            {
                Name = "Paramaunt",
                Serials = ser
            };
            Director Director = new Director()
            {
                Name = "Jamis Cameron",
                Serials = ser
            };
            List<Country> Countries = new List<Country>()
            {
                new Country(){ Name = "USA", Serials = ser},
                new Country(){ Name = "Canada", Serials =ser}
            };
            List<SerialSeazon> temp = new List<SerialSeazon>()
            {
                new SerialSeazon() {Serial=ser[0], Seazon=sez[0] },
                new SerialSeazon() {Serial=ser[0], Seazon=sez[1] },
                new SerialSeazon() {Serial=ser[0], Seazon=sez[2] },
                new SerialSeazon() {Serial=ser[0], Seazon=sez[3] },
                new SerialSeazon() {Serial=ser[0], Seazon=sez[4] },
                new SerialSeazon() {Serial=ser[0], Seazon=sez[5] },

                new SerialSeazon() {Serial=ser[1], Seazon=sez[0] },
                new SerialSeazon() {Serial=ser[1], Seazon=sez[1] },
                new SerialSeazon() {Serial=ser[1], Seazon=sez[2] },
                new SerialSeazon() {Serial=ser[1], Seazon=sez[3] },
                new SerialSeazon() {Serial=ser[1], Seazon=sez[4] },
                new SerialSeazon() {Serial=ser[1], Seazon=sez[5] },
            };
            List<Ganer> ganers = new List<Ganer>()
            {
                new Ganer() { Name="Фантастика" },
                new Ganer() { Name="Спорт" },
                new Ganer() { Name="Драма" },
                new Ganer() { Name="Триллер" },
                new Ganer() { Name="Детектив" },
                new Ganer() { Name="Фэнтези" },
                new Ganer() { Name="Ужасы" },
                new Ganer() { Name="Боевик" },
                new Ganer() { Name="Мильтики" },
                new Ganer() { Name="Биография" }

            };
            List<SerialGaner> sg = new List<SerialGaner>()
            {
                new SerialGaner() {Serial=ser[0],Ganer=ganers[6]},
                new SerialGaner() {Serial=ser[0],Ganer=ganers[3]},
                new SerialGaner() {Serial=ser[0],Ganer=ganers[5]},
                new SerialGaner() {Serial=ser[0],Ganer=ganers[4]},

                new SerialGaner() {Serial=ser[1],Ganer=ganers[2]},
                new SerialGaner() {Serial=ser[1],Ganer=ganers[4]},
            };
            List<Seria> serias = new List<Seria>()
            {
                new Seria { Name="ведьма", Date = DateTime.Now, SeazonSerial= temp[0] },
                new Seria { Name="ведьма1", Date = DateTime.Now, SeazonSerial= temp[1] },
                new Seria { Name="ведьма2", Date = DateTime.Now, SeazonSerial= temp[2] },
                new Seria { Name="ведьма3", Date = DateTime.Now, SeazonSerial= temp[3] },
            };


            context.SerialsSeazons.AddRange(temp);
            context.Directors.Add(Director);
            context.Countrys.AddRange(Countries);
            context.Studios.Add(studios);
            context.Serials.AddRange(ser);
            context.Seazons.AddRange(sez);
            context.Serias.AddRange(serias);
            context.SerialGaners.AddRange(sg);
            context.Ganers.AddRange(ganers);
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "Alex"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "alexmoroz@gmail.com", Email ="alexmoroz@gmail.com" };
         
                manager.Create(user, "Alex-123");
                manager.AddToRole(user.Id, "Admin");
            }
        }
    }
}
