export const BusinessController = {
  //contacts
  Contacts: `contactus`,
  Create: `contactus`,
  Delete: (id: string) => `contactus/${id}`,
  Activate: (id: string) => `contactus/${id}/activate`,
  Deactivate: (id: string) => `contactus/${id}/deactivate`,
  //private dining
  PrivateDining: `private-dining`,
  //manu
  CreateManu: `manu`,
}
