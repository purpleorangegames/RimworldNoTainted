# NoTainted

Skips the tainted flag when pawns die

Every time a pawn dies the game checks if the apparel it was wearing needs to be tainted, this mod puts the flag back to what it was before, so apparel never gets tainted that way.
On 1.7 it also does the same when a pawn turns into a shambler (Anomaly).

Apparel that was already tainted stays tainted. You can add it mid playthrough.

Steam version: https://steamcommunity.com/sharedfiles/filedetails/?id=2004935468

Requires Harmony.

## Versions

1.7 is built from the code in the Source folder.

1.1 to 1.6 use the last dll I released for them (Legacy folder), I don't have the source for that one anymore.

## Building

You need the .NET 10 SDK, then inside this folder run:

    dotnet build Source -c Release

The dll goes to 1.7/Assemblies. To test it, copy or link this folder to RimWorld/Mods.

## License

CC0, you can do whatever you want with it, no need to give credits.

AI was used to help code/fix issues
