export const IsGoogleDocUrl = (str: string) => {
  // url ="https://docs.google.com/document/d/1JZkZwc6BSDnNakI3a3PNg2sh87VY8FEYXGHycVDqNqw/edit";
  return /https:\/\/docs.google.com\/(document|spreadsheets)\/d\/[^\s]+[^]+/g.test(
    str
  );
};
export const getIdFromUrl = (url: string) => {
  const match = url.match(/[-\w]{25,}/) || "";

  return match ? match[0] : "";
};
export const getUrlFromId = (id: string) => {};
