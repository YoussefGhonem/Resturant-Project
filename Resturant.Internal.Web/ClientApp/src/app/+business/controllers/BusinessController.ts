export const BusinessController = {
  //contacts
  Contacts: `contactus`,
  Create: `contactus`,
  Delete: (id: string) => `contactus/${id}`,
  Activate: (id: string) => `contactus/${id}/activate`,
  Deactivate: (id: string) => `contactus/${id}/deactivate`,
  //private dining
  PrivateDining: `private-dining`,
  //menu
  CreateMenu: `menu`,
  Categories: `menu/categories`,
  SubCategories: `menu/sub-categories`,
  CategoriesDetails: (id: string) => `menu/categories/${id}`,
  UpdateSubCategory: (id: string) => `menu/sub-category/${id}`,
  UpdateCategory: (id: string) => `menu/category/${id}`,
  // happenings
  happenings: 'happenings',
  CreateHappening: 'happenings',
  UpdateHappening: 'happenings',

}
