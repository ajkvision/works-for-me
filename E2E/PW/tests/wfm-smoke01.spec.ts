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