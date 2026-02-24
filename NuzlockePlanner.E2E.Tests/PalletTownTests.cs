using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.MSTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NuzlockePlanner.E2E.Tests
{
    [TestClass]
    public class PalletTownTests : PageTest
    {
        private const string AppUrl = "http://localhost:5096";

        [TestMethod]
        [Description("Checks if both Pokémon Red and Blue have Bulbasaur as an encounter in Pallet Town.")]
        public async Task RedAndBlue_ShouldHaveBulbasaurInPalletTown()
        {
            // Test explanation
            // This test will first navigate to the home page of the application.
            // Then, it will select "Generation I" from the generation dropdown.
            // After that, it will select the "Red" game.
            // It will then click on the "Pallet Town" location on the map.
            // Finally, it will assert that "Bulbasaur" is present in the encounter list.
            // The same steps will be repeated for the "Blue" game.

            await Page.GotoAsync(AppUrl);

            await Page.GetByLabel("Generation:").SelectOptionAsync(new[] { "Generation I" });

            // Check Red
            await Page.GetByLabel("Red").CheckAsync();
            await Page.Locator("[title='Pallet Town']").ClickAsync();
            await Expect(Page.Locator(".info-panel")).ToContainTextAsync("Bulbasaur");

            // Check Blue
            await Page.GetByLabel("Blue").CheckAsync();
            await Page.Locator("[title='Pallet Town']").ClickAsync();
            await Expect(Page.Locator(".info-panel")).ToContainTextAsync("Bulbasaur");
        }

        [TestMethod]
        [Description("Checks if Pokémon Yellow has a Pikachu as an encounter in Pallet Town.")]
        public async Task Yellow_ShouldHavePikachuInPalletTown()
        {
            // Test explanation
            // This test will first navigate to the home page of the application.
            // Then, it will select "Generation I" from the generation dropdown.
            // After that, it will select the "Yellow" game.
            // It will then click on the "Pallet Town" location on the map.
            // Finally, it will assert that "Pikachu" is present in the encounter list.

            await Page.GotoAsync(AppUrl);

            await Page.GetByLabel("Generation:").SelectOptionAsync(new[] { "Generation I" });

            await Page.GetByLabel("Yellow").CheckAsync();
            await Page.Locator("[title='Pallet Town']").ClickAsync();
            await Expect(Page.Locator(".info-panel")).ToContainTextAsync("Pikachu");
        }
    }
}
