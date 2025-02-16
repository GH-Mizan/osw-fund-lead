import { OSWTemplatePage } from './app.po';

describe('OSW App', function() {
  let page: OSWTemplatePage;

  beforeEach(() => {
    page = new OSWTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
