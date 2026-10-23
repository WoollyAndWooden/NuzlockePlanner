namespace Core.Models;

public class Game : NameIdResource
{
    public VersionGroup version_group { get; set; }
    public override void FullInitialization(NameIdResource data)
    {
        base.FullInitialization(data);
        if (data is Game full)
        {
            version_group = full.version_group;

        }
    }
}
