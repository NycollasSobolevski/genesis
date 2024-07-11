
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

bool hasPakcage = manipulator.VerifyPackageReference("AspNetCore.Genesis","1.0.3");
if(!hasPakcage)
{
    Tag itemgroup = new("ItemGroup", newPackages, null);
    manipulator.AddTags([itemgroup]);
}
