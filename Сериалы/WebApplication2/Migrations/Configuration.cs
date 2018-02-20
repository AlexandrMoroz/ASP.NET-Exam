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
                 Name = "�����������������",
                 EnglishName="Supernational",
                 Coments= "������������ �������-����������, ��������� ������ ������. �������� ����������� ���������� �� ���������� The WB 13 �������� 2005 ����, � ����� �� ���� ������ ��������� ���������� The CW, ������� ����������� ����� ������� The WB � UPN. � �������� �������� � ��������� ������ � ������� ����� ���� � ���� ����������� ��������������, ������ ���������� � ���� ������� � ��������� �� ��������, ������� ������������ �� ��� �� ������ Chevrolet Impala 1967 ����, ��������� �������������� �������, ������ �� ������� �������� �� ��������� �������� � ���������, � ����� ��������� � ������������ ���: ��������, ���������� � ������ ��������. ������������� ��� ���������� �������� Warner Bros. Television ������ � Wonderland Sound and Vision.������ � ������, �������� ��������������� ����������� ����������� � ������ ���� ���� ������, ������ ������, ����� ��������, ���� �����, ������� ������, ���� �����, ��� ������ � ���� �����. ��� ���� �������������� �������� � ������� ��� ������� ���� �� ���� ����� �� ����� ������������ ��������� ������[1]. ������������������� ���� ����� ��������������� ������������������ ������ - �������������� ��������(�� ����� �� �������� ��� ������ ���������, ������������� 218 ��������)",
                 YearsOfEdition="2005 - ....",
                 ImagePath="supernatural.jpg",
                 Time="50 min",
                 Rate=0
             },
             new Serial {
                 Name = "������ ����",
                 EnglishName="House MD",
                 Coments= "������ ������������ � ������� ������, ������� ������ ��������� ��������� ������� �������� � ������ ���. ����������� ������� ������ ������� ����, ������� ����� � ������� ����� ����, ��� ��� �������� ������� � ������ ���� ������� ������ ��������� ���������������. ��� ���� ���� ������ �����, �� ��� �� ���������� ����������������� � ������� � �������� � � ������������� �������� ��, ���� ������ ���� �����������. �� ��� �� ����� �������� � ������ � ����������� �����, � ������ � ��� ���� ������ ������������ ��� �������, �������� ������ �������. ����� ��� ��������� ����� ������� ����� �������������, � ��� ���� �� ���������� ����, ���������� ���������� ���� � ����������� ����������, ��� �������� ��� �������� ��������. ������ ��������������, �� ��� � ������������� ��������, ������� ����� ����������� ����������� �������, ����� ������ ����-�� �����. ���� �� ��� ���� �� ��� ����, �� ���� ����� �� ������� �� ������ �� ������ ��������.",
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
                new Ganer() { Name="����������" },
                new Ganer() { Name="�����" },
                new Ganer() { Name="�����" },
                new Ganer() { Name="�������" },
                new Ganer() { Name="��������" },
                new Ganer() { Name="�������" },
                new Ganer() { Name="�����" },
                new Ganer() { Name="������" },
                new Ganer() { Name="��������" },
                new Ganer() { Name="���������" }

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
                new Seria { Name="������", Date = DateTime.Now, SeazonSerial= temp[0] },
                new Seria { Name="������1", Date = DateTime.Now, SeazonSerial= temp[1] },
                new Seria { Name="������2", Date = DateTime.Now, SeazonSerial= temp[2] },
                new Seria { Name="������3", Date = DateTime.Now, SeazonSerial= temp[3] },
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
