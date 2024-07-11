namespace Genesis.Generator.Templates;

public partial class GenesisTemplate 
{
    public string GetProjectTemplate()
    {
        return """
        <ItemGroup>
            <PackageReference Include="AspNetCore.Genesis" Version="1.0.3" />
        </ItemGroup>
        """;
    }
}