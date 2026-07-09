using Microsoft.Playwright;

namespace Portfolio.Tests;

public sealed class PlaywrightSmokeTests
{
    [Fact]
    public async Task Home_page_exposes_core_content_when_base_url_is_configured()
    {
        var baseUrl = Environment.GetEnvironmentVariable("PORTFOLIO_BASE_URL");

        if (string.IsNullOrWhiteSpace(baseUrl))
        {
            return;
        }

        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = true
        });

        var page = await browser.NewPageAsync(new BrowserNewPageOptions
        {
            ViewportSize = new ViewportSize
            {
                Width = 1440,
                Height = 1000
            }
        });

        await page.GotoAsync(baseUrl, new PageGotoOptions
        {
            WaitUntil = WaitUntilState.NetworkIdle
        });

        await Expect(page.GetByRole(AriaRole.Heading, new() { Name = "Interfaces metier industrielles, lisibles et orientees decision." }))
            .ToBeVisibleAsync();
        await Expect(page.GetByText("Cartographie des flux metier")).ToBeVisibleAsync();
    }

    private static ILocatorAssertions Expect(ILocator locator)
    {
        return Assertions.Expect(locator);
    }
}
