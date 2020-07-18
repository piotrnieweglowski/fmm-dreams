using System;
using System.Collections.Generic;
using System.Linq;

namespace FMM.Persistent
{
    public class DataSeeder
    {
        private DataContext _dbContext;

        public DataSeeder(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            ReCreateDatabase();
            CreateDreamers();
            CreateCategories();
            CreateDreams();
            CreateSponsors();
            CreateVoluteers();
        }

        private void ReCreateDatabase()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();
        }

        private void CreateDreamers()
        {
            var dreamers = new List<Dreamer>
            {
                new Dreamer { Id = Guid.NewGuid(), FirstName = "Seba",  GuardianContact = "100100100", Sex = "M", YearOfBirth = 2005 },
                new Dreamer { Id = Guid.NewGuid(), FirstName = "Dagmara",  GuardianContact = "200200200", Sex = "F", YearOfBirth = 2010 },
                new Dreamer { Id = Guid.NewGuid(), FirstName = "Janusz Jr",  GuardianContact = "300300300", Sex = "M", YearOfBirth = 2008 },
                new Dreamer { Id = Guid.NewGuid(), FirstName = "Jessica",  GuardianContact = "400400400", Sex = "F", YearOfBirth = 2012 }
            };

            _dbContext.Dreamers.AddRange(dreamers);
            _dbContext.SaveChanges();
        }

        private void CreateCategories()
        {
            var categories = new List<Category>
            {
                new Category { Id = Guid.NewGuid(), Description = "Chcę dostać" },
                new Category { Id = Guid.NewGuid(), Description = "Chcę spotkać" },
                new Category { Id = Guid.NewGuid(), Description = "Sport" }, // only for testing
                new Category { Id = Guid.NewGuid(), Description = "Chcę zwiedzić" }
            };

            _dbContext.Categories.AddRange(categories);
            _dbContext.SaveChanges();
        }

        private void CreateDreams()
        {
            var dreamers = _dbContext.Dreamers.ToList();
            var categories = _dbContext.Categories.ToList();

            var dream1 = new Dream
            { 
                Id = Guid.NewGuid(), 
                Title = "Spotkanie z Lewandowskim",
                Description = "Seba chce spotkać Roberta Lewandowskiego, zeby przybic sobie z nim piatke",
                Dreamer = dreamers.First(x => x.FirstName == "Seba"),
                CanProceed = true
            };
            dream1.Categories = categories
                .Where(x => x.Description.Contains("Chcę spotkać") || x.Description.Contains("Sport"))
                .Select(x => new DreamCategory { CategoryId = x.Id, DreamId = dream1.Id }).ToList();
                
            var dream2 = new Dream
            { 
                Id = Guid.NewGuid(), 
                Title = "Zwiedzanie Bytomia",
                Description = "Jessica lubi śląskie klimaty, więc chce zwiedzić Bytom.",
                Dreamer = dreamers.First(x => x.FirstName == "Jessica"),
                CanProceed = true
            };
            dream2.Categories = categories.Where(x => x.Description.Contains("Chcę zwiedzić"))
                                .Select(x => new DreamCategory { CategoryId = x.Id, DreamId = dream2.Id }).ToList();
            
            var dream3 = new Dream
            { 
                Id = Guid.NewGuid(), 
                Title = "Zwiedzanie siedziby Wykop",
                Description = "Janusz Jr jest wielkim fanem Wykopu, dodatkowo lubi serwery. Odkąd pamięta zawsze marzył o zwiedzeniu wykopowej serwerowni",
                Dreamer = dreamers.First(x => x.FirstName == "Janusz Jr"),
                CanProceed = false
            };
            dream3.Categories = categories.Where(x => x.Description.Contains("Chcę zwiedzić"))
                                .Select(x => new DreamCategory { CategoryId = x.Id, DreamId = dream3.Id }).ToList();

            var dreams = new List<Dream> { dream1, dream2, dream3 };

            _dbContext.Dreams.AddRange(dreams);
            _dbContext.SaveChanges();
        }

        private void CreateSponsors()
        {
            var sponsor1 = new Sponsor
            {
                Id = Guid.NewGuid(),
                Name = "Kopalnia Bytom Bobrek",
                Dreams = _dbContext.Dreams.Where(x => x.Title.Contains("Zwiedzanie")).ToList()
            };

            var sponsors = new List<Sponsor> { sponsor1 };

            _dbContext.Sponsors.AddRange(sponsors);
            _dbContext.SaveChanges();
        }

        private void CreateVoluteers()
        {
            var volunteer1 = new Volunteer
            {
                Id = Guid.NewGuid(),
                FirstName = "Jan",
                LastName = "Kowalski"
            };
            volunteer1.Dreams = _dbContext.Dreams.Select(x => new DreamVolunteer { DreamId = x.Id, VolunteerId = volunteer1.Id }).ToList();

            var volunteers = new List<Volunteer> { volunteer1 };

            _dbContext.Volunteers.AddRange(volunteers);
            _dbContext.SaveChanges();
        }
    }
}