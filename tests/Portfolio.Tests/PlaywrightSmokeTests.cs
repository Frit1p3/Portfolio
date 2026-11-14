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

        await Expect(page.GetByRole(AriaRole.Heading, new() { Name = "Relier les usages, les interfaces et la donnée" }))
            .ToBeVisibleAsync();
        await Expect(page.Locator(".concept-hero__dashboard")).ToContainTextAsync("Applications métier .NET");
        await Expect(page.GetByRole(AriaRole.Heading, new() { Name = "Du besoin métier à une solution vérifiable" }))
            .ToBeVisibleAsync();
        await Expect(page.GetByRole(AriaRole.Heading, new() { Name = "Des réalisations réelles, chacune avec son statut" }))
            .ToBeVisibleAsync();
        await Expect(page.GetByRole(AriaRole.Heading, new() { Name = "Concevoir un portail BI adapté aux besoins de chaque service" }))
            .ToBeVisibleAsync();
        await Expect(page.GetByRole(AriaRole.Heading, new() { Name = "Votre besoin métier", Level = 2 }))
            .ToBeVisibleAsync();
        await Expect(page.GetByRole(AriaRole.Button, new() { Name = "Préparer le message" }))
            .ToBeVisibleAsync();
    }

    [Fact]
    public async Task Home_page_keeps_compact_hero_visible_across_responsive_viewports()
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

            await Expect(page.Locator(".concept-hero__dashboard")).ToBeVisibleAsync();
            await Expect(page.Locator(".concept-hero__primary-metric")).ToContainTextAsync(".NET");
            Assert.Equal(3, await page.Locator(".concept-hero__dashboard-footer li").CountAsync());
            Assert.Equal(3, await page.Locator(".concept-hero__credentials li").CountAsync());
            Assert.Equal(0, await page.Locator(".motion-sequence").CountAsync());

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
            ".concept-hero__dashboard",
            ".expertise-section",
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
    public async Task Home_page_exposes_accessible_landmarks_and_anchors()
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
        await Expect(page.GetByRole(AriaRole.Navigation, new() { Name = "Navigation de pied de page" })).ToBeVisibleAsync();
        await Expect(page.Locator(".skip-link")).ToHaveAttributeAsync("href", "#main-content");
        await Expect(page.Locator(".site-header .button")).ToHaveAttributeAsync("href", "#contact");

        Assert.Equal(1, await page.Locator("h1").CountAsync());
        Assert.Equal(5, await page.Locator("main h2").CountAsync());
        Assert.Equal(5, await page.Locator(".site-header__nav a").CountAsync());
        Assert.Equal(6, await page.Locator(".site-footer__nav a").CountAsync());
        Assert.Equal(3, await page.Locator(".site-footer__profiles a").CountAsync());
        Assert.Equal(3, await page.Locator(".contact-section__resources a").CountAsync());
        Assert.Equal(3, await page.Locator(".expertise-section .skill-card").CountAsync());
        Assert.Equal(4, await page.Locator(".projects-section__filter").CountAsync());
        Assert.Equal(3, await page.Locator(".projects-section .project-card").CountAsync());
        Assert.Equal(1, await page.Locator(".projects-section .project-card--featured").CountAsync());
        Assert.Equal(3, await page.Locator(".projects-section .project-card__visual").CountAsync());
        Assert.Equal(2, await page.Locator(".case-study-section__comparison-item").CountAsync());
        Assert.Equal(3, await page.Locator(".case-study-section__facts > div").CountAsync());
        Assert.Equal(3, await page.Locator(".contact-form__field").CountAsync());
        await Expect(page.Locator("#expertise")).ToBeVisibleAsync();
        await Expect(page.Locator("#journey")).ToBeVisibleAsync();
        Assert.Equal(4, await page.Locator(".journey-section__timeline li").CountAsync());
        Assert.Equal(2, await page.Locator(".journey-section__proof").CountAsync());

        await page.GetByRole(AriaRole.Button, new() { Name = "Préparer le message" }).ClickAsync();
        Assert.Equal(3, await page.Locator(".contact-form .validation-message").CountAsync());
        await Expect(page.Locator(".contact-form__status"))
            .ToContainTextAsync("Certains champs sont incomplets ou invalides");

        await page.Locator("[data-filter='data']").ClickAsync();
        await Expect(page.Locator("[data-filter='data']")).ToHaveAttributeAsync("aria-pressed", "true");
        Assert.Equal(1, await page.Locator(".projects-section .project-card").CountAsync());

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

        Assert.Equal(0, await page.Locator(".motion-sequence").CountAsync());
        await Expect(page.Locator(".concept-hero__dashboard")).ToHaveAttributeAsync(
            "aria-label",
            "Synthèse des domaines d'intervention");
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

        Assert.Equal("Merryl Bouchereau - Applications métier .NET", await page.TitleAsync());
        Assert.Equal("fr", await page.Locator("html").GetAttributeAsync("lang"));
        Assert.Equal(
            "width=device-width, initial-scale=1.0",
            await page.Locator("meta[name='viewport']").GetAttributeAsync("content"));
        Assert.Equal(
            "Portfolio de Merryl Bouchereau, développeur Full-Stack .NET spécialisé en applications métier, interfaces Blazor et valorisation de la donnée.",
            await page.Locator("meta[name='description']").GetAttributeAsync("content"));
        Assert.Equal(
            "https://frit1p3.github.io/Portfolio/",
            await page.Locator("link[rel='canonical']").GetAttributeAsync("href"));
        Assert.Equal("website", await page.Locator("meta[property='og:type']").GetAttributeAsync("content"));
        Assert.Equal(
            "https://frit1p3.github.io/Portfolio/images/og-portfolio.jpg",
            await page.Locator("meta[property='og:image']").GetAttributeAsync("content"));
        Assert.Equal("summary_large_image", await page.Locator("meta[name='twitter:card']").GetAttributeAsync("content"));
        Assert.Equal("#091521", await page.Locator("meta[name='theme-color']").GetAttributeAsync("content"));
        Assert.Equal("/", await page.Locator("base").GetAttributeAsync("href"));
        await Expect(page.GetByRole(AriaRole.Heading, new() { Level = 1 })).ToBeVisibleAsync();

        Assert.Empty(consoleErrors);
        Assert.Empty(pageErrors);
    }

    [Fact]
    public async Task Home_page_keeps_core_content_visible_when_reduced_motion_is_preferred()
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

        await Expect(page.Locator(".concept-hero__dashboard")).ToBeVisibleAsync();
        await Expect(page.GetByRole(AriaRole.Heading, new() { Name = "Relier les usages, les interfaces et la donnée" }))
            .ToBeVisibleAsync();
        Assert.Equal(0, await page.Locator(".motion-sequence").CountAsync());
    }

    [Fact]
    public async Task Project_case_study_exposes_complete_narrative_across_responsive_viewports()
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
        var projectUrl = new Uri(new Uri(baseUrl.EndsWith('/') ? baseUrl : $"{baseUrl}/"), "projets/pilotage-atelier").ToString();
        var viewports = new[]
        {
            new ViewportSize { Width = 1440, Height = 1000 },
            new ViewportSize { Width = 390, Height = 900 }
        };

        foreach (var viewport in viewports)
        {
            var page = await browser.NewPageAsync(new BrowserNewPageOptions { ViewportSize = viewport });

            await page.GotoAsync(projectUrl, new PageGotoOptions { WaitUntil = WaitUntilState.NetworkIdle });

            await Expect(page.GetByRole(AriaRole.Heading, new() { Name = "Explorer la lisibilité d'un dashboard de pilotage atelier" }))
                .ToBeVisibleAsync();
            await Expect(page.Locator(".project-study__dashboard")).ToBeVisibleAsync();
            Assert.Equal(3, await page.Locator(".project-study__decisions li").CountAsync());
            Assert.Equal(3, await page.Locator(".project-study__system-grid article").CountAsync());
            Assert.Equal(2, await page.Locator(".project-study__outcome").CountAsync());
            Assert.Equal(4, await page.Locator("[data-reveal]").CountAsync());

            Assert.Equal(
                "Prototype conceptuel UX et Blazor utilisant des données de démonstration pour explorer la lisibilité d'un dashboard industriel.",
                await page.Locator("meta[name='description']").GetAttributeAsync("content"));
            Assert.Equal(
                "https://frit1p3.github.io/Portfolio/projets/pilotage-atelier",
                await page.Locator("link[rel='canonical']").GetAttributeAsync("href"));
            Assert.Equal("article", await page.Locator("meta[property='og:type']").GetAttributeAsync("content"));
            Assert.Equal(
                "https://frit1p3.github.io/Portfolio/images/og-portfolio.jpg",
                await page.Locator("meta[property='og:image']").GetAttributeAsync("content"));
            Assert.Equal("summary_large_image", await page.Locator("meta[name='twitter:card']").GetAttributeAsync("content"));

            var scrollWidth = await page.EvaluateAsync<int>("() => document.documentElement.scrollWidth");
            Assert.True(scrollWidth <= viewport.Width + 1, $"Case study at {viewport.Width}px has horizontal scroll width {scrollWidth}px.");

            await page.CloseAsync();
        }
    }

    [Fact]
    public async Task Ssis_case_study_exposes_factual_architecture_across_responsive_viewports()
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
        var projectUrl = new Uri(new Uri(baseUrl.EndsWith('/') ? baseUrl : $"{baseUrl}/"), "projets/poc-ssis").ToString();
        var viewports = new[]
        {
            new ViewportSize { Width = 1440, Height = 1000 },
            new ViewportSize { Width = 390, Height = 900 }
        };

        foreach (var viewport in viewports)
        {
            var page = await browser.NewPageAsync(new BrowserNewPageOptions { ViewportSize = viewport });

            await page.GotoAsync(projectUrl, new PageGotoOptions { WaitUntil = WaitUntilState.NetworkIdle });

            await Expect(page.GetByRole(AriaRole.Heading, new() { Name = "Standardiser un flux ERP avec une architecture SSIS traçable" }))
                .ToBeVisibleAsync();
            await Expect(page.Locator(".ssis-flow")).ToBeVisibleAsync();
            Assert.Equal(5, await page.Locator(".ssis-flow__pipeline li").CountAsync());
            Assert.Equal(4, await page.Locator(".ssis-study__steps li").CountAsync());
            Assert.Equal(4, await page.Locator(".ssis-study__outcomes .project-study__outcome").CountAsync());
            Assert.Equal(5, await page.Locator("[data-reveal]").CountAsync());
            Assert.Equal(2, await page.Locator(".case-study-navigation__card").CountAsync());

            Assert.Equal(
                "Étude de cas d'un POC SSIS opérationnel : extraction ERP incrémentale, staging, contrôles, journalisation et chargement SQL Server.",
                await page.Locator("meta[name='description']").GetAttributeAsync("content"));
            Assert.Equal(
                "https://frit1p3.github.io/Portfolio/projets/poc-ssis",
                await page.Locator("link[rel='canonical']").GetAttributeAsync("href"));
            Assert.Equal("article", await page.Locator("meta[property='og:type']").GetAttributeAsync("content"));

            var scrollWidth = await page.EvaluateAsync<int>("() => document.documentElement.scrollWidth");
            Assert.True(scrollWidth <= viewport.Width + 1, $"SSIS case study at {viewport.Width}px has horizontal scroll width {scrollWidth}px.");

            await page.CloseAsync();
        }
    }

    [Fact]
    public async Task Bi_case_study_exposes_production_evidence_across_responsive_viewports()
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
        var projectUrl = new Uri(new Uri(baseUrl.EndsWith('/') ? baseUrl : $"{baseUrl}/"), "projets/portail-bi").ToString();
        var viewports = new[]
        {
            new ViewportSize { Width = 1440, Height = 1000 },
            new ViewportSize { Width = 390, Height = 900 }
        };

        foreach (var viewport in viewports)
        {
            var page = await browser.NewPageAsync(new BrowserNewPageOptions { ViewportSize = viewport });

            await page.GotoAsync(projectUrl, new PageGotoOptions { WaitUntil = WaitUntilState.NetworkIdle });

            await Expect(page.GetByRole(AriaRole.Heading, new() { Name = "Rendre les données industrielles accessibles dans un portail BI" }))
                .ToBeVisibleAsync();
            await Expect(page.Locator(".bi-screen")).ToBeVisibleAsync();
            Assert.Equal(4, await page.Locator(".bi-study__uses article").CountAsync());
            Assert.Equal(4, await page.Locator(".bi-study__decisions li").CountAsync());
            Assert.Equal(4, await page.Locator(".bi-study__outcomes .project-study__outcome").CountAsync());
            Assert.Equal(5, await page.Locator("[data-reveal]").CountAsync());
            Assert.Equal(2, await page.Locator(".case-study-navigation__card").CountAsync());

            Assert.Equal(
                "Étude de cas d'un portail BI industriel en production : écrans Blazor responsive, filtres avancés, graphiques, exports et intégrations Full-Stack.",
                await page.Locator("meta[name='description']").GetAttributeAsync("content"));
            Assert.Equal(
                "https://frit1p3.github.io/Portfolio/projets/portail-bi",
                await page.Locator("link[rel='canonical']").GetAttributeAsync("href"));
            Assert.Equal("article", await page.Locator("meta[property='og:type']").GetAttributeAsync("content"));

            var scrollWidth = await page.EvaluateAsync<int>("() => document.documentElement.scrollWidth");
            Assert.True(scrollWidth <= viewport.Width + 1, $"BI case study at {viewport.Width}px has horizontal scroll width {scrollWidth}px.");

            await page.CloseAsync();
        }
    }

    [Fact]
    public async Task Cicd_case_study_exposes_traceability_and_limits_across_responsive_viewports()
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
        var projectUrl = new Uri(new Uri(baseUrl.EndsWith('/') ? baseUrl : $"{baseUrl}/"), "projets/ci-cd-cesizen").ToString();
        var viewports = new[]
        {
            new ViewportSize { Width = 1440, Height = 1000 },
            new ViewportSize { Width = 390, Height = 900 }
        };

        foreach (var viewport in viewports)
        {
            var page = await browser.NewPageAsync(new BrowserNewPageOptions { ViewportSize = viewport });

            await page.GotoAsync(projectUrl, new PageGotoOptions { WaitUntil = WaitUntilState.NetworkIdle });

            await Expect(page.GetByRole(AriaRole.Heading, new() { Name = "Transformer un déploiement ponctuel en livraison maîtrisée" }))
                .ToBeVisibleAsync();
            await Expect(page.Locator(".cicd-pipeline")).ToBeVisibleAsync();
            Assert.Equal(6, await page.Locator(".cicd-pipeline__stages li").CountAsync());
            Assert.Equal(4, await page.Locator(".cicd-study__gates li").CountAsync());
            Assert.Equal(5, await page.Locator(".cicd-study__services article").CountAsync());
            Assert.Equal(6, await page.Locator("[data-reveal]").CountAsync());
            Assert.Equal(2, await page.Locator(".case-study-navigation__card").CountAsync());

            Assert.Equal(
                "Étude de cas CI/CD .NET : GitHub Actions, tests, Trivy, images Docker par SHA, déploiement Azure, supervision et rollback.",
                await page.Locator("meta[name='description']").GetAttributeAsync("content"));
            Assert.Equal(
                "https://frit1p3.github.io/Portfolio/projets/ci-cd-cesizen",
                await page.Locator("link[rel='canonical']").GetAttributeAsync("href"));
            Assert.Equal("article", await page.Locator("meta[property='og:type']").GetAttributeAsync("content"));

            var scrollWidth = await page.EvaluateAsync<int>("() => document.documentElement.scrollWidth");
            Assert.True(scrollWidth <= viewport.Width + 1, $"CI/CD case study at {viewport.Width}px has horizontal scroll width {scrollWidth}px.");

            await page.CloseAsync();
        }
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
