import { Cotal.WebAdminPage } from './app.po';

describe('cotal.web-admin App', () => {
  let page: Cotal.WebAdminPage;

  beforeEach(() => {
    page = new Cotal.WebAdminPage();
  });

  it('should display welcome message', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('Welcome to app!');
  });
});
