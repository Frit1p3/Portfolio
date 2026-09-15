using Microsoft.Playwright;

namespace Portfolio.Tests;

public sealed class PlaywrightSmokeTests
{
    [Fact]
    public async Task Home_page_exposes_core_content_when_base_url_is_configured()
    {
        if (!TryGetBaseUrl(out var baseUrl))
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

        await Expect(page.GetByRole(AriaRole.Heading, new() { Name = "Interfaces industrielles qui transforment la donnee en decision." }))
            .ToBeVisibleAsync();
        await Expect(page.GetByText("Cartographie des flux metier")).ToBeVisibleAsync();
        await Expect(page.GetByRole(AriaRole.Heading, new() { Name = "De la complexite terrain au parcours utilisable." }))
            .ToBeVisibleAsync();
        await Expect(page.GetByRole(AriaRole.Heading, new() { Name = "Des produits front-end pour les usages terrain." }))
            .ToBeVisibleAsync();
        await Expect(page.GetByRole(AriaRole.Heading, new() { Name = "Rassembler les signaux atelier dans un dashboard actionnable." }))
            .ToBeVisibleAsync();
        await Expect(page.GetByRole(AriaRole.Heading, new() { Name = "Passons d'un besoin metier a une interface utile." }))
            .ToBeVisibleAsync();
        await Expect(page.GetByRole(AriaRole.Link, new() { Name = "Demarrer un echange" }))
            .ToBeVisibleAsync();
    }

    [Fact]
    public async Task Home_page_keeps_motion_sequence_visible_across_responsive_viewports()
    {
        if (!TryGetBaseUrl(out var baseUrl))
        {
            return;
        }

        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = true
        });

        var viewports = new[]
        {
            new ViewportSize { Width = 1440, Height = 1000 },
            new ViewportSize { Width = 768, Height = 960 },
            new ViewportSize { Width = 390, Height = 900 }
        };

        foreach (var viewport in viewports)
        {
            var page = await browser.NewPageAsync(new BrowserNewPageOptions
            {
                ViewportSize = viewport
            });

            await page.GotoAsync(baseUrl, new PageGotoOptions
            {
                WaitUntil = WaitUntilState.NetworkIdle
            });

            await Expect(page.Locator(".motion-sequence")).ToBeVisibleAsync();
            await Expect(page.GetByRole(AriaRole.Button, new() { Name = "Precedent" })).ToBeVisibleAsync();
            await Expect(page.GetByRole(AriaRole.Button, new() { Name = "Suivant" })).ToBeVisibleAsync();
            await Expect(page.GetByRole(AriaRole.Button, new() { Name = "Rejouer" })).ToBeVisibleAsync();
            await Expect(page.GetByRole(AriaRole.Button, new() { Name = "Lecture auto" })).ToBeVisibleAsync();

            Assert.Equal(6, await page.Locator(".motion-sequence__tab").CountAsync());

            var scrollWidth = await page.EvaluateAsync<int>("() => document.documentElement.scrollWidth");
            Assert.True(scrollWidth <= viewport.Width + 1);

            await page.CloseAsync();
        }
    }

    [Fact]
    public async Task Home_page_disables_motion_auto_play_when_reduced_motion_is_preferred()
    {
        if (!TryGetBaseUrl(out var baseUrl))
        {
            return;
        }

        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = true
        });
        await using var context = await browser.NewContextAsync(new BrowserNewContextOptions
        {
            ReducedMotion = ReducedMotion.Reduce,
            ViewportSize = new ViewportSize
            {
                Width = 1440,
                Height = 1000
            }
        });
        var page = await context.NewPageAsync();

        await page.GotoAsync(baseUrl, new PageGotoOptions
        {
            WaitUntil = WaitUntilState.NetworkIdle
        });

        await Expect(page.GetByRole(AriaRole.Button, new() { Name = "Lecture auto indisponible" }))
            .ToBeDisabledAsync();
    }

    private static bool TryGetBaseUrl(out string baseUrl)
    {
        baseUrl = Environment.GetEnvironmentVariable("PORTFOLIO_BASE_URL") ?? string.Empty;

        return !string.IsNullOrWhiteSpace(baseUrl);
    }

    private static ILocatorAssertions Expect(ILocator locator)
    {
        return Assertions.Expect(locator);
    }
}
