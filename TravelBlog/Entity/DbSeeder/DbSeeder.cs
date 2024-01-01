using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelBlog.Models;

namespace TravelBlog.Entity.DbSeeder
{
    public class DbSeeder
    {
      public static DataContext _Context = new DataContext();

        public static void DbSeed()
        {
            if (!_Context.Regions.Any())
            {
                RegionSeed(_Context);
            }

            if (!_Context.Cities.Any())
            {
                CitySeed(_Context);
            }
           
            if (!_Context.AppRoles.Any())
            {
                RoleSeed(_Context);
            }
           
            if (!_Context.AppUsers.Any())
            {
                UserSeed(_Context);
            }

            if (!_Context.BlogPosts.Any())
            {
                BlogPostSeed(_Context);
            }
       
            if (!_Context.Comments.Any())
            {
                CommentsSeed(_Context);
            }
    
        }

        private static void RegionSeed(DataContext _context)
        {
            _context.Regions.Add(
                          new Region
                          {
                              Name = "Marmara",
                              Image = "Marmara.png"
                          }
                         );

            _context.Regions.Add(
                      new Region
                      {
                          Name = "Ege",
                          Image = "Ege.png"
                      }
                     );

            _context.Regions.Add(
                               new Region
                               {
                                   Name = "Akdeniz",
                                   Image = "Akdeniz.png"
                               }
                               );

            _context.Regions.Add(
                               new Region
                               {
                                   Name = "Karadeniz",
                                   Image = "Karadeniz.png"
                               }
                                                                 );

            _context.Regions.Add(
                               new Region
                               {
                                   Name = "İç Anadolu",
                                   Image = "IcAnadolu.png"
                               }
                                                                 );

            _context.Regions.Add(
                               new Region
                               {
                                   Name = "Doğu Anadolu",
                                   Image = "DoguAnadolu.png"
                               }
                                                                                                   );

            _context.Regions.Add(
                               new Region
                               {
                                   Name = "Güneydoğu Anadolu",
                                   Image = "GuneydoguAnadolu.png"
                               });



            _context.SaveChanges();
        }

        private static void CitySeed(DataContext _context)
        {
            List<City> cities = new List<City>()
             {
                 new City
                 {
                     Name = "İstanbul",
                     Image = "Istanbul.png",
                     RegionId = 1
                 },
                 new City
                 {
                        Name = "Bursa",
                        Image = "Bursa.png",
                        RegionId = 1
                    },
                 new City
                 {
                            Name = "İzmir",
                            Image = "Izmir.png",
                            RegionId = 2
                        },
                 new City
                 {
                      Name = "Muğla",
                      Image = "Mugla.png",
                      RegionId = 2
                  },
                 new City
                 {
                     Name = "Antalya",
                     Image = "Antalya.png",
                     RegionId = 3
                 },
                 new City
                 {
                        Name = "Adana",
                        Image = "Adana.png",
                        RegionId = 3
                    },
                 new City
                 {
                      Name = "Trabzon",
                      Image = "Trabzon.png",
                      RegionId = 4
                  },

                 new City
                 {
                     Name = "Rize",
                     Image = "Rize.png",
                     RegionId = 4
                 },
                 new City
                 {
                            Name = "Ankara",
                            Image = "Ankara.png",
                            RegionId = 5
                  },
                 new City
                 {
                        Name = "Konya",
                        Image = "Konya.png",
                        RegionId = 5
                  },

                 new City
                 {
                        Name = "Van",
                        Image = "Van.png",
                        RegionId = 6
                 },
                 new City
                 {
                            Name = "Erzurum",
                            Image = "Erzurum.png",
                            RegionId = 6
                 },
                 new City
                 {
                        Name = "Diyarbakır",
                        Image = "Diyarbakir.png",
                        RegionId = 7
                 },
                 new City
                 {
                     Name = "Şanlıurfa",
                     Image = "Sanliurfa.png",
                     RegionId = 7
                 }

             };

            _context.Cities.AddRange(cities);
            _context.SaveChanges();
        }

        private static void RoleSeed(DataContext _context)
        {
            List<AppRole> roles = new List<AppRole>()
            {
                new AppRole
                {
                    Name = "Admin"
                },
                new AppRole
                {
                    Name = "Blogger"
                }

            };

            _context.AppRoles.AddRange(roles);
            _context.SaveChanges();

        }

