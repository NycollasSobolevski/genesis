
string path = "./example.xml";
XMLManipulator manipulator = new(path);
await manipulator.ReadAsync();
var packages = manipulator.GetPackages();

List<Tag> newPackages = [
    new(
        "PackageReference",
        "",
        new(){
            {"Include","AspNetCore.Genesis"},
            {"Version","1.0.3"}
        }
    )
];


Tag itemgroup = new("ItemGroup", newPackages, null);

System.Console.WriteLine(itemgroup.ToString());

manipulator.AddTags([itemgroup]);
