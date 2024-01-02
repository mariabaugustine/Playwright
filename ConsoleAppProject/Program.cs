using Microsoft.Playwright;

//playwright startup

using var playwright =await Playwright.CreateAsync();
//Launch browser

await using var browser=await playwright.Chromium.LaunchAsync();

//Page instance
var context=await browser.NewContextAsync();
var page=await context.NewPageAsync();