        private static void UserSeed(DataContext _context)
        {
            List<AppUser> users = new List<AppUser>()
            {
                new AppUser
                {
                    RoleId = 1,
                    Email = "admin@travelblog.com",
                    Password = "123456",
                    UserName = "admin",

                },
                new AppUser
                {
                    RoleId = 2,
                    Email = "bursali@gmail.com",
                    Password = "123456",
                    UserName = "bursali",

                },
                new AppUser
                {
                    RoleId = 2,
                    Email = "istanbullu@gmail.com",
                    Password = "123456",
                    UserName = "istanbullu",

                },
                new AppUser
                {
                    RoleId = 2,
                    Email = "izmirli@gmail.com",
                    Password = "123456",
                    UserName = "izmirli",
                },
                new AppUser
                {
                    RoleId = 2,
                    Email = "sanliurfali@gmail.com",
                    Password = "123456",
                    UserName = "sanliurfali",
                },
                new AppUser
                {
                    RoleId = 2,
                    Email = "konyali@gmail.com",
                    Password = "123456",
                    UserName = "konyali",
                }
            };


            _context.AppUsers.AddRange(users);
            _context.SaveChanges();
        }

        private static void BlogPostSeed(DataContext _context)
        {
            List<BlogPost> blogPosts = new List<BlogPost>()
            {
            new BlogPost
            {
                Title = "İstanbul",
                Content = "İstanbul, Türkiye'nin en kalabalık, iktisadi ve kültürel açıdan en önemli şehri. 2019 itibarıyla 15,5 milyonluk nüfusuyla Avrupa'da en kalabalık şehir ve dünyada ise Şanghay'dan sonra ikinci sırada yer alır. Ülkenin kuzeybatısında yer alan şehir, iki kıta üzerine kurulmuş olup Avrupa'daki kısmı Marmara Bölgesi'nde, Anadolu Yakası'ndaki kısmı ise Marmara ve Karadeniz bölgelerinin kesiştiği noktada yer alır. İstanbul, Türkiye'nin en kalabalık, iktisadi ve kültürel açıdan en önemli şehri. 2019 itibarıyla 15,5 milyonluk nüfusuyla Avrupa'da en kalabalık şehir ve dünyada ise Şanghay'dan sonra ikinci sırada yer alır. Ülkenin kuzeybatısında yer alan şehir, iki kıta üzerine kurulmuş olup Avrupa'daki kısmı Marmara Bölgesi'nde, Anadolu Yakası'ndaki kısmı ise Marmara ve Karadeniz bölgelerinin kesiştiği noktada yer alır.",
                Image = "Istanbul.png",
                CityId = 1,
                AppUserId = 3,
                CreateDate = DateTime.Now,

            },
           new BlogPost
    {
        Title = "Bursa'nın Yeşil Doğası ve Tarihi",
        Content = "Bursa, Osmanlı İmparatorluğu'nun ilk başkenti olarak bilinir. Yeşil Bursa olarak da adlandırılan bu şehir, doğal güzellikleri ve tarihi yapıları ile ünlüdür.",
        Image = "Bursa.png",
        CityId = 2, // Bursa için uygun CityId
        AppUserId = 2,
        CreateDate = DateTime.Now,
    },
            new BlogPost
    {
        Title = "Konya: Mevlana'nın Şehri",
        Content = "Tarihi ve manevi atmosferi ile bilinen Konya, Mevlana Celaleddin Rumi'nin türbesi ve hoşgörü kültürü ile ünlüdür.",
        Image = "Konya.png",
        CityId = 10, // Konya için uygun CityId
        AppUserId = 6,
        CreateDate = DateTime.Now,
    },
            };

            _context.BlogPosts.AddRange(blogPosts);

            _context.SaveChanges();
        }

        private static void CommentsSeed(DataContext _context)
        {
            List<Comment> comments = new List<Comment>()
            {
                new Comment
                {
                    Content = "İstanbul çok güzel bir şehir",
                    BlogPostId = 1,
                    AppUserId = 2,
                    CreateDate = DateTime.Now,
                    
                },
                new Comment
                {
                    Content = "Bursa çok güzel bir şehir",
                    AppUserId = 3,
                    BlogPostId = 2,
                    CreateDate = DateTime.Now
                },
                new Comment
                {
                    Content = "Konya çok güzel bir şehir",
                    AppUserId = 4,
                    BlogPostId = 3,
                    CreateDate = DateTime.Now
                }
            };
            _context.Comments.AddRange(comments);
            _context.SaveChanges();
        }
        
    }
}