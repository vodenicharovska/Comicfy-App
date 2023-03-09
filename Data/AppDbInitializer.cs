using Comicfy.Data.Static;
using Comicfy.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comicfy.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Writers
                if (!context.Writers.Any())
                {
                    context.Writers.AddRange(new List<Writer>()
                    {
                        new Writer()
                        {
                            Name = "Nnedi Okorafor",
                            Picture = "https://pbs.twimg.com/profile_images/1458606568186920962/7S45wxH3_400x400.jpg",
                        },
                        new Writer()
                        {
                            Name = "Phillip Kennedy Johnson",
                            Picture = "https://www.fumettologica.it/wp-content/uploads/2021/03/phillip-kennedy-johnson-670x377.jpeg",
                        },
                        new Writer()
                        {
                            Name = "Al Ewing",
                            Picture = "https://s3.amazonaws.com/comicgeeks/people/avatars/1216.jpg?t=1636395240"
                        },
                    });
                    context.SaveChanges();
                }
                //MainCharacters
                if (!context.MainCharacters.Any())
                {
                    context.MainCharacters.AddRange(new List<MainCharacter>()
                    {
                        new MainCharacter()
                        {
                            Bio = "The Wasp е партнер на Хенк Пим (познат и како Ант-Ман), а подоцна стана негова сопруга. Таа обично се прикажува како да има способност да се смалува до височина од неколку сантиметри, да лета со помош на инсектоидни крилја и да пали биоелектрични енергетски експлозии. Таа е основачки член на Avengers, како и долгогодишен лидер на тимот, и беше член на Defenders и Lady Liberators",
                            Name = "The Wasp (вистинско име -Janet Van Dyne)",
                            Picture = "https://i.pinimg.com/474x/02/49/6d/02496deb64b4b689f48f99bffee4f321.jpg"
                        },
                        new MainCharacter()
                        {
                            Bio = "Елси беше млада девојка која потекнуваше од сиромашно и често бездомно семејство, честопати страдајќи од запоставување и физичко малтретирање од страна на нејзината мајка Ди и очувот Френк. Откако Френк и Ди побараа запуштена градска куќа во Бруклин како резиденција на сквотери, Елси честопати беше испраќана надвор од куќата и црташе на тротоарот пред урнатините на старото училиште. Еден ден, еден човек по име Џери и пришол и ја предупредил дека училиштето Сент Естес било место на масакр години пред тоа и дека луѓето понекогаш исчезнуваат околу него. Занемарувајќи ги предупредувањата на Џери да не остане таму во мракот, Елси побарала засолниште во урнатините кога нејзиниот цртеж бил уништен од некои пијани студенти на колеџ и почнал да врне.",
                            Name = "Carnage (Elsie)",
                            Picture = "https://static.tvtropes.org/pmwiki/pub/images/carnage_eddie_brock.png",
                        },
                        new MainCharacter()
                        {
                            Bio = "Шури е принцезата и главниот технолошки иноватор од малку познатата, но технолошки напредна земја Ваканда. По загубата на речиси целото нејзино семејство, имено нејзиниот постар брат Т'Чала и мајката Рамонда, Шури ја презела наметката на заштитникот на предците на Ваканда, Црниот Пантер.",
                            Name = "Shuri",
                            Picture = "https://pbs.twimg.com/profile_images/1580903058535596033/O_fOvNvK_400x400.jpg"
                        },
                    });
                    context.SaveChanges();
                }

                //CoverArtists
                if (!context.CoverArtists.Any())
                {
                    context.CoverArtists.AddRange(new List<CoverArtist>()
                    {
                        new CoverArtist()
                        {
                            Name = "Tom Reilly"
                        },
                        new CoverArtist()
                        {
                            Name = "kunkka"
                        },
                        new CoverArtist()
                        {
                           Name = "Leonardo Romero"
                        },
                    });
                    context.SaveChanges();
                }
                //Pencilers
                if (!context.Pencilers.Any())
                {
                    context.Pencilers.AddRange(new List<Penciler>()
                    {
                        new Penciler()
                        {
                            Name = "Kasia Nie"
                        },
                        new Penciler()
                        {
                            Name = "Edgar Salazar"
                        },

                         new Penciler()
                        {
                            Name = "Jordie Belaire"
                        },
                     });
                    context.SaveChanges();
                }

                //ComicBooks
                if (!context.ComicBooks.Any())
                {
                    context.ComicBooks.AddRange(new List<ComicBook>()
                    {
                        new ComicBook()
                        {
                            Image = "https://cdn.marvel.com/u/prod/marvel/i/mg/c/70/63dd8ac85b40f/clean.jpg",
                            Title = "Wasp #3",
                            ShortDescription = "captured by an alliance of their oldest enemies, janet and nadia van dyne find themselves trapped in a past where a key part of their history - henry pym, the ant-man - never existed at all. as strange new lives play out around them, they must find their way back to the wasp...or cease to exist entirely.",
                            Published = "25 September, 2019",
                            Language = "English",
                            Price = 150,
                            WriterId =1,
                            PencilerId = 1,
                            CoverArtistId = 1,
                            SellingCategory = SellingCategory.Продажба
                        },
                        new ComicBook()
                        {
                            Image = "https://cdn.marvel.com/u/prod/marvel/i/mg/2/40/61b2391a1d410/clean.jpg",
                            Title = "Carnage forever #1",
                            ShortDescription = "a killer celebration! cletus kasady is the most notorious serial killer in the marvel universe - and it's been thirty years since his first introduction! thirty years of monsters, mayhem and murder - and you haven't seen anything yet! with an awesome assembly of creators, this issue will have it all! a look back on carnage's past, his present and, just maybe, the first hints you'll ever get of his visceral and violent future!",
                            Published = "18 February 2022",
                            Language = "English",
                            Price = 150,
                            WriterId =2,
                            PencilerId = 2,
                            CoverArtistId = 2,
                            SellingCategory = SellingCategory.Изнајмување
                        },
                        new ComicBook()
                        {
                            Image = "https://cdn.marvel.com/u/prod/marvel/i/mg/6/c0/5cb8890c247b6/clean.jpg",
                            Title = "Shuri vol. 1: the search for black panther",
                            ShortDescription = "the world fell in love with her in marvel’s black panther. now, t’challa’s techno-genius sister launches her own adventures — written by best-selling afrofuturist author nnedi okorafor and drawn by eisner award-nominated artist leonardo romero! t’challa has disappeared, and everyone is looking at the next in line for the throne. wakanda expects shuri to take on the mantle of black panther once more and lead their great nation — but she’s happiest in a lab, surrounded by her own inventions. she’d rather be testing gauntlets than throwing them down! so it’s time for shuri to go rescue her brother yet again — with a little help from storm, rocket raccoon and groot, of course! but when her outer-space adventure puts the entire cultural history of her continent at risk from an energy-sapping alien threat, can shuri and iron man save africa?",
                            Published = "17 June 2020",
                            Language = "Macedonian",
                            Price = 150,
                            WriterId = 3,
                            PencilerId = 3,
                            CoverArtistId = 3,
                            SellingCategory = SellingCategory.Замена
                        },
                    });
                    context.SaveChanges();
                }

                //Characters and ComicBooks
                if (!context.Characters_ComicBooks.Any())
                {
                    context.Characters_ComicBooks.AddRange(new List<MCharacter_ComicBook>()
                    {
                        new MCharacter_ComicBook()
                        {
                            ComicBookId = 23,
                            CharacterId = 1
                        },
                        new MCharacter_ComicBook()
                        {
                            ComicBookId = 22,
                            CharacterId = 2
                        },
                        new MCharacter_ComicBook()
                        {
                            ComicBookId = 21,
                            CharacterId = 3
                        },
                    });
                    context.SaveChanges();
                }
            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@comicfy.com";
                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if(adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    //await userManager.AddToRoleAsync(newAdminUser, );
                }
            }
        }
    }
}
