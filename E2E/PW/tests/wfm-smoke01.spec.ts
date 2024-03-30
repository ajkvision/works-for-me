import { test, expect } from '@playwright/test';

test('has title', async ({ page }) => {
  await page.goto('http://localhost:5265/Home/TestPlans/');

  // Expect a title "to contain" a substring.
  await expect(page).toHaveTitle(/Test plans/);
});

test('home link', async ({ page }) => {
  await page.goto('http://localhost:5265/Home/TestPlans/');

  // Click the get started link.
  await page.getByRole('link', { name: 'Home' }).click();

  // Expects page to have a heading with the name of Installation.
  await expect(page.getByRole('heading', { name: 'Welcome' })).toBeVisible();
});

test('at least one details link', async ({ page }) => {
  await page.goto('http://localhost:5265/Home/TestPlans/');

  // Click the get started link.
  await expect(page.getByRole('link', { name: 'View' }).first()).toBeVisible();
  
});

test('should be possible navigate to details', async ({ page }) => {
  await page.goto('http://localhost:5265/Home/TestPlans/');

  // Click the get started link.
  await page.getByRole('link', { name: 'View' }).first().click();

  await expect(page.getByRole('link', { name: 'Download as json' }).first()).toBeVisible();
  
});


test('view copy and delete links shoidl be visible', async ({ page }) => {
  await page.goto('http://localhost:5265/Home/TestPlans/');

  // Click the get started link.
  await expect(page.getByRole('link', { name: 'View' }).first()).toBeVisible();

  await expect(page.getByRole('link', { name: 'Copy' }).first()).toBeVisible();
  await expect(page.getByRole('link', { name: 'Delete' }).first()).toBeVisible();
});

test('home and test plans shoidl be visible', async ({ page }) => {
  await page.goto('http://localhost:5265/Home/TestPlans/');

  // Click the get started link.
  await expect(page.getByRole('link', { name: 'Home' }).first()).toBeVisible();

  await expect(page.getByRole('link', { name: 'Test plans' }).first()).toBeVisible();
});




test('should have downloads links', async ({ page }) => {
  await page.goto('http://localhost:5265/Home/TestPlans/');

  // Click the get started link.
  await page.getByRole('link', { name: 'View' }).first().click();

  await expect(page.getByRole('link', { name: 'Download as json' }).first()).toBeVisible();

  await expect(page.getByRole('link', { name: 'Download as text file' }).first()).toBeVisible();
  
});

test('verify text file downloads', async ({ page }) => {
  await page.goto('http://localhost:5265/Home/TestPlans/');

  // Click the get started link.
  await page.getByRole('link', { name: 'View' }).first().click();

  const downloadPromise = page.waitForEvent('download');

  await page.getByRole('link', { name: 'Download as text file' }).first().click();
  
  const download = await downloadPromise;

  // Wait for the download process to complete and save the downloaded file somewhere.
  await download.saveAs(download.suggestedFilename());

});



test('shoud  have back button', async ({ page }) => {
  await page.goto('http://localhost:5265/Home/TestPlans/');

  // Click the get started link.
  await page.getByRole('link', { name: 'View' }).first().click();

  await expect(page.getByRole('link', { name: 'Back' })).toBeVisible();

});




