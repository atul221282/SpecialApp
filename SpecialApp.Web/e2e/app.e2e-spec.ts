import { TestProjPage } from './app.po';

describe('test-proj App', () => {
  let page: TestProjPage;

  beforeEach(() => {
    page = new TestProjPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
