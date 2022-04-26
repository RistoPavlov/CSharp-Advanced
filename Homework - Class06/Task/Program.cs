// See https://aka.ms/new-console-template for more information
using Classes;
using Classes.Enums;
using Classes.Helpers;

Console.WriteLine("\nFind and print all persons firstnames starting with 'R', ordered by Age - DESCENDING ORDER");
List<Person> task1 = DB.People.OrderByDescending(x => x.Age)
                              .Where(y => y.FirstName.Substring(0, 1) == "R").ToList();
task1.PrintEntities();



Console.WriteLine("\nFind and print all persons firstnames and lastnames with job Dentist with age below 32");
List<Person> task2 = (from x in DB.People
                      where x.Age < 32
                      select x).ToList();
task2.PrintEntities();
//RP: You are missing the job filtering (Dentist) - extend the condition for Age with condition for Job



Console.WriteLine("\nFind and print all brown dogs names and ages older than 3 years, ordered by Age - ASCENDING ORDER");
List<Dog> task3 = DB.Dogs.OrderBy(x => x.Age).Where(y => y.Age > 3 && y.Color == "Brown").ToList();
task3.PrintEntities();
//RP: You need to print only Name and Age of the dogs. Use Select with string concatanation to get only Name and Age (similar as Freddy's Dogs LINQ)


Console.WriteLine("\nFind and print all persons names with more than 2 dogs, ordered by Name - DESCENDING ORDER");
List<Person> task4 = DB.People.OrderByDescending(x => x.FirstName).Where(y => y.Dogs.Count() > 2).ToList();
task4.PrintEntities();



Console.WriteLine("\nFind and print all black dogs names from race dalmatins, order by Age - ASCENDING ORDER");
List<Dog> task5 = DB.Dogs.OrderBy(x => x.Age).Where(y => y.Color == "Black" && y.Race == Race.Dalmatian).ToList();
task5.PrintEntities();
//RP: You need to print only Name of the dogs. Use Select to get only Name (same as Freddy's Dogs LINQ)


Console.WriteLine("\nFind and print all Freddy`s dogs names older than 1 year");
List<string> task6 = DB.People.SingleOrDefault(a => a.FirstName == "Freddy").Dogs.Where(b => b.Age > 1).Select(d => d.Name).ToList();
task6.PrintSimple();



Console.WriteLine("\nFind and print all persons firstnames with job developer, don't have dogs and are younger than 25 years, order by age - ASCENDING ORDER");
DB.People.OrderBy(x => x.Age).Where(y => y.Age < 25 && y.Occupation == Job.Developer && y.Dogs.Count() == 0).ToList().PrintEntities();
//RP: You need to print only firstname of the persin. Use Select (same as Freddy's Dogs LINQ)


Console.WriteLine("\nFind and print Nathen`s first dog");
string task8 = DB.People.SingleOrDefault(a => a.FirstName == "Nathen").Dogs.ElementAt(0).Name;
Console.WriteLine(task8);
//RP: This is selecting the single Nathen and print the first element in the dogs list. If there are more than Nathan this will throw error
//use ForstOrDefault in the both cases, to select Nathan and to select the first Dog (no lambda expression just Dogs.FirstOrDefault())


Console.WriteLine("\nFind and print all Freddy Gordin's dogs from race boxer and bulldog older than 1 year, ordered by name - DESCENDING ORDER");
DB.People.FirstOrDefault(a => a.FirstName == "Freddy" && a.LastName == "Gordon").Dogs
                           .Where(b => (b.Race == Race.Boxer || b.Race == Race.Bulldog) && b.Age > 1)
                           .OrderByDescending(d => d.Name).ToList().PrintEntities();
//RP: excelent combination of LINQ methods

Console.WriteLine("\nFind and print all white dogs names from Cristofer, Freddy, Erin and Amelia, ordered by Name - ASCENDING ORDER");
DB.People.Where(a => a.FirstName == "Freddy" || a.FirstName == "Erin" || a.FirstName == "Amelia" || a.FirstName == "Cristofer")
                            .SelectMany(t => t.Dogs)
                            .OrderBy(b => b.Name)
                            .Where(c => c.Color == "White").ToList().PrintEntities();
//RP: excelent combination of LINQ methods
