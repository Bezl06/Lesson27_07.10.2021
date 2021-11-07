// using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.DependencyInjection;
// using Lesson3.Data;
// using System;
// using System.Linq;

// namespace Lesson3.Models
// {
//     public static class SeedData
//     {
//         public static void Initialize(IServiceProvider serviceProvider)
//         {
//             using (var context = new MvcProductContext(
//                 serviceProvider.GetRequiredService<
//                     DbContextOptions<MvcProductContext>>()))
//             {
//                 if (context.Categories.Any())
//                 {
//                     return;
//                 }
//                 var category1 = new Category { Name = "Drinks" };
//                 var category2 = new Category { Name = "Snacks" };
//                 var category3 = new Category { Name = "Milk" };
//                 var category4 = new Category { Name = "Meat" };
//                 var category5 = new Category { Name = "Cookies" };
//                 var category6 = new Category { Name = "Bakery" };
//                 context.Categories.AddRange(category1, category2, category3, category4, category5, category6);
//                 context.SaveChanges();
//             }
//         }
//     }
// }