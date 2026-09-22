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

        await Expect(page.GetByRole(AriaRole.Heading, new() { Name = "Interfaces industrielles qui rendent la donnée actionnable" }))
            .ToBeVisibleAsync();
        await Expect(page.GetByText("Cartographie opérationnelle des flux")).ToBeVisibleAsync();
        await Expect(page.GetByRole(AriaRole.Heading, new() { Name = "De la complexité terrain à l'écran utile" }))
            .ToBeVisibleAsync();
        await Expect(page.GetByRole(AriaRole.Heading, new() { Name = "Des produits front-end pour usages industriels" }))
            .ToBeVisibleAsync();
        await Expect(page.GetByRole(AriaRole.Heading, new() { Name = "Rassembler les signaux atelier dans un dashboard actionnable" }))
            .ToBeVisibleAsync();
        await Expect(page.GetByRole(AriaRole.Heading, new() { Name = "Passons d'un besoin métier à une interface utile" }))
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

            await page.GetByRole(AriaRole.Tab, new() { Name = "04 - Convergence des données" }).ClickAsync();
            await Expect(page.Locator(".concept-hero"))
                .ToHaveAttributeAsync("data-motion-state", "data-convergence");
            Assert.Equal(4, await page.Locator(".concept-hero__flow-path").CountAsync());

            await page.GetByRole(AriaRole.Tab, new() { Name = "05 - Focus narratif" }).ClickAsync();
            await Expect(page.Locator(".concept-hero"))
                .ToHaveAttributeAsync("data-motion-state", "concept-switch");
            await Expect(page.Locator(".concept-demo-card--highlighted"))
                .ToContainTextAsync("Mettre les signaux en contexte");

            await page.GetByRole(AriaRole.Tab, new() { Name = "06 - Demo produit" }).ClickAsync();
            await Expect(page.Locator(".concept-hero"))
                .ToHaveAttributeAsync("data-motion-state", "demo-takeover");
            await Expect(page.Locator(".product-demo-panel")).ToBeVisibleAsync();
            await Expect(page.Locator(".concept-tab--active"))
                .ToContainTextAsync("Décider");

            var scrollWidth = await page.EvaluateAsync<int>("() => document.documentElement.scrollWidth");
            Assert.True(scrollWidth <= viewport.Width + 1);

            await page.CloseAsync();
        }
    }

    [Fact]
    public async Task Home_page_keeps_landing_sections_within_responsive_viewports()
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
            new ViewportSize { Width = 1024, Height = 900 },
            new ViewportSize { Width = 768, Height = 960 },
            new ViewportSize { Width = 390, Height = 900 },
            new ViewportSize { Width = 360, Height = 800 }
        };
        var sectionSelectors = new[]
        {
            ".concept-hero",
            ".product-demo-panel",
            ".method-section",
            ".projects-section",
            ".case-study-section",
            ".contact-section",
            ".site-footer"
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

            foreach (var selector in sectionSelectors)
            {
                await Expect(page.Locator(selector)).ToBeVisibleAsync();
            }

            var scrollWidth = await page.EvaluateAsync<int>("() => document.documentElement.scrollWidth");
            Assert.True(scrollWidth <= viewport.Width + 1, $"Viewport {viewport.Width}px has horizontal scroll width {scrollWidth}px.");

            var overflowingSelectors = await page.EvaluateAsync<string[]>(
                @"(selectors) => selectors.filter((selector) => {
                    const element = document.querySelector(selector);
                    if (!element) {
                        return true;
                    }

                    const rect = element.getBoundingClientRect();
                    return rect.left < -1 || rect.right > window.innerWidth + 1;
                })",
                sectionSelectors);

            Assert.True(
                overflowingSelectors.Length == 0,
                $"Viewport {viewport.Width}px has overflowing sections: {string.Join(", ", overflowingSelectors)}");

            await page.CloseAsync();
        }
    }

    [Fact]
    public async Task Home_page_exposes_accessible_landmarks_anchors_and_motion_tabs()
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

        await Expect(page.GetByRole(AriaRole.Banner)).ToBeVisibleAsync();
        await Expect(page.GetByRole(AriaRole.Main)).ToBeVisibleAsync();
        await Expect(page.GetByRole(AriaRole.Contentinfo)).ToBeVisibleAsync();
        await Expect(page.GetByRole(AriaRole.Navigation, new() { Name = "Navigation principale" })).ToBeVisibleAsync();

        Assert.Equal(1, await page.Locator("h1").CountAsync());
        Assert.Equal(5, await page.Locator("main h2").CountAsync());

        var anchorAudit = await page.EvaluateAsync<AnchorAudit>(
            @"() => {
                const links = [...document.querySelectorAll('a[href^=""#""]')];
                const brokenLinks = links
                    .map((link) => link.getAttribute('href'))
                    .filter((href) => !href || !document.querySelector(href));
                const ids = [...document.querySelectorAll('[id]')].map((element) => element.id);
                const duplicateIds = ids.filter((id, index) => ids.indexOf(id) !== index);

                return {
                    brokenLinks: [...new Set(brokenLinks)],
                    duplicateIds: [...new Set(duplicateIds)]
                };
            }");

        Assert.Empty(anchorAudit.BrokenLinks);
        Assert.Empty(anchorAudit.DuplicateIds);

        Assert.Equal(6, await page.Locator(".motion-sequence [role='tab']").CountAsync());
        await Expect(page.GetByRole(AriaRole.Tablist, new() { Name = "Etats de la sequence motion" }))
            .ToBeVisibleAsync();
        await Expect(page.Locator("#motion-sequence-panel")).ToHaveAttributeAsync("role", "tabpanel");
        await Expect(page.Locator("#motion-sequence-panel"))
            .ToHaveAttributeAsync("aria-labelledby", "motion-sequence-tab-message-reveal");

        await page.Locator("#motion-sequence-tab-message-reveal").PressAsync("End");
        await Expect(page.Locator("#motion-sequence-tab-demo-takeover")).ToHaveAttributeAsync("aria-selected", "true");
        await Expect(page.Locator("#motion-sequence-panel"))
            .ToHaveAttributeAsync("aria-labelledby", "motion-sequence-tab-demo-takeover");
        Assert.Equal(
            "motion-sequence-tab-demo-takeover",
            await page.EvaluateAsync<string>("() => document.activeElement?.id ?? ''"));

        await page.Locator("#motion-sequence-tab-demo-takeover").PressAsync("Home");
        await Expect(page.Locator("#motion-sequence-tab-grid-wake")).ToHaveAttributeAsync("aria-selected", "true");
        await Expect(page.Locator("#motion-sequence-panel"))
            .ToHaveAttributeAsync("aria-labelledby", "motion-sequence-tab-grid-wake");
    }

    [Fact]
    public async Task Home_page_exposes_document_metadata_without_browser_errors()
    {
        if (!TryGetBaseUrl(out var baseUrl))
        {
            return;
        }

        var consoleErrors = new List<string>();
        var pageErrors = new List<string>();

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
        page.Console += (_, message) =>
        {
            if (message.Type == "error")
            {
                consoleErrors.Add(message.Text);
            }
        };
        page.PageError += (_, error) => pageErrors.Add(error);

        await page.GotoAsync(baseUrl, new PageGotoOptions
        {
            WaitUntil = WaitUntilState.NetworkIdle
        });

        Assert.Equal("Merryl Bouchereau - Interfaces industrielles .NET", await page.TitleAsync());
        Assert.Equal("fr", await page.Locator("html").GetAttributeAsync("lang"));
        Assert.Equal(
            "width=device-width, initial-scale=1.0",
            await page.Locator("meta[name='viewport']").GetAttributeAsync("content"));
        Assert.Equal(
            "Portfolio Front-End .NET pour interfaces industrielles, dashboards métier et outils terrain B2B.",
            await page.Locator("meta[name='description']").GetAttributeAsync("content"));
        Assert.Equal("#091521", await page.Locator("meta[name='theme-color']").GetAttributeAsync("content"));
        Assert.Equal("/", await page.Locator("base").GetAttributeAsync("href"));
        await Expect(page.GetByRole(AriaRole.Heading, new() { Level = 1 })).ToBeVisibleAsync();

        Assert.Empty(consoleErrors);
        Assert.Empty(pageErrors);
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

    private sealed class AnchorAudit
    {
        public string[] BrokenLinks { get; set; } = Array.Empty<string>();

        public string[] DuplicateIds { get; set; } = Array.Empty<string>();
    }
}
