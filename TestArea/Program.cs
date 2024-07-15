// using System.Text.RegularExpressions;

// var current = Directory.GetCurrentDirectory();
// System.Console.WriteLine(current);

// string pattern = @"\.csproj$";

// var dir = Directory.GetFiles("./");
// var dirs = dir.FirstOrDefault( d => Regex.IsMatch(d, pattern))!.Replace("./","");

// var sla = Path.Combine(current, dirs);

// System.Console.WriteLine(sla);



// // string path = "./example.xml";
// // XMLManipulator manipulator = new(path);
// // await manipulator.ReadAsync();
// // var packages = manipulator.GetPackages();

// // List<Tag> newPackages = [
// //     new(
// //         "PackageReference",
// //         "",
// //         new(){
// //             {"Include","AspNetCore.Genesis"},
// //             {"Version","1.0.3"}
// //         }
// //     )
// // ];

// // bool hasPakcage = manipulator.VerifyPackageReference("AspNetCore.Genesis","1.0.3");
// // if(!hasPakcage)
// // {
// //     Tag itemgroup = new("ItemGroup", newPackages, null);
// //     manipulator.AddTags([itemgroup]);
// // }

using Genesis.Generator;
System.Console.WriteLine("hello");
var gns = await GenesisGenerator.GetLatestVersion();
System.Console.WriteLine(gns);